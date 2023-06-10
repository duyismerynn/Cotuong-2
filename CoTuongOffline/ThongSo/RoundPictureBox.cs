using CoTuongOffline.CoTuong;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTuongOffline.ProgramConfig
{
    public class RoundPictureBox : PictureBox
    {
        #region properties
        public QuanCo Quan_Co { get; private set; }

        public string TenQuanCo { get; private set; }
        #endregion

        #region methods
        public RoundPictureBox()
        {
            Quan_Co = new QuanCo();
            TenQuanCo = "";
            this.BackColor = Color.DarkGray;
        }

        public RoundPictureBox(Point toaDoBanDau)
        {
            TenQuanCo = "";
            if (toaDoBanDau == ThongSo.ToaDoNULL)
            {
                Quan_Co = new QuanCo(toaDoBanDau);
                TenQuanCo += "NULL";
            }
            else if (global::CoTuongOffline.CoTuong.BanCo.MauPheTa == 2)
            {
                if (toaDoBanDau == ThongSoPheDo.ToaDoTuongXanh || toaDoBanDau == ThongSoPheDo.ToaDoTuongDo)
                {
                    Quan_Co = new QuanTuong(toaDoBanDau);
                    TenQuanCo += "Tuong";
                }
                else if (toaDoBanDau == ThongSoPheDo.ToaDoXeXanh1 || toaDoBanDau == ThongSoPheDo.ToaDoXeXanh2 || toaDoBanDau == ThongSoPheDo.ToaDoXeDo1 || toaDoBanDau == ThongSoPheDo.ToaDoXeDo2)
                {
                    Quan_Co = new QuanXe(toaDoBanDau);
                    TenQuanCo += "Xe";
                }
                else if (toaDoBanDau == ThongSoPheDo.ToaDoMaXanh1 || toaDoBanDau == ThongSoPheDo.ToaDoMaXanh2 || toaDoBanDau == ThongSoPheDo.ToaDoMaDo1 || toaDoBanDau == ThongSoPheDo.ToaDoMaDo2)
                {
                    Quan_Co = new QuanMa(toaDoBanDau);
                    TenQuanCo += "Ma";
                }
                else if (toaDoBanDau == ThongSoPheDo.ToaDoTinhXanh1 || toaDoBanDau == ThongSoPheDo.ToaDoTinhXanh2 || toaDoBanDau == ThongSoPheDo.ToaDoTinhDo1 || toaDoBanDau == ThongSoPheDo.ToaDoTinhDo2)
                {
                    Quan_Co = new QuanTinh(toaDoBanDau);
                    TenQuanCo += "Tinh";
                }
                else if (toaDoBanDau == ThongSoPheDo.ToaDoSiXanh1 || toaDoBanDau == ThongSoPheDo.ToaDoSiXanh2 || toaDoBanDau == ThongSoPheDo.ToaDoSiDo1 || toaDoBanDau == ThongSoPheDo.ToaDoSiDo2)
                {
                    Quan_Co = new QuanSi(toaDoBanDau);
                    TenQuanCo += "Si";
                }
                else if (toaDoBanDau == ThongSoPheDo.ToaDoPhaoXanh1 || toaDoBanDau == ThongSoPheDo.ToaDoPhaoXanh2 || toaDoBanDau == ThongSoPheDo.ToaDoPhaoDo1 || toaDoBanDau == ThongSoPheDo.ToaDoPhaoDo2)
                {
                    Quan_Co = new QuanPhao(toaDoBanDau);
                    TenQuanCo += "Phao";
                }
                else
                {
                    Quan_Co = new QuanTot(toaDoBanDau);
                    TenQuanCo += "Tot";
                }
            }
            else if (global::CoTuongOffline.CoTuong.BanCo.MauPheTa == 1)
            {
                if (toaDoBanDau == ThongSoPheXanh.ToaDoTuongXanh || toaDoBanDau == ThongSoPheXanh.ToaDoTuongDo)
                {
                    Quan_Co = new QuanTuong(toaDoBanDau);
                    TenQuanCo += "Tuong";
                }
                else if (toaDoBanDau == ThongSoPheXanh.ToaDoXeXanh1 || toaDoBanDau == ThongSoPheXanh.ToaDoXeXanh2 || toaDoBanDau == ThongSoPheXanh.ToaDoXeDo1 || toaDoBanDau == ThongSoPheXanh.ToaDoXeDo2)
                {
                    Quan_Co = new QuanXe(toaDoBanDau);
                    TenQuanCo += "Xe";
                }
                else if (toaDoBanDau == ThongSoPheXanh.ToaDoMaXanh1 || toaDoBanDau == ThongSoPheXanh.ToaDoMaXanh2 || toaDoBanDau == ThongSoPheXanh.ToaDoMaDo1 || toaDoBanDau == ThongSoPheXanh.ToaDoMaDo2)
                {
                    Quan_Co = new QuanMa(toaDoBanDau);
                    TenQuanCo += "Ma";
                }
                else if (toaDoBanDau == ThongSoPheXanh.ToaDoTinhXanh1 || toaDoBanDau == ThongSoPheXanh.ToaDoTinhXanh2 || toaDoBanDau == ThongSoPheXanh.ToaDoTinhDo1 || toaDoBanDau == ThongSoPheXanh.ToaDoTinhDo2)
                {
                    Quan_Co = new QuanTinh(toaDoBanDau);
                    TenQuanCo += "Tinh";
                }
                else if (toaDoBanDau == ThongSoPheXanh.ToaDoSiXanh1 || toaDoBanDau == ThongSoPheXanh.ToaDoSiXanh2 || toaDoBanDau == ThongSoPheXanh.ToaDoSiDo1 || toaDoBanDau == ThongSoPheXanh.ToaDoSiDo2)
                {
                    Quan_Co = new QuanSi(toaDoBanDau);
                    TenQuanCo += "Si";
                }
                else if (toaDoBanDau == ThongSoPheXanh.ToaDoPhaoXanh1 || toaDoBanDau == ThongSoPheXanh.ToaDoPhaoXanh2 || toaDoBanDau == ThongSoPheXanh.ToaDoPhaoDo1 || toaDoBanDau == ThongSoPheXanh.ToaDoPhaoDo2)
                {
                    Quan_Co = new QuanPhao(toaDoBanDau);
                    TenQuanCo += "Phao";
                }
                else
                {
                    Quan_Co = new QuanTot(toaDoBanDau);
                    TenQuanCo += "Tot";
                }
            }
            if (Quan_Co.Mau == 1)
            {
                base.BackColor = global::CoTuongOffline.CoTuong.BanCo.MauPheXanh;
                TenQuanCo += " Xanh";
            }
            else if (Quan_Co.Mau == 2)
            {
                base.BackColor = global::CoTuongOffline.CoTuong.BanCo.MauPheDo;
                TenQuanCo += " Do";
            }
            Height = ThongSo.DuongKinhQuanCo;
            Width = ThongSo.DuongKinhQuanCo;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Location = ThongSo.ToaDoBanCoCuaQuanCo(toaDoBanDau);
        }

        public void DiChuyen(Point location)
        {
            Quan_Co.DiChuyen(location);
            Location = ThongSo.ToaDoBanCoCuaQuanCo(location);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                this.Region = new Region(gp);
            }
        }
        #endregion
    }
}