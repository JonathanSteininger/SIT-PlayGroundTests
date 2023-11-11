using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SohCahToa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {

                    Console.WriteLine("Firsts Point");
                    string input = Console.ReadLine();
                    string[] parts = input.Split(' ');
                    Point startPoint = new Point(parts[0], parts[1]);

                    Console.WriteLine("Second Point");
                    string input2 = Console.ReadLine();
                    string[] parts2 = input2.Split(' ');
                    Point entPoint = new Point(parts2[0], parts2[1]);

                    CalculateAngle(startPoint, entPoint);


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void CalculateAngle(Point startPoint, Point endPoint)
        {
            double temp = Math.Atan2(startPoint.X - endPoint.X, startPoint.Y - endPoint.Y);
            Console.WriteLine(temp / Math.PI * 180);
        }

        private class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                (X,Y) = (x,y);
            }
            public Point(string x, string y)
            {
                    (X, Y) = (int.Parse(x), int.Parse(y));
            }
        }
    }

}
