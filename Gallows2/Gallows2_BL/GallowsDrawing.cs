using System;
using System.Collections.Generic;
using System.Drawing;

namespace Gallows2_BL
{
    public static class GallowsDrawing
    {
        private static List<Point> pts = new List<Point>();
        
        private static Dictionary<int,List<Point>> gallowItems = new Dictionary<int, List<Point>>();

        public static void DefineGallowElementsPositions()
        {
            // Define the points in the polygonal path.
            AssignGallowItems(0, new Point(30, 350), new Point(80, 290), new Point(90, 290), new Point(40, 350));
            AssignGallowItems(1, new Point(80, 290), new Point(90, 290), new Point(140, 350), new Point(130, 350));
            AssignGallowItems(2, new Point(80, 290), new Point(80, 40), new Point(90, 40), new Point(90, 290));
            AssignGallowItems(3, new Point(90, 40), new Point(180, 40), new Point(180, 50), new Point(90, 50));
            AssignGallowItems(4, new Point(90, 90), new Point(130, 50), new Point(120, 50), new Point(90, 80));
            AssignGallowItems(5, new Point(170, 50), new Point(170, 90), new Point(180, 90), new Point(180, 50));
            AssignGallowItems(6, new Point(150, 90), new Point(200, 90), new Point(200, 140), new Point(150, 140));
            AssignGallowItems(7, new Point(170, 140), new Point(180, 140), new Point(180, 220), new Point(170, 220));
            AssignGallowItems(8, new Point(170, 220), new Point(180, 220), new Point(140, 270), new Point(130, 270));
            AssignGallowItems(9, new Point(170, 220), new Point(180, 220), new Point(210, 270), new Point(200, 270));
            AssignGallowItems(10, new Point(170, 160), new Point(170, 170), new Point(130, 180), new Point(130, 170));
            AssignGallowItems(11, new Point(180, 160), new Point(180, 170), new Point(220, 180), new Point(220, 170));
        }

         private static void AssignGallowItems(int sequenceNumber, Point p1, Point p2, Point p3, Point p4)
        {
            pts = new List<Point> {p1,p2,p3,p4};
            gallowItems.Add(sequenceNumber, pts);
        }
        public static List<Point> GetPoint(int sequenceNumber)
        {
            return gallowItems[sequenceNumber];
        }        
    }
}
