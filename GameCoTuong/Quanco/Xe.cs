using CoTuongLAN.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongLAN.Cotuong
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
            Point toaDoMucTieu;
            Quanco quanCoMucTieu;
            // Xét 4 hướng thẳng, tập điểm đích chạy vòng lặp dọc theo 4 hướng, dừng lại khi gặp quân (kiểm tra khác màu thì ăn được)
            // if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // không có quân
            // else // có quân

            // Xét bên trái
            for (int x = Toado.X - 1; x >= 0; x--)
            {
                toaDoMucTieu = new Point(x, Toado.Y);
                if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                    Danhsach_Diemdich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toaDoMucTieu);
                    break;
                }
            }

            // Xét bên phải
            for (int x = Toado.X + 1; x < 9; x++)
            {
                toaDoMucTieu = new Point(x, Toado.Y);
                if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                    Danhsach_Diemdich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toaDoMucTieu);
                    break;
                }
            }

            // Xét bên trên
            for (int y = Toado.Y - 1; y >= 0; y--)
            {
                toaDoMucTieu = new Point(Toado.X, y);
                if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                    Danhsach_Diemdich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toaDoMucTieu);
                    break;
                }
            }

            // Xét bên dưới
            for (int y = Toado.Y + 1; y < 10; y++)
            {
                toaDoMucTieu = new Point(Toado.X, y);
                if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                    Danhsach_Diemdich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toaDoMucTieu);
                    break;
                }
            }
        }
    }
}