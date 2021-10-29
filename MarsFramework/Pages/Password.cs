using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.Base;
using RelevantCodes.ExtentReports;
using MarsFramework.Global;
using System.Threading;

namespace MarsFramework.Pages
{
    class Password
    {
        private RemoteWebDriver _driver;

        [Obsolete]
        public Password(RemoteWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        #region Password Change web elements
        //Account holder name
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement userName { get; set; }

        //change password link
        [FindsBy(How = How.LinkText, Using = "Change Password")]
        private IWebElement changePasswordLink { get; set; }

        //current password text box
        [FindsBy(How = How.XPath, Using = "//body[@class='dimmable dimmed']/div[4]//form//input[@name='oldPassword']")]
        private IWebElement currentPassword { get; set; }

        //new password text box
        [FindsBy(How = How.XPath, Using = "//body[@class='dimmable dimmed']/div[4]//form//input[@name='newPassword']")]
        private IWebElement newPassword { get; set; }

        //confirm password text box
        [FindsBy(How = How.XPath, Using = "//body[@class='dimmable dimmed']/div[4]//form//input[@name='confirmPassword']")]
        private IWebElement confirmPassword { get; set; }

        //Account holder name
        [FindsBy(How = How.XPath, Using = "//body[@class='dimmable dimmed']/div[4]//form//button[@role='button']")]
        private IWebElement savePassword { get; set; }

        #endregion

        public void ResetPassword()
        {
            //Click on account holder name
            userName.WaitForElementClickable(_driver, 60);
            userName.Click();

            //Click on Change passwordlink
            changePasswordLink.WaitForElementClickable(_driver, 60);
            changePasswordLink.Click();

            Base.Wait(3);
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ChangePassword");
            //Enter old password
            currentPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CurrentPassword"));

            //Enter new password
            Base.Wait(1);
            newPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "NewPassword"));

            //Enter confirm password
            Base.Wait(1);
            confirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPassword"));

            savePassword.WaitForElementClickable(_driver, 60);
            savePassword.Click();
            Thread.Sleep(500);
            Base.test.Log(LogStatus.Info, "Password reset successfully");
        }
    }
}
