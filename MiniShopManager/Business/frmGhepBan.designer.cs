namespace MyRMS.NghiepVu
{
    partial class frmGhepBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGhepBan));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.btnDongY = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.glkuDenBan = new DevExpress.XtraEditors.GridLookUpEdit();
            this.glkuvDenBan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glkuTuBan = new DevExpress.XtraEditors.GridLookUpEdit();
            this.glkuvTuBan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkuDenBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkuvDenBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkuTuBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkuvTuBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.glkuDenBan);
            this.layoutControl1.Controls.Add(this.glkuTuBan);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(243, 105);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(243, 105);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // btnDongY
            // 
            this.btnDongY.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDongY.Appearance.Options.UseFont = true;
            this.btnDongY.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDongY.ImageOptions.Image")));
            this.btnDongY.Location = new System.Drawing.Point(82, 109);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 32);
            this.btnDongY.TabIndex = 7;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnDong
            // 
            this.btnDong.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDong.Appearance.Options.UseFont = true;
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.ImageOptions.Image")));
            this.btnDong.Location = new System.Drawing.Point(163, 109);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 32);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // glkuDenBan
            // 
            this.glkuDenBan.Location = new System.Drawing.Point(12, 64);
            this.glkuDenBan.Name = "glkuDenBan";
            this.glkuDenBan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.glkuDenBan.Properties.Appearance.Options.UseFont = true;
            this.glkuDenBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glkuDenBan.Properties.NullText = "";
            this.glkuDenBan.Properties.PopupView = this.glkuvDenBan;
            this.glkuDenBan.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.None;
            this.glkuDenBan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.glkuDenBan.Size = new System.Drawing.Size(219, 26);
            this.glkuDenBan.StyleController = this.layoutControl1;
            this.glkuDenBan.TabIndex = 16;
            // 
            // glkuvDenBan
            // 
            this.glkuvDenBan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.glkuvDenBan.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.glkuvDenBan.Name = "glkuvDenBan";
            this.glkuvDenBan.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.glkuvDenBan.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ID";
            this.gridColumn3.FieldName = "BP_ID";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Bàn";
            this.gridColumn4.FieldName = "BP_Ten";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // glkuTuBan
            // 
            this.glkuTuBan.Location = new System.Drawing.Point(12, 12);
            this.glkuTuBan.Name = "glkuTuBan";
            this.glkuTuBan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.glkuTuBan.Properties.Appearance.Options.UseFont = true;
            this.glkuTuBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glkuTuBan.Properties.NullText = "";
            this.glkuTuBan.Properties.PopupView = this.glkuvTuBan;
            this.glkuTuBan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.glkuTuBan.Size = new System.Drawing.Size(219, 26);
            this.glkuTuBan.StyleController = this.layoutControl1;
            this.glkuTuBan.TabIndex = 15;
            // 
            // glkuvTuBan
            // 
            this.glkuvTuBan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.glkuvTuBan.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.glkuvTuBan.Name = "glkuvTuBan";
            this.glkuvTuBan.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.glkuvTuBan.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "BP_ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Bàn";
            this.gridColumn2.FieldName = "BP_Ten";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.glkuTuBan;
            this.layoutControlItem4.CustomizationFormText = "Từ bàn";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(223, 30);
            this.layoutControlItem4.Text = "Từ bàn";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.glkuDenBan;
            this.layoutControlItem1.CustomizationFormText = "Đến bàn";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(223, 55);
            this.layoutControlItem1.Text = "Ghép với bàn:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(100, 19);
            // 
            // frmGhepBan
            // 
            this.AcceptButton = this.btnDongY;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(243, 152);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.btnDong);
            this.IconOptions.Image = global::MyRMS.Properties.Resources.Custo_Man_Christmas_Globe_Internet_128;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGhepBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GHÉP BÀN";
            this.Load += new System.EventHandler(this.frmGhepBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkuDenBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkuvDenBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkuTuBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkuvTuBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GridLookUpEdit glkuDenBan;
        private DevExpress.XtraGrid.Views.Grid.GridView glkuvDenBan;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.GridLookUpEdit glkuTuBan;
        private DevExpress.XtraGrid.Views.Grid.GridView glkuvTuBan;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnDongY;
        private DevExpress.XtraEditors.SimpleButton btnDong;
    }
}