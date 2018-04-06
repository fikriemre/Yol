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
        PointF k_point;
        System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Red);
        float offsetx = 0;
        float offsety = 0;
        bool bresetView = true;
        bool firstReset = true;
        int lookatIdex = 0;
        float[] scales = { 10f, 20f, 30f, 40f, 50f };
        int defscale = 3;
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

                        pp[k].X = ((pp[k].X) * scales[defscale]) + offsetx;
                        pp[k].Y = ((pp[k].Y + (s * 5)) * scales[defscale]) + offsety;

                        Font font = new Font(FontFamily.GenericSansSerif, 0.3f * scales[defscale], FontStyle.Regular);

                        e.Graphics.DrawString(kesitler[s].kesitPoints[k].kesitName, font, new SolidBrush(Color.Black), pp[k]);
                        if (k == 0) e.Graphics.DrawString(s.ToString() + "  EKS:"+ kesitler[s].baslangic.ToString(), font, new SolidBrush(Color.Black), new PointF(pp[k].X, pp[k].Y - (2 * scales[defscale])));
                        
                        if (k == 0 && s == lookatIdex)
                        {
                            k_point = pp[k];
                            

                        }
                       
                    }
                    //System.Diagnostics.Trace.WriteLine("------");
                    e.Graphics.DrawLines(pen, pp);
                }
            }
            if (bresetView)
            {
                ResetView();                
            }

        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            defscale++;
            ResetView();
            if (defscale == scales.Length) defscale = scales.Length - 1;

            this.Invalidate();
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            defscale--;
            if (defscale < 0) defscale = 0;
            ResetView();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            //offsety = offsety + 100;
            lookatIdex = lookatIdex + 1;
            if (lookatIdex > kesitler.Count - 1) { lookatIdex = kesitler.Count - 1; }
            ResetView();
        }

        private void beforeButton_Click(object sender, EventArgs e)
        {

            lookatIdex = lookatIdex - 1;
            if (lookatIdex <= 0) { lookatIdex = 0; }
            ResetView();
        }

        private void FormPopup_Load(object sender, EventArgs e)
        {
            //burası popup load
        }
        void ResetView()
        {
            offsetx = offsetx - k_point.X + 50;
            offsety = offsety - k_point.Y+150;
            bresetView = false;
            this.Invalidate();
            firstReset = false;
        }
    }
}
