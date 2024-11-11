using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPCalculator;

namespace BPCalculatorUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private BloodPressure bp;

        [SetUp]
        public void Setup()
        {
            // Initialize the BloodPressure instance before each test
            bp = new BloodPressure();
        }

        [TestMethod]
        public void TestLowBloodPressure()
        {
            bp.Systolic = 80;
            bp.Diastolic = 50;
            Assert.AreEqual(bp.Category, BPCategory.Low);
        }

        [TestMethod]
        public void TestIdealBloodPressure()
        {
            bp.Systolic = 110;
            bp.Diastolic = 70;
            Assert.AreEqual(bp.Category, BPCategory.Ideal);
        }

        [TestMethod]
        public void TestPreHighBloodPressure()
        {
            bp.Systolic = 130;
            bp.Diastolic = 85;
            Assert.AreEqual(bp.Category, BPCategory.PreHigh);
        }

        [TestMethod]
        public void TestHighBloodPressure()
        {
            bp.Systolic = 170;
            bp.Diastolic = 95;
            Assert.AreEqual(bp.Category, BPCategory.High);
        }

        [TestMethod]
        public void TestPreBorderLowIdealBloodPressure()
        {
            bp.Systolic = 89;
            bp.Diastolic = 59;
            Assert.AreEqual(bp.Category, BPCategory.Low);
        }

        [TestMethod]
        public void TestBorderLowIdealBloodPressure()
        {
            bp.Systolic = 90;
            bp.Diastolic = 60;
            Assert.AreEqual(bp.Category, BPCategory.Ideal);
        }

        [TestMethod]
        public void TestPreBorderIdealPreHighBloodPressure()
        {
            bp.Systolic = 119;
            bp.Diastolic = 79;
            Assert.AreEqual(bp.Category, BPCategory.Ideal);
        }

        [TestMethod]
        public void TestBorderIdealPreHighBloodPressure()
        {
            bp.Systolic = 120;
            bp.Diastolic = 80;
            Assert.AreEqual(bp.Category, BPCategory.PreHigh);
        }

        [TestMethod]
        public void TestPreBorderPreHighHighBloodPressure()
        {
            bp.Systolic = 139;
            bp.Diastolic = 89;
            Assert.AreEqual(bp.Category, BPCategory.PreHigh);
        }

        [TestMethod]
        public void TestBorderPreHighHighBloodPressure()
        {
            bp.Systolic = 140;
            bp.Diastolic = 90;
            Assert.AreEqual(bp.Category, BPCategory.High);
        }

        [TestMethod]
        public void TestInvalidBloodPressureValues()
        {
            // Arrange
            Assert.Throws<System.ArgumentOutOfRangeException>(() => bp.Systolic = -1);
            Assert.Throws<System.ArgumentOutOfRangeException>(() => bp.Diastolic = -1);
        }

    }
}
// end