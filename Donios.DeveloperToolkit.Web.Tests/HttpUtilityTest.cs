namespace Donios.DeveloperToolkit.Web.Tests
{
    using Donios.DeveloperToolkit.Web;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;    
    
    /// <summary>
    ///This is a test class for HttpUtilityTest and is intended
    ///to contain all HttpUtilityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HttpUtilityTest
    {


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
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for HttpUtility Constructor
        ///</summary>
        [TestMethod()]
        public void HttpUtilityConstructorTest()
        {
            HttpUtility target = new HttpUtility();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for HttpGet
        ///</summary>
        [TestMethod()]
        public void HttpGetTest()
        {
            string URI = "http://www.google.com/#q=github";
            string expected = "<title>Google</title>";
            string actual;
            actual = HttpUtility.HttpGet(URI, null);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Contains(expected));
        }

        /// <summary>
        ///A test for HttpPost
        ///</summary>
        [TestMethod()]
        public void HttpPostTest()
        {
            string URI = "http://posttestserver.com/post.php";
            string expected = "dumped 2 post variables";
            string actual;
            actual = HttpUtility.HttpPost(URI, "q=github&q2=donios", null);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Contains(expected));
        }
    }
}
