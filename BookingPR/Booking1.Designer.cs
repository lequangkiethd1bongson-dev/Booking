namespace BookingPR
{
    partial class Booking1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Booking1));
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.numSoNguoi = new DevExpress.XtraEditors.SpinEdit();
            this.dtGioDen = new DevExpress.XtraEditors.DateEdit();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.btTiepTuc = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SĐT = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGioDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGioDen.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(358, 87);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.AutoHeight = false;
            this.txtHoTen.Size = new System.Drawing.Size(133, 28);
            this.txtHoTen.TabIndex = 0;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(358, 138);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.AutoHeight = false;
            this.txtSDT.Size = new System.Drawing.Size(133, 28);
            this.txtSDT.TabIndex = 0;
            // 
            // numSoNguoi
            // 
            this.numSoNguoi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numSoNguoi.Location = new System.Drawing.Point(357, 187);
            this.numSoNguoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numSoNguoi.Name = "numSoNguoi";
            this.numSoNguoi.Properties.AutoHeight = false;
            this.numSoNguoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.numSoNguoi.Size = new System.Drawing.Size(133, 27);
            this.numSoNguoi.TabIndex = 1;
            // 
            // dtGioDen
            // 
            this.dtGioDen.EditValue = null;
            this.dtGioDen.Location = new System.Drawing.Point(358, 241);
            this.dtGioDen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtGioDen.Name = "dtGioDen";
            this.dtGioDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtGioDen.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dtGioDen.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtGioDen.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.dtGioDen.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dtGioDen.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtGioDen.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dtGioDen.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtGioDen.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.dtGioDen.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dtGioDen.Size = new System.Drawing.Size(132, 20);
            this.dtGioDen.TabIndex = 2;
            this.dtGioDen.EditValueChanged += new System.EventHandler(this.dtGioDen_EditValueChanged);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(358, 291);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(136, 26);
            this.txtNote.TabIndex = 3;
            // 
            // btTiepTuc
            // 
            this.btTiepTuc.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTiepTuc.Appearance.Options.UseFont = true;
            this.btTiepTuc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btTiepTuc.ImageOptions.Image")));
            this.btTiepTuc.Location = new System.Drawing.Point(496, 344);
            this.btTiepTuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btTiepTuc.Name = "btTiepTuc";
            this.btTiepTuc.Size = new System.Drawing.Size(93, 40);
            this.btTiepTuc.TabIndex = 4;
            this.btTiepTuc.Text = "Tiếp tục";
            this.btTiepTuc.Click += new System.EventHandler(this.btTiepTuc_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(230, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Họ tên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SĐT
            // 
            this.SĐT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.SĐT.Enabled = false;
            this.SĐT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SĐT.Location = new System.Drawing.Point(230, 139);
            this.SĐT.Name = "SĐT";
            this.SĐT.Size = new System.Drawing.Size(99, 26);
            this.SĐT.TabIndex = 5;
            this.SĐT.Text = "Số diện thoại";
            this.SĐT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(230, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số người";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(230, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ngày đến";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(230, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ghi chú";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(267, 29);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(205, 32);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Thông tin đặt bàn";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // Booking1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SĐT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btTiepTuc);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.dtGioDen);
            this.Controls.Add(this.numSoNguoi);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtHoTen);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Booking1";
            this.Size = new System.Drawing.Size(687, 401);
            this.Load += new System.EventHandler(this.Booking1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGioDen.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGioDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraEditors.SpinEdit numSoNguoi;
        private DevExpress.XtraEditors.DateEdit dtGioDen;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.SimpleButton btTiepTuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SĐT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LabelControl lblTitle;
    }
}
