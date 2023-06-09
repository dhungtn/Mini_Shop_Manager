namespace MyRMS.HeThong
{
    partial class frmPhanQuyen
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
            this.grcNguoiDung = new DevExpress.XtraGrid.GridControl();
            this.grvNguoiDung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcQuyen = new DevExpress.XtraGrid.GridControl();
            this.grvQuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rchkTatCa = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rchkThem = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rchkSua = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rchkXoa = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rchkIn = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rchkNhap = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rchkXuat = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rchkTruyCap = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkChonTatCa = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grcNguoiDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNguoiDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkTatCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkThem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkSua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkTruyCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChonTatCa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grcNguoiDung
            // 
            this.grcNguoiDung.Dock = System.Windows.Forms.DockStyle.Left;
            this.grcNguoiDung.Location = new System.Drawing.Point(0, 0);
            this.grcNguoiDung.MainView = this.grvNguoiDung;
            this.grcNguoiDung.Name = "grcNguoiDung";
            this.grcNguoiDung.Size = new System.Drawing.Size(195, 414);
            this.grcNguoiDung.TabIndex = 0;
            this.grcNguoiDung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNguoiDung});
            // 
            // grvNguoiDung
            // 
            this.grvNguoiDung.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvNguoiDung.Appearance.GroupRow.Options.UseFont = true;
            this.grvNguoiDung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.grvNguoiDung.GridControl = this.grcNguoiDung;
            this.grvNguoiDung.GroupCount = 1;
            this.grvNguoiDung.GroupPanelText = "Người dùng";
            this.grvNguoiDung.Name = "grvNguoiDung";
            this.grvNguoiDung.OptionsBehavior.Editable = false;
            this.grvNguoiDung.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn12, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvNguoiDung.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvNguoiDung_FocusedRowChanged);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "ID";
            this.gridColumn10.FieldName = "ND_ID";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Họ tên";
            this.gridColumn11.FieldName = "ND_Ten";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Vai trò";
            this.gridColumn12.FieldName = "VT_Ten";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // grcQuyen
            // 
            this.grcQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcQuyen.Location = new System.Drawing.Point(195, 0);
            this.grcQuyen.MainView = this.grvQuyen;
            this.grcQuyen.Name = "grcQuyen";
            this.grcQuyen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rchkThem,
            this.rchkSua,
            this.rchkXoa,
            this.rchkIn,
            this.rchkNhap,
            this.rchkXuat,
            this.rchkTruyCap,
            this.rchkTatCa});
            this.grcQuyen.Size = new System.Drawing.Size(576, 414);
            this.grcQuyen.TabIndex = 1;
            this.grcQuyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvQuyen});
            // 
            // grvQuyen
            // 
            this.grvQuyen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn1,
            this.gridColumn14,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn13});
            this.grvQuyen.GridControl = this.grcQuyen;
            this.grvQuyen.GroupCount = 1;
            this.grvQuyen.GroupPanelText = "Quyền";
            this.grvQuyen.Name = "grvQuyen";
            this.grvQuyen.OptionsView.ShowFooter = true;
            this.grvQuyen.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn13, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvQuyen.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grvQuyen_RowUpdated);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "ID";
            this.gridColumn9.FieldName = "Q_ID";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên giao diện";
            this.gridColumn1.FieldName = "CN_Ten";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 320;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Tất cả";
            this.gridColumn14.ColumnEdit = this.rchkTatCa;
            this.gridColumn14.FieldName = "Q_TatCa";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowSize = false;
            this.gridColumn14.OptionsColumn.FixedWidth = true;
            // 
            // rchkTatCa
            // 
            this.rchkTatCa.AutoHeight = false;
            this.rchkTatCa.Name = "rchkTatCa";
            this.rchkTatCa.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rchkTatCa_EditValueChanging);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Thêm";
            this.gridColumn2.ColumnEdit = this.rchkThem;
            this.gridColumn2.FieldName = "Q_Them";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowSize = false;
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 47;
            // 
            // rchkThem
            // 
            this.rchkThem.AutoHeight = false;
            this.rchkThem.Name = "rchkThem";
            this.rchkThem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rchkThem_EditValueChanging);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Sửa";
            this.gridColumn3.ColumnEdit = this.rchkSua;
            this.gridColumn3.FieldName = "Q_Sua";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowSize = false;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 44;
            // 
            // rchkSua
            // 
            this.rchkSua.AutoHeight = false;
            this.rchkSua.Name = "rchkSua";
            this.rchkSua.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rchkSua_EditValueChanging);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Xóa";
            this.gridColumn4.ColumnEdit = this.rchkXoa;
            this.gridColumn4.FieldName = "Q_Xoa";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowSize = false;
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 44;
            // 
            // rchkXoa
            // 
            this.rchkXoa.AutoHeight = false;
            this.rchkXoa.Name = "rchkXoa";
            this.rchkXoa.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rchkXoa_EditValueChanging);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "In";
            this.gridColumn5.ColumnEdit = this.rchkIn;
            this.gridColumn5.FieldName = "Q_In";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowSize = false;
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 44;
            // 
            // rchkIn
            // 
            this.rchkIn.AutoHeight = false;
            this.rchkIn.Name = "rchkIn";
            this.rchkIn.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rchkIn_EditValueChanging);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Nhập";
            this.gridColumn6.ColumnEdit = this.rchkNhap;
            this.gridColumn6.FieldName = "Q_Nhap";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowSize = false;
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 50;
            // 
            // rchkNhap
            // 
            this.rchkNhap.AutoHeight = false;
            this.rchkNhap.Name = "rchkNhap";
            this.rchkNhap.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rchkNhap_EditValueChanging);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Xuất";
            this.gridColumn7.ColumnEdit = this.rchkXuat;
            this.gridColumn7.FieldName = "Q_Xuat";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowSize = false;
            this.gridColumn7.OptionsColumn.FixedWidth = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 50;
            // 
            // rchkXuat
            // 
            this.rchkXuat.AutoHeight = false;
            this.rchkXuat.Name = "rchkXuat";
            this.rchkXuat.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rchkXuat_EditValueChanging);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Truy cập";
            this.gridColumn8.ColumnEdit = this.rchkTruyCap;
            this.gridColumn8.FieldName = "Q_TruyCap";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowSize = false;
            this.gridColumn8.OptionsColumn.FixedWidth = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            // 
            // rchkTruyCap
            // 
            this.rchkTruyCap.AutoHeight = false;
            this.rchkTruyCap.Name = "rchkTruyCap";
            this.rchkTruyCap.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.rchkTruyCap_EditValueChanging);
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Nhóm chức năng";
            this.gridColumn13.FieldName = "NCN_Ten";
            this.gridColumn13.Name = "gridColumn13";
            // 
            // chkChonTatCa
            // 
            this.chkChonTatCa.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkChonTatCa.Location = new System.Drawing.Point(195, 393);
            this.chkChonTatCa.Name = "chkChonTatCa";
            this.chkChonTatCa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkChonTatCa.Properties.Appearance.Options.UseFont = true;
            this.chkChonTatCa.Properties.Caption = " Chọn / Bỏ chọn tất cả";
            this.chkChonTatCa.Size = new System.Drawing.Size(576, 21);
            this.chkChonTatCa.TabIndex = 2;
            this.chkChonTatCa.CheckedChanged += new System.EventHandler(this.chkChonTatCa_CheckedChanged);
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 414);
            this.Controls.Add(this.chkChonTatCa);
            this.Controls.Add(this.grcQuyen);
            this.Controls.Add(this.grcNguoiDung);
            this.IconOptions.Image = global::MyRMS.Properties.Resources.Custo_Man_Christmas_Globe_Internet_128;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhanQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHÂN QUYỀN SỬ DỤNG";
            this.Load += new System.EventHandler(this.frmPhanQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcNguoiDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNguoiDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkTatCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkThem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkSua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkTruyCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChonTatCa.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcNguoiDung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNguoiDung;
        private DevExpress.XtraGrid.GridControl grcQuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQuyen;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkThem;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkSua;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkIn;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkNhap;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkXuat;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkTruyCap;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkTatCa;
        private DevExpress.XtraEditors.CheckEdit chkChonTatCa;
    }
}