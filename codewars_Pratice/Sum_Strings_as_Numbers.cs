using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace codewars_Pratice
{
    [TestClass]
    public class Sum_Strings_as_Numbers
    {
        //[TestMethod]
        public void Given123And456Returns579()
        {
            Assert.AreEqual("8842", Kata2.sumStrings("50095301248058391139327916261", "81055900096023504197206408605"));
        }
    }
    public  class Kata2
    {
        public static string sumStrings(string a, string b)
        {
            return (int.Parse(a) + int.Parse(b)).ToString();
        }
    }
    //土法煉鋼 一個一個加
    public class Kata
    {
        public static string sumStrings(string a, string b)
        {
            Console.WriteLine("a="+a+"b="+b);
            var aList = a.ToList();
            aList.Reverse();
            var bList = b.ToList();
            bList.Reverse();      
            int tmp = 0,count=0;
            string ans="";
            
            while (true)
            {
                if(aList.Count==0&&bList.Count==0)
                    break;
                
                if (aList.Count == 0)
                {
                    if (tmp > 0)
                    {
                        int bbb = Int32.Parse(bList[0].ToString());

                        if ( bbb + 1 > 9)
                        {
                            ans += ((bbb + 1) % 10).ToString();
                            bList.Remove(bList[0]);
                            while (tmp == 0)
                            {
                                bbb = Int32.Parse(bList[0].ToString());
                                if (bbb + 1 > 9)
                                {
                                    ans += (( bbb + 1) % 10).ToString();
                                    bList.Remove(bList[0]);
                                }
                                else
                                {
                                    tmp--;
                                    ans += (bbb + 1).ToString();
                                    bList.Remove(bList[0]);
                                }
                            }
                        }
                        else
                        {
                            tmp--;
                            ans += (bbb + 1).ToString();
                            bList.Remove(bList[0]);
                        }
                    }
                    for (int i = 0; i < bList.Count; i++)
                    {
                        int bbb = Int32.Parse(bList[i].ToString());
                        ans += bbb.ToString();
                    }
                    break;
                }

                if (bList.Count == 0)
                {
                    if (tmp > 0)
                    {
                        int aaa = Int32.Parse(aList[0].ToString());

                        if (aaa + 1 > 9)
                        {
                            ans += ((aaa + 1)%10).ToString();
                            aList.Remove(aList[0]);
                            while (tmp == 0)
                            {
                                aaa = Int32.Parse(aList[0].ToString());
                                if (aaa + 1 > 9)
                                {
                                    ans += ((aaa + 1) % 10).ToString();
                                    aList.Remove(aList[0]);
                                }
                                else
                                {
                                    tmp--;
                                    ans += (aaa + 1).ToString();
                                    aList.Remove(aList[0]);
                                }
                            }
                        }
                        else
                        {
                            tmp--;
                            ans += (aaa + 1).ToString();
                            aList.Remove(aList[0]);
                        }
                    }
                    for (int i = 0; i < aList.Count; i++)
                    {
                        int aaa = Int32.Parse(aList[i].ToString());
                        ans += aaa.ToString();
                    }
                    break;
                }

                int aa = Int32.Parse(aList[0].ToString());
                int bb = Int32.Parse(bList[0].ToString());
                
                if (tmp > 0)
                {
                    if (aa + bb +1 > 9)
                    {
                        ans += ((aa + bb+1) % 10).ToString();
                    }
                    else
                    {
                        tmp--;
                        ans+= (aa + bb + 1).ToString();
                    }
                }
                else if (aa+bb>9)
                {
                    tmp++;
                    ans += ((aa + bb) % 10).ToString();
                }
                else
                {
                    ans += (aa + bb).ToString();
                }
                aList.Remove(aList[0]);
                bList.Remove(bList[0]);
            }
            ans +=tmp != 0 ?  "1" : "";
           var c = ans.Reverse().ToArray();            
            string r = new string(c);
            if (r.Substring(0, 1) == "0")
                r = r.Substring(1, r.Length - 1);
            return r;
        }
    }
}
