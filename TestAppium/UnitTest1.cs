using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;


namespace TestAppium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            AndroidDriver<AndroidElement> driver;
            AppiumOptions options = new AppiumOptions();
            options.PlatformName = "Android";
            options.AddAdditionalCapability("deviceName", "34012a3ff30a16af");
            options.AddAdditionalCapability("platformVersion", "10.0");
            //options.AddAdditionalCapability("app", "D:\\Downloads\\Development-dotnettest5.apk");
            options.AddAdditionalCapability("appPackage", "com.LokumGames.ZulaMobile");
            options.AddAdditionalCapability("appActivity", "com.google.firebase.MessagingUnityPlayerActivity t28043");
            options.AddAdditionalCapability("skipDeviceInitialization", true);
            options.AddAdditionalCapability("skipServerInstallation", true);
            options.AddAdditionalCapability("noReset", true);

            Uri url = new Uri("http://127.0.0.1:4723/wd/hub");

            driver = new AndroidDriver<AndroidElement>(url, options);
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(80));

            var image = GetRefImage("FirstDayReward");

            var element = driver.FindElementByImage(image);

            wait.Until(i => element.Displayed);
            
            element.Click();
        }

        protected string GetRefImage(string refImgName)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"/Images/");
            var file = Directory.GetFiles("D:/Images/", "*.jpg")
                .Select(Path.GetFileName).Where(p => p == refImgName).ToString();
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(file);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}