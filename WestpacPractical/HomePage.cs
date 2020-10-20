using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.IO.MemoryMappedFiles;
using SeleniumExtras.WaitHelpers;

namespace WestpacPractical
{
    class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;

        }
        public void GotoURL()
        {
            try
            {
                driver.Navigate().GoToUrl(Settings1.Default.baseURL);
                driver.Manage().Window.Maximize();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
               
        public void NavigatetoKiwisaver()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("ubermenu-section-link-kiwisaver-ps")));
            driver.FindElement(By.Id("ubermenu-section-link-kiwisaver-ps")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        public void NavigatetoKiwiSaverCalulator()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("ubermenu-item-cta-kiwisaver-calculators-ps")));
            driver.FindElement(By.XPath("//*[@id='ubermenu-item-cta-kiwisaver-calculators-ps']")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='content-ps']/div[2]/div/section/p[4]/a")));
        }
    }
}
