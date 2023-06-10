using CoTuongOffline.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTuongOffline.CoTuong
{
    public class QuanCo
    {
        #region properties

        public Point ToaDo { get; protected set; }

        public int Mau { get; protected set; } // xanh 1, đỏ 2;

        public List<Point> DanhSachDiemDich { get; protected set; }

        #endregion

        #region methods

        public QuanCo() { }

        public QuanCo(int X, int Y)
        {
            ToaDo = new Point(X, Y);
        }

        public QuanCo(Point toaDoBanDau)
        {
            if (toaDoBanDau == ThongSo.ToaDoNULL)
                Mau = 0;
            ToaDo = toaDoBanDau;
        }

        public virtual void TinhNuocDi() { }

        public void DiChuyen(Point location)
        {
            ToaDo = location;
            DanhSachDiemDich.Clear();
        }

        public bool NamTrongBanCo(int X, int Y)
        {
            if (X < 0 || X > 8 || Y < 0 || Y > 9)
                return false;
            return true;
        }

        public bool NamTrongBanCo(Point diem)
        {
            return NamTrongBanCo(diem.X, diem.Y);
        }

        #endregion
    }
}