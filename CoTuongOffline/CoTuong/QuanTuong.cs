using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CoTuongOffline.ProgramConfig;

namespace CoTuongOffline.CoTuong
{
    public class QuanTuong : QuanCo
    {
        public QuanTuong() { }

        public QuanTuong(Point toaDoBanDau)
        {
            ToaDo = toaDoBanDau;
            DanhSachDiemDich = new List<Point>();
            if (BanCo.MauPheTa == 2)
                Mau = ThongSoPheDo.MauQuanCo(toaDoBanDau);
            else if (BanCo.MauPheTa == 1)
                Mau = ThongSoPheXanh.MauQuanCo(toaDoBanDau);
            BanCo.Alive_QuanCo.Add(this);
            if (Mau == 1)
                BanCo.TuongXanh = this;
            else if (Mau == 2)
                BanCo.TuongDo = this;
        }

        public override void TinhNuocDi()
        {
            Point toaDoMucTieu;
            QuanCo quanCoMucTieu;

            toaDoMucTieu = new Point(ToaDo.X + 1, ToaDo.Y);
            if (NamTrongCung(toaDoMucTieu))
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

            toaDoMucTieu = new Point(ToaDo.X - 1, ToaDo.Y);
            if (NamTrongCung(toaDoMucTieu))
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

            toaDoMucTieu = new Point(ToaDo.X, ToaDo.Y + 1);
            if (NamTrongCung(toaDoMucTieu))
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

            toaDoMucTieu = new Point(ToaDo.X, ToaDo.Y - 1);
            if (NamTrongCung(toaDoMucTieu))
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

        private bool NamTrongCung(Point point)
        {
            if (BanCo.MauPheTa == 2)
            {
                if (Mau == 1)
                    if ((point.X >= 3 && point.X <= 5 && point.Y >= 0 && point.Y <= 2))
                        return true;
                if (Mau == 2)
                    if (point.X >= 3 && point.X <= 5 && point.Y >= 7 && point.Y <= 9)
                        return true;
            }
            else if (BanCo.MauPheTa == 1)
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