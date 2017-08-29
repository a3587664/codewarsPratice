using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Power_of_two
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(POT.PowerOfTwo(536870912));
        }
    }

    public static class POT
    {
        public static bool PowerOfTwo(int n)
        {
            
            int tmp = 2;
            while (tmp<n)
            {
                tmp *= 2;
            }
            return tmp == n ? true : false;
        }
    }
}
