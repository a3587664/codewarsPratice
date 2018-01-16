using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Worda10n
    {
        [TestMethod]
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
            return string.Join("", Regex.Split(input, @"([^a-zA-Z])").Select(word => word.Length < 4 ? word : word.First() + (word.Length - 2).ToString() + word.Last()));
        }

        private static string WordAbbreviate(string word)
        {
            return word.Length < 4 ? word : word.First() + (word.Length - 2).ToString() + word.Last();
        }
    }
}
