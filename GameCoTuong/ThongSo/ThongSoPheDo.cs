using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoTuongLAN.ProgramConfig
{
    public static class ThongSoPheDo
    {
        #region Tọa độ đơn vị ban đầu của tất cả quân cờ
        /* PHE XANH */

        /* Tướng Xanh */
        public static Point ToaDoTuongXanh { get { return new Point(4, 0); } }

        /* Xe Xanh */
        public static Point ToaDoXeXanh1 { get { return new Point(0, 0); } }

        public static Point ToaDoXeXanh2 { get { return new Point(8, 0); } }

        /* Mã Xanh */
        public static Point ToaDoMaXanh1 { get { return new Point(1, 0); } }

        public static Point ToaDoMaXanh2 { get { return new Point(7, 0); } }

        /* Tịnh Xanh */
        public static Point ToaDoTinhXanh1 { get { return new Point(2, 0); } }

        public static Point ToaDoTinhXanh2 { get { return new Point(6, 0); } }

        /* Sĩ Xanh */
        public static Point ToaDoSiXanh1 { get { return new Point(3, 0); } }

        public static Point ToaDoSiXanh2 { get { return new Point(5, 0); } }

        /* Pháo Xanh */
        public static Point ToaDoPhaoXanh1 { get { return new Point(1, 2); } }

        public static Point ToaDoPhaoXanh2 { get { return new Point(7, 2); } }

        /* Tốt Xanh */
        public static Point ToaDoTotXanh1 { get { return new Point(0, 3); } }

        public static Point ToaDoTotXanh2 { get { return new Point(2, 3); } }

        public static Point ToaDoTotXanh3 { get { return new Point(4, 3); } }

        public static Point ToaDoTotXanh4 { get { return new Point(6, 3); } }

        public static Point ToaDoTotXanh5 { get { return new Point(8, 3); } }

        /* PHE ĐỎ */

        /* Tướng Đỏ */
        public static Point ToaDoTuongDo { get { return new Point(4, 9); } }

        /* Xe Đỏ */
        public static Point ToaDoXeDo1 { get { return new Point(8, 9); } }

        public static Point ToaDoXeDo2 { get { return new Point(0, 9); } }

        /* Mã Đỏ */
        public static Point ToaDoMaDo1 { get { return new Point(7, 9); } }

        public static Point ToaDoMaDo2 { get { return new Point(1, 9); } }

        /* Tịnh Đỏ */
        public static Point ToaDoTinhDo1 { get { return new Point(6, 9); } }

        public static Point ToaDoTinhDo2 { get { return new Point(2, 9); } }

        /* Sĩ Đỏ */
        public static Point ToaDoSiDo1 { get { return new Point(5, 9); } }

        public static Point ToaDoSiDo2 { get { return new Point(3, 9); } }

        /* Pháo Đỏ */
        public static Point ToaDoPhaoDo1 { get { return new Point(7, 7); } }

        public static Point ToaDoPhaoDo2 { get { return new Point(1, 7); } }

        /* Tốt Đỏ */
        public static Point ToaDoTotDo1 { get { return new Point(8, 6); } }

        public static Point ToaDoTotDo2 { get { return new Point(6, 6); } }

        public static Point ToaDoTotDo3 { get { return new Point(4, 6); } }

        public static Point ToaDoTotDo4 { get { return new Point(2, 6); } }

        public static Point ToaDoTotDo5 { get { return new Point(0, 6); } }
        #endregion

        #region Hàm tính toán
        public static int MauQuanCo(Point toaDoBanDau) // xác định màu quân cờ dựa vào TDDV ban đầu của nó
        {
            if (toaDoBanDau == ToaDoTuongXanh ||
                toaDoBanDau == ToaDoXeXanh1 || toaDoBanDau == ToaDoXeXanh2 ||
                toaDoBanDau == ToaDoMaXanh1 || toaDoBanDau == ToaDoMaXanh2 ||
                toaDoBanDau == ToaDoTinhXanh1 || toaDoBanDau == ToaDoTinhXanh2 ||
                toaDoBanDau == ToaDoSiXanh1 || toaDoBanDau == ToaDoSiXanh2 ||
                toaDoBanDau == ToaDoPhaoXanh1 || toaDoBanDau == ToaDoPhaoXanh2 ||
                toaDoBanDau == ToaDoTotXanh1 ||
                toaDoBanDau == ToaDoTotXanh2 ||
                toaDoBanDau == ToaDoTotXanh3 ||
                toaDoBanDau == ToaDoTotXanh4 ||
                toaDoBanDau == ToaDoTotXanh5)
                return 1;
            return 2;
        }
        #endregion
    }
}