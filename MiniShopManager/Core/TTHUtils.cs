using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Management;
using Microsoft.Win32;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Drawing;
namespace MyRMS
{
    public static class TTHUtils
    {
        public static string GetDate()
        {
            string s = "";
            DateTime date = DateTime.Now;
            string sthu = "";
            string sday = date.DayOfWeek.ToString();
            if (sday == "Monday")
                sthu = "Thứ 2";
            if (sday == "Tuesday")
                sthu = "Thứ 3";
            if (sday == "Wednesday")
                sthu = "Thứ 4";
            if (sday == "Thursday")
                sthu = "Thứ 5";
            if (sday == "Friday")
                sthu = "Thứ 6";
            if (sday == "Saturday")
                sthu = "Thứ 7";
            if (sday == "Sunday")
                sthu = "Chủ nhật";
            s = sthu + ", ngày " + date.ToString("dd/MM/yyyy");
            return s;
        }
        public static string ConvertNumberToText(string s)
        {
            string tempNum2Text = null;
            try
            {
                string[] so = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                string[] hang = { "", "nghìn", "triệu", "tỷ" };

                int i = 0;
                int j = 0;
                int donvi = 0;
                int chuc = 0;
                int tram = 0;
                string str = null;
                str = "";
                i = s.Length;

                for (j = 0; j < i; j++)
                {
                    if (s.Substring(0, 1) == "0")
                    {
                        s = s.Substring(s.Length - (i - j));
                    }
                }
                if (s == "0")
                {
                    return so[0];
                }
                i = s.Length;
                if (i == 0)
                {
                    str = "";
                }
                else
                {
                    j = 0;
                    while (i > 0)
                    {
                        donvi = int.Parse(s.Substring(i - 1, 1));
                        i = i - 1;
                        if (i > 0)
                        {
                            chuc = int.Parse(s.Substring(i - 1, 1));
                        }
                        else
                        {
                            chuc = -1;
                        }
                        i = i - 1;
                        if (i > 0)
                        {
                            tram = int.Parse(s.Substring(i - 1, 1));
                        }
                        else
                        {
                            tram = -1;
                        }
                        i = i - 1;
                        if (donvi > 0 | chuc > 0 | tram > 0 || j == 3)
                        {
                            str = hang[j] + " " + str;
                        }
                        j = j + 1;
                        if (j > 3)
                        {
                            j = 1;
                        }
                        if (donvi == 1 && chuc > 1)
                        {
                            str = "mốt" + " " + str;
                        }
                        else
                        {
                            if (donvi == 5 && chuc > 0)
                            {
                                str = "lăm" + " " + str;
                            }
                            else if (donvi > 0)
                            {
                                str = so[donvi] + " " + str;
                            }
                        }
                        if (chuc < 0)
                        {
                            break;
                        }
                        else
                        {
                            if (chuc == 0 && donvi > 0)
                            {
                                str = "lẻ" + " " + str;
                            }
                            else if (chuc == 1)
                            {
                                str = "mười" + " " + str;
                            }
                            else if (chuc > 1)
                            {
                                str = so[chuc] + " " + "mươi" + " " + str;
                            }
                        }
                        if (tram < 0)
                        {
                            break;
                        }
                        else
                        {
                            if (tram > 0 | chuc > 0 | donvi > 0)
                            {
                                str = so[tram] + " " + "trăm" + " " + str;
                            }
                        }
                    }
                }
                str = str.Trim(' ');
                str = str.Substring(0, 1).ToUpper() + str.Substring(str.Length - (str.Length - 1));
                tempNum2Text = "(" + str + " đồng)";
            }
            catch (Exception)
            {
                tempNum2Text = "";
            }
            return tempNum2Text;
        }
        



        public static DateTime LayNgayDauThang()
        {
            string sdate = DateTime.Now.ToString("dd/MM/yyyy");
            string sthang = sdate.Substring(3, 2);
            return DateTime.ParseExact("01/" + sthang + "/" + DateTime.Now.Year.ToString(), "dd/MM/yyyy", null);
        }
        public static byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        public static bool IsValidInt(string val)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(val, @"^[1-9]\d*\.?[0]*$");
        }
        public static string MaHoaBase64(byte[] Bydata)
        {
            if (Bydata == null)
            {
                throw new ArgumentNullException("Bydata");
            }
            return Convert.ToBase64String(Bydata);
        }

        public static byte[] GiaiMaBase64(string base64)
        {
            if (base64 == null)
            {
                throw new ArgumentNullException("base64");
            }
            return Convert.FromBase64String(base64);
        }
        
        //Kiem tra co cai dat SQL Server 2005 chưa
        public static bool IsExpressInstalled()
        {
            using (RegistryKey Key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Microsoft SQL Server\\", false))
            {
                if (Key == null) return false;
                string[] strNames;
                strNames = Key.GetSubKeyNames();

                //If we cannot find a SQL Server registry key, we don't have SQL Server Express installed
                if (strNames.Length == 0) return false;

                foreach (string s in strNames)
                {
                    if (s.StartsWith("MSSQL."))
                    {
                        //Check to see if the edition is "Express Edition"
                        using (RegistryKey KeyEdition = Key.OpenSubKey(s.ToString() + "\\Setup\\", false))
                        {
                            if ((string)KeyEdition.GetValue("Edition") == "Express Edition")
                            {
                                //If there is at least one instance of SQL Server Express installed, return true
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        //Loại bỏ các dấu tiếng Việt khỏi chuỗi
        public static string RejectMarks(string text)
        {
            text = text.ToLower();
            string[] pattern = new string[7];
            pattern[0] = "a|(á|ả|à|ạ|ã|ă|ắ|ẳ|ằ|ặ|ẵ|â|ấ|ẩ|ầ|ậ|ẫ)";
            pattern[1] = "o|(ó|ỏ|ò|ọõ|ô|ố|ổ|ồ|ộ|ỗ|ơ|ớ|ở|ờ|ợ|ỡ|ọ)";
            pattern[2] = "e|(é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ)";
            pattern[3] = "u|(ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ)";
            pattern[4] = "i|(í|ì|ỉ|ị|ĩ)";
            pattern[5] = "y|(ý|ỳ|ỷ|ỵ|ỹ)";
            pattern[6] = "d|đ";
            for (int i = 0; i < pattern.Length; i++)
            {
                // kí tự sẽ thay thế
                char replaceChar = pattern[i][0];
                MatchCollection matchs = Regex.Matches(text, pattern[i]);
                foreach (Match m in matchs)
                {
                    text = text.Replace(m.Value[0], replaceChar);
                }
            }
            text = text.Replace(" - ", "").Replace(" - ", "").Replace(" –", "").Replace("– ", "").Replace("(", "").Replace(")", "").Replace("@", "").Replace("/", "").Replace(": ", "").Replace(":", "").Replace("“", "").Replace("”", "").Replace("?", "").Replace(" , ", "").Replace(", ", "").Replace(" ,", "").Replace(",", "").Replace(" ", "");
            return text;
        }
        public static string RejectMarks1(string text)
        {
            text = text.ToLower();
            string[] pattern = new string[7];
            pattern[0] = "a|(á|ả|à|ạ|ã|ă|ắ|ẳ|ằ|ặ|ẵ|â|ấ|ẩ|ầ|ậ|ẫ)";
            pattern[1] = "o|(ó|ỏ|ò|ọõ|ô|ố|ổ|ồ|ộ|ỗ|ơ|ớ|ở|ờ|ợ|ỡ|ọ)";
            pattern[2] = "e|(é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ)";
            pattern[3] = "u|(ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ)";
            pattern[4] = "i|(í|ì|ỉ|ị|ĩ)";
            pattern[5] = "y|(ý|ỳ|ỷ|ỵ|ỹ)";
            pattern[6] = "d|đ";
            for (int i = 0; i < pattern.Length; i++)
            {
                // kí tự sẽ thay thế
                char replaceChar = pattern[i][0];
                MatchCollection matchs = Regex.Matches(text, pattern[i]);
                foreach (Match m in matchs)
                {
                    text = text.Replace(m.Value[0], replaceChar);
                }
            }
            text = text.Replace(" - ", "").Replace(" - ", "").Replace(" –", "").Replace("– ", "").Replace("(", "").Replace(")", "").Replace("@", "").Replace("/", "").Replace(": ", "").Replace(":", "").Replace("“", "").Replace("”", "").Replace("?", "").Replace(" , ", "").Replace(", ", "").Replace(" ,", "").Replace(",", "").Replace(" ", "").Replace(".", "").Replace(" .", "").Replace(". ", "").Replace(" . ", "").Replace("!", "");
            return text;
        }
        public static string LoaiBoDauTiengViet(string text)
        {
            text = text.ToLower();
            string[] pattern = new string[7];
            pattern[0] = "a|(á|ả|à|ạ|ã|ă|ắ|ẳ|ằ|ặ|ẵ|â|ấ|ẩ|ầ|ậ|ẫ)";
            pattern[1] = "o|(ó|ỏ|ò|ọõ|ô|ố|ổ|ồ|ộ|ỗ|ơ|ớ|ở|ờ|ợ|ỡ|ọ)";
            pattern[2] = "e|(é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ)";
            pattern[3] = "u|(ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ)";
            pattern[4] = "i|(í|ì|ỉ|ị|ĩ)";
            pattern[5] = "y|(ý|ỳ|ỷ|ỵ|ỹ)";
            pattern[6] = "d|đ";
            for (int i = 0; i < pattern.Length; i++)
            {
                // kí tự sẽ thay thế
                char replaceChar = pattern[i][0];
                MatchCollection matchs = Regex.Matches(text, pattern[i]);
                foreach (Match m in matchs)
                {
                    text = text.Replace(m.Value[0], replaceChar);
                }
            }
            text = text.Replace(" - ", "").Replace(" - ", "").Replace(" –", "").Replace("– ", "").Replace("(", "").Replace(")", "").Replace("@", "").Replace("/", "").Replace(": ", "").Replace(":", "").Replace("“", "").Replace("”", "").Replace("?", "").Replace(" , ", "").Replace(", ", "").Replace(" ,", "").Replace(",", "").Replace(" ", "").Replace(".", "").Replace(" .", "").Replace(". ", "").Replace(" . ", "").Replace("!", "");
            return text;
        }
        private static void ExportTo(DevExpress.XtraGrid.Views.Grid.GridView grv)
        {
            //// Cursor currentCursor = Cursor.Current;
            // //Cursor.Current = Cursors.WaitCursor;

            // //frm.FindForm().Refresh();
            // BaseExportLink link = grv.CreateExportLink(provider);
            // (link as GridViewExportLink).ExpandAll = false;
            // //link.Progress += new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);
            // link.ExportTo(true);
            // provider.Dispose();
            // //link.Progress -= new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);

            // //Cursor.Current = currentCursor;
        }
        private static string ShowSaveFileDialog(string title, string filter, string filename)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            //string name = Application.ProductName;
            //int n = name.LastIndexOf(".") + 1;
            //if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "Export To " + title;
            dlg.FileName = filename;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
        private static void OpenFile(string fileName)
        {
            if (XtraMessageBox.Show("Bạn có muốn mở file này không?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Phần Mềm Quản Lý Bán Hàng", "Không tìm thấy file này trong hệ thống.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        public static void ExportToExcel(DevExpress.XtraGrid.Views.Grid.GridView grv)
        {
            if (grv.RowCount > 0)
            {
                string fileName = "";
                fileName = ShowSaveFileDialog("Xuất ra file Excel", "Microsoft Excel|*.xls", "NhatKySuDung");
                if (fileName != "")
                {
                    grv.ExportToXls(fileName);
                    OpenFile(fileName);
                }
            }
            else TTHMessage.ShowMessageWarming("Không có dữ liệu để export.");
        }
        public static void ExportToExcelFile(DevExpress.XtraGrid.Views.Grid.GridView grv, string filename)
        {
            if (grv.RowCount > 0)
            {
                string fileName = "";
                fileName = ShowSaveFileDialog("Xuất ra file Excel", "Microsoft Excel|*.xls", filename);
                if (fileName != "")
                {
                    grv.ExportToXls(fileName);
                    OpenFile(fileName);
                }
            }
            else TTHMessage.ShowMessageWarming("Không có dữ liệu để export.");
        }
        

        /// <summary>
        /// ////////////////////CAC HAM XU LY CHUOI///////////////////////
        /// </summary>
        /// <returns></returns>
        public static string RandomString(int size)
        {
            Random rnd = new Random();
            string srds = "";
            string[] str = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            for (int i = 0; i < size; i++)
            {
                srds = srds + str[rnd.Next(0, str.Length)];
            }
            return srds;
        }
        public static string TaoMaSoNgauNhien(int dodaichuoi)
        {
            string randomStr = "";
            int[] myIntArray = new int[dodaichuoi];
            int x;
            //Phần tạo ngẫu nhiên các ký tự để xuất ra
            Random autoRand = new Random();
            for (x = 0; x < dodaichuoi; x++)
            {
                myIntArray[x] = System.Convert.ToInt32(autoRand.Next(0, 9));
                randomStr += (myIntArray[x].ToString());
            }
            return randomStr;
        }
        //Chèn một chuỗi vào chuỗi nguồn (tính từ trái hoặc phải)
        public static string InsertString(string input, string value, int startIndex, bool rightToLeft)
        {
            if (rightToLeft)
            {
                if (startIndex > input.Length)
                    startIndex = 0;
                else
                    startIndex = input.Length - startIndex;
            }
            else
            {
                if (startIndex > input.Length)
                    startIndex = input.Length;
            }
            return input.Insert(startIndex, value);
        }

        //Chuyen chuoi ve dang Title Case
        public static string ToTitleCase(string str)
        {
            str = str.ToLower();
            Char[] charArr = str.ToCharArray();
            charArr[0] = Char.ToUpper(charArr[0]);
            foreach (Match m in Regex.Matches(str, @"(\s\S)"))
            {
                charArr[m.Index + 1] = m.Value.ToUpper().Trim()[0];
            }
            return new String(charArr);
        }

        public static string Cuts(string str, int n)
        {
            if (str.Length == 0) return str;
            int num = ((n <= str.Length) ? n : str.Length);
            //MessageBox.Show(num.ToString());
            int pos = str.IndexOf(" ", num);
            //MessageBox.Show(pos.ToString());
            if (pos <= 0)
            {
                return str;
            }
            else
            {
                return str.Substring(0, pos) + " ...";
            }
        }
        public static Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }
       
    }
}
