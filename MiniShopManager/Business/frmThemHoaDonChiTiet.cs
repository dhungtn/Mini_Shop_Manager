using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyRMS.NghiepVu
{
    public partial class frmThemHoaDonChiTiet : DevExpress.XtraEditors.XtraForm
    {
        public string hd_id = "";
        public string hd_thutu = "";
        public string mh_id = "";
        public string mh_ten = "";
        public string mh_donvi = "";
        public double mh_dongia = 0;
        public double mh_dongiavon = 0;
        public delegate void AddHoaDonChiTietDelegate(string hdct_mh_id, string hdct_donvi, double hdct_soluong, double hdct_dongia, double hdct_dongiavon, double hdct_thanhtien);
        public AddHoaDonChiTietDelegate AddHoaDonChiTiet;

        public string idct = "";
        public double number = 0;
        public double landau = 0;
        public delegate void SetSoLuongDelegate(string idct, double soluong);
        public SetSoLuongDelegate SetSoLuong;
        public void LayThongTinMatHang()
        {
            DataAccess cls = new DataAccess();
            string sql = "select MH_DVT, MH_GiaMua, MH_GiaBanLe, MH_GiaBanSi from MatHang where MH_ID = '" + mh_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                //mh_ten = dr["MH_Ten"].ToString().Trim();
                this.Text = "THÊM MẶT HÀNG VÀO HÓA ĐƠN";
                lblTenHang.Text = "<<" + mh_ten.ToUpper() + ">>";
                mh_donvi = dr["MH_DVT"].ToString().Trim();
                mh_dongiavon = double.Parse(dr["MH_GiaMua"].ToString().Trim());
                mh_dongia = double.Parse(dr["MH_GiaBanLe"].ToString().Trim());

            }

        }
        public frmThemHoaDonChiTiet()
        {
            InitializeComponent();
        }


        private void frmBangTinh_Load(object sender, EventArgs e)
        {
            try
            {
                spnNumber.EditValue = 1.0;
                LayThongTinMatHang();
            }
            catch (Exception)
            {


            }
            //spnNumber.EditValue = number;
            //if (loai == "soluong")
            //    spnNumber.EditValue = soluong;
            //if (loai == "dongia")
            //    spnNumber.EditValue = dongia;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            spnNumber.EditValue = 0;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (spnNumber.EditValue.ToString().Trim().Length == 1)
                spnNumber.EditValue = 0;
            else
            {
                string s = spnNumber.EditValue.ToString().Trim();
                s = s.Substring(0, s.Length - 1);
                spnNumber.EditValue = double.Parse(s);
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (landau == 0)
            {
                landau = 1;
                spnNumber.EditValue = 0;
            }
            else
            {
                if (double.Parse(spnNumber.EditValue.ToString()) > 0)
                {
                    string s = spnNumber.EditValue.ToString().Trim();
                    s = s + "0";
                    spnNumber.EditValue = double.Parse(s);
                }
            }
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            if (landau == 0)
            {
                landau = 1;
                spnNumber.EditValue = 0;
            }
            else
            {
                if (double.Parse(spnNumber.EditValue.ToString()) > 0)
                {
                    string s = spnNumber.EditValue.ToString().Trim();
                    s = s + "00";
                    spnNumber.EditValue = double.Parse(s);
                }
            }
        }

        private void btn000_Click(object sender, EventArgs e)
        {
            if (landau == 0)
            {
                landau = 1;
                spnNumber.EditValue = 0;
            }
            else
            {
                if (double.Parse(spnNumber.EditValue.ToString()) > 0)
                {
                    string s = spnNumber.EditValue.ToString().Trim();
                    s = s + "000";
                    spnNumber.EditValue = double.Parse(s);
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (landau == 0)
            {
                landau = 1;
                spnNumber.EditValue = 1;
            }
            else
            {
                if (double.Parse(spnNumber.EditValue.ToString()) == 0)
                {
                    spnNumber.EditValue = 1;
                }
                else
                {
                    string s = spnNumber.EditValue.ToString().Trim();
                    s = s + "1";
                    spnNumber.EditValue = double.Parse(s);
                }
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (landau == 0)
            {
                landau = 1;
                spnNumber.EditValue = 2;
            }
            else
            {
                if (double.Parse(spnNumber.EditValue.ToString()) == 0)
                {
                    spnNumber.EditValue = 2;
                }
                else
                {
                    string s = spnNumber.EditValue.ToString().Trim();
                    s = s + "2";
                    spnNumber.EditValue = double.Parse(s);
                }
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (landau == 0)
            {
                landau = 1;
                spnNumber.EditValue = 3;
            }
            else
            {
                if (double.Parse(spnNumber.EditValue.ToString()) == 0)
                {
                    spnNumber.EditValue = 3;
                }
                else
                {
                    string s = spnNumber.EditValue.ToString().Trim();
                    s = s + "3";
                    spnNumber.EditValue = double.Parse(s);
                }
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (landau == 0)
            {
                landau = 1;
                spnNumber.EditValue = 4;
            }
            else
            {
                if (double.Parse(spnNumber.EditValue.ToString()) == 0)
                {
                    spnNumber.EditValue = 4;
                }
                else
                {
                    string s = spnNumber.EditValue.ToString().Trim();
                    s = s + "4";
                    spnNumber.EditValue = double.Parse(s);
                }
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (landau == 0)
            {
                landau = 1;
                spnNumber.EditValue = 5;
            }
            else
            {
                if (double.Parse(spnNumber.EditValue.ToString()) == 0)
                {
                    spnNumber.EditValue = 5;
                }
                else
                {
                    string s = spnNumber.EditValue.ToString().Trim();
                    s = s + "5";
                    spnNumber.EditValue = double.Parse(s);
                }
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (landau == 0)
            {
                landau = 1;
                spnNumber.EditValue = 6;
            }
            else
            {
                if (double.Parse(spnNumber.EditValue.ToString()) == 0)
                {
                    spnNumber.EditValue = 6;
                }
                else
                {
                    string s = spnNumber.EditValue.ToString().Trim();
                    s = s + "6";
                    spnNumber.EditValue = double.Parse(s);
                }
            }
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            if (landau == 0)
            {
                landau = 1;
                spnNumber.EditValue = 7;
            }
            else
            {
                if (double.Parse(spnNumber.EditValue.ToString()) == 0)
                {
                    spnNumber.EditValue = 7;
                }
                else
                {
                    string s = spnNumber.EditValue.ToString().Trim();
                    s = s + "7";
                    spnNumber.EditValue = double.Parse(s);
                }
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (landau == 0)
            {
                landau = 1;
                spnNumber.EditValue = 8;
            }
            else
            {
                if (double.Parse(spnNumber.EditValue.ToString()) == 0)
                {
                    spnNumber.EditValue = 8;
                }
                else
                {
                    string s = spnNumber.EditValue.ToString().Trim();
                    s = s + "8";
                    spnNumber.EditValue = double.Parse(s);
                }
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (landau == 0)
            {
                landau = 1;
                spnNumber.EditValue = 9;
            }
            else
            {
                if (double.Parse(spnNumber.EditValue.ToString()) == 0)
                {
                    spnNumber.EditValue = 9;
                }
                else
                {
                    string s = spnNumber.EditValue.ToString().Trim();
                    s = s + "9";
                    spnNumber.EditValue = double.Parse(s);
                }
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                AddHoaDonChiTiet(mh_id, mh_donvi, double.Parse(spnNumber.EditValue.ToString()), mh_dongia, mh_dongiavon, double.Parse(spnNumber.EditValue.ToString()) * mh_dongia);
                this.Close();
            }
            catch (Exception)
            {


            }
            //try
            //{
            //    SetSoLuong(idct, double.Parse(spnNumber.EditValue.ToString()));
            //    this.Close();
            //}
            //catch (Exception)
            //{
                
                
            //}
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            if (double.Parse(spnNumber.EditValue.ToString()) == 0)
            {
                spnNumber.EditValue = 0;
            }
            else
            {
                string s = spnNumber.EditValue.ToString().Trim();
                s = "-" + s;
                spnNumber.EditValue = double.Parse(s);
            }
        }
    }
}