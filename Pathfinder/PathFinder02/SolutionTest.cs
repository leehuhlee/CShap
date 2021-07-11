using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathFinder02
{
    public class SolutionTest
    {

        [Test]
        public void TestBasic()
        {

            string a = ".W.\n" +
                       ".W.\n" +
                       "...",

                   b = ".W.\n" +
                       ".W.\n" +
                       "W..",

                   c = "......\n" +
                       "......\n" +
                       "......\n" +
                       "......\n" +
                       "......\n" +
                       "......",

                   d = "......\n" +
                       "......\n" +
                       "......\n" +
                       "......\n" +
                       ".....W\n" +
                       "....W.";

            Assert.AreEqual(4, Finder.PathFinder(a));
            Assert.AreEqual(-1, Finder.PathFinder(b));
            Assert.AreEqual(10, Finder.PathFinder(c));
            Assert.AreEqual(-1, Finder.PathFinder(d));
        }
    }

}
