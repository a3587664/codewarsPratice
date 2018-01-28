using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Not_So_Random
    {

        [TestMethod]
        public void If_One_Black_Should_Be_Black()
        {
            Assert.AreEqual("black", Hat.NotSoRandom(1, 0));
        }

        [TestMethod]
        public void If_One_White_Should_Be_White()
        {
            Assert.AreEqual("white", Hat.NotSoRandom(0, 1));
        }

        [TestMethod]
        public void If_One_Black_And_One_White_Should_Be_Black()
        {
            Assert.AreEqual("black", Hat.NotSoRandom(1, 1));
        }

        [TestMethod]
        public void If_Two_Black_And_One_White_Should_Be_White()
        {
            Assert.AreEqual("white", Hat.NotSoRandom(2, 1));
        }

        [TestMethod]
        public void If_One_Black_And_Two_White_Should_Be_Black()
        {
            Assert.AreEqual("black", Hat.NotSoRandom(1, 2));
        }

        [TestMethod]
        public void If_One_Black_And_Two_White_Should_Be_()
        {
            Assert.AreEqual("black", Hat.NotSoRandom(1.2, 2.3));
        }
    }

    public class Hat
    {
        public static string NotSoRandom(double b, double w)
        {
            var b1 = (int)b;
            var w1 = (int)w;
            Console.WriteLine("b1="+b1+",w1="+w1);
            while (b1>1||w1>1)
            {
                w1 += b1 / 2 ;
                b1 = b1 % 2;
                w1 += w1 / 2;
                w1 = w1 % 2;
                if (b1==1&&w1==1)
                {
                    w1--;
                }
            }
            return b1 == 0 ? "white" : "black";
        }
    }
}
