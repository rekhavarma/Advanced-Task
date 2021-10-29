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
using NUnit.Framework;

namespace MarsFramework.Pages
{
    class Notification
    {
        private RemoteWebDriver _driver;

        [Obsolete]
        public Notification(RemoteWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Initialize web driver
        //Notification link
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div[2]/div/div")]
        public IWebElement notificationLink { get; set; }    

        //Click on "See All" link
        [FindsBy(How = How.LinkText, Using = "See All...")]
        public IWebElement seeAllLink { get; set; }

        //Mark As Read link
        [FindsBy(How = How.XPath, Using = "/html//div[@id='service-search-section']/div[1]/div[2]/div/div/div//a[.='Mark all as read']")]
        public IWebElement markAsReadLink { get; set; }

        //Select All button
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Select all']")]
        public IWebElement selectAll { get; set; }

        //Unselect All button
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[2]")]
        public IWebElement unselectAll { get; set; }

        //notification checkbox
        [FindsBy(How = How.XPath, Using = "//input[@value='0']")]
        public IWebElement notificationCheckBox { get; set; }

        // Delete button
        [FindsBy(How = How.XPath, Using = "/html//div[@id='notification-section']//div[@name='NotificationBody']/div[3]/div[1]/div[3]")]
        public IWebElement deleteButton { get; set; }

        //Maerk Selection as read
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[4]")]
        public IWebElement markSelectionAsRead { get; set; }

        //Load more button
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Load More...']")]
        public IWebElement loadMoreLink { get; set; }

        //Show less button
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='...Show Less']")]
        public IWebElement showLessLink { get; set; }
        #endregion

        #region Notification feature
        public void Notifications()
        {
            //Click on notification link
            notificationLink.WaitForElementClickable(_driver, 60);
            notificationLink.Click();

            //Click on See All link
            seeAllLink.WaitForElementClickable(_driver, 60);
            seeAllLink.Click();
            Base.Wait(1);

            //Validate See all link  
            try
             {
                 string expectedTitle = "Dashboard";
                 string actualTitle = _driver.Title;
                 Assert.AreEqual(expectedTitle, actualTitle);
                 Base.Wait(2);
                 test.Log(LogStatus.Pass, " Notification See all feature successful");
                 SaveScreenShotClass.SaveScreenshot(_driver, "Notification view Successful");
             }
             catch(Exception ex)
             {
                 test.Log(LogStatus.Fail, "Test failed");
                 Assert.Fail("Test Failed, Notifications not viewed", ex.Message);
               
             }
            Thread.Sleep(3000);


            //Click on Select All
           selectAll.WaitForElementClickable(_driver, 60).Click();
            Thread.Sleep(2000);

            //Click on Mark as read
             //markSelectionAsRead.WaitForElementClickable(_driver, 60);
             //markSelectionAsRead.Click();

            //Click on Load more
            loadMoreLink.WaitForElementClickable(_driver, 60);
            loadMoreLink.Click();

            //Click on show less link
            showLessLink.WaitForElementClickable(_driver, 60);
            showLessLink.Click();

            //Click on Unselect all link
            unselectAll.WaitForElementClickable(_driver, 60);
            unselectAll.Click();


            //Click on top notification checkbox
            notificationCheckBox.WaitForElementClickable(_driver, 60);
            notificationCheckBox.Click();

            try
            {
                //Click on delete button
                deleteButton.WaitForElementClickable(_driver, 60);
                deleteButton.Click();

                test.Log(LogStatus.Pass, " Notification Delete Test Successful");
                SaveScreenShotClass.SaveScreenshot(_driver, "Notification Delete Successful");
            }
            catch(Exception ex)
            {
                test.Log(LogStatus.Fail, "Test failed");
                Assert.Fail("Test Failed, Notification not deleted", ex.Message);

            }


        }

        #endregion

    }
}
