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
                    totalScore += NextRoundIsX(scoreList, count, scoreArray);
                    totalScore += Next2RoundIsX(scoreList, count, scoreArray);
                }
                else
                {
                    totalScore += ConVertToNum(scoreArray[count]);
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

        private int NextRoundIsX(string[] scoreList, int count, List<char> scoreArray)
        {
            if (count / 3 + 1 < 10)
            {
                if (scoreList[count / 3 + 1].Contains("X"))
                {
                    return 10;
                }
                return ConVertToNum(scoreArray[count + 3]);
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
