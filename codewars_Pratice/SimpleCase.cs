using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class SimpleCase
    {
        //[TestMethod] ************************未完成
        public void SimpleCase_Test()
        {
            var Kata = new CountCombinationsKata();
            //Assert.AreEqual(3, Kata.CountCombinations(4, new[] { 1, 2 }));
            //Assert.AreEqual(4, Kata.CountCombinations(10, new[] { 5, 2, 3 }));
            //Assert.AreEqual(0, Kata.CountCombinations(11, new[] { 5, 7 }));
            Assert.AreEqual(14, Kata.CountCombinations(15, new[] { 1, 2, 3, 6, 11 }));
        }
    }

    public class CountCombinationsKata
    {
        public int CountCombinations(int money, int[] coins)
        {
            var List = coins.ToList();
            List.Sort();
            int sum = 0;

            for (int k = 1; k < List.Count + 1; k++)
            {
                for (int i = 0; i < List.Count / k; i++)
                {
                    int tmpSum = 0;
                    for (int j = i; j < k; j++)
                    {
                        tmpSum += List[j];
                    }
                    int tmpMoney = money;
                    while (tmpMoney >= 0)
                    {
                        if (k == 1)
                        {
                            tmpMoney -= List[i];
                        }
                        else
                        {
                            if (tmpMoney - tmpSum >= 0)
                                tmpMoney -= tmpSum;
                        }
                        if (tmpMoney == 0)
                        {
                            sum++;
                            break;
                        }
                        if (tmpMoney - tmpSum < 0)
                        {
                            for (int a = 0; a <= i; a++)
                            {
                                while (tmpMoney >= 0)
                                {
                                    tmpMoney -= List[a];
                                    if (tmpMoney == 0)
                                    {
                                        sum++;
                                        break;
                                    }
                                    if (tmpMoney < 0)
                                        break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return sum;
        }
    }
}
