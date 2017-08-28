using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class UnitTest3
    {
        //[TestMethod]
        public void StringMerger_test()
        {
            //Assert.IsTrue(StringMerger.isMerge("cca", "ca", "cc"), "codewars can be created from code and wars");
            // Assert.IsTrue(StringMerger.isMerge("codewars", "cdwr", "oeas"), "codewars can be created from cdwr and oeas");
            Assert.IsFalse(StringMerger.isMerge("codewars", "code", "wasr"), "Codewars are not codwars");
        }
    }
    public class StringMerger
    {
        public static bool isMerge(string s, string part1, string part2)
        {
            var sList = s.ToList();
            var tmp = (part1 + part2).ToList();
            int count = 0;
            for (int i = 0; i < sList.Count; i++)
            {
                for (int j = 0; j < tmp.Count; j++)
                {
                    if (sList[i] == tmp[j])
                    {
                        count++;
                        tmp.Remove(tmp[j]);
                    }
                }
            }
            return sList.Count != (part1 + part2).Length ? false : count == s.Length;
        }
    }
}
