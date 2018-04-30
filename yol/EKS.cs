﻿using System;
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
            point = new PointF((float)px,(float)py);
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
                kesitPoints.Add(new KesitPoint(x, y,name));
        }
    }
}
