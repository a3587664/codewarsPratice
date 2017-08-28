using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Stop_gninnipS_My_sdrow
    {
       // [TestMethod]
        public void Stop_gninnipS_My_sdroW_Test()
        {
            var kata = new StopgninnipSMysdroW();
            Assert.AreEqual("emocleW", kata.SpinWords("Welcome"));
            Assert.AreEqual("Hey wollef sroirraw", kata.SpinWords("Hey fellow warriors"));
            Assert.AreEqual("This is a test", kata.SpinWords("This is a test"));
            Assert.AreEqual("This is rehtona test", kata.SpinWords("This is another test"));
            Assert.AreEqual("You are tsomla to the last test", kata.SpinWords("You are almost to the last test"));
            Assert.AreEqual("Just gniddik ereht is llits one more", kata.SpinWords("Just kidding there is still one more"));
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
}
