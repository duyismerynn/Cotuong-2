using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CoTuongOffline.ProgramConfig;

namespace CoTuongOffline.Cotuong
{
    public class Si : Quanco
    {
        public Si() { }

        public Si(Point toado_Bandau)
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
            // nửa trên: (3,0) (5,0) (3,2) (5;2): 4 góc trong cung; (4,1): trung tâm cung
            // nửa dưới: (3,7) (5,7) (3,9) (5;9): 4 góc trong cung; (4,8): trung tâm cung

            // if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu)) // không có quân
            // else // có quân
                        

            if (Banco.Mau_Pheta == 2) // xét phe ta màu đỏ (dưới)
            {
                if (Mau == 1) // sĩ xanh (trên)
                {
                    if (Toado == new Point(3, 0) || Toado == new Point(5, 0) || Toado == new Point(3, 2) || Toado == new Point(5, 2)) // 4 góc trong cung, chỉ di chuyển được tới trung tâm cung
                    {
                        toado_Muctieu = new Point(4, 1);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }
                    }
                    else if (Toado == new Point(4, 1)) // trung tâm cung (di chuyển được tới 4 góc)
                    {
                        toado_Muctieu = new Point(3, 0);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }

                        toado_Muctieu = new Point(5, 0);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }

                        toado_Muctieu = new Point(3, 2);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }

                        toado_Muctieu = new Point(5, 2);
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
                else if (Mau == 2)
                {
                    if (Toado == new Point(3, 9) || Toado == new Point(5, 9) || Toado == new Point(3, 7) || Toado == new Point(5, 7)) // 4 góc trong cung, chỉ di chuyển được tới trung tâm cung
                    {
                        toado_Muctieu = new Point(4, 8);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }
                    } 
                    else if (Toado == new Point(4, 8)) // trung tâm cung (di chuyển được tới 4 góc)
                    {
                        toado_Muctieu = new Point(3, 9);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }

                        toado_Muctieu = new Point(5, 9);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }

                        toado_Muctieu = new Point(3, 7);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }

                        toado_Muctieu = new Point(5, 7);
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
            else if (Banco.Mau_Pheta == 1) // xtes phe ta là xanh (dưới) 
            {
                if (Mau == 2) // sĩ đỏ (trên)
                {
                    if (Toado == new Point(3, 0) || Toado == new Point(5, 0) || Toado == new Point(3, 2) || Toado == new Point(5, 2))
                    {
                        toado_Muctieu = new Point(4, 1);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }
                    }
                    else if (Toado == new Point(4, 1)) // trung tâm cung (di chuyển được tới 4 góc)
                    {
                        toado_Muctieu = new Point(3, 0);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }

                        toado_Muctieu = new Point(5, 0);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }

                        toado_Muctieu = new Point(3, 2);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }

                        toado_Muctieu = new Point(5, 2);
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
                else if (Mau == 1)
                {
                    if (Toado == new Point(3, 9) || Toado == new Point(5, 9) || Toado == new Point(3, 7) || Toado == new Point(5, 7))
                    {
                        toado_Muctieu = new Point(4, 8);
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }
                    }
                    else if (Toado == new Point(4, 8)) // trung tâm cung (di chuyển được tới 4 góc)
                    {
                        toado_Muctieu = new Point(3, 9);//
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }

                        toado_Muctieu = new Point(5, 9); 
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }

                        toado_Muctieu = new Point(3, 7);//
                        if (!Banco.Ktra_Quanco_taivitri(toado_Muctieu))
                            Danhsach_Diemdich.Add(toado_Muctieu);
                        else
                        {
                            quanco_Muctieu = Banco.Lay_Quanco(toado_Muctieu);
                            if (quanco_Muctieu.Mau != this.Mau)
                                Danhsach_Diemdich.Add(toado_Muctieu);
                        }

                        toado_Muctieu = new Point(5, 7);//
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
        }
    }
}