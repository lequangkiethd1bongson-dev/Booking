using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace BookingPR
{
    public partial class Booking3 : UserControl
    {
        private string ten, sdt, ghiChu;
        private int soNguoi;
        private DateTime gioDen;
        private List<(string tenMon, int soLuong, decimal donGia)> dsMon;

        private bool isProcessing = false;
        public Booking3(string hoTen, string soDT, int soNguoi, DateTime gioDen, string ghiChu, List<(string, int, decimal)> dsMon)
        {
            
            InitializeComponent();
            this.ten = hoTen;
            this.sdt = soDT;
            this.soNguoi = soNguoi;
            this.gioDen = gioDen;
            this.ghiChu = ghiChu;
            this.dsMon = dsMon;
            LoadData();
        }

        private void LoadData()
        {
            lblHoTen.Text = $"Họ tên: {ten}";
            lblSDT.Text = $"Số điện thoại: {sdt}";
            lblSoNguoi.Text = $"Số người: {soNguoi}";
            lblGioDen.Text = $"Giờ đến: {gioDen.ToString("g")}";
            lblGhiChu.Text = $"Ghi chú: {ghiChu}";
            
            dgvMonAn.DataSource = dsMon.Select(m => new
            {
                Tên_Món = m.tenMon,
                Số_Lượng = m.soLuong,
                Đơn_Giá = m.donGia,
                Thành_Tiền = m.soLuong * m.donGia
            }).ToList();

            decimal tongtien = dsMon.Sum(m => m.soLuong * m.donGia);
            lblTongTien.Text = $"Tổng tiền: {tongtien:C}";
        }
        private void Booking3_Load(object sender, EventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as Form1;
            if (mainForm != null)
            {
                try
                {
                    mainForm.navigationFrame1.SelectedPage = mainForm.pageHome;
                    return;
                }
                catch { }
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;
            btnXacNhan.Enabled = false;

            int? datBanID = null;

            try
            {
                // TODO: move to App.config later
                string connString = @"Data Source=Trung;Initial Catalog=QLDatBan;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmdKH = new SqlCommand("SELECT KhachHangID FROM KhachHang WHERE SDT = @sdt", conn);
                    cmdKH.Parameters.AddWithValue("@sdt", sdt);
                    object result = cmdKH.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng này!", "Lỗi");
                        return;
                    }
                    int khID = (int)result;

                    SqlCommand cmdDatBan = new SqlCommand(
                        "INSERT INTO DatBan (KhachHangID, SoNguoi, GioDat, GhiChu, TrangThai) OUTPUT INSERTED.DatBanID VALUES (@kh, @so, @gio, @gc, N'Đã xác nhận')", conn);
                    cmdDatBan.Parameters.AddWithValue("@kh", khID);
                    cmdDatBan.Parameters.AddWithValue("@so", soNguoi);
                    cmdDatBan.Parameters.AddWithValue("@gio", gioDen);
                    cmdDatBan.Parameters.AddWithValue("@gc", ghiChu);

                    datBanID = (int)cmdDatBan.ExecuteScalar();

                    foreach (var mon in dsMon)
                    {
                        SqlCommand cmdCT = new SqlCommand(
                            "INSERT INTO ChiTietDatBan (DatBanID, MonAnID, SoLuong) SELECT @db, MonAnID, @sl FROM MonAn WHERE TenMon = @ten", conn);
                        cmdCT.Parameters.AddWithValue("@db", datBanID);
                        cmdCT.Parameters.AddWithValue("@ten", mon.tenMon);
                        cmdCT.Parameters.AddWithValue("@sl", mon.soLuong);
                        cmdCT.ExecuteNonQuery();
                    }

                    // success path: show confirmation with real id
                    MessageBox.Show($"Đặt bàn thành công. Mã đặt: {datBanID}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // generate QR for real reservation id
                    string qrContent = $"DB:{datBanID}";
                    var writer = new BarcodeWriter
                    {
                        Format = BarcodeFormat.QR_CODE,
                        Options = new EncodingOptions { Height = 300, Width = 300, Margin = 1 }
                    };
                    using (var qrBmp = writer.Write(qrContent))
                    {
                        ShowQrDialog(new Bitmap(qrBmp), datBanID.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                // show full error for diagnosis
                MessageBox.Show("Lỗi khi lưu đặt bàn: " + ex.Message + "\n\nChi tiết:\n" + ex.ToString(),
                    "Lỗi khi lưu đặt bàn", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // FALLBACK: generate a temporary QR so you can continue testing QR flow locally
                try
                {
                    string tmpToken = Guid.NewGuid().ToString("N");
                    string fallbackContent = $"TMP:{tmpToken}|{sdt}|{gioDen:O}|soNguoi:{soNguoi}";
                    var writer = new BarcodeWriter
                    {
                        Format = BarcodeFormat.QR_CODE,
                        Options = new EncodingOptions { Height = 300, Width = 300, Margin = 1 }
                    };
                    using (var qrBmp = writer.Write(fallbackContent))
                    {
                        // show dialog with temporary token (datBanID not available)
                        ShowQrDialog(new Bitmap(qrBmp), datBanID ?? -1);
                    }
                }
                catch (Exception exQr)
                {
                    MessageBox.Show("Không thể tạo QR fallback: " + exQr.Message, "Lỗi QR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                isProcessing = false;
                btnXacNhan.Enabled = true;
            }
        }

        private void ShowQrDialog(Bitmap qrBitmap, int datBanID)
        {
            var dlg = new Form()
            {
                Text = $"QR mã đặt {datBanID}",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(360, 420)
            };

            var pb = new PictureBox
            {
                Image = qrBitmap,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Location = new Point(30, 20),
                Size = new Size(300, 300)
            };
            dlg.Controls.Add(pb);

            var lbl = new Label
            {
                Text = $"Mã đặt: {datBanID}",
                Location = new Point(30, 330),
                AutoSize = true,
                Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
            };
            dlg.Controls.Add(lbl);

            var btnSave = new Button
            {
                Text = "Lưu ảnh...",
                Location = new Point(30, 355),
                Size = new Size(100, 30)
            };
            btnSave.Click += (s, e) =>
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PNG Image|*.png";
                    sfd.FileName = $"DatBan_{datBanID}.png";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            qrBitmap.Save(sfd.FileName, ImageFormat.Png);
                            MessageBox.Show("Đã lưu.", "Lưu ảnh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };
            dlg.Controls.Add(btnSave);

            var btnClose = new Button
            {
                Text = "Đóng",
                Location = new Point(240, 355),
                Size = new Size(90, 30)
            };
            btnClose.Click += (s, e) => dlg.Close();
            dlg.Controls.Add(btnClose);

            // Show modal dialog
            dlg.ShowDialog(this.FindForm());
            dlg.Dispose();

            // AFTER dialog closes => reset BookingUC and navigate to the first booking step
            try
            {
                // find parent BookingUC and call StartNewBooking
                Control c = this.Parent;
                while (c != null && !(c is BookingUC))
                {
                    c = c.Parent;
                }
                if (c is BookingUC bookingUc)
                {
                    bookingUc.StartNewBooking();
                }

                var mainForm = this.FindForm() as Form1;
                if (mainForm != null)
                {
                    mainForm.NavigateToBooking();
                }
            }
            catch
            {
                // ignore navigation/reset errors
            }
        }

        private void dgvMonAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
                this.Dispose();
            }
        }

        private void groupThongTin_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Intentionally empty — remove this method and the Designer subscription if no custom painting is required.
        }
    }
}
