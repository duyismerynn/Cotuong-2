using CoTuongLAN.LAN;
using CoTuongLAN.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTuongLAN.Cotuong
{
    public static class Banco
    {
        #region properties

        public static int Mau_Pheta { get; set; } // màu của phe ta (đỏ)
        public static string Name { get; set; } = ""; // tên 
        public static string OpponentName { get; set; } = ""; // tên đối thủ

        public static Color Mau_Phedo { get { return Color.Red; } }

        public static Color Mau_Phexanh { get { return Color.DarkGreen; } }

        #region Nước đi trước
        public static Point Vitri_GreyTargetDeparture_Truoc { get; set; } = Thongso.Toado_NULL;
        public static Point Vitri_GreyTargetDestination_Truoc { get; set; } = Thongso.Toado_NULL;
        public static Point Toado_Ditruoc { get; set; } = Thongso.Toado_NULL;
        public static Point Toado_Dentruoc { get; set; } = Thongso.Toado_NULL;
        public static RoundPictureBox Quanco_Dichuyen_Truoc { get; set; } = null;
        public static RoundPictureBox Quanco_Biloai_Truoc { get; set; } = null;
        #endregion

        // Đối tượng Quanco: quân cờ trừu tượng

        public static List<Quanco> Alive_Quanco { get; set; } = new List<Quanco>();

        public static Tuong Tuongxanh { get; set; } = null;

        public static Tuong Tuongdo { get; set; } = null;

        // Đối tượng RoundButton: điểm trên bàn cờ

        public static RoundButton[,] Diem_Banco { get; set; } = new RoundButton[9, 10]; // Mảng 2 chiều chứa 9x10=90 điểm bàn cờ

        // Đối tượng RoundPictureBox: quân cờ trực quan

        public static List<RoundPictureBox> Alive_RoundPictureBox { get; set; } = new List<RoundPictureBox>(); // Danh sách quân cờ còn sống

        public static RoundPictureBox Quanco_Duocchon { get; set; } // quân cờ được chọn

        public static RoundPictureBox Quanco_Biloai { get; set; } // quân cờ vừa bị loại ở nước đi trước đó, nếu di chuyển thành công thì gán lại về null

        public static int PheDuocDanh { get; private set; } // Phe hiện tại đang được đánh 1 xanh/2 đỏ

        public static int So_luotdi { get; private set; } // Thống kê số lượt đã đi

        #region Controls
        public static PictureBox Ptb_Banco { get; set; }
        public static Label Lbl_PheDuocDanh { get; set; }
        public static Label Lbl_SoLuotDi { get; set; }
        public static Button Btn_NewGame { get; set; }
        public static Button Btn_Undo { get; set; }
        public static Button Btn_Surrender { get; set; }
        public static Timer TimerRemainingTime { get; set; }
        public static Label Lbl_RemainingTime { get; set; }
        public static Label Lbl_OpponentRemainingTime { get; set; }
        public static Button Btn_Ready { get; set; }
        #endregion

        #region Đánh dấu
        public static PictureBox YellowTarget { get; set; } = new PictureBox() // Khung vàng - Đánh dấu quân cờ đang được chọn
        {
            Width = 58,
            Height = 58,
            BackColor = Color.Transparent,
            Image = Properties.Resources.yellow_square_target,
            Location = Thongso.Toado_NULL
        };
        public static PictureBox GreyTargetDeparture { get; set; } = new PictureBox() // Khung xám nhỏ - Đánh dấu vị trí cũ của quân cờ sau nước đi vừa rồi
        {
            Width = 36,
            Height = 36,
            BackColor = Color.Transparent,
            Image = CoTuongLAN.Properties.Resources.grey_square_target_depart,
            Location = Thongso.Toado_NULL
        };
        public static PictureBox GreyTargetDestination { get; set; } = new PictureBox() // Khung xám to - Đánh dấu vị trí mới của quân cờ sau nước đi vừa rồi
        {
            Width = 58,
            Height = 58,
            BackColor = Color.Transparent,
            Image = CoTuongLAN.Properties.Resources.grey_square_target_dest,
            Location = Thongso.Toado_NULL
        };
        #endregion

        public static int RemainingTime { get; set; } = 1200; // thời gian suy nghĩ và đánh mỗi bên là 1200 giây (20 phút)

        #endregion

        #region methods
        // đối tượng Quanco

        public static bool Ktra_Quanco_taivitri(Point vitri) // Kiểm tra ở vị trí có quân cờ không?
        {
            return Alive_Quanco.Find(element => element.Toado == vitri) != null;
        }

        public static Quanco Get_Quanco(Point vitri) // tìm quân cờ tại vị trí
        {
            return Alive_Quanco.Find(element => element.Toado == vitri);
        }


        // Đối tượng RoundPictureBox
        // Tạo 90 RoundButton điểm bàn cờ nhưng chưa hiển thị
        public static void Taodiem_Banco(EventHandler Diembanco_Click)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Diem_Banco[x, y] = new RoundButton()
                    {
                        Text = "",
                        Width = Thongso.Duongkinh_Diem,
                        Height = Thongso.Duongkinh_Diem,
                        BackColor = Color.Yellow,
                        Location = Thongso.TDBC_Cua_Diem(x, y),
                        Visible = false // Ẩn sau khi tạo
                    };
                    Diem_Banco[x, y].Click += Diembanco_Click;
                    Ptb_Banco.Controls.Add(Diem_Banco[x, y]);
                }
            }
        }

        // Tạo 32 RoundPictureBox quân cờ và đưa chúng vào danh sách
        public static void Tao_Quanco(EventHandler Quanco_Click)
        {
            if (Mau_Pheta == 2) // phe ta là đỏ
            {
                // Xanh

                // Tướng
                RoundPictureBox tuongxanh = new RoundPictureBox(Bandau_Phedo.Toado_Tuongxanh);
                tuongxanh.Image = CoTuongLAN.Properties.Resources.TuongXanh;
               
                Alive_RoundPictureBox.Add(tuongxanh);

                // Xe
                RoundPictureBox xexanh_1 = new RoundPictureBox(Bandau_Phedo.Toado_Xexanh_1);
                xexanh_1.Image = CoTuongLAN.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xexanh_1);

                RoundPictureBox xexanh_2 = new RoundPictureBox(Bandau_Phedo.Toado_Xexanh_2);
                xexanh_2.Image = CoTuongLAN.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xexanh_2);

                // Mã
                RoundPictureBox maxanh_1 = new RoundPictureBox(Bandau_Phedo.Toado_Maxanh_1);
                maxanh_1.Image = CoTuongLAN.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maxanh_1);

                RoundPictureBox maxanh_2 = new RoundPictureBox(Bandau_Phedo.Toado_Maxanh_2);
                maxanh_2.Image = CoTuongLAN.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maxanh_2);

                // Tịnh
                RoundPictureBox tinhxanh_1 = new RoundPictureBox(Bandau_Phedo.Toado_Tinhxanh_1);
                tinhxanh_1.Image = CoTuongLAN.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhxanh_1);

                RoundPictureBox tinhxanh_2 = new RoundPictureBox(Bandau_Phedo.Toado_Tinhxanh_2);
                tinhxanh_2.Image = CoTuongLAN.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhxanh_2);

                // Sĩ
                RoundPictureBox sixanh_1 = new RoundPictureBox(Bandau_Phedo.Toado_Sixanh_1);
                sixanh_1.Image = CoTuongLAN.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(sixanh_1);

                RoundPictureBox sixanh_2 = new RoundPictureBox(Bandau_Phedo.Toado_Sixanh_2);
                sixanh_2.Image = CoTuongLAN.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(sixanh_2);

                // Pháo
                RoundPictureBox phaoxanh_1 = new RoundPictureBox(Bandau_Phedo.Toado_Phaoxanh_1);
                phaoxanh_1.Image = CoTuongLAN.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoxanh_1);

                RoundPictureBox phaoxanh_2 = new RoundPictureBox(Bandau_Phedo.Toado_Phaoxanh_2);
                phaoxanh_2.Image = CoTuongLAN.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoxanh_2);

                // Tốt
                RoundPictureBox totxanh_1 = new RoundPictureBox(Bandau_Phedo.Toado_Totxanh_1);
                totxanh_1.Image = CoTuongLAN.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_1);

                RoundPictureBox totxanh_2 = new RoundPictureBox(Bandau_Phedo.Toado_Totxanh_2);
                totxanh_2.Image = CoTuongLAN.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_2);

                RoundPictureBox totxanh_3 = new RoundPictureBox(Bandau_Phedo.Toado_Totxanh_3);
                totxanh_3.Image = CoTuongLAN.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_3);

                RoundPictureBox totxanh_4 = new RoundPictureBox(Bandau_Phedo.Toado_Totxanh_4);
                totxanh_4.Image = CoTuongLAN.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_4);

                RoundPictureBox totxanh_5 = new RoundPictureBox(Bandau_Phedo.Toado_Totxanh_5);
                totxanh_5.Image = CoTuongLAN.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_5);

                // Đỏ

                // Tướng
                RoundPictureBox tuongdo = new RoundPictureBox(Bandau_Phedo.Toado_Tuongdo);
                tuongdo.Image = CoTuongLAN.Properties.Resources.TuongDo;
                Alive_RoundPictureBox.Add(tuongdo);

                // Xe
                RoundPictureBox xedo_1 = new RoundPictureBox(Bandau_Phedo.Toado_Xedo_1);
                xedo_1.Image = CoTuongLAN.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xedo_1);

                RoundPictureBox xedo_2 = new RoundPictureBox(Bandau_Phedo.Toado_Xedo_2);
                xedo_2.Image = CoTuongLAN.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xedo_2);

                // Mã
                RoundPictureBox mado_1 = new RoundPictureBox(Bandau_Phedo.Toado_Mado_1);
                mado_1.Image = CoTuongLAN.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(mado_1);

                RoundPictureBox mado_2 = new RoundPictureBox(Bandau_Phedo.Toado_Mado_2);
                mado_2.Image = CoTuongLAN.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(mado_2);

                // Tịnh
                RoundPictureBox tinhdo_1 = new RoundPictureBox(Bandau_Phedo.Toado_Tinhdo_1);
                tinhdo_1.Image = CoTuongLAN.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhdo_1);

                RoundPictureBox tinhdo_2 = new RoundPictureBox(Bandau_Phedo.Toado_Tinhdo_2);
                tinhdo_2.Image = CoTuongLAN.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhdo_2);

                // Sĩ
                RoundPictureBox sido_1 = new RoundPictureBox(Bandau_Phedo.Toado_Sido_1);
                sido_1.Image = CoTuongLAN.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(sido_1);

                RoundPictureBox sido_2 = new RoundPictureBox(Bandau_Phedo.Toado_Sido_2);
                sido_2.Image = CoTuongLAN.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(sido_2);

                // Pháo
                RoundPictureBox phaodo_1 = new RoundPictureBox(Bandau_Phedo.Toado_Phaodo_1);
                phaodo_1.Image = CoTuongLAN.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaodo_1);

                RoundPictureBox phaodo_2 = new RoundPictureBox(Bandau_Phedo.Toado_Phaodo_2);
                phaodo_2.Image = CoTuongLAN.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaodo_2);

                // Tốt
                RoundPictureBox totdo_1 = new RoundPictureBox(Bandau_Phedo.Toado_Totdo_1);
                totdo_1.Image = CoTuongLAN.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_1);

                RoundPictureBox totdo_2 = new RoundPictureBox(Bandau_Phedo.Toado_Totdo_2);
                totdo_2.Image = CoTuongLAN.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_2);

                RoundPictureBox totdo_3 = new RoundPictureBox(Bandau_Phedo.Toado_Totdo_3);
                totdo_3.Image = CoTuongLAN.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_3);

                RoundPictureBox totdo_4 = new RoundPictureBox(Bandau_Phedo.Toado_Totdo_4);
                totdo_4.Image = CoTuongLAN.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_4);

                RoundPictureBox totdo_5 = new RoundPictureBox(Bandau_Phedo.Toado_Totdo_5);
                totdo_5.Image = CoTuongLAN.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_5);
            }
            else if (Mau_Pheta == 1) // phe ta là xanh
            {
                // Tướng
                RoundPictureBox tuongxanh = new RoundPictureBox(Bandau_Phexanh.Toado_Tuongxanh);
                tuongxanh.Image = CoTuongLAN.Properties.Resources.TuongXanh;
                Alive_RoundPictureBox.Add(tuongxanh);

                // Xe
                RoundPictureBox xexanh_1 = new RoundPictureBox(Bandau_Phexanh.Toado_Xexanh_1);
                xexanh_1.Image = CoTuongLAN.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xexanh_1);

                RoundPictureBox xexanh_2 = new RoundPictureBox(Bandau_Phexanh.Toado_Xexanh_2);
                xexanh_2.Image = CoTuongLAN.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xexanh_2);

                // Mã
                RoundPictureBox maxanh_1 = new RoundPictureBox(Bandau_Phexanh.Toado_Maxanh_1);
                maxanh_1.Image = CoTuongLAN.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maxanh_1);

                RoundPictureBox maxanh_2 = new RoundPictureBox(Bandau_Phexanh.Toado_Maxanh_2);
                maxanh_2.Image = CoTuongLAN.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maxanh_2);

                // Tịnh
                RoundPictureBox tinhxanh_1 = new RoundPictureBox(Bandau_Phexanh.Toado_Tinhxanh_1);
                tinhxanh_1.Image = CoTuongLAN.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhxanh_1);

                RoundPictureBox tinhxanh_2 = new RoundPictureBox(Bandau_Phexanh.Toado_Tinhxanh_2);
                tinhxanh_2.Image = CoTuongLAN.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhxanh_2);

                // Sĩ
                RoundPictureBox sixanh_1 = new RoundPictureBox(Bandau_Phexanh.Toado_Sixanh_1);
                sixanh_1.Image = CoTuongLAN.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(sixanh_1);

                RoundPictureBox sixanh_2 = new RoundPictureBox(Bandau_Phexanh.Toado_Sixanh_2);
                sixanh_2.Image = CoTuongLAN.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(sixanh_2);

                // Pháo
                RoundPictureBox phaoxanh_1 = new RoundPictureBox(Bandau_Phexanh.Toado_Phaoxanh_1);
                phaoxanh_1.Image = CoTuongLAN.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoxanh_1);

                RoundPictureBox phaoxanh_2 = new RoundPictureBox(Bandau_Phexanh.Toado_Phaoxanh_2);
                phaoxanh_2.Image = CoTuongLAN.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoxanh_2);

                // Tốt
                RoundPictureBox totxanh_1 = new RoundPictureBox(Bandau_Phexanh.Toado_Totxanh_1);
                totxanh_1.Image = CoTuongLAN.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_1);

                RoundPictureBox totxanh_2 = new RoundPictureBox(Bandau_Phexanh.Toado_Totxanh_2);
                totxanh_2.Image = CoTuongLAN.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_2);

                RoundPictureBox totxanh_3 = new RoundPictureBox(Bandau_Phexanh.Toado_Totxanh_3);
                totxanh_3.Image = CoTuongLAN.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_3);

                RoundPictureBox totxanh_4 = new RoundPictureBox(Bandau_Phexanh.Toado_Totxanh_4);
                totxanh_4.Image = CoTuongLAN.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_4);

                RoundPictureBox totxanh_5 = new RoundPictureBox(Bandau_Phexanh.Toado_Totxanh_5);
                totxanh_5.Image = CoTuongLAN.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_5);

                // Đỏ

                // Tướng
                RoundPictureBox tuongdo = new RoundPictureBox(Bandau_Phexanh.Toado_Tuongdo);
                tuongdo.Image = CoTuongLAN.Properties.Resources.TuongDo;
                Alive_RoundPictureBox.Add(tuongdo);

                // Xe
                RoundPictureBox xedo_1 = new RoundPictureBox(Bandau_Phexanh.Toado_Xedo_1);
                xedo_1.Image = CoTuongLAN.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xedo_1);

                RoundPictureBox xedo_2 = new RoundPictureBox(Bandau_Phexanh.Toado_Xedo_2);
                xedo_2.Image = CoTuongLAN.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xedo_2);

                // Mã
                RoundPictureBox mado_1 = new RoundPictureBox(Bandau_Phexanh.Toado_Mado_1);
                mado_1.Image = CoTuongLAN.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(mado_1);

                RoundPictureBox mado_2 = new RoundPictureBox(Bandau_Phexanh.Toado_Mado_2);
                mado_2.Image = CoTuongLAN.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(mado_2);

                // Tịnh
                RoundPictureBox tinhdo_1 = new RoundPictureBox(Bandau_Phexanh.Toado_Tinhdo_1);
                tinhdo_1.Image = CoTuongLAN.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhdo_1);

                RoundPictureBox tinhdo_2 = new RoundPictureBox(Bandau_Phexanh.Toado_Tinhdo_2);
                tinhdo_2.Image = CoTuongLAN.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhdo_2);

                // Sĩ
                RoundPictureBox sido_1 = new RoundPictureBox(Bandau_Phexanh.Toado_Sido_1);
                sido_1.Image = CoTuongLAN.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(sido_1);

                RoundPictureBox sido_2 = new RoundPictureBox(Bandau_Phexanh.Toado_Sido_2);
                sido_2.Image = CoTuongLAN.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(sido_2);

                // Pháo
                RoundPictureBox phaodo_1 = new RoundPictureBox(Bandau_Phexanh.Toado_Phaodo_1);
                phaodo_1.Image = CoTuongLAN.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaodo_1);

                RoundPictureBox phaodo_2 = new RoundPictureBox(Bandau_Phexanh.Toado_Phaodo_2);
                phaodo_2.Image = CoTuongLAN.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaodo_2);

                // Tốt
                RoundPictureBox totdo_1 = new RoundPictureBox(Bandau_Phexanh.Toado_Totdo_1);
                totdo_1.Image = CoTuongLAN.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_1);

                RoundPictureBox totdo_2 = new RoundPictureBox(Bandau_Phexanh.Toado_Totdo_2);
                totdo_2.Image = CoTuongLAN.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_2);

                RoundPictureBox totdo_3 = new RoundPictureBox(Bandau_Phexanh.Toado_Totdo_3);
                totdo_3.Image = CoTuongLAN.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_3);

                RoundPictureBox totdo_4 = new RoundPictureBox(Bandau_Phexanh.Toado_Totdo_4);
                totdo_4.Image = CoTuongLAN.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_4);

                RoundPictureBox totdo_5 = new RoundPictureBox(Bandau_Phexanh.Toado_Totdo_5);
                totdo_5.Image = CoTuongLAN.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_5);
            }
            foreach (RoundPictureBox element in Alive_RoundPictureBox) // Gán cho mỗi RoundPictureBox quân cờ 1 sự kiện click và xếp lên bàn cờ
            {
                element.Click += Quanco_Click;
                Ptb_Banco.Controls.Add(element);
            }
        }

        public static void Refresh_Banco() // refresh bàn cờ
        {
            if (PheDuocDanh == Mau_Pheta)
            {
                foreach (RoundPictureBox element in Alive_RoundPictureBox)
                {
                    if (element.Quanco.Mau == Mau_Pheta)
                        element.Enabled = true;
                    else
                        element.Enabled = false;
                    element.BringToFront();
                }
            }
            else
            {
                foreach (RoundPictureBox element in Alive_RoundPictureBox)
                {
                    element.Enabled = false;
                    element.BringToFront();
                }
            }
        }

        public static void Write_PheDuocDanh(Label lbl_PheDuocDanh)
        {
            if (PheDuocDanh == 2)
                lbl_PheDuocDanh.ForeColor = Mau_Phedo;
            else lbl_PheDuocDanh.ForeColor = Mau_Phexanh;
            if (PheDuocDanh == Mau_Pheta)
                lbl_PheDuocDanh.Text = "Lượt đi của " + Name;
            else lbl_PheDuocDanh.Text = "Lượt đi của " + OpponentName;
        }
        
        public static void SetToDefault() // Bàn cờ về mặc định
        {
            TimerRemainingTime.Stop();
            Ptb_Banco.Enabled = false;

            Quanco_Biloai = null;
            Quanco_Duocchon = null;
            PheDuocDanh = 2; // phe đỏ đi trước
            So_luotdi = 0;

            Write_PheDuocDanh(Lbl_PheDuocDanh);
            Lbl_SoLuotDi.Text = So_luotdi.ToString();
            Btn_NewGame.Enabled = false;
            Btn_Undo.Enabled = false;
            Btn_Surrender.Enabled = false;

            RemainingTime = 1200; // thời gian suy nghĩ mỗi người là 20 phút
            Lbl_RemainingTime.Text = s_to_ms(RemainingTime);
            Lbl_OpponentRemainingTime.Text = Lbl_RemainingTime.Text;
            if (Mau_Pheta == 2)
                Btn_Ready.Enabled = true;
            else
                Btn_Ready.Enabled = false;
        }

        public static void XoaBanCo() // Xóa các RoundPictureBox quân cờ khỏi bàn cờ và danh sách
        {
            Ptb_Banco.Controls.Clear();
            Tuongxanh = null;
            Tuongdo = null;
            Alive_Quanco.Clear();
            Alive_RoundPictureBox.Clear();
            Vitri_GreyTargetDeparture_Truoc = Thongso.Toado_NULL;
            Vitri_GreyTargetDestination_Truoc = Thongso.Toado_NULL;
            Toado_Ditruoc = Thongso.Toado_NULL;
            Toado_Dentruoc = Thongso.Toado_NULL;
            Quanco_Dichuyen_Truoc = null;
            Quanco_Biloai_Truoc = null;
        }

        public static void Highlight(PictureBox ptb_BanCo)
        {
            YellowTarget.Location = new Point(Quanco_Duocchon.Location.X - 1, Quanco_Duocchon.Location.Y - 1);
            YellowTarget.Parent = ptb_BanCo;
        }

        public static void Dehighlight()
        {
            YellowTarget.Parent = null;
        }
       
        public static void Hienthi_Diemdich() // Hiển thị tập hợp điểm đích
        {
            Quanco_Duocchon.Quanco.Danhsach_Diemdich.Clear();
            Quanco_Duocchon.Quanco.Tinh_Nuocdi();
            foreach (Point element in Quanco_Duocchon.Quanco.Danhsach_Diemdich)
            {
                Quanco target = Alive_Quanco.Find(element1 => element1.Mau != Quanco_Duocchon.Quanco.Mau && element1.Toado == element);
                if (target != null)
                    Diem_Banco[element.X, element.Y].BackColor = Color.Red;
                Diem_Banco[element.X, element.Y].Visible = true;
                Diem_Banco[element.X, element.Y].BringToFront();
            }
        }

        public static void An_Diemdich() // Ẩn tập hợp điểm đích
        {
            foreach (RoundButton element in Diem_Banco)
            {
                element.Visible = false;
                element.BackColor = Color.Yellow;
            }
        }

        public static void Loaibo_Quanco(Point vitri, PictureBox ptb_Banco)
        {
            Quanco_Biloai = Alive_RoundPictureBox.Find(element => element.Quanco.Mau != PheDuocDanh && element.Quanco.Toado == vitri);
            if (Quanco_Biloai != null)
            {
                ptb_Banco.Controls.Remove(Quanco_Biloai);
                Alive_RoundPictureBox.Remove(Quanco_Biloai);
                Alive_Quanco.Remove(Quanco_Biloai.Quanco);
            }
        }

        public static void Tralai_Quanco(RoundPictureBox quanco_Cantralai, PictureBox ptb_Banco) // Trả lại quân cờ bị loại
        {
            if (quanco_Cantralai != null)
            {
                Alive_Quanco.Add(quanco_Cantralai.Quanco);
                Alive_RoundPictureBox.Add(quanco_Cantralai);
                ptb_Banco.Controls.Add(quanco_Cantralai);
            }
        }

        public static int PheDoithu(int phe) // trả về xanh nếu là đỏ, đỏ nếu là xanh
        {
            if (phe == 1)
                return 2;
            return 1;
        }

        public static bool Chongtuong() //Chống tướng: 2 tướng không được đối mặt
        {
            if (Tuongxanh.Toado.X == Tuongdo.Toado.X) // xét trường hợp 2 quân tướng cùng 1 hàng dọc
            {
                int X = Tuongxanh.Toado.X;
                if (Mau_Pheta == 2)
                {
                    for (int Y = Tuongxanh.Toado.Y + 1; Y < Tuongdo.Toado.Y; Y++) // xét giữa 2 tướng có quân nào không
                    {
                        Point diem_Giua2tuong = new Point(X, Y);
                        if (Ktra_Quanco_taivitri(diem_Giua2tuong))
                            return false;
                    }
                    return true;
                }
                else if (Mau_Pheta == 1)
                {
                    for (int Y = Tuongxanh.Toado.Y - 1; Y > Tuongdo.Toado.Y; Y--) // xét giữa 2 tướng có quân nào không
                    {
                        Point diem_Giua2tuong = new Point(X, Y);
                        if (Ktra_Quanco_taivitri(diem_Giua2tuong))
                            return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public static bool Chieutuong(int phechieu) // Chiếu
        {
            foreach (Quanco element in Alive_Quanco)
            {
                if (element.Mau == phechieu)
                {
                    element.Danhsach_Diemdich.Clear();
                    element.Tinh_Nuocdi();
                    foreach (Point element1 in element.Danhsach_Diemdich)
                    {
                        Quanco target = Alive_Quanco.Find(element2 => element2.Mau != phechieu && element2.Toado == element1);
                        if (target != null && (target == Tuongxanh || target == Tuongdo))
                            return true;
                    }
                }
            }
            return false;
        }

        public static void Doiphe() // Đổi phe đánh
        {
            Quanco_Duocchon = null;
            Quanco_Biloai = null;
            PheDuocDanh = PheDoithu(PheDuocDanh);
            So_luotdi++;

            Write_PheDuocDanh(Lbl_PheDuocDanh);
            Lbl_SoLuotDi.Text = So_luotdi.ToString();
            if (So_luotdi != 0)
            {
                Btn_NewGame.Enabled = true;
                Btn_Surrender.Enabled = true;
            }
            else
            {
                Btn_NewGame.Enabled = false;
                Btn_Surrender.Enabled = false;
            }
            if (So_luotdi != 0 && PheDuocDanh != Mau_Pheta)
                Btn_Undo.Enabled = true;
            else
                Btn_Undo.Enabled = false;
            Refresh_Banco();
        }
 
        public static void Doiphe_Undo() // Đổi phe (undo)
        {
            Quanco_Biloai = null;
            Quanco_Duocchon = null;
            PheDuocDanh = PheDoithu(PheDuocDanh);
            So_luotdi--;

            Write_PheDuocDanh(Lbl_PheDuocDanh);
            Lbl_SoLuotDi.Text = So_luotdi.ToString();
            if (So_luotdi == 0)
            {
                Btn_NewGame.Enabled = false;
                Btn_Surrender.Enabled = false;
            }
            else
            {
                Btn_NewGame.Enabled = true;
                Btn_Surrender.Enabled = true;
            }
            Refresh_Banco();
        }
       
        public static void Hienthi_Nuocdi(Point departure, Point destination, PictureBox ptb_Banco) // Hiển thị nước đi
        {
            GreyTargetDeparture.Location = new Point(Thongso.TDBC_Cua_Quanco(departure).X + 10, Thongso.TDBC_Cua_Quanco(departure).Y + 10);
            GreyTargetDestination.Location = new Point(Thongso.TDBC_Cua_Quanco(destination).X - 1, Thongso.TDBC_Cua_Quanco(destination).Y - 1);
            if (So_luotdi == 0)
            {
                GreyTargetDeparture.Parent = ptb_Banco;
                GreyTargetDestination.Parent = ptb_Banco;
            }
        }

        public static void Hienthi_Nuocdi_Truoc()  // Hiển thị nước đi (undo)
        {
            GreyTargetDeparture.Location = Vitri_GreyTargetDeparture_Truoc;
            GreyTargetDestination.Location = Vitri_GreyTargetDestination_Truoc;
            if (So_luotdi == 0)
            {
                GreyTargetDeparture.Parent = null;
                GreyTargetDestination.Parent = null;
            }
        }

        public static void Luu_Nuocdi(Point departure, Point destination) // Lưu nước đi
        {
            Vitri_GreyTargetDeparture_Truoc = GreyTargetDeparture.Location;
            Vitri_GreyTargetDestination_Truoc = GreyTargetDestination.Location;
            Toado_Ditruoc = new Point(departure.X, departure.Y);
            Toado_Dentruoc = new Point(destination.X, destination.Y);
            Quanco_Dichuyen_Truoc = Quanco_Duocchon;
            Quanco_Biloai_Truoc = Quanco_Biloai;
        }

        public static void Hoantac() // hoàn tác, quay lại nước đi trước đó, trả lại quân cờ, số nước đi--, đổi lại phe đánh
        {
            Quanco_Dichuyen_Truoc.DiChuyen(Toado_Ditruoc);
            Tralai_Quanco(Quanco_Biloai_Truoc, Ptb_Banco);
            Doiphe_Undo();
            Hienthi_Nuocdi_Truoc();
        }

        public static bool TaDanh(Point departure, Point destination)
        {
            Loaibo_Quanco(destination, Ptb_Banco); // Loại bỏ quân cờ ở điểm đích
            Quanco_Duocchon.DiChuyen(destination); // Di chuyển quân cờ đến điểm đích
            if (Chongtuong())
            {
                MessageBox.Show("Chống tướng!", "Cảnh báo");
                Quanco_Duocchon.DiChuyen(departure);
                Tralai_Quanco(Quanco_Biloai, Ptb_Banco);
                Quanco_Duocchon = null;
                Quanco_Biloai = null;
                Refresh_Banco();
                return false;
            }
            if (Chieutuong(PheDoithu(Mau_Pheta))) // Đã bị chiếu
            {
                MessageBox.Show("Đã bị chiếu từ trước!", "Cảnh báo");
                Quanco_Duocchon.DiChuyen(departure);
                Tralai_Quanco(Quanco_Biloai, Ptb_Banco);
                Quanco_Duocchon = null;
                Quanco_Biloai = null;
                Refresh_Banco();
                return false;
            }
            Luu_Nuocdi(departure, destination);
            Hienthi_Nuocdi(departure, destination, Ptb_Banco);
            Doiphe();
            return true;
        }

        public static void DoithuDanh(Point departure, Point destination)
        {
            Quanco_Duocchon = Alive_RoundPictureBox.Find(element => element.Quanco.Toado == departure);
            Loaibo_Quanco(destination, Ptb_Banco);
            Quanco_Duocchon.DiChuyen(destination);
            Luu_Nuocdi(departure, destination);
            Hienthi_Nuocdi(departure, destination, Ptb_Banco);
            Doiphe();
            if (Chieutuong(PheDoithu(Mau_Pheta))) // Bị chiếu
            {
                MessageBox.Show("Bạn bị chiếu tướng!", "Cảnh báo");
            }
        }

        public static void Disable_Banco() // vô hiệu mọi tương tác với bàn cờ
        {
            foreach (RoundPictureBox element in Alive_RoundPictureBox)
                element.Enabled = false;
        }

        public static string s_to_ms(int s) // chuyển giây sang phút:giây
        {
            string result = "";
            int min, sec;
            min = s / 60;
            sec = s % 60;
            if (min < 10)
                result += "0" + min + ":";
            else
                result += min + ":";
            if (sec < 10)
                result += "0" + sec;
            else
                result += sec;
            return result;
        }
        #endregion
    }
}