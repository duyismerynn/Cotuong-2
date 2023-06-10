using CoTuongOffline.Cotuong;
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

        public RoundPictureBox(Point toado_Bandau)
        {
            TenQuanCo = "";
            if (toado_Bandau == Thongso.Toado_NULL)
            {
                Quanco = new Quanco(toado_Bandau);
                TenQuanCo += "NULL";
            }
            else if (global::CoTuongOffline.Cotuong.Banco.Mau_Pheta == 2)
            {
                if (toado_Bandau == Bandau_Phedo.Toado_Tuongxanh || toado_Bandau == Bandau_Phedo.Toado_Tuongdo)
                {
                    Quanco = new Tuong(toado_Bandau);
                    TenQuanCo += "Tuong";
                }
                else if (toado_Bandau == Bandau_Phedo.Toado_Xexanh_1 || toado_Bandau == Bandau_Phedo.Toado_Xexanh_2 || toado_Bandau == Bandau_Phedo.Toado_Xedo_1 || toado_Bandau == Bandau_Phedo.Toado_Xedo_2)
                {
                    Quanco = new Xe(toado_Bandau);
                    TenQuanCo += "Xe";
                }
                else if (toado_Bandau == Bandau_Phedo.Toado_Maxanh_1 || toado_Bandau == Bandau_Phedo.Toado_Maxanh_2 || toado_Bandau == Bandau_Phedo.Toado_Mado_1 || toado_Bandau == Bandau_Phedo.Toado_Mado_2)
                {
                    Quanco = new Ma(toado_Bandau);
                    TenQuanCo += "Ma";
                }
                else if (toado_Bandau == Bandau_Phedo.Toado_Tinhxanh_1 || toado_Bandau == Bandau_Phedo.Toado_Tinhxanh_2 || toado_Bandau == Bandau_Phedo.Toado_Tinhdo_1 || toado_Bandau == Bandau_Phedo.Toado_Tinhdo_2)
                {
                    Quanco = new Tinh(toado_Bandau);
                    TenQuanCo += "Tinh";
                }
                else if (toado_Bandau == Bandau_Phedo.Toado_Sixanh_1 || toado_Bandau == Bandau_Phedo.Toado_Sixanh_2 || toado_Bandau == Bandau_Phedo.Toado_Sido_1 || toado_Bandau == Bandau_Phedo.Toado_Sido_2)
                {
                    Quanco = new Si(toado_Bandau);
                    TenQuanCo += "Si";
                }
                else if (toado_Bandau == Bandau_Phedo.Toado_Phaoxanh_1 || toado_Bandau == Bandau_Phedo.Toado_Phaoxanh_2 || toado_Bandau == Bandau_Phedo.Toado_Phaodo_1 || toado_Bandau == Bandau_Phedo.Toado_Phaodo_2)
                {
                    Quanco = new Phao(toado_Bandau);
                    TenQuanCo += "Phao";
                }
                else
                {
                    Quanco = new Tot(toado_Bandau);
                    TenQuanCo += "Tot";
                }
            }
            else if (global::CoTuongOffline.Cotuong.Banco.Mau_Pheta == 1)
            {
                if (toado_Bandau == Bandau_Phexanh.Toado_Tuongxanh || toado_Bandau == Bandau_Phexanh.Toado_Tuongdo)
                {
                    Quanco = new Tuong(toado_Bandau);
                    TenQuanCo += "Tuong";
                }
                else if (toado_Bandau == Bandau_Phexanh.Toado_Xexanh_1 || toado_Bandau == Bandau_Phexanh.Toado_Xexanh_2 || toado_Bandau == Bandau_Phexanh.Toado_Xedo_1 || toado_Bandau == Bandau_Phexanh.Toado_Xedo_2)
                {
                    Quanco = new Xe(toado_Bandau);
                    TenQuanCo += "Xe";
                }
                else if (toado_Bandau == Bandau_Phexanh.Toado_Maxanh_1 || toado_Bandau == Bandau_Phexanh.Toado_Maxanh_2 || toado_Bandau == Bandau_Phexanh.Toado_Mado_1 || toado_Bandau == Bandau_Phexanh.Toado_Mado_2)
                {
                    Quanco = new Ma(toado_Bandau);
                    TenQuanCo += "Ma";
                }
                else if (toado_Bandau == Bandau_Phexanh.Toado_Tinhxanh_1 || toado_Bandau == Bandau_Phexanh.Toado_Tinhxanh_2 || toado_Bandau == Bandau_Phexanh.Toado_Tinhdo_1 || toado_Bandau == Bandau_Phexanh.Toado_Tinhdo_2)
                {
                    Quanco = new Tinh(toado_Bandau);
                    TenQuanCo += "Tinh";
                }
                else if (toado_Bandau == Bandau_Phexanh.Toado_Sixanh_1 || toado_Bandau == Bandau_Phexanh.Toado_Sixanh_2 || toado_Bandau == Bandau_Phexanh.Toado_Sido_1 || toado_Bandau == Bandau_Phexanh.Toado_Sido_2)
                {
                    Quanco = new Si(toado_Bandau);
                    TenQuanCo += "Si";
                }
                else if (toado_Bandau == Bandau_Phexanh.Toado_Phaoxanh_1 || toado_Bandau == Bandau_Phexanh.Toado_Phaoxanh_2 || toado_Bandau == Bandau_Phexanh.Toado_Phaodo_1 || toado_Bandau == Bandau_Phexanh.Toado_Phaodo_2)
                {
                    Quanco = new Phao(toado_Bandau);
                    TenQuanCo += "Phao";
                }
                else
                {
                    Quanco = new Tot(toado_Bandau);
                    TenQuanCo += "Tot";
                }
            }
            if (Quanco.Mau == 1)
            {
                base.BackColor = global::CoTuongOffline.Cotuong.Banco.Mau_Phexanh;
                TenQuanCo += " Xanh";
            }
            else if (Quanco.Mau == 2)
            {
                base.BackColor = global::CoTuongOffline.Cotuong.Banco.Mau_Phedo;
                TenQuanCo += " Do";
            }
            Height = Thongso.Duongkinh_Quanco;
            Width = Thongso.Duongkinh_Quanco;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Location = Thongso.TDBC_Quanco(toado_Bandau);
        }

        public void DiChuyen(Point location)
        {
            Quanco.Dichuyen(location);
            Location = Thongso.TDBC_Quanco(location);
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