using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BookingPR
{
    public partial class FormAdmin : XtraForm
    {
        private Button btnDoanhThu;
        private Button btnSoLuongMon;
        private Button btnClose;
        private Label lblTitle;
        private Panel topPanel;
        private Panel contentPanel;

        public FormAdmin()
        {
            InitializeComponent();
            InitializeCustomComponents();

            this.Shown += FormAdmin_Shown;
            this.Resize += FormAdmin_Resize;
        }

        private void InitializeCustomComponents()
        {
            this.Text = "📋 Admin Dashboard";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(700, 450);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // 🌈 Header panel
            topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = Color.FromArgb(0, 122, 204)
            };

            lblTitle = new Label
            {
                Text = "ADMIN DASHBOARD",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold),
                ForeColor = Color.White
            };
            topPanel.Controls.Add(lblTitle);

            // 🌟 Content panel
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 30, 0, 0),
                BackColor = Color.White
            };

            // 📊 Button Doanh thu
            btnDoanhThu = CreateStyledButton("📈  Báo cáo Doanh thu", Color.FromArgb(0, 120, 215));
            btnDoanhThu.Click += BtnDoanhThu_Click;

            // 🍽️ Button Số lượng món
            btnSoLuongMon = CreateStyledButton("🍜  Báo cáo Số lượng món", Color.FromArgb(0, 180, 100));
            btnSoLuongMon.Click += BtnSoLuongMon_Click;

            // ❌ Button Đóng
            btnClose = new Button
            {
                Text = "Đóng",
                Width = 120,
                Height = 35,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                BackColor = Color.FromArgb(230, 230, 230),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            // Add vào content
            contentPanel.Controls.Add(btnDoanhThu);
            contentPanel.Controls.Add(btnSoLuongMon);
            contentPanel.Controls.Add(btnClose);

            this.Controls.Add(contentPanel);
            this.Controls.Add(topPanel);
        }

        // 🎨 Hàm tạo nút có phong cách đẹp
        private Button CreateStyledButton(string text, Color baseColor)
        {
            var btn = new Button
            {
                Text = text,
                Width = 220,
                Height = 60,
                Font = new Font("Segoe UI Semibold", 11F),
                BackColor = baseColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;

            // hiệu ứng hover
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ControlPaint.Light(baseColor, 0.2f);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = baseColor;
            };

            return btn;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LayoutButtons();
        }

        private void FormAdmin_Shown(object sender, EventArgs e)
        {
            LayoutButtons();
        }

        private void FormAdmin_Resize(object sender, EventArgs e)
        {
            LayoutButtons();
        }

        private void LayoutButtons()
        {
            int cx = this.ClientSize.Width / 2;
            int top = (this.ClientSize.Height / 2) - 60;

            if (btnDoanhThu != null)
            {
                btnDoanhThu.Left = cx - btnDoanhThu.Width - 15;
                btnDoanhThu.Top = top;
            }

            if (btnSoLuongMon != null)
            {
                btnSoLuongMon.Left = cx + 15;
                btnSoLuongMon.Top = top;
            }

            if (btnClose != null)
            {
                btnClose.Left = (this.ClientSize.Width - btnClose.Width) / 2;
                btnClose.Top = this.ClientSize.Height - btnClose.Height - 25;
            }
        }

        private void BtnDoanhThu_Click(object sender, EventArgs e)
        {
            try
            {
                using (var f = new DoanhThu())
                    f.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở báo cáo Doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSoLuongMon_Click(object sender, EventArgs e)
        {
            try
            {
                using (var f = new SoLuongMon())
                    f.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở báo cáo Số lượng món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
