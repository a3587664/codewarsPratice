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
        private List<string[]> _reels = new List<string[]>();

        [SetUp]
        public void Set()
        {
            string[] reel = { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            _reels = new List<string[]> { reel, reel, reel };
        }

        [Test]
        public void Three_Wild()
        {
            int[] spins = { 0, 0, 0 };
            Assert.AreEqual(100, Slot.CalculateScore(_reels, spins));
        }

        [Test]
        public void Three_Diff()
        {
            int[] spins = { 0, 1, 2 };
            Assert.AreEqual(0, Slot.CalculateScore(_reels, spins));
        }

        [Test]
        public void Three_SameItems()
        {
            int[] spins = { 1, 1, 1 };
            Assert.AreEqual(90, Slot.CalculateScore(_reels, spins));
        }

        [Test]
        public void Two_Wild_One_Diff()
        {
            int[] spins = { 0, 0, 1 };
            Assert.AreEqual(10, Slot.CalculateScore(_reels, spins));
        }

        [Test]
        public void Two_SameItems_One_Diff()
        {
            int[] spins = { 3, 1, 1 };
            Assert.AreEqual(9, Slot.CalculateScore(_reels, spins));
            int[] spins2 = { 5, 1, 5 };
            Assert.AreEqual(5, Slot.CalculateScore(_reels, spins2));
            int[] spins3 = { 3, 7, 3 };
            Assert.AreEqual(7, Slot.CalculateScore(_reels, spins3));
        }

        [Test]
        public void Two_Wild_One_Wild()
        {
            int[] spins = { 2, 2, 0 };
            Assert.AreEqual(16, Slot.CalculateScore(_reels, spins));
        }

        public class Slot
        {
            public static int CalculateScore(List<string[]> reels, int[] spins)
            {
                string sameItem = Item.GetSameItem(reels, spins);

                if (Item.IsAllSameItems(reels, spins))
                {
                    return Score.GetAllSameItemScore(sameItem);
                }
                if (Item.IsTwoSameItems(reels, spins))
                {
                    string diffItem = GetDiffItem(reels,spins);
                    return Score.GetTwoSameItemScore(sameItem,diffItem);
                }
                return 0;
            }

            private static string GetDiffItem(List<string[]> reels, int[] spins)
            {
                var firstItem = reels[0][spins[0]];
                var secondItem = reels[1][spins[1]];
                var thirdItem = reels[2][spins[2]];

                if (firstItem == secondItem)
                {
                    return thirdItem;
                }
                if(firstItem == thirdItem)
                {
                    return secondItem;
                }
                    return firstItem;
            }
        }
    }

    internal class Item
    {
        public static string GetSameItem(List<string[]> reels, int[] spins)
        {
            var firstItem = reels[0][spins[0]];
            var secondItem = reels[1][spins[1]];
            var thirdItem = reels[2][spins[2]];

            return firstItem == secondItem ? firstItem : thirdItem;
        }

        public static bool IsTwoSameItems(List<string[]> reels, int[] spins)
        {
            return reels[0][spins[0]] == reels[1][spins[1]] || 
                   reels[0][spins[0]] == reels[2][spins[2]] || 
                   reels[1][spins[1]] == reels[2][spins[2]];
        }

        public static bool IsAllSameItems(List<string[]> reels, int[] spins)
        {
            return reels[0][spins[0]] == reels[1][spins[1]] && 
                   reels[0][spins[0]] == reels[2][spins[2]];
        }
    }

    internal class Score
    {
        public static int GetAllSameItemScore(string item)
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

        public static int GetTwoSameItemScore(string item , string diffItem)
        {
            int tmpScore = 0;
            switch (item)
            {
                case "Wild":
                    tmpScore = 10;
                    break;
                case "Star":
                    tmpScore = 9;
                    break;
                case "Bell":
                    tmpScore = 8;
                    break;
                case "Shell":
                    tmpScore = 7;
                    break;
                case "Seven":
                    tmpScore = 6;
                    break;
                case "Cherry":
                    tmpScore = 5;
                    break;
                case "Bar":
                    tmpScore = 4;
                    break;
                case "King":
                    tmpScore = 3;
                    break;
                case "Queen":
                    tmpScore = 2;
                    break;
                case "Jack":
                    tmpScore = 1;
                    break;
            }
            if (diffItem == "Wild")
                tmpScore *= 2;
            return tmpScore;
        }
    }
}
