using CoTuongOffline.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongOffline.CoTuong
{
    public class QuanMa : QuanCo
    {
        public QuanMa() { }

        public QuanMa(Point toaDoBanDau)
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
            Point diemCan;
            Point toaDoMucTieu;
            QuanCo quanCoMucTieu;

            // Xét điểm cản (ToaDo.X - 1, ToaDo.Y)
            // Xét điểm cản(ToaDo.X - 1, ToaDo.Y)
            diemCan = new Point(ToaDo.X - 1, ToaDo.Y);
            if (NamTrongBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
            toaDoMucTieu = new Point(ToaDo.X - 2, ToaDo.Y - 1);
            if (NamTrongBanCo(toaDoMucTieu))
            {
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
            toaDoMucTieu = new Point(ToaDo.X - 2, ToaDo.Y + 1);
            if (NamTrongBanCo(toaDoMucTieu))
            {
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

            // Xét điểm cản (ToaDo.X + 1, ToaDo.Y)
            diemCan = new Point(ToaDo.X + 1, ToaDo.Y);
            if (NamTrongBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
            toaDoMucTieu = new Point(ToaDo.X + 2, ToaDo.Y - 1);
            if (NamTrongBanCo(toaDoMucTieu))
            {
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
            toaDoMucTieu = new Point(ToaDo.X + 2, ToaDo.Y + 1);
            if (NamTrongBanCo(toaDoMucTieu))
            {
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

            // Xét điểm cản (ToaDo.X, ToaDo.Y - 1)
            diemCan = new Point(ToaDo.X, ToaDo.Y - 1);
            if (NamTrongBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
            toaDoMucTieu = new Point(ToaDo.X - 1, ToaDo.Y - 2);
            if (NamTrongBanCo(toaDoMucTieu))
            {
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
            toaDoMucTieu = new Point(ToaDo.X + 1, ToaDo.Y - 2);
            if (NamTrongBanCo(toaDoMucTieu))
            {
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

            // Xét điểm cản (ToaDo.X, ToaDo.Y + 1)
            diemCan = new Point(ToaDo.X, ToaDo.Y + 1);
            if (NamTrongBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
            toaDoMucTieu = new Point(ToaDo.X - 1, ToaDo.Y + 2);
            if (NamTrongBanCo(toaDoMucTieu))
            {
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
            toaDoMucTieu = new Point(ToaDo.X + 1, ToaDo.Y + 2);
            if (NamTrongBanCo(toaDoMucTieu))
            {
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