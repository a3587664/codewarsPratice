using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        public void WeightSort_Test()
        {
            Assert.AreEqual("1 2 200", WeightSort.orderWeight("1 200 2"));
           Assert.AreEqual("11 11 2000 10003 22 123 1234000 44444444 9999", WeightSort.orderWeight("2000 10003 1234000 44444444 9999 11 11 22 123"));
        }

        //[TestMethod]
        public  void Stop_gninnipS_My_sdroW_Test()
        {
            var kata = new StopgninnipSMysdroW();
            Assert.AreEqual("emocleW", kata.SpinWords("Welcome"));
            Assert.AreEqual("Hey wollef sroirraw", kata.SpinWords("Hey fellow warriors"));
            Assert.AreEqual("This is a test", kata.SpinWords("This is a test"));
            Assert.AreEqual("This is rehtona test", kata.SpinWords("This is another test"));
            Assert.AreEqual("You are tsomla to the last test", kata.SpinWords("You are almost to the last test"));
            Assert.AreEqual("Just gniddik ereht is llits one more", kata.SpinWords("Just kidding there is still one more"));
        }

        //[TestMethod]
        public void GoodVsEvil_Test()
        {
            var Kata = new GoodVsEvilKata();
            Assert.AreEqual("Battle Result: Good triumphs over Evil", Kata.GoodVsEvil("0 0 0 0 0 10", "0 1 1 1 1 0 0"));
            Assert.AreEqual("Battle Result: No victor on this battle field", Kata.GoodVsEvil("1 0 0 0 0 0", "1 0 0 0 0 0 0"));
            Assert.AreEqual("Battle Result: Evil eradicates all trace of Good", Kata.GoodVsEvil("1 1 1 1 1 1", "1 1 1 1 1 1 1"));
        }

        //[TestMethod] ************************未完成
        public void SimpleCase()
        {
            var Kata = new CountCombinationsKata();
            //Assert.AreEqual(3, Kata.CountCombinations(4, new[] { 1, 2 }));
            //Assert.AreEqual(4, Kata.CountCombinations(10, new[] { 5, 2, 3 }));
            //Assert.AreEqual(0, Kata.CountCombinations(11, new[] { 5, 7 }));
            Assert.AreEqual(14, Kata.CountCombinations(15, new[] { 1,2,3,6,11 }));
        }

        //[TestMethod]
        public void Parentheses_Test()
        {
            Assert.AreEqual(true, Parentheses.ValidParentheses("(((()))()()())"));
            //Assert.AreEqual(true, Parentheses.ValidParentheses("(())((()())())"));
        }

        //[TestMethod]
        public void ShouldBeWorthless()
        {
            var Kata = new Greed_is_Good();
            Assert.AreEqual(0, Kata.Score(new int[] { 2, 3, 4, 6, 2 }), "Should be 0 :-(");
            Assert.AreEqual(400, Kata.Score(new int[] { 4, 4, 4, 3, 3 }), "Should be 400");
            Assert.AreEqual(450, Kata.Score(new int[] { 2, 4, 4, 5, 4 }), "Should be 450");
            Assert.AreEqual(1100,Kata.Score(new int[]{1,1,1,1,2}));
        }

        //[TestMethod]
        public void Test1()
        {
            var kata = new PrimeDecomp();
            int lst = 7775460;
            Assert.AreEqual("(2**2)(3**3)(5)(7)(11**2)(17)", kata.factors(lst));
        }

        //[TestMethod]
        public void StringMerger_test()
        {
            //Assert.IsTrue(StringMerger.isMerge("cca", "ca", "cc"), "codewars can be created from code and wars");
           // Assert.IsTrue(StringMerger.isMerge("codewars", "cdwr", "oeas"), "codewars can be created from cdwr and oeas");
            Assert.IsFalse(StringMerger.isMerge("codewars", "code", "wasr"), "Codewars are not codwars");
        }

        [TestMethod]
        public void SmallPyramidTest()
        {
            var smallPyramid = new[]
            {
                new[] {3},
                new[] {7, 4},
                new[] {2, 4, 6},
                new[] {8, 5, 9, 3}
            };

            Assert.AreEqual(PyramidSlideDown.LongestSlideDown(smallPyramid), 23);
        }

        [TestMethod]
        public void MediumPyramidTest()
        {
            var mediumPyramid = new[]
            {
                new [] {75},
                new [] {95, 64},
                new [] {17, 47, 82},
                new [] {18, 35, 87, 10},
                new [] {20,  4, 82, 47, 65},
                new [] {19,  1, 23, 75,  3, 34},
                new [] {88,  2, 77, 73,  7, 63, 67},
                new [] {99, 65,  4, 28,  6, 16, 70, 92},
                new [] {41, 41, 26, 56, 83, 40, 80, 70, 33},
                new [] {41, 48, 72, 33, 47, 32, 37, 16, 94, 29},
                new [] {53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14},
                new [] {70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57},
                new [] {91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48},
                new [] {63, 66,  4, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31},
                new [] { 4, 62, 98, 27, 23,  9, 70, 98, 73, 93, 38, 53, 60,  4, 23}
            };

            Assert.AreEqual(PyramidSlideDown.LongestSlideDown(mediumPyramid), 1074);
        }
    }

    public class PyramidSlideDown
    {
        public static int LongestSlideDown(int[][] pyramid)
        {
            int sum = pyramid[0][0],tmp=0;
            for (int i = 1; i < pyramid.Length; i++)
            {                
                int numTmp = 0,num2Tmp=0;
                if (i + 1 >= pyramid.Length)
                {
                    if (pyramid[i][tmp] > pyramid[i][tmp + 1])
                    {
                        sum += pyramid[i][tmp];
                    }
                    else
                    {
                        sum += pyramid[i][tmp + 1];
                        tmp++;
                    }
                }
                else
                {
                    numTmp = pyramid[i + 1][tmp] > pyramid[i + 1][tmp + 1]
                        ? pyramid[i + 1][tmp] : pyramid[i + 1][tmp + 1];
                    num2Tmp = pyramid[i + 1][tmp + 1] > pyramid[i + 1][tmp + 2]
                        ? pyramid[i + 1][tmp + 1]
                        : pyramid[i + 1][tmp + 2];
                    sum += pyramid[i][tmp] + numTmp > pyramid[i][tmp+1] + num2Tmp ? pyramid[i][tmp] : pyramid[i][tmp+1];
                    tmp += pyramid[i][tmp] + numTmp > pyramid[i][tmp+1] + num2Tmp ? 0 : 1;
                }
                
            }
            return sum;
        }
    }


    public class StringMerger
    {
        public static bool isMerge(string s, string part1, string part2)
        {
            var sList = s.ToList();
            var tmp = (part1 + part2).ToList();
            int count = 0;
            for (int i = 0; i < sList.Count; i++)
            {
                for (int j = 0; j < tmp.Count; j++)
                {
                    if (sList[i] == tmp[j])
                    {
                        count++;
                        tmp.Remove(tmp[j]);
                    }
                }
            }
            return sList.Count!=(part1+part2).Length ? false : count == s.Length;
        }
    }

    public class PrimeDecomp
    {
        public String factors(int lst)
        {
            List<int> AllNum = new List<int>();
            List<int> Pow = new List<int>();
            string Ans = "";
            for (int i = 2; i <= lst; i++)
            {
                if (lst % i == 0)
                {
                    int count = 0;
                    while (lst%i==0)
                    {
                        lst /= i;
                        count++;
                    }
                    AllNum.Add(i);
                    Pow.Add(count);
                    Ans += count == 1 ? "(" + i + ")" : "(" + i + "**" + count + ")";
                }                                 
            }
            return Ans;
        }
    }

    public class Greed_is_Good
    {
        public int Score(int[] dice)
        {
            int one = (from a in dice where a == 1 select a).Count(),
                two = (from a in dice where a == 2 select a).Count(), 
                three = (from a in dice where a ==3 select a).Count(), 
                four = (from a in dice where a == 4 select a).Count(), 
                five = (from a in dice where a == 5 select a).Count(), 
                six = (from a in dice where a == 6 select a).Count(), 
                sum = 0;
            sum += (one - (3 * (one / 3))) * 100 + ((one / 3) * 1000);
            sum += two/3*200;
            sum += three/3*300;
            sum += four/3*400;
            sum += (five - (3 * (five / 3))) * 50 + ((five / 3) * 500);
            sum += six / 3 * 600;
            return sum;
        }
    }

    public class Parentheses
    {
        public static bool ValidParentheses(string input)
        {
            int stack = 0;
            foreach (char c in input)
            {
                if (c == ')')
                {
                    stack--;
                }
                else if (c == '(')
                {
                    stack++;
                }
                if (stack < 0)
                    return false;
            }
            return stack == 0;

            //if (input.Length > 100 || input.Length < 0)
            //    return false;
            //int count = 0;

            //while (input.Length > 1)
            //{
            //    var right = (from a in input.ToCharArray() where a == '(' select a).Count();
            //    var left = (from a in input.ToCharArray() where a == ')' select a).Count();
            //    if (right==0||left==0)
            //        break;
            //    bool ck = false;
            //        for (int i = input.IndexOf("("); i < input.Length; i++)
            //        {
            //            if (input.Substring(i, 1) == ")")
            //            {
            //                input = input.Remove(i, 1);
            //                input = input.Remove(input.IndexOf("("),1);                           
            //                break;
            //            }
            //            else if (i == input.Length - 1)
            //            {
            //                ck = true;
            //            }
            //        }
            //    if (ck==true)
            //    {
            //        break;
            //    }
            //}
            //var right1 = (from a in input.ToCharArray() where a == '(' select a).Count();
            //var left1 = (from a in input.ToCharArray() where a == ')' select a).Count();
            //return right1 == 0 && left1==0 ? true : false;
        }
    }

    public class CountCombinationsKata
    {
        public int CountCombinations(int money, int[] coins)
        {
            var List = coins.ToList();
            List.Sort();
            int sum = 0;

            for (int k = 1; k < List.Count+1; k++)
            {
                for (int i = 0; i < List.Count/k; i++)
                {
                    int tmpSum = 0;
                    for (int j = i; j < k; j++)
                    {
                        tmpSum += List[j];
                    }
                    int tmpMoney = money;
                    while (tmpMoney >= 0)
                    {
                        if (k == 1)
                        {
                            tmpMoney -= List[i];
                        }
                        else
                        {
                            if(tmpMoney-tmpSum>=0)
                            tmpMoney -= tmpSum;
                        }
                        if (tmpMoney == 0)
                        {
                            sum++;
                            break;
                        }
                        if (tmpMoney - tmpSum < 0)
                        {
                            for (int a = 0; a <= i; a++)
                            {
                                while (tmpMoney >= 0)
                                {
                                    tmpMoney -= List[a];
                                    if (tmpMoney == 0)
                                    {
                                        sum++;
                                        break;
                                    }
                                    if(tmpMoney<0)
                                        break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return sum;           
        }
    }

    public class GoodVsEvilKata
    {
        public string GoodVsEvil(string good, string evil)
        {
            int[] goodPoint = { 1, 2, 3, 3, 4, 10 }, evilPoint = { 1, 2, 2, 2, 3, 5, 10 };
            int sumGood = 0,sumEvil=0;
            //var GoodArray = good.Split(' ');
            //var EvilArray =evil.Split(' ');
            //for (int i = 0; i < GoodArray.Length; i++)
            //    sumGood+=Int32.Parse(GoodArray[i]) *goodPoint[i];
            //for (int i = 0; i < EvilArray.Length; i++)
            //    sumEvil += Int32.Parse(EvilArray[i]) * evilPoint[i];
            sumGood = good.Split(' ').Select(Int32.Parse).Zip(goodPoint, (first, second) => first * second).Sum();
            sumEvil = evil.Split(' ').Select(Int32.Parse).Zip(evilPoint, (first, second) => first * second).Sum();
            return sumGood == sumEvil
                ? "Battle Result: No victor on this battle field"
                : sumGood > sumEvil
                    ? "Battle Result: Good triumphs over Evil"
                    : "Battle Result: Evil eradicates all trace of Good";
        }
    }
    

    public class StopgninnipSMysdroW
    {
        public string SpinWords(string sentence)
        {
            //var array = sentence.Split(' ');
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (array[i].Length > 4)
            //    {
            //        array[i] = new string(array[i].Reverse().ToArray()); 
            //    }
            //}
            //return string.Join(" ", array);
            return String.Join(" ", sentence.Split(' ').Select(str => str.Length > 4 ? new string(str.Reverse().ToArray()) : str));
        }
    }

    public class WeightSort
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
