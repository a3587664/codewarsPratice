﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    //[TestClass]
    public class Valid_Braces
    {
        [TestMethod]
        public void Kata()
        {
            Assert.AreEqual(true, Brace.validBraces("()"));
        }

        [TestMethod]
        public void Kata2()
        {
            Assert.AreEqual(true, Brace.validBraces("[]"));
        }

        [TestMethod]
        public void Kata3()
        {
            Assert.AreEqual(true, Brace.validBraces("{}"));
        }

        [TestMethod]
        public void Kata4()
        {
            Assert.AreEqual(false, Brace.validBraces("()]"));
        }

        [TestMethod]
        public void Kata5()
        {
            Assert.AreEqual(true, Brace.validBraces("{()}"));
        }

        [TestMethod]
        public void Kata6()
        {
            Assert.AreEqual(true, Brace.validBraces("([{()}])"));
        }

        [TestMethod]
        public void Kata7()
        {
            Assert.AreEqual(false, Brace.validBraces("([{])}}"));
        }

        public class Brace
        {
            public static bool validBraces(string braces)
            {
                int bracesIndex = 0;
                while (bracesIndex < braces.Length - 1)
                {
                    RemovePairBraces(ref braces, ref bracesIndex);
                }
                return braces == String.Empty;
            }

            private static void RemovePairBraces(ref string braces, ref int bracesIndex)
            {
                var nextIndex = bracesIndex + 1;
                if (braces[bracesIndex] == '(' && braces[nextIndex] == ')' ||
                    braces[bracesIndex] == '[' && braces[nextIndex] == ']' ||
                    braces[bracesIndex] == '{' && braces[nextIndex] == '}')
                {
                    braces = braces.Remove(bracesIndex, 2);
                    bracesIndex = 0;
                }
                else
                {
                    bracesIndex++;
                }
            }
        }
    }
}
