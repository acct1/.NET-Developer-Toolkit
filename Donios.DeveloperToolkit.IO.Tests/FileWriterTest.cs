using Donios.DeveloperToolkit.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Donios.DeveloperToolkit.IO.Tests
{
    
    
    /// <summary>
    ///This is a test class for FileWriterTest and is intended
    ///to contain all FileWriterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FileWriterTest
    {
        private string _filePath = @"c:\testSandbox\Donios.DeveloperToolkit.IO.FileWriter.Test.txt";

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            System.IO.FileInfo info = new System.IO.FileInfo(_filePath);
            if (info.Exists)
                info.Delete();
        }
        
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>Tests the FileWriter.WriteToFile() method</summary>
        [TestMethod()]
        public void WriteToFileTest()
        {
            string filePath = _filePath;
            string fileContent = "WriteToFileTest()";
            FileWriter.WriteToFile(filePath, fileContent);

            Assert.IsTrue(CheckForFile(filePath));

            using (StreamReader sr = new StreamReader(_filePath))
            {
                Assert.AreEqual(fileContent, sr.ReadToEnd());
            }
        }

        /// <summary>Checks if the filePath specified exists on the file system</summary>
        /// <returns>True: file exists; False: file does not exist;</returns>
        private bool CheckForFile(string filePath)
        {
            System.IO.FileInfo info = new System.IO.FileInfo(filePath);
            return info.Exists;
        }
    }
}
