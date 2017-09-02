using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Counting_Duplicates
    {
        [TestMethod]
        public void DuplicatesTests()
        {
            Assert.AreEqual(7, Duplicates.DuplicateCount("190187186180188182196202187190196180187183195181178176171172"));
            Assert.AreEqual(0, Duplicates.DuplicateCount("abcde"));
            Assert.AreEqual(2, Duplicates.DuplicateCount("aabbcde"));
            Assert.AreEqual(2, Duplicates.DuplicateCount("aabBcde"), "should ignore case");
            Assert.AreEqual(1, Duplicates.DuplicateCount("Indivisibility"));
            Assert.AreEqual(2, Duplicates.DuplicateCount("Indivisibilities"), "characters may not be adjacent");

        }
    }

    public class Duplicates
    {
        public static int DuplicateCount(string str)
        {
            int tmp = 0,count=0,same=0,i=0;
            str=str.ToUpper();
            var List = str.ToList();
            var copy = List.ToList();
            bool check = false;
            while (true)
            {
                if (i == List.Count || copy.Count == 0)
                    break;
                if (List[i] == copy[count])
                {
                    same++;
                    if (same>1 && !check)
                    {
                         tmp++;
                         check = true;                                        
                    }
                    copy.Remove(copy[count]);
                }
                else
                {
                    count++;
                }
                if (count == copy.Count)
                {
                    check = false;
                    count = 0;
                    same = 0;
                    i++;                    
                }
            }
            return tmp;
        }
    }
}
