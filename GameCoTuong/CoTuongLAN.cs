using CoTuongLAN.Cotuong;
using CoTuongLAN.LAN;
using CoTuongLAN.ProgramConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CoTuongLAN.LAN.SocketData;

namespace CoTuongLAN
{

    public partial class Cotuong_LAN : Form
    {
        private SocketManager socketManager;
        //Chat
        private static int soKT = 30, doDai = 50;

        public Cotuong_LAN()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblName.Text = Banco.Name;
            txbIP.Enabled = (Banco.Mau_Pheta == 1) ? true : false;
            btnLAN.Text = (Banco.Mau_Pheta == 2) ? "Tạo phòng" : "Vào phòng";

            Banco.Ptb_Banco = ptbBanCo;
            Banco.Lbl_PheDuocDanh = lblPheDuocDanh;
            Banco.Lbl_SoLuotDi = lblSoLuotDi;
            Banco.Btn_NewGame = btnNewGame;
            Banco.Btn_Undo = btnUndo;
            Banco.Btn_Surrender = btnSurrender;
            Banco.TimerRemainingTime = timerRemainingTime;
            Banco.Lbl_RemainingTime = lblRemainingTime;
            Banco.Lbl_OpponentRemainingTime = lblOpponentRemainingTime;
            Banco.Btn_Ready = btnReady;
            socketManager = new SocketManager();

            Banco.SetToDefault();
            Banco.Taodiem_Banco(DiemBanCo_Click);
            Banco.Tao_Quanco(QuanCo_Click);
            Banco.Refresh_Banco();
        }

        
        private void QuanCo_Click(object sender, EventArgs e) // chọn quân cờ
        {
            Banco.Quanco_Duocchon = sender as RoundPictureBox;
            Banco.Highlight(ptbBanCo); // hiện khung vàng đánh dấu
            Banco.Hienthi_Diemdich(); // hiển tập điểm đích có thể đến
            Banco.Disable_Banco(); // unable các quân khác
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

        private void DiemBanCo_Click(object sender, EventArgs e) // Chọn một RoundButton điểm bàn cờ (điểm đích) để đi đến, tập điểm đích sẽ hiện khi chọn 1 quân cờ
        {
            if (Banco.Quanco_Duocchon == null) return; // chống lỗi lặp lại
            Banco.Dehighlight(); // ẩn đánh dấu sau khi di chuyển xong
            Banco.An_Diemdich(); // ẩn tập điểm đích sau khi di chuyển xong
            try
            {
                socketManager.Send(new SocketData((int)SocketCommand.TEST_CONNECTION));
            }
            catch
            {
                MessageBox.Show("Mất kết nối với đối thủ.", "Thông báo");
                Banco.Refresh_Banco();
                Banco.Quanco_Duocchon = null;
                return;
            }

            if (Banco.TaDanh(Banco.Quanco_Duocchon.Quanco.Toado, Thongso.TDDV_Cua_Diem(((RoundButton)sender).Location)))
            {
                timerRemainingTime.Stop(); 
                socketManager.Send(new SocketData((int)SocketCommand.SEND_MOVE, string.Empty,
                    new Point(8 - Banco.Toado_Ditruoc.X, 9 - Banco.Toado_Ditruoc.Y), new Point(8 - Banco.Toado_Dentruoc.X, 9 - Banco.Toado_Dentruoc.Y)));
            }
            Listen();
        }
  
        private void btnNewGame_Click(object sender, EventArgs e) // nút cầu hoà
        {
            DialogResult result = MessageBox.Show("Bạn muốn cầu hòa với đối thủ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnNewGame.Enabled = false;
                socketManager.Send(new SocketData((int)SocketCommand.ASK_NEW_GAME));
            }
        }

        private void btnUndo_Click(object sender, EventArgs e) // Nút xin hoàn tác
        {
            DialogResult result = MessageBox.Show("Bạn muốn xin đi lại nước đi vừa rồi?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (btnUndo.Enabled == true)
                {
                    btnUndo.Enabled = false;
                    socketManager.Send(new SocketData((int)SocketCommand.ASK_UNDO));
                }
                else
                {
                    MessageBox.Show("Bạn không còn quyền xin đi lại.", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSurrender_Click(object sender, EventArgs e) // Nút xin đầu hàng
        {
            DialogResult result = MessageBox.Show("Bạn muốn đầu hàng?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnSurrender.Enabled = false;
                socketManager.Send(new SocketData((int)SocketCommand.SURRENDER));
                btnUndo.Enabled = false;
                btnNewGame.Enabled = false;
                if (Banco.Mau_Pheta == 2)
                    btnReady.Enabled = true;
                timerRemainingTime.Stop();
                MessageBox.Show("Bạn đã thua cuộc.", "Kết thúc", MessageBoxButtons.OK);

                
            }
        }

        private void btnLAN_Click(object sender, EventArgs e)
        {
            
            btnLAN.Enabled = false;
            if (Banco.Mau_Pheta == 1)
                btnLAN.Enabled = true;
            socketManager.IP = txbIP.Text;
            if (Banco.Mau_Pheta == 2) // phe đỏ, tức chủ phòng, tạo server để kết nối
            {
                socketManager.isServer = true;
                socketManager.CreateServer();
            }
            else // phe xanh, khách kết nối vào server
            {
                if (socketManager.ConnectToServer())
                {
                    socketManager.isServer = false;
                    socketManager.Send(new SocketData((int)SocketCommand.TEST_CONNECTION));
                    Listen();
                }
            }
        }

        private void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData receivedData = (SocketData)socketManager.Receive();
                    ProcessSocketData(receivedData);
                }
                catch { }
            })
            {
                IsBackground = true
            };
            listenThread.Start();
        }

        private void ProcessSocketData(SocketData data) // xử lí bên đối thủ khi ta thao tác
        {
            switch (data.Command)
            {
                case (int)SocketCommand.SEND_MOVE: 
                    this.Invoke((MethodInvoker)(() =>
                    {
                        timerRemainingTime.Start();
                        Banco.DoithuDanh(data.DepartureLocation, data.DestinationLocation);
                    }));
                    break;
                case (int)SocketCommand.NOTIFY:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        MessageBox.Show(data.Message, "Thông báo", MessageBoxButtons.OK);
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.ASK_NEW_GAME: // cầu hoà
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        timerRemainingTime.Stop();
                        DialogResult resultNewGame = MessageBox.Show("Đối thủ xin hòa, bạn có đồng ý?", "Thông báo", MessageBoxButtons.YesNo);
                        if (resultNewGame == DialogResult.Yes)
                        {
                            btnNewGame.Enabled = false;
                            btnUndo.Enabled = false;
                            btnSurrender.Enabled = false;
                            if (Banco.Mau_Pheta == 2)
                                btnReady.Enabled = true;
                            socketManager.Send(new SocketData((int)SocketCommand.ACCEPT_NEW_GAME));
                            Banco.Disable_Banco();
                        }
                        else if (resultNewGame == DialogResult.No) // từ chối cầu hoà
                        {
                            socketManager.Send(new SocketData((int)SocketCommand.NOTIFY, "Đối thủ từ chối cầu hoà."));
                            if (Banco.PheDuocDanh == Banco.Mau_Pheta)
                                timerRemainingTime.Start();
                        }
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.ACCEPT_NEW_GAME: // chấp nhận cầu hoà
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        if (Banco.Mau_Pheta == 2)
                            btnReady.Enabled = true;
                        btnUndo.Enabled = false;
                        btnSurrender.Enabled = false;
                        MessageBox.Show("Đối thủ chấp nhận hòa.", "Thông báo", MessageBoxButtons.OK);
                        Banco.Disable_Banco();
                        timerRemainingTime.Stop();
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.ASK_UNDO: // xin đi lại
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        timerRemainingTime.Stop();
                        DialogResult resultUndo = MessageBox.Show("Đối thủ xin đi lại nước vừa rồi. Bạn có có đồng ý không?", "Xin đi lại", MessageBoxButtons.YesNo);
                        if (resultUndo == DialogResult.Yes)
                        {
                            socketManager.Send(new SocketData((int)SocketCommand.ACCEPT_UNDO));
                            Banco.Dehighlight();
                            Banco.An_Diemdich();
                            Banco.Hoantac();
                        }
                        else if (resultUndo == DialogResult.No) // từ chối cho đối thủ đi lại 
                        {
                            socketManager.Send(new SocketData((int)SocketCommand.NOTIFY, "Đối thủ không đồng ý cho bạn đi lại."));
                            timerRemainingTime.Start();
                        }
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.ACCEPT_UNDO: // chấp nhận cho đối thủ đi lại
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        Banco.Dehighlight();
                        Banco.An_Diemdich();
                        Banco.Hoantac();
                        MessageBox.Show("Đối thủ đã đồng ý cho bạn đi lại.", "Thông báo", MessageBoxButtons.OK);
                        timerRemainingTime.Start();
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.SURRENDER: // đầu hàng
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        if (Banco.Mau_Pheta == 2)
                            btnReady.Enabled = true;
                        Banco.Disable_Banco();
                        btnSurrender.Enabled = false;
                        btnUndo.Enabled = false;
                        btnNewGame.Enabled = false;
                        timerRemainingTime.Stop();
                        MessageBox.Show("Đối thủ đã đầu hàng", "Thông báo", MessageBoxButtons.OK);
                        
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.EXIT: // thoát trận
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.Enabled = false;
                        MessageBox.Show("Đối thủ đã rời trận", "Thông báo", MessageBoxButtons.OK);
                        panel1.Enabled = false;
                        this.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.CHAT_MESSAGE:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        ThemTinNhanNhan(data.Message);
                    }));
                    break;
                case (int)SocketCommand.TEST_CONNECTION:

                    break;
                case (int)SocketCommand.OUT_OF_TIME: // hết giờ
                    this.Enabled = false;
                    Banco.SetToDefault();
                    Banco.XoaBanCo();
                    Banco.Taodiem_Banco(DiemBanCo_Click);
                    Banco.Tao_Quanco(QuanCo_Click);
                    Banco.Refresh_Banco();
                    MessageBox.Show("Bạn thắng vì đối thủ đã hết giờ", "Thông báo", MessageBoxButtons.OK);
                    this.Enabled = true;
                    break;
                case (int)SocketCommand.READY: // sẵn sàng
                    this.Invoke((MethodInvoker)(() =>
                    {

                        DialogResult result = MessageBox.Show("Sẵn sàng chưa?", "Thông báo", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            panel1.Enabled = true;
                            socketManager.Send(new SocketData((int)SocketCommand.ACCEPT_READY, Banco.Name));
                            Banco.SetToDefault();
                            Banco.XoaBanCo();
                            Banco.Taodiem_Banco(DiemBanCo_Click);
                            Banco.Tao_Quanco(QuanCo_Click);
                            Banco.Refresh_Banco();

                            Banco.OpponentName = data.Message;
                            lblOpponentName.Text = Banco.OpponentName;
                            Banco.Write_PheDuocDanh(lblPheDuocDanh);
                            lblPheDuocDanh.Visible = true;
                            ptbBanCo.Enabled = true;
                            btnLAN.Enabled = false;
                        }
                        else if (result == DialogResult.No)
                        {
                            socketManager.Send(new SocketData((int)SocketCommand.DENY_READY));
                        }

                    }));
                    break;
                case (int)SocketCommand.OPPONENT_TICK:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        lblOpponentRemainingTime.Text = data.Message;
                    }));
                    break;
                case (int)SocketCommand.ACCEPT_READY: // bắt đầu ván đấu sau khi đã sẵn sàng
                    this.Invoke((MethodInvoker)(() =>
                    {
                        Banco.SetToDefault();
                        Banco.XoaBanCo();
                        Banco.Taodiem_Banco(DiemBanCo_Click);
                        Banco.Tao_Quanco(QuanCo_Click);
                        Banco.Refresh_Banco();

                        Banco.OpponentName = data.Message;
                        lblOpponentName.Text = Banco.OpponentName;
                        Banco.Write_PheDuocDanh(lblPheDuocDanh);
                        lblPheDuocDanh.Visible = true;
                        ptbBanCo.Enabled = true;
                        timerRemainingTime.Start();
                        btnReady.Enabled = false;
                    }));
                    break;
                case (int)SocketCommand.DENY_READY:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        btnReady.Enabled = true;
                    }));
                    break;
            }
            Listen();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txbIP.Text = socketManager.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txbIP.Text))
            {
                txbIP.Text = socketManager.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // thông báo khi đóng form
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (result == DialogResult.Yes)
            {
                try
                {
                    socketManager.Send(new SocketData((int)SocketCommand.EXIT));
                }
                catch { }
            }
        }

        #region Trò chuyện
        private int TimDauCach(string str, int soKyTu)
        {
            for (int i = soKyTu; i > 0; i--)
            {
                if (str[i] == ' ') return i;
            }
            return soKyTu;
        }
        private string LayDoanSau(string str, int soKyTu)
        {
            string str1 = "";
            for (int i = soKyTu; i < str.Length; i++)
                str1 += str[i];
            return str1;
        }
        private string ThemCachTruoc(string str, int doDai)
        {
            while (str.Length < doDai)
                str = str.Insert(0, " ");
            return str;
        }
        private string ThemCachSau(string str, int so)
        {
            while (str.Length < so)
                str = str.Insert(str.Length, " ");
            return str;
        }

        private void ThemTinNhanNhan(string str)
        {
            while (str.Length > soKT)
            {
                string str1 = "";
                int viTriDauCach = TimDauCach(str, soKT);
                for (int i = 0; i < viTriDauCach; i++)
                {
                    str1 += str[i];
                }
                str1 = str1.Trim();
                lsvMessage.Items.Add(new ListViewItem() { Text = Banco.OpponentName + ":  " + str1 });
                lsvMessage.Items[lsvMessage.Items.Count - 1].ForeColor = Color.Blue;

                str = LayDoanSau(str, soKT);
            }
            if (str.Length < soKT)
            {
                str = str.Trim();
                lsvMessage.Items.Add(new ListViewItem() { Text = Banco.OpponentName + ": " + str });
                lsvMessage.Items[lsvMessage.Items.Count - 1].ForeColor = Color.Blue;

            }
        }
        private void ThemTinNhanGui(string str)
        {
            if (str.Length < soKT)
            {
                str = str.Trim();
                str = ThemCachTruoc(str, doDai);
                lsvMessage.Items.Add(new ListViewItem() { Text = str });
            }
            else
            {
                while (str.Length > soKT)
                {
                    string str1 = "";
                    int viTriDauCach = TimDauCach(str, soKT);
                    for (int i = 0; i < viTriDauCach; i++)
                    {
                        str1 += str[i];
                    }
                    str1 = str1.Trim();
                    str1 = ThemCachSau(str1, soKT);
                    str1 = ThemCachTruoc(str1, doDai);
                    lsvMessage.Items.Add(new ListViewItem() { Text = str1 });

                    str = LayDoanSau(str, soKT);
                }
                if (str.Length < soKT)
                {
                    str = str.Trim();
                    str = ThemCachSau(str, soKT);
                    str = ThemCachTruoc(str, doDai);
                    lsvMessage.Items.Add(new ListViewItem() { Text = str });
                }
            }
        }
        #endregion

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (txtChat.Text != string.Empty)
            {
                ThemTinNhanGui(txtChat.Text);
                try
                {
                    socketManager.Send(new SocketData((int)SocketCommand.CHAT_MESSAGE, txtChat.Text));
                }
                catch
                {
                    lsvMessage.Items.Add(new ListViewItem() { Text = "Không thể gửi", ForeColor = Color.Red });
                }
                txtChat.Clear();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtChat.Focused && e.KeyCode == Keys.Enter)
            {
                btnGui_Click(sender, e);
            }
        }

        private void RemainingTime_Tick(object sender, EventArgs e)
        {
            Banco.RemainingTime--;
            lblRemainingTime.Text = Banco.s_to_ms(Banco.RemainingTime);
            socketManager.Send(new SocketData((int)SocketCommand.OPPONENT_TICK, lblRemainingTime.Text));
                lblRemainingTime.ForeColor = Color.Black;
            if (Banco.RemainingTime == 0) // hết giờ
            {
                timerRemainingTime.Stop();
                socketManager.Send(new SocketData((int)SocketCommand.OUT_OF_TIME));
                Banco.SetToDefault();
                Banco.XoaBanCo();
                Banco.Taodiem_Banco(DiemBanCo_Click);
                Banco.Tao_Quanco(QuanCo_Click);
                Banco.Refresh_Banco();
                MessageBox.Show("Bạn đã thua vì hết giờ.", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            btnReady.Enabled = false;
            try
            {
                socketManager.Send(new SocketData((int)SocketCommand.READY, Banco.Name));
                Listen();
            }
            catch
            {
                MessageBox.Show("Mất kết nối với đối thủ.");
                btnReady.Enabled = true;
            }
           
        }
    }
}