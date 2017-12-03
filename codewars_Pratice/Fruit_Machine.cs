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
            string[] reel = { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            var reels = new List<string[]> { reel, reel, reel };
            int[] spins = { 0, 0, 0 };
            Assert.AreEqual(100, Slot.CalculateScore(reels, spins));
        }

        [TestMethod]
        public void Three_Diff()
        {
            string[] reel1 = { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            string[] reel2 = { "Bar", "Wild", "Queen", "Bell", "King", "Seven", "Cherry", "Jack", "Star", "Shell" };
            string[] reel3 = { "Bell", "King", "Wild", "Bar", "Seven", "Jack", "Shell", "Cherry", "Queen", "Star" };
            List<string[]> reels = new List<string[]> { reel1, reel2, reel3 };
            int[] spins = { 5, 4, 3 };
            Assert.AreEqual(0, Slot.CalculateScore(reels, spins));
        }

        public class Slot
        {
            public static int CalculateScore(List<string[]> reels, int[] spins)
            {
                return reels[0][spins[0]] != reels[1][spins[1]] ? 0 : 100;
            }
        }
    }
}
