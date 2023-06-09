namespace MyRMS.DanhMuc
{
    partial class frmLoaiHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiHang));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barTaiLai = new DevExpress.XtraBars.BarButtonItem();
            this.barThem = new DevExpress.XtraBars.BarButtonItem();
            this.barSua = new DevExpress.XtraBars.BarButtonItem();
            this.barXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barIn = new DevExpress.XtraBars.BarButtonItem();
            this.barExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barDong = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmenuThem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuSua = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuTaiLai = new System.Windows.Forms.ToolStripMenuItem();
            this.grcData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLH_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLH_Ten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLH_GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLH_KichHoat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barThem,
            this.barSua,
            this.barXoa,
            this.barIn,
            this.barTaiLai,
            this.barDong,
            this.barExcel});
            this.barManager1.MaxItemId = 7;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barTaiLai),
            new DevExpress.XtraBars.LinkPersistInfo(this.barThem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSua, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barXoa, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barExcel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barDong, true)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barTaiLai
            // 
            this.barTaiLai.Caption = "Tải lại (F5)";
            this.barTaiLai.Id = 4;
            this.barTaiLai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barTaiLai.ImageOptions.Image")));
            this.barTaiLai.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.barTaiLai.Name = "barTaiLai";
            this.barTaiLai.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barTaiLai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barTaiLai_ItemClick);
            // 
            // barThem
            // 
            this.barThem.Caption = "Thêm (F6)";
            this.barThem.Id = 0;
            this.barThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barThem.ImageOptions.Image")));
            this.barThem.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.barThem.Name = "barThem";
            this.barThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barThem_ItemClick);
            // 
            // barSua
            // 
            this.barSua.Caption = "Sửa (F8)";
            this.barSua.Id = 1;
            this.barSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSua.ImageOptions.Image")));
            this.barSua.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F8);
            this.barSua.Name = "barSua";
            this.barSua.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSua_ItemClick);
            // 
            // barXoa
            // 
            this.barXoa.Caption = "Xóa (F9)";
            this.barXoa.Id = 2;
            this.barXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barXoa.ImageOptions.Image")));
            this.barXoa.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F9);
            this.barXoa.Name = "barXoa";
            this.barXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barXoa_ItemClick);
            // 
            // barIn
            // 
            this.barIn.Caption = "In (F10)";
            this.barIn.Id = 3;
            this.barIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barIn.ImageOptions.Image")));
            this.barIn.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F10);
            this.barIn.Name = "barIn";
            this.barIn.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barIn_ItemClick);
            // 
            // barExcel
            // 
            this.barExcel.Caption = "Excel (F11)";
            this.barExcel.Id = 6;
            this.barExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barExcel.ImageOptions.Image")));
            this.barExcel.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F11);
            this.barExcel.Name = "barExcel";
            this.barExcel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barExcel_ItemClick);
            // 
            // barDong
            // 
            this.barDong.Caption = "Đóng (F12)";
            this.barDong.Id = 5;
            this.barDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barDong.ImageOptions.Image")));
            this.barDong.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
            this.barDong.Name = "barDong";
            this.barDong.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barDong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDong_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(749, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 343);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(749, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 319);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(749, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 319);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuThem,
            this.tsmenuSua,
            this.tsmenuXoa,
            this.tsmenuTaiLai});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowItemToolTips = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 92);
            // 
            // tsmenuThem
            // 
            this.tsmenuThem.Name = "tsmenuThem";
            this.tsmenuThem.Size = new System.Drawing.Size(104, 22);
            // 
            // tsmenuSua
            // 
            this.tsmenuSua.Name = "tsmenuSua";
            this.tsmenuSua.Size = new System.Drawing.Size(104, 22);
            this.tsmenuSua.Text = "Sửa";
            // 
            // tsmenuXoa
            // 
            this.tsmenuXoa.Name = "tsmenuXoa";
            this.tsmenuXoa.Size = new System.Drawing.Size(104, 22);
            // 
            // tsmenuTaiLai
            // 
            this.tsmenuTaiLai.Name = "tsmenuTaiLai";
            this.tsmenuTaiLai.Size = new System.Drawing.Size(104, 22);
            this.tsmenuTaiLai.Text = "Tải lại";
            // 
            // grcData
            // 
            this.grcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcData.Location = new System.Drawing.Point(0, 24);
            this.grcData.MainView = this.grvData;
            this.grcData.MenuManager = this.barManager1;
            this.grcData.Name = "grcData";
            this.grcData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.grcData.Size = new System.Drawing.Size(749, 319);
            this.grcData.TabIndex = 8;
            this.grcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvData.Appearance.FooterPanel.Options.UseFont = true;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLH_ID,
            this.colLH_Ten,
            this.colLH_GhiChu,
            this.colLH_KichHoat});
            this.grvData.GridControl = this.grcData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsSelection.MultiSelect = true;
            this.grvData.OptionsView.ShowAutoFilterRow = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.DoubleClick += new System.EventHandler(this.grvLoaiHang_DoubleClick);
            // 
            // colLH_ID
            // 
            this.colLH_ID.Caption = "ID";
            this.colLH_ID.FieldName = "LH_ID";
            this.colLH_ID.Name = "colLH_ID";
            // 
            // colLH_Ten
            // 
            this.colLH_Ten.Caption = "Tên";
            this.colLH_Ten.FieldName = "LH_Ten";
            this.colLH_Ten.Name = "colLH_Ten";
            this.colLH_Ten.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colLH_Ten.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "tenloai", "count = {0:0,#}")});
            this.colLH_Ten.Visible = true;
            this.colLH_Ten.VisibleIndex = 0;
            this.colLH_Ten.Width = 338;
            // 
            // colLH_GhiChu
            // 
            this.colLH_GhiChu.Caption = "Ghi chú";
            this.colLH_GhiChu.FieldName = "LH_GhiChu";
            this.colLH_GhiChu.Name = "colLH_GhiChu";
            this.colLH_GhiChu.Visible = true;
            this.colLH_GhiChu.VisibleIndex = 1;
            this.colLH_GhiChu.Width = 309;
            // 
            // colLH_KichHoat
            // 
            this.colLH_KichHoat.Caption = "Kích hoạt";
            this.colLH_KichHoat.FieldName = "LH_KichHoat";
            this.colLH_KichHoat.Name = "colLH_KichHoat";
            this.colLH_KichHoat.OptionsColumn.AllowSize = false;
            this.colLH_KichHoat.OptionsColumn.FixedWidth = true;
            this.colLH_KichHoat.Visible = true;
            this.colLH_KichHoat.VisibleIndex = 2;
            this.colLH_KichHoat.Width = 100;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // frmLoaiHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 343);
            this.Controls.Add(this.grcData);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::MyRMS.Properties.Resources.Custo_Man_Christmas_Globe_Internet_128;
            this.Name = "frmLoaiHang";
            this.Text = "DANH MỤC LOẠI HÀNG";
            this.Load += new System.EventHandler(this.frmLoaiHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barThem;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barSua;
        private DevExpress.XtraBars.BarButtonItem barXoa;
        private DevExpress.XtraBars.BarButtonItem barIn;
        private DevExpress.XtraBars.BarButtonItem barTaiLai;
        private DevExpress.XtraBars.BarButtonItem barDong;
        private DevExpress.XtraBars.BarButtonItem barExcel;
        private DevExpress.XtraGrid.GridControl grcData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colLH_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colLH_Ten;
        private DevExpress.XtraGrid.Columns.GridColumn colLH_GhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colLH_KichHoat;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmenuThem;
        private System.Windows.Forms.ToolStripMenuItem tsmenuSua;
        private System.Windows.Forms.ToolStripMenuItem tsmenuXoa;
        private System.Windows.Forms.ToolStripMenuItem tsmenuTaiLai;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}