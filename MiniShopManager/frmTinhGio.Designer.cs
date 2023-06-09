namespace MyRMS
{
    partial class frmTinhGio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTinhGio));
            this.timeGioVao = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.timeGioRa = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnDongY = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.timeGioVao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeGioRa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timeGioVao
            // 
            this.timeGioVao.EditValue = new System.DateTime(2017, 11, 27, 0, 0, 0, 0);
            this.timeGioVao.Location = new System.Drawing.Point(96, 31);
            this.timeGioVao.Name = "timeGioVao";
            this.timeGioVao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.timeGioVao.Properties.Appearance.Options.UseFont = true;
            this.timeGioVao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeGioVao.Properties.EditFormat.FormatString = "HH:mm";
            this.timeGioVao.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeGioVao.Properties.Mask.EditMask = "HH:mm";
            this.timeGioVao.Size = new System.Drawing.Size(58, 22);
            this.timeGioVao.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(27, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 17);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Giờ vào:";
            // 
            // timeGioRa
            // 
            this.timeGioRa.EditValue = new System.DateTime(2017, 11, 27, 0, 0, 0, 0);
            this.timeGioRa.Location = new System.Drawing.Point(96, 65);
            this.timeGioRa.Name = "timeGioRa";
            this.timeGioRa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.timeGioRa.Properties.Appearance.Options.UseFont = true;
            this.timeGioRa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeGioRa.Properties.EditFormat.FormatString = "HH:mm";
            this.timeGioRa.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeGioRa.Properties.Mask.EditMask = "HH:mm";
            this.timeGioRa.Size = new System.Drawing.Size(58, 22);
            this.timeGioRa.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(27, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 17);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Giờ ra:";
            // 
            // btnDongY
            // 
            this.btnDongY.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDongY.Appearance.Options.UseFont = true;
            this.btnDongY.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDongY.ImageOptions.Image")));
            this.btnDongY.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnDongY.Location = new System.Drawing.Point(170, 31);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(56, 57);
            this.btnDongY.TabIndex = 2;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // frmTinhGio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 129);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.timeGioRa);
            this.Controls.Add(this.timeGioVao);
            this.IconOptions.Image = global::MyRMS.Properties.Resources.Custo_Man_Christmas_Globe_Internet_128;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTinhGio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÍNH GIỜ";
            this.Load += new System.EventHandler(this.frmTinhGio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timeGioVao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeGioRa.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TimeEdit timeGioVao;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TimeEdit timeGioRa;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDongY;
    }
}