using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.Utils.Serializing;
using DevExpress.XtraLayout.ViewInfo;

using DevExpress.XtraLayout;
using DevExpress.XtraBars;

namespace MyRMS.TienIch
{
    public partial class frmBrowser : DevExpress.XtraEditors.XtraForm
    {
        public delegate void DisplayObject();
        public DisplayObject DisplayBackgroung;
        public delegate void MoFormMacDinh(Form frm);
        public MoFormMacDinh moFormMacDinh;
        public WebBrowser browser = new WebBrowser();
        bool needDecreaseSelectedPageIndex = false;
        string defaultUrl = "";
        string dxUrl = "http://www.tamtrihiep.com";
        int tabIndexToSelect = -1;
        protected void SetUrlInSelectedTabPage(string url)
        {
            if (url == "" || url == null) ((WebBrowser)((LayoutControlItem)tabbedControlGroup1.SelectedTabPage[0]).Control).GoHome();
            else ((WebBrowser)((LayoutControlItem)tabbedControlGroup1.SelectedTabPage[0]).Control).Url = new Uri(url);
        }
        protected void UpdateUrl()
        {
            bool wasError = false;
            try
            {
                SetUrlInSelectedTabPage((string)urlEdit.EditValue);
            }
            catch
            {
                try
                {
                    SetUrlInSelectedTabPage("http://" + (string)urlEdit.EditValue);
                }
                catch
                {
                    wasError = true;
                }
            }
            if (!wasError)
            {
                tabbedControlGroup1.SelectedTabPage.Text = (string)urlEdit.EditValue;
            }
        }
        public frmBrowser()
        {
            InitializeComponent();
        }
        protected void FillComboBoxValues()
        {
            string[] names = Enum.GetNames(tabbedControlGroup1.TextLocation.GetType());
            foreach (string name in names)
                comboBoxEdit1.Properties.Items.Add(name);
            comboBoxEdit1.SelectedIndex = 0;
        }
        protected void AsyncSelectTab()
        {
            tabbedControlGroup1.SelectedTabPageIndex = tabIndexToSelect;
        }
        protected void CheckCloseButtonStatus()
        {
            if (tabbedControlGroup1.TabPages.Count == 2) tabbedControlGroup1.TabPages[0].ShowTabPageCloseButton = false;
            if (tabbedControlGroup1.TabPages.Count > 2) tabbedControlGroup1.TabPages[0].ShowTabPageCloseButton = true;
        }
        protected void CreateBrowserTab(String url)
        {
            layoutControl1.BeginUpdate();
            LayoutControlGroup newPage = new LayoutControlGroup();
            tabbedControlGroup1.InsertTabPage(tabbedControlGroup1.TabPages.Count - 1, newPage);
            newPage.ShowTabPageCloseButton = true;
            LayoutControlItem lci = newPage.AddItem();
            lci.Padding = new DevExpress.XtraLayout.Utils.Padding(0);
            lci.TextVisible = false;
            lci.BeginInit();
            //WebBrowser browser = new WebBrowser();
            
            browser.Bounds = Rectangle.Empty;//antiflicker :)
            browser.Name = Guid.NewGuid().ToString();
            lci.Control = browser;
            lci.EndInit();
            SetUrlInSelectedTabPage(url);
            newPage.Text = url != "" ? url : "New Page";
            CheckCloseButtonStatus();
            tabIndexToSelect = tabbedControlGroup1.TabPages.IndexOf(newPage);
            BeginInvoke(new MethodInvoker(AsyncSelectTab));
            layoutControl1.EndUpdate();
        }
        public void DestroyTab(LayoutGroup group)
        {
            tabbedControlGroup1.BeginUpdate();
            ((WebBrowser)((LayoutControlItem)group[0]).Control).Dispose();
            group.Dispose();
            CheckCloseButtonStatus();
            tabbedControlGroup1.EndUpdate();
        }
        private void frmBrowser_Load(object sender, EventArgs e)
        {
            CreateBrowserTab(dxUrl);
            FillComboBoxValues();
        }

        private void urlEdit_Click(object sender, EventArgs e)
        {
            //tabbedControlGroup1.BeginUpdate();
            //tabbedControlGroup1.SelectedTabPage.HideToCustomization();
            //tabbedControlGroup1.EndUpdate();
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            tabbedControlGroup1.MultiLine = checkEdit1.Checked ? DefaultBoolean.True : DefaultBoolean.False;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            tabbedControlGroup1.HeaderOrientation = checkEdit2.Checked ? DevExpress.XtraTab.TabOrientation.Vertical : DevExpress.XtraTab.TabOrientation.Horizontal;
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabbedControlGroup1.TextLocation = (Locations)Enum.Parse(typeof(Locations), (string)comboBoxEdit1.Properties.Items[comboBoxEdit1.SelectedIndex]);
            checkEdit2_CheckedChanged(sender, e);
        }

        private void urlEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) UpdateUrl();
        }

        private void tabbedControlGroup1_SelectedPageChanging(object sender, LayoutTabPageChangingEventArgs e)
        {
            if (e.Page == tabbedControlGroup1.TabPages[tabbedControlGroup1.TabPages.Count - 1])
            {
                if (!tabbedControlGroup1.IsUpdateLocked)
                {
                    CreateBrowserTab(defaultUrl);
                    e.Cancel = true;
                }
                else
                {
                    needDecreaseSelectedPageIndex = true;
                }
            }
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e)
        {
            if (needDecreaseSelectedPageIndex)
            {
                needDecreaseSelectedPageIndex = false;
                tabbedControlGroup1.SelectedTabPageIndex--;
            }
        }

        private void layoutControl1_TabPageCloseButtonClick(object sender, DevExpress.XtraLayout.Utils.LayoutGroupEventArgs e)
        {
            if (tabbedControlGroup1.TabPages.Count == 2) return;
            DestroyTab(e.Group);
        }

        private void urlEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            UpdateUrl();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //WebBrowser browser = new WebBrowser();
           
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            browser.GoBack();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            browser.GoForward();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            browser.GoHome();
           
        }

        private void frmBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisplayBackgroung();
        }
    }
}