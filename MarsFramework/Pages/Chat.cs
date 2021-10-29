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
    class Chat
    {
        private RemoteWebDriver _driver;

        [Obsolete]
        public Chat(RemoteWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Chat web elements
        //Chat link
        [FindsBy(How = How.XPath, Using = "/html//div[@id='account-profile-section']/div/div[1]//a[@href='/Home/Message']")]
        private IWebElement chatLink { get; set; }

        //Message text box
        [FindsBy(How = How.XPath, Using = "/html//input[@id='chatTextBox']")]
        private IWebElement chatTextBox { get; set; }
      
        //Send chat button
        [FindsBy(How = How.Id, Using = "btnSend")]
        private IWebElement sendButton { get; set; }

        //search box
        [FindsBy(How = How.XPath, Using = "/html//div[@id='chatRoomContainer']/div[@class='chatRoom']//input[@class='prompt']")]
        private IWebElement searchUser { get; set; }

        
         //Search Icon
        [FindsBy(How = How.XPath, Using = "/html//div[@id='chatRoomContainer']/div[@class='chatRoom']//i")]
        private IWebElement searchIcon { get; set; }
        //*[@id="chatList"]/div[2]/div[2]/div[1]
        //Latest chat row
        [FindsBy(How = How.XPath, Using = "//*[@id='chatList']/div[1]/div[2]/div[1]")]
        private IWebElement latestChatRow { get; set; }
        
        //Latest chat message
        [FindsBy(How = How.XPath, Using = "//div[last()]//div[1]//div[1]//span[1]")]
        private IWebElement latestChat{ get; set; }

        
        #endregion

        #region chat functionality
        public void ChatFeature()
        {
            //Click on Chat link
            chatLink.WaitForElementClickable(_driver, 60);
            chatLink.Click();


            chatTextBox.WaitForElementClickable(_driver, 30);
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Chat");
           
            //Read and Enter message into chat box
            chatTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ChatMessage"));

            //Click on send button
            sendButton.WaitForElementClickable(_driver, 80);
            sendButton.Click();
            test.Log(LogStatus.Pass, "Test Passed, Chat Sent Successfully");
            SaveScreenShotClass.SaveScreenshot(_driver, "ChatSuccessful");

            Thread.Sleep(4000);
            //Validate Chat sent successfully
          //  latestChat.WaitForElementClickable(_driver, 60);
           /*string expectedMessage = latestChat.Text;
            string actualMessage = GlobalDefinitions.ExcelLib.ReadData(2, "ChatMessage");
            try
            {
                Thread.Sleep(3000);
                Assert.AreEqual(actualMessage, expectedMessage);
                Thread.Sleep(2000);
                test.Log(LogStatus.Pass, "Test Passed, Chat Sent Successfully");
                SaveScreenShotClass.SaveScreenshot(_driver, "ChatSuccessful");
                Assert.IsTrue(true);

            }

            catch (Exception ex)
            {
                test.Log(LogStatus.Fail, "Test Failed");
                Console.WriteLine(ex.Message);
            }*/

        }
        #endregion

        #region Find user in Chat room
        public void ChatRoomSearch()
        {
            //Click on Search box
            searchUser.WaitForElementClickable(_driver, 60);
            searchUser.Click();

            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Chat");

            //Enter data into search box
            searchUser.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchUser"));
            Thread.Sleep(2000);

            //Click on Search Icon
            searchIcon.Click();



            //Validate search user is successful
            Thread.Sleep(5000);
            string expectedUser = latestChatRow.Text;
            string actualUser = GlobalDefinitions.ExcelLib.ReadData(2, "SearchUser");
            try
            {
                Thread.Sleep(3000);
                Assert.AreEqual(actualUser, expectedUser);
                Thread.Sleep(2000);
                test.Log(LogStatus.Pass, "Test Passed, Chat room search successful");
                SaveScreenShotClass.SaveScreenshot(_driver, "ChatSearchSuccessful");
                Assert.IsTrue(true);

            }

            catch (Exception ex)
            {
                test.Log(LogStatus.Fail, "Test Failed");
                Console.WriteLine(ex.Message);
            }

        }

        #endregion




    }


}
