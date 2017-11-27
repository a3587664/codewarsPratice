using System;
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

                var encryptMessage = SetEncryptMessage(message, key);

                var output = Encrypt(message, key, encryptMessage);

                return string.Join("", output.Cast<string>());
            }

            private static string[,] Encrypt(string message, string key, string[,] EncryptMessage)
            {
                int width = key.Length;
                int height = (int)Math.Ceiling((decimal)message.Length / width);
                var output = new string[height, width];
                var sortKey = key.OrderBy(x => x).ToArray();

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        output[i, j] = EncryptMessage[i, Array.IndexOf(key.ToArray(), sortKey[j])];
                    }
                }

                return output;
            }

            private static string[,] SetEncryptMessage(string message, string key)
            {
                int width = key.Length;
                int height = (int)Math.Ceiling((decimal)message.Length / width);

                int count = 0;

                var arrayMessage = new string[height, width];

                message = message.PadRight(height * width, ' ');

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        arrayMessage[i, j] = message[count].ToString();
                        count++;
                    }
                }

                return arrayMessage;
            }
        }
    }
}
