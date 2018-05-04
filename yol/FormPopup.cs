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
        System.Drawing.Pen penselected = new System.Drawing.Pen(System.Drawing.Color.Blue);
        float offsetx = 0;
        float offsety = 0;
        bool bresetView = true;
        bool firstReset = true;
        int _lookatIndex = 0;
        public int lookatIdex
        {
            get { return _lookatIndex; }
            set
            {
                _lookatIndex = value;
                if (lookatIdex < 0) lookatIdex = 0;
                fillEditpanel();
            }
        }
        List<TextBox> textboxlar = new List<TextBox>();
        List<Label> labels = new List<Label>();
        float[] scales = { 10f, 20f, 30f, 40f, 50f };
        int defscale = 3;
        HataListe hatalistbox;

        List<Kesithata> hatalar;

        public FormPopup()
        {
            lookatIdex = 0;
            InitializeComponent();
            hatalistbox = new HataListe();
        }

        public void SetKesitler(List<Kesit> kesitler)
        {
            this.kesitler = kesitler;

            hatakontrol();

            /*
            for (int i = 0; i<kesitler.Count;i++)
            {
                Hatalarlistbox.Items.Add(i.ToString());
            }*/
            for (int aa = 0; aa < 10; aa++)
            {
                // Hatalarlistbox.Items.Add(kesitler[aa]);
                //Hatalarlistbox.Items[Hatalarlistbox.Items.Count - 1] = a.baslangic.ToString()



                // Hatalarlistbox.Items.Add(new (index = aa,_name="mm"));

                // list.Items.add(new ListBoxItem("name", "value"));
            }
        }
        public void hatakontrol()
        {

            hatalar = new List<Kesithata>();
            
            Hatalarlistbox.Items.Clear();
            for (int s = 0; s < kesitler.Count; s++)
            {
                bool _ekskontrol = true;
                for (int k = 0; k < kesitler[s].kesitPoints.Count; k++)
                {
                    if (_ekskontrol)
                    {
                        if (kesitler[s].kesitPoints[k].kesitName == "EKS") { _ekskontrol = false; }
                    }

                    for (int y = k + 1; y < kesitler[s].kesitPoints.Count; y++)
                    {
                        if (y == k) { continue; }



                        if (kesitler[s].kesitPoints[k].kesitName == kesitler[s].kesitPoints[y].kesitName)
                        {
                            if (kesitler[s].kesitPoints[k].kesitName == "") { continue; }
                            Kesithata hata = new Kesithata();
                            hata.info = kesitler[s].kesitPoints[k].kesitName;
                            hata.setKesithata(kesitler[s], 1, s);
                            hatalar.Add(hata);
                        }
                        if (kesitler[s].kesitPoints[y].kesitName == "")
                        {
                            if (hatalar[hatalar.Count - 1].kesit == kesitler[s] && hatalar[hatalar.Count - 1].hatatipi == 0) { continue; }
                            Kesithata hata = new Kesithata();
                            hata.setKesithata(kesitler[s], 0, s);
                            hatalar.Add(hata);
                        }


                    }

                }
                if (_ekskontrol)
                {
                    Kesithata hata = new Kesithata();
                    hata.setKesithata(kesitler[s], 3, s);
                    hatalar.Add(hata);

                }

            }
            for (int i = 0; i < hatalar.Count; i++)
            {

                Hatalarlistbox.Items.Add(hatalar[i]);
            }
            KesitGoster0.Invalidate();
            KesitGoster1.Invalidate();
            KesitGoster2.Invalidate();

        }
        private void FormPopup_Paint(object sender, PaintEventArgs e)
        {
            return;
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

                        if (s == lookatIdex)
                        {
                            e.Graphics.DrawString(kesitler[s].kesitPoints[k].kesitName, font, new SolidBrush(Color.Black), pp[k]);
                            if (k == 0)
                            {
                                e.Graphics.DrawString(s.ToString() + "  EKS:" + kesitler[s].baslangic.ToString(), font, new SolidBrush(Color.Blue), new PointF(pp[k].X, pp[k].Y - (2 * scales[defscale])));
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString(kesitler[s].kesitPoints[k].kesitName, font, new SolidBrush(Color.Black), pp[k]);
                            if (k == 0)
                            {
                                e.Graphics.DrawString(s.ToString() + "  EKS:" + kesitler[s].baslangic.ToString(), font, new SolidBrush(Color.Black), new PointF(pp[k].X, pp[k].Y - (2 * scales[defscale])));
                            }
                        }
                        if (k == 0 && s == lookatIdex)
                        {
                            k_point = pp[k];
                        }

                    }
                    //System.Diagnostics.Trace.WriteLine("------");
                    if (s == lookatIdex) e.Graphics.DrawLines(penselected, pp);
                    else e.Graphics.DrawLines(pen, pp);
                }
            }


        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            /* defscale++;
             ResetView();
             if (defscale == scales.Length) defscale = scales.Length - 1;

             this.Invalidate();*/
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            /*defscale--;
            if (defscale < 0) defscale = 0;
            ResetView();*/
        }

        private void beforeButton_Click(object sender, EventArgs e)
        {
            //offsety = offsety + 100;
            lookatIdex = lookatIdex - 1;
            if (lookatIdex <= 0) { lookatIdex = 0; }
            KesitGoster0.Invalidate();
            KesitGoster1.Invalidate();
            KesitGoster2.Invalidate();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {

            Hatalarlistbox.SelectedIndex = -1;
            lookatIdex = lookatIdex + 1;
            if (lookatIdex > kesitler.Count - 1) { lookatIdex = kesitler.Count - 1; }
            KesitGoster0.Invalidate();
            KesitGoster1.Invalidate();
            KesitGoster2.Invalidate();
        }

        private void FormPopup_Load(object sender, EventArgs e)
        {
            //burası popup load
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            if (!hatalistbox.IsDisposed)
            {
                hatalistbox.SetWindow(this, kesitler[lookatIdex]);
                hatalistbox.Show(this);
            }
            else
            {
                hatalistbox = new HataListe();
                hatalistbox.SetWindow(this, kesitler[lookatIdex]);
                hatalistbox.Show(this);
            }



        }


        private void kesitciz(int index, PaintEventArgs e)
        {
            int s = index;
            pp = new PointF[kesitler[s].kesitPoints.Count];


            PointF _offsetmin = kesitler[s].kesitPoints[0].point;
            PointF _offsetmax = kesitler[s].kesitPoints[kesitler[s].kesitPoints.Count - 1].point;

            for (int l = 0; l < kesitler[s].kesitPoints.Count; l++)
            {
                if ((kesitler[s].kesitPoints[l].point.Y) <= _offsetmin.Y) { _offsetmin.Y = kesitler[s].kesitPoints[l].point.Y; }
                if ((kesitler[s].kesitPoints[l].point.Y) >= _offsetmax.Y) { _offsetmax.Y = kesitler[s].kesitPoints[l].point.Y; }
            }


            float _scale = 450 / (_offsetmax.X - _offsetmin.X);
            float _yoffset = (_offsetmax.Y - _offsetmin.Y) * _scale;

            //if (_yoffset < 50) { _yoffset = 50 - _yoffset / 2; } else { _yoffset = 50 + _yoffset/2; }




            for (int k = 0; k < kesitler[s].kesitPoints.Count; k++)
            {
                pp[k] = kesitler[s].kesitPoints[k].point;

                pp[k].X = (pp[k].X - _offsetmin.X) * _scale + 50;
                pp[k].Y = (pp[k].Y - _offsetmin.Y) * _scale;




                Font font = new Font(FontFamily.GenericSansSerif, 0.3f * scales[defscale], FontStyle.Regular);
                /*
                if (k == lookatIdex)
                {
                    e.Graphics.DrawString(kesitler[s].kesitPoints[k].kesitName, font, new SolidBrush(Color.Black), pp[k]);
                    if (k == 0)
                    {
                        e.Graphics.DrawString(s.ToString() + "  EKS:" + kesitler[s].baslangic.ToString(), font, new SolidBrush(Color.Blue), new PointF(pp[k].X, pp[k].Y - (2 * scales[defscale])));
                    }
                }
                else*/
                e.Graphics.DrawString(kesitler[s].kesitPoints[k].kesitName, font, new SolidBrush(Color.Blue), pp[k]);
                if (k == 0)
                {
                    e.Graphics.DrawString(s.ToString() + "  EKS:" + kesitler[s].baslangic.ToString(), font, new SolidBrush(Color.Black), new PointF(pp[k].X, pp[k].Y - (2 * scales[defscale])));
                }


            }
            //System.Diagnostics.Trace.WriteLine("------");
            //if (s == lookatIdex) e.Graphics.DrawLines(penselected, pp);
            //  else e.Graphics.DrawLines(pen, pp);
            e.Graphics.DrawLines(pen, pp);



        }

        private void KesitGoster0_Paint(object sender, PaintEventArgs e)
        {
            int _index = lookatIdex - 1;
            if (lookatIdex == 0) { Kesitisim0.Text = ""; return; }
            kesitciz(_index, e);
            Kesitisim0.Text = kesitler[_index].baslangic.ToString();

        }

        private void KesitGoster1_Paint(object sender, PaintEventArgs e)
        {
            int _index = lookatIdex;
            if (lookatIdex == 0) { _index = 0; }

            kesitciz(_index, e);
            kesitisim1.Text = kesitler[_index].baslangic.ToString();
        }

        private void KesitGoster2_Paint(object sender, PaintEventArgs e)
        {
            int _index = lookatIdex + 1;
            if (lookatIdex == 0) { _index = 1; }
            if (_index >= kesitler.Count) { Kesitisim2.Text = ""; return; }
            kesitciz(_index, e);
            Kesitisim2.Text = kesitler[_index].baslangic.ToString();
        }

        private void Hatalarlistbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Kesit a = (Kesit)Hatalarlistbox.Items[Hatalarlistbox.SelectedIndex];
            //MessageBox.Show(a.kesitPoints[0].pointx.ToString());
            //  lookatIdex = Hatalarlistbox.SelectedIndex;
            // lookatIdex = (int)Hatalarlistbox.SelectedValue;
            if (Hatalarlistbox.SelectedIndex == -1) { return; }
            Kesithata v = (Kesithata)Hatalarlistbox.SelectedItem;
            lookatIdex = v.kesitindex;

            KesitGoster0.Invalidate();
            KesitGoster1.Invalidate();
            KesitGoster2.Invalidate();

        }
        private void fillEditpanel()
        {
                        
            if (kesitler == null) { return; }
            if(lookatIdex>= kesitler.Count) { return; }
            if (EditPanel.Controls.Count > 0) { EditPanel.Controls.Clear(); }
            if (textboxlar.Count>0)
            {
                textboxlar.Clear();
                labels.Clear();
            }
            Kesit k = kesitler[lookatIdex];
            
            for (int i = 0; i < k.kesitPoints.Count; i++)
            {
                Label ll = new Label();
                ll.Text = k.kesitPoints[i].kesitName;
                ll.Location = new Point(120, 20 + (i * 30));
                labels.Add(ll);

                TextBox tb = new TextBox();
                tb.Text = k.kesitPoints[i].kesitName;
                tb.Location = new Point(200, 20 + (i * 30));
                textboxlar.Add(tb);

                Button bb = new Button();
                bb.Text = "Değiştir";
                bb.Tag = i;
                bb.Location = new Point(400, 20 + (i * 30));

                bb.Click += new EventHandler(degistirbutonEvent);


                EditPanel.Controls.Add(bb);
                EditPanel.Controls.Add(tb);
                EditPanel.Controls.Add(ll);
            }
        }
        void degistirbutonEvent(object sender, System.EventArgs e)
        {
            Kesit k = kesitler[lookatIdex];
            Button bt = (Button)sender;
            //labellar[(int)bt.Tag].Invalidate();
            k.kesitPoints[(int)bt.Tag].kesitName = textboxlar[(int)bt.Tag].Text;
            labels[(int)bt.Tag].Text = textboxlar[(int)bt.Tag].Text;
            hatakontrol();            
        }
    }
}
