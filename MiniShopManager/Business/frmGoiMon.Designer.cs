namespace MyRMS.NghiepVu
{
    partial class frmGoiMon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoiMon));
            this.picHinhAnh = new DevExpress.XtraEditors.PictureEdit();
            this.txtSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.barCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.EditValue = ((object)(resources.GetObject("picHinhAnh.EditValue")));
            this.picHinhAnh.Location = new System.Drawing.Point(21, 23);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            this.picHinhAnh.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picHinhAnh.Size = new System.Drawing.Size(123, 131);
            this.picHinhAnh.TabIndex = 9;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSoLuong.Location = new System.Drawing.Point(163, 69);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.txtSoLuong.Properties.Appearance.Options.UseFont = true;
            this.txtSoLuong.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSoLuong.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSoLuong.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtSoLuong.Size = new System.Drawing.Size(58, 40);
            this.txtSoLuong.TabIndex = 18;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(163, 23);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(58, 40);
            this.simpleButton1.TabIndex = 20;
            this.simpleButton1.Text = "+1";
            // 
            // btnDong
            // 
            this.btnDong.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDong.Appearance.Options.UseFont = true;
            this.btnDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.ImageOptions.Image")));
            this.btnDong.Location = new System.Drawing.Point(129, 160);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(92, 30);
            this.btnDong.TabIndex = 22;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // barCapNhat
            // 
            this.barCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.barCapNhat.Appearance.Options.UseFont = true;
            this.barCapNhat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCapNhat.ImageOptions.Image")));
            this.barCapNhat.Location = new System.Drawing.Point(21, 160);
            this.barCapNhat.Name = "barCapNhat";
            this.barCapNhat.Size = new System.Drawing.Size(90, 30);
            this.barCapNhat.TabIndex = 21;
            this.barCapNhat.Text = "Đồng ý";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(163, 114);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(58, 40);
            this.simpleButton2.TabIndex = 20;
            this.simpleButton2.Text = "-1";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // frmGoiMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 210);
            this.ControlBox = false;
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.barCapNhat);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.picHinhAnh);
            this.IconOptions.Image = global::MyRMS.Properties.Resources.Custo_Man_Christmas_Globe_Internet_128;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGoiMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GỌI THỰC ĐƠN";
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picHinhAnh;
        private DevExpress.XtraEditors.SpinEdit txtSoLuong;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton barCapNhat;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}