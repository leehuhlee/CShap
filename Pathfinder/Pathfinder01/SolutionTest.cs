using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinder01
{
    public class SolutionTest
    {
        [Test]
        public void sampleTests()
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

            Assert.AreEqual(true, Finder.PathFinder(a));
            Assert.AreEqual(false, Finder.PathFinder(b));
            Assert.AreEqual(true, Finder.PathFinder(c));
            Assert.AreEqual(false, Finder.PathFinder(d));
        }
    }
}
