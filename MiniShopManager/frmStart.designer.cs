namespace MyRMS
{
    partial class frmStart
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.lblTienTrinh = new DevExpress.XtraEditors.LabelControl();
            this.pbarTienTrinh = new DevExpress.XtraEditors.ProgressBarControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbarTienTrinh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTienTrinh
            // 
            this.lblTienTrinh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTienTrinh.Appearance.Options.UseFont = true;
            this.lblTienTrinh.Location = new System.Drawing.Point(21, 21);
            this.lblTienTrinh.Name = "lblTienTrinh";
            this.lblTienTrinh.Size = new System.Drawing.Size(194, 17);
            this.lblTienTrinh.TabIndex = 3;
            this.lblTienTrinh.Text = "Đang khởi động chương trình...";
            // 
            // pbarTienTrinh
            // 
            this.pbarTienTrinh.Location = new System.Drawing.Point(20, 40);
            this.pbarTienTrinh.Name = "pbarTienTrinh";
            this.pbarTienTrinh.Properties.ShowTitle = true;
            this.pbarTienTrinh.Size = new System.Drawing.Size(293, 18);
            this.pbarTienTrinh.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmKhoiDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 83);
            this.ControlBox = false;
            this.Controls.Add(this.lblTienTrinh);
            this.Controls.Add(this.pbarTienTrinh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmKhoiDong.IconOptions.Icon")));
            this.IconOptions.Image = global::MyRMS.Properties.Resources.Custo_Man_Christmas_Globe_Internet_128;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKhoiDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần Mềm Quản Lý Kinh Doanh";
            this.Load += new System.EventHandler(this.frmKhoiDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbarTienTrinh.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTienTrinh;
        private DevExpress.XtraEditors.ProgressBarControl pbarTienTrinh;
        private System.Windows.Forms.Timer timer1;
    }
}