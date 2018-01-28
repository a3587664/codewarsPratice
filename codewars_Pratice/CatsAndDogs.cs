using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace codewars_Pratice
{
    [TestFixture]
    public class CatsAndDogs
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(1, Catch.Solve(new List<char> { 'D', 'C' }, 1));
            Assert.AreEqual(2, Catch.Solve(new List<char> { 'D', 'C', 'C', 'D', 'C' }, 1));
        }
        [Test]
        public void SampleTest1()
        {
            Assert.AreEqual(3, Catch.Solve(new List<char> { 'C', 'C', 'D', 'D', 'C', 'D' }, 2));
            Assert.AreEqual(2, Catch.Solve(new List<char> { 'C', 'C', 'D', 'D', 'C', 'D' }, 1));
        }
        [Test]
        public void SampleTest2()
        {
            Assert.AreEqual(3, Catch.Solve(new List<char> { 'D', 'C', 'D', 'C', 'C', 'D' }, 3));
        }
        [Test]
        public void SampleTest3()
        {
            Assert.AreEqual(2, Catch.Solve(new List<char> { 'C', 'C', 'C', 'D', 'D' }, 3));
            Assert.AreEqual(2, Catch.Solve(new List<char> { 'C', 'C', 'C', 'D', 'D' }, 2));
            Assert.AreEqual(1, Catch.Solve(new List<char> { 'C', 'C', 'C', 'D', 'D' }, 1));
        }

    }

    public class Catch
    {
        public static int Solve(List<char> xs, int n)
        {
            for (int i = 0; i < xs.Count; i++)
            {
                Console.Write(xs[i]);
            }
            int count = 0;
            for (int i = 0; i < xs.Count; i++)
            {
                if (xs[i] == 'D')
                {
                    for (int j = n; j > 0; j--)
                    {
                        if (i - j >= 0 && xs[i - j] == 'C')
                        {
                            xs[i] = 'n';
                            xs[i - j] = 'n';
                            count++;
                            break;
                        }

                    }

                    if (xs[i] == 'D')
                    {
                        for (int j = 1; j <= n; j++)
                        {
                            if (i + j < xs.Count && xs[i + j] == 'C')
                            {
                                xs[i] = 'n';
                                xs[i + j] = 'n';
                                count++;
                                break;
                            }
                        }
                    }

                }
            }
            return count;
        }
    }
}
