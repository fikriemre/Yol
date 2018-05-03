using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace yol
{
    [Serializable()]
    public class KesitPoint
    {
        public PointF point;
        public double pointx;
        public double pointy;
        public string kesitName;

        public KesitPoint(double px, double py, string _kn)
        {
            kesitName = _kn;
            point = new PointF((float)px, (float)py);
            pointx = px;
            pointy = py;
        }

    }
    [Serializable()]
    public class Kesit
    {
        public List<KesitPoint> kesitPoints = new List<KesitPoint>();

        public float baslangic;
        public Kesit(float _b)
        {
            baslangic = _b;
        }
        public void setList(List<KesitPoint> _kesitPoints)
        {
            kesitPoints = _kesitPoints;
        }
        public Kesit getKesit()
        {
            return this;
        }
        public void addToList(double x, double y, string name)
        {
            kesitPoints.Add(new KesitPoint(x, y, name));
        }
    }
    [Serializable()]
    public class Kesithata
    {
        public Kesit kesit;
        public string info;
        public int kesitindex=0;
        string name;
        public string dname
        {
            get { return name; }
        }
        public int VMindex
        {
            get { return kesitindex; }
        }

        /// <summary>
        /// 0= bos isim 1= aynı isim 2= o ve a yanlış yerde  3= EKS yok
        /// </summary>
        public int hatatipi = -1;
       
        public void setKesithata(Kesit k, int tip,int index)
        {
            kesit = k;
            hatatipi = tip;
            kesitindex = index;
            string hatatipistring="";

            switch(tip)
            {
                case 0:
                    hatatipistring = "Bos isim";
                    break;
                case 1:
                    hatatipistring = "Aynı İsim ->"+ info;
                    break;
                case 2:
                    hatatipistring = "O ve A yanlış yerde";
                    break;
                case 3:
                    hatatipistring = "EKS yok";
                    break;
            }



           
            name = kesit.baslangic.ToString()+" "+hatatipistring;
            


        }

    }
}
