using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CoTuongOffline.ProgramConfig;

namespace CoTuongOffline.CoTuong
{
    public class QuanSi : QuanCo
    {
        public QuanSi() { }

        public QuanSi(Point toaDoBanDau)
        {
            ToaDo = toaDoBanDau;
            DanhSachDiemDich = new List<Point>();
            if (BanCo.MauPheTa == 2)
                Mau = ThongSoPheDo.MauQuanCo(toaDoBanDau);
            else if (BanCo.MauPheTa == 1)
                Mau = ThongSoPheXanh.MauQuanCo(toaDoBanDau);
            BanCo.Alive_QuanCo.Add(this);
        }

        public override void TinhNuocDi()
        {
            Point toaDoMucTieu;
            QuanCo quanCoMucTieu;

            if (BanCo.MauPheTa == 2)
            {
                if (Mau == 1)
                {
                    if (ToaDo == new Point(3, 0) || ToaDo == new Point(5, 0) || ToaDo == new Point(3, 2) || ToaDo == new Point(5, 2))
                    {
                        toaDoMucTieu = new Point(4, 1);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }
                    }
                    else if (ToaDo == new Point(4, 1))
                    {
                        toaDoMucTieu = new Point(3, 0);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 0);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(3, 2);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 2);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }
                    }
                }
                else if (Mau == 2)
                {
                    if (ToaDo == new Point(3, 9) || ToaDo == new Point(5, 9) || ToaDo == new Point(3, 7) || ToaDo == new Point(5, 7))
                    {
                        toaDoMucTieu = new Point(4, 8);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }
                    }
                    else if (ToaDo == new Point(4, 8))
                    {
                        toaDoMucTieu = new Point(3, 9);//
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 9);//
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(3, 7);//
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 7);//
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }
                    }
                }
            }
            else if (BanCo.MauPheTa == 1)
            {
                if (Mau == 2)
                {
                    if (ToaDo == new Point(3, 0) || ToaDo == new Point(5, 0) || ToaDo == new Point(3, 2) || ToaDo == new Point(5, 2))
                    {
                        toaDoMucTieu = new Point(4, 1);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }
                    }
                    else if (ToaDo == new Point(4, 1))
                    {
                        toaDoMucTieu = new Point(3, 0);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 0);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(3, 2);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 2);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }
                    }
                }
                else if (Mau == 1)
                {
                    if (ToaDo == new Point(3, 9) || ToaDo == new Point(5, 9) || ToaDo == new Point(3, 7) || ToaDo == new Point(5, 7))
                    {
                        toaDoMucTieu = new Point(4, 8);
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }
                    }
                    else if (ToaDo == new Point(4, 8))
                    {
                        toaDoMucTieu = new Point(3, 9);//
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 9);//
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(3, 7);//
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }

                        toaDoMucTieu = new Point(5, 7);//
                        if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            DanhSachDiemDich.Add(toaDoMucTieu);
                        }
                        else
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                            {
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }
                    }
                }
            }
        }
    }
}