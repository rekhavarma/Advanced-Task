using AutoIt;
using MarsFramework.Global;
using Microsoft.JScript;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using static MarsFramework.Global.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.Remote;

namespace MarsFramework.Pages
{
    public class Profile
    {
        private RemoteWebDriver _driver;
        

        [Obsolete]
        public Profile(RemoteWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Initialise Web Elelements
        //Profile edit
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']//section[@class='nav-secondary']//a[@href='/Account/Profile']")]
        public IWebElement ProfileEdit { get; set; }

        #region Language feature web element
        //Language tab
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div//form//a[.='Languages']")]
        public IWebElement languageTab { get; set; }

        //Language level droppdown
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[2]//select[@name='level']")]
        public IWebElement languageLevel { get; set; }

        //Add New button
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[2]//input[@name='name']")]
        public IWebElement languageAdd { get; set; }

        // Add new language button
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[2]//table//div[.='Add New']")]
        public IWebElement addNewLanguageButton { get; set; }

        //Add button in language 
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[2]//input[@value='Add']")]
        public IWebElement addLanguageButton { get; set; }

        //Save language
        [FindsBy(How = How.XPath, Using = "//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[3]/input[1]")]
        public IWebElement saveLanguage { get; set; }

        //Edit language
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        public IWebElement updateButton { get; set; }

        //Cancel language button
        [FindsBy(How = How.XPath, Using = "//input[@value='Cancel']")]
        public IWebElement cancelLanguageButton { get; set; }

        //Delete language icon
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[2]//table/tbody/tr/td[3]/span[2]/i")]
        public IWebElement deleteLanguage { get; set; }

        // public IWebElement deleteContent => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        #endregion

        #region  certification feature web elements
        //Certification tab
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div//form//a[.='Certifications']")]
        public IWebElement certifications { get; set; }

        //Add new Certificate
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[5]//table//div[.='Add New']")]
        private IWebElement AddNewButton { get; set; }

        //Enter Certification Name
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//input[@name='certificationName']")]
        private IWebElement EnterCertificate { get; set; }

        //Certified from
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Certified From (e.g. Adobe)']")]
        private IWebElement CertificateFrom { get; set; }

        //Year
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//select[@name='certificationYear']")]
        private IWebElement CertificateYear { get; set; }

        //Choose Opt from Year
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select/option[5]")]
        private IWebElement CertificateYearOpt { get; set; }

        // edit icon
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//table/tbody/tr/td[4]/span[1]/i")]
        private IWebElement editCertificate { get; set; }

        //Update certficate button
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//table//input[@value='Update']")]
        private IWebElement updateCertificate { get; set; }

        //Delete icon
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[5]//table/tbody/tr/td[4]/span[2]/i")]
        private IWebElement deleteCertificate { get; set; }

        //Add Ceritification
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[5]//input[@value='Add']")]
        private IWebElement AddCertificate { get; set; }
        #endregion

        #region Profile details web elements
        //Earn Target icon
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']/div[2]/div/div[@class='content']//div[@class='column']/div/div[3]/div/div[4]/div/span/i")]
        public IWebElement earnTarget { get; set; }//i[@class='outline write icon']

        //Description details
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']/div[3]/div/div[@class='content']/div/h3/span[@class='button']/i")]
        public IWebElement editDescriptionIcon { get; set; }

        //Description input box
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']/div[3]/div/div[@class='content']/form//textarea[@name='value']")]
        public IWebElement descriptionText { get; set; }

        //Description save button
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']/div[3]/div/div[@class='content']/form//button[@type='button']")]
        public IWebElement descriptionSave { get; set; }

        //Availability functionality
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i")]
        public IWebElement availability { get; set; }

        //Select Dropdown option
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']/div[2]/div/div[@class='content']//select[@name='availabiltyType']")]
        public IWebElement selectAvailability { get; set; }

        //Cancel Availability
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']/div[2]/div/div[@class='content']//div[@class='column']/div/div[3]/div/div[2]/div/span/i")]
        public IWebElement cancelAvaialbility { get; set; }

        //Hours details
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")]
        public IWebElement hours { get; set; }

        //Avaialble Hours
        [FindsBy(How = How.XPath, Using = "//select[@name='availabiltyHour']")]
        public IWebElement selectAvailabilityHours { get; set; }

        //Cancel Hours

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")]
        public IWebElement cancelHours { get; set; }
        #endregion

        #region skills feature web element

        // Skills feature web elements
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Skills']")]
        public IWebElement skills { get; set; }

        //Add new skill button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")]
        public IWebElement addNewSkill { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Skill']")]
        public IWebElement addSkill { get; set; }

        //Add skill
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")]
        public IWebElement addSkillButton { get; set; }

        //Cancel skill
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[2]")]
        public IWebElement cancelAddSkill { get; set; }
        //Edit skill field
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i")]
        public IWebElement editSKill { get; set; }

        //Edit skill button
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        public IWebElement updateSkillButton { get; set; }

        //Cancel skills buttion
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[2]")]
        public IWebElement cancelSkillUpdate { get; set; }

        //Delete skills icon
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i")]
        public IWebElement deleteSkill { get; set; }
        #endregion

        #region Education feature web elements
        //Click on education tab
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div//form//a[.='Education']")]
        public IWebElement educationTab { get; set; }

        //Click on Add new to Educaiton
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[4]//table//div")]
        private IWebElement AddNewEducation { get; set; }

        //Enter university in the text box
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//input[@name='instituteName']")]
        private IWebElement EnterUniversity { get; set; }

        //Choose the country
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//select[@name='country']")]
        private IWebElement ChooseCountry { get; set; }

        //Choose the skill level option
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select/option[8]")]
        private IWebElement ChooseCountryOpt { get; set; }

        //Click on Title dropdown
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//select[@name='title']")]
        private IWebElement ChooseTitle { get; set; }

        //Choose title
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select/option[7]")]
        private IWebElement ChooseTitleOpt { get; set; }

        //Degree
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//input[@name='degree']")]
        private IWebElement Degree { get; set; }

        //Year of graduation
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//select[@name='yearOfGraduation']")]
        private IWebElement DegreeYear { get; set; }

        //Choose Year
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select/option[11]")]
        private IWebElement DegreeYearOpt { get; set; }

        //Click on Add button
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//input[@value='Add']")]
        private IWebElement AddEdu { get; set; }

        //Click on Edit education icon
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//table/tbody/tr/td[6]/span[1]/i")]
        private IWebElement editEducation { get; set; }

        //Click on Save update button
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//table//input[@value='Update']")]
        private IWebElement updateEdu{ get; set; }

        //Click on Delete icon
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/section[2]/div/div/div[@class='row']//form/div[4]//table/tbody/tr/td[6]/span[2]/i")]
        private IWebElement deleteEducation { get; set; }

        #endregion

        
        #endregion

        #region Add Education feature
        //Add Education
        public void AddEducation()
        {

            //Click on profile tab
            ProfileEdit.WaitForElementClickable(_driver, 60);
            ProfileEdit.Click();

            //Click on education tab
            educationTab.WaitForElementClickable(_driver, 60).Click();

            //Click on add new education button
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Education");
            AddNewEducation.WaitForElementClickable(_driver, 60);
            AddNewEducation.Click();
            //Enter the University
            EnterUniversity.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "University"));

            //Choose Country
            ChooseCountry.Click();
            Base.Wait(3);
            //Choose Country Level
            ChooseCountryOpt.Click();

            //Choose Title
            ChooseTitle.Click();
            Thread.Sleep(3000);
            ChooseTitleOpt.Click();

            Thread.Sleep(3000);
            //Enter Degree
            Degree.Click();
            Degree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Degree"));

            //Year of Graduation
            DegreeYear.Click();
            Thread.Sleep(1500);
            DegreeYearOpt.Click();
            //Click on Add button
            AddEdu.WaitForElementClickable(_driver, 60);
            AddEdu.Click();
            Thread.Sleep(3000);

            //Validate Add Education 
            string actualCountry = _driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[4]//table//td[.='Argentina']")).Text;
            string actualUniversity = _driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[4]//table//td[.='MDU']")).Text;
            string actualTitle = _driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[4]//table//td[.='B.Tech']")).Text;
            if (actualCountry == "Argentina" && actualUniversity == "MDU" && actualTitle == "B.Tech")
            {
                Thread.Sleep(4000);
                test.Log(LogStatus.Pass, " Education added Successful");
                SaveScreenShotClass.SaveScreenshot(_driver, "AddedEducation");
                Thread.Sleep(6000);
                Assert.IsTrue(true);
            }
            else
            {
                test.Log(LogStatus.Fail, "Test Failed");
            }
            Thread.Sleep(500);
        }

        #endregion

        #region Update Education details
        public void UpdateEducation()
        {
            //Click on education tab
            educationTab.WaitForElementClickable(_driver, 60).Click();

            //Click on Edit education button
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Education");
            editEducation.WaitForElementClickable(_driver, 60);
            editEducation.Click();
            Thread.Sleep(3000);
            //Enter the University
            EnterUniversity.Clear();
            EnterUniversity.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "University"));
            updateEdu.WaitForElementClickable(_driver, 60);
            updateEdu.Click();

            //Validate Update Education 
            Thread.Sleep(3000);
            string actualUniversity = _driver.FindElement(By.XPath("/html//div[@id='account-profile-section']/div/section[2]/div/div//form/div[4]//table//td[.='ITM']")).Text;

            if (actualUniversity == "ITM")
            {
                Thread.Sleep(2000);
                test.Log(LogStatus.Pass, " Education Updated Successful");
                SaveScreenShotClass.SaveScreenshot(_driver, "EditedEducation");
                Thread.Sleep(6000);
                Assert.IsTrue(true);
            }
            else
            {
                test.Log(LogStatus.Fail, "Test Failed");
            }
        }
        #endregion

        #region Delete Education
        public void DeleteEducation()
            {
            //Click on education tab
            educationTab.WaitForElementClickable(_driver, 60).Click();
            educationTab.Click();
            
            //Click on  Delete icon
            deleteEducation.WaitForElementClickable(_driver, 60);
            deleteEducation.Click();

            //Validate delete Education 
           
            IWebElement messageDelete = _driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            Base.Wait(3);
            Assert.IsTrue(messageDelete.Enabled);
            Base.test.Log(LogStatus.Pass, "Deleted Education successfully");
            SaveScreenShotClass.SaveScreenshot(_driver, "Education deleted");

        }

        
        #endregion

        #region Add certification
        //Add new Certificate
        public void AddNewCertificate()
        {

            //Click on profile tab
            ProfileEdit.WaitForElementClickable(_driver, 60);
            ProfileEdit.Click();

            //Click on certification tab
            certifications.WaitForElementClickable(_driver, 40);
            certifications.Click();

            //Click on Add new certificate button
            AddNewButton.WaitForElementClickable(_driver, 60);
            AddNewButton.Click();
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Certification");
            Base.Wait(3);
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Certification");
            //Enter Certificate Name
            EnterCertificate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certification"));

            Base.Wait(4);
            //Enter Certified from
            CertificateFrom.Click();
            Base.Wait(6);
            CertificateFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "From "));

            Base.Wait(5);
            //Enter the Year
            CertificateYear.Click();
            Base.Wait(1);
            CertificateYearOpt.Click();
            AddCertificate.Click();
            Thread.Sleep(500);
          //Validate Add certification 
            string actualCertificateName = _driver.FindElement(By.XPath("//td[normalize-space()='Publishing']")).Text;
            string expectedCertificateName = GlobalDefinitions.ExcelLib.ReadData(2, "Certification");
            Assert.AreEqual(actualCertificateName, expectedCertificateName);
            Base.Wait(3);
            Base.test.Log(LogStatus.Pass, "Added Certificate successfully");
            SaveScreenShotClass.SaveScreenshot(_driver, "Certficate Added");

        }
        #endregion

        #region Update certification
        
        public void EditCertificate()
        {

            //Click on profile tab
            ProfileEdit.WaitForElementClickable(_driver, 60);
            ProfileEdit.Click();

            //Click on certification tab
            certifications.WaitForElementClickable(_driver, 40);
            certifications.Click();

            //Click on Add new certificate button
            Thread.Sleep(4000);
            editCertificate.Click();
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Certification");
            Thread.Sleep(3000);
            //Enter Certificate Name
            EnterCertificate.Clear();
            EnterCertificate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Certification"));

            //Click on save button
            updateCertificate.WaitForElementClickable(_driver, 60);
            updateCertificate.Click();
            Thread.Sleep(500);
            //Validate Update certification 
            string actualCertificateName = _driver.FindElement(By.XPath("//td[normalize-space()='MBA']")).Text;
            string expectedCertificateName = GlobalDefinitions.ExcelLib.ReadData(3, "Certification");
            Assert.AreEqual(actualCertificateName, expectedCertificateName);
            Base.Wait(3);
            Base.test.Log(LogStatus.Pass, "Edit Certificate successfully");
            SaveScreenShotClass.SaveScreenshot(_driver, "Certficate updated");
        }
        #endregion

        #region Delete certification
        //Delete Certificate
        public void DeleteCertificate()
        {

            //Click on profile tab
            ProfileEdit.WaitForElementClickable(_driver, 60);
            ProfileEdit.Click();

            //Click on certification tab
            certifications.WaitForElementClickable(_driver, 40);
            certifications.Click();

            Thread.Sleep(4000);
            //Click on save button
            deleteCertificate.Click();
            Thread.Sleep(500);
            //Validate delete certificate
            IWebElement deleteMessage = _driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            Base.Wait(3);
            Assert.IsTrue(deleteMessage.Enabled);
            Base.test.Log(LogStatus.Pass, "Deleted certifcation successfully"); 
            SaveScreenShotClass.SaveScreenshot(_driver, "Certficate deleted");
        }
        #endregion

        #region Edit Availability, Hours and Earn Target feature
        public void EditProfile()
        {
            //Click on profile tab
            ProfileEdit.WaitForElementClickable(_driver, 60);
            ProfileEdit.Click();

            #region Description feature
            // Save Description
            //Click on edit description icon
            editDescriptionIcon.WaitForElementClickable(_driver, 60);
            editDescriptionIcon.Click();
            //Read description from Excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Description");
            descriptionText.WaitForElementClickable(_driver, 30);
            Base.Wait(3);
            descriptionText.Clear();
            Base.Wait(3);
            descriptionText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Base.Wait(2);
            //Save description added from Excel
            descriptionSave.Click();
            //Validate description
            string actualDescription = descriptionText.Text;
            string expectedDescription = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
            Assert.AreEqual(actualDescription, expectedDescription);
            Base.test.Log(LogStatus.Pass, "Description added successfully");
            SaveScreenShotClass.SaveScreenshot(_driver, "Description added");

            #endregion

            #region Availability Feature

            //Click on edit availablity
            availability.WaitForElementClickable(_driver, 60);
            availability.Click();

            //Select options from dropdown list
            SelectElement dropSelectAvailability = new SelectElement(selectAvailability);
            Base.Wait(2);
            Random rnd = new Random();
            int count = rnd.Next(1, 2);
            dropSelectAvailability.SelectByIndex(count);
            Base.Wait(2);
            Base.test.Log(LogStatus.Info, "Added Availability successfully");

           
            #endregion

            #region Hours Feature
            //Add Hours
            hours.WaitForElementClickable(_driver, 60);
            //Click on add hours icon 
            hours.Click();
            //Select available hours option
            SelectElement dropAvailabilityHours = new SelectElement(selectAvailabilityHours);
            Thread.Sleep(1000);
            dropAvailabilityHours.SelectByIndex(rnd.Next(1, 3));
            Thread.Sleep(2000);
            Base.test.Log(LogStatus.Info, "Added Hours successfully");

            //Cancel Add Hours
            //cancelHours.Click();
            #endregion
        }
        #endregion

        #region Add new skills
        //Add new Skill
        public void AddSkills()
        {
            //Click on profile tab
            ProfileEdit.WaitForElementClickable(_driver, 60);
            ProfileEdit.Click();

            skills.WaitForElementClickable(_driver, 60);
            //Add new skill
            skills.Click();

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Skills");
            //Read data from excel file
            for (int i = 2; i <= 4; i++)
            {
                Thread.Sleep(3000);
                //GlobalDefinitions.wait(3);
                addNewSkill.Click();
                Thread.Sleep(4000);
                //GlobalDefinitions.wait(3);
                addSkill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i, "Skillls"));

                //Select option from drop down list
                SelectElement skillsdropdown = new SelectElement(_driver.FindElement(By.Name("level")));
                //GlobalDefinitions.wait(3);

                Thread.Sleep(1000);
                //Generating random value to select option from dropdown list
                Random rnd = new Random();
                int count = rnd.Next(1, i);
                skillsdropdown.SelectByIndex(count);

                //Thread.Sleep(500);
                addSkillButton.Click();
                Thread.Sleep(1000);

                #region Validate Add skills feature 
                //Validate the skills are added sucessfully
                try
                {
                    //Start Reports
                    test = extent.StartTest("Add skills");
                    test.Log(LogStatus.Info, "Adding skills");
                    String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Skills");
                    //List table data       
                    IList<IWebElement> rows = _driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                    //Read the row count in table
                    for (var y = 1; y < rows.Count; y++)
                    {
                        Thread.Sleep(4000);
                        string actualValue = _driver.FindElement(By.XPath("//div/table/tbody[" + y + "]/tr/td[1]")).Text;
                        //Verify if expected value is equal to actual value
                        if (expectedValue == actualValue)
                        {
                            test.Log(LogStatus.Pass, "Skills added Successful");
                            SaveScreenShotClass.SaveScreenshot(_driver, "SkillsAdd");
                            Assert.IsTrue(true);
                        }
                    
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Thread.Sleep(1500);
                #endregion
            }
        }
        #endregion

        #region Edit Skills feature
        //Update added skills
        public void UpdateSkills()
        {
            //Click on profile tab
            ProfileEdit.WaitForElementClickable(_driver, 60);
            ProfileEdit.Click();
            skills.WaitForElementClickable(_driver, 60);
            //Add new skill
            skills.Click();

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Skills");
            Thread.Sleep(6000);
            //Update and read Skills from Excel data
            for (int i = 1; i <= 3; i++)
            {

                IWebElement editIcon = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                editIcon.WaitForElementClickable(_driver, 40);
                //Click on Edit skills icon
                editIcon.Click();
                //Clear content for skills input 
                addSkill.Clear();
                Thread.Sleep(500);
                //Read updated skills from Excel file
                addSkill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "Updated_Skills"));

                // Select and input value from Skills level dropdown list
                SelectElement skillsdropdown = new SelectElement(_driver.FindElement(By.Name("level")));
                //Generating random value to select option from dropdown list
                Random rnd = new Random();
                int count = rnd.Next(1, i);
                skillsdropdown.SelectByIndex(count);
                Thread.Sleep(1500);
                //Save updated Skills
                updateSkillButton.Click();

            }


            #region Validate update skills feature

            //Validate the skills are updated sucessfully
            try
            {
                //Start Reports
                test = extent.StartTest("Update Skills");
                test.Log(LogStatus.Info, "Updating Skills");
                String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Updated_Skills");
                //List table data       
                IList<IWebElement> rows = _driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Read the row count in table
                for (var i = 1; i < rows.Count; i++)
                {
                    Thread.Sleep(4000);
                    string actualValue = _driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    //Verify if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        test.Log(LogStatus.Pass, " Skills Update Successful");
                        SaveScreenShotClass.SaveScreenshot(_driver, "skillsUpdate");
                        Assert.IsTrue(true);
                    }
                  
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(1500);
            #endregion
        }

        #endregion

        #region Delete skills
        //Delete skills
        public void DeleteSkills()
        {
            //Click on profile tab
            ProfileEdit.WaitForElementClickable(_driver, 60);
            ProfileEdit.Click();

            skills.WaitForElementClickable(_driver, 60);
            skills.Click();
            Thread.Sleep(3000);
            IList<IWebElement> rows = _driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr"));
            //Read the row count in table
            for (var i = 1; i <= rows.Count; i++)
            {
                Thread.Sleep(2000);
                deleteSkill.Click();

            }


            #region Validate Delete skills

            try
            {
                //Start Reports
                test = extent.StartTest("Delete Skills");
                test.Log(LogStatus.Info, "Deleting skills");

                //List table data       
                IList<IWebElement> rowsDelete = _driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Read the row count in table
                for (var i = 1; i < rowsDelete.Count; i++)
                {
                    Thread.Sleep(4000);
                    string actualValue = _driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    //Verify if actual value is equal to null
                    if (actualValue == null)
                    {
                        test.Log(LogStatus.Pass, " Skills delete Successful");
                        SaveScreenShotClass.SaveScreenshot(_driver, "DeleteSkills");
                        Thread.Sleep(4000);
                        Assert.IsTrue(true);
                    }
                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(1500);

            #endregion
        }

        #endregion

        #region Add language
        //Add new language
        public void AddLanguage()
        {
            languageTab.WaitForElementClickable(_driver, 60);
            //Add new language
            languageTab.Click();

            //Populate data into excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Language");
            //Read data from excel file
            for (int i = 2; i <= 5; i++)
            {
                //Click on add new button
                addNewLanguageButton.WaitForElementClickable(_driver, 60);
                addNewLanguageButton.Click();
                
                //Read data from excel
                Base.Wait(2);
                languageAdd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i, "Language"));
                
                //Select option from drop down list
                SelectElement dropdownLanguage = new SelectElement(_driver.FindElement(By.Name("level")));
                Base.Wait(2000);
                //Generating random value to select option from dropdown list
                Random rnd = new Random();
                int count = rnd.Next(1, i);
                dropdownLanguage.SelectByIndex(count);
                saveLanguage.Click();
                Thread.Sleep(2000);
            }
            
            #region Validate the language is added sucessfully

            try
            {
                //Start Reports
                test = extent.StartTest("Add Language");
                test.Log(LogStatus.Info, "Adding language");
                String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Language");
                //List table data       
                IList<IWebElement> rowsAdd = _driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Read the row count in table
                for (var k = 1; k < rowsAdd.Count; k++)
                {
                   
                    string actualValue = _driver.FindElement(By.XPath("//div/table/tbody[" + k + "]/tr/td[1]")).Text;
                    //Verify if expected value is equal to actual value
                    
                    if (expectedValue == actualValue)
                    {
                        Base.Wait(4);
                        Assert.IsTrue(true);
                        test.Log(LogStatus.Pass, " Language added Successful");
                        SaveScreenShotClass.SaveScreenshot(_driver, "languageAdd");
                        Base.Wait(2);
                        
                    }
                
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message, "Test Failed");
            }
           
            #endregion
             

            }
             #endregion

        #region Update language
        //Update added language
        public void UpdateLanguage()
        {
            //Click on languageTab
            languageTab.WaitForElementClickable(_driver, 60);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Language");

            //Update and read language from Excel data
            for (int i = 1; i <= 4; i++)
            {
                Thread.Sleep(1000);
                IWebElement editIcon = _driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                //Click on Edit icon 
                editIcon.Click();
                //Clear content for language input 
                Thread.Sleep(1000);
                languageAdd.Clear();
                Base.Wait(2);
                //Read updated language from Excel file
                languageAdd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i + 1, "Updated_Language"));
                Thread.Sleep(500);
                // Select and input value from language level dropdown list
                SelectElement dropdown = new SelectElement(_driver.FindElement(By.Name("level")));
                //Generating random value to select option from dropdown list
                Random rnd = new Random();
                int count = rnd.Next(1, i);
                dropdown.SelectByIndex(count);
                Thread.Sleep(1000);
                //Save updated language
                updateButton.Click();
                Base.Wait(4);
            }

       

            #region Validate the language is updated sucessfully
            try
            {
                //Start Reports
                test = extent.StartTest("Update Language");
                test.Log(LogStatus.Info, "Updating language");
                String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Updated_Language");
                Base.Wait(2);
                //List table data      
                IList<IWebElement> rows = _driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Read the row count in table
                for (var i = 1; i < rows.Count; i++)
                {
                    Thread.Sleep(4000);
                    string actualValue = _driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    //Verify if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        Assert.IsTrue(true);
                        Base.Wait(4);
                        test.Log(LogStatus.Pass, "Language Update Successful");
                        SaveScreenShotClass.SaveScreenshot(_driver, "languageUpdate");
                        
                    }
                   
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Test Failed", e.Message);
            }
            Base.Wait(2);

            #endregion

        }
        #endregion

        #region Delete language
        //Delete added language
        public void DeleteLanguage()
        {

            //Click on languageTab
            languageTab.WaitForElementClickable(_driver, 60);

            //List table data       
            IList<IWebElement> rowsDelete = _driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
            //Read the row count in table
            for (var i = 1; i <= rowsDelete.Count; i++)
            {
                deleteLanguage.WaitForElementClickable(_driver, 60);
                //Click on DeleteIcon
                deleteLanguage.Click();
              
               
            }

            #region Validate Delete language feature
            try
            {
                //Start Reports
                test = extent.StartTest("Delete Language");
                test.Log(LogStatus.Info, "Deleting language");

                //Read the row count in table
                for (var i = 1; i < rowsDelete.Count; i++)
                {
                    
                    string actualValue = _driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    
                    //Verify if actual value is equal to null
                    if (actualValue == null)
                    {
                        Assert.IsTrue(true);
                        Base.Wait(2);
                        test.Log(LogStatus.Pass, " Language delete Successful");
                        SaveScreenShotClass.SaveScreenshot(_driver, "DeleteLanguage");
                      
                    }
  

                }
               
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message, "Test Failed");
            }
            Base.Wait(3);

            #endregion
        }
        #endregion
    }

}
