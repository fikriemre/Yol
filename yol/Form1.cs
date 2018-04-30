
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace yol
{
    public partial class Form1 : Form
    {
        List<double> points = new List<double>();
        List<float> PRadius = new List<float>();
        List<double> PCurves = new List<double>();
        List<double> Clenghts = new List<double>();
        List<bool> C_Cws = new List<bool>();
        List<double> DuseyPoints = new List<double>();
        float basx2, basy2;
        private List<Kesit> kesitler;
        FormPopup EKSform;
        PointF[] pp;
        PointF k_point;
        PointF p1;
        PointF p2;
        string globalnameKSE;
        string globalname = "";
        double KMO = 0;
        double X_offset = 0;
        double Y_offset = 0;
        float[] scales = { 0.1f, 0.2f, 0.5f, 0.7f, 1, 1.5f, 2, 5, 10, 20, 40, 50 };
        int defscale = 4;
        float offsety = 0;
        float offsetx = 0;


        public Form1()
        {
            InitializeComponent();
            CreateGraphics();
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US", false);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US", false);




        }

        public void starter()
        {
            read_file();
            //if (read_file() == 1)
            //{
            //  write_file();
            // return;
            // }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Random rnd = new Random();
            int v = rnd.Next(500);

            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Red);
            System.Drawing.Pen pen2 = new System.Drawing.Pen(System.Drawing.Color.Blue);
            System.Drawing.Pen pen3 = new System.Drawing.Pen(System.Drawing.Color.Green);

            /*e.Graphics.DrawRectangle(pen2, new System.Drawing.Rectangle(0, 0, v, 500));
            e.Graphics.DrawArc(pen, new System.Drawing.Rectangle(0, 0, v, 500), 90, 90);*/

            /*if (noktalarint != null)
            {
                for (int i = 0; i < noktalarint.Length - 3; i += 2)
                {
                    e.Graphics.DrawLine(pen, (noktalarint[i] * scales[defscale]) + offsetx, (noktalarint[i + 1] * scales[defscale]) + offsety,
                        (noktalarint[i + 2] * scales[defscale]) + offsetx, (noktalarint[i + 3] * scales[defscale]) + offsety);
                }
            }

            if (noktalarint2 != null)
            {
                for (int i = 0; i < noktalarint2.Length - 3; i += 2)
                {
                    e.Graphics.DrawLine(pen2, (noktalarint2[i] * scales[defscale]) + offsetx, (noktalarint2[i + 1] * scales[defscale]) + offsety,
                         (noktalarint2[i + 2] * scales[defscale]) + offsetx, (noktalarint2[i + 3] * scales[defscale]) + offsety);
                }
            }*/
            if (points != null)
            {
                for (int i = 0; i < points.Count - 2; i += 2)
                {
                    e.Graphics.DrawLine(pen3, ((float)points[i] * scales[defscale]) + offsetx, ((float)points[i + 1] * scales[defscale]) + offsety,
                        ((float)points[i + 2] * scales[defscale]) + offsetx, ((float)points[i + 3] * scales[defscale]) + offsety);
                }
            }
            if (PCurves != null)
            {

                for (int i = 0; i < PCurves.Count - 2; i += 2)
                {

                    e.Graphics.DrawLine(pen2, ((float)PCurves[i] * scales[defscale]) + offsetx, ((float)PCurves[i + 1] * scales[defscale]) + offsety, ((float)PCurves[i + 2] * scales[defscale]) + offsetx, ((float)PCurves[i + 3] * scales[defscale]) + offsety);

                }
            }

        }
        void updateGraphic()
        {
            this.Invalidate();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }


        

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Middle)
            {
                double gosterx = e.X + X_offset;
                double gostery = e.Y + Y_offset;
                label4.Text = gosterx.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + "   " + gostery.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture);
            }
            else
            {
                if (p1 == PointF.Empty) p1 = e.Location;
                else if (p2 == PointF.Empty)
                {
                    p2 = e.Location;

                    double sonuc = ((p2.X - p1.X) * (p2.X - p1.X)) + ((p2.Y - p1.Y) * (p2.Y - p1.Y));

                    sonuc = Math.Sqrt(sonuc);


                    sonuc = sonuc / scales[defscale];
                    label1.Text = sonuc.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture);
                    p1 = PointF.Empty;
                    p2 = PointF.Empty;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            defscale--;
            if (defscale < 0) defscale = 0;
            updateGraphic();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            defscale++;
            if (defscale == scales.Length) defscale = scales.Length - 1;

            updateGraphic();
        }

        private void button_alt_Click(object sender, EventArgs e)
        {
            offsety = offsety - trackBar1.Value;
            updateGraphic();
        }

        private void button_sag_Click(object sender, EventArgs e)
        {
            offsetx = offsetx + trackBar1.Value;
            updateGraphic();
        }

        private void button_ust_Click(object sender, EventArgs e)
        {

            offsety = offsety + trackBar1.Value;
            updateGraphic();
        }

        private void button_sol_Click(object sender, EventArgs e)
        {
            offsetx = offsetx - trackBar1.Value;
            updateGraphic();
        }

        private void button_rest_Click(object sender, EventArgs e)
        {
            offsetx = offsetx - k_point.X;
            offsety = offsety - k_point.Y;
            updateGraphic();
        }



        private void Read_Path(object sender, EventArgs e)
        {
            string _path = PathTextBox.Text;
            string readText;
            if (File.Exists(_path))
            {
                ReadPathButton.Text = "Dosya bulundu";
                readText = File.ReadAllText(_path);
                globalname = _path.Split('\\')[_path.Split('\\').Length - 1];
            }
            else { ReadPathButton.Text = "Dosya yok"; return; }
            string[] readData = readText.Split('\n');
            bool getpoints = false;
            bool _KMO = false;
            bool _dusey = false;
            int eklenti = 0;

            List<string> pointsTextArray = new List<string>();
            points = new List<double>();
            PCurves = new List<double>();

            for (int i = 0; i < readData.Length; i++)
            {
                if (readData[i].StartsWith("$KM0")) { _KMO = true; continue; }
                if (readData[i].StartsWith("$YATAY")) { getpoints = true; continue; }
                if (readData[i].StartsWith("$DUSEY")) { _dusey = true; continue; }
                if (readData[i].StartsWith("$SON")) { getpoints = false; _KMO = false; _dusey = false; continue; }
                if (getpoints)
                {
                    pointsTextArray.Add(readData[i]);
                }
                if (_KMO)
                {
                    readData[i] = readData[i].Replace('.', ',');

                    KMO = double.Parse(readData[i]);
                }
                if (_dusey)
                {
                    eklenti = 0;
                    readData[i] = readData[i].Replace('.', ',');
                    readData[i] = System.Text.RegularExpressions.Regex.Replace(readData[i], @"\s+", "*");
                    string[] _Dbuffer = readData[i].Split('*');
                    for (int t = 0 + eklenti; t < 3 + eklenti; t++)
                    {
                        DuseyPoints.Add(double.Parse(_Dbuffer[t]));
                    }

                }

            }
            for (int i = 0; i < pointsTextArray.Count; i++)
            {
                string data = pointsTextArray[i];
                data = data.Replace('.', ',');
                string[] dataarr;
                dataarr = data.Split(' ');
                points.Add(double.Parse(dataarr[2]));
                points.Add(double.Parse(dataarr[1]));

                if (dataarr[3] == null) { PRadius.Add(0.0f); } else { PRadius.Add(float.Parse(dataarr[3])); }

            }
            //points = new PointF[readData.Length - 1];
            double basx = points[0];
            X_offset = points[0];
            double basy = points[1];
            Y_offset = points[1];

            for (int i = 2; i < points.Count - 1; i += 2)
            {
                points[i] = points[i] - basx;
                points[i + 1] = points[i + 1] - basy;
            }
            points[0] = 0;
            points[1] = 0;

            if ((points.Count / 2 - 1) <= 1) { return; }

            for (int i = 1; i < points.Count; i++)
            {
                if (i % 2 == 1 || i >= points.Count - 3) { continue; }
                List<double> Cpoints = new List<double>();
                calculatecurve(i, (double)PRadius[i / 2], out Cpoints);
                PCurves.AddRange(Cpoints);
                //System.Diagnostics.Trace.WriteLine(PRadius[i / 2].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
            }
            // System.Diagnostics.Trace.WriteLine(PCurves.Count.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));


            //////////////////////////////////////////


            _path = KSETextBox.Text;
            if (File.Exists(_path))
            {
                ReadPathButton.Text = "Dosya bulundu";
                readText = File.ReadAllText(_path);
                globalnameKSE = _path.Split('\\')[_path.Split('\\').Length - 1];
            }
            else { ReadPathButton.Text = "Dosya yok"; return; }
            readData = readText.Split('\n');
            Kesit tempKesit;
            kesitler = new List<Kesit>();
            for (int i = 0; i < readData.Length; i++)
            {
                readData[i] = readData[i].Replace(".", ",");
                readData[i] = System.Text.RegularExpressions.Regex.Replace(readData[i], @"\s+", "*");
                if (readData[i].StartsWith("2")) { continue; }
                else if (readData[i].StartsWith("*1"))
                {
                    string[] Kbuffer = readData[i].Split('*');
                    tempKesit = new Kesit(float.Parse(Kbuffer[3]));
                    kesitler.Add(tempKesit);
                }
                else if (readData[i].StartsWith("*0"))
                {
                    string[] Pbuffer = readData[i].Split('*');

                    kesitler[kesitler.Count - 1].addToList(double.Parse(Pbuffer[2]), double.Parse(Pbuffer[3]), Pbuffer[4]);
                }




            }

            /*EKSform = new FormPopup();
            EKSform.Text = "EKS";
            EKSform.SetKesitler(kesitler);
            EKSform.Show(this);*/


            updateGraphic();








        }



        private int read_file()
        {
            string _path = PathTextBox.Text;
            string readText;
            if (File.Exists(_path))
            {
                ReadPathButton.Text = "Dosya bulundu";
                readText = File.ReadAllText(_path);
                globalname = _path.Split('\\')[_path.Split('\\').Length - 1];
            }
            else { ReadPathButton.Text = "Dosya yok"; return 0; }
            string[] readData = readText.Split('\n');
            bool getpoints = false;
            bool _KMO = false;
            bool _dusey = false;
            int eklenti = 0;

            List<string> pointsTextArray = new List<string>();
            points = new List<double>();
            PCurves = new List<double>();

            for (int i = 0; i < readData.Length; i++)
            {
                if (readData[i].StartsWith("$KM0")) { _KMO = true; continue; }
                if (readData[i].StartsWith("$YATAY")) { getpoints = true; continue; }
                if (readData[i].StartsWith("$DUSEY")) { _dusey = true; continue; }
                if (readData[i].StartsWith("$SON")) { getpoints = false; _KMO = false; _dusey = false; continue; }
                if (getpoints)
                {
                    pointsTextArray.Add(readData[i]);
                }
                if (_KMO)
                {
                    readData[i] = readData[i].Replace('.', ',');

                    KMO = double.Parse(readData[i]);
                }
                if (_dusey)
                {
                    eklenti = 0;
                    readData[i] = readData[i].Replace('.', ',');
                    readData[i] = System.Text.RegularExpressions.Regex.Replace(readData[i], @"\s+", "*");
                    string[] _Dbuffer = readData[i].Split('*');
                    if (_Dbuffer[0].Equals("")) eklenti = 1;
                    for (int t = 0 + eklenti; t < 3 + eklenti; t++)
                    {
                        DuseyPoints.Add(double.Parse(_Dbuffer[t]));
                    }

                }

            }
            for (int i = 0; i < pointsTextArray.Count; i++)
            {
                string data = pointsTextArray[i];
                data = data.Replace('.', ',');
                string[] dataarr;
                dataarr = data.Split(' ');
                points.Add(double.Parse(dataarr[2]));
                points.Add(double.Parse(dataarr[1]));

                if (dataarr[3] == null) { PRadius.Add(0.0f); } else { PRadius.Add(float.Parse(dataarr[3])); }

            }
            //points = new PointF[readData.Length - 1];
            double basx = points[0];
            X_offset = points[0];
            double basy = points[1];
            Y_offset = points[1];

            for (int i = 2; i < points.Count - 1; i += 2)
            {
                points[i] = points[i] - basx;
                points[i + 1] = points[i + 1] - basy;
            }
            points[0] = 0;
            points[1] = 0;

            if ((points.Count / 2 - 1) <= 1) { return 0; }

            for (int i = 1; i < points.Count; i++)
            {
                if (i % 2 == 1 || i >= points.Count - 3) { continue; }
                List<double> Cpoints = new List<double>();
                calculatecurve(i, (double)PRadius[i / 2], out Cpoints);
                PCurves.AddRange(Cpoints);
                //System.Diagnostics.Trace.WriteLine(PRadius[i / 2].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
            }
            // System.Diagnostics.Trace.WriteLine(PCurves.Count.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));


            //////////////////////////////////////////


            _path = KSETextBox.Text;
            if (File.Exists(_path))
            {
                ReadPathButton.Text = "Dosya bulundu";
                readText = File.ReadAllText(_path);
                globalnameKSE = _path.Split('\\')[_path.Split('\\').Length - 1];
            }
            else { ReadPathButton.Text = "Dosya yok"; return 0; }
            readData = readText.Split('\n');
            Kesit tempKesit;
            kesitler = new List<Kesit>();
            for (int i = 0; i < readData.Length; i++)
            {
                readData[i] = readData[i].Replace(".", ",");
                readData[i] = System.Text.RegularExpressions.Regex.Replace(readData[i], @"\s+", "*");
                if (readData[i].StartsWith("2")) { continue; }
                else if (readData[i].StartsWith("*1"))
                {
                    string[] Kbuffer = readData[i].Split('*');
                    tempKesit = new Kesit(float.Parse(Kbuffer[3]));
                    kesitler.Add(tempKesit);
                }
                else if (readData[i].StartsWith("*0"))
                {
                    string[] Pbuffer = readData[i].Split('*');

                    kesitler[kesitler.Count - 1].addToList(double.Parse(Pbuffer[2]), double.Parse(Pbuffer[3]), Pbuffer[4]);
                }




            }

            EKSform = new FormPopup();
            EKSform.Text = "EKS";
            EKSform.SetKesitler(kesitler);
            EKSform.Show(this);



            updateGraphic();



            return 1;




        }

        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        void normalizeVector(double InX, double InY, double l, out double Ox, out double Oy)
        {
            double d0 = Math.Sqrt(InX * InX + InY * InY);
            Ox = InX / d0 * l;
            Oy = InY / d0 * l;
        }


        private void write_file()
        {
            double anlikuzunluk = KMO;
            XDocument maindocument = new XDocument();
            XElement landxml = new XElement("LandXml");

            XElement units = new XElement("Units");
            XElement metric = new XElement("Metric");
            metric.SetAttributeValue("areaUnit", "squareMeter");
            metric.SetAttributeValue("linearUnit", "meter");
            metric.SetAttributeValue("volumeUnit", "cubicMeter");
            metric.SetAttributeValue("temperatureUnit", "celsius");
            metric.SetAttributeValue("pressureUnit", "milliBars");
            metric.SetAttributeValue("diameterUnit", "millimeter");
            metric.SetAttributeValue("angularUnit", "decimal degrees");
            metric.SetAttributeValue("directionUnit", "decimal degrees");
            units.Add(metric);
            landxml.Add(units);



            XElement application = new XElement("Application");
            application.SetAttributeValue("name", "HALFSTAR");
            application.SetAttributeValue("desc", "InterSan");
            application.SetAttributeValue("version", "1.0.99");
            application.SetAttributeValue("manufacturerURL", "www.intersanyazilim.com");
            landxml.Add(application);


            XElement project = new XElement("Project");
            project.SetAttributeValue("name", "Project.map");
            landxml.Add(project);

            XElement alignments = new XElement("Alignments");

            XElement alignment = new XElement("Alignment");


            XElement coordgeom = new XElement("CoordGeom");
            XElement line = new XElement("Line");
            line.Add(new XElement("Start", X_offset.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + Y_offset.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
            line.Add(new XElement("End", (PCurves[0] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[1] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
            line.SetAttributeValue("staStart", anlikuzunluk.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
            line.SetAttributeValue("length", uzaklikHesapla(PCurves[0] + X_offset, (PCurves[1] + Y_offset), X_offset, Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
            anlikuzunluk = anlikuzunluk + uzaklikHesapla(PCurves[0] + X_offset, (PCurves[1] + Y_offset), X_offset, Y_offset);
            coordgeom.Add(line);
            XElement curve = new XElement("Curve");
            int lcounter = 0;
            for (int i = 0; i < PCurves.Count - 6; i += 6)
            {
                curve = new XElement("Curve");
                curve.Add(new XElement("Start", (PCurves[i] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[i + 1] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
                curve.Add(new XElement("End", (PCurves[i + 4] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[i + 5] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
                curve.Add(new XElement("Center", (PCurves[i + 2] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[i + 3] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
                curve.SetAttributeValue("staStart", anlikuzunluk.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
                curve.SetAttributeValue("crvType", "arc");
                curve.SetAttributeValue("rot", C_Cws[lcounter] ? "cw" : "ccw");
                curve.SetAttributeValue("radius", PRadius[lcounter + 1].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
                curve.SetAttributeValue("length", Clenghts[lcounter].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
                anlikuzunluk += Clenghts[lcounter];
                lcounter++;
                if (!(PCurves[i + 2] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture).Equals("NaN"))
                {
                    coordgeom.Add(curve);
                }
                line = new XElement("Line");
                line.Add(new XElement("Start", (PCurves[i + 4] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[i + 5] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
                line.Add(new XElement("End", (PCurves[i + 6] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[i + 7] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
                line.SetAttributeValue("staStart", anlikuzunluk.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
                line.SetAttributeValue("length", uzaklikHesapla(PCurves[i + 6], (PCurves[i + 7]), PCurves[i + 4], PCurves[i + 5]).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
                anlikuzunluk += uzaklikHesapla(PCurves[i + 6], (PCurves[i + 7]), PCurves[i + 4], PCurves[i + 5]);
                coordgeom.Add(line);


            }
            int j = PCurves.Count - 6;
            curve = new XElement("Curve");
            curve.Add(new XElement("Start", (PCurves[j] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[j + 1] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
            curve.Add(new XElement("End", (PCurves[j + 4] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[j + 5] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
            curve.Add(new XElement("Center", (PCurves[j + 2] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[j + 3] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
            curve.SetAttributeValue("staStart", anlikuzunluk.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)); anlikuzunluk += Clenghts[lcounter];
            curve.SetAttributeValue("crvType", "arc");
            curve.SetAttributeValue("rot", C_Cws[lcounter] ? "cw" : "ccw");
            curve.SetAttributeValue("radius", PRadius[lcounter + 1].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
            curve.SetAttributeValue("length", Clenghts[lcounter].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
            if (!(PCurves[j + 2] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture).Equals("NaN"))
            {
                coordgeom.Add(curve);
            }
            line = new XElement("Line");
            line.Add(new XElement("Start", (PCurves[j + 4] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[j + 5] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
            line.Add(new XElement("End", ((points[points.Count - 2] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (points[points.Count - 1] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture))));
            line.SetAttributeValue("staStart", anlikuzunluk.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
            line.SetAttributeValue("length", uzaklikHesapla(points[points.Count - 2], points[points.Count - 1], PCurves[j + 4], (PCurves[j + 5])).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));

            anlikuzunluk += uzaklikHesapla(points[points.Count - 2], points[points.Count - 1], PCurves[j + 4], (PCurves[j + 5]));
            coordgeom.Add(line);

            alignment.SetAttributeValue("name", globalname);
            alignment.SetAttributeValue("length", (anlikuzunluk - KMO).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
            alignment.SetAttributeValue("staStart", KMO.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
            alignment.Add(coordgeom);

            XElement profile = new XElement("Profile");
            XElement profalign = new XElement("ProfAlign");
            profalign.SetAttributeValue("name", globalname);
            XElement pvi;
            XElement paracurve;
            for (int u = 0; u <= DuseyPoints.Count - 3; u += 3)
            {
                if (DuseyPoints[u + 2] == 0)
                {
                    pvi = new XElement("PVI", DuseyPoints[u].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + DuseyPoints[u + 1].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
                    profalign.Add(pvi);
                }
                else
                {
                    paracurve = new XElement("ParaCurve", DuseyPoints[u].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + DuseyPoints[u + 1].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
                    paracurve.SetAttributeValue("length", DuseyPoints[u + 2].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
                    profalign.Add(paracurve);
                }

            }

            profile.Add(profalign);
            alignment.Add(profile);


            XElement crosssects = new XElement("CrossSects");
            XElement crosssect;
            XElement crosssectsurf;
            XElement pntlist2d;
            XElement featureN;
            XElement featureC;
            XElement featureI;
            string kesitlerinnoktalari = "";
            string kesitlerinisimleri = "";
            string kesitlerinbaglantilari = "";
            for (int k = 0; k < kesitler.Count; k++)
            {
                crosssect = new XElement("CrossSect");
                crosssect.SetAttributeValue("sta", kesitler[k].baslangic.ToString("0.000", System.Globalization.CultureInfo.CurrentUICulture));

                crosssectsurf = new XElement("CrossSectSurf");
                crosssectsurf.SetAttributeValue("name", globalnameKSE);
                kesitlerinnoktalari = "";
                kesitlerinisimleri = "";
                kesitlerinbaglantilari = "";
                List<string> bironceolanlar = new List<string>();
                for (int p = 0; p < kesitler[k].kesitPoints.Count; p++)
                {

                    kesitlerinnoktalari = kesitlerinnoktalari + kesitler[k].kesitPoints[p].pointx.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " +
                        kesitler[k].kesitPoints[p].pointy.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " ";

                    kesitlerinisimleri = kesitlerinisimleri + kesitler[k].kesitPoints[p].kesitName + ",";

                    if (k != 0)
                    {
                        for (int pp = 0; pp < kesitler[k - 1].kesitPoints.Count; pp++)
                        {
                            if (kesitler[k].kesitPoints[p].kesitName.Equals(kesitler[k - 1].kesitPoints[pp].kesitName))
                            {
                                kesitlerinbaglantilari = kesitlerinbaglantilari + kesitler[k].kesitPoints[p].kesitName + "," + kesitler[k - 1].kesitPoints[pp].kesitName + ",";
                                
                                //break;
                            }
                            else
                            {
                                //bironceolanlar.Add(kesitler[k].kesitPoints[p].kesitName);
                                if(k == 1)
                                richTextBox1.AppendText((kesitler[k].baslangic.ToString() + " -- " + kesitler[k].kesitPoints[p].kesitName + "\n"));

                            }
                        }
                        
                       /* if (k != kesitler.Count - 1)
                        {
                            for (int ppp = 0; ppp < kesitler[k + 1].kesitPoints.Count; ppp++)
                            {
                                if (kesitler[k].kesitPoints[p].kesitName.Equals(kesitler[k + 1].kesitPoints[ppp].kesitName))
                                {
                                    bulundu = true;
                                    break;
                                }
                            }

                            if (bulundu == false)
                            {
                                richTextBox1.AppendText((kesitler[k].baslangic.ToString() + " -- " + kesitler[k].kesitPoints[p].kesitName + "\n"));
                            }
                        }*/

                    }


                    bironceolanlar.Clear();
                }

                
                          


                pntlist2d = new XElement("PntList2D", kesitlerinnoktalari.Remove(kesitlerinnoktalari.Length - 1, 1));
                featureN = new XElement("Feature", kesitlerinisimleri.Remove(kesitlerinisimleri.Length - 1, 1));
                featureN.SetAttributeValue("code", "RR Vertex Name");


                crosssectsurf.Add(pntlist2d);
                crosssectsurf.Add(featureN);

                if (k != 0)
                {

                    featureC = new XElement("Feature");
                    featureC.SetAttributeValue("code", "RR Vertex Connections");

                    featureI = new XElement("Feature", kesitlerinbaglantilari.Remove(kesitlerinbaglantilari.Length - 1, 1));
                    featureI.SetAttributeValue("code", "RR Vertex Interpolate");

                    crosssectsurf.Add(featureC);
                    featureC.Add(featureI);
                }
                crosssect.Add(crosssectsurf);
                crosssects.Add(crosssect);
            }

            alignment.Add(crosssects);
            alignments.Add(alignment);
            landxml.Add(alignments);
            maindocument.Add(landxml);
            maindocument.Save("landxml.xml");


            //this.Close();
            return;

        }

        private void Write_Xml(object sender, EventArgs e)
        {
            write_file();
        }
        //    double anlikuzunluk = KMO;
        //    XDocument maindocument = new XDocument();
        //    XElement landxml = new XElement("LandXml");

        //    XElement units = new XElement("Units");
        //    XElement metric = new XElement("Metric");
        //    metric.SetAttributeValue("areaUnit", "squareMeter");
        //    metric.SetAttributeValue("linearUnit", "meter");
        //    metric.SetAttributeValue("volumeUnit", "cubicMeter");
        //    metric.SetAttributeValue("temperatureUnit", "celsius");
        //    metric.SetAttributeValue("pressureUnit", "milliBars");
        //    metric.SetAttributeValue("diameterUnit", "millimeter");
        //    metric.SetAttributeValue("angularUnit", "decimal degrees");
        //    metric.SetAttributeValue("directionUnit", "decimal degrees");
        //    units.Add(metric);
        //    landxml.Add(units);



        //    XElement application = new XElement("Application");
        //    application.SetAttributeValue("name", "HALFSTAR");
        //    application.SetAttributeValue("desc", "InterSan");
        //    application.SetAttributeValue("version", "1.0.99");
        //    application.SetAttributeValue("manufacturerURL", "www.intersanyazilim.com");
        //    landxml.Add(application);


        //    XElement project = new XElement("Project");
        //    project.SetAttributeValue("name", "Project.map");
        //    landxml.Add(project);

        //    XElement alignments = new XElement("Alignments");

        //    XElement alignment = new XElement("Alignment");


        //    XElement coordgeom = new XElement("CoordGeom");
        //    XElement line = new XElement("Line");
        //    line.Add(new XElement("Start", X_offset.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + Y_offset.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
        //    line.Add(new XElement("End", (PCurves[0] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[1] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
        //    line.SetAttributeValue("staStart", anlikuzunluk.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //    line.SetAttributeValue("length", uzaklikHesapla(PCurves[0] + X_offset, (PCurves[1] + Y_offset), X_offset, Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //    anlikuzunluk = anlikuzunluk + uzaklikHesapla(PCurves[0] + X_offset, (PCurves[1] + Y_offset), X_offset, Y_offset);
        //    coordgeom.Add(line);
        //    XElement curve = new XElement("Curve");
        //    int lcounter = 0;
        //    for (int i = 0; i < PCurves.Count - 6; i += 6)
        //    {
        //        curve = new XElement("Curve");
        //        curve.Add(new XElement("Start", (PCurves[i] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[i + 1] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
        //        curve.Add(new XElement("End", (PCurves[i + 4] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[i + 5] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
        //        curve.Add(new XElement("Center", (PCurves[i + 2] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[i + 3] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
        //        curve.SetAttributeValue("staStart", anlikuzunluk.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //        curve.SetAttributeValue("crvType", "arc");
        //        curve.SetAttributeValue("rot", C_Cws[lcounter] ? "cw" : "ccw");
        //        curve.SetAttributeValue("radius", PRadius[lcounter+1].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //        curve.SetAttributeValue("length", Clenghts[lcounter].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //        anlikuzunluk += Clenghts[lcounter];
        //        lcounter++;
        //        if (!(PCurves[i + 2] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture).Equals("NaN"))
        //        {
        //            coordgeom.Add(curve);
        //        }
        //        line = new XElement("Line");
        //        line.Add(new XElement("Start", (PCurves[i + 4] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[i + 5] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
        //        line.Add(new XElement("End", (PCurves[i + 6] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[i + 7] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
        //        line.SetAttributeValue("staStart", anlikuzunluk.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //        line.SetAttributeValue("length", uzaklikHesapla(PCurves[i + 6], (PCurves[i + 7]), PCurves[i + 4], PCurves[i + 5]).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //        anlikuzunluk += uzaklikHesapla(PCurves[i + 6], (PCurves[i + 7]), PCurves[i + 4], PCurves[i + 5]);
        //        coordgeom.Add(line);

                
        //    }
        //    int j = PCurves.Count - 6;
        //    curve = new XElement("Curve");
        //    curve.Add(new XElement("Start", (PCurves[j] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[j + 1] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
        //    curve.Add(new XElement("End", (PCurves[j + 4] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[j + 5] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
        //    curve.Add(new XElement("Center", (PCurves[j + 2] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[j + 3] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
        //    curve.SetAttributeValue("staStart", anlikuzunluk.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)); anlikuzunluk += Clenghts[lcounter];
        //    curve.SetAttributeValue("crvType", "arc");
        //    curve.SetAttributeValue("rot", C_Cws[lcounter] ? "cw" : "ccw");
        //    curve.SetAttributeValue("radius", PRadius[lcounter + 1].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //    curve.SetAttributeValue("length", Clenghts[lcounter].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //    if (!(PCurves[j + 2] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture).Equals("NaN"))
        //    {
        //        coordgeom.Add(curve);
        //    }
        //    line = new XElement("Line");
        //    line.Add(new XElement("Start", (PCurves[j + 4] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (PCurves[j + 5] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture)));
        //    line.Add(new XElement("End", ((points[points.Count - 2] + X_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (points[points.Count - 1] + Y_offset).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture))));
        //    line.SetAttributeValue("staStart", anlikuzunluk.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //    line.SetAttributeValue("length", uzaklikHesapla(points[points.Count - 2], points[points.Count - 1], PCurves[j + 4], (PCurves[j + 5])).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));

        //    anlikuzunluk += uzaklikHesapla(points[points.Count - 2], points[points.Count - 1], PCurves[j + 4], (PCurves[j + 5]));
        //    coordgeom.Add(line);

        //    alignment.SetAttributeValue("name", globalname);
        //    alignment.SetAttributeValue("length", (anlikuzunluk - KMO).ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //    alignment.SetAttributeValue("staStart", KMO.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //    alignment.Add(coordgeom);

        //    XElement profile = new XElement("Profile");
        //    XElement profalign = new XElement("ProfAlign");
        //    profalign.SetAttributeValue("name", globalname);
        //    XElement pvi;
        //    XElement paracurve;
        //    for (int u = 0; u <= DuseyPoints.Count - 3; u += 3)
        //    {
        //        if (DuseyPoints[u + 2] == 0)
        //        {
        //            pvi = new XElement("PVI", DuseyPoints[u].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + DuseyPoints[u + 1].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //            profalign.Add(pvi);
        //        }
        //        else
        //        {
        //            paracurve = new XElement("ParaCurve", DuseyPoints[u].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + DuseyPoints[u + 1].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //            paracurve.SetAttributeValue("length", DuseyPoints[u + 2].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));
        //            profalign.Add(paracurve);
        //        }

        //    }

        //    profile.Add(profalign);
        //    alignment.Add(profile);


        //    XElement crosssects = new XElement("CrossSects");
        //    XElement crosssect;
        //    XElement crosssectsurf;
        //    XElement pntlist2d;
        //    XElement featureN;
        //    XElement featureC;
        //    XElement featureI;
        //    string kesitlerinnoktalari = "";
        //    string kesitlerinisimleri = "";
        //    string kesitlerinbaglantilari = "";
        //    for (int k = 0; k < kesitler.Count; k++)
        //    {
        //        crosssect = new XElement("CrossSect");
        //        crosssect.SetAttributeValue("sta", kesitler[k].baslangic.ToString("0.000", System.Globalization.CultureInfo.CurrentUICulture));

        //        crosssectsurf = new XElement("CrossSectSurf");
        //        crosssectsurf.SetAttributeValue("name", globalnameKSE);
        //        kesitlerinnoktalari = "";
        //        kesitlerinisimleri = "";
        //        kesitlerinbaglantilari = "";
        //        for (int p = 0; p < kesitler[k].kesitPoints.Count; p++)
        //        {

        //            kesitlerinnoktalari = kesitlerinnoktalari + kesitler[k].kesitPoints[p].pointx.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " +
        //                kesitler[k].kesitPoints[p].pointy.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " ";

        //            kesitlerinisimleri = kesitlerinisimleri + kesitler[k].kesitPoints[p].kesitName + ",";

        //            if (k != 0)
        //            {

        //                for (int pp = 0; pp < kesitler[k - 1].kesitPoints.Count; pp++)
        //                {
        //                    if (kesitler[k].kesitPoints[p].kesitName.Equals(kesitler[k - 1].kesitPoints[pp].kesitName))
        //                    {
        //                        kesitlerinbaglantilari = kesitlerinbaglantilari + kesitler[k].kesitPoints[p].kesitName + "," + kesitler[k - 1].kesitPoints[pp].kesitName + ",";
        //                        break;
        //                    }
        //                }

        //            }
        //        }
        //        pntlist2d = new XElement("PntList2D", kesitlerinnoktalari.Remove(kesitlerinnoktalari.Length - 1, 1));
        //        featureN = new XElement("Feature", kesitlerinisimleri.Remove(kesitlerinisimleri.Length - 1, 1));
        //        featureN.SetAttributeValue("code", "RR Vertex Name");


        //        crosssectsurf.Add(pntlist2d);
        //        crosssectsurf.Add(featureN);

        //        if (k != 0)
        //        {

        //            featureC = new XElement("Feature");
        //            featureC.SetAttributeValue("code", "RR Vertex Connections");

        //            featureI = new XElement("Feature", kesitlerinbaglantilari.Remove(kesitlerinbaglantilari.Length - 1, 1));
        //            featureI.SetAttributeValue("code", "RR Vertex Interpolate");

        //            crosssectsurf.Add(featureC);
        //            featureC.Add(featureI);
        //        }
        //        crosssect.Add(crosssectsurf);
        //        crosssects.Add(crosssect);
        //    }

        //    alignment.Add(crosssects);
        //    alignments.Add(alignment);
        //    landxml.Add(alignments);
        //    maindocument.Add(landxml);
        //    maindocument.Save("landxml.xml");



        //}

        double uzaklikHesapla(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));


        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

        }
        private void OutText_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            starter();
        }

        void calculatecurve(int Pindex, double rad, out List<double> O_points)
        {
            O_points = new List<double>();
            double Xa = points[Pindex - 2];
            double Xb = points[Pindex];
            double Xc = points[Pindex + 2];
            double Ya = points[Pindex - 1];
            double Yb = points[Pindex + 1];
            double Yc = points[Pindex + 3];
            double v1x = Xc - Xb;
            double v1y = Yc - Yb;
            double v2x = Xa - Xb;
            double v2y = Ya - Yb;
            double v3x = Xb - Xa;
            double v3y = Yb - Ya;
            bool _cw = false;
            double angle = Math.Atan2(v1x, v1y) - Math.Atan2(v2x, v2y);
            double nextangle = Math.Atan2(v1x, v1y) - Math.Atan2(v3x, v3y);
            if (nextangle < 0) _cw = true;
            angle = angle * (180 / Math.PI);
            //System.Diagnostics.Trace.Write(angle.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + "////");
            if (angle > 360)
            {
                angle = 360 - angle;
            }
            if (angle >= 0) angle = 180 - angle;
            else { angle = angle + 180; /*_cw = false; */}
            Clenghts.Add(Math.Abs(2 * Math.PI * rad * angle / 360));
            //if (Clenghts[Clenghts.Count - 1] < 0) { _cw = false; }

            
            /*System.Diagnostics.Trace.Write(_cw + "////");
            System.Diagnostics.Trace.WriteLine(Clenghts[Clenghts.Count - 1].ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));*/




           /* double dot = ((Xb - Xa) * (Xc - Xb)) + ((Yb - Ya) * (Yc - Yb));
            _cw = true;
            if (dot <= 0) { _cw = false; }
            */
            C_Cws.Add(_cw);
            System.Diagnostics.Trace.WriteLine(nextangle.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " " + (_cw ? "cw" : "ccw" ));




            double os = rad / Math.Cos(angle / 2 * Math.PI / 180);
            double t = Math.Pow(os, 2) - Math.Pow(rad, 2);
            t = Math.Sqrt(t);
            //System.Diagnostics.Trace.WriteLine(os.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture));

            label2.Text = t.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture);


            double _X = points[Pindex] - points[Pindex - 2];
            double _Y = points[Pindex + 1] - points[Pindex - 1];

            double _X2 = points[Pindex + 2] - points[Pindex];
            double _Y2 = points[Pindex + 3] - points[Pindex + 1];

            normalizeVector(_X, _Y, t, out _X, out _Y);
            normalizeVector(_X2, _Y2, t, out _X2, out _Y2);




            _X2 = points[Pindex] + _X2;
            _Y2 = points[Pindex + 1] + _Y2;

            _X = points[Pindex] - _X;
            _Y = points[Pindex + 1] - _Y;


            //Orta nokta
            double CX = (_X + _X2) / 2;
            double CY = (_Y + _Y2) / 2;
            CX = CX - points[Pindex];
            CY = CY - points[Pindex + 1];
            normalizeVector(CX, CY, Math.Abs(os), out CX, out CY);
            CX = CX + points[Pindex];
            CY = CY + points[Pindex + 1];

            O_points.Add(_X);
            O_points.Add(_Y);
            O_points.Add(CX);
            O_points.Add(CY);
            O_points.Add(_X2);
            O_points.Add(_Y2);
            label3.Text = _X.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + " --- " + _Y.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + "  " + X_offset.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture);
            //richTextBox2.Text = richTextBox2.Text + "\n" + _X.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture) + "\n" + _Y.ToString("0.000000", System.Globalization.CultureInfo.CurrentUICulture);

        }
    }
}
