using CoTuongOffline.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongOffline.CoTuong
{
    public class Phao : Quanco
    {
        public Phao() { }

        public Phao(Point toaDoBanDau)
        {
            Toado = toaDoBanDau;
            Danhsach_Diemdich = new List<Point>();
            if (Banco.Mau_Pheta == 2)
                Mau = Thongso_Phedo.Mau_Quanco(toaDoBanDau);
            else if (Banco.Mau_Pheta == 1)
                Mau = Thongso_Phexanh.Mau_Quanco(toaDoBanDau);
            Banco.Alive_Quanco.Add(this);
        }

        public override void TinhNuocDi()
        {
            Point toaDoMucTieu;
            Quanco quanCoMucTieu;

            /* Xét nhánh các điểm đích BÊN TRÁI quân pháo */
            for (int x = Toado.X - 1; x >= 0; x--)
            {
                toaDoMucTieu = new Point(x, Toado.Y);
                if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                    Danhsach_Diemdich.Add(toaDoMucTieu);
                else
                {
                    for (x -= 1; x >= 0; x--)
                    {
                        toaDoMucTieu = new Point(x, Toado.Y);
                        if (Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            break;
                        }
                    }
                    break;
                }
            }

            /* Xét nhánh các điểm đích BÊN PHẢI quân pháo */
            for (int x = Toado.X + 1; x < 9; x++)
            {
                toaDoMucTieu = new Point(x, Toado.Y);
                if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                    Danhsach_Diemdich.Add(toaDoMucTieu);
                else
                {
                    for (x += 1; x < 9; x++)
                    {
                        toaDoMucTieu = new Point(x, Toado.Y);
                        if (Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            break;
                        }
                    }
                    break;
                }
            }

            /* Xét nhánh các điểm đích BÊN TRÊN quân pháo */
            for (int y = Toado.Y - 1; y >= 0; y--)
            {
                toaDoMucTieu = new Point(Toado.X, y);
                if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                    Danhsach_Diemdich.Add(toaDoMucTieu);
                else
                {
                    for (y -= 1; y >= 0; y--)
                    {
                        toaDoMucTieu = new Point(Toado.X, y);
                        if (Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            break;
                        }
                    }
                    break;
                }
            }

            /* Xét nhánh các điểm đích BÊN DƯỚI quân pháo */
            for (int y = Toado.Y + 1; y < 10; y++)
            {
                toaDoMucTieu = new Point(Toado.X, y);
                if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                    Danhsach_Diemdich.Add(toaDoMucTieu);
                else
                {
                    for (y += 1; y < 10; y++)
                    {
                        toaDoMucTieu = new Point(Toado.X, y);
                        if (Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}