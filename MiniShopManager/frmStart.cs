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
    public partial class frmStart : DevExpress.XtraEditors.XtraForm
    {
        public frmStart()
        {
            InitializeComponent();
        }
        public frmStart(string s)
        {
            InitializeComponent();
            lblTienTrinh.Text = s;
        }
        public void setValueProgressBar(int value, Boolean isshowtitle)
        {
            pbarTienTrinh.Properties.ShowTitle = isshowtitle;

            int currentpos = pbarTienTrinh.Position;
            for (int i = 1; i <= value - currentpos; i++)
            {
                pbarTienTrinh.Position = currentpos + i;
                pbarTienTrinh.Update();
                //System.Threading.Thread.Sleep(100);
            }

        }
        public int dem = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            setValueProgressBar(dem, true);
            if (dem == 100)
            {
                timer1.Enabled = false;
                this.Close();
            }
            dem = dem + 10;
        }

        private void frmKhoiDong_Load(object sender, EventArgs e)
        {
            this.Text = Info.tenphanmem;
            timer1.Enabled = true;
        }
    }
}