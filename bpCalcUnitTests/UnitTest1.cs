using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPCalculator;

namespace BPCalculatorUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLowBloodPressure()
        {
            BloodPressure bp = new BloodPressure() { Systolic = 80, Diastolic = 50 };
            Assert.AreEqual(bp.Category, BPCategory.Low);
        }

        [TestMethod]
        public void TestIdealBloodPressure()
        {
            BloodPressure bp = new BloodPressure() { Systolic = 110, Diastolic = 70 };
            Assert.AreEqual(bp.Category, BPCategory.Ideal);
        }

        [TestMethod]
        public void TestPreHighBloodPressure()
        {
            BloodPressure bp = new BloodPressure() { Systolic = 130, Diastolic = 85 };
            Assert.AreEqual(bp.Category, BPCategory.PreHigh);
        }

        [TestMethod]
        public void TestHighBloodPressure()
        {
            BloodPressure bp = new BloodPressure() { Systolic = 170, Diastolic = 95 };
            Assert.AreEqual(bp.Category, BPCategory.High);
        }

        [TestMethod]
        public void TestPreBorderLowIdealBloodPressure()
        {
            BloodPressure bp = new BloodPressure() { Systolic = 89, Diastolic = 59 };
            Assert.AreEqual(bp.Category, BPCategory.Low);
        }

        [TestMethod]
        public void TestBorderLowIdealBloodPressure()
        {
            BloodPressure bp = new BloodPressure() { Systolic = 90, Diastolic = 60 };
            Assert.AreEqual(bp.Category, BPCategory.Ideal);
        }

        [TestMethod]
        public void TestPreBorderIdealPreHighBloodPressure()
        {
            BloodPressure bp = new BloodPressure() { Systolic = 119, Diastolic = 79 };
            Assert.AreEqual(bp.Category, BPCategory.Ideal);
        }

        [TestMethod]
        public void TestBorderIdealPreHighBloodPressure()
        {
            BloodPressure bp = new BloodPressure() { Systolic = 120, Diastolic = 80 };
            Assert.AreEqual(bp.Category, BPCategory.PreHigh);
        }

        [TestMethod]
        public void TestPreBorderPreHighHighBloodPressure()
        {
            BloodPressure bp = new BloodPressure() { Systolic = 139, Diastolic = 89 };
            Assert.AreEqual(bp.Category, BPCategory.PreHigh);
        }

        [TestMethod]
        public void TestBorderPreHighHighBloodPressure()
        {
            BloodPressure bp = new BloodPressure() { Systolic = 140, Diastolic = 90 };
            Assert.AreEqual(bp.Category, BPCategory.High);
        }

    }
}
// end