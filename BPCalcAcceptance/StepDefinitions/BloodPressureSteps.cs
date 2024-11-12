
﻿using BPCalculator;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace BPCalculator.Tests.StepDefinitions
{
    [Binding]
    public class BloodPressureSteps
    {
        private BloodPressure BP;
        private BPCategory calculatedCategory;

        [Given(@"I have entered a systolic pressure of (.*)")]
        public void GivenIHaveEnteredASystolicPressureOf(int systolic)
        {
            BP = new BloodPressure { Systolic = systolic };
        }
        
        [Given(@"I have entered a diastolic pressure of (.*)")]
        public void GivenIHaveEnteredADiastolicPressureOf(int diastolic)
        {
            BP.Diastolic = diastolic;
        }
        
        [When(@"I calculate the blood pressure")]
        public void WhenICalculateTheBloodPressure()
        {
           calculatedCategory = BP.Category;
        }
        
        [Then(@"the category should be ""(.*)""")]
        public void ThenTheCategoryShouldBe(string expectedCategory)
        {
            Assert.AreEqual(expectedCategory, calculatedCategory.ToString());
        }
    }
}
