using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace codewars_Pratice
{
    //[TestFixture]
    public class BingoCardTests
    {
        [Test]
        public void CardHas24Numbers()
        {
            Assert.AreEqual(24, BingoCard.GetCard().Length);
        }

        [Test]
        public void EachNumberOnCardIsUnique()
        {
            var card = BingoCard.GetCard();
            Assert.AreEqual(card.Length, card.ToList().Distinct().Count());
        }

        [TestCase("B", 5)]
        [TestCase("I", 5)]
        [TestCase("N", 4)]
        [TestCase("G", 5)]
        [TestCase("O", 5)]
        public void ColumnContainsCorrectNumberOfItems(string column, int count)
        {
            var numbers = BingoCard.GetCard().Where(x => x.StartsWith(column)).ToList();
            Assert.AreEqual(count, numbers.Count);
        }

        [Test]
        public void NumbersAreOrderedByColumn()
        {
            var columns = string.Join("", BingoCard.GetCard().ToList()
                .Select(x => x.Substring(0, 1)).ToArray());

            Assert.IsTrue(Regex.IsMatch(columns, "^[B]*[I]*[N]*[G]*[O]*$"));
        }

        [TestCase("B", 1, 15)]
        [TestCase("I", 16, 30)]
        [TestCase("N", 31, 45)]
        [TestCase("G", 46, 60)]
        [TestCase("O", 61, 75)]
        public void NumbersWithinColumnAreAllInTheCorrectRange(string column, int start, int end)
        {
            var numbers = BingoCard.GetCard().Where(x => x.StartsWith(column)).ToList();

            foreach (var number in numbers)
            {
                var n = Convert.ToInt32(number.Substring(1));
                Assert.GreaterOrEqual(n, start, "Column {0} should be in the range between {1} and {2}, found: {3}", column, start, end, number);
                Assert.LessOrEqual(n, end, "Column {0} should be in the range between {1} and {2}, found: {3}", column, start, end, number);
            }
        }

        [Test]
        public void NumbersWithinColumnAreInRandomOrder()
        {
            var card = BingoCard.GetCard().Select(x => Convert.ToInt32(x.Substring(1))).ToArray();

            var isRandom = false;
            for (var i = 1; i < card.Length; i++)
            {
                if (card[i - 1] > card[i])
                {
                    isRandom = true;
                    break;
                }
            }

            Assert.IsTrue(isRandom, "Unlikely result, is the list ordered?");
        }


        public class BingoCard
        {

            public static string[] GetCard()
            {
                var card = new List<string>();
                card.AddRange(SetCard(bingo:"B", count: 5, startNum: 1, endNum: 16));
                card.AddRange(SetCard(bingo:"I", count: 5, startNum: 16, endNum: 31));
                card.AddRange(SetCard(bingo:"N", count: 4, startNum: 31, endNum: 46));
                card.AddRange(SetCard(bingo:"G", count: 5, startNum: 46, endNum: 61));
                card.AddRange(SetCard(bingo:"O", count: 5, startNum: 61, endNum: 76));
                return card.ToArray();
            }

            private static List<string> SetCard(string bingo, int count, int startNum, int endNum)
            {
                Random gerenateRandomNum = new Random();
                var card = new List<string>();
                while (card.Count < count)
                {
                    int rngNum = gerenateRandomNum.Next(startNum, endNum);
                    var IsUniqueNumInCard = !card.Where(x => x == bingo + rngNum.ToString()).Any();

                    if (IsUniqueNumInCard)
                    {
                        card.Add(bingo + rngNum);
                    }
                }
                return card;
            }

        }
    }
}
