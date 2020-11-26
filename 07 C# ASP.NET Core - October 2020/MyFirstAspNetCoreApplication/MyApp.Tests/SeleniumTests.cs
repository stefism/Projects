using MyFirstAspNetCoreApplication;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyApp.Tests
{
    // Selenium.WebDriver 4.0.0-alpha07 (prerelease)
    public class SeleniumTests
    {
        [Fact]
        public void RemoveH1ElementFromPrivacyPage()
        {
            var serverFactory = new SeleniumServerFactory<Startup>();

            var options = new ChromeOptions();
            options.AddArguments("--headless"); //Да не виждаме браузъра.
            options.AcceptInsecureCertificates = true;

            var webDriver = new ChromeDriver(options);
            webDriver.Navigate().GoToUrl(serverFactory.RootUri + "/Home/Privacy");

            var element = webDriver.FindElementByTagName("h1");

            Assert.Throws<NoSuchElementException>(() => 
            webDriver.FindElementByTagName("h1"));
        }
    }
}
