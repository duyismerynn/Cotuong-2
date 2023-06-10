using CoTuongOffline.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongOffline.Cotuong
{
    public class Tot : Quanco
    {
        public Tot() { }

        public Tot(Point toado_Bandau)
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
            Point toado_Muctieu = Thongso.Toado_NULL;
            Quanco quanco_Muctieu;
            // đi thẳng, thêm đi ngang trái phải nếu ĐÃ QUA SÔNG, KHÔNG đi lùi

            // if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // không có quân
            // else // có quân

            if (Banco.Mau_Pheta == 2) // phe ta là đỏ (dưới)
            {
                if (Mau == 1) // xanh (trên)
                    toado_Muctieu = new Point(Toado.X, Toado.Y + 1);
                else if (Mau == 2) // đỏ (dưới)
                    toado_Muctieu = new Point(Toado.X, Toado.Y - 1);
            }
            else if (Banco.Mau_Pheta == 1) // phe ta là xanh (dưới)
            {
                if (Mau == 2) // đỏ (trên)
                    toado_Muctieu = new Point(Toado.X, Toado.Y + 1);
                else if (Mau == 1) // xanh (dưới)
                    toado_Muctieu = new Point(Toado.X, Toado.Y - 1);
            }

            if (Namtrong_Banco(toado_Muctieu)) // kiểm tra có quân cờ ở điểm đích không? nếu ko thì đi được, có thì ăn (nếu khác màu)
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

            if (Quasong()) 
            {
                if (Banco.Mau_Pheta == 2) // phe ta là đỏ (dưới)
                {
                    if (Mau == 1) // xanh (trên)
                    {
                        if (Namtrong_Banco(toado_Muctieu))
                        {
                            toado_Muctieu = new Point(Toado.X, Toado.Y + 1);
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
                    else if (Mau == 2) // đỏ (dưới)
                    {
                        
                        if (Namtrong_Banco(toado_Muctieu))
                        {
                            toado_Muctieu = new Point(Toado.X, Toado.Y - 1);
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
                }
                else if (Banco.Mau_Pheta == 1) // phe ta là xanh (dưới)
                {
                    if (Mau == 2) // đỏ (trên)
                    {
                        toado_Muctieu = new Point(Toado.X, Toado.Y + 1);
                        if (Namtrong_Banco(toado_Muctieu))
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
                    else if (Mau == 1) // xanh (dưới)
                    {
                        toado_Muctieu = new Point(Toado.X, Toado.Y - 1);
                        if (Namtrong_Banco(toado_Muctieu))
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
                }

                toado_Muctieu = new Point(Toado.X - 1, Toado.Y); // đi sang trái
                if (Namtrong_Banco(toado_Muctieu))
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
                toado_Muctieu = new Point(Toado.X + 1, Toado.Y); // đi sang phải
                if (Namtrong_Banco(toado_Muctieu))
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
        }

        private bool Quasong() // xét thêm hàm qua sông bằng hoành độ Y
        {
            if (Banco.Mau_Pheta == 2) // phe ta là đỏ (dưới)
            {
                if (Mau == 1) // xanh (trên)
                    if (Toado.Y > 4) return true;
                else if (Mau == 2) // đỏ (dưới)
                    if (Toado.Y < 5) return true;
            }
            else if (Banco.Mau_Pheta == 1) // phe ta là xanh (dưới)
            {
                if (Mau == 2) // đỏ (trên)
                    if (Toado.Y > 4) return true;
                else if (Mau == 1) // xanh (dưới)
                    if (Toado.Y < 5) return true;
            }
            return false;
        }
    }
}