using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyRMS
{
    public partial class frmTinhGio : DevExpress.XtraEditors.XtraForm
    {
        public string hd_id = "";
        DataAccess cls = new DataAccess();
        public delegate void TinhGioDelegate(DateTime giovao, DateTime giaora);
        public TinhGioDelegate TinhGio;
        public DateTime LayGioVao()
        {
            
            DateTime d = DateTime.Now;
            string sql = "select HD_GioVao from HoaDon where HD_ID = '" + hd_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                d = (DateTime)dr["HD_GioVao"];
            }
            return d;
        }
        public string TinhThoiGian(DateTime giovao, DateTime giora)
        {
            string thoigian = "";
            int gv = giora.Hour;
            int gr = giovao.Hour;
            if (gv > gr) gr = gr + 24;
            int phut = (gr * 60 + giora.Minute) - (gv * 60 + giovao.Minute);
            int gio = phut / 60;
            int phutle = phut % 60;
            thoigian = gio.ToString() + ":" + phutle.ToString();
            return thoigian;
        }
        public frmTinhGio()
        {
            InitializeComponent();
        }

        private void frmTinhGio_Load(object sender, EventArgs e)
        {
            timeGioVao.EditValue = LayGioVao();
            timeGioRa.EditValue = DateTime.Now;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            string[] field = { "HD_GioVao", "HD_GioRa", "HD_ThoiGian", "HD_DaTinhGio" };
            object[] value = { (object)((DateTime)timeGioVao.EditValue), (object)((DateTime)timeGioRa.EditValue), (object)TinhThoiGian((DateTime)timeGioVao.EditValue, (DateTime)timeGioRa.EditValue), (object)true };
            string[] fieldwhere = { "HD_ID" };
            object[] valuewhere = { (object)hd_id };
            if (cls.EditRecord("HoaDon", field, value, fieldwhere, valuewhere))
            {
                TinhGio((DateTime)timeGioVao.EditValue, (DateTime)timeGioRa.EditValue);
                this.Close();
            }
        }
    }
}