using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Leap_Years
    {
        [TestMethod]
        public void Leap_Years_Test()
        {
            Assert.AreEqual(false, LeapYears.IsLeapYear(1234), "Year 1234");
            Assert.AreEqual(true, LeapYears.IsLeapYear(1984), "Year 1984");
            Assert.AreEqual(true, LeapYears.IsLeapYear(2000), "Year 2000");
            Assert.AreEqual(false, LeapYears.IsLeapYear(2010), "Year 2010");
            Assert.AreEqual(false, LeapYears.IsLeapYear(2013), "Year 2013");

        }
    }

    public  class LeapYears
    {
        public static bool IsLeapYear(int year)
        {
            //return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
            return IsLeapYear(year);
        }
    }
}
