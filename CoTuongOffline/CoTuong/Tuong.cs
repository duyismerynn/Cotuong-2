using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CoTuongOffline.ProgramConfig;

namespace CoTuongOffline.CoTuong
{
    public class Tuong : Quanco
    {
        public Tuong() { }

        public Tuong(Point toaDoBanDau)
        {
            Toado = toaDoBanDau;
            Danhsach_Diemdich = new List<Point>();
            if (Banco.Mau_Pheta == 2)
                Mau = Thongso_Phedo.Mau_Quanco(toaDoBanDau);
            else if (Banco.Mau_Pheta == 1)
                Mau = Thongso_Phexanh.Mau_Quanco(toaDoBanDau);
            Banco.Alive_Quanco.Add(this);
            if (Mau == 1)
                Banco.Tuongxanh = this;
            else if (Mau == 2)
                Banco.Tuongdo = this;
        }

        public override void TinhNuocDi()
        {
            Point toaDoMucTieu;
            Quanco quanCoMucTieu;

            toaDoMucTieu = new Point(Toado.X + 1, Toado.Y);
            if (NamTrongCung(toaDoMucTieu))
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

            toaDoMucTieu = new Point(Toado.X - 1, Toado.Y);
            if (NamTrongCung(toaDoMucTieu))
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

            toaDoMucTieu = new Point(Toado.X, Toado.Y + 1);
            if (NamTrongCung(toaDoMucTieu))
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

            toaDoMucTieu = new Point(Toado.X, Toado.Y - 1);
            if (NamTrongCung(toaDoMucTieu))
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

        private bool NamTrongCung(Point point)
        {
            if (Banco.Mau_Pheta == 2)
            {
                if (Mau == 1)
                    if ((point.X >= 3 && point.X <= 5 && point.Y >= 0 && point.Y <= 2))
                        return true;
                if (Mau == 2)
                    if (point.X >= 3 && point.X <= 5 && point.Y >= 7 && point.Y <= 9)
                        return true;
            }
            else if (Banco.Mau_Pheta == 1)
            {
                if (Mau == 2)
                    if ((point.X >= 3 && point.X <= 5 && point.Y >= 0 && point.Y <= 2))
                        return true;
                if (Mau == 1)
                    if (point.X >= 3 && point.X <= 5 && point.Y >= 7 && point.Y <= 9)
                        return true;
            }
            return false;
        }
    }
}