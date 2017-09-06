using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Best_travel
    {
        //[TestMethod]
        public void Best_travel_test() 
        {
            Console.WriteLine("****** Basic Tests");
            List<int> ts = new List<int> { 50, 55, 56, 57, 58 };
            int? n = SumOfK.chooseBestSum(163, 3, ts);
            Assert.AreEqual(163, n);

            //ts = new List<int> { 50 };
            //n = SumOfK.chooseBestSum(163, 3, ts);
            //Assert.AreEqual(null, n);

            //ts = new List<int> { 91, 74, 73, 85, 73, 81, 87 };
            //n = SumOfK.chooseBestSum(230, 3, ts);
            //Assert.AreEqual(228, n);

            //var ts = new List<int> {419,11,455,281,362,81,141,217,118,455,373,153,205,27,351,206,326,11,137,162};
            //var n = SumOfK.chooseBestSum(10, 1, ts);
            //Assert.AreEqual(49, n);
        }
    }

    public static class SumOfK
    {
        public static int? chooseBestSum(int far, int place, List<int> list)
        {
            int sum = 0;
            if (place == list.Count && list.Sum() < far)
                return list.Sum();

            sum = Recursion(0, -1, far, place, list, 0, 0);
            if (sum == 0)
                return null;

            return sum;
        }

        public static int Recursion(int deep, int m, int far, int place, List<int> list, int bestSum, int sum)
        {
            int resSum = 0;
            if (deep == place - 1)
            {
                for (int i = m + 1; i < list.Count; i++)
                {
                    sum += list[i];
                    bestSum = (sum <= far && sum > bestSum) ? sum : bestSum;
                    sum -= list[i];
                }
                return bestSum;
            }
            for (int i = m + 1; i < list.Count - place + deep; i++)
            {
                sum += list[i];
                resSum = Recursion(deep + 1, i, far, place, list, bestSum, sum);
                bestSum = (resSum <= far && resSum > bestSum) ? resSum : bestSum;
                sum -= list[i];
            }
            return bestSum;
        }
    }
}
