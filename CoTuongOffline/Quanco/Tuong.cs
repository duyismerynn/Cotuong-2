using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CoTuongOffline.ProgramConfig;

namespace CoTuongOffline.Cotuong
{
    public class Tuong : Quanco
    {
        public Tuong() { }

        public Tuong(Point toado_Bandau)
        {
            Toado = toado_Bandau;
            Danhsach_Diemdich = new List<Point>();
            if (Banco.Mau_Pheta == 2)
                Mau = Bandau_Phedo.Mau_Quanco(toado_Bandau);
            else if (Banco.Mau_Pheta == 1)
                Mau = Bandau_Phexanh.Mau_Quanco(toado_Bandau);
            Banco.Alive_Quanco.Add(this);
            if (Mau == 1)
                Banco.Tuongxanh = this;
            else if (Mau == 2)
                Banco.Tuongdo = this;
        }

        public override void Tinh_Nuocdi()
        {
            Point toado_Muctieu;
            Quanco quanco_Muctieu;
            // if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // không có quân
            // else // có quân

            toado_Muctieu = new Point(Toado.X + 1, Toado.Y); // di chuyển sang phải
            if (Namtrongcung(toado_Muctieu))
            {
                if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                    Danhsach_Diemdich.Add(toado_Muctieu);
                else
                {
                    quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                    if (quanco_Muctieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toado_Muctieu);
                }
            }

            toado_Muctieu = new Point(Toado.X - 1, Toado.Y); // di chuyển sang trái
            if (Namtrongcung(toado_Muctieu))
            {

                if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                    Danhsach_Diemdich.Add(toado_Muctieu);
                else
                {
                    quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                    if (quanco_Muctieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toado_Muctieu);
                }
            }

            toado_Muctieu = new Point(Toado.X, Toado.Y + 1); // di chuyển xuống dưới
            if (Namtrongcung(toado_Muctieu))
            {
                if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                    Danhsach_Diemdich.Add(toado_Muctieu);
                else
                {
                    quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                    if (quanco_Muctieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toado_Muctieu);
                }
            }

            toado_Muctieu = new Point(Toado.X, Toado.Y - 1); // di chuyển lên trên
            if (Namtrongcung(toado_Muctieu))
            {
                if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                    Danhsach_Diemdich.Add(toado_Muctieu);
                else
                {
                    quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                    if (quanco_Muctieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toado_Muctieu);
                }
            }
        }

        private bool Namtrongcung(Point point) // khu vực 9 ô trong cung mà tướng được phép di chuyển 
        {
            if (Banco.Mau_Pheta == 2) // phe ta là đỏ (dưới)
            {
                if (Mau == 1) // xanh (trên)
                    if ((point.X >= 3 && point.X <= 5 && point.Y >= 0 && point.Y <= 2))
                        return true;
                if (Mau == 2) // đỏ (dưới)
                    if (point.X >= 3 && point.X <= 5 && point.Y >= 7 && point.Y <= 9)
                        return true;
            }
            else if (Banco.Mau_Pheta == 1) // phe ta là xanh (dưới)
            {
                if (Mau == 2) // đỏ (trên)
                    if ((point.X >= 3 && point.X <= 5 && point.Y >= 0 && point.Y <= 2))
                        return true;
                if (Mau == 1) // xanh (dưới)
                    if (point.X >= 3 && point.X <= 5 && point.Y >= 7 && point.Y <= 9)
                        return true;
            }
            return false;
        }
    }
}