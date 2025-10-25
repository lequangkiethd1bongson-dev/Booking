namespace BookingPR
{
    partial class Booking2
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
        /// Required method for Designer support 
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Booking2));
            this.flowMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTiepTuc = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowMenu
            // 
            this.flowMenu.AutoScroll = true;
            this.flowMenu.BackColor = System.Drawing.Color.LightGray;
            this.flowMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowMenu.Location = new System.Drawing.Point(0, 43);
            this.flowMenu.Name = "flowMenu";
            this.flowMenu.Padding = new System.Windows.Forms.Padding(9);
            this.flowMenu.Size = new System.Drawing.Size(732, 434);
            this.flowMenu.TabIndex = 0;
            this.flowMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.flowMenu_Paint);
            // 
            // btnTiepTuc
            // 
            this.btnTiepTuc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTiepTuc.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTiepTuc.Appearance.Options.UseFont = true;
            this.btnTiepTuc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTiepTuc.ImageOptions.Image")));
            this.btnTiepTuc.Location = new System.Drawing.Point(608, 9);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnTiepTuc.Size = new System.Drawing.Size(111, 35);
            this.btnTiepTuc.TabIndex = 1;
            this.btnTiepTuc.Text = "Tiếp tục";
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(9, 9, 0, 9);
            this.lblTitle.Size = new System.Drawing.Size(732, 43);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Chọn món ăn bạn muốn đặt trước";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnTiepTuc);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 477);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(732, 52);
            this.panelBottom.TabIndex = 3;
            this.panelBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBottom_Paint);
            // 
            // Booking2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.flowMenu);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelBottom);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Booking2";
            this.Size = new System.Drawing.Size(732, 529);
            this.Load += new System.EventHandler(this.Booking2_Load);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowMenu;
        private DevExpress.XtraEditors.SimpleButton btnTiepTuc;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelBottom;
    }
}
