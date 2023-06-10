using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongOffline.CoTuong
{
    public class NuocDi
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

        public NuocDi()
        {
            PrevGreyTargetDepartureLocation = global::CoTuongOffline.ProgramConfig.ThongSo.ToaDoNULL;
            PrevGreyTargetDestinationLocation = global::CoTuongOffline.ProgramConfig.ThongSo.ToaDoNULL;
            ToaDoDi = global::CoTuongOffline.ProgramConfig.ThongSo.ToaDoNULL;
            ToaDoDen = global::CoTuongOffline.ProgramConfig.ThongSo.ToaDoNULL;
            QuanCoDiChuyen = null;
            QuanCoBiLoai = null;
        }

        public void Clear()
        {
            PrevGreyTargetDepartureLocation = global::CoTuongOffline.ProgramConfig.ThongSo.ToaDoNULL;
            PrevGreyTargetDestinationLocation = global::CoTuongOffline.ProgramConfig.ThongSo.ToaDoNULL;
            ToaDoDi = global::CoTuongOffline.ProgramConfig.ThongSo.ToaDoNULL;
            ToaDoDen = global::CoTuongOffline.ProgramConfig.ThongSo.ToaDoNULL;
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
