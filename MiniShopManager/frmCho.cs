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
    public partial class frmCho : DevExpress.XtraEditors.XtraForm
    {
        public frmCho()
        {
            InitializeComponent();
        }
        public frmCho(string s)
        {
            InitializeComponent();
            lblWait.Text = s;
        }
        private void frmWait_Load(object sender, EventArgs e)
        {
            //lblWait.Text = "Bài Tin Mừng hôm nay đề cao đức công chính của thánh Giu-se,\n biểu lộ qua cách xử lý trước việc thụ thai lạ lùng \ncủa Đức Ma-ri-a.";
            
        }

        private void frmWait_Activated(object sender, EventArgs e)
        {
            //this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}