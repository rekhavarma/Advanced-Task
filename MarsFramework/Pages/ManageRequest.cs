using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.Remote;

namespace MarsFramework.Pages
{
    public class ManageRequest
    {
        private RemoteWebDriver _driver;

        [Obsolete]
        public ManageRequest(RemoteWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Initialize web elements
        // Manage request tab
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']//section[@class='nav-secondary']/div/div[1]")]
        public IWebElement manageRequest { get; set; }

        //Received request
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']//section[@class='nav-secondary']//div[@class='menu transition visible']/a[@href='/Home/SentRequest']")]
        public IWebElement sentRequest { get; set; }

        //Sent Requests
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']//section[@class='nav-secondary']//div[@class='menu transition visible']/a[@href='/Home/ReceivedRequest']")]
        public IWebElement receivedRequest { get; set; }

        //Accept button in Received request
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Accept']")]
        public IWebElement acceptButton { get; set; }

        //Decline button in Received request
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Decline']")]
        public IWebElement declineButton { get; set; }

        //Withdraw button in Sent request   
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Withdraw']")]
        public IWebElement withdrawButton { get; set; }

        //Complete button for accepted request
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Complete']")]
        public IWebElement completeButton { get; set; }

        //Status message for complete request
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")]
        public IWebElement completeStatus { get; set; }

        //status fore request declined
        [FindsBy(How = How.XPath, Using = "//td[normalize-space()='Declined']")]
        public IWebElement declineStatus { get; set; }

        //status for request withdrawn
        [FindsBy(How = How.XPath, Using = "/html//div[@id='sent-request-section']//table/tbody/tr[1]/td[5]")]
         public IWebElement withdrawStatus { get; set; }

        #endregion

        #region Accept receive request
        public void AcceptReceivedRequest()
        {
            //Click on Manage request
            manageRequest.WaitForElementClickable(_driver, 60);
            manageRequest.Click();

            //Click Received request
            receivedRequest.WaitForElementClickable(_driver, 60);
            receivedRequest.Click();

            //Click on accept button
            acceptButton.WaitForElementClickable(_driver, 60);
            acceptButton.Click();

            //Click on complete button
            completeButton.WaitForElementClickable(_driver, 60);
            completeButton.Click();
            Thread.Sleep(2000);

            //Validate request complete
            try
            {
                if (completeStatus.Text == "Request has been updated")
                {
                    test.Log(LogStatus.Pass, "Test Passed, Request completed");
                    SaveScreenShotClass.SaveScreenshot(_driver, "completed successful");
                }
            }
            catch (Exception ex)
            {
                test.Log(LogStatus.Fail, "Test Failed");
                Assert.Fail("Test Failed, Complete not successful", ex.Message);

            }
        }
        #endregion

        #region Decline Accept Request
        public void DeclineRequest()
        {
            //Click on Manage request
            manageRequest.WaitForElementClickable(_driver, 60);
            manageRequest.Click();

            //Click Received request
            receivedRequest.WaitForElementClickable(_driver, 60);
            receivedRequest.Click();

            //Click on Withdraw button
            declineButton.WaitForElementClickable(_driver, 60);
            declineButton.Click();

            Thread.Sleep(3000);
            Assert.IsTrue(declineStatus.Text == "Declined");
          
            Base.Wait(2);
                
            test.Log(LogStatus.Pass, "Test Passed, Request declined");
            SaveScreenShotClass.SaveScreenshot(_driver, "Decline successful");
        }
        #endregion

        #region Withdraw sent request
        public void WithdrawRequest()
        {
            //Click on Manage request
            manageRequest.WaitForElementClickable(_driver, 60);
            manageRequest.Click();

            //Click Sent request
            sentRequest.WaitForElementClickable(_driver, 60);
            sentRequest.Click();

            //Click on withdraw button
            withdrawButton.WaitForElementClickable(_driver, 60);
            withdrawButton.Click();

            //Validate withdrawn request
            Thread.Sleep(3000);
            Assert.IsTrue(withdrawStatus.Text == "Withdrawn");

            Base.Wait(4);

            test.Log(LogStatus.Pass, "Test Passed, Request withdrawn");
            SaveScreenShotClass.SaveScreenshot(_driver, "Withdraw successful");
           
        }
        #endregion 

    }

}