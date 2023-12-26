using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.ButakovIK.Sprint7.Project.V11.Lib;

namespace Tyuiu.ButakovIK.Sprint7.Project.V11.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            string testFilePath = @"C:\DataSprint6\InPutFileTask7V16.csv";

            int lineCount = 0;

            
            using (var reader = new StreamReader(testFilePath))
            {
               
                reader.ReadLine();

                
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }

            
            Assert.AreEqual(9, lineCount);
        }
    }
}
