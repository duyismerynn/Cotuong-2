using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoiDong
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new KhoiDong());
            if (KhoiDong.FormResult == DialogResult.Yes)
            {
                if (KhoiDong.Offline)
                    Application.Run(new CoTuongOffline.Cotuong_Off());
                else
                    Application.Run(new CoTuongLAN.Cotuong_LAN());
            }
        }
    }
}
