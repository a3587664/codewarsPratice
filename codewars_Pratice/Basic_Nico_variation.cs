using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Basic_Nico_variation
    {
        [TestMethod]
        public void Basic_Nico_variation_Test()
        {
            Assert.AreEqual("cseerntiofarmit on  ", Kata.Nico("crazy", "secretinformation"));
            Assert.AreEqual("abcd  ", Kata.Nico("abc", "abcd"));
            Assert.AreEqual("2143658709", Kata.Nico("ba", "1234567890"));
            Assert.AreEqual("message", Kata.Nico("a", "message"));
            Assert.AreEqual("eky", Kata.Nico("key", "key"));
        }

        public class Kata
        {
            public static string Nico(string key, string message)
            {
                int firstNum = message.Length % key.Length == 0
                    ? message.Length / key.Length
                    : message.Length / key.Length + 1;

                int count = 0;

                string[,] arrayMessage = new string[firstNum, key.Length];

                for (int i = 0; i < firstNum; i++)
                {
                    for (int j = 0; j < key.Length; j++)
                    {
                        if (i * key.Length + j < message.Length)
                        {
                            arrayMessage[i, j] = message[count].ToString();
                        }
                        else
                        {
                            arrayMessage[i, j] = " ";
                        }
                        count++;
                    }
                }
                var keyArray = key.ToArray();
                Array.Sort(keyArray, StringComparer.InvariantCulture);
                int keyCount = 0,ansArrayCount=0;
                count = 0;
                string[,] anserArray = new string[firstNum, key.Length];
                while (count < key.Length)
                {
                    if (keyArray[count] == key[keyCount])
                    {
                        count++;
                        for (int i = 0; i < firstNum; i++)
                        {
                            anserArray[i, ansArrayCount] = arrayMessage[i, keyCount];
                        }
                        ansArrayCount++;
                        keyCount = 0;
                    }
                    else
                    {
                        keyCount++;
                    }
                }
                List<string> ansList = anserArray.OfType<string>().ToList();
                return string.Join("", ansList);
            }
        }
    }
}
