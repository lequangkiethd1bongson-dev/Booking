using BookingPR.Data;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZXing;
using System.Data.Entity;
using ZXing.Common;

namespace BookingPR
{
    public partial class LichsuUC : DevExpress.XtraEditors.XtraUserControl
    {
        private int? lastKhachHangId = null;

        public LichsuUC()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.VisibleChanged += LichsuUC_VisibleChanged;
            // wire up QR button click (designer leaves wiring to constructor)
            this.btnqrcode.Click += Btnqrcode_Click;
        }
        public void RefreshData()
        {
            LoadLS(force: true);
        }

        private void LichsuUC_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadLS();
            }
        }
        private void LoadLS(bool force = false)
        {
            try
            {
                var current = LoginUC.CurrentUser.KhachHienTai;
                int? currentId = current?.KhachHangID;
                if (!force && currentId != null && lastKhachHangId == currentId)
                    return;

                // Nếu chưa đăng nhập -> clear grid, không show MessageBox
                if (current == null)
                {
                    dgv1.DataSource = new List<object>();
                    lastKhachHangId = null;
                    ClearDetails();
                    return;
                }

                using (var db = new Model1())
                {
                    int khId = current.KhachHangID;

                    var list = db.DatBan
                        .Where(d => d.KhachHang.KhachHangID == khId)
                        .Select(d => new
                        {
                            DatBanID = d.DatBanID,
                            KhachHang = d.KhachHang.HoTen,
                            SDT = d.KhachHang.SDT,
                            d.SoNguoi,
                            d.GioDat,
                            d.GhiChu,
                            d.TrangThai,
                            TongTien = d.ChiTietDatBan.Sum(ct => (decimal?)ct.SoLuong * (ct.MonAn.Gia)) ?? 0
                        })
                        .OrderByDescending(d => d.GioDat)
                        .ToList();

                    dgv1.DataSource = list;
                    if (dgv1.Columns.Contains("KhachHang")) dgv1.Columns["KhachHang"].HeaderText = "Khách hàng";
                    if (dgv1.Columns.Contains("SDT")) dgv1.Columns["SDT"].HeaderText = "Số điện thoại";
                    if (dgv1.Columns.Contains("SoNguoi")) dgv1.Columns["SoNguoi"].HeaderText = "Số người";
                    if (dgv1.Columns.Contains("GioDat")) dgv1.Columns["GioDat"].HeaderText = "Giờ đặt";
                    if (dgv1.Columns.Contains("GhiChu")) dgv1.Columns["GhiChu"].HeaderText = "Ghi chú";
                    if (dgv1.Columns.Contains("TrangThai")) dgv1.Columns["TrangThai"].HeaderText = "Trạng thái";
                    if (dgv1.Columns.Contains("TongTien"))
                    {
                        dgv1.Columns["TongTien"].HeaderText = "Tổng tiền";
                        dgv1.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                        dgv1.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    lastKhachHangId = khId;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi tải lịch sử đặt bàn: " + ex.Message);
            }
        }

        private void ClearDetails()
        {
            lblKhachHang.Text = "Khách: ";
            lblSDT.Text = "Số điện thoại: ";
            lblSoNguoi.Text = "Số người: ";
            lblGioDat.Text = "Giờ đặt: ";
            lblGhiChu.Text = "Ghi chú: ";
            lblTrangThai.Text = "Trạng thái: ";
            lblTongTien.Text = "Tổng tiền: ";
            if (pbQrPreview.Image != null)
            {
                pbQrPreview.Image.Dispose();
                pbQrPreview.Image = null;
            }
        }

        private void LichsuUC_Load(object sender, EventArgs e)
        {
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.MultiSelect = false;
            dgv1.CellClick += dgv1_CellClick;

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btnqrcode_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                ofd.Title = "Chọn ảnh chứa QR code";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    // Load image via stream to avoid file-locking and invalid-cast issues
                    using (var fs = System.IO.File.OpenRead(ofd.FileName))
                    using (var img = Image.FromStream(fs))
                    using (var bmp = new Bitmap(img))
                    {
                        // show preview copy
                        if (pbQrPreview.Image != null)
                        {
                            pbQrPreview.Image.Dispose();
                            pbQrPreview.Image = null;
                        }
                        pbQrPreview.Image = new Bitmap(bmp);

                        // decode (existing code)
                        var reader = new BarcodeReader
                        {
                            AutoRotate = true,
                            TryInverted = true,
                            Options = new DecodingOptions { TryHarder = true }
                        };

                        var result = reader.Decode(bmp);

                        // fallback decoding code omitted for brevity (keep your robust fallback here if needed)

                        if (result == null)
                        {
                            XtraMessageBox.Show("Không đọc được QR code trong ảnh.", "QR Scan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string text = result.Text.Trim();
                        int datBanId;
                        if (!int.TryParse(text, out datBanId))
                        {
                            var parts = text.Split(new[] { ':', '#' }, 2);
                            if (parts.Length == 2 && int.TryParse(parts[1], out datBanId))
                            {
                                // parsed
                            }
                            else
                            {
                                XtraMessageBox.Show("QR code không chứa mã đặt bàn hợp lệ.", "QR Scan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        using (var db = new Model1())
                        {
                            var datBan = db.DatBan
                                .Include(d => d.KhachHang)
                                .Include(d => d.ChiTietDatBan.Select(ct => ct.MonAn))
                                .FirstOrDefault(d => d.DatBanID == datBanId);

                            if (datBan == null)
                            {
                                XtraMessageBox.Show("Không tìm thấy đặt bàn với mã: " + datBanId, "QR Scan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            // populate details panel
                            lblKhachHang.Text = "Khách: " + (datBan.KhachHang?.HoTen ?? "");
                            lblSDT.Text = "Số điện thoại: " + (datBan.KhachHang?.SDT ?? "");
                            lblSoNguoi.Text = "Số người: " + datBan.SoNguoi;
                            lblGioDat.Text = "Giờ đặt: " + datBan.GioDat.ToString();
                            lblGhiChu.Text = "Ghi chú: " + (datBan.GhiChu ?? "");
                            lblTrangThai.Text = "Trạng thái: " + (datBan.TrangThai ?? "");

                            decimal tong = datBan.ChiTietDatBan.Sum(ct => (decimal?)(ct.SoLuong * (ct.MonAn?.Gia ?? 0))) ?? 0;
                            lblTongTien.Text = "Tổng tiền: " + tong.ToString("N0");

                            // select row if present
                            try
                            {
                                foreach (DataGridViewRow row in dgv1.Rows)
                                {
                                    if (row.Cells["DatBanID"] != null && row.Cells["DatBanID"].Value != null)
                                    {
                                        int id;
                                        if (int.TryParse(row.Cells["DatBanID"].Value.ToString(), out id) && id == datBanId)
                                        {
                                            row.Selected = true;
                                            dgv1.FirstDisplayedScrollingRowIndex = row.Index;
                                            break;
                                        }
                                    }
                                }
                            }
                            catch { }
                        }

                        // Ask user if they want to open booking page to make a new booking
                        var dr = XtraMessageBox.Show("Mở trang đặt bàn mới?", "Tiếp tục", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                var mainForm = this.FindForm() as Form1;
                                if (mainForm != null)
                                {
                                    // use the public navigation method
                                    mainForm.NavigateToBooking();
                                }
                            }
                            catch { }
                        }
                    }
                }
                catch (System.OutOfMemoryException)
                {
                    XtraMessageBox.Show("Tập tin không phải là ảnh hợp lệ hoặc đã bị hỏng.", "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi khi quét QR: " + ex.Message, "QR Scan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int? selectedDatBanId = null;

        private void btHuy_Click(object sender, EventArgs e)
        {
            if (selectedDatBanId == null)
            {
                XtraMessageBox.Show("Vui lòng chọn một đơn đặt bàn để hủy.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int datBanId = selectedDatBanId.Value;

            using (var db = new Model1())
            {
                var datBan = db.DatBan.FirstOrDefault(d => d.DatBanID == datBanId);
                if (datBan == null)
                {
                    XtraMessageBox.Show("Không tìm thấy đơn đặt bàn này!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra thời gian hủy: chỉ cho phép hủy trước 12 tiếng
                TimeSpan timeDiff = datBan.GioDat - DateTime.Now;
                if (timeDiff.TotalHours < 12)
                {
                    XtraMessageBox.Show("Không thể hủy đơn này vì còn dưới 12 tiếng trước giờ đặt!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận xóa
                var result = XtraMessageBox.Show(
                    "Bạn có chắc chắn muốn hủy đơn đặt bàn này?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa chi tiết đặt bàn trước
                    var chiTiet = db.ChiTietDatBan.Where(ct => ct.DatBanID == datBanId).ToList();
                    db.ChiTietDatBan.RemoveRange(chiTiet);

                    // Sau đó xóa đơn chính
                    db.DatBan.Remove(datBan);
                    db.SaveChanges();

                    XtraMessageBox.Show("Đơn đặt bàn đã được hủy thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 🔄 Load lại dữ liệu bảng
                    LoadLS(force: true);
                    selectedDatBanId = null;
                }
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dgv1.Rows[e.RowIndex].Cells["DatBanID"].Value != null)
            {
                selectedDatBanId = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells["DatBanID"].Value);
            }
        }
    }
}

    

