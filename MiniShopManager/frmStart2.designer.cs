namespace MyRMS
{
    partial class frmStart2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart2));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbarTienTrinh = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblTienTrinh = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbarTienTrinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbarTienTrinh
            // 
            this.pbarTienTrinh.Location = new System.Drawing.Point(93, 225);
            this.pbarTienTrinh.Name = "pbarTienTrinh";
            this.pbarTienTrinh.Properties.ShowTitle = true;
            this.pbarTienTrinh.Size = new System.Drawing.Size(293, 18);
            this.pbarTienTrinh.TabIndex = 0;
            // 
            // lblTienTrinh
            // 
            this.lblTienTrinh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTienTrinh.Appearance.Options.UseFont = true;
            this.lblTienTrinh.Location = new System.Drawing.Point(142, 188);
            this.lblTienTrinh.Name = "lblTienTrinh";
            this.lblTienTrinh.Size = new System.Drawing.Size(194, 17);
            this.lblTienTrinh.TabIndex = 1;
            this.lblTienTrinh.Text = "Đang khởi động chương trình...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyRMS.Properties.Resources.bg;
            this.pictureBox1.Location = new System.Drawing.Point(80, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(318, 170);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmStart2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 356);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTienTrinh);
            this.Controls.Add(this.pbarTienTrinh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmStart2.IconOptions.Icon")));
            this.IconOptions.Image = global::MyRMS.Properties.Resources.Custo_Man_Christmas_Globe_Internet_128;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStart2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStart";
            this.Load += new System.EventHandler(this.frmStart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbarTienTrinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.ProgressBarControl pbarTienTrinh;
        private DevExpress.XtraEditors.LabelControl lblTienTrinh;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}