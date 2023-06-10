using CoTuongLAN.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongLAN.CoTuong
{
    public class QuanPhao : QuanCo
    {
        public QuanPhao() { }

        public QuanPhao(Point toaDoBanDau)
        {
            ToaDo = toaDoBanDau;
            DanhSachDiemDich = new List<Point>();
            if (BanCo.PheTa == 2)
                Mau = ThongSoPheDo.MauQuanCo(toaDoBanDau);
            else if (BanCo.PheTa == 1)
                Mau = ThongSoPheXanh.MauQuanCo(toaDoBanDau);
            BanCo.Alive_QuanCo.Add(this);
        }

        public override void TinhNuocDi()
        {
            Point toaDoMucTieu;
            QuanCo quanCoMucTieu;

            /* Xét nhánh các điểm đích BÊN TRÁI quân pháo */
            for (int x = ToaDo.X - 1; x >= 0; x--)
            {
                toaDoMucTieu = new Point(x, ToaDo.Y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    DanhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    for (x -= 1; x >= 0; x--)
                    {
                        toaDoMucTieu = new Point(x, ToaDo.Y);
                        if (BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            break;
                        }
                    }
                    break;
                }
            }

            /* Xét nhánh các điểm đích BÊN PHẢI quân pháo */
            for (int x = ToaDo.X + 1; x < 9; x++)
            {
                toaDoMucTieu = new Point(x, ToaDo.Y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    DanhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    for (x += 1; x < 9; x++)
                    {
                        toaDoMucTieu = new Point(x, ToaDo.Y);
                        if (BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            break;
                        }
                    }
                    break;
                }
            }

            /* Xét nhánh các điểm đích BÊN TRÊN quân pháo */
            for (int y = ToaDo.Y - 1; y >= 0; y--)
            {
                toaDoMucTieu = new Point(ToaDo.X, y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    DanhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    for (y -= 1; y >= 0; y--)
                    {
                        toaDoMucTieu = new Point(ToaDo.X, y);
                        if (BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            break;
                        }
                    }
                    break;
                }
            }

            /* Xét nhánh các điểm đích BÊN DƯỚI quân pháo */
            for (int y = ToaDo.Y + 1; y < 10; y++)
            {
                toaDoMucTieu = new Point(ToaDo.X, y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    DanhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    for (y += 1; y < 10; y++)
                    {
                        toaDoMucTieu = new Point(ToaDo.X, y);
                        if (BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                        {
                            quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                            if (quanCoMucTieu.Mau != this.Mau)
                                DanhSachDiemDich.Add(toaDoMucTieu);
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}