namespace MyRMS
{
    partial class frmDangNhap
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lnkChinhSua = new System.Windows.Forms.LinkLabel();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnDongY = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkNho = new DevExpress.XtraEditors.CheckEdit();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.txtTenDangNhap = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(219, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(296, 29);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "THÔNG TIN ĐĂNG NHẬP";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(207, 133);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 17);
            this.labelControl1.TabIndex = 30;
            this.labelControl1.Text = "Mật khẩu:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(207, 98);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(98, 17);
            this.labelControl4.TabIndex = 29;
            this.labelControl4.Text = "Tên đăng nhập:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lnkChinhSua);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 253);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(543, 28);
            this.panelControl2.TabIndex = 32;
            // 
            // lnkChinhSua
            // 
            this.lnkChinhSua.AutoSize = true;
            this.lnkChinhSua.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lnkChinhSua.Location = new System.Drawing.Point(403, 5);
            this.lnkChinhSua.Name = "lnkChinhSua";
            this.lnkChinhSua.Size = new System.Drawing.Size(120, 17);
            this.lnkChinhSua.TabIndex = 33;
            this.lnkChinhSua.TabStop = true;
            this.lnkChinhSua.Text = "Cấu hình máy chủ";
            this.lnkChinhSua.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChinhSua_LinkClicked);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(12, 5);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(0, 16);
            this.labelControl6.TabIndex = 30;
            // 
            // btnDongY
            // 
            this.btnDongY.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDongY.Appearance.Options.UseFont = true;
            this.btnDongY.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDongY.ImageOptions.Image")));
            this.btnDongY.Location = new System.Drawing.Point(311, 198);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(98, 25);
            this.btnDongY.TabIndex = 27;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnDong
            // 
            this.btnDong.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDong.Appearance.Options.UseFont = true;
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.ImageOptions.Image")));
            this.btnDong.Location = new System.Drawing.Point(429, 198);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(94, 25);
            this.btnDong.TabIndex = 28;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::MyRMS.Properties.Resources.Paomedia_Small_N_Flat_Shop_512;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 187);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // chkNho
            // 
            this.chkNho.Location = new System.Drawing.Point(308, 166);
            this.chkNho.Name = "chkNho";
            this.chkNho.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkNho.Properties.Appearance.Options.UseFont = true;
            this.chkNho.Properties.Caption = "Nhớ tên đăng nhập.";
            this.chkNho.Size = new System.Drawing.Size(154, 21);
            this.chkNho.TabIndex = 31;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(312, 130);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMatKhau.Properties.Appearance.Options.UseFont = true;
            this.txtMatKhau.Properties.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(211, 22);
            this.txtMatKhau.TabIndex = 26;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(312, 95);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTenDangNhap.Properties.Appearance.Options.UseFont = true;
            this.txtTenDangNhap.Size = new System.Drawing.Size(211, 22);
            this.txtTenDangNhap.TabIndex = 25;
            // 
            // frmDangNhap
            // 
            this.AcceptButton = this.btnDongY;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(543, 281);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.chkNho);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDangNhap);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmDangNhap.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SHOP MANAGER";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chkNho;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton btnDongY;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraEditors.TextEdit txtTenDangNhap;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.LinkLabel lnkChinhSua;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}