using CoTuongLAN.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongLAN.Cotuong
{
    public class Tinh : Quanco
    {
        public Tinh() { }

        public Tinh(Point toado_Bandau)
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

            Point diemcan;
            Point toado_Muctieu;
            Quanco quanco_Muctieu;
            // Tương tự quân mã, xét điểm cản ở các hướng trước

            // if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // không có quân
            // else // có quân

            // Xét điểm cản chéo trái trên (X - 1, Y - 1)
            diemcan = new Point(Toado.X - 1, Toado.Y - 1);
            if (Namtrong_Nua_Banco(diemcan) && !Banco.Ktra_Quanco_taivitri(diemcan))
            {
                toado_Muctieu = new Point(Toado.X - 2, Toado.Y - 2);
                if (Namtrong_Nua_Banco(toado_Muctieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    else
                    {
                        quanco_Muctieu = Banco.Get_Quanco(toado_Muctieu);
                        if (quanco_Muctieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toado_Muctieu);
                    }
                }
            }

            // Xét điểm cản chéo trái dưới (X - 1, Y + 1)
            diemcan = new Point(Toado.X - 1, Toado.Y + 1);
            if (Namtrong_Nua_Banco(diemcan) && !Banco.Ktra_Quanco_taivitri(diemcan))
            {
                toado_Muctieu = new Point(Toado.X - 2, Toado.Y + 2);
                if (Namtrong_Nua_Banco(toado_Muctieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    else
                    {
                        quanco_Muctieu = Banco.Get_Quanco(toado_Muctieu);
                        if (quanco_Muctieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toado_Muctieu);
                    }
                }
            }

            // Xét điểm cản chéo phải trên (X + 1, Y - 1)
            diemcan = new Point(Toado.X + 1, Toado.Y - 1);
            if (Namtrong_Nua_Banco(diemcan) && !Banco.Ktra_Quanco_taivitri(diemcan))
            {
                toado_Muctieu = new Point(Toado.X + 2, Toado.Y - 2);
                if (Namtrong_Nua_Banco(toado_Muctieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    else
                    {
                        quanco_Muctieu = Banco.Get_Quanco(toado_Muctieu);
                        if (quanco_Muctieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toado_Muctieu);
                    }
                }
            }

            // Xét điểm cản chéo phải dưới (X + 1, Y + 1)
            diemcan = new Point(Toado.X + 1, Toado.Y + 1);
            if (Namtrong_Nua_Banco(diemcan) && !Banco.Ktra_Quanco_taivitri(diemcan))
            {
                toado_Muctieu = new Point(Toado.X + 2, Toado.Y + 2);
                if (Namtrong_Nua_Banco(toado_Muctieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    else
                    {
                        quanco_Muctieu = Banco.Get_Quanco(toado_Muctieu);
                        if (quanco_Muctieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toado_Muctieu);
                    }
                }
            }
        }

        private bool Namtrong_Nua_Banco(Point diem) // chỉ xét 1 nửa bàn cờ
        {
            if (diem.X < 0 || diem.X > 8)
                return false;
            if (Banco.Mau_Pheta == 2) // phe ta là đỏ (dưới)
            {
                if (this.Mau == 1) // xanh (trên)
                {
                    if (diem.Y < 0 || diem.Y > 4)
                        return false;
                }
                else if (this.Mau == 2) // đỏ (dưới)
                {
                    if (diem.Y < 5 || diem.Y > 9)
                        return false;
                }
            }
            else if (Banco.Mau_Pheta == 1) // phe ta là xanh (dưới)
            {
                if (this.Mau == 2) // đỏ (trên)
                {
                    if (diem.Y < 0 || diem.Y > 4)
                        return false;
                }
                else if (this.Mau == 1) // xanh (dưới)
                {
                    if (diem.Y < 5 || diem.Y > 9)
                        return false;
                }
            }
            return true;
        }
    }
}