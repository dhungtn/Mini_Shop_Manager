using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
namespace MyRMS.DanhMuc
{
    public partial class frmMatHangUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void SetMatHangDelegate(string value);
        public SetMatHangDelegate SetMatHang;
        public delegate void GetDataTableDelegate();
        public GetDataTableDelegate LayDSMatHang;
        public delegate void AddMatHangDelegate(string MH_ID, string MH_Ma, string MH_Ten, string MH_DVT, double MH_GiaMua, double MH_GiaBanSi, double MH_GiaBanLe, double MH_GiaTraCham, string MH_GhiChu, Boolean MH_TrangThai, string MH_TuKhoa);
        public AddMatHangDelegate AddMatHang;
        public delegate void EditMatHangDelegate(string MH_ID, string MH_Ma, string MH_Ten, string MH_DVT, double MH_GiaMua, double MH_GiaBanSi, double MH_GiaBanLe, double MH_GiaTraCham, string MH_GhiChu, Boolean MH_TrangThai, string MH_TuKhoa);
        public EditMatHangDelegate EditMatHang;
        public delegate void AddHoaDonChiTietDelegate(string hdct_mh_id, string hdct_donvi, double hdct_soluong, double hdct_dongia, double hdct_dongiavon, double hdct_thanhtien);
        public AddHoaDonChiTietDelegate AddHoaDonChiTiet;
        public string mh_id = "";
        public Boolean issua = false;
        public string frmReq = "";
        public string frmText = "";
        public string loai = "";
        public string lh_id = "";
        public byte[] imgArray = null;
        public frmMatHangUpdate()
        {
            InitializeComponent();
        }
        public void LayDSLoaiHang()
        {
            DataAccess cls = new DataAccess();
            string sql = "select LH_ID, LH_Ten from LoaiHang where LH_KichHoat = 'True' order by LH_Ten";
            glkuLoaiHang.Properties.DataSource = cls.GetDataTable(sql);
            glkuLoaiHang.Properties.ValueMember = "LH_ID";
            glkuLoaiHang.Properties.DisplayMember = "LH_Ten";
            glkuLoaiHang.Properties.PopupFormWidth = glkuLoaiHang.Size.Width - 4;
            glkuvLoaiHang.BestFitColumns();
            if (glkuvLoaiHang.RowCount > 0)
            {
                DataRow row = glkuvLoaiHang.GetDataRow(0);
                glkuLoaiHang.EditValue = row["LH_ID"].ToString().Trim();
            }
            if (lh_id.Trim().Length > 0) glkuLoaiHang.EditValue = lh_id;
        }
        public Boolean ThemMatHang()
        {
            
            string[] field = { "MH_ID", "MH_Ma", "MH_Ten", "MH_DVT",  "MH_GiaMua", "MH_GiaBanSi", "MH_GiaBanLe", "MH_GiaTraCham", "MH_GhiChu", "MH_KichHoat", "MH_LH_ID",  "MH_TuKhoa", "MH_DV_ID", "MH_TheoDoiTon" };
            object[] value = { (object)mh_id, (object)txtMa.Text.Trim(), (object)txtTen.Text.Trim(), (object)cboDVT.Text.Trim(), (object)double.Parse(spnGiaMua.EditValue.ToString()), (object)0, (object)double.Parse(spnGiaBanLe.EditValue.ToString()), (object)double.Parse(spnGiaBanLe.EditValue.ToString()), (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked, (object)glkuLoaiHang.EditValue.ToString().Trim(), (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()), (object)Info.dv_id, (object)true };
            return cls.AddRecord("MatHang", field, value);
        }
        public Boolean SuaMatHang()
        {
            
            string[] field = { "MH_Ma", "MH_Ten", "MH_DVT",  "MH_GiaMua", "MH_GiaBanSi", "MH_GiaBanLe", "MH_GiaTraCham", "MH_GhiChu", "MH_KichHoat", "MH_LH_ID", "MH_TuKhoa", "MH_DV_ID", "MH_TheoDoiTon" };
            object[] value = { (object)txtMa.Text.Trim(), (object)txtTen.Text.Trim(), (object)cboDVT.Text.Trim(), (object)double.Parse(spnGiaMua.EditValue.ToString()), (object)double.Parse(spnGiaBanLe.EditValue.ToString()), (object)double.Parse(spnGiaBanLe.EditValue.ToString()), (object)double.Parse(spnGiaBanLe.EditValue.ToString()), (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked, (object)glkuLoaiHang.EditValue.ToString().Trim(), (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()), (object)Info.dv_id, (object)true };
            string[] fieldwhere = { "MH_ID"};
            object[] objwhere = { (object)mh_id };
            return cls.EditRecord("MatHang", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinMatHang()
        {
            string sql = "select * from MatHang where MH_ID = '" + mh_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                glkuLoaiHang.EditValue = dr["MH_LH_ID"].ToString().Trim();
                txtMa.Text = dr["MH_Ma"].ToString().Trim();
                txtMa.Enabled = true;
                txtTen.Text = dr["MH_Ten"].ToString().Trim();
                cboDVT.Text = dr["MH_DVT"].ToString().Trim();
                //try
                //{
                //    System.IO.MemoryStream imgStream = new System.IO.MemoryStream((byte[])dr["MH_HinhAnh"], 0, ((byte[])dr["MH_HinhAnh"]).Length);
                //    imgStream.Write((byte[])dr["MH_HinhAnh"], 0, ((byte[])dr["MH_HinhAnh"]).Length);
                //    picHinhAnh.Image = Image.FromStream(imgStream, true);
                //}
                //catch (Exception)
                //{
                    
                    
                //}
                spnGiaMua.EditValue = double.Parse(dr["MH_GiaMua"].ToString());
                //spnGiaBanSi.EditValue = double.Parse(dr["MH_GiaBanSi"].ToString());
                spnGiaBanLe.EditValue = double.Parse(dr["MH_GiaBanLe"].ToString());
                
                txtGhiChu.Text = dr["MH_GhiChu"].ToString().Trim();
                chkKichHoat.Checked = (bool)dr["MH_KichHoat"];
                //chkTheoDoiTon.Checked = (bool)dr["MH_TheoDoiTon"];
            }
        }
        public void LayDSDVT()
        {
            string sql = "select distinct MH_DVT from MatHang order by MH_DVT ";
            cboDVT.Properties.Items.Clear();
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                cboDVT.Properties.Items.Add(dr["MH_DVT"].ToString().Trim());
            }

        }
        public string TaoMaHang()
        {
            string s = TTHUtils.TaoMaSoNgauNhien(8);
            if (cls.IsExist("select MH_ID from MatHang where MH_ID = '" + s + "'"))
                s = TaoMaHang();
            return s;
        }
        private void frmCapNhatHangHoa_Load(object sender, EventArgs e)
        {
            this.Text = frmText;
            LayDSLoaiHang();
            LayDSDVT();
            if (issua)
            {
                LayThongTinMatHang();

            }
            else
            {
                if (mh_id.Length == 0)
                {
                    mh_id = TaoMaHang();
                    txtMa.Text = mh_id;
                    txtMa.Focus();
                    txtMa.SelectAll();
                }
                else
                {
                    txtMa.Text = mh_id;
                    txtTen.Focus();
                    txtTen.SelectAll();
                }
                //txtMa.Enabled = false;
                //txtTen.Focus();
                //txtTen.SelectAll();
                
            }
        }
        

        private void barF12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnLuu_Click(null, null);
            
        }

        private void barDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDong_Click(null, null);
        }

        private void txtMa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                txtMa.Text = TTHUtils.TaoMaSoNgauNhien(Info.dodaimadoitac);
                txtMa.SelectAll();
                txtMa.Focus();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMa.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập mã.");
                txtMa.Focus();
                return;
            }
            if (!issua)
            {
                if (cls.IsExist("select MH_Ma from MatHang where MH_Ma = '" + txtMa.Text.Trim() + "'"))
                {
                    TTHMessage.ShowMessageWarming("Mã này đã tồn tại. Xin chọn mã khác!");
                    txtMa.Focus();
                    txtMa.SelectAll();
                    return;
                }
            }
            if (txtTen.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập tên.");
                txtTen.Focus();
                return;
            }
            if (glkuLoaiHang.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa chọn loại hàng.");
                txtMa.Focus();
                return;
            }
            if (cboDVT.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập đơn vị tính.");
                cboDVT.Focus();
                return;
            }
            Boolean ok = false;
            if (issua)
                ok = SuaMatHang();
            else
            {
                ok = ThemMatHang();
            }
            if (ok)
            {

                try
                {
                    AddMatHang(mh_id, txtMa.Text.Trim(), txtTen.Text.Trim(), cboDVT.Text.Trim(), double.Parse(spnGiaMua.EditValue.ToString()), double.Parse(spnGiaBanLe.EditValue.ToString()), double.Parse(spnGiaBanLe.EditValue.ToString()), double.Parse(spnGiaBanLe.EditValue.ToString()), txtGhiChu.Text.Trim(), chkKichHoat.Checked, TTHUtils.LoaiBoDauTiengViet(txtMa.Text.Trim() + txtTen.Text.Trim()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                try
                {
                    EditMatHang(mh_id, txtMa.Text.Trim(), txtTen.Text.Trim(), cboDVT.Text.Trim(), double.Parse(spnGiaMua.EditValue.ToString()), double.Parse(spnGiaBanLe.EditValue.ToString()), double.Parse(spnGiaBanLe.EditValue.ToString()), double.Parse(spnGiaBanLe.EditValue.ToString()), txtGhiChu.Text.Trim(), chkKichHoat.Checked, TTHUtils.LoaiBoDauTiengViet(txtMa.Text.Trim() + txtTen.Text.Trim()));
                }
                catch (Exception)
                {


                }
                try
                {
                    LayDSMatHang();
                }
                catch (Exception)
                {


                }
                try
                {
                    SetMatHang(mh_id);
                }
                catch (Exception)
                {


                }
                try
                {
                    AddHoaDonChiTiet(mh_id, "", 1, double.Parse(spnGiaBanLe.EditValue.ToString()), double.Parse(spnGiaMua.EditValue.ToString()), double.Parse(spnGiaBanLe.EditValue.ToString()));
                }
                catch (Exception)
                {
                    
                    
                }
                TTHMessage.ShowMessageInfomation("Đã lưu thành công!");
                if (frmText.Length > 0 || issua == true || frmReq.Trim().Length > 0)
                    this.Close();
                issua = false;
                mh_id = DateTime.Now.ToString("yyMMddHHmmss");//.Substring(8, 6) + TTHUtils.TaoMaSoNgauNhien(2);
                LayDSDVT();
                txtMa.Text = DateTime.Now.ToString("yyMMddHHmmss");
                txtMa.Focus();
                txtMa.SelectAll();
                if (!chkSaoChep.Checked)
                {
                    txtTen.Text = "";
                    //cboDonVi.Text = "";
                    spnGiaMua.EditValue = 0;
                    //spnGiaBanSi.EditValue = 0;
                    spnGiaBanLe.EditValue = 0;

                    txtGhiChu.Text = "";
                }
               
                
                //chkTrangThai.Checked = false;
                //txtKhoiTaoNo.EditValue = 0.0;

            }
            else TTHMessage.ShowMessageWarming("Không thể lưu. Xin kiểm tra lại thông tin!");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PasteImage(PictureEdit edit, Image im)
        {
            if ((edit.EditValue is Image) || edit.Properties.PictureStoreMode == DevExpress.XtraEditors.Controls.PictureStoreMode.Image)
                edit.EditValue = im;
            else
                edit.EditValue = DevExpress.XtraEditors.Controls.ByteImageConverter.ToByteArray(im, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
       
        public void SetLoaiHang(string s)
        {
            glkuLoaiHang.EditValue = s;
        }
        public Boolean XoaLoaiHang(string lh_id)
        {
            string sql = "delete LoaiHang where LH_ID = '" + lh_id + "'";
            return cls.ExecuteNonQuery(sql);
        }
        private void glkuLoaiHang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                frmLoaiHangUpdate frm = new frmLoaiHangUpdate();
                frm.LayDSLoaiHang = new frmLoaiHangUpdate.GetDataTableDelegate(LayDSLoaiHang);
                frm.SetLoaiHang = new frmLoaiHangUpdate.SetStringDelegate(SetLoaiHang);
                frm.frmText = "LOẠI HÀNG [Thêm]";
                frm.frmReq = "MẶT HÀNG";
                frm.ShowDialog();
            }
            //if (e.Button.Index == 2)
            //{
            //    if (glkuLoaiHang.Text.Length > 0)
            //    {
            //        frmLoaiHangUpdate frm = new frmLoaiHangUpdate();
            //        frm.LayDSLoaiHang = new frmLoaiHangUpdate.GetDataTableDelegate(LayDSLoaiHang);
            //        frm.SetLoaiHang = new frmLoaiHangUpdate.SetStringDelegate(SetLoaiHang);
            //        frm.frmText = "LOẠI HÀNG [Sửa]";
            //        frm.issua = true;
            //        frm.lh_id = glkuLoaiHang.EditValue.ToString();
            //        frm.ShowDialog();
            //    }
            //}
            //if (e.Button.Index == 3)
            //{
            //    try
            //    {
            //        if (glkuLoaiHang.Text.Length == 0) return;
            //        string lh_id = glkuLoaiHang.EditValue.ToString();

            //        //Xoa mot dong
            //        if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa dòng được chọn không?") == DialogResult.Yes)
            //        {

            //            if (!XoaLoaiHang(lh_id))
            //                TTHMessage.ShowMessageWarming("Không thể xóa dòng này.");
            //            else
            //            {
            //                LayDSLoaiHang();
            //                TTHMessage.ShowMessageInfomation("Đã xóa thành công.");

            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {

            //        TTHMessage.ShowMessageWarming("Bạn chưa chọn dòng muốn xóa!");
            //    }
            //}
        }

        private void txtMa_MouseUp(object sender, MouseEventArgs e)
        {
            txtMa.SelectAll();
        }

        private void txtTen_MouseUp(object sender, MouseEventArgs e)
        {
            //txtTen.SelectAll();
        }

        private void glkuLoaiHang_MouseUp(object sender, MouseEventArgs e)
        {
            glkuLoaiHang.SelectAll();
        }

        private void spnGiaMua_MouseUp(object sender, MouseEventArgs e)
        {
            spnGiaMua.SelectAll();
        }

        private void spnGiaBanLe_MouseUp(object sender, MouseEventArgs e)
        {
            spnGiaBanLe.SelectAll();
        }

        private void txtGhiChu_MouseUp(object sender, MouseEventArgs e)
        {
            txtGhiChu.SelectAll();
        }
    }
}