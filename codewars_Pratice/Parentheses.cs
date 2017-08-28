using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        public void Parentheses_Test()
        {
            Assert.AreEqual(true, Parentheses.ValidParentheses("(((()))()()())"));
            //Assert.AreEqual(true, Parentheses.ValidParentheses("(())((()())())"));
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
}
