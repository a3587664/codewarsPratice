using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace codewars_Pratice
{
    [TestFixture]
    public class SMS_Lottery
    {
        [Test]
        public void normalNumbers_space()
        {
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, Lottery.ValidateBet(5, 90, "1 2 3 4 5"));
        }

        [Test]
        public void inValidInput()
        {
            Assert.AreEqual(null, Lottery.ValidateBet(5, 90, "1, 2; 3, 4, 5"));
        }

        [Test]
        public void inValidInputCount()
        {
            Assert.AreEqual(null, Lottery.ValidateBet(5, 90, "1, 2, 3, 4"));
            Assert.AreEqual(null, Lottery.ValidateBet(5, 90, "1, 2, 3, 4,5 6"));
        }

        [Test]
        public void inValidInputNumRange()
        {
            Assert.AreEqual(null, Lottery.ValidateBet(5, 90, "1, 2, 3, 4, 95"));
        }

        [Test]
        public void normalNumbers_SpaceAndcomma()
        {
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, Lottery.ValidateBet(5, 90, "5 , 3, 1  4,2"));
        }

        [Test]
        public void InputHaveZero()
        {
            Assert.AreEqual(null, Lottery.ValidateBet(5, 90, "1, 2, 3, 4, 0"));
        }

        [Test]
        public void InputHaveSameNum()
        {
            Assert.AreEqual(null, Lottery.ValidateBet(5, 90, "1, 2, 3, 4, 1"));
        }
    }

    class Lottery
    {
        public static int[] ValidateBet(int count, int maxNum, string text)
        {
            try
            {
                var numbers = ConverToNum(text);
                if (IsValidInput(count, maxNum, numbers))
                {
                    numbers.Sort();
                    return numbers.ToArray();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        private static bool IsValidInput(int count, int maxNum, List<int> numbers)
        {
            return !numbers.Any(num => num > maxNum || num <= 0) && (numbers.Distinct().Count() == count && numbers.Count == count);
        }

        private static List<int> ConverToNum(string text)
        {
            return Array.ConvertAll(text.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s)).ToList();
        }
    }
}
