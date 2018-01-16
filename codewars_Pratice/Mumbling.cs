using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Mumbling
    {
        [TestMethod]
        public void hehe()
        {
            Assert.AreEqual("Z-Pp-Ggg-Llll-Nnnnn-Rrrrrr-Xxxxxxx-Qqqqqqqq-Eeeeeeeee-Nnnnnnnnnn-Uuuuuuuuuuu", Accumul.Accum("ZpglnRxqenU"));
        }
    }

    public class Accumul
    {
        public static string Accum(string s)
        {
            string test = "";
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (j == 0)
                    {
                        test += s[i].ToString().ToUpper();
                    }
                    else
                    {
                        test += s[i].ToString().ToLower();
                    }
                }
                if (i != s.Length-1)
                    test += "-";
            }
            return test;
        }
    }
}
