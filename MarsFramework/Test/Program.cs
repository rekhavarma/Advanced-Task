using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;

namespace MarsFramework
{

    [TestFixture(BrowserType.Firefox)]
    [TestFixture(BrowserType.Chrome)]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("Sprint1")]
    public class Program : Base
    {
        public Program(BrowserType browser) : base(browser, _driver)
        {
        }
    

        //Add a new skill
        [Test]
        [Obsolete]
        public void AddNewSkillTest()
        {
            test = extent.StartTest("Add New Skills ");
            ShareSkill shareSkillObj = new ShareSkill(_driver);
            shareSkillObj.EnterSkill();
           
        }

        //Manage Listing feature
       [Test]
         [Obsolete]
         public void ManageServiceListingTest()
         {
            test = extent.StartTest("Manage Service Listing ");
            ManageListings manageListingsObj = new ManageListings(_driver);
             manageListingsObj.ViewListing();
             manageListingsObj.EditServiceListing();
              manageListingsObj.DeleteListings();

         }

        

        // Select availablity feature test
        [Test]
        [Obsolete]
        public void ProfileDetailsEdit()
        {
           test = extent.StartTest("Profile Details ");

            Profile profileObj = new Profile(_driver);
            profileObj.EditProfile();
            
        }

        [Test]
        [Obsolete]
        public void ProfileSkillsFeatureTest()
        {
            test = extent.StartTest("Profile Skills");

            Profile profileObj = new Profile(_driver);
            profileObj.AddSkills();
            profileObj.UpdateSkills();
            profileObj.DeleteSkills();
        }

        // Education feature test
        [Test]
        [Obsolete]
        public void EducationFeatureTest()
        {
            test = extent.StartTest("Profile Education");
            Profile profileObj = new Profile(_driver);
            //Add education
            profileObj.AddEducation();
            //Edit Education
            profileObj.UpdateEducation();
            //Delete Education
            profileObj.DeleteEducation();
        }

        // Certification feature test
        [Test]
        [Obsolete]
        public void CertificationFeatureTest()
        {
            test = extent.StartTest("Profile Certification");
            Profile profileObj = new Profile(_driver);
            //Add Certification
            profileObj.AddNewCertificate();
            //Edit Certification
            profileObj.EditCertificate();
            //Delete Certification
            profileObj.DeleteCertificate();

        }
        // language feature test
        [Test]
        [Obsolete]
        public void LanguageFeatureTest()
        {
            test = extent.StartTest("Profile Language");
            Profile profileObj = new Profile(_driver);
            //Add language test
            profileObj.AddLanguage();
            //Update language test
            profileObj.UpdateLanguage();
            //Delete language test
            profileObj.DeleteLanguage();
           
        }

        //Change password test
        [Test]
        [Obsolete]
        public void ChangePasswordTest()
        {
            test = extent.StartTest("Reset Password");
            Password passObj = new Password(_driver);
            //Reset password
            passObj.ResetPassword();

        }

        //Chat feature test
        [Test]
        [Obsolete]
        public void ChatFeatureTest()
        {
            test = extent.StartTest("Chat");
            Chat chatObj = new Chat(_driver);
            //chat send
            chatObj.ChatFeature();
            //Chat room search
            chatObj.ChatRoomSearch();

        }

        //Notification feature test
        [Test]
        [Obsolete]
        public void NotificationTest()
        {
            test = extent.StartTest("Notification");
            Notification notificationObj = new Notification(_driver);
            notificationObj.Notifications();

        }

        //Accept recieved request
        [Test]
        [Obsolete]
        public void AcceptReceivedRequest()
        {
            test = extent.StartTest("Accept request");
            ManageRequest manageRequestObj = new ManageRequest(_driver);
            manageRequestObj.AcceptReceivedRequest();  
        }

        //Accept recieved request
        [Test]
        [Obsolete]
        public void DeclineReceivedRequest()
        {
            test = extent.StartTest("Decline request");
            ManageRequest manageRequestObj = new ManageRequest(_driver);
            manageRequestObj.DeclineRequest();
        }


        //Withdraw sent request
        [Test]
        [Obsolete]
        public void WithdrawSentRequest()
        {
            test = extent.StartTest("Withdraw request");
            ManageRequest manageRequestObj = new ManageRequest(_driver);
            manageRequestObj.WithdrawRequest();
        }

        //Search Skill
        [Test]
        [Obsolete]
        public void searchSKill()
        {
            test = extent.StartTest("SearchSkill");
            SearchSkill searchSkillObj = new SearchSkill(_driver);
            
            searchSkillObj.SearchSkillsFilter();
           
        }
    }

}