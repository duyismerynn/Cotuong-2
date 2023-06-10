using CoTuongLAN.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongLAN.Cotuong
{
    public class Ma : Quanco
    {
        public Ma() { }

        public Ma(Point toado_Bandau)
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
            Point diemcan; // điểm cản
            Point toado_Muctieu;
            Quanco quanco_Muctieu;

            // Xét 4 điểm cản có toạ độ trên, dưới, trái, phải quân mã 1 đơn vị, nếu có thì không thể di chuyển theo hướng đó

            // Xét điểm cản bên trái (X - 1,Y)
            diemcan = new Point(Toado.X - 1, Toado.Y);
            if (Namtrong_Banco(diemcan) && !Banco.Ktra_Quanco_taivitri(diemcan)) 
            {
                toado_Muctieu = new Point(Toado.X - 2, Toado.Y - 1); // điểm đích chéo trái trên
                if (Namtrong_Banco(toado_Muctieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // điểm đích không có quân
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    else // có
                    {
                        quanco_Muctieu = Banco.Get_Quanco(toado_Muctieu);
                        if (quanco_Muctieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toado_Muctieu);
                    }
                }
                toado_Muctieu = new Point(Toado.X - 2, Toado.Y + 1); // điểm đích chéo trái dưới
                if (Namtrong_Banco(toado_Muctieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // điểm đích không có quân
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    else // có quân
                    {
                        quanco_Muctieu = Banco.Get_Quanco(toado_Muctieu);
                        if (quanco_Muctieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toado_Muctieu);
                    }
                }
            }

            // Xét điểm cản bên phải (X + 1,Y)
            diemcan = new Point(Toado.X + 1, Toado.Y);
            if (Namtrong_Banco(diemcan) && !Banco.Ktra_Quanco_taivitri(diemcan))
            {
                toado_Muctieu = new Point(Toado.X + 2, Toado.Y - 1); // điểm đích chéo phải trên
                if (Namtrong_Banco(toado_Muctieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // không có quân
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    else // có quân
                    {
                        quanco_Muctieu = Banco.Get_Quanco(toado_Muctieu);
                        if (quanco_Muctieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toado_Muctieu);
                    }
                }
                toado_Muctieu = new Point(Toado.X + 2, Toado.Y + 1); // điểm đích chéo phải dưới
                if (Namtrong_Banco(toado_Muctieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // không có quân
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    else // có quân
                    {
                        quanco_Muctieu = Banco.Get_Quanco(toado_Muctieu);
                        if (quanco_Muctieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toado_Muctieu);
                    }
                }
            }

            // Xét điểm cản bên trên (X, Y - 1)
            diemcan = new Point(Toado.X, Toado.Y - 1);
            if (Namtrong_Banco(diemcan) && !Banco.Ktra_Quanco_taivitri(diemcan))
            {
                toado_Muctieu = new Point(Toado.X - 1, Toado.Y - 2); // điểm đích chéo trái trên
                if (Namtrong_Banco(toado_Muctieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // không có quân
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    else // có
                    {
                        quanco_Muctieu = Banco.Get_Quanco(toado_Muctieu);
                        if (quanco_Muctieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toado_Muctieu);
                    }
                }
                toado_Muctieu = new Point(Toado.X + 1, Toado.Y - 2); // điểm đích chéo phải trên
                if (Namtrong_Banco(toado_Muctieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) //không có quân
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    else // có quân
                    {
                        quanco_Muctieu = Banco.Get_Quanco(toado_Muctieu);
                        if (quanco_Muctieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toado_Muctieu);
                    }
                }
            }

            // Xét điểm cản bên dưới (X, Y + 1)
            diemcan = new Point(Toado.X, Toado.Y + 1);
            if (Namtrong_Banco(diemcan) && !Banco.Ktra_Quanco_taivitri(diemcan))
            {
                toado_Muctieu = new Point(Toado.X - 1, Toado.Y + 2); // điểm đích chéo trái dưới
                if (Namtrong_Banco(toado_Muctieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // không có quân ở vị trí đích
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    else // có
                    {
                        quanco_Muctieu = Banco.Get_Quanco(toado_Muctieu);
                        if (quanco_Muctieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toado_Muctieu);
                    }
                }
                toado_Muctieu = new Point(Toado.X + 1, Toado.Y + 2); // điểm đích chéo phải dưới
                if (Namtrong_Banco(toado_Muctieu))
                {
                    if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // không có quân ở điểm đích
                        Danhsach_Diemdich.Add(toado_Muctieu);
                    else // có quân
                    {
                        quanco_Muctieu = Banco.Get_Quanco(toado_Muctieu);
                        if (quanco_Muctieu.Mau != this.Mau)
                            Danhsach_Diemdich.Add(toado_Muctieu);
                    }
                }
            }
        }
    }
}