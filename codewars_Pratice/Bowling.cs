using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    //[TestClass]
    public class Bowling
    {
        [TestMethod]
        public void Bowling_AllX_shouldBe300()
        {
            Assert.AreEqual(300, Score("X- X- X- X- X- X- X- X- X- XXX"));
        }

        [TestMethod]
        public void Bowling_All7_shouldBe70()
        {
            Assert.AreEqual(70, Score("52 52 52 52 52 52 52 52 52 52-"));
        }

        [TestMethod]
        public void Bowling_HaveX_HaveNormalScore_shouldBe100()
        {
            Assert.AreEqual(100, Score("X- 52 52 -7 52 X- 52 52 7- X52"));
        }

        [TestMethod]
        public void Bowling_SpareAndFinalX_shouldBe178()
        {
            Assert.AreEqual(178, Score("5/ 8/ 6/ 7/ 7/ 9/ 5/ 8/ 9/ 9/X"));
        }

        [TestMethod]
        public void Bowling_AllMiss_shouldBe73()
        {
            Assert.AreEqual(73, Score("5- 8- 6- 7- 7- 9- 5- 8- 9- 9--"));
        }

        [TestMethod]
        public void Bowling_STRIKE_SPARE_GAME_shouldBe200()
        {
            Assert.AreEqual(200, Score("X- 9/ X- 7/ X- 2/ X- 5/ X- 1/X"));
        }

        [TestMethod]
        public void Bowling_HaveXAndLastIsSpare_shouldBe115()
        {
            Assert.AreEqual(115, Score("62 8- 51 X- 72 X- 6/ 32 45 5/8"));
        }

        [TestMethod]
        public void Bowling_2XClose_shouldBe132()
        {
            Assert.AreEqual(132, Score("62 8- 51 X- X- 72 6/ 32 45 XX8"));
        }

        [TestMethod]
        public void Bowling_2SpareClose_shouldBe118()
        {
            Assert.AreEqual(118, Score("62 8- 51 2/ 3/ 72 X- 32 45 XX8"));
        }

        public int Score(string score)
        {
            var scoreArray = score.ToList();
            int totalScore = 0, count = 0;

            while (count < scoreArray.Count)
            {
                int lastBall = count - 1, 
                    nextRoundFirstBall = count + 2, 
                    round = count / 3 + 1;

                if (scoreArray[count].ToString() == " " || scoreArray[count].ToString() == "-")
                {
                    count++;
                    continue;
                }

                if (round < 10 && scoreArray[count].ToString() == "X")
                {
                    totalScore += 10;
                    totalScore += CountXScore(count, scoreArray);
                }
                else if (round < 10 && scoreArray[count].ToString() == "/")
                {
                    totalScore += 10 + ConVertToNum(scoreArray[nextRoundFirstBall]) - ConVertToNum(scoreArray[lastBall]);
                }
                else
                {
                    if (scoreArray[count] == '/')
                    {
                        totalScore += 10 - ConVertToNum(scoreArray[lastBall]);
                    }
                    else
                    {
                        totalScore += ConVertToNum(scoreArray[count]);
                    }
                }
                count++;
            }
            return totalScore;
        }

        private int CountXScore(int count, List<char> scoreArray)
        {
            int nextRoundFirstBall = count + 3;
            int nextRoundSecondBall = count + 4;
            int nextTwoRoundFirstBall = count + 6;
            int round = count / 3 + 1;

            if (scoreArray[nextRoundSecondBall] == '/')
            {
                return 10;
            }

            if (scoreArray[nextRoundFirstBall] == 'X')
            {
                if (round == 9)
                {
                    return 10 + ConVertToNum(scoreArray[nextRoundSecondBall]);
                }

                return 10 + ConVertToNum(scoreArray[nextTwoRoundFirstBall]);
            }

            return ConVertToNum(scoreArray[nextRoundFirstBall]) + ConVertToNum(scoreArray[nextRoundSecondBall]);

        }


        public int ConVertToNum(char parm)
        {
            if (parm == 'X')
            {
                return 10;
            }
            if (parm == '-')
            {
                return 0;
            }
            return Int32.Parse(parm.ToString());
        }
    }
}
