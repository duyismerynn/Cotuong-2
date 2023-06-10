using CoTuongOffline.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongOffline.CoTuong
{
    public class QuanTot : QuanCo
    {
        public QuanTot() { }

        public QuanTot(Point toaDoBanDau)
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
            Point toaDoMucTieu = ThongSo.ToaDoNULL;
            QuanCo quanCoMucTieu;

            if (BanCo.MauPheTa == 2)
            {
                if (Mau == 1)
                    toaDoMucTieu = new Point(ToaDo.X, ToaDo.Y + 1);
                else if (Mau == 2)
                    toaDoMucTieu = new Point(ToaDo.X, ToaDo.Y - 1);
            }
            else if (BanCo.MauPheTa == 1)
            {
                if (Mau == 2)
                    toaDoMucTieu = new Point(ToaDo.X, ToaDo.Y + 1);
                else if (Mau == 1)
                    toaDoMucTieu = new Point(ToaDo.X, ToaDo.Y - 1);
            }

            if (NamTrongBanCo(toaDoMucTieu))
            {
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    DanhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        DanhSachDiemDich.Add(toaDoMucTieu);
                }
            }

            if (QuaSong())
            {
                if (BanCo.MauPheTa == 2)
                {
                    if (Mau == 1)
                    {
                        if (NamTrongBanCo(toaDoMucTieu))
                        {
                            toaDoMucTieu = new Point(ToaDo.X, ToaDo.Y + 1);
                            if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            else
                            {
                                quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                                if (quanCoMucTieu.Mau != this.Mau)
                                    DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }
                    }
                    else if (Mau == 2)
                    {
                        toaDoMucTieu = new Point(ToaDo.X, ToaDo.Y - 1);
                        if (NamTrongBanCo(toaDoMucTieu))
                        {
                            if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            else
                            {
                                quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                                if (quanCoMucTieu.Mau != this.Mau)
                                    DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }
                    }
                }
                else if (BanCo.MauPheTa == 1)
                {
                    if (Mau == 2)
                    {
                        if (NamTrongBanCo(toaDoMucTieu))
                        {
                            toaDoMucTieu = new Point(ToaDo.X, ToaDo.Y + 1);
                            if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            else
                            {
                                quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                                if (quanCoMucTieu.Mau != this.Mau)
                                    DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }
                    }
                    else if (Mau == 1)
                    {
                        toaDoMucTieu = new Point(ToaDo.X, ToaDo.Y - 1);
                        if (NamTrongBanCo(toaDoMucTieu))
                        {
                            if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            else
                            {
                                quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                                if (quanCoMucTieu.Mau != this.Mau)
                                    DanhSachDiemDich.Add(toaDoMucTieu);
                            }
                        }
                    }
                }

                toaDoMucTieu = new Point(ToaDo.X - 1, ToaDo.Y);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        DanhSachDiemDich.Add(toaDoMucTieu);
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                            DanhSachDiemDich.Add(toaDoMucTieu);
                    }
                }
                toaDoMucTieu = new Point(ToaDo.X + 1, ToaDo.Y);
                if (NamTrongBanCo(toaDoMucTieu))
                {
                    if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        DanhSachDiemDich.Add(toaDoMucTieu);
                    else
                    {
                        quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                        if (quanCoMucTieu.Mau != this.Mau)
                            DanhSachDiemDich.Add(toaDoMucTieu);
                    }
                }
            }
        }

        private bool QuaSong()
        {
            if (BanCo.MauPheTa == 2)
            {
                if (Mau == 1) //Xanh
                {
                    if (ToaDo.Y > 4) return true;
                }
                else if (Mau == 2) //Do
                {
                    if (ToaDo.Y < 5) return true;
                }
            }
            else if (BanCo.MauPheTa == 1)
            {
                if (Mau == 2) //Do
                {
                    if (ToaDo.Y > 4) return true;
                }
                else if (Mau == 1) //Xanh
                {
                    if (ToaDo.Y < 5) return true;
                }
            }
            return false;
        }
    }
}