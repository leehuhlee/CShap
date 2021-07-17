using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinder03
{
    public class SolutionTest
    {
        [Test]
        public void SampleTests()
        {

            string a = "000\n" +
                       "000\n" +
                       "000",

                   b = "010\n" +
                       "010\n" +
                       "010",

                   c = "010\n" +
                       "101\n" +
                       "010",

                   d = "0707\n" +
                       "7070\n" +
                       "0707\n" +
                       "7070",

                   e = "700000\n" +
                       "077770\n" +
                       "077770\n" +
                       "077770\n" +
                       "077770\n" +
                       "000007",

                   f = "777000\n" +
                       "007000\n" +
                       "007000\n" +
                       "007000\n" +
                       "007000\n" +
                       "007777",

                   g = "000000\n" +
                       "000000\n" +
                       "000000\n" +
                       "000010\n" +
                       "000109\n" +
                       "001010";

            Assert.AreEqual(0, Finder.PathFinder(a));
            Assert.AreEqual(2, Finder.PathFinder(b));
            Assert.AreEqual(4, Finder.PathFinder(c));
            Assert.AreEqual(42, Finder.PathFinder(d));
            Assert.AreEqual(14, Finder.PathFinder(e));
            Assert.AreEqual(0, Finder.PathFinder(f));
            Assert.AreEqual(4, Finder.PathFinder(g));
        }
    }
}
