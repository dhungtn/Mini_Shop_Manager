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
    public partial class Test : DevExpress.XtraEditors.XtraForm
    {
        public Test()
        {
            InitializeComponent();
        }

        private void btnMoKetNoi_Click(object sender, EventArgs e)
        {
            DataAccessStatic.OpenConnection();
        }

        private void btnDongKetNoi_Click(object sender, EventArgs e)
        {
            DataAccessStatic.CloseConnection();
        }

        private void btnKetNoiLai_Click(object sender, EventArgs e)
        {
            DataAccessStatic.ReOpenConnection();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            //TTHMessage.ShowMessageInfomation(DataAccessStatic.conn.State.ToString());
        }
    }
}