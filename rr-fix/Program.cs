using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace rr_fix
{
    class Program
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);        

        static void Main(string[] args)
        {
            if (!CheckIfAProcessIsRunning("LegoRR"))
            {
                MessageBox.Show("Please start Lego Rock Raider first !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            try
            {
                //const short SWP_NOMOVE = 0X2;
                const short SWP_NOSIZE = 1;
                const short SWP_NOZORDER = 0X4;
                const int SWP_SHOWWINDOW = 0x0040;
                Process p = Process.GetProcessesByName("LegoRR")[0];
                IntPtr handle = p.MainWindowHandle;
                var form = Control.FromHandle(handle);
                SetWindowPos(handle, 0, -3, -26, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool CheckIfAProcessIsRunning(string processname)
        {
            return Process.GetProcessesByName(processname).Length > 0;
        }
    }
}
