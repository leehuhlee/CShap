using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace PathFinder04
{
    public class PathFinder
    {
        private static Point p = new Point(0, 0);
        private static Point[] ix = new Point[] { new Point(-1, 0), new Point(0, 1), new Point(1, 0), new Point(0, -1) };
        private static int cd = 0;

        public static Point iAmHere(string s)
        {
            foreach (Match m in Regex.Matches("q" + s, @"[qrRlL]\d*"))
            {
                string ms = m.ToString();
                switch (ms[0])
                {
                    case 'r': cd = (cd + 1) % 4; break;
                    case 'l': cd = (cd + 3) % 4; break;
                    case 'q': break;
                    default: cd = (cd + 2) % 4; break;
                }
                if (ms.Length > 1)
                {
                    int dq = Int32.Parse(ms.Substring(1));
                    p.X += dq * ix[cd].X;
                    p.Y += dq * ix[cd].Y;
                }
            }
            return p;
        }
    }
}
