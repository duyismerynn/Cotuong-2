using CoTuongOffline.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongOffline.CoTuong
{
    public class QuanTinh : QuanCo
    {
        public QuanTinh() { }

        public QuanTinh(Point toaDoBanDau)
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

            // Xét điểm cản (ToaDo.X - 1, ToaDo.Y - 1)
            diemCan = new Point(ToaDo.X - 1, ToaDo.Y - 1);
            if (NamTrongNuaBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
                toaDoMucTieu = new Point(ToaDo.X - 2, ToaDo.Y - 2);
                if (NamTrongNuaBanCo(toaDoMucTieu))
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

            // Xét điểm cản (ToaDo.X - 1, ToaDo.Y + 1)
            diemCan = new Point(ToaDo.X - 1, ToaDo.Y + 1);
            if (NamTrongNuaBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
                toaDoMucTieu = new Point(ToaDo.X - 2, ToaDo.Y + 2);
                if (NamTrongNuaBanCo(toaDoMucTieu))
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

            // Xét điểm cản (ToaDo.X + 1, ToaDo.Y - 1)
            diemCan = new Point(ToaDo.X + 1, ToaDo.Y - 1);
            if (NamTrongNuaBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
                toaDoMucTieu = new Point(ToaDo.X + 2, ToaDo.Y - 2);
                if (NamTrongNuaBanCo(toaDoMucTieu))
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

            // Xét điểm cản (ToaDo.X + 1, ToaDo.Y + 1)
            diemCan = new Point(ToaDo.X + 1, ToaDo.Y + 1);
            if (NamTrongNuaBanCo(diemCan) && !BanCo.CoQuanCoTaiDay(diemCan))
            {
                toaDoMucTieu = new Point(ToaDo.X + 2, ToaDo.Y + 2);
                if (NamTrongNuaBanCo(toaDoMucTieu))
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

        private bool NamTrongNuaBanCo(Point diem)
        {
            if (diem.X < 0 || diem.X > 8)
                return false;
            if (BanCo.MauPheTa == 2)
            {
                if (this.Mau == 1)
                {
                    if (diem.Y < 0 || diem.Y > 4)
                        return false;
                }
                else if (this.Mau == 2)
                {
                    if (diem.Y < 5 || diem.Y > 9)
                        return false;
                }
            }
            else if (BanCo.MauPheTa == 1)
            {
                if (this.Mau == 2)
                {
                    if (diem.Y < 0 || diem.Y > 4)
                        return false;
                }
                else if (this.Mau == 1)
                {
                    if (diem.Y < 5 || diem.Y > 9)
                        return false;
                }
            }
            return true;
        }
    }
}