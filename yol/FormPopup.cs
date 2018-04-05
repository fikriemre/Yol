using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yol
{
    public partial class FormPopup : Form
    {
        public List<Kesit> kesitler;
        PointF[] pp;
        System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Red);
        float offsetx = 0;
        float offsety = 0;
        float[] scales = { 0.5f, 1.0f, 2f, 3f, 10f };
        int defscale = 4;
        public FormPopup()
        {
            InitializeComponent();
        }

        public void SetKesitler(List<Kesit> kesitler)
        {
            this.kesitler = kesitler;
        }

        private void FormPopup_Paint(object sender, PaintEventArgs e)
        {
            if (kesitler != null)
            {
                for (int s = 0; s < kesitler.Count; s++)
                {
                    pp = new PointF[kesitler[s].kesitPoints.Count];
                    for (int k = 0; k < kesitler[s].kesitPoints.Count; k++)
                    {
                        pp[k] = kesitler[s].kesitPoints[k].point;

                        pp[k].X = ((pp[k].X + 500) * scales[defscale]) + offsetx;
                        pp[k].Y = ((pp[k].Y + (s * 12)) * scales[defscale]) + offsety;

                        Font font = new Font(FontFamily.GenericSansSerif, 0.3f * scales[defscale], FontStyle.Regular);
                        e.Graphics.DrawString(kesitler[s].kesitPoints[k].kesitName, font, new SolidBrush(Color.Black), pp[k]);
                        if (k == 0) e.Graphics.DrawString(s.ToString(), font, new SolidBrush(Color.Black), new PointF(pp[k].X, pp[k].Y - (2 * scales[defscale])));
                        if (k == 0 && s == 1) {
                            offsetx = offsetx - pp[k].X;
                            offsety = offsety - pp[k].Y;
                        }
                    }
                    e.Graphics.DrawLines(pen, pp);
                }
            }
        }
    }
}
