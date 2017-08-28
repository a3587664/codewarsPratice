using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class ShouldBeWorthless
    {
        //[TestMethod]
        public void ShouldBeWorthless_Test()
        {
            var Kata = new Greed_is_Good();
            Assert.AreEqual(0, Kata.Score(new int[] { 2, 3, 4, 6, 2 }), "Should be 0 :-(");
            Assert.AreEqual(400, Kata.Score(new int[] { 4, 4, 4, 3, 3 }), "Should be 400");
            Assert.AreEqual(450, Kata.Score(new int[] { 2, 4, 4, 5, 4 }), "Should be 450");
            Assert.AreEqual(1100, Kata.Score(new int[] { 1, 1, 1, 1, 2 }));
        }
    }

    public class Greed_is_Good
    {
        public int Score(int[] dice)
        {
            int one = (from a in dice where a == 1 select a).Count(),
                two = (from a in dice where a == 2 select a).Count(),
                three = (from a in dice where a == 3 select a).Count(),
                four = (from a in dice where a == 4 select a).Count(),
                five = (from a in dice where a == 5 select a).Count(),
                six = (from a in dice where a == 6 select a).Count(),
                sum = 0;
            sum += (one - (3 * (one / 3))) * 100 + ((one / 3) * 1000);
            sum += two / 3 * 200;
            sum += three / 3 * 300;
            sum += four / 3 * 400;
            sum += (five - (3 * (five / 3))) * 50 + ((five / 3) * 500);
            sum += six / 3 * 600;
            return sum;
        }
    }
}
