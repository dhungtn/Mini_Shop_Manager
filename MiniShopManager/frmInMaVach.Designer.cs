namespace MyRMS
{
    partial class frmPrintBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintBarcode));
            this.panel1 = new System.Windows.Forms.Panel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtDonGia = new DevExpress.XtraEditors.SpinEdit();
            this.txtSoLuongIn = new DevExpress.XtraEditors.SpinEdit();
            this.txtHangHoa = new DevExpress.XtraEditors.TextEdit();
            this.txtMaVach = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnDongY = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHangHoa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaVach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnDongY);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 38);
            this.panel1.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtDonGia);
            this.layoutControl1.Controls.Add(this.txtSoLuongIn);
            this.layoutControl1.Controls.Add(this.txtHangHoa);
            this.layoutControl1.Controls.Add(this.txtMaVach);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(354, 116);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(354, 116);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // txtDonGia
            // 
            this.txtDonGia.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDonGia.Enabled = false;
            this.txtDonGia.Location = new System.Drawing.Point(106, 72);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtDonGia.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtDonGia.Properties.Appearance.Options.UseFont = true;
            this.txtDonGia.Properties.Appearance.Options.UseForeColor = true;
            this.txtDonGia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDonGia.Properties.DisplayFormat.FormatString = "{0:0,#}";
            this.txtDonGia.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDonGia.Properties.EditFormat.FormatString = "{0:0,#}";
            this.txtDonGia.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDonGia.Properties.MaskSettings.Set("mask", "###,###,###,###");
            this.txtDonGia.Size = new System.Drawing.Size(83, 26);
            this.txtDonGia.StyleController = this.layoutControl1;
            this.txtDonGia.TabIndex = 8;
            // 
            // txtSoLuongIn
            // 
            this.txtSoLuongIn.EditValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtSoLuongIn.Location = new System.Drawing.Point(287, 72);
            this.txtSoLuongIn.Name = "txtSoLuongIn";
            this.txtSoLuongIn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtSoLuongIn.Properties.Appearance.Options.UseFont = true;
            this.txtSoLuongIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSoLuongIn.Properties.DisplayFormat.FormatString = "{0:0,#}";
            this.txtSoLuongIn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSoLuongIn.Properties.EditFormat.FormatString = "{0:0,#}";
            this.txtSoLuongIn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSoLuongIn.Properties.MaskSettings.Set("mask", "###,###,###,###");
            this.txtSoLuongIn.Size = new System.Drawing.Size(55, 26);
            this.txtSoLuongIn.StyleController = this.layoutControl1;
            this.txtSoLuongIn.TabIndex = 7;
            // 
            // txtHangHoa
            // 
            this.txtHangHoa.Enabled = false;
            this.txtHangHoa.Location = new System.Drawing.Point(106, 12);
            this.txtHangHoa.Name = "txtHangHoa";
            this.txtHangHoa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtHangHoa.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtHangHoa.Properties.Appearance.Options.UseFont = true;
            this.txtHangHoa.Properties.Appearance.Options.UseForeColor = true;
            this.txtHangHoa.Size = new System.Drawing.Size(236, 26);
            this.txtHangHoa.StyleController = this.layoutControl1;
            this.txtHangHoa.TabIndex = 6;
            // 
            // txtMaVach
            // 
            this.txtMaVach.Enabled = false;
            this.txtMaVach.Location = new System.Drawing.Point(106, 42);
            this.txtMaVach.Name = "txtMaVach";
            this.txtMaVach.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtMaVach.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtMaVach.Properties.Appearance.Options.UseFont = true;
            this.txtMaVach.Properties.Appearance.Options.UseForeColor = true;
            this.txtMaVach.Size = new System.Drawing.Size(236, 26);
            this.txtMaVach.StyleController = this.layoutControl1;
            this.txtMaVach.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txtMaVach;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(334, 30);
            this.layoutControlItem2.Text = "Mã vạch";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(82, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txtSoLuongIn;
            this.layoutControlItem4.CustomizationFormText = "Nợ ban đầu";
            this.layoutControlItem4.Location = new System.Drawing.Point(181, 60);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(153, 36);
            this.layoutControlItem4.Text = "Số lượng in";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(82, 19);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txtHangHoa;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(334, 30);
            this.layoutControlItem3.Text = "Hàng hóa";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(82, 19);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txtDonGia;
            this.layoutControlItem1.CustomizationFormText = "Đơn giá";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(181, 36);
            this.layoutControlItem1.Text = "Đơn giá";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(82, 19);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(278, 6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(70, 25);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Đóng";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDongY
            // 
            this.btnDongY.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDongY.Appearance.Options.UseFont = true;
            this.btnDongY.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDongY.ImageOptions.Image")));
            this.btnDongY.Location = new System.Drawing.Point(202, 6);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(70, 25);
            this.btnDongY.TabIndex = 9;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // frmInMaVach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 154);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.panel1);
            this.IconOptions.Image = global::MyRMS.Properties.Resources.Custo_Man_Christmas_Globe_Internet_128;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInMaVach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IN MÃ VẠCH";
            this.Load += new System.EventHandler(this.frmInMaVach_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHangHoa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaVach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnDongY;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SpinEdit txtDonGia;
        private DevExpress.XtraEditors.SpinEdit txtSoLuongIn;
        private DevExpress.XtraEditors.TextEdit txtHangHoa;
        private DevExpress.XtraEditors.TextEdit txtMaVach;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}