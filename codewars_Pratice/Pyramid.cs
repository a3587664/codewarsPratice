using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Pyramid
    {
        [TestMethod]
        public void SmallPyramidTest()
        {
            var smallPyramid = new[]
            {
                new[] {3},
                new[] {7, 4},
                new[] {2, 4, 6},
                new[] {8, 5, 9, 3}
            };

            Assert.AreEqual(PyramidSlideDown.LongestSlideDown(smallPyramid), 23);
        }

        [TestMethod]
        public void MediumPyramidTest()
        {
            var mediumPyramid = new[]
            {
                new [] {75},
                new [] {95, 64},
                new [] {17, 47, 82},
                new [] {18, 35, 87, 10},
                new [] {20,  4, 82, 47, 65},
                new [] {19,  1, 23, 75,  3, 34},
                new [] {88,  2, 77, 73,  7, 63, 67},
                new [] {99, 65,  4, 28,  6, 16, 70, 92},
                new [] {41, 41, 26, 56, 83, 40, 80, 70, 33},
                new [] {41, 48, 72, 33, 47, 32, 37, 16, 94, 29},
                new [] {53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14},
                new [] {70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57},
                new [] {91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48},
                new [] {63, 66,  4, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31},
                new [] { 4, 62, 98, 27, 23,  9, 70, 98, 73, 93, 38, 53, 60,  4, 23}
            };

            Assert.AreEqual(PyramidSlideDown.LongestSlideDown(mediumPyramid), 1074);
        }
    }

    public class PyramidSlideDown
    {
        public static int LongestSlideDown(int[][] pyramid)
        {
            int sum = pyramid[0][0], tmp = 0;
            for (int i = 1; i < pyramid.Length; i++)
            {
                int numTmp = 0, num2Tmp = 0;
                if (i + 1 >= pyramid.Length)
                {
                    if (pyramid[i][tmp] > pyramid[i][tmp + 1])
                    {
                        sum += pyramid[i][tmp];
                    }
                    else
                    {
                        sum += pyramid[i][tmp + 1];
                        tmp++;
                    }
                }
                else
                {
                    numTmp = pyramid[i + 1][tmp] > pyramid[i + 1][tmp + 1]
                        ? pyramid[i + 1][tmp] : pyramid[i + 1][tmp + 1];
                    num2Tmp = pyramid[i + 1][tmp + 1] > pyramid[i + 1][tmp + 2]
                        ? pyramid[i + 1][tmp + 1]
                        : pyramid[i + 1][tmp + 2];
                    sum += pyramid[i][tmp] + numTmp > pyramid[i][tmp + 1] + num2Tmp ? pyramid[i][tmp] : pyramid[i][tmp + 1];
                    tmp += pyramid[i][tmp] + numTmp > pyramid[i][tmp + 1] + num2Tmp ? 0 : 1;
                }

            }
            return sum;
        }
    }
}
