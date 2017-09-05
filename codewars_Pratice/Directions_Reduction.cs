using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_Pratice
{
    [TestClass]
    public class Directions_Reduction
    {
        //[TestMethod]
        public void Directions_Reduction_Test1() 
        {
            string[] a =  { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
            string[] b =  { "WEST" };
            Assert.AreEqual(b, DirReduction.dirReduc(a));
        }

        [TestMethod]
        public void Directions_Reduction_Test2()
        {
            string[] a = new string[] { "NORTH", "WEST", "SOUTH", "EAST" }; 
            string[] b = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };

            CollectionAssert.AreEqual(b, DirReduction.dirReduc(a));
        }

        public class DirReduction
        {
            
            public static string[] dirReduc(String[] arr)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    Console.WriteLine(arr[j]);
                }
                int i = 0;
                var arrList = arr.ToList();
                while (i< arrList.Count-1 && arrList.Count>1)
                {
                    switch (arrList[i].ToUpper())
                    {
                        case "EAST":
                            if (i != 0 && arrList[i - 1 ]== "WEST")
                            {
                                i--;
                                arrList.Remove(arrList[i]);
                                arrList.Remove(arrList[i]);
                            }
                            else if (arrList[i + 1] == "WEST")
                            {
                                arrList.Remove(arrList[i]);
                                arrList.Remove(arrList[i]);
                            }
                            else
                            {
                                i++;
                            }
                            break;
                        case "WEST":
                            if (i != 0 && arrList[i - 1] == "EAST")
                            {
                                i--;
                                arrList.Remove(arrList[i]);
                                arrList.Remove(arrList[i]);
                            }
                            else if (arrList[i + 1] == "EAST")
                            {
                                arrList.Remove(arrList[i]);
                                arrList.Remove(arrList[i]);
                            }
                            else
                            {
                                i++;
                            }
                            break;
                        case "SOUTH":
                            if (i != 0 && arrList[i - 1] == "NORTH")
                            {
                                i--;
                                arrList.Remove(arrList[i]);
                                arrList.Remove(arrList[i]);
                            }
                            else if (arrList[i + 1] == "NORTH")
                            {
                                arrList.Remove(arrList[i]);
                                arrList.Remove(arrList[i]);
                            }
                            else
                            {
                                i++;
                            }
                            break;
                        case "NORTH":
                            if (i != 0 && arrList[i - 1] == "SOUTH")
                            {
                                i--;
                                arrList.Remove(arrList[i]);
                                arrList.Remove(arrList[i]);
                            }
                            else if (arrList[i + 1] == "SOUTH")
                            {
                                arrList.Remove(arrList[i]);
                                arrList.Remove(arrList[i]);
                            }
                            else
                            {
                                i++;
                            }
                            break;
                    }
                }
                Console.WriteLine("/n");
                for (int j = 0; j < arrList.Count; j++)
                {
                    Console.WriteLine(arrList[j]);
                }

                return arrList.ToArray();
            }
        }
    }
}
