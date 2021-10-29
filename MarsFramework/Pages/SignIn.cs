using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    public class SignIn
    {
        public RemoteWebDriver _driver;

        [Obsolete]
        public SignIn(RemoteWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        public void LoginSteps()
        {
            //extent Reports
            Base.test = Base.extent.StartTest("Login Test");


            //Populate the Excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "SignIn");
            //Navigate to the Url
            _driver.Navigate().GoToUrl(Base.Url);

            //Click on Sign In tab
            SignIntab.Click();
            //Enter the data in Username textbox
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            //Enter the password 
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            ////Click on Login button
            LoginBtn.Click();
            if (_driver.WaitForElementDisplayed(By.XPath("//a[contains(text(),'Mars Logo')]"), 60))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successful");
            }
            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Login failed");
            }

        }    
    }
}