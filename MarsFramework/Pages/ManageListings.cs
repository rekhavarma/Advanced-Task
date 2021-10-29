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
    public class ManageListings 
    {
        private RemoteWebDriver _driver;

        [Obsolete]
        public ManageListings(RemoteWebDriver driver) 
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Initialise web Elements
        //Click on Manage Listings Link
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Manage Listings']")]
        public IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "/html//div[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]/i[@class='eye icon']")]
        public IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i")]
        public IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "/html//div[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i")]
        public IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        public IWebElement clickActionsButton { get; set; }

        //Click on Yes  
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        public IWebElement clickYesButton { get; set; }

        //Click on No 
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[1]")]
        public IWebElement clickNoButton { get; set; }

        //Select category for the top row
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]")]
        public IWebElement categoryType { get; set; }
       

        //Select Title for the top row
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]")]
        public IWebElement titleText { get; set; }

        //Select Description for the top row
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]")]
        public IWebElement descriptionText { get; set; }

       //Delete confirmation  Message
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/h3")]
        public IWebElement messageDisplay { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        public IWebElement title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        public IWebElement description { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        public IWebElement Save { get; set; }
        #endregion

        #region Edit service listings
        public void EditServiceListing()
        {
            //Click on ManageListing Link
            manageListingsLink.WaitForElementClickable(_driver, 60);
            manageListingsLink.Click();

            //Click on edit service Icon
            edit.WaitForElementClickable(_driver, 60);
            edit.Click();

            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            Thread.Sleep(2000);
            //Edit the title and read from Excel
            title.Clear();
            Thread.Sleep(2);
            title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter Description
            description.Clear();
            Thread.Sleep(2);
            description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Click on Save listing button
            Save.WaitForElementClickable(_driver, 60);
            Save.Click();

            #region Validate edit service listing functionality

            Thread.Sleep(2);
            string expectedTitle = "Software Testing";
            string expectedDescription = "Experience in both Manual and Automatic Testing";

            try
            {
                //Start the Reports

                Thread.Sleep(1000);
                Base.test = Base.extent.StartTest("Edit a Service Listing");
                test.Log(LogStatus.Info, "Editing a listing");
                titleText.WaitForElementClickable(_driver, 60);

                //Verify if expected value and actual values are same for Title and description content
                Assert.IsTrue((titleText.Text == expectedTitle && descriptionText.Text == expectedDescription));
                Thread.Sleep(2000);
                test.Log(LogStatus.Pass, "Test Passed, Service listing edited Successfully");
                SaveScreenShotClass.SaveScreenshot(_driver, "SkillsEditedSuccessfully");
                Assert.IsTrue(true);
            }

            catch (Exception ex)
            {
                test.Log(LogStatus.Fail, "Test Failed");
                Console.WriteLine(ex.Message);
            }

            #endregion


        }   
        #endregion

        #region View service Listing
            public void ViewListing()
        {

            //Click on ManageListing Link
            manageListingsLink.WaitForElementClickable(_driver, 60);
            manageListingsLink.Click();

            //Click on View Listing icon
            view.WaitForElementClickable(_driver, 60);
            view.Click();

            //Validate view listing feature
            Base.Wait(3);
            string actualPageTitle = _driver.Title;
            string expectedPageTitle = "Service Detail";

            try
            {
                //Start the Reports

                Base.test = Base.extent.StartTest("View a Service Listing");
                test.Log(LogStatus.Info, "View listing");
                Base.Wait(2);
                //verify if actual and expected page title are same
                Assert.AreEqual(actualPageTitle, expectedPageTitle);
                Base.Wait(2);
                test.Log(LogStatus.Pass, "Test Passed, Service listing viewed");
                SaveScreenShotClass.SaveScreenshot(_driver, "ViewSuccessfully");
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Base.Wait(2);
                test.Log(LogStatus.Fail, "Test Failed");
                Assert.Fail("Test Failed, Skill not viewed", ex.Message);
            }
        }
        #endregion

        #region Delete Service Listing
        public void DeleteListings()
        {

            //wait for element to be clickable
            manageListingsLink.WaitForElementClickable(_driver, 60);
            //click on Manage listing Link
            manageListingsLink.Click();

            //click on delete link
            delete.WaitForElementClickable(_driver, 60);
            delete.Click();

            //Wait for Click Yes button element
            clickYesButton.WaitForElementClickable(_driver, 60);
            //Confirm Delete operation
            clickYesButton.Click();
            
       
        #region Validate delete listings functionality
        
            Thread.Sleep(5000);
            //wait for TitleText to be clickable
            string actualMessageDisplay = "You do not have any service listings!";
            string expectedMessageDisplay = messageDisplay.Text;
           
            try
            {
                //Start the Reports

                Base.Wait(1);
                Base.test = Base.extent.StartTest("Delete a Service Listing");
                test.Log(LogStatus.Info, "Delete a listing");

                //verify if skill listing is deleted deleted 
                Assert.AreEqual(actualMessageDisplay, expectedMessageDisplay);

                test.Log(LogStatus.Pass, "Test Passed, Service listing deleted Successfully");
                SaveScreenShotClass.SaveScreenshot(_driver, "SkillsdeleteSuccessful");
                Assert.IsTrue(true);

            }

            catch (Exception ex)
            {
                test.Log(LogStatus.Fail, "Test Failed");
                Console.WriteLine(ex.Message);
            }

        
            #endregion

        }
        #endregion
    }
}

