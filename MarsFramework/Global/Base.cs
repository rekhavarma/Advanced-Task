
using RelevantCodes.ExtentReports;
using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using static MarsFramework.Global.GlobalDefinitions;
using OpenQA.Selenium.Remote;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace MarsFramework.Global
{
    
        public enum BrowserType
        {
            Firefox,
            Chrome
        }
        [TestFixture]
        public class Base
        {
        private BrowserType _BrowserType;
        public static RemoteWebDriver _driver;
        public Base(BrowserType browser, RemoteWebDriver driver )
        {
            _BrowserType = browser;
            _driver = driver;

        }
        //Initialise the browser
        //public static RemoteWebDriver driver { get; set; }
       

        public static void Wait(int time)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }

        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string Url = "http://localhost:5000";
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;

        public string ReportXMLPath { get; private set; }

        #endregion



        #region setup and tear down
        [SetUp]
        [Obsolete]
        public void Inititalize()
        {

            ChooseBrowser(_BrowserType);
           

            void ChooseBrowser(BrowserType browserType)
            {
                if (browserType == BrowserType.Firefox)
                {
                    _driver = new FirefoxDriver();
                }
                else if (browserType == BrowserType.Chrome)
                {
                    _driver = new ChromeDriver();
                }

            }

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(ReportXMLPath);

            #endregion

            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn(_driver);
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp(_driver);
                obj.register();
            }

        }


        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                
                String img = SaveScreenShotClass.SaveScreenshot(_driver, "Report");
                test.Log(LogStatus.Error, "Image example: " + test.AddScreenCapture(img));
            }
            else
            {
                String img = SaveScreenShotClass.SaveScreenshot(_driver, "Report");
                test.Log(LogStatus.Pass, "Image example: " + test.AddScreenCapture(img));
            }

            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :)            
            _driver.Close();
        }
    }
        #endregion

   
}