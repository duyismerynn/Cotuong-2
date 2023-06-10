using CoTuongOffline.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongOffline.Cotuong
{
    public class Xe : Quanco
    {
        public Xe() { }

        public Xe(Point toado_Bandau)
        {
            Toado = toado_Bandau;
            Danhsach_Diemdich = new List<Point>();
            if (Banco.Mau_Pheta == 2)
                Mau = Bandau_Phedo.Mau_Quanco(toado_Bandau);
            else if (Banco.Mau_Pheta == 1)
                Mau = Bandau_Phexanh.Mau_Quanco(toado_Bandau);
            Banco.Alive_Quanco.Add(this);
        }

        public override void Tinh_Nuocdi()
        {
            Point toado_Muctieu;
            Quanco quanco_Muctieu;
            // Xét 4 hướng thẳng, tập điểm đích chạy vòng lặp dọc theo 4 hướng, dừng lại khi gặp quân (kiểm tra khác màu thì ăn được)
            // if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // không có quân
            // else // có quân

            // Xét bên trái
            for (int x = Toado.X - 1; x >= 0; x--)
            {
                toado_Muctieu = new Point(x, Toado.Y);
                if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                    Danhsach_Diemdich.Add(toado_Muctieu);
                else
                {
                    quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                    if (quanco_Muctieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    break;
                }
            }

            // Xét bên phải
            for (int x = Toado.X + 1; x < 9; x++)
            {
                toado_Muctieu = new Point(x, Toado.Y);
                if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                    Danhsach_Diemdich.Add(toado_Muctieu);
                else
                {
                    quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                    if (quanco_Muctieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    break;
                }
            }

            // Xét bên trên
            for (int y = Toado.Y - 1; y >= 0; y--)
            {
                toado_Muctieu = new Point(Toado.X, y);
                if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                    Danhsach_Diemdich.Add(toado_Muctieu);
                else
                {
                    quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                    if (quanco_Muctieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    break;
                }
            }

            // Xét bên dưới
            for (int y = Toado.Y + 1; y < 10; y++)
            {
                toado_Muctieu = new Point(Toado.X, y);
                if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                    Danhsach_Diemdich.Add(toado_Muctieu);
                else
                {
                    quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                    if (quanco_Muctieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    break;
                }
            }
        }
    }
}