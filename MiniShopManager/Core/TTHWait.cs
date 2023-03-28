using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace MyRMS
{
    public static class TTHWait
    {
        // Thredding.
        private static Thread _waitThread;
        private static frmCho _waitForm;
        private static frmStart2 _startForm;

        // Show the Splash Screen (Loading...)      
        public static void ShowWait()
        {
            if (_waitThread == null)
            {
                // show the form in a new thread            
                _waitThread = new Thread(new ThreadStart(DoShowWait));
                _waitThread.IsBackground = true;
                _waitThread.Start();
            }
        }

        // Called by the thread    
        private static void DoShowWait()
        {
            if (_waitForm == null)
            {
                _waitForm = new frmCho();
                _waitForm.StartPosition = FormStartPosition.CenterScreen;
                _waitForm.TopMost = true;
            }
            // create a new message pump on this thread (started from ShowSplash)        
            Application.Run(_waitForm);
        }


        // Show the Splash Screen (Loading...)      
        public static void ShowStart()
        {
            if (_waitThread == null)
            {
                // show the form in a new thread            
                _waitThread = new Thread(new ThreadStart(DoShowStart));
                _waitThread.IsBackground = true;
                _waitThread.Start();
            }
        }

        // Called by the thread    
        private static void DoShowStart()
        {
            if (_startForm == null)
            {
                _startForm = new frmStart2();
                _startForm.StartPosition = FormStartPosition.CenterScreen;
                _startForm.TopMost = true;
            }
            // create a new message pump on this thread (started from ShowSplash)        
            Application.Run(_startForm);
        }

        // Close the splash (Loading...) screen    
        public static void CloseWait()
        {
            //// Need to call on the thread that launched this splash        
            //if (_waitForm.InvokeRequired)
            //    _waitForm.Invoke(new MethodInvoker(CloseWait));
            //else
            //    Application.ExitThread();
            if (_waitThread != null)
                _waitThread.Abort();
            
        }
    }
}
