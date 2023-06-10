using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTuongOffline.CoTuong
{
    public static class BanCo
    {
        #region properties

        public static int MauPheTa { get; set; } = 2; // màu của phe ta (phe xuất phát ở nửa dưới bàn cờ)

        public static Color MauPheDo { get { return Color.DarkRed; } }

        public static Color MauPheXanh { get { return Color.DarkBlue; } }

        public static NuocDi NuocDiTruocDo { get; } = new NuocDi(); ///*

        /* Thuộc tính liên quan đến đối tượng QuanCo (quân cờ trừu tượng) */

        public static List<QuanCo> Alive_QuanCo { get; } = new List<QuanCo>(); ///*

        public static QuanTuong TuongXanh { get; set; } = null;

        public static QuanTuong TuongDo { get; set; } = null;

        /* Thuộc tính liên quan đến đối tượng RoundButton (thể hiện điểm bàn cờ) */

        public static ProgramConfig.RoundButton[,] DiemBanCo { get; } = new ProgramConfig.RoundButton[9, 10]; ///* // Mảng 2 chiều chứa 90 điểm bàn cờ

        /* Thuộc tính liên quan đến đối tượng RoundPictureBox (thể hiện quân cờ trực quan) */

        public static List<ProgramConfig.RoundPictureBox> Alive_RoundPictureBox { get; } = new List<ProgramConfig.RoundPictureBox>(); ///* // List chứa tất cả các quân cờ còn sống

        public static ProgramConfig.RoundPictureBox QuanCoDuocChon { get; set; } // quân cờ đang được chọn

        public static ProgramConfig.RoundPictureBox QuanCoBiLoai { get; set; } // quân cờ vừa bị loại ở nước đi trước đó, nếu di chuyển thành công thì quanCoBiLoai không cần dùng đến => gán lại về null
        
        public static int PheDuocDanh { get; private set; } // Phe hiện tại đang được đánh (1 - Xanh, 2 - Đỏ). Phe Đỏ được đánh đầu tiên

        public static int SoLuotDi { get; private set; } // Số lượt đã đi từ đầu ván cờ

        
        public static PictureBox YellowTarget { get; } = new PictureBox() // Khung vàng - Đánh dấu quân cờ đang được chọn
        {
            Width = 58,
            Height = 58,
            BackColor = Color.Transparent,
            Image = Properties.Resources.yellow_square_target,
            Location = ProgramConfig.ThongSo.ToaDoNULL
        };
        public static PictureBox GreyTargetDeparture { get; } = new PictureBox() // Khung xám nhỏ - Đánh dấu vị trí cũ của quân cờ sau nước đi vừa rồi
        {
            Width = 36,
            Height = 36,
            BackColor = Color.Transparent,
            Image = Properties.Resources.grey_square_target_depart,
            Location = ProgramConfig.ThongSo.ToaDoNULL
        };
        public static PictureBox GreyTargetDestination { get; } = new PictureBox() // Khung xám to - Đánh dấu vị trí mới của quân cờ sau nước đi vừa rồi
        {
            Width = 58,
            Height = 58,
            BackColor = Color.Transparent,
            Image = global::CoTuongOffline.Properties.Resources.grey_square_target_dest,
            Location = ProgramConfig.ThongSo.ToaDoNULL,
         
        };

        #endregion

        #region methods
        /* Phương thức dùng cho đối tượng QuanCo */

        public static bool CoQuanCoTaiDay(Point viTri) // kiểm tra xem có quân cờ nào tại vị trí cho trước hay không
        {
            return Alive_QuanCo.Find(element => element.ToaDo == viTri) != null;
        }

        public static QuanCo GetQuanCo(Point viTri) // tìm quân cờ tại điểm cho trước
        {
            return Alive_QuanCo.Find(element => element.ToaDo == viTri);
        }

        /* Phương thức dùng cho đối tượng RoundPictureBox */
        /* Tạo 90 RoundButton điểm bàn cờ nhưng chưa hiển thị.
         Khi click vào 1 RoundPictureBox quân cờ thì những điểm bàn cờ ở những tọa độ trong danh sách điểm đích của quân đó sẽ hiện ra */
        public static void TaoDiemBanCo(PictureBox ptbBanCo, EventHandler DiemBanCo_Click)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    DiemBanCo[x, y] = new ProgramConfig.RoundButton()
                    {
                        Text = "",
                        Width = ProgramConfig.ThongSo.DuongKinhDiem,
                        Height = ProgramConfig.ThongSo.DuongKinhDiem,
                        BackColor = Color.Yellow,
                        Location = ProgramConfig.ThongSo.ToaDoBanCoCuaDiem(x, y),
                        Visible = false // Ẩn điểm bàn cờ sau khi khởi tạo
                    };
                    DiemBanCo[x, y].Click += DiemBanCo_Click;
                    ptbBanCo.Controls.Add(DiemBanCo[x, y]);
                }
            }
        }

        /* Tạo 32 RoundPictureBox quân cờ và đưa chúng vào danh sách các quân cờ để quản lý */
        public static void TaoQuanCo(EventHandler QuanCo_Click, PictureBox ptbBanCo)
        {
            if (MauPheTa == 2)
            {
                /* Tướng xanh */
                ProgramConfig.RoundPictureBox tuongXanh = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTuongXanh);
                tuongXanh.Image = global::CoTuongOffline.Properties.Resources.TuongXanh;
                Alive_RoundPictureBox.Add(tuongXanh);

                /* Xe xanh */
                ProgramConfig.RoundPictureBox xeXanh1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoXeXanh1);
                xeXanh1.Image = Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xeXanh1);

                ProgramConfig.RoundPictureBox xeXanh2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoXeXanh2);
                xeXanh2.Image = global::CoTuongOffline.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xeXanh2);

                /* Mã xanh */
                ProgramConfig.RoundPictureBox maXanh1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoMaXanh1);
                maXanh1.Image = global::CoTuongOffline.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maXanh1);

                ProgramConfig.RoundPictureBox maXanh2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoMaXanh2);
                maXanh2.Image = global::CoTuongOffline.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maXanh2);

                /* Tịnh xanh */
                ProgramConfig.RoundPictureBox tinhXanh1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTinhXanh1);
                tinhXanh1.Image = global::CoTuongOffline.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhXanh1);

                ProgramConfig.RoundPictureBox tinhXanh2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTinhXanh2);
                tinhXanh2.Image = global::CoTuongOffline.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhXanh2);

                /* Sĩ xanh */
                ProgramConfig.RoundPictureBox siXanh1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoSiXanh1);
                siXanh1.Image = global::CoTuongOffline.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(siXanh1);

                ProgramConfig.RoundPictureBox siXanh2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoSiXanh2);
                siXanh2.Image = global::CoTuongOffline.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(siXanh2);

                /* Pháo xanh */
                ProgramConfig.RoundPictureBox phaoXanh1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoPhaoXanh1);
                phaoXanh1.Image = global::CoTuongOffline.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoXanh1);

                ProgramConfig.RoundPictureBox phaoXanh2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoPhaoXanh2);
                phaoXanh2.Image = global::CoTuongOffline.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoXanh2);

                /* Tốt xanh */
                ProgramConfig.RoundPictureBox totXanh1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTotXanh1);
                totXanh1.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh1);

                ProgramConfig.RoundPictureBox totXanh2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTotXanh2);
                totXanh2.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh2);

                ProgramConfig.RoundPictureBox totXanh3 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTotXanh3);
                totXanh3.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh3);

                ProgramConfig.RoundPictureBox totXanh4 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTotXanh4);
                totXanh4.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh4);

                ProgramConfig.RoundPictureBox totXanh5 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTotXanh5);
                totXanh5.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh5);

                /* Tướng đỏ */
                ProgramConfig.RoundPictureBox tuongDo = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTuongDo);
                tuongDo.Image = global::CoTuongOffline.Properties.Resources.TuongDo;
                Alive_RoundPictureBox.Add(tuongDo);

                /* Xe đỏ */
                ProgramConfig.RoundPictureBox xeDo1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoXeDo1);
                xeDo1.Image = global::CoTuongOffline.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xeDo1);

                ProgramConfig.RoundPictureBox xeDo2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoXeDo2);
                xeDo2.Image = global::CoTuongOffline.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xeDo2);

                /* Mã đỏ */
                ProgramConfig.RoundPictureBox maDo1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoMaDo1);
                maDo1.Image = global::CoTuongOffline.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(maDo1);

                ProgramConfig.RoundPictureBox maDo2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoMaDo2);
                maDo2.Image = global::CoTuongOffline.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(maDo2);

                /* Tịnh đỏ */
                ProgramConfig.RoundPictureBox tinhDo1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTinhDo1);
                tinhDo1.Image = global::CoTuongOffline.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhDo1);

                ProgramConfig.RoundPictureBox tinhDo2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTinhDo2);
                tinhDo2.Image = global::CoTuongOffline.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhDo2);

                /* Sĩ đỏ */
                ProgramConfig.RoundPictureBox siDo1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoSiDo1);
                siDo1.Image = global::CoTuongOffline.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(siDo1);

                ProgramConfig.RoundPictureBox siDo2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoSiDo2);
                siDo2.Image = global::CoTuongOffline.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(siDo2);

                /* Pháo đỏ */
                ProgramConfig.RoundPictureBox phaoDo1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoPhaoDo1);
                phaoDo1.Image = global::CoTuongOffline.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaoDo1);

                ProgramConfig.RoundPictureBox phaoDo2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoPhaoDo2);
                phaoDo2.Image = global::CoTuongOffline.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaoDo2);

                /* Tốt đỏ */
                ProgramConfig.RoundPictureBox totDo1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTotDo1);
                totDo1.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo1);

                ProgramConfig.RoundPictureBox totDo2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTotDo2);
                totDo2.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo2);

                ProgramConfig.RoundPictureBox totDo3 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTotDo3);
                totDo3.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo3);

                ProgramConfig.RoundPictureBox totDo4 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTotDo4);
                totDo4.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo4);

                ProgramConfig.RoundPictureBox totDo5 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheDo.ToaDoTotDo5);
                totDo5.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo5);
            }
            else if (MauPheTa == 1)
            {
                /* Tướng xanh */
                ProgramConfig.RoundPictureBox tuongXanh = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTuongXanh);
                tuongXanh.Image = global::CoTuongOffline.Properties.Resources.TuongXanh;
                Alive_RoundPictureBox.Add(tuongXanh);

                /* Xe xanh */
                ProgramConfig.RoundPictureBox xeXanh1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoXeXanh1);
                xeXanh1.Image = global::CoTuongOffline.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xeXanh1);

                ProgramConfig.RoundPictureBox xeXanh2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoXeXanh2);
                xeXanh2.Image = global::CoTuongOffline.Properties.Resources.XeXanh;
                Alive_RoundPictureBox.Add(xeXanh2);

                /* Mã xanh */
                ProgramConfig.RoundPictureBox maXanh1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoMaXanh1);
                maXanh1.Image = global::CoTuongOffline.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maXanh1);

                ProgramConfig.RoundPictureBox maXanh2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoMaXanh2);
                maXanh2.Image = global::CoTuongOffline.Properties.Resources.MaXanh;
                Alive_RoundPictureBox.Add(maXanh2);

                /* Tịnh xanh */
                ProgramConfig.RoundPictureBox tinhXanh1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTinhXanh1);
                tinhXanh1.Image = global::CoTuongOffline.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhXanh1);

                ProgramConfig.RoundPictureBox tinhXanh2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTinhXanh2);
                tinhXanh2.Image = global::CoTuongOffline.Properties.Resources.TinhXanh;
                Alive_RoundPictureBox.Add(tinhXanh2);

                /* Sĩ xanh */
                ProgramConfig.RoundPictureBox siXanh1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoSiXanh1);
                siXanh1.Image = global::CoTuongOffline.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(siXanh1);

                ProgramConfig.RoundPictureBox siXanh2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoSiXanh2);
                siXanh2.Image = global::CoTuongOffline.Properties.Resources.SiXanh;
                Alive_RoundPictureBox.Add(siXanh2);

                /* Pháo xanh */
                ProgramConfig.RoundPictureBox phaoXanh1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoPhaoXanh1);
                phaoXanh1.Image = global::CoTuongOffline.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoXanh1);

                ProgramConfig.RoundPictureBox phaoXanh2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoPhaoXanh2);
                phaoXanh2.Image = global::CoTuongOffline.Properties.Resources.PhaoXanh;
                Alive_RoundPictureBox.Add(phaoXanh2);

                /* Tốt xanh */
                ProgramConfig.RoundPictureBox totXanh1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTotXanh1);
                totXanh1.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh1);

                ProgramConfig.RoundPictureBox totXanh2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTotXanh2);
                totXanh2.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh2);

                ProgramConfig.RoundPictureBox totXanh3 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTotXanh3);
                totXanh3.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh3);

                ProgramConfig.RoundPictureBox totXanh4 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTotXanh4);
                totXanh4.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh4);

                ProgramConfig.RoundPictureBox totXanh5 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTotXanh5);
                totXanh5.Image = global::CoTuongOffline.Properties.Resources.TotXanh;
                Alive_RoundPictureBox.Add(totXanh5);

                /* Tướng đỏ */
                ProgramConfig.RoundPictureBox tuongDo = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTuongDo);
                tuongDo.Image = global::CoTuongOffline.Properties.Resources.TuongDo;
                Alive_RoundPictureBox.Add(tuongDo);

                /* Xe đỏ */
                ProgramConfig.RoundPictureBox xeDo1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoXeDo1);
                xeDo1.Image = global::CoTuongOffline.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xeDo1);

                ProgramConfig.RoundPictureBox xeDo2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoXeDo2);
                xeDo2.Image = global::CoTuongOffline.Properties.Resources.XeDo;
                Alive_RoundPictureBox.Add(xeDo2);

                /* Mã đỏ */
                ProgramConfig.RoundPictureBox maDo1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoMaDo1);
                maDo1.Image = global::CoTuongOffline.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(maDo1);

                ProgramConfig.RoundPictureBox maDo2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoMaDo2);
                maDo2.Image = global::CoTuongOffline.Properties.Resources.MaDo;
                Alive_RoundPictureBox.Add(maDo2);

                /* Tịnh đỏ */
                ProgramConfig.RoundPictureBox tinhDo1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTinhDo1);
                tinhDo1.Image = global::CoTuongOffline.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhDo1);

                ProgramConfig.RoundPictureBox tinhDo2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTinhDo2);
                tinhDo2.Image = global::CoTuongOffline.Properties.Resources.TinhDo;
                Alive_RoundPictureBox.Add(tinhDo2);

                /* Sĩ đỏ */
                ProgramConfig.RoundPictureBox siDo1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoSiDo1);
                siDo1.Image = global::CoTuongOffline.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(siDo1);

                ProgramConfig.RoundPictureBox siDo2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoSiDo2);
                siDo2.Image = global::CoTuongOffline.Properties.Resources.SiDo;
                Alive_RoundPictureBox.Add(siDo2);

                /* Pháo đỏ */
                ProgramConfig.RoundPictureBox phaoDo1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoPhaoDo1);
                phaoDo1.Image = global::CoTuongOffline.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaoDo1);

                ProgramConfig.RoundPictureBox phaoDo2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoPhaoDo2);
                phaoDo2.Image = global::CoTuongOffline.Properties.Resources.PhaoDo;
                Alive_RoundPictureBox.Add(phaoDo2);

                /* Tốt đỏ */
                ProgramConfig.RoundPictureBox totDo1 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTotDo1);
                totDo1.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo1);

                ProgramConfig.RoundPictureBox totDo2 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTotDo2);
                totDo2.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo2);

                ProgramConfig.RoundPictureBox totDo3 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTotDo3);
                totDo3.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo3);

                ProgramConfig.RoundPictureBox totDo4 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTotDo4);
                totDo4.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo4);

                ProgramConfig.RoundPictureBox totDo5 = new ProgramConfig.RoundPictureBox(ProgramConfig.ThongSoPheXanh.ToaDoTotDo5);
                totDo5.Image = global::CoTuongOffline.Properties.Resources.TotDo;
                Alive_RoundPictureBox.Add(totDo5);
            }
            foreach (ProgramConfig.RoundPictureBox element in Alive_RoundPictureBox) // Gắn cho mỗi RoundPictureBox quân cờ 1 sự kiện click và xếp nó lên bàn cờ
            {
                element.Click += QuanCo_Click;
                ptbBanCo.Controls.Add(element);
            }
        }

        public static void RefreshBanCo() // BẢN OFFLINE
        {
            foreach (ProgramConfig.RoundPictureBox element in Alive_RoundPictureBox)
            {
                if (element.Quan_Co.Mau == PheDuocDanh)
                    element.Enabled = true;
                else element.Enabled = false;
                element.BringToFront();
            }
        }

        public static void WritePheDuocDanh(Label lblPheDuocDanh)
        {
            if (PheDuocDanh == 2)
            {
                lblPheDuocDanh.ForeColor = MauPheDo;
                lblPheDuocDanh.Text = "Lượt đi của phe Đỏ";
            }
            else
            {
                lblPheDuocDanh.ForeColor = MauPheXanh;
                lblPheDuocDanh.Text = "Lượt đi của phe Xanh";
            }
        }

        /*Dat ban co ve trang thai ban dau*/
        public static void SetToDefault(Label lblPheDuocDanh, Label lblSoLuotDi, Button btnNewGame, Button btnUndo)
        {
            QuanCoBiLoai = null;
            QuanCoDuocChon = null;
            PheDuocDanh = MauPheTa;
            SoLuotDi = 0;

            WritePheDuocDanh(lblPheDuocDanh);
            lblSoLuotDi.Text = SoLuotDi.ToString();
            btnNewGame.Enabled = false;
            btnUndo.Enabled = false;
        }

        /* Xóa các RoundPictureBox quân cờ khỏi bàn cờ và danh sách quân cờ */
        public static void XoaBanCo(PictureBox ptbBanCo)
        {
            ptbBanCo.Controls.Clear();
            TuongXanh = null;
            TuongDo = null;
            Alive_QuanCo.Clear();
            Alive_RoundPictureBox.Clear();
            NuocDiTruocDo.Clear();
        }

        public static void Highlight(PictureBox ptbBanCo)
        {
            YellowTarget.Location = new Point(QuanCoDuocChon.Location.X - 1, QuanCoDuocChon.Location.Y - 1);
            YellowTarget.Parent = ptbBanCo;
        }

        public static void Dehighlight()
        {
            YellowTarget.Parent = null;
        }

        /* Tính toán và hiển thị tất cả điểm đích của quân cờ được chọn */
        public static void HienThiDiemDich() // Vẽ các điểm đích của quân cờ đang được chọn
        {
            QuanCoDuocChon.Quan_Co.DanhSachDiemDich.Clear();
            QuanCoDuocChon.Quan_Co.TinhNuocDi();
            foreach (Point element in QuanCoDuocChon.Quan_Co.DanhSachDiemDich)
            {
                QuanCo target = Alive_QuanCo.Find(element1 => element1.Mau != QuanCoDuocChon.Quan_Co.Mau && element1.ToaDo == element);
                if (target != null)
                    DiemBanCo[element.X, element.Y].BackColor = Color.Red;
                DiemBanCo[element.X, element.Y].Visible = true;
                DiemBanCo[element.X, element.Y].BringToFront();
            }
        }
        /* Ẩn tất cả các điểm đích đang hiển thị trên bàn cờ */
        public static void AnDiemDich()
        {
            foreach (ProgramConfig.RoundButton element in DiemBanCo)
            {
                element.Visible = false;
                element.BackColor = Color.Yellow;
            }
        }

        public static void LoaiBoQuanCo(Point viTri, PictureBox ptbBanCo)
        {
            QuanCoBiLoai = Alive_RoundPictureBox.Find(element => element.Quan_Co.Mau != PheDuocDanh && element.Quan_Co.ToaDo == viTri);
            if (QuanCoBiLoai != null)
            {
                ptbBanCo.Controls.Remove(QuanCoBiLoai);
                Alive_RoundPictureBox.Remove(QuanCoBiLoai);
                Alive_QuanCo.Remove(QuanCoBiLoai.Quan_Co);
            }
        }

        /* Trả lại một quân cờ bị loại khỏi bàn cờ */
        public static void TraLaiQuanCo(PictureBox ptbBanCo, ProgramConfig.RoundPictureBox quanCoCanTraLai)
        {
            if (quanCoCanTraLai != null)
            {
                Alive_QuanCo.Add(quanCoCanTraLai.Quan_Co);
                Alive_RoundPictureBox.Add(quanCoCanTraLai);
                ptbBanCo.Controls.Add(quanCoCanTraLai);
            }
        }

        public static int PheDoiPhuong()
        {
            if (PheDuocDanh == 1)
                return 2;
            return 1;
        }

        public static bool HaiTuongDoiMatNhau()
        {
            if (TuongXanh.ToaDo.X == TuongDo.ToaDo.X) // nếu 2 tướng cùng hoành độ (thẳng hàng) ...
            {
                int X = TuongXanh.ToaDo.X;
                if (MauPheTa == 2)
                {
                    for (int Y = TuongXanh.ToaDo.Y + 1; Y < TuongDo.ToaDo.Y; Y++) // ... thì xét xem giữa 2 tướng có quân cờ nào không
                    {
                        Point diemGiuaHaiTuong = new Point(X, Y);
                        if (CoQuanCoTaiDay(diemGiuaHaiTuong))
                            return false; // nếu có 1 quân cờ ở giữa 2 tướng thì 2 tướng không đối mặt nhau
                    }
                    return true; // nếu không có quân cờ nào ở giữa 2 tướng thì 2 tướng đối mặt nhau
                }
                else if (MauPheTa == 1)
                {
                    for (int Y = TuongXanh.ToaDo.Y - 1; Y > TuongDo.ToaDo.Y; Y--) // ... thì xét xem giữa 2 tướng có quân cờ nào không
                    {
                        Point diemGiuaHaiTuong = new Point(X, Y);
                        if (CoQuanCoTaiDay(diemGiuaHaiTuong))
                            return false; // nếu có 1 quân cờ ở giữa 2 tướng thì 2 tướng không đối mặt nhau
                    }
                    return true;
                }
            }
            return false; // nếu 2 tướng không cùng hoành độ thì 2 tướng không đối mặt nhau
        }

        public static bool CoChieuTuong(int pheChieuTuong)
        {
            foreach (QuanCo element in Alive_QuanCo)
            {
                if (element.Mau == pheChieuTuong)
                {
                    element.DanhSachDiemDich.Clear();
                    element.TinhNuocDi();
                    foreach (Point element1 in element.DanhSachDiemDich)
                    {
                        QuanCo target = Alive_QuanCo.Find(element2 => element2.Mau != pheChieuTuong && element2.ToaDo == element1);
                        if (target != null && (target == TuongXanh || target == TuongDo))
                            return true;
                    }
                }
            }
            return false;
        }

        /* Đổi phe sau mỗi nước đi thành công */
        public static void DoiPhe(Label lblPheDuocDanh, Label lblSoLuotDi, Button btnNewGame, Button btnUndo)
        {
            QuanCoBiLoai = null;
            QuanCoDuocChon = null;
            PheDuocDanh = PheDoiPhuong();
            SoLuotDi++;

            WritePheDuocDanh(lblPheDuocDanh);
            lblSoLuotDi.Text = SoLuotDi.ToString();
            if (SoLuotDi != 0)
            {
                btnNewGame.Enabled = true;
                btnUndo.Enabled = true;
            }
            else
            {
                btnNewGame.Enabled = false;
                btnUndo.Enabled = false;
            }
            RefreshBanCo();
        }

        /* Đổi phe cho sự kiện undo */
        public static void DoiPhe(Label lblPheDuocDanh, Label lblSoLuotDi, Button btnNewGame)
        {
            QuanCoBiLoai = null;
            QuanCoDuocChon = null;
            PheDuocDanh = PheDoiPhuong();
            SoLuotDi--;

            WritePheDuocDanh(lblPheDuocDanh);
            lblSoLuotDi.Text = SoLuotDi.ToString();
            if (SoLuotDi != 0)
            {
                btnNewGame.Enabled = true;
            }
            else
            {
                btnNewGame.Enabled = false;
            }
            RefreshBanCo();
        }

        /* Hiển thị nước đi sau mỗi nước đi thành công */
        public static void HienThiNuocDi(Point departure, Point destination, PictureBox ptbBanCo)
        {
            NuocDiTruocDo.PrevGreyTargetDepartureLocation = GreyTargetDeparture.Location;
            NuocDiTruocDo.PrevGreyTargetDestinationLocation = GreyTargetDestination.Location;
            GreyTargetDeparture.Location = new Point(ProgramConfig.ThongSo.ToaDoBanCoCuaQuanCo(departure).X + 10, ProgramConfig.ThongSo.ToaDoBanCoCuaQuanCo(departure).Y + 10);
            GreyTargetDestination.Location = new Point(ProgramConfig.ThongSo.ToaDoBanCoCuaQuanCo(destination).X - 1, ProgramConfig.ThongSo.ToaDoBanCoCuaQuanCo(destination).Y - 1);
            if (SoLuotDi == 0)
            {
                GreyTargetDeparture.Parent = ptbBanCo;
                GreyTargetDestination.Parent = ptbBanCo;
            }
        }

        /* Hiển thị nước đi cho sự kiện undo */
        public static void HienThiNuocDiTruoc(PictureBox ptbBanCo)
        {
            GreyTargetDeparture.Location = NuocDiTruocDo.PrevGreyTargetDepartureLocation;
            GreyTargetDestination.Location = NuocDiTruocDo.PrevGreyTargetDestinationLocation;
            if (SoLuotDi == 0)
            {
                GreyTargetDeparture.Parent = null;
                GreyTargetDestination.Parent = null;
            }
        }

        public static void LuuNuocDi(Point departure, Point destination)
        {
            NuocDiTruocDo.ToaDoDi = new Point(departure.X, departure.Y);
            NuocDiTruocDo.ToaDoDen = new Point(destination.X, destination.Y);
            NuocDiTruocDo.QuanCoDiChuyen = QuanCoDuocChon;
            NuocDiTruocDo.QuanCoBiLoai = QuanCoBiLoai;
        }

        public static void HoanTac(PictureBox ptbBanCo)
        {
            NuocDiTruocDo.QuanCoDiChuyen.DiChuyen(NuocDiTruocDo.ToaDoDi);
            TraLaiQuanCo(ptbBanCo, NuocDiTruocDo.QuanCoBiLoai);
        }

        #endregion
    }
}
