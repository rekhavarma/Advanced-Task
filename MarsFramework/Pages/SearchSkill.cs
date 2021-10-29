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
    public class SearchSkill
    {
        private RemoteWebDriver _driver;

        [Obsolete]
        public SearchSkill(RemoteWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Initialise the web element
        //Search skills input box
        [FindsBy(How = How.XPath, Using = "//div[@class='four wide column']//input[@placeholder='Search skills']")]
        public IWebElement searchSkillsTextbox { get; set; }

        //Search skills icon
        [FindsBy(How = How.XPath, Using = "//i[@class='search link icon']")]
        public IWebElement searchSkillsIcon { get; set; }
       
        //Search user input box
        [FindsBy(How = How.XPath, Using = " //input[@placeholder='Search user']")]
        public IWebElement searchUserTextbox { get; set; }
        
        //Search user input box
        [FindsBy(How = How.XPath, Using = " //*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span")]
        public IWebElement searchUserLink { get; set; }
              
        //All category link
         [FindsBy(How = How.XPath, Using = "/html//div[@id='service-search-section']//section[@class='search-results']//div[@role='list']/a[1]/b[.='All Categories']")]
        public IWebElement allCategories { get; set; }

        //Search Category
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[3]/div/section/div/div[1]/div[1]/div/a[2]/b")]
        public IWebElement categoryType { get; set; }

        //Search subCategory
        [FindsBy(How = How.XPath, Using = "/html//div[@id='service-search-section']//section[@class='search-results']//div[@role='list']/a[3]/b[.='Logo Design']")]
        public IWebElement subCategoryType { get; set; }

        // Online search filter
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Online']")]
        public IWebElement onlineFilter { get; set; }

        //Filter offline search filter
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Onsite']")]
        public IWebElement offlineFilter { get; set; }

        //Show all filter
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='ShowAll']")]
        public IWebElement showAllFilter { get; set; }

        //Filtered skill
        //Show all filter
        [FindsBy(How = How.XPath, Using = "//em[normalize-space()='Skills: Test']")]
        public IWebElement filteredSkill { get; set; }

        #endregion


        #region Search skills
        public void SearchSkillsFilter()
        {
            //Click on search skills icon
            searchSkillsIcon.WaitForElementClickable(_driver, 60);
            searchSkillsIcon.Click();

            Base.Wait(4);
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkills");
            //Enter skills to be searched
            searchSkillsTextbox.WaitForElementClickable(_driver, 60);
            searchSkillsTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchSkill"));

            searchUserTextbox.WaitForElementClickable(_driver, 60);
            searchUserTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "User"));
            Base.Wait(4);
            searchUserLink.Click();

            //Click on online filter
            onlineFilter.WaitForElementClickable(_driver, 60);
            onlineFilter.Click();

            //Click on offline filter
            Base.Wait(2);
            offlineFilter.Click();

            //Click on ShowAll filter
            showAllFilter.Click();

            //Validate filter
            Base.Wait(3);
            Assert.IsTrue(filteredSkill.Displayed);
            test.Log(LogStatus.Pass, "Test Passed, Skill filtered");
            SaveScreenShotClass.SaveScreenshot(_driver, "Search filtered");
            Base.Wait(3);
        }
        #endregion

        

    }
}

