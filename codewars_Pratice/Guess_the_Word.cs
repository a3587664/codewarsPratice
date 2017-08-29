using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Guess_the_Word
    {
        [TestMethod]       
            public void GuesserTest()
            {
            //[TestCase("dog", "car", 0)]
            //    [TestCase("dog", "god", 1)]
            //    [TestCase("dog", "cog", 2)]
            //    [TestCase("dog", "cod", 1)]
            //    [TestCase("dog", "bog", 2)]
            //    [TestCase("dog", "dog", 3)]

            Assert.AreEqual(0, WordGuesser.CountCorrectCharacters("dog", "car"));
                Assert.AreEqual(1, WordGuesser.CountCorrectCharacters("dog", "god"));
                Assert.AreEqual(2, WordGuesser.CountCorrectCharacters("dog", "cog"));
                Assert.AreEqual(1, WordGuesser.CountCorrectCharacters("dog", "cod"));
                Assert.AreEqual(2, WordGuesser.CountCorrectCharacters("dog", "bog"));
                Assert.AreEqual(3, WordGuesser.CountCorrectCharacters("dog", "dog"));
        }
        
    }

    public class WordGuesser
    {
        public static int CountCorrectCharacters(string correctWord, string guess)
        {
            if (correctWord.Length != guess.Length)
                throw new InvalidOperationException();
            return correctWord.ToList().Where((a, i) => a == guess.ToList()[i]).Count();
        }
    }
}
