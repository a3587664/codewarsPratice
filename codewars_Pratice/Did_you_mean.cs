using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Did_you_mean
    {
        [TestMethod]
        public void Did_you_mean_Test()
        {
            Kataf kata = new Kataf(new List<string> { "zqdrhpviqslik", "karpscdigdvucfr" });
            Assert.AreEqual("karpscdigdvucfr", kata.FindMostSimilar("rkacypviuburk"));
        }
    }

    public class Kataf
    {
        private IEnumerable<string> words;

        public Kataf(IEnumerable<string> words)
        {
            this.words = words;
        }

        public string FindMostSimilar(string term)
        {
            var wordsList = words.ToList();

            List<int> NumList = new List<int>();
            for (int i = 0; i < wordsList.Count; i++)
            {
                int SameTmp = 0,DefTmp=0;
                var wordTmp = wordsList[i].ToList();
                var termList = term.ToList();
                for (int j = 0; j < termList.Count; j++)
                {
                    for (int k = 0; k < wordTmp.Count; k++)
                    {
                        if (termList[j].ToString() == wordTmp[k].ToString())
                        {
                            SameTmp++;
                            wordTmp.Remove(wordTmp[k]);
                            break;                            
                        }
                    }
                    
                }
                if (wordsList[i].Length > term.Length)
                {
                    NumList.Add(wordsList[i].Length - SameTmp);
                }
                else
                {
                    NumList.Add(term.Length - SameTmp);
                }
            }
            int min = NumList.Max(),index=0;
            for (int i = 0; i < NumList.Count; i++)
            {
                if (min > NumList[i])
                {
                        min = NumList[i];
                        index = i;                                                      
                }
                else if (min == NumList[i] && wordsList[index].Length > wordsList[i].Length)
                {
                        min = NumList[i];
                        index = i;
                }
            }
            return wordsList[index];
        }
    }
}