using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace codewars_Pratice
{
    public class Morse_Test
    {
        [Test]
        public void OneWord()
        {
            Assert.AreEqual("ABC", DecodeMorse(".- -... -.-."));
        }

        [Test]
        public void TwoWords()
        {
            Assert.AreEqual("ABC DEF", DecodeMorse(".- -... -.-.   -.. . ..-."));
        }

        [Test]
        public void KataTest()
        {
            Assert.AreEqual("HEY JUDE", DecodeMorse(".... . -.--   .--- ..- -.. ."));
        }

        [Test]
        public void MoreSpaceTest()
        {
            Assert.AreEqual("E E", DecodeMorse("   .   ."));
        }

        private string DecodeMorse(string message)
        {
            return message.Trim()
                          .TrimEnd()
                          .Split(' ')
                          .Aggregate(string.Empty,(x,y) => x + (y == "" ?  " " : MorseCodeDecodeForm[y]))
                          .Replace("  "," ");
        }

        static Dictionary<string, string> MorseCodeDecodeForm = new Dictionary<string, string>()
        {
            { ".-","A"},
            { "-...","B"},
            { "-.-.","C"},
            { "-..","D"},
            { ".","E"},
            { "..-.","F"},
            { "--.","G"},
            { "....","H"},
            { "..","I"},
            { ".---","J"},
            { "-.-","K"},
            { ".-..","L"},
            { "--","M"},
            { "-.","N"},
            { "---","O"},
            { ".--.","P"},
            { "--.-","Q"},
            { ".-.","R"},
            { "...","S"},
            { "-","T"},
            { "..-","U"},
            { "...-","V"},
            { ".--","W"},
            { "-..-","X"},
            { "-.--","Y"},
            { "--..","Z"},
            {"...---...","SOS"},
            {"-.-.--","!"},
            {".-.-.-","."}
        };
    }


}
