using CoTuongLAN.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongLAN.CoTuong
{
    public class Ma : Quanco
    {
        public Ma() { }

        public Ma(Point toaDoBanDau)
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
            Point diemCan;
            Point toaDoMucTieu;
            Quanco quanCoMucTieu;

            // Xét điểm cản(ToaDo.X - 1, ToaDo.Y)
            diemCan = new Point(Toado.X - 1, Toado.Y);
            if (NamTrongBanCo(diemCan) && !Banco.Ktra_Quanco_taivitri(diemCan))
            {
                toaDoMucTieu = new Point(Toado.X - 2, Toado.Y - 1);
                if (NamTrongBanCo(toaDoMucTieu))
                {
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
                toaDoMucTieu = new Point(Toado.X - 2, Toado.Y + 1);
                if (NamTrongBanCo(toaDoMucTieu))
                {
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

            // Xét điểm cản (ToaDo.X + 1, ToaDo.Y)
            diemCan = new Point(Toado.X + 1, Toado.Y);
            if (NamTrongBanCo(diemCan) && !Banco.Ktra_Quanco_taivitri(diemCan))
            {
                toaDoMucTieu = new Point(Toado.X + 2, Toado.Y - 1);
                if (NamTrongBanCo(toaDoMucTieu))
                {
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
                toaDoMucTieu = new Point(Toado.X + 2, Toado.Y + 1);
                if (NamTrongBanCo(toaDoMucTieu))
                {
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

            // Xét điểm cản (ToaDo.X, ToaDo.Y - 1)
            diemCan = new Point(Toado.X, Toado.Y - 1);
            if (NamTrongBanCo(diemCan) && !Banco.Ktra_Quanco_taivitri(diemCan))
            {
                toaDoMucTieu = new Point(Toado.X - 1, Toado.Y - 2);
                if (NamTrongBanCo(toaDoMucTieu))
                {
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
                toaDoMucTieu = new Point(Toado.X + 1, Toado.Y - 2);
                if (NamTrongBanCo(toaDoMucTieu))
                {
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

            // Xét điểm cản (ToaDo.X, ToaDo.Y + 1)
            diemCan = new Point(Toado.X, Toado.Y + 1);
            if (NamTrongBanCo(diemCan) && !Banco.Ktra_Quanco_taivitri(diemCan))
            {
                toaDoMucTieu = new Point(Toado.X - 1, Toado.Y + 2);
                if (NamTrongBanCo(toaDoMucTieu))
                {
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
                toaDoMucTieu = new Point(Toado.X + 1, Toado.Y + 2);
                if (NamTrongBanCo(toaDoMucTieu))
                {
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