using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTuongOffline.Cotuong
{
    public class Nuocdi
    {
        #region properties

        public Point PrevGreyTargetDepartureLocation { get; set; }
        public Point PrevGreyTargetDestinationLocation { get; set; }
        public Point Toado_Di { get; set; }
        public Point Toado_Den { get; set; }
        public global::CoTuongOffline.ProgramConfig.RoundPictureBox Quanco_Dichuyen { get; set; }
        public global::CoTuongOffline.ProgramConfig.RoundPictureBox Quanco_Biloai { get; set; }

        #endregion

        #region methods

        public Nuocdi()
        {
            PrevGreyTargetDepartureLocation = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            PrevGreyTargetDestinationLocation = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            Toado_Di = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            Toado_Den = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            Quanco_Dichuyen = null;
            Quanco_Biloai = null;
        }

        public void Clear()
        {
            PrevGreyTargetDepartureLocation = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            PrevGreyTargetDestinationLocation = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            Toado_Di = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            Toado_Den = global::CoTuongOffline.ProgramConfig.Thongso.Toado_NULL;
            Quanco_Dichuyen = null;
            Quanco_Biloai = null;
        }

        public string SerializeNuocDi()
        {
            string result = "1";
            result += Toado_Di.X.ToString() + Toado_Di.Y.ToString() + Toado_Den.X.ToString() + Toado_Den.Y.ToString();
            return result;
        }

        #endregion
    }
}
