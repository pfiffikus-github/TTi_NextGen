using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTi_NextGen
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool ok;
            System.Threading.Mutex m = new System.Threading.Mutex(true, Application.ProductName, out ok);

            if (!ok)
            {
                MessageBox.Show(Application.ProductName + " wird bereits ausgeführt...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
