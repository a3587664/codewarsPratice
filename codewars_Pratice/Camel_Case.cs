using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Camel_Case
    {
        [TestMethod]
        public void Camel_Case_Test()
        {
            Assert.AreEqual("theStealthWarrior", Camel_Case_Kata.ToCamelCase("the_stealth_warrior"), "Kata.ToCamelCase('the_stealth_warrior') did not return correct value");
            Assert.AreEqual("TheStealthWarrior", Camel_Case_Kata.ToCamelCase("The-Stealth-Warrior"), "Kata.ToCamelCase('The-Stealth-Warrior') did not return correct value");
        }
    }

    public class Camel_Case_Kata
    {
        public static string ToCamelCase(string str)
        {
            List<string> strList = str.Select(c => c.ToString()).ToList();
            for (int i = 1; i < strList.Count; i++)
            {
                if (strList[i] == "_" || strList[i] == "-")
                {
                    strList.Remove(strList[i]);
                    strList[i]= strList[i].ToUpper();
                }
            }
            return string.Join("",strList);
        }
    }
}
