namespace MyRMS
{
    partial class Test
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
            this.btnDongKetNoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoKetNoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKetNoiLai = new DevExpress.XtraEditors.SimpleButton();
            this.dateThoiGian = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dateThoiGian.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateThoiGian.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDongKetNoi
            // 
            this.btnDongKetNoi.Location = new System.Drawing.Point(90, 146);
            this.btnDongKetNoi.Name = "btnDongKetNoi";
            this.btnDongKetNoi.Size = new System.Drawing.Size(75, 23);
            this.btnDongKetNoi.TabIndex = 0;
            this.btnDongKetNoi.Text = "Đóng kết nối";
            this.btnDongKetNoi.Click += new System.EventHandler(this.btnDongKetNoi_Click);
            // 
            // btnMoKetNoi
            // 
            this.btnMoKetNoi.Location = new System.Drawing.Point(90, 117);
            this.btnMoKetNoi.Name = "btnMoKetNoi";
            this.btnMoKetNoi.Size = new System.Drawing.Size(75, 23);
            this.btnMoKetNoi.TabIndex = 1;
            this.btnMoKetNoi.Text = "Mở kết nối";
            this.btnMoKetNoi.Click += new System.EventHandler(this.btnMoKetNoi_Click);
            // 
            // btnKetNoiLai
            // 
            this.btnKetNoiLai.Location = new System.Drawing.Point(90, 175);
            this.btnKetNoiLai.Name = "btnKetNoiLai";
            this.btnKetNoiLai.Size = new System.Drawing.Size(75, 23);
            this.btnKetNoiLai.TabIndex = 2;
            this.btnKetNoiLai.Text = "Kết nối lại";
            this.btnKetNoiLai.Click += new System.EventHandler(this.btnKetNoiLai_Click);
            // 
            // dateThoiGian
            // 
            this.dateThoiGian.EditValue = null;
            this.dateThoiGian.Location = new System.Drawing.Point(12, 31);
            this.dateThoiGian.Name = "dateThoiGian";
            this.dateThoiGian.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.dateThoiGian.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.dateThoiGian.Properties.Appearance.Options.UseFont = true;
            this.dateThoiGian.Properties.Appearance.Options.UseForeColor = true;
            this.dateThoiGian.Properties.Appearance.Options.UseTextOptions = true;
            this.dateThoiGian.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.dateThoiGian.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateThoiGian.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dateThoiGian.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateThoiGian.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dateThoiGian.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateThoiGian.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
            this.dateThoiGian.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.dateThoiGian.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateThoiGian.Size = new System.Drawing.Size(179, 23);
            this.dateThoiGian.TabIndex = 8;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 262);
            this.Controls.Add(this.dateThoiGian);
            this.Controls.Add(this.btnKetNoiLai);
            this.Controls.Add(this.btnMoKetNoi);
            this.Controls.Add(this.btnDongKetNoi);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateThoiGian.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateThoiGian.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDongKetNoi;
        private DevExpress.XtraEditors.SimpleButton btnMoKetNoi;
        private DevExpress.XtraEditors.SimpleButton btnKetNoiLai;
        private DevExpress.XtraEditors.DateEdit dateThoiGian;
    }
}