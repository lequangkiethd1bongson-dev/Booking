namespace BookingPR
{
    partial class LichsuUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LichsuUC));
            this.btnqrcode = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.pbQrPreview = new System.Windows.Forms.PictureBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblGioDat = new System.Windows.Forms.Label();
            this.lblSoNguoi = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.btHuy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.groupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQrPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnqrcode
            // 
            this.btnqrcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnqrcode.Location = new System.Drawing.Point(758, 505);
            this.btnqrcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnqrcode.Name = "btnqrcode";
            this.btnqrcode.Size = new System.Drawing.Size(140, 39);
            this.btnqrcode.TabIndex = 0;
            this.btnqrcode.Text = "Quét QR";
            this.btnqrcode.UseVisualStyleBackColor = true;
            // 
            // dgv1
            // 
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(12, 12);
            this.dgv1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidth = 51;
            this.dgv1.Size = new System.Drawing.Size(887, 271);
            this.dgv1.TabIndex = 1;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            // 
            // groupDetails
            // 
            this.groupDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDetails.Controls.Add(this.pbQrPreview);
            this.groupDetails.Controls.Add(this.lblTongTien);
            this.groupDetails.Controls.Add(this.lblTrangThai);
            this.groupDetails.Controls.Add(this.lblGhiChu);
            this.groupDetails.Controls.Add(this.lblGioDat);
            this.groupDetails.Controls.Add(this.lblSoNguoi);
            this.groupDetails.Controls.Add(this.lblSDT);
            this.groupDetails.Controls.Add(this.lblKhachHang);
            this.groupDetails.Location = new System.Drawing.Point(12, 295);
            this.groupDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupDetails.Size = new System.Drawing.Size(723, 258);
            this.groupDetails.TabIndex = 2;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Thông tin đặt bàn (sau khi quét QR)";
            // 
            // pbQrPreview
            // 
            this.pbQrPreview.Location = new System.Drawing.Point(502, 25);
            this.pbQrPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbQrPreview.Name = "pbQrPreview";
            this.pbQrPreview.Size = new System.Drawing.Size(198, 209);
            this.pbQrPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbQrPreview.TabIndex = 7;
            this.pbQrPreview.TabStop = false;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(8, 209);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(70, 16);
            this.lblTongTien.TabIndex = 6;
            this.lblTongTien.Text = "Tổng tiền: ";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(8, 178);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(75, 16);
            this.lblTrangThai.TabIndex = 5;
            this.lblTrangThai.Text = "Trạng thái: ";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(8, 147);
            this.lblGhiChu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(58, 16);
            this.lblGhiChu.TabIndex = 4;
            this.lblGhiChu.Text = "Ghi chú: ";
            // 
            // lblGioDat
            // 
            this.lblGioDat.AutoSize = true;
            this.lblGioDat.Location = new System.Drawing.Point(8, 116);
            this.lblGioDat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGioDat.Name = "lblGioDat";
            this.lblGioDat.Size = new System.Drawing.Size(56, 16);
            this.lblGioDat.TabIndex = 3;
            this.lblGioDat.Text = "Giờ đặt: ";
            // 
            // lblSoNguoi
            // 
            this.lblSoNguoi.AutoSize = true;
            this.lblSoNguoi.Location = new System.Drawing.Point(8, 86);
            this.lblSoNguoi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoNguoi.Name = "lblSoNguoi";
            this.lblSoNguoi.Size = new System.Drawing.Size(67, 16);
            this.lblSoNguoi.TabIndex = 2;
            this.lblSoNguoi.Text = "Số người: ";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(8, 55);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(91, 16);
            this.lblSDT.TabIndex = 1;
            this.lblSDT.Text = "Số điện thoại: ";
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(8, 25);
            this.lblKhachHang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(50, 16);
            this.lblKhachHang.TabIndex = 0;
            this.lblKhachHang.Text = "Khách: ";
            // 
            // btHuy
            // 
            this.btHuy.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btHuy.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btHuy.Appearance.Options.UseFont = true;
            this.btHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btHuy.ImageOptions.Image")));
            this.btHuy.Location = new System.Drawing.Point(734, 234);
            this.btHuy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btHuy.Name = "btHuy";
            this.btHuy.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btHuy.Size = new System.Drawing.Size(155, 38);
            this.btHuy.TabIndex = 3;
            this.btHuy.Text = "Hủy đặt bàn";
            this.btHuy.Click += new System.EventHandler(this.btHuy_Click);
            // 
            // LichsuUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btHuy);
            this.Controls.Add(this.groupDetails);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.btnqrcode);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "LichsuUC";
            this.Size = new System.Drawing.Size(930, 566);
            this.Load += new System.EventHandler(this.LichsuUC_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQrPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnqrcode;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.Label lblGioDat;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.PictureBox pbQrPreview;
        private DevExpress.XtraEditors.SimpleButton btHuy;
    }
}
