using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Worda10n
    {
        //[TestMethod]
        public void TestInternationalization()
        {
            Assert.AreEqual("i18n", Abbreviator.Abbreviate("internationalization"));
        }

        [TestMethod]
        public void TestShortSentance()
        {
            Assert.AreEqual("my. dog, isn't f5g v2y w2l.", Abbreviator.Abbreviate("my. dog, isn't feeling very well."));
        }
    }
    public class Abbreviator
    {
        public static string Abbreviate(string input)
        {
            var words = Regex.Split(input, @"([^a-zA-Z])");
            var output = string.Empty;
            foreach (var word in words)
            {
                if (word.Length < 4)
                {
                    output += word;
                }
                else
                {
                    var length = word.Length - 2;
                    var firstWord = word.Substring(0, 1);
                    var lastWord = word.Substring(word.Length - 1, 1);
                    output += firstWord + length + lastWord;
                }
            }
            return output;
        }
    }
}
