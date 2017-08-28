using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class UnitTest2
    {
        //[TestMethod]
        public void PrimeDecomp_Test()
        {
            var kata = new PrimeDecomp();
            int lst = 7775460;
            Assert.AreEqual("(2**2)(3**3)(5)(7)(11**2)(17)", kata.factors(lst));
        }
    }

    public class PrimeDecomp
    {
        public String factors(int lst)
        {
            List<int> AllNum = new List<int>();
            List<int> Pow = new List<int>();
            string Ans = "";
            for (int i = 2; i <= lst; i++)
            {
                if (lst % i == 0)
                {
                    int count = 0;
                    while (lst % i == 0)
                    {
                        lst /= i;
                        count++;
                    }
                    AllNum.Add(i);
                    Pow.Add(count);
                    Ans += count == 1 ? "(" + i + ")" : "(" + i + "**" + count + ")";
                }
            }
            return Ans;
        }
    }
}
