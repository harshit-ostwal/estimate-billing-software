using System;
using System.Threading;
using System.Windows.Forms;

namespace SS_SOFTWARE_ESTIMATE_BILL
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Mutex mutex = new System.Threading.Mutex(false, "SS SOFTWARE");
            if (mutex.WaitOne(0, false))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FRM_ESTIMATE_BILL());
            }
            else
            {
                MessageBox.Show("SS SOFTWARE IS ALREADY RUNNING!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
