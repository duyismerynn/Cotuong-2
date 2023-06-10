using CoTuongLAN.CoTuong;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTuongLAN.ProgramConfig
{
    public class RoundPictureBox : PictureBox
    {
        #region properties
        public Quanco Quanco { get; private set; }

        public string TenQuanCo { get; private set; }
        #endregion

        #region methods
        public RoundPictureBox()
        {
            Quanco = new Quanco();
            TenQuanCo = "";
            this.BackColor = Color.DarkGray;
        }

        public RoundPictureBox(Point toaDoBanDau)
        {
            TenQuanCo = "";
            if (toaDoBanDau == Thongso.Toado_NULL)
            {
                Quanco = new Quanco(toaDoBanDau);
                TenQuanCo += "NULL";
            }
            else if (Banco.Mau_Pheta == 2)
            {
                if (toaDoBanDau == Thongso_Phedo.Toado_Tuongxanh || toaDoBanDau == Thongso_Phedo.Toado_Tuongdo)
                {
                    Quanco = new Tuong(toaDoBanDau);
                    TenQuanCo += "Tuong";
                }
                else if (toaDoBanDau == Thongso_Phedo.Toado_Xexanh_1 || toaDoBanDau == Thongso_Phedo.Toado_Xexanh_2 || toaDoBanDau == Thongso_Phedo.Toado_Xedo_1 || toaDoBanDau == Thongso_Phedo.Toado_Xedo_2)
                {
                    Quanco = new Xe(toaDoBanDau);
                    TenQuanCo += "Xe";
                }
                else if (toaDoBanDau == Thongso_Phedo.Toado_Maxanh_1 || toaDoBanDau == Thongso_Phedo.Toado_Maxanh_2 || toaDoBanDau == Thongso_Phedo.Toado_Mado_1 || toaDoBanDau == Thongso_Phedo.Toado_Mado_2)
                {
                    Quanco = new Ma(toaDoBanDau);
                    TenQuanCo += "Ma";
                }
                else if (toaDoBanDau == Thongso_Phedo.Toado_Tinhxanh_1 || toaDoBanDau == Thongso_Phedo.Toado_Tinhxanh_2 || toaDoBanDau == Thongso_Phedo.Toado_Tinhdo_1 || toaDoBanDau == Thongso_Phedo.Toado_Tinhdo_2)
                {
                    Quanco = new Tinh(toaDoBanDau);
                    TenQuanCo += "Tinh";
                }
                else if (toaDoBanDau == Thongso_Phedo.Toado_Sixanh_1 || toaDoBanDau == Thongso_Phedo.Toado_Sixanh_2 || toaDoBanDau == Thongso_Phedo.Toado_Sido_1 || toaDoBanDau == Thongso_Phedo.Toado_Sido_2)
                {
                    Quanco = new Si(toaDoBanDau);
                    TenQuanCo += "Si";
                }
                else if (toaDoBanDau == Thongso_Phedo.Toado_Phaoxanh_1 || toaDoBanDau == Thongso_Phedo.Toado_Phaoxanh_2 || toaDoBanDau == Thongso_Phedo.Toado_Phaodo_1 || toaDoBanDau == Thongso_Phedo.Toado_Phaodo_2)
                {
                    Quanco = new Phao(toaDoBanDau);
                    TenQuanCo += "Phao";
                }
                else
                {
                    Quanco = new Tot(toaDoBanDau);
                    TenQuanCo += "Tot";
                }
            }
            else if (Banco.Mau_Pheta == 1)
            {
                if (toaDoBanDau == Thongso_Phexanh.Toado_Tuongxanh || toaDoBanDau == Thongso_Phexanh.Toado_Tuongdo)
                {
                    Quanco = new Tuong(toaDoBanDau);
                    TenQuanCo += "Tuong";
                }
                else if (toaDoBanDau == Thongso_Phexanh.Toado_Xexanh_1 || toaDoBanDau == Thongso_Phexanh.Toado_Xexanh_2 || toaDoBanDau == Thongso_Phexanh.Toado_Xedo_1 || toaDoBanDau == Thongso_Phexanh.Toado_Xedo_2)
                {
                    Quanco = new Xe(toaDoBanDau);
                    TenQuanCo += "Xe";
                }
                else if (toaDoBanDau == Thongso_Phexanh.Toado_Maxanh_1 || toaDoBanDau == Thongso_Phexanh.Toado_Maxanh_2 || toaDoBanDau == Thongso_Phexanh.Toado_Mado_1 || toaDoBanDau == Thongso_Phexanh.Toado_Mado_2)
                {
                    Quanco = new Ma(toaDoBanDau);
                    TenQuanCo += "Ma";
                }
                else if (toaDoBanDau == Thongso_Phexanh.Toado_Tinhxanh_1 || toaDoBanDau == Thongso_Phexanh.Toado_Tinhxanh_2 || toaDoBanDau == Thongso_Phexanh.Toado_Tinhdo_1 || toaDoBanDau == Thongso_Phexanh.Toado_Tinhdo_2)
                {
                    Quanco = new Tinh(toaDoBanDau);
                    TenQuanCo += "Tinh";
                }
                else if (toaDoBanDau == Thongso_Phexanh.Toado_Sixanh_1 || toaDoBanDau == Thongso_Phexanh.Toado_Sixanh_2 || toaDoBanDau == Thongso_Phexanh.Toado_Sido_1 || toaDoBanDau == Thongso_Phexanh.Toado_Sido_2)
                {
                    Quanco = new Si(toaDoBanDau);
                    TenQuanCo += "Si";
                }
                else if (toaDoBanDau == Thongso_Phexanh.Toado_Phaoxanh_1 || toaDoBanDau == Thongso_Phexanh.Toado_Phaoxanh_2 || toaDoBanDau == Thongso_Phexanh.Toado_Phaodo_1 || toaDoBanDau == Thongso_Phexanh.Toado_Phaodo_2)
                {
                    Quanco = new Phao(toaDoBanDau);
                    TenQuanCo += "Phao";
                }
                else
                {
                    Quanco = new Tot(toaDoBanDau);
                    TenQuanCo += "Tot";
                }
            }
            if (Quanco.Mau == 1)
            {
                BackColor = Banco.Mau_Phexanh;
                TenQuanCo += " Xanh";
            }
            else if (Quanco.Mau == 2)
            {
                BackColor = Banco.Mau_Phedo;
                TenQuanCo += " Do";
            }
            Height = Thongso.Duongkinh_Quanco;
            Width = Thongso.Duongkinh_Quanco;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Location = Thongso.Toado_Banco_Cua_Quanco(toaDoBanDau);
        }

        public void DiChuyen(Point location)
        {
            Quanco.DiChuyen(location);
            Location = Thongso.Toado_Banco_Cua_Quanco(location);
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