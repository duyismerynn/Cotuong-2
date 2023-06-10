using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhoiDong
{
    public partial class KhoiDong : Form
    {
        public static bool Offline { get; private set; }

        public static DialogResult FormResult { get; private set; }

        public KhoiDong()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if(radioOffline.Checked)
            {
                Offline = true;
            }
            else if (radioLAN.Checked)
            {
                Offline = false;
                if (radioNewGamePvp.Checked)
                {
                    CoTuongLAN.CoTuong.BanCo.PheTa = 2;
                }
                else if (radioConnectPvp.Checked)
                {
                    CoTuongLAN.CoTuong.BanCo.PheTa = 1;
                }
                if (tbPlayerName.Text != string.Empty)
                    CoTuongLAN.CoTuong.BanCo.Name = tbPlayerName.Text;
                else
                {
                    if (radioNewGamePvp.Checked)
                        CoTuongLAN.CoTuong.BanCo.Name = "PlayerRed";
                    else if (radioConnectPvp.Checked)
                        CoTuongLAN.CoTuong.BanCo.Name = "PlayerBlue";
                }
            }
            FormResult = DialogResult.Yes;
            this.Close();
        }

        private void radioLAN_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = true;
        }
    }
}
