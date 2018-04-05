using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace yol
{
    public class KesitPoint
    {
        public PointF point;
        public string kesitName;

        public KesitPoint(PointF _kp, string _kn)
        {
            kesitName = _kn;
            point = _kp;
            //muzodeneme
            //ekleme22

        }

    }
    public class Kesit
    {
        public List<KesitPoint> kesitPoints = new List<KesitPoint>();
        float baslangic;
        public Kesit(float _b)
        {
            baslangic = _b;
        }

        public void addToList(float x,float y, string name)
        {
            kesitPoints.Add(new KesitPoint(new PointF(x,y),name));
        }
    }
}
