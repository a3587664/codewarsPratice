using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace codewars_Pratice
{
    [TestClass]
    public class GoodVsEvil
    {
        //[TestMethod]
        public void GoodVsEvil_Test()
        {
            var Kata = new GoodVsEvilKata();
            Assert.AreEqual("Battle Result: Good triumphs over Evil", Kata.GoodVsEvil("0 0 0 0 0 10", "0 1 1 1 1 0 0"));
            Assert.AreEqual("Battle Result: No victor on this battle field", Kata.GoodVsEvil("1 0 0 0 0 0", "1 0 0 0 0 0 0"));
            Assert.AreEqual("Battle Result: Evil eradicates all trace of Good", Kata.GoodVsEvil("1 1 1 1 1 1", "1 1 1 1 1 1 1"));
        }
    }

    public class GoodVsEvilKata
    {
        public string GoodVsEvil(string good, string evil)
        {
            int[] goodPoint = { 1, 2, 3, 3, 4, 10 }, evilPoint = { 1, 2, 2, 2, 3, 5, 10 };
            int sumGood = 0, sumEvil = 0;
            //var GoodArray = good.Split(' ');
            //var EvilArray =evil.Split(' ');
            //for (int i = 0; i < GoodArray.Length; i++)
            //    sumGood+=Int32.Parse(GoodArray[i]) *goodPoint[i];
            //for (int i = 0; i < EvilArray.Length; i++)
            //    sumEvil += Int32.Parse(EvilArray[i]) * evilPoint[i];
            sumGood = good.Split(' ').Select(Int32.Parse).Zip(goodPoint, (first, second) => first * second).Sum();
            sumEvil = evil.Split(' ').Select(Int32.Parse).Zip(evilPoint, (first, second) => first * second).Sum();
            return sumGood == sumEvil
                ? "Battle Result: No victor on this battle field"
                : sumGood > sumEvil
                    ? "Battle Result: Good triumphs over Evil"
                    : "Battle Result: Evil eradicates all trace of Good";
        }
    }
}
