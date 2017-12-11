using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace codewars_Pratice
{
    [TestFixture]
    public class Fruit_Machine
    {
        private static List<string[]> _reels = new List<string[]>();
        private static Dictionary<string, int> ItemsScore = new Dictionary<string, int>()
        {
            { "Wild" , 10 },
            { "Star" , 9 },
            { "Bell" , 8 },
            { "Shell" , 7 },
            { "Seven" , 6 },
            { "Cherry" , 5 },
            { "Bar" , 4 },
            { "King" , 3 },
            { "Queen" , 2 },
            { "Jack" , 1 }
        };

        [SetUp]
        public void Set()
        {
            string[] reel = { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            _reels = new List<string[]> { reel, reel, reel };
        }

        [Test]
        public void Three_Diff()
        {
            int[] spins = { 0, 1, 2 };
            Assert.AreEqual(0, Slot.CalculateScore(spins));
            int[] spins2 = { 3, 5, 7 };
            Assert.AreEqual(0, Slot.CalculateScore(spins2));
        }

        [Test]
        public void Three_SameItems()
        {
            int[] spins = { 1, 1, 1 };
            Assert.AreEqual(90, Slot.CalculateScore(spins));
            int[] spins2 = { 0, 0, 0 };
            Assert.AreEqual(100, Slot.CalculateScore(spins2));
        }

        [Test]
        public void Two_SameItems_One_Diff()
        {
            int[] spins = { 0, 1, 1 };
            Assert.AreEqual(18, Slot.CalculateScore(spins));
            int[] spins2 = { 5, 1, 5 };
            Assert.AreEqual(5, Slot.CalculateScore(spins2));
        }

        public class Slot
        {
            public static int CalculateScore(int[] spins)
            {
                string sameSpinsItem = GetSameItem(spins);
                string onlyOneItem = GetOnlyOneItem(spins);

                if (sameSpinsItem == null)
                {
                    return 0;
                }

                if (onlyOneItem == null)
                {
                    var allSameItemScore = ItemsScore[sameSpinsItem] * 10;
                    return allSameItemScore;
                }

                if (onlyOneItem == "Wild")
                {
                    var twoSameItemScore = ItemsScore[sameSpinsItem] * 2;
                    return twoSameItemScore;
                }

                return ItemsScore[sameSpinsItem];
            }

            public static string GetSameItem(int[] spins)
            {
                var firstItem = _reels[0][spins[0]];
                var secondItem = _reels[1][spins[1]];
                var thirdItem = _reels[2][spins[2]];

                if (firstItem == secondItem || firstItem == thirdItem)
                {
                    return firstItem;
                }
                if (secondItem == thirdItem)
                {
                    return secondItem;
                }
                return null;
            }

            public static string GetOnlyOneItem(int[] spins)
            {
                var firstItem = _reels[0][spins[0]];
                var secondItem = _reels[1][spins[1]];
                var thirdItem = _reels[2][spins[2]];

                if (firstItem == secondItem && firstItem == thirdItem)
                {
                    return null;
                }
                if (firstItem == secondItem)
                {
                    return thirdItem;
                }
                if (firstItem == thirdItem)
                {
                    return secondItem;
                }
                return firstItem;
            }
        }
    }
}
