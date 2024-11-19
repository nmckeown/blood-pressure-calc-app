using Microsoft.VisualStudio.TestTools.UnitTesting;

// NuGet install Selenium WebDriver package and Support Classes
 
using OpenQA.Selenium;

// NuGet install Chrome Driver
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTest
{
    [TestClass]
    public class LandingPage
    {
        private TestContext testContextInstance;

        // test harness uses this property to initliase test context
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        // URI for web app being tested
        private String webAppUri;

        [TestInitialize]                // run before each unit test
        public void Setup()
        {
            // read URL from SeleniumTest.runsettings (configure run settings)
            //this.webAppUri = testContextInstance.Properties["webAppUri"].ToString();
            
            this.webAppUri = "https://ca1app.azurewebsites.net/";
        }

        [TestMethod]
        public void TestBPUI()
        {
            String chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (chromeDriverPath is null)
            {
                chromeDriverPath = ".";                 // for IDE
            }
          
            using (IWebDriver driver = new ChromeDriver(chromeDriverPath))
            {
                // any exception below results in a test fail

                // navigate to URI for temperature converter
                // web app running on IIS express
                driver.Navigate().GoToUrl(webAppUri);

                // get input values and submit button
                IWebElement BPSystolicElement = driver.FindElement(By.Id("BP_Systolic"));
                IWebElement BPDiastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
                IWebElement BPCalcButton = driver.FindElement(By.Id("BP_Calc"));


                // input values
                BPSystolicElement.SendKeys("80");
                BPDiastolicElement.SendKeys("50");

                // calculate
                BPCalcButton.Click();

                IWebElement BPCalc = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
                    .Until(c => c.FindElement(By.Id("BP_Category")));

                string bpval = BPCalc.Text.ToString();
                StringAssert.Contains("Low", bpval);
                //Assert.Contains("Low", bpval);

                //var bpCalc = driver.FindElement(By.Id("Category")).Text.toString();
                //Assert.Contains("Low", result);

                // submit the form
                //driver.FindElement(By.Id("form1")).Submit();

                // explictly wait for result with "BMIValue" item
                //IWebElement BMIValueElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                //    .Until(c => c.FindElement(By.Id("BPCalc")));

                // item comes back like "BMIValue: 24.96"
                //String bmi = BMIValueElement.Text.ToString();

                //StringAssert.EndsWith(bmi, "24.96");

                driver.Quit();


            }
        }
    }

}