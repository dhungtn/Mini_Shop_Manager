namespace MyRMS.DanhMuc
{
    partial class frmQuyTien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuyTien));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barThem = new DevExpress.XtraBars.BarButtonItem();
            this.barSua = new DevExpress.XtraBars.BarButtonItem();
            this.barXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barTaiLai = new DevExpress.XtraBars.BarButtonItem();
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
            this.grcQuyTien = new DevExpress.XtraGrid.GridControl();
            this.grvQuyTien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colQT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQT_Ten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQT_GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQT_TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcQuyTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuyTien)).BeginInit();
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barThem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSua, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barXoa, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barTaiLai, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barExcel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barDong, true)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barThem
            // 
            this.barThem.Caption = "Thêm (F1)";
            this.barThem.Id = 0;
            this.barThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barThem.ImageOptions.Image")));
            this.barThem.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.barThem.Name = "barThem";
            this.barThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barXem_ItemClick);
            // 
            // barSua
            // 
            this.barSua.Caption = "Sửa (F2)";
            this.barSua.Id = 1;
            this.barSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSua.ImageOptions.Image")));
            this.barSua.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.barSua.Name = "barSua";
            this.barSua.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSua_ItemClick);
            // 
            // barXoa
            // 
            this.barXoa.Caption = "Xóa (F3)";
            this.barXoa.Id = 2;
            this.barXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barXoa.ImageOptions.Image")));
            this.barXoa.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.barXoa.Name = "barXoa";
            this.barXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barXoa_ItemClick);
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
            // grcQuyTien
            // 
            this.grcQuyTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcQuyTien.Location = new System.Drawing.Point(0, 24);
            this.grcQuyTien.MainView = this.grvQuyTien;
            this.grcQuyTien.MenuManager = this.barManager1;
            this.grcQuyTien.Name = "grcQuyTien";
            this.grcQuyTien.Size = new System.Drawing.Size(749, 319);
            this.grcQuyTien.TabIndex = 8;
            this.grcQuyTien.UseEmbeddedNavigator = true;
            this.grcQuyTien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvQuyTien});
            // 
            // grvQuyTien
            // 
            this.grvQuyTien.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvQuyTien.Appearance.FooterPanel.Options.UseFont = true;
            this.grvQuyTien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colQT_ID,
            this.colQT_Ten,
            this.colQT_GhiChu,
            this.colQT_TrangThai});
            this.grvQuyTien.GridControl = this.grcQuyTien;
            this.grvQuyTien.Name = "grvQuyTien";
            this.grvQuyTien.OptionsBehavior.Editable = false;
            this.grvQuyTien.OptionsSelection.MultiSelect = true;
            this.grvQuyTien.OptionsView.ShowAutoFilterRow = true;
            this.grvQuyTien.OptionsView.ShowGroupPanel = false;
            this.grvQuyTien.DoubleClick += new System.EventHandler(this.grvQuyTien_DoubleClick_1);
            // 
            // colQT_ID
            // 
            this.colQT_ID.Caption = "ID";
            this.colQT_ID.FieldName = "QT_ID";
            this.colQT_ID.Name = "colQT_ID";
            // 
            // colQT_Ten
            // 
            this.colQT_Ten.Caption = "Tên";
            this.colQT_Ten.FieldName = "QT_Ten";
            this.colQT_Ten.Name = "colQT_Ten";
            this.colQT_Ten.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colQT_Ten.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "tenloai", "count = {0:0,#}")});
            this.colQT_Ten.Visible = true;
            this.colQT_Ten.VisibleIndex = 0;
            this.colQT_Ten.Width = 316;
            // 
            // colQT_GhiChu
            // 
            this.colQT_GhiChu.Caption = "Ghi chú";
            this.colQT_GhiChu.FieldName = "QT_GhiChu";
            this.colQT_GhiChu.Name = "colQT_GhiChu";
            this.colQT_GhiChu.Visible = true;
            this.colQT_GhiChu.VisibleIndex = 1;
            this.colQT_GhiChu.Width = 253;
            // 
            // colQT_TrangThai
            // 
            this.colQT_TrangThai.Caption = "Đang theo dõi";
            this.colQT_TrangThai.FieldName = "QT_TrangThai";
            this.colQT_TrangThai.Name = "colQT_TrangThai";
            this.colQT_TrangThai.Visible = true;
            this.colQT_TrangThai.VisibleIndex = 2;
            this.colQT_TrangThai.Width = 105;
            // 
            // frmQuyTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 343);
            this.Controls.Add(this.grcQuyTien);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::MyRMS.Properties.Resources.Custo_Man_Christmas_Globe_Internet_128;
            this.Name = "frmQuyTien";
            this.Text = "DANH MỤC QUỸ TIỀN";
            this.Load += new System.EventHandler(this.frmDMQuyTien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcQuyTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuyTien)).EndInit();
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
        private DevExpress.XtraGrid.GridControl grcQuyTien;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQuyTien;
        private DevExpress.XtraGrid.Columns.GridColumn colQT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colQT_Ten;
        private DevExpress.XtraGrid.Columns.GridColumn colQT_GhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colQT_TrangThai;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmenuThem;
        private System.Windows.Forms.ToolStripMenuItem tsmenuSua;
        private System.Windows.Forms.ToolStripMenuItem tsmenuXoa;
        private System.Windows.Forms.ToolStripMenuItem tsmenuTaiLai;
    }
}