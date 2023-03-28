using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace MyRMS
{
    public static class TTHMessage
    {
        public static DialogResult ShowMessageConfirm(string message)
        {
            return XtraMessageBox.Show(message, "Thông Báo Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static void ShowMessageWarming(string message)
        {
            XtraMessageBox.Show(message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void ShowMessageInfomation(string message)
        {
            XtraMessageBox.Show(message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowMessageError(string message)
        {
            XtraMessageBox.Show(message, "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
