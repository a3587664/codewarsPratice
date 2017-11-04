using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace codewars_Pratice
{
    //[TestClass]
    public class Connect_Four
    {
        [TestMethod]
        public void FirstTest()
        {
            List<string> myList = new List<string>()
            {
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "G_Red",
                "B_Yellow"
            };
            Assert.AreEqual("Yellow", ConnectFour.WhoIsWinner(myList), "it should return Yellow");            
        }

        public class ConnectFour
        {
            public static string WhoIsWinner(List<string> piecesPositionList)
            {
                var AList = new List<string>();
                var BList = new List<string>();
                var CList = new List<string>();
                var DList = new List<string>();
                var EList = new List<string>();
                var FList = new List<string>();
                var GList = new List<string>();
                int i = 0;
                while (piecesPositionList.Count>0)
                {
                    string Q = piecesPositionList[i];
                    if (Q.Substring(0, 1) == "A")
                        AList.Add(Q.Substring(2, Q.Length));
                    if (Q.Substring(0, 1) == "B")
                        BList.Add(Q.Substring(2, Q.Length));
                    if (Q.Substring(0, 1) == "C")
                        CList.Add(Q.Substring(2, Q.Length));
                    if (Q.Substring(0, 1) == "D")
                        DList.Add(Q.Substring(2, Q.Length));
                    if (Q.Substring(0, 1) == "E")
                        EList.Add(Q.Substring(2, Q.Length));
                    if (Q.Substring(0, 1) == "F")
                        FList.Add(Q.Substring(2, Q.Length));
                    if (Q.Substring(0, 1) == "G")
                        GList.Add(Q.Substring(2, Q.Length));
                    piecesPositionList.Remove(Q);
                    i++;
                }

                return "";
            }
        }
    }
}
