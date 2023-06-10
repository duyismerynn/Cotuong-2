using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CoTuongLAN.ProgramConfig;

namespace CoTuongLAN.CoTuong
{
    public class Si : Quanco
    {
        public Si() { }

        public Si(Point toaDoBanDau)
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

            if (Banco.Mau_Pheta == 2)
            {
                if (Mau == 1)
                {
                    if (Toado == new Point(3, 0) || Toado == new Point(5, 0) || Toado == new Point(3, 2) || Toado == new Point(5, 2))
                    {
                        toaDoMucTieu = new Point(4, 1);
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }
                    }
                    else if (Toado == new Point(4, 1))
                    {
                        toaDoMucTieu = new Point(3, 0);
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 0);
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(3, 2);
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 2);
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }
                    }
                }
                else if (Mau == 2)
                {
                    if (Toado == new Point(3, 9) || Toado == new Point(5, 9) || Toado == new Point(3, 7) || Toado == new Point(5, 7))
                    {
                        toaDoMucTieu = new Point(4, 8);
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }
                    }
                    else if (Toado == new Point(4, 8))
                    {
                        toaDoMucTieu = new Point(3, 9);//
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 9);//
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(3, 7);//
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 7);//
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }
                    }
                }
            }
            else if (Banco.Mau_Pheta == 1)
            {
                if (Mau == 2)
                {
                    if (Toado == new Point(3, 0) || Toado == new Point(5, 0) || Toado == new Point(3, 2) || Toado == new Point(5, 2))
                    {
                        toaDoMucTieu = new Point(4, 1);
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }
                    }
                    else if (Toado == new Point(4, 1))
                    {
                        toaDoMucTieu = new Point(3, 0);
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 0);
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(3, 2);
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 2);
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }
                    }
                }
                else if (Mau == 1)
                {
                    if (Toado == new Point(3, 9) || Toado == new Point(5, 9) || Toado == new Point(3, 7) || Toado == new Point(5, 7))
                    {
                        toaDoMucTieu = new Point(4, 8);
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }
                    }
                    else if (Toado == new Point(4, 8))
                    {
                        toaDoMucTieu = new Point(3, 9);//
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 9);//
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(3, 7);//
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 7);//
                        if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        {
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }
                    }
                }
            }
        }
    }
}