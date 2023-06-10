using CoTuongOffline.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTuongOffline.Cotuong
{
    public class Quanco
    {

        public Point Toado { get; protected set; }

        public int Mau { get; protected set; } // xanh 1, đỏ 2

        public List<Point> Danhsach_Diemdich { get; protected set; }

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

        public virtual void Tinh_Nuocdi() { }

        public void Dichuyen(Point location)
        {
            Toado = location;
            Danhsach_Diemdich.Clear();
        }

        public bool Namtrong_Banco(int X, int Y) // kiểm tra toạ độ có thuộc từ (0,0) đến (8,9) không 
        {
            if (X < 0 || X > 8 || Y < 0 || Y > 9)
                return false;
            return true;
        }

        public bool Namtrong_Banco(Point diem)
        {
            return Namtrong_Banco(diem.X, diem.Y);
        }
    }
}