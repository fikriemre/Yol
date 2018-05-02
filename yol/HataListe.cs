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
    public partial class HataListe : Form
    {
        Kesit k;
        FormPopup parent;
        List<TextBox> textboxlar = new List<TextBox>();
        List<Label> labels = new List<Label>();
        List<int> errors = new List<int>();
        
        public HataListe()
        {
            InitializeComponent();
        }

        public void SetWindow(FormPopup _p, Kesit _k)
        {             
            k = _k;
            parent = _p;
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

                bb.Click += new EventHandler(ButtonActionClick);


                this.Controls.Add(bb);
                this.Controls.Add(tb);
                this.Controls.Add(ll);
            }
        }

        void ButtonActionClick(object sender, System.EventArgs e)
        {
            Button bt = (Button)sender;
            //labellar[(int)bt.Tag].Invalidate();
            k.kesitPoints[(int)bt.Tag].kesitName = textboxlar[(int)bt.Tag].Text;
            labels[(int)bt.Tag].Text = textboxlar[(int)bt.Tag].Text;
            parent.hatakontrol();

            parent.Invalidate();
        }

      
    }
}
