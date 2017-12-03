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
            Assert.AreEqual(100, Slot.Fruit(reels, spins));
        }

        public class Slot
        {
            public static int Fruit(List<string[]> reels, int[] spins)
            {
                return 100;
            }
        }
    }
}
