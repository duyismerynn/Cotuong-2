using CoTuongOffline.Cotuong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CoTuongOffline
{
    public partial class Cotuong_Off : Form
    {
        public Cotuong_Off()
        {
            InitializeComponent();
        }

        private void CoTuongOffline_Load(object sender, EventArgs e)
        {

            Banco.SetToDefault(lblPheDuocDanh, lblSoLuotDi, btnNewGame, btnUndo);
            Banco.Taodiem_Banco(ptbBanCo, DiemBanCo_Click);
            Banco.Tao_Quanco(QuanCo_Click, ptbBanCo);
            Banco.Refresh_Banco();
        }
        
        private void QuanCo_Click(object sender, EventArgs e) // chọn quân cờ
        {
            Banco.Quanco_Duocchon = sender as ProgramConfig.RoundPictureBox;
            Banco.Highlight(ptbBanCo); // hiện khung vàng đánh dấu
            Banco.Hienthi_Diemdich(); // hiển tập điểm đích có thể đến
            foreach (ProgramConfig.RoundPictureBox element in Banco.Alive_RoundPictureBox) // không thể chọn quân khác khi đang chọn 1 quân
                element.Enabled = false;
        }

        private void ptbBanCo_Click(object sender, EventArgs e) // khi đang chọn 1 quân, huỷ bằng chọn vị trí bất kỳ khác trên bàn cờ
        {
            if (Banco.Quanco_Duocchon != null)
            {
                Banco.Dehighlight(); // ẩn khung vàng
                Banco.An_Diemdich(); // ẩn tập điểm đích
                Banco.Refresh_Banco();
                Banco.Quanco_Duocchon = null;
            }
        }
        
        private void DiemBanCo_Click(object sender, EventArgs e)  // chọn điểm đích để di chuyển
        {
            if (Banco.Quanco_Duocchon == null) return; // chống lỗi lặp lại
            Banco.Dehighlight(); // ẩn đánh dấu sau khi di chuyển xong
            Banco.An_Diemdich(); // ẩn tập điểm đích sau khi di chuyển xong

            Point departure = new Point(Banco.Quanco_Duocchon.Quanco.Toado.X, Banco.Quanco_Duocchon.Quanco.Toado.Y); // toạ độ ban đầu
            Point destination = ProgramConfig.Thongso.TDDV_Cua_Diem(((ProgramConfig.RoundButton)sender).Location); // toạ độ đích

            Banco.Loaibo_Quanco(destination, ptbBanCo); // ăn quân cờ (nếu có) 
            Banco.Quanco_Duocchon.DiChuyen(destination); // di chuyển tới vị trí đích

            if (Banco.Chongtuong()) // chống tướng, ngăn chặn nước đi
            {
                MessageBox.Show("Chống tướng", "Cảnh báo");
                Banco.Quanco_Duocchon.DiChuyen(departure);
                Banco.Quanco_Duocchon = null;
                Banco.TraLaiQuanCo(ptbBanCo, Banco.Quanco_Biloai);
                Banco.Refresh_Banco();
                return;
            }
            if (Banco.Chieutuong(Banco.PheDoiThu())) // cảnh báo đã bị chiếu, ngăn chặn nước đi
            {
                MessageBox.Show("Bạn sẽ thua nếu đi nước này", "Cảnh báo");
                Banco.Quanco_Duocchon.DiChuyen(departure); 
                Banco.Quanco_Duocchon = null;
                Banco.TraLaiQuanCo(ptbBanCo, Banco.Quanco_Biloai);
                Banco.Refresh_Banco();
                return;
            }
            if (Banco.Chieutuong(Banco.PheDuocdanh)) // cảnh báo chiếu tướng cho địch
            {
                if (Banco.PheDoiThu() == 1)
                    MessageBox.Show("Chiếu tướng", "Cảnh báo");
                else
                    MessageBox.Show("Chiếu tướng", "Cảnh báo");
            }
            Banco.Hienthi_Nuocdi(departure, destination, ptbBanCo); // hiển thị
            Banco.Luu_Nuocdi(departure, destination); // lưu nước đi
            Banco.Doiphe(lblPheDuocDanh, lblSoLuotDi, btnNewGame, btnUndo); // đổi phe đánh
        }

        private void btnNewGame_Click(object sender, EventArgs e) // Game mới
        {
            DialogResult result = MessageBox.Show("Bạn muốn bắt đầu một ván mới?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Banco.SetToDefault(lblPheDuocDanh, lblSoLuotDi, btnNewGame, btnUndo);
                Banco.XoaBanCo(ptbBanCo);
                Banco.Taodiem_Banco(ptbBanCo, DiemBanCo_Click);
                Banco.Tao_Quanco(QuanCo_Click, ptbBanCo);
                Banco.Refresh_Banco();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e) // Hoàn tác nước đi
        {
            DialogResult result = MessageBox.Show("Bạn muốn đi lại?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnUndo.Enabled = false; // không được hoàn tác liên tiếp quá 1 lần
                Banco.Dehighlight();
                Banco.An_Diemdich();
                Banco.Hoantac(ptbBanCo);
                Banco.Doiphe_Undo(lblPheDuocDanh, lblSoLuotDi, btnNewGame);
                Banco.Hienthi_Nuocdi_Truoc(ptbBanCo);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
