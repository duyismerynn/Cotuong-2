using CoTuongLAN.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTuongLAN.CoTuong
{
    public class Quanco
    {
        #region properties

        public Point Toado { get; protected set; }

        public int Mau { get; protected set; } // xanh 1, đỏ 2;

        public List<Point> Danhsach_Diemdich { get; protected set; }

        #endregion

        #region methods

        public Quanco() { }

        public Quanco(int X, int Y)
        {
            Toado = new Point(X, Y);
        }

        public Quanco(Point toaDoBanDau)
        {
            if (toaDoBanDau == Thongso.Toado_NULL)
                Mau = 0;
            Toado = toaDoBanDau;
        }

        public virtual void TinhNuocDi() { }

        public void DiChuyen(Point location)
        {
            Toado = location;
            Danhsach_Diemdich.Clear();
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