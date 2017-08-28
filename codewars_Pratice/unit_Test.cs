using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Unit_Test
    {
        //[TestMethod]
        public void WeightSort_Test()
        {
            Assert.AreEqual("1 2 200", unit_Test.orderWeight("1 200 2"));
           Assert.AreEqual("11 11 2000 10003 22 123 1234000 44444444 9999", unit_Test.orderWeight("2000 10003 1234000 44444444 9999 11 11 22 123"));
        }

    }

    public class unit_Test
    {

        public static string orderWeight(string str)
        {
            var strList = str.Split(' ').ToList();
            List<int> sumArray = new List<int>();
            string result="";
            for (int i = 0; i < strList.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < strList[i].Length; j++)
                {
                    var tmp = strList[i].ToArray();
                    sum += Int32.Parse(tmp[j].ToString());
                }
                sumArray.Add(sum);
            }
            while (sumArray.Count > 0)
            {
                for (int i = 0; i < sumArray.Count; i++)
                {
                    if (sumArray[i] == sumArray.Min())
                    {
                        result += strList[i] + " ";
                        sumArray.RemoveAt(i);
                        strList.RemoveAt(i);
                        break;
                    }
                }
            }

            var strList2 = result.Split(' ').ToList();
            List<int> sumArray2 = new List<int>();
            string result2 = "";
            for (int i = 0; i < strList2.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < strList2[i].Length; j++)
                {
                    var tmp = strList2[i].ToArray();
                    sum += Int32.Parse(tmp[j].ToString());
                }
                sumArray2.Add(sum);
            }
            for (int i = 0; i < strList2.Count-1; i++)
            {
                int count = 0;
                for (int j = i+1; j < strList2.Count; j++)
                    {                      
                        if (sumArray2[i] == sumArray2[j])
                        {
                            count++;
                        }
                        else
                        {                   
                            break;                            
                        }                  
                    }
                while (count > 0)
                {
                    
                    for (int x = i; x < count + i; x++)
                    {
                        bool ck = false;
                        int test = strList2[x].Length > strList2[x + 1].Length
                            ? strList2[x + 1].Length
                            : strList2[x].Length;
                        for (int y = 1; y <= test; y++)
                        {
                            if (Int32.Parse(strList2[x].Substring(0, y)) >
                                Int32.Parse(strList2[x + 1].Substring(0, y)))
                            {
                                var tmp = strList2[x];
                                strList2[x] = strList2[x + 1];
                                strList2[x + 1] = tmp;
                                break;
                            }
                            else if (Int32.Parse(strList2[x].Substring(0, y)) == Int32.Parse(strList2[x+1].Substring(0, y)) && y==test)
                            { ck = true;}
                            else if(Int32.Parse(strList2[x].Substring(0, y)) < Int32.Parse(strList2[x + 1].Substring(0, y)))
                            { break;}
                        }
                        if (ck == true && strList2[x].Length > strList2[x + 1].Length)
                        {
                            var tmp = strList2[x];
                            strList2[x] = strList2[x + 1];
                            strList2[x + 1] = tmp;
                            break;
                        }
                    }
                    count--;
                }
                result2 += strList2[i] + " ";
            }

            return result2.TrimEnd(' ');
        }
    }
}
