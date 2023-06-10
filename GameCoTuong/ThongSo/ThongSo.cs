using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongLAN.ProgramConfig
{
    public static class Thongso
    {
        // Tọa độ đơn vị (TDDV) là tọa độ của bàn cờ tướng đơn vị trong đó các đường thẳng song song cách nhau 1 đơn vị
        // Tọa độ bàn cờ (TDBC) là tọa độ của bàn cờ thực sự trên WinForm
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

        //Điểm bàn cờ
        public static int Duongkinh_Diem { get { return 30; } } // đường kính điểm bàn cờ

        // Bàn cờ
        public static Point Toado_Banco { get { return new Point(0, 0); } } // tọa độ bàn cờ trong WinForm

        public static int Chieurong_Banco { get { return 607; } } // chiều rộng bàn cờ

        public static int Chieudai_Banco { get { return 662; } } // chiều dài bàn cờ
        #endregion

        #region Hàm tính toán

        public static Point ToaDoBanCoCuaDiem(int x, int y) // TDDV -> TDBC // toi day
        {
            return new Point(Gocdiem_Banco_X + x * Khoangcach, Gocdiem_Banco_Y + y * Khoangcach);
        }

        public static Point ToaDoBanCoCuaDiem(Point toaDoDonVi)
        {
            return ToaDoBanCoCuaDiem(toaDoDonVi.X, toaDoDonVi.Y);
        }

        public static Point ToaDoBanCoCuaQuanCo(int x, int y) // hàm chuyển TDDV của quân cờ sang TDBC
        {
            return new Point(Goc_Quanco_X + x * Khoangcach, Goc_Quanco_Y + y * Khoangcach);
        }

        public static Point Toado_Banco_Cua_Quanco(Point toaDoDonVi)
        {
            return ToaDoBanCoCuaQuanCo(toaDoDonVi.X, toaDoDonVi.Y);
        }

        public static Point ToaDoDonViCuaDiem(int X, int Y) // hàm chuyển TDBC của điểm bàn cờ sang TDDV
        {
            return new Point((X - Gocdiem_Banco_X) / Khoangcach, (Y - Gocdiem_Banco_Y) / Khoangcach);
        }

        public static Point ToaDoDonViCuaDiem(Point toaDoBanCo)
        {
            return ToaDoDonViCuaDiem(toaDoBanCo.X, toaDoBanCo.Y);
        }

        public static Point ToaDoDonViCuaQuanCo(int X, int Y)  // hàm chuyển TDBC của quân cờ sang TDDV
        {
            return new Point((X - Goc_Quanco_X) / Khoangcach, (Y - Goc_Quanco_Y) / Khoangcach);
        }
        public static Point ToaDoDonViCuaQuanCo(Point toaDoBanCo)
        {
            return ToaDoDonViCuaQuanCo(toaDoBanCo.X, toaDoBanCo.Y);
        }

        public static Point ToaDoDiemSangQuanCo(int X_DiemBanCo, int Y_DiemBanCo) // hàm chuyển TDBC của điểm bàn cờ sang TDBC của quân cờ
        {
            return Toado_Banco_Cua_Quanco(ToaDoDonViCuaDiem(X_DiemBanCo, Y_DiemBanCo));
        }
        public static Point ToaDoDiemSangQuanCo(Point toaDoDiem)
        {
            return ToaDoDiemSangQuanCo(toaDoDiem.X, toaDoDiem.Y);
        }

        public static Point ToaDoQuanCoSangDiem(int X_QuanCo, int Y_QuanCo) // hàm chuyển TDBC của quân cờ sang TDBC của điểm bàn cờ
        {
            return ToaDoBanCoCuaDiem(ToaDoDonViCuaQuanCo(X_QuanCo, Y_QuanCo));
        }
        public static Point ToaDoQuanCoSangDiem(Point toaDoQuanCo)
        {
            return ToaDoQuanCoSangDiem(toaDoQuanCo.X, toaDoQuanCo.Y);
        }

        public static Point[] NuocDiCuaDoiThu(string input)
        {
            Point[] nuocDi = new Point[2];
            Point diemDi = new Point();
            Point diemDen = new Point();
            diemDi.X = 8 - int.Parse(input[0].ToString());
            diemDi.Y = 9 - int.Parse(input[1].ToString());
            diemDen.X = 8 - int.Parse(input[2].ToString());
            diemDen.Y = 9 - int.Parse(input[3].ToString());
            nuocDi[0] = diemDi;
            nuocDi[1] = diemDen;
            return nuocDi;
        }

        public static string NuocDiCuaTa(Point[] nuocDi)
        {
            return nuocDi[0].X.ToString() + nuocDi[0].Y.ToString() + nuocDi[1].X.ToString() + nuocDi[1].Y.ToString();
        }

        #endregion
    }
}