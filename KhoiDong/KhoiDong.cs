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
            if(radioOffline.Checked) // Offline
            {
                Offline = true;
            }
            else if (radioLAN.Checked) // LAN
            {
                Offline = false;
                if (radioNewGamePvp.Checked)
                    CoTuongLAN.Cotuong.Banco.Mau_Pheta = 2; //
                else if (radioConnectPvp.Checked)
                    CoTuongLAN.Cotuong.Banco.Mau_Pheta = 1;
                if (tbPlayerName.Text != string.Empty)
                    CoTuongLAN.Cotuong.Banco.Name = tbPlayerName.Text;
                else
                {
                    if (radioNewGamePvp.Checked)
                        CoTuongLAN.Cotuong.Banco.Name = "PlayerRed";
                    else if (radioConnectPvp.Checked)
                        CoTuongLAN.Cotuong.Banco.Name = "PlayerBlue";
                }
            }
            FormResult = DialogResult.Yes;
            this.Close();
        }

        private void radioLAN_CheckedChanged(object sender, EventArgs e) // bật panel tạo phòng, đặt tên
        {
            panel2.Enabled = true;
        }
        private void radioOffline_CheckedChanged(object sender, EventArgs e) // tắt panel tạo phòng, đặt tên
        {
            panel2.Enabled = false;
        }

        private void radioNewGamePvp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
