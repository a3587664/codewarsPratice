using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Fruit_Machine
    {

        [TestMethod]
        public void Three_Wild()
        {
            string[] reel1 = { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            string[] reel2 = { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            string[] reel3 = { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            var reels = new List<string[]> { reel1, reel2, reel3 };
            int[] spins = { 0, 0, 0 };
            Assert.AreEqual(100, Slot.CalculateScore(reels, spins));
        }

        [TestMethod]
        public void Three_Diff()
        {
            string[] reel1 = { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            string[] reel2 = { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            string[] reel3 = { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            List<string[]> reels = new List<string[]> { reel1, reel2, reel3 };
            int[] spins = { 5, 4, 3 };
            Assert.AreEqual(0, Slot.CalculateScore(reels, spins));
        }

        public class Slot
        {
            public static int CalculateScore(List<string[]> reels, int[] spins)
            {
                if (IsAllSame(reels, spins))
                {
                    return GetAllSameItemScore(reels[0][spins[0]]);
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
