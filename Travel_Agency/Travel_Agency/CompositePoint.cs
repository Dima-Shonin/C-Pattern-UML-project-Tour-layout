using System;
using System.Collections.Generic;
using System.Text;

namespace Travel_Agency
{
    class CompositePoint : Point
    {
        public CompositePoint() { }
        private List<Point> points = new List<Point>();
        public override void AddPoint(Point point) { this.points.Add(point);  }


        public override string GetInfo() 
        {
            string str = "";
            foreach (var item in points)
            {                
                str += item.GetInfo() + "\n";
                
            }
            return str;
        }
    }
}