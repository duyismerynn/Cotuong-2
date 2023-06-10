using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongOffline.ProgramConfig
{
    public static class Thongso
    {
        // Tọa độ đơn vị (TDDV): toạ độ theo 2 trục XY dùng để tạo các điểm trên bàn cờ
        // Tọa độ bàn cờ (TDBC) là tọa độ đơn vị pixel trong winform
        // Gốc tọa độ trên bàn cờ của điểm bàn cờ và quân cờ không trùng nhau, do đó TDBC của chúng cũng khác nhau. Nhưng chúng lại dùng chung TDDV
        #region Gốc tọa độ bàn cờ và khoảng cách
        public static int Gocdiem_Banco_X { get { return 44; } } // hoành độ gốc của điểm bàn cờ trên bàn cờ: góc trái trên

        public static int Gocdiem_Banco_Y { get { return 42; } } // tung độ gốc của điểm bàn cờ trên bàn cờ: góc trái trên

        public static int Goc_Quanco_X { get { return 31; } } // hoành độ gốc của quân cờ trên bàn cờ: góc trái trên

        public static int Goc_Quanco_Y { get { return 30; } } // tung độ gốc của quân cờ trên bàn cờ: góc trái trên

        public static int Khoangcach { get { return 61; } } // khoảng cách giữa các điểm bàn cờ & quân cờ

        // Toạ độ NULL
        public static Point Toado_NULL { get { return new Point(-1, -1); } }
        #endregion

        #region Kích thước quân cờ, điểm bàn cờ và bàn cờ
        // Quân cờ
        public static int Duongkinh_Quanco { get { return 56; } } // đường kính quân cờ

        // Điểm bàn cờ
        public static int Duongkinh_diem { get { return 30; } } // đường kính điểm bàn cờ

        // Bàn cờ
        public static Point Toado_Banco { get { return new Point(0, 0); } } // tọa độ của bàn cờ trong winform

        public static int Chieurong_Banco { get { return 607; } } // chiều rộng bàn cờ

        public static int Chieudai_Banco { get { return 662; } } // chiều dài bàn cờ
        #endregion

        #region Hàm tính toán

        public static Point TDBC_Diem(int x, int y) // TDDV -> TDBC
        {
            return new Point(Gocdiem_Banco_X + x * Khoangcach, Gocdiem_Banco_Y + y * Khoangcach);
        }

        public static Point TDBC_Diem(Point TDDV)
        {
            return TDBC_Diem(TDDV.X, TDDV.Y);
        }

        public static Point TDBC_Quanco(int x, int y) // TDDV -> TDBC
        {
            return new Point(Goc_Quanco_X + x * Khoangcach, Goc_Quanco_Y + y * Khoangcach);
        }

        public static Point TDBC_Quanco(Point TDDV)
        {
            return TDBC_Quanco(TDDV.X, TDDV.Y);
        }

        public static Point TDDV_Diem(int X, int Y) // TDBC -> TDDV
        {
            return new Point((X - Gocdiem_Banco_X) / Khoangcach, (Y - Gocdiem_Banco_Y) / Khoangcach);
        }

        public static Point TDDV_Cua_Diem(Point TDBC)
        {
            return TDDV_Diem(TDBC.X, TDBC.Y);
        }

        public static Point TDDV_Cua_Quanco(int X, int Y)  // TDBC -> TDDV
        {
            return new Point((X - Goc_Quanco_X) / Khoangcach, (Y - Goc_Quanco_Y) / Khoangcach);
        }
        public static Point TDDV_Cua_Quanco(Point TDBC)
        {
            return TDDV_Cua_Quanco(TDBC.X, TDBC.Y);
        }

        public static Point Toado_Diem_Sang_Quanco(int X_DiemBanCo, int Y_DiemBanCo) // TDBC điểm -> TDBC quân cờ
        {
            return TDBC_Quanco(TDDV_Diem(X_DiemBanCo, Y_DiemBanCo));
        }
        public static Point Toado_Diem_Sang_Quanco(Point toado_Diem)
        {
            return Toado_Diem_Sang_Quanco(toado_Diem.X, toado_Diem.Y);
        }

        public static Point Toado_Quanco_Sang_Diem(int X_QuanCo, int Y_QuanCo) // TDBC quân cờ -> TDBC điểm
        {
            return TDBC_Diem(TDDV_Cua_Quanco(X_QuanCo, Y_QuanCo));
        }
        public static Point Toado_Quanco_Sang_Diem(Point toado_Quanco)
        {
            return Toado_Quanco_Sang_Diem(toado_Quanco.X, toado_Quanco.Y);
        }

        public static Point[] Nuocdi_Doithu(string input)
        {
            Point[] nuocdi = new Point[2];
            Point diemdi = new Point();
            Point diemden = new Point();
            diemdi.X = 8 - int.Parse(input[0].ToString());
            diemdi.Y = 9 - int.Parse(input[1].ToString());
            diemden.X = 8 - int.Parse(input[2].ToString());
            diemden.Y = 9 - int.Parse(input[3].ToString());
            nuocdi[0] = diemdi;
            nuocdi[1] = diemden;
            return nuocdi;
        }

        public static string Nuocdi_ta(Point[] nuocdi)
        {
            return nuocdi[0].X.ToString() + nuocdi[0].Y.ToString() + nuocdi[1].X.ToString() + nuocdi[1].Y.ToString();
        }

        #endregion
    }
}