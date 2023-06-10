using CoTuongOffline.ProgramConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongOffline.CoTuong
{
    public class QuanXe : QuanCo
    {
        public QuanXe() { }

        public QuanXe(Point toaDoBanDau)
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

            /* Xét nhánh các điểm đích BÊN TRÁI quân xe */
            for (int x = ToaDo.X - 1; x >= 0; x--)
            {
                toaDoMucTieu = new Point(x, ToaDo.Y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    DanhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        DanhSachDiemDich.Add(toaDoMucTieu);
                    break;
                }
            }

            /* Xét nhánh các điểm đích BÊN PHẢI quân xe */
            for (int x = ToaDo.X + 1; x < 9; x++)
            {
                toaDoMucTieu = new Point(x, ToaDo.Y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    DanhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        DanhSachDiemDich.Add(toaDoMucTieu);
                    break;
                }
            }

            /* Xét nhánh các điểm đích BÊN TRÊN quân xe */
            for (int y = ToaDo.Y - 1; y >= 0; y--)
            {
                toaDoMucTieu = new Point(ToaDo.X, y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    DanhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        DanhSachDiemDich.Add(toaDoMucTieu);
                    break;
                }
            }

            /* Xét nhánh các điểm đích BÊN DƯỚI quân xe */
            for (int y = ToaDo.Y + 1; y < 10; y++)
            {
                toaDoMucTieu = new Point(ToaDo.X, y);
                if (!BanCo.CoQuanCoTaiDay(toaDoMucTieu))
                    DanhSachDiemDich.Add(toaDoMucTieu);
                else
                {
                    quanCoMucTieu = BanCo.GetQuanCo(toaDoMucTieu);
                    if (quanCoMucTieu.Mau != this.Mau)
                        DanhSachDiemDich.Add(toaDoMucTieu);
                    break;
                }
            }
        }
    }
}