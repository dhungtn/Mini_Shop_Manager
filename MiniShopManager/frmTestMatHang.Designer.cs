namespace MyRMS
{
    partial class frmTestMatHang
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestMatHang));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grcData = new DevExpress.XtraGrid.GridControl();
            this.grvMatHang = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colMH_ID = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.Item1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colMH_Ma = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rpicHinhAnh = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.Item3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colMH_Ten = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.Item2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colTuKhoa = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.Item8 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rbtnSua = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rbtnXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpicHinhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnSua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnXoa)).BeginInit();
            this.SuspendLayout();
            // 
            // grcData
            // 
            this.grcData.Dock = System.Windows.Forms.DockStyle.Left;
            this.grcData.Location = new System.Drawing.Point(0, 0);
            this.grcData.MainView = this.grvMatHang;
            this.grcData.Name = "grcData";
            this.grcData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.rbtnSua,
            this.rbtnXoa,
            this.rpicHinhAnh});
            this.grcData.Size = new System.Drawing.Size(275, 262);
            this.grcData.TabIndex = 11;
            this.grcData.UseEmbeddedNavigator = true;
            this.grcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMatHang});
            // 
            // grvMatHang
            // 
            this.grvMatHang.CardHorzInterval = 3;
            this.grvMatHang.CardMinSize = new System.Drawing.Size(68, 108);
            this.grvMatHang.CardVertInterval = 3;
            this.grvMatHang.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colMH_ID,
            this.colMH_Ma,
            this.colMH_Ten,
            this.colTuKhoa});
            this.grvMatHang.GridControl = this.grcData;
            this.grvMatHang.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Item1,
            this.Item8});
            this.grvMatHang.Name = "grvMatHang";
            this.grvMatHang.OptionsBehavior.Editable = false;
            this.grvMatHang.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.grvMatHang.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.AutoSize;
            this.grvMatHang.OptionsItemText.TextToControlDistance = 2;
            this.grvMatHang.OptionsSelection.MultiSelect = true;
            this.grvMatHang.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.grvMatHang.OptionsView.ShowCardCaption = false;
            this.grvMatHang.OptionsView.ShowCardLines = false;
            this.grvMatHang.OptionsView.ShowFieldHints = false;
            this.grvMatHang.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvMatHang.OptionsView.ShowHeaderPanel = false;
            this.grvMatHang.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiColumn;
            this.grvMatHang.TemplateCard = this.layoutViewCard1;
            // 
            // colMH_ID
            // 
            this.colMH_ID.Caption = "ID";
            this.colMH_ID.FieldName = "MH_ID";
            this.colMH_ID.LayoutViewField = this.Item1;
            this.colMH_ID.Name = "colMH_ID";
            // 
            // Item1
            // 
            this.Item1.EditorPreferredWidth = 40;
            this.Item1.Location = new System.Drawing.Point(0, 0);
            this.Item1.Name = "Item1";
            this.Item1.Size = new System.Drawing.Size(68, 108);
            this.Item1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item1.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item1.TextSize = new System.Drawing.Size(43, 13);
            // 
            // colMH_Ma
            // 
            this.colMH_Ma.Caption = "Mã";
            this.colMH_Ma.ColumnEdit = this.rpicHinhAnh;
            this.colMH_Ma.FieldName = "MH_HinhAnh";
            this.colMH_Ma.LayoutViewField = this.Item3;
            this.colMH_Ma.Name = "colMH_Ma";
            // 
            // rpicHinhAnh
            // 
            this.rpicHinhAnh.Name = "rpicHinhAnh";
            this.rpicHinhAnh.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image;
            this.rpicHinhAnh.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // Item3
            // 
            this.Item3.EditorPreferredWidth = 63;
            this.Item3.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Item3.Location = new System.Drawing.Point(0, 0);
            this.Item3.MaxSize = new System.Drawing.Size(60, 60);
            this.Item3.MinSize = new System.Drawing.Size(60, 60);
            this.Item3.Name = "Item3";
            this.Item3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Item3.Size = new System.Drawing.Size(68, 60);
            this.Item3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.Item3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item3.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item3.TextSize = new System.Drawing.Size(0, 0);
            this.Item3.TextVisible = false;
            // 
            // colMH_Ten
            // 
            this.colMH_Ten.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMH_Ten.AppearanceCell.Options.UseFont = true;
            this.colMH_Ten.Caption = "Tên";
            this.colMH_Ten.FieldName = "MH_Ten";
            this.colMH_Ten.LayoutViewField = this.Item2;
            this.colMH_Ten.Name = "colMH_Ten";
            this.colMH_Ten.OptionsColumn.AllowEdit = false;
            this.colMH_Ten.OptionsColumn.FixedWidth = true;
            this.colMH_Ten.OptionsFilter.AllowAutoFilter = false;
            this.colMH_Ten.OptionsFilter.AllowFilter = false;
            this.colMH_Ten.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMH_Ten.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "tenloai", "count = {0:0,#}")});
            this.colMH_Ten.Width = 246;
            // 
            // Item2
            // 
            this.Item2.EditorPreferredWidth = 29;
            this.Item2.Location = new System.Drawing.Point(0, 60);
            this.Item2.Name = "Item2";
            this.Item2.Size = new System.Drawing.Size(68, 31);
            this.Item2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item2.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item2.TextSize = new System.Drawing.Size(22, 13);
            // 
            // colTuKhoa
            // 
            this.colTuKhoa.Caption = "Từ khóa";
            this.colTuKhoa.FieldName = "MH_TuKhoa";
            this.colTuKhoa.LayoutViewField = this.Item8;
            this.colTuKhoa.Name = "colTuKhoa";
            // 
            // Item8
            // 
            this.Item8.EditorPreferredWidth = 139;
            this.Item8.Location = new System.Drawing.Point(0, 0);
            this.Item8.Name = "Item8";
            this.Item8.Size = new System.Drawing.Size(68, 108);
            this.Item8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item8.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item8.TextSize = new System.Drawing.Size(43, 13);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewTemplateCard";
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Item2,
            this.Item3});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 2;
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // rbtnSua
            // 
            this.rbtnSua.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.rbtnSua.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rbtnSua.Name = "rbtnSua";
            this.rbtnSua.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // rbtnXoa
            // 
            this.rbtnXoa.AutoHeight = false;
            editorButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions3.Image")));
            this.rbtnXoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rbtnXoa.Name = "rbtnXoa";
            this.rbtnXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // frmTestMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 262);
            this.Controls.Add(this.grcData);
            this.IconOptions.Image = global::MyRMS.Properties.Resources.Custo_Man_Christmas_Globe_Internet_128;
            this.Name = "frmTestMatHang";
            this.Text = "frmTestMatHang";
            this.Load += new System.EventHandler(this.frmTestMatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMatHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpicHinhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnSua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnXoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcData;
        private DevExpress.XtraGrid.Views.Layout.LayoutView grvMatHang;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colMH_ID;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colMH_Ma;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colMH_Ten;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colTuKhoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnSua;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rpicHinhAnh;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item8;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
    }
}