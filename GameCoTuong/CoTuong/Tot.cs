using CoTuongLAN.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongLAN.CoTuong
{
    public class Tot : Quanco
    {
        public Tot() { }

        public Tot(Point toaDoBanDau)
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
            Point toaDoMucTieu = Thongso.Toado_NULL;
            Quanco quanCoMucTieu;

            if (Banco.Mau_Pheta == 2)
            {
                if (Mau == 1)
                    toaDoMucTieu = new Point(Toado.X, Toado.Y + 1);
                else if (Mau == 2)
                    toaDoMucTieu = new Point(Toado.X, Toado.Y - 1);
            }
            else if (Banco.Mau_Pheta == 1)
            {
                if (Mau == 2)
                    toaDoMucTieu = new Point(Toado.X, Toado.Y + 1);
                else if (Mau == 1)
                    toaDoMucTieu = new Point(Toado.X, Toado.Y - 1);
            }

            if (NamTrongBanCo(toaDoMucTieu))
            {
                if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                    Danhsach_Diemdich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        Danhsach_Diemdich.Add(toaDoMucTieu);
                }
            }

            if (QuaSong())
            {
                if (Banco.Mau_Pheta == 2)
                {
                    if (Mau == 1)
                    {
                        if (NamTrongBanCo(toaDoMucTieu))
                        {
                            toaDoMucTieu = new Point(Toado.X, Toado.Y + 1);
                            if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            else
                            {
                                quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                                if (quanCoMucTieu.Mau != this.Mau)
                                    Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }
                    }
                    else if (Mau == 2)
                    {
                        toaDoMucTieu = new Point(Toado.X, Toado.Y - 1);
                        if (NamTrongBanCo(toaDoMucTieu))
                        {
                            if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            else
                            {
                                quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                                if (quanCoMucTieu.Mau != this.Mau)
                                    Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }
                    }
                }
                else if (Banco.Mau_Pheta == 1)
                {
                    if (Mau == 2)
                    {
                        if (NamTrongBanCo(toaDoMucTieu))
                        {
                            toaDoMucTieu = new Point(Toado.X, Toado.Y + 1);
                            if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            else
                            {
                                quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                                if (quanCoMucTieu.Mau != this.Mau)
                                    Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }
                    }
                    else if (Mau == 1)
                    {
                        toaDoMucTieu = new Point(Toado.X, Toado.Y - 1);
                        if (NamTrongBanCo(toaDoMucTieu))
                        {
                            if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                                Danhsach_Diemdich.Add(toaDoMucTieu);
                            else
                            {
                                quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                                if (quanCoMucTieu.Mau != this.Mau)
                                    Danhsach_Diemdich.Add(toaDoMucTieu);
                            }
                        }
                    }
                }

                toaDoMucTieu = new Point(Toado.X - 1, Toado.Y);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        Danhsach_Diemdich.Add(toaDoMucTieu);
                    else
                    {
                        quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                    }
                }
                toaDoMucTieu = new Point(Toado.X + 1, Toado.Y);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toaDoMucTieu))
                        Danhsach_Diemdich.Add(toaDoMucTieu);
                    else
                    {
                        quanCoMucTieu = Banco.Get_Quanco(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toaDoMucTieu);
                    }
                }
            }
        }

        private bool QuaSong()
        {
            if (Banco.Mau_Pheta == 2)
            {
                if (Mau == 1) //Xanh
                {
                    if (Toado.Y > 4) return true;
                }
                else if (Mau == 2) //Do
                {
                    if (Toado.Y < 5) return true;
                }
            }
            else if (Banco.Mau_Pheta == 1)
            {
                if (Mau == 2) //Do
                {
                    if (Toado.Y > 4) return true;
                }
                else if (Mau == 1) //Xanh
                {
                    if (Toado.Y < 5) return true;
                }
            }
            return false;
        }
    }
}