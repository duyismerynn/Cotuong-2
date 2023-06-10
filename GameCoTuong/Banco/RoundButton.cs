using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTuongLAN.ProgramConfig
{
    public class RoundButton : Button
    {
        #region attributes

        #endregion

        #region methods
        public RoundButton() { }
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(5, 5, ClientSize.Width - 9, ClientSize.Height - 9);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }
        #endregion
    }
}