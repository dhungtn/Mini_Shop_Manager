namespace MyRMS.NghiepVu
{
    partial class frmThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThanhToan));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtKhachDua = new DevExpress.XtraEditors.CalcEdit();
            this.chkTraDu = new DevExpress.XtraEditors.CheckEdit();
            this.txtTienThua = new DevExpress.XtraEditors.SpinEdit();
            this.txtPhaiThanhToan = new DevExpress.XtraEditors.SpinEdit();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKhachDua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTraDu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTienThua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhaiThanhToan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtKhachDua);
            this.layoutControl1.Controls.Add(this.chkTraDu);
            this.layoutControl1.Controls.Add(this.txtTienThua);
            this.layoutControl1.Controls.Add(this.txtPhaiThanhToan);
            this.layoutControl1.Controls.Add(this.btnLuu);
            this.layoutControl1.Controls.Add(this.btnDong);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 45);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(351, 161);
            this.layoutControl1.TabIndex = 15;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem5,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(351, 161);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(17, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(309, 29);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "THÔNG TIN THANH TOÁN";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(351, 45);
            this.panelControl1.TabIndex = 16;
            // 
            // txtKhachDua
            // 
            this.txtKhachDua.Location = new System.Drawing.Point(135, 42);
            this.txtKhachDua.Name = "txtKhachDua";
            this.txtKhachDua.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtKhachDua.Properties.Appearance.Options.UseFont = true;
            this.txtKhachDua.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtKhachDua.Properties.DisplayFormat.FormatString = "{0:0,#}";
            this.txtKhachDua.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtKhachDua.Properties.EditFormat.FormatString = "{0:0,#}";
            this.txtKhachDua.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtKhachDua.Properties.MaskSettings.Set("mask", "###,###,###,###");
            this.txtKhachDua.Size = new System.Drawing.Size(204, 26);
            this.txtKhachDua.StyleController = this.layoutControl1;
            this.txtKhachDua.TabIndex = 22;
            this.txtKhachDua.EditValueChanged += new System.EventHandler(this.txtKhachDua_EditValueChanged);
            // 
            // chkTraDu
            // 
            this.chkTraDu.EditValue = true;
            this.chkTraDu.Location = new System.Drawing.Point(15, 110);
            this.chkTraDu.Name = "chkTraDu";
            this.chkTraDu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkTraDu.Properties.Appearance.Options.UseFont = true;
            this.chkTraDu.Properties.Caption = "Khách đưa đủ";
            this.chkTraDu.Size = new System.Drawing.Size(148, 21);
            this.chkTraDu.StyleController = this.layoutControl1;
            this.chkTraDu.TabIndex = 17;
            this.chkTraDu.CheckedChanged += new System.EventHandler(this.chkTraDu_CheckedChanged);
            this.chkTraDu.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.chkTraDu_EditValueChanging);
            // 
            // txtTienThua
            // 
            this.txtTienThua.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTienThua.Enabled = false;
            this.txtTienThua.Location = new System.Drawing.Point(135, 72);
            this.txtTienThua.Name = "txtTienThua";
            this.txtTienThua.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtTienThua.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtTienThua.Properties.Appearance.Options.UseFont = true;
            this.txtTienThua.Properties.Appearance.Options.UseForeColor = true;
            this.txtTienThua.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtTienThua.Properties.DisplayFormat.FormatString = "{0:0,#}";
            this.txtTienThua.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTienThua.Properties.EditFormat.FormatString = "{0:0,#}";
            this.txtTienThua.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTienThua.Properties.MaskSettings.Set("mask", "###,###,###,###");
            this.txtTienThua.Size = new System.Drawing.Size(204, 26);
            this.txtTienThua.StyleController = this.layoutControl1;
            this.txtTienThua.TabIndex = 21;
            // 
            // txtPhaiThanhToan
            // 
            this.txtPhaiThanhToan.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPhaiThanhToan.Enabled = false;
            this.txtPhaiThanhToan.Location = new System.Drawing.Point(135, 12);
            this.txtPhaiThanhToan.Name = "txtPhaiThanhToan";
            this.txtPhaiThanhToan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtPhaiThanhToan.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtPhaiThanhToan.Properties.Appearance.Options.UseFont = true;
            this.txtPhaiThanhToan.Properties.Appearance.Options.UseForeColor = true;
            this.txtPhaiThanhToan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPhaiThanhToan.Properties.DisplayFormat.FormatString = "{0:0,#}";
            this.txtPhaiThanhToan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPhaiThanhToan.Properties.EditFormat.FormatString = "{0:0,#}";
            this.txtPhaiThanhToan.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPhaiThanhToan.Properties.MaskSettings.Set("mask", "###,###,###,###");
            this.txtPhaiThanhToan.Size = new System.Drawing.Size(204, 26);
            this.txtPhaiThanhToan.StyleController = this.layoutControl1;
            this.txtPhaiThanhToan.TabIndex = 18;
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(170, 113);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(88, 24);
            this.btnLuu.StyleController = this.layoutControl1;
            this.btnLuu.TabIndex = 16;
            this.btnLuu.Text = "Đồng ý";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnDong.Appearance.Options.UseFont = true;
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.ImageOptions.Image")));
            this.btnDong.Location = new System.Drawing.Point(262, 113);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(77, 24);
            this.btnDong.StyleController = this.layoutControl1;
            this.btnDong.TabIndex = 15;
            this.btnDong.Text = "Đóng";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnDong;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.FillControlToClientArea = false;
            this.layoutControlItem6.Location = new System.Drawing.Point(250, 90);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(81, 39);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(81, 51);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnLuu;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.FillControlToClientArea = false;
            this.layoutControlItem7.Location = new System.Drawing.Point(158, 90);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(70, 39);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(92, 51);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txtPhaiThanhToan;
            this.layoutControlItem5.CustomizationFormText = "Đơn giá (/giờ)";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(331, 30);
            this.layoutControlItem5.Text = "Phải thanh toán";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(111, 19);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txtTienThua;
            this.layoutControlItem1.CustomizationFormText = "Tiền thừa";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(331, 30);
            this.layoutControlItem1.Text = "Tiền thừa";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(111, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkTraDu;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 10, 5);
            this.layoutControlItem2.Size = new System.Drawing.Size(158, 51);
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txtKhachDua;
            this.layoutControlItem3.CustomizationFormText = "Khách đưa";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(331, 30);
            this.layoutControlItem3.Text = "Khách đưa";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(111, 19);
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 206);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.Image = global::MyRMS.Properties.Resources.Custo_Man_Christmas_Globe_Internet_128;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THANH TOÁN";
            this.Load += new System.EventHandler(this.frmThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKhachDua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTraDu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTienThua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhaiThanhToan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit txtPhaiThanhToan;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SpinEdit txtTienThua;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkTraDu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CalcEdit txtKhachDua;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}