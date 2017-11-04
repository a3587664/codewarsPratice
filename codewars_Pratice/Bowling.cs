using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Bowling
    {
        [TestMethod]
        public void Bowling_AllX_shouldBe300()
        {
            Assert.AreEqual(300, Score("X- X- X- X- X- X- X- X- X- XXX"));
            Assert.AreEqual(70, Score("52 52 52 52 52 52 52 52 52 52-"));
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
        public void Bowling_AllHaveAndLastIsSpare_shouldBe115()
        {
            Assert.AreEqual(115, Score("62 8- 51 X- 72 X- 6/ 32 45 5/8"));
        }

        [TestMethod]
        public void Bowling_AllHaveAndLastIs2X_shouldBe125()
        {
            Assert.AreEqual(125, Score("62 8- 51 X- 72 X- 6/ 32 45 XX8"));
        }

        public int Score(string score)
        {
            var scoreArray = score.ToList();
            var scoreList = score.Split(' ');
            int totalScore = 0, count = 0;
            while (count < scoreArray.Count)
            {
                if (scoreArray[count].ToString() == " ")
                {
                    count++;
                    continue;
                }

                if (count < 27 && scoreArray[count].ToString() == "X")
                {
                    totalScore += 10;
                    totalScore += CountXScore(scoreList, count, scoreArray);
                }
                else if (count < 27 && scoreArray[count].ToString() == "/")
                {
                    totalScore += 10 + ConVertToNum(scoreArray[count + 2]) - ConVertToNum(scoreArray[count - 1]);
                }
                else
                {
                    if (scoreArray[count] == '/')
                    {
                        totalScore += 10 - ConVertToNum(scoreArray[count - 1]);
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

        private int Next2RoundIsX(string[] scoreList, int count, List<char> scoreArray)
        {
            if (count / 3 + 2 < 10)
            {
                if (scoreList[count / 3 + 2].Contains("X"))
                {
                    return 10;
                }

                return ConVertToNum(scoreArray[count + 4]);
            }
            if (scoreList[9].Contains("X"))
            {
                return 10;
            }
            return ConVertToNum(scoreArray[count + 4]);
        }

        private int CountXScore(string[] scoreList, int count, List<char> scoreArray)
        {
            if (count / 3 + 1 < 10)
            {
                if (scoreArray[count + 4] == '/')
                {
                    return 10;
                }

                if (scoreList[count / 3 + 1].Contains("X"))
                {
                    return 10 + Next2RoundIsX(scoreList, count, scoreArray);
                }

                return ConVertToNum(scoreArray[count + 3]) + ConVertToNum(scoreArray[count + 4]);
            }
            if (scoreList[9].Contains("X"))
            {
                return 10;
            }
            return ConVertToNum(scoreArray[count + 3]);
        }


        public int ConVertToNum(char parm)
        {
            if (parm == 'X')
            {
                return 10;
            }
            else if (parm == '-')
            {
                return 0;
            }

            return Int32.Parse(parm.ToString());
        }
    }
}
