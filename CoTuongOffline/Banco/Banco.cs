using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTuongOffline.Cotuong
{
    public static class Banco
    {
        #region properties

        public static int Mau_Pheta { get; set; } = 2; // màu của phe ta (đỏ)

        public static Color Mau_Phedo { get { return Color.Red; } }

        public static Color Mau_Phexanh { get { return Color.DarkGreen; } }

        public static Nuocdi Nuocdi_Truoc { get; } = new Nuocdi();

        // Đối tượng Quanco: quân cờ trừu tượng

        public static List<Quanco> Alive_Quanco { get; } = new List<Quanco>(); // ds quân cờ còn sống

        public static Tuong Tuongxanh { get; set; } = null;

        public static Tuong Tuongdo { get; set; } = null;

        // Đối tượng RoundButton: điểm trên bàn cờ

        public static ProgramConfig.RoundButton[,] Diem_Banco { get; } = new ProgramConfig.RoundButton[9, 10]; // Mảng 2 chiều chứa 9x10=90 điểm bàn cờ

        // Đối tượng RoundPictureBox: quân cờ trực quan

        public static List<ProgramConfig.RoundPictureBox> Alive_RoundPictureBox { get; } = new List<ProgramConfig.RoundPictureBox>(); // Danh sách quân cờ còn sống

        public static ProgramConfig.RoundPictureBox Quanco_Duocchon { get; set; } // quân cờ được chọn

        public static ProgramConfig.RoundPictureBox Quanco_Biloai { get; set; } // quân cờ vừa bị loại ở nước đi trước đó, nếu di chuyển thành công thì gán lại về null
        
        public static int PheDuocdanh { get; private set; } // Phe hiện tại đang được đánh 1 xanh/2 đỏ

        public static int So_Luotdi { get; private set; } // Thống kê số lượt đã đi

        #region Đánh dấu
        public static PictureBox YellowTarget { get; } = new PictureBox() // Khung vàng - Đánh dấu quân cờ đang được chọn
        {
            Width = 58,
            Height = 58,
            BackColor = Color.Transparent,
            Image = Properties.Resources.yellow_square_target,
            Location = ProgramConfig.Thongso.Toado_NULL
        };
        public static PictureBox GreyTargetDeparture { get; } = new PictureBox() // Khung xám nhỏ - Đánh dấu vị trí cũ của quân cờ sau nước đi vừa rồi
        {
            Width = 36,
            Height = 36,
            BackColor = Color.Transparent,
            Image = Properties.Resources.grey_square_target_depart,
            Location = ProgramConfig.Thongso.Toado_NULL
        };
        public static PictureBox GreyTargetDestination { get; } = new PictureBox() // Khung xám to - Đánh dấu vị trí mới của quân cờ sau nước đi vừa rồi
        {
            Width = 58,
            Height = 58,
            BackColor = Color.Transparent,
            Image = global::CoTuongOffline.Properties.Resources.grey_square_target_dest,
            Location = ProgramConfig.Thongso.Toado_NULL,
         
        };
        #endregion
        #endregion

        #region methods
        // đối tượng Quanco

        public static bool Ktra_Quanco_taivitri(Point vitri) // Kiểm tra ở vị trí có quân cờ không?
        {
            return Alive_Quanco.Find(element => element.Toado == vitri) != null;
        }

        public static Quanco Lay_Quanco(Point vitri) // tìm quân cờ tại vị trí 
        {
            return Alive_Quanco.Find(element => element.Toado == vitri);
        }

        // Đối tượng RoundPictureBox
        // Tạo 90 RoundButton điểm bàn cờ ẩn
        // 90 điểm này theo 2 trục XY với đỉnh O ngay góc trái trên bàn cờ, chạy dọc và sang phải theo 2 vòng lặp tạo điểm bàn cờ
        public static void Taodiem_Banco(PictureBox ptb_Banco, EventHandler Diembanco_Click)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Diem_Banco[x, y] = new ProgramConfig.RoundButton()
                    {
                        Text = "",
                        Width = ProgramConfig.Thongso.Duongkinh_diem,
                        Height = ProgramConfig.Thongso.Duongkinh_diem,
                        BackColor = Color.Yellow,
                        Location = ProgramConfig.Thongso.TDBC_Diem(x, y),
                        Visible = false // Ẩn sau khi tạo
                    };
                    Diem_Banco[x, y].Click += Diembanco_Click;
                    ptb_Banco.Controls.Add(Diem_Banco[x, y]);
                }
            }
        }
        #region tạo 32 roundpicturebox quân cờ
        // Tạo 32 RoundPictureBox quân cờ và đưa chúng vào danh sách
        public static void Tao_Quanco(EventHandler Quanco_Click, PictureBox ptb_Banco)
        {
            if (Mau_Pheta == 2) // phe ta là đỏ
            {
                // Xanh

                // Tướng
                ProgramConfig.RoundPictureBox tuongxanh = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Tuongxanh);
                tuongxanh.Image = global::CoTuongOffline.Properties.Resources.TuongXanh;
                Alive_RoundPictureBox.Add(tuongxanh);

                // Xe
                ProgramConfig.RoundPictureBox xexanh_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Xexanh_1);
                xexanh_1.Image = Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xexanh_1);

                ProgramConfig.RoundPictureBox xexanh_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Xexanh_2);
                xexanh_2.Image = global::CoTuongOffline.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xexanh_2);

                // Mã
                ProgramConfig.RoundPictureBox maxanh_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Maxanh_1);
                maxanh_1.Image = global::CoTuongOffline.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maxanh_1);

                ProgramConfig.RoundPictureBox maxanh_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Maxanh_2);
                maxanh_2.Image = global::CoTuongOffline.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maxanh_2);

                // Tịnh
                ProgramConfig.RoundPictureBox tinhxanh_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Tinhxanh_1);
                tinhxanh_1.Image = global::CoTuongOffline.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhxanh_1);

                ProgramConfig.RoundPictureBox tinhxanh_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Tinhxanh_2);
                tinhxanh_2.Image = global::CoTuongOffline.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhxanh_2);

                // Sĩ
                ProgramConfig.RoundPictureBox sixanh_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Sixanh_1);
                sixanh_1.Image = global::CoTuongOffline.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(sixanh_1);

                ProgramConfig.RoundPictureBox sixanh_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Sixanh_2);
                sixanh_2.Image = global::CoTuongOffline.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(sixanh_2);

                // Pháo
                ProgramConfig.RoundPictureBox phaoxanh_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Phaoxanh_1);
                phaoxanh_1.Image = global::CoTuongOffline.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoxanh_1);

                ProgramConfig.RoundPictureBox phaoxanh_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Phaoxanh_2);
                phaoxanh_2.Image = global::CoTuongOffline.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoxanh_2);

                // Tốt
                ProgramConfig.RoundPictureBox totxanh_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Totxanh_1);
                totxanh_1.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_1);

                ProgramConfig.RoundPictureBox totxanh_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Totxanh_2);
                totxanh_2.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_2);

                ProgramConfig.RoundPictureBox totxanh_3 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Totxanh_3);
                totxanh_3.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_3);

                ProgramConfig.RoundPictureBox totxanh_4 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Totxanh_4);
                totxanh_4.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_4);

                ProgramConfig.RoundPictureBox totxanh_5 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Totxanh_5);
                totxanh_5.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_5);

                // Đỏ

                // Tướng
                ProgramConfig.RoundPictureBox tuongdo = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Tuongdo);
                tuongdo.Image = global::CoTuongOffline.Properties.Resources.TuongDo;
                Alive_RoundPictureBox.Add(tuongdo);

                // Xe
                ProgramConfig.RoundPictureBox xedo_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Xedo_1);
                xedo_1.Image = global::CoTuongOffline.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xedo_1);

                ProgramConfig.RoundPictureBox xedo_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Xedo_2);
                xedo_2.Image = global::CoTuongOffline.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xedo_2);

                // Mã
                ProgramConfig.RoundPictureBox mado_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Mado_1);
                mado_1.Image = global::CoTuongOffline.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(mado_1);

                ProgramConfig.RoundPictureBox mado2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Mado_2);
                mado2.Image = global::CoTuongOffline.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(mado2);

                // Tịnh
                ProgramConfig.RoundPictureBox tinhdo_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Tinhdo_1);
                tinhdo_1.Image = global::CoTuongOffline.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhdo_1);

                ProgramConfig.RoundPictureBox tinhdo_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Tinhdo_2);
                tinhdo_2.Image = global::CoTuongOffline.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhdo_2);

                // Sĩ
                ProgramConfig.RoundPictureBox sido_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Sido_1);
                sido_1.Image = global::CoTuongOffline.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(sido_1);

                ProgramConfig.RoundPictureBox sido_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Sido_2);
                sido_2.Image = global::CoTuongOffline.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(sido_2);

                // Pháo
                ProgramConfig.RoundPictureBox phaodo_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Phaodo_1);
                phaodo_1.Image = global::CoTuongOffline.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaodo_1);

                ProgramConfig.RoundPictureBox phaodo_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Phaodo_2);
                phaodo_2.Image = global::CoTuongOffline.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaodo_2);

                // Tốt
                ProgramConfig.RoundPictureBox totdo_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Totdo_1);
                totdo_1.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_1);

                ProgramConfig.RoundPictureBox totdo_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Totdo_2);
                totdo_2.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_2);

                ProgramConfig.RoundPictureBox totdo_3 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Totdo_3);
                totdo_3.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_3);

                ProgramConfig.RoundPictureBox totdo_4 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Totdo_4);
                totdo_4.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_4);

                ProgramConfig.RoundPictureBox totdo_5 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phedo.Toado_Totdo_5);
                totdo_5.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_5);
            }
            else if (Mau_Pheta == 1) // phe ta là xanh 
            {
                // Xanh

                // Tướng
                ProgramConfig.RoundPictureBox tuongxanh = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Tuongxanh);
                tuongxanh.Image = global::CoTuongOffline.Properties.Resources.TuongXanh;
                Alive_RoundPictureBox.Add(tuongxanh);

                // Xe
                ProgramConfig.RoundPictureBox xexanh_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Xexanh_1);
                xexanh_1.Image = global::CoTuongOffline.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xexanh_1);

                ProgramConfig.RoundPictureBox xexanh_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Xexanh_2);
                xexanh_2.Image = global::CoTuongOffline.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xexanh_2);

                // Mã
                ProgramConfig.RoundPictureBox maxanh_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Maxanh_1);
                maxanh_1.Image = global::CoTuongOffline.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maxanh_1);

                ProgramConfig.RoundPictureBox maxanh_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Maxanh_2);
                maxanh_2.Image = global::CoTuongOffline.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maxanh_2);

                // Tịnh
                ProgramConfig.RoundPictureBox tinhxanh_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Tinhxanh_1);
                tinhxanh_1.Image = global::CoTuongOffline.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhxanh_1);

                ProgramConfig.RoundPictureBox tinhxanh_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Tinhxanh_2);
                tinhxanh_2.Image = global::CoTuongOffline.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhxanh_2);

                // Sĩ
                ProgramConfig.RoundPictureBox sixanh_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Sixanh_1);
                sixanh_1.Image = global::CoTuongOffline.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(sixanh_1);

                ProgramConfig.RoundPictureBox sixanh_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Sixanh_2);
                sixanh_2.Image = global::CoTuongOffline.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(sixanh_2);

                // Pháo
                ProgramConfig.RoundPictureBox phaoxanh_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Phaoxanh_1);
                phaoxanh_1.Image = global::CoTuongOffline.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoxanh_1);

                ProgramConfig.RoundPictureBox phaoxanh_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Phaoxanh_2);
                phaoxanh_2.Image = global::CoTuongOffline.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoxanh_2);

                // Tốt
                ProgramConfig.RoundPictureBox totxanh_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Totxanh1_);
                totxanh_1.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_1);

                ProgramConfig.RoundPictureBox totxanh_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Totxanh_2);
                totxanh_2.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_2);

                ProgramConfig.RoundPictureBox totxanh_3 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Totxanh_3);
                totxanh_3.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_3);

                ProgramConfig.RoundPictureBox totxanh_4 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Totxanh_4);
                totxanh_4.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_4);

                ProgramConfig.RoundPictureBox totxanh_5 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Totxanh_5);
                totxanh_5.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totxanh_5);

                // Đỏ

                // Tướng
                
                ProgramConfig.RoundPictureBox tuongdo = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Tuongdo);
                tuongdo.Image = global::CoTuongOffline.Properties.Resources.TuongDo;
                Alive_RoundPictureBox.Add(tuongdo);

                // Xe
                ProgramConfig.RoundPictureBox xedo_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Xedo_1);
                xedo_1.Image = global::CoTuongOffline.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xedo_1);

                ProgramConfig.RoundPictureBox xedo_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Xedo_2);
                xedo_2.Image = global::CoTuongOffline.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xedo_2);

                // Mã
                ProgramConfig.RoundPictureBox mado_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Mado_1);
                mado_1.Image = global::CoTuongOffline.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(mado_1);

                ProgramConfig.RoundPictureBox mado_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Mado_2);
                mado_2.Image = global::CoTuongOffline.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(mado_2);

                // Tịnh
                ProgramConfig.RoundPictureBox tinhdo_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Tinhdo_1);
                tinhdo_1.Image = global::CoTuongOffline.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhdo_1);

                ProgramConfig.RoundPictureBox tinhdo_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Tinhdo_2);
                tinhdo_2.Image = global::CoTuongOffline.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhdo_2);

                // Sĩ
                ProgramConfig.RoundPictureBox sido_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Sido_1);
                sido_1.Image = global::CoTuongOffline.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(sido_1);

                ProgramConfig.RoundPictureBox sido_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Sido_2);
                sido_2.Image = global::CoTuongOffline.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(sido_2);

                // Pháo
                ProgramConfig.RoundPictureBox phaodo_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Phaodo_1);
                phaodo_1.Image = global::CoTuongOffline.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaodo_1);

                ProgramConfig.RoundPictureBox phaodo_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Phaodo_2);
                phaodo_2.Image = global::CoTuongOffline.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaodo_2);

                // Tốt
                ProgramConfig.RoundPictureBox totdo_1 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Totdo_1);
                totdo_1.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_1);

                ProgramConfig.RoundPictureBox totdo_2 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Totdo_2);
                totdo_2.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_2);

                ProgramConfig.RoundPictureBox totdo_3 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Totdo_3);
                totdo_3.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_3);

                ProgramConfig.RoundPictureBox totdo_4 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Totdo_4);
                totdo_4.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_4);

                ProgramConfig.RoundPictureBox totdo_5 = new ProgramConfig.RoundPictureBox(ProgramConfig.Bandau_Phexanh.Toado_Totdo_5);
                totdo_5.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totdo_5);
            }
            foreach (ProgramConfig.RoundPictureBox element in Alive_RoundPictureBox) // Gán cho mỗi RoundPictureBox quân cờ 1 sự kiện click và xếp lên bàn cờ
            {
                element.Click += Quanco_Click;
                ptb_Banco.Controls.Add(element);
            }
        }
        #endregion

        public static void Refresh_Banco() // refresh bàn cờ
        {
            foreach (ProgramConfig.RoundPictureBox element in Alive_RoundPictureBox)
            {
                if (element.Quanco.Mau == PheDuocdanh)
                    element.Enabled = true;
                else element.Enabled = false;
                element.BringToFront();
            }
        }

        public static void Write_PheDuocDanh(Label lbl_PheDuocDanh) // hiển thị tới lượt của phe nào
        {
            if (PheDuocdanh == 2)
            {
                lbl_PheDuocDanh.ForeColor = Mau_Phedo;
                lbl_PheDuocDanh.Text = "Phe đỏ";
            }
            else
            {
                lbl_PheDuocDanh.ForeColor = Mau_Phexanh;
                lbl_PheDuocDanh.Text = "Phe xanh";
            }
        }

        public static void SetToDefault(Label lbl_PheDuocDanh, Label lbl_SoLuotDi, Button btn_NewGame, Button btn_Undo) // Bàn cờ về mặc định
        {
            Quanco_Biloai = null;
            Quanco_Duocchon = null;
            PheDuocdanh = Mau_Pheta;
            So_Luotdi = 0;

            Write_PheDuocDanh(lbl_PheDuocDanh);
            lbl_SoLuotDi.Text = So_Luotdi.ToString();
            btn_NewGame.Enabled = false;
            btn_Undo.Enabled = false;
        }

        public static void XoaBanCo(PictureBox ptbBanCo) // Xóa các RoundPictureBox quân cờ khỏi bàn cờ và danh sách
        {
            ptbBanCo.Controls.Clear();
            Tuongxanh = null;
            Tuongdo = null;
            Alive_Quanco.Clear();
            Alive_RoundPictureBox.Clear();
            Nuocdi_Truoc.Clear();
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
            foreach (ProgramConfig.RoundButton element in Diem_Banco)
            {
                element.Visible = false;
                element.BackColor = Color.Yellow;
            }
        }

        public static void Loaibo_Quanco(Point vitri, PictureBox ptb_Banco)
        {
            Quanco_Biloai = Alive_RoundPictureBox.Find(element => element.Quanco.Mau != PheDuocdanh && element.Quanco.Toado == vitri);
            if (Quanco_Biloai != null)
            {
                ptb_Banco.Controls.Remove(Quanco_Biloai);
                Alive_RoundPictureBox.Remove(Quanco_Biloai);
                Alive_Quanco.Remove(Quanco_Biloai.Quanco);
            }
        }
        
        public static void TraLaiQuanCo(PictureBox ptb_Banco, ProgramConfig.RoundPictureBox quanco_Cantralai) // Trả lại quân cờ bị loại
        {
            if (quanco_Cantralai != null)
            {
                Alive_Quanco.Add(quanco_Cantralai.Quanco);
                Alive_RoundPictureBox.Add(quanco_Cantralai);
                ptb_Banco.Controls.Add(quanco_Cantralai);
            }
        }

        public static int PheDoiThu() // trả về xanh nếu là đỏ, đỏ nếu là xanh
        {
            if (PheDuocdanh == 1)
                return 2;
            return 1;
        }

        public static bool Chongtuong() //Chống tướng: 2 tướng không được đối mặt
        {
            if (Tuongxanh.Toado.X == Tuongdo.Toado.X) // nếu 2 tướng cùng hoành độ (thẳng hàng) ...
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

        public static void Doiphe(Label lbl_PheDuocDanh, Label lbl_SoLuotDi, Button btn_NewGame, Button btn_Undo) // Đổi phe đánh
        {
            Quanco_Biloai = null;
            Quanco_Duocchon = null;
            PheDuocdanh = PheDoiThu();
            So_Luotdi++;

            Write_PheDuocDanh(lbl_PheDuocDanh);
            lbl_SoLuotDi.Text = So_Luotdi.ToString();
            if (So_Luotdi != 0)
            {
                btn_NewGame.Enabled = true;
                btn_Undo.Enabled = true;
            }
            else
            {
                btn_NewGame.Enabled = false;
                btn_Undo.Enabled = false;
            }
            Refresh_Banco();
        }

        public static void Doiphe_Undo(Label lbl_PheDuocDanh, Label lbl_SoLuotDi, Button btn_NewGame) // Đổi phe (undo)
        {
            Quanco_Biloai = null;
            Quanco_Duocchon = null;
            PheDuocdanh = PheDoiThu();
            So_Luotdi--;

            Write_PheDuocDanh(lbl_PheDuocDanh);
            lbl_SoLuotDi.Text = So_Luotdi.ToString();
            if (So_Luotdi != 0)
                btn_NewGame.Enabled = true;
            else
                btn_NewGame.Enabled = false;
            Refresh_Banco();
        }

        public static void Hienthi_Nuocdi(Point departure, Point destination, PictureBox ptb_Banco) // Hiển thị nước đi
        {
            Nuocdi_Truoc.PrevGreyTargetDepartureLocation = GreyTargetDeparture.Location; // đánh dấu khung xám nhỏ (điểm bắt đầu) ở nước đi trước
            Nuocdi_Truoc.PrevGreyTargetDestinationLocation = GreyTargetDestination.Location; // đánh dấu khung xám to (điểm đến) ở nước đi trước
            GreyTargetDeparture.Location = new Point(ProgramConfig.Thongso.TDBC_Quanco(departure).X + 10, ProgramConfig.Thongso.TDBC_Quanco(departure).Y + 10);
            GreyTargetDestination.Location = new Point(ProgramConfig.Thongso.TDBC_Quanco(destination).X - 1, ProgramConfig.Thongso.TDBC_Quanco(destination).Y - 1);
            if (So_Luotdi == 0)
            {
                GreyTargetDeparture.Parent = ptb_Banco;
                GreyTargetDestination.Parent = ptb_Banco;
            }
        }

        public static void Hienthi_Nuocdi_Truoc(PictureBox ptb_Banco) // Hiển thị nước đi (undo)
        {
            GreyTargetDeparture.Location = Nuocdi_Truoc.PrevGreyTargetDepartureLocation;
            GreyTargetDestination.Location = Nuocdi_Truoc.PrevGreyTargetDestinationLocation;
            if (So_Luotdi == 0)
            {
                GreyTargetDeparture.Parent = null;
                GreyTargetDestination.Parent = null;
            }
        }
    
        public static void Luu_Nuocdi(Point departure, Point destination) // Lưu nước đi
        {
            Nuocdi_Truoc.Toado_Di = new Point(departure.X, departure.Y);
            Nuocdi_Truoc.Toado_Den = new Point(destination.X, destination.Y);
            Nuocdi_Truoc.Quanco_Dichuyen = Quanco_Duocchon;
            Nuocdi_Truoc.Quanco_Biloai = Quanco_Biloai;
        }

        public static void Hoantac(PictureBox ptb_Banco) // hoàn tác
        {
            Nuocdi_Truoc.Quanco_Dichuyen.DiChuyen(Nuocdi_Truoc.Toado_Di);
            TraLaiQuanCo(ptb_Banco, Nuocdi_Truoc.Quanco_Biloai);
        }
        #endregion
    }
}
