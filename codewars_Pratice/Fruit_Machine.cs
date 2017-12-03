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
        private List<string[]> reels = new List<string[]>();

        [SetUp]
        public void Set()
        {
            string[] reel = { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            reels = new List<string[]> { reel, reel, reel };
        }

        [Test]
        public void Three_Wild()
        {
            int[] spins = { 0, 0, 0 };
            Assert.AreEqual(100, Slot.CalculateScore(reels, spins));
        }

        [Test]
        public void Three_Diff()
        {
            int[] spins = { 5, 4, 3 };
            Assert.AreEqual(0, Slot.CalculateScore(reels, spins));
        }

        [Test]
        public void Three_SameItems()
        {
            int[] spins = { 1, 1, 1 };
            Assert.AreEqual(90, Slot.CalculateScore(reels, spins));
        }

        public class Slot
        {
            public static int CalculateScore(List<string[]> reels, int[] spins)
            {
                if (IsAllSame(reels, spins))
                {
                    string sameItem = reels[0][spins[0]];
                    return GetAllSameItemScore(sameItem);
                }
                return 0;
            }

            private static bool IsAllSame(List<string[]> reels, int[] spins)
            {
                return reels[0][spins[0]] == reels[1][spins[1]] && reels[0][spins[0]] == reels[2][spins[2]];
            }

            private static int GetAllSameItemScore(string item)
            {
                switch (item)
                {
                    case "Wild":
                        return 100;
                    case "Star":
                        return 90;
                    case "Bell":
                        return 80;
                    case "Shell":
                        return 70;
                    case "Seven":
                        return 60;
                    case "Cherry":
                        return 50;
                    case "Bar":
                        return 40;
                    case "King":
                        return 30;
                    case "Queen":
                        return 20;
                    case "Jack":
                        return 10;
                }
                return 0;
            }
        }
    }
}
