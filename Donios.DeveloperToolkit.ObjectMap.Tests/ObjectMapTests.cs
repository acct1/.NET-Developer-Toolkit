using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Donios.DeveloperToolkit.ObjectMap.Tests
{
    /// <summary>Tests for an ObjectMap of Car/MorphedCar objects</summary>
    [TestClass]
    public class ObjectMapTests
    {
        string _color = "blue";
        int _doors = 4;
        bool _hasSatelliteRadio = true;

        public ObjectMapTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>Test that a Car can be converted into a MorphedCar using the ObjectMap.</summary>
        [TestMethod]
        public void ObjectMapTest()
        {
            // create Car
            Car car = new Car();
            car.Color = _color;
            car.Doors = _doors;
            car.HasSatelliteRadio = _hasSatelliteRadio;
            
            // use the objectMap to convert the Car to a MorphedCar
            ObjectMap map = new ObjectMap();
            MorphedCar morphedCar = map.Convert<MorphedCar, Car>(car);

            // validate the MorphedCar contains the right values
            Assert.AreEqual(_color, morphedCar.Color);
            Assert.AreEqual(_doors, morphedCar.Doors);
            Assert.AreEqual(_hasSatelliteRadio, morphedCar.HasSatelliteRadio);
            Assert.IsNull(morphedCar.Name); // the object map does not contain a mapping for the Name field. Therefore, this value should be how the MorphedCar initialized it.
        }
    }
}
