using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoTuongOffline.ProgramConfig
{
    public static class Thongso_Phedo
    {
        #region Tọa độ đơn vị ban đầu của tất cả quân cờ
        
        // Xanh

        // Tướng
        public static Point Toado_Tuongxanh { get { return new Point(4, 0); } }

        // Xe
        public static Point Toado_Xexanh_1 { get { return new Point(0, 0); } }

        public static Point Toado_Xexanh_2 { get { return new Point(8, 0); } }

        // Mã
        public static Point Toado_Maxanh_1 { get { return new Point(1, 0); } }

        public static Point Toado_Maxanh_2 { get { return new Point(7, 0); } }

        // Tịnh
        public static Point Toado_Tinhxanh_1 { get { return new Point(2, 0); } }

        public static Point Toado_Tinhxanh_2 { get { return new Point(6, 0); } }

        // Sĩ
        public static Point Toado_Sixanh_1 { get { return new Point(3, 0); } }

        public static Point Toado_Sixanh_2 { get { return new Point(5, 0); } }

        // Pháo
        public static Point Toado_Phaoxanh_1 { get { return new Point(1, 2); } }

        public static Point Toado_Phaoxanh_2 { get { return new Point(7, 2); } }

        // Tốt
        public static Point Toado_Totxanh_1 { get { return new Point(0, 3); } }

        public static Point Toado_Totxanh_2 { get { return new Point(2, 3); } }

        public static Point Toado_Totxanh_3 { get { return new Point(4, 3); } }

        public static Point Toado_Totxanh_4 { get { return new Point(6, 3); } }

        public static Point Toado_Totxanh_5 { get { return new Point(8, 3); } }

        // Đỏ

        // Tướng
        public static Point Toado_Tuongdo { get { return new Point(4, 9); } }

        // Xe
        public static Point Toado_Xedo_1 { get { return new Point(8, 9); } }

        public static Point Toado_Xedo_2 { get { return new Point(0, 9); } }

        // Mã
        public static Point Toado_Mado_1 { get { return new Point(7, 9); } }

        public static Point Toado_Mado_2 { get { return new Point(1, 9); } }

        // Tịnh
        public static Point Toado_Tinhdo_1 { get { return new Point(6, 9); } }

        public static Point Toado_Tinhdo_2 { get { return new Point(2, 9); } }

        // Sĩ
        public static Point Toado_Sido_1 { get { return new Point(5, 9); } }

        public static Point Toado_Sido_2 { get { return new Point(3, 9); } }

        // Pháo
        public static Point Toado_Phaodo_1 { get { return new Point(7, 7); } }

        public static Point Toado_Phaodo_2 { get { return new Point(1, 7); } }

        // Tốt
        public static Point Toado_Totdo_1 { get { return new Point(8, 6); } }

        public static Point Toado_Totdo_2 { get { return new Point(6, 6); } }

        public static Point Toado_Totdo_3 { get { return new Point(4, 6); } }

        public static Point Toado_Totdo_4 { get { return new Point(2, 6); } }

        public static Point Toado_Totdo_5 { get { return new Point(0, 6); } }
        #endregion

        #region Hàm tính toán
        public static int Mau_Quanco(Point toado_Bandau) // xác định màu quân cờ dựa vào TDDV ban đầu của nó
        {
            if (toado_Bandau == Toado_Tuongxanh ||
                toado_Bandau == Toado_Xexanh_1 || toado_Bandau == Toado_Xexanh_2 ||
                toado_Bandau == Toado_Maxanh_1 || toado_Bandau == Toado_Maxanh_2 ||
                toado_Bandau == Toado_Tinhxanh_1 || toado_Bandau == Toado_Tinhxanh_2 ||
                toado_Bandau == Toado_Sixanh_1 || toado_Bandau == Toado_Sixanh_2 ||
                toado_Bandau == Toado_Phaoxanh_1 || toado_Bandau == Toado_Phaoxanh_2 ||
                toado_Bandau == Toado_Totxanh_1 ||
                toado_Bandau == Toado_Totxanh_2 ||
                toado_Bandau == Toado_Totxanh_3 ||
                toado_Bandau == Toado_Totxanh_4 ||
                toado_Bandau == Toado_Totxanh_5)
                return 1;
            return 2;
        }
        #endregion
    }
}