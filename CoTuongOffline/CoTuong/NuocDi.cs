using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongOffline.CoTuong
{
    public class Nuocdi
    {
        #region properties

        public Point PrevGreyTargetDepartureLocation { get; set; }
        public Point PrevGreyTargetDestinationLocation { get; set; }
        public Point ToaDoDi { get; set; }
        public Point ToaDoDen { get; set; }
        public global::CoTuongOffline.ProgramConfig.RoundPictureBox QuanCoDiChuyen { get; set; }
        public global::CoTuongOffline.ProgramConfig.RoundPictureBox QuanCoBiLoai { get; set; }

        #endregion

        #region methods

        public Nuocdi()
        {
            PrevGreyTargetDepartureLocation = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            PrevGreyTargetDestinationLocation = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            ToaDoDi = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            ToaDoDen = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            QuanCoDiChuyen = null;
            QuanCoBiLoai = null;
        }

        public void Clear()
        {
            PrevGreyTargetDepartureLocation = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            PrevGreyTargetDestinationLocation = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            ToaDoDi = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            ToaDoDen = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            QuanCoDiChuyen = null;
            QuanCoBiLoai = null;
        }

        public string SerializeNuocDi()
        {
            string result = "1";
            result += ToaDoDi.X.ToString() + ToaDoDi.Y.ToString() + ToaDoDen.X.ToString() + ToaDoDen.Y.ToString();
            return result;
        }

        #endregion
    }
}
