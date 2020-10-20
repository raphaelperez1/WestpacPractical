using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Constraints;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace WestpacPractical
{
    class KiwisaverCalculatorHomePage
    {
        private IWebDriver driver;
        public KiwisaverCalculatorHomePage(IWebDriver driver)
        {
            this.driver = driver;

        }
        public void GetStartedKiwiSaver()
        {
            driver.FindElement(By.XPath("//*[@id='content-ps']/div[2]/div/section/p[4]/a")).Click();
        }

        public void CheckCurrentAgeHelpinfo()

        { 
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='content-inner-header']")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.SwitchTo().Frame(0);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@help-id='CurrentAge']//input")));
            driver.FindElement(By.XPath("//div[@help-id='CurrentAge']/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='field-message message-info ng-binding']")));
            string agelimittext = driver.FindElement(By.XPath("//div[@class='field-message message-info ng-binding']")).Text;
            
            for (int second = 0 ; ;second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("This calculator has an age limit of 18 to 64 years old." == agelimittext)
                    {
                        Console.WriteLine("Test Passed");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Test Failed");
                        break;
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("Exception Ocurred", e.Message);
                }
                Thread.Sleep(1000);
            }

        }

        public void EnterCurrentAge(string currentage)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 60));
           wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='content-inner-header']")));
            driver.SwitchTo().Frame(0);
            Thread.Sleep(5000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@help-id='CurrentAge']//input")));
            //driver.FindElement(By.XPath("//div[@help-id='CurrentAge']//input")).Click();
            driver.FindElement(By.XPath("//div[@help-id='CurrentAge']//input")).SendKeys(currentage);
        }
        public void SelectEmploymentStatus(string employmentstatus)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='well-value ng-binding']/span[@class='ng-scope']")));
            driver.FindElement(By.XPath("//div[@class='well-value ng-binding']/span[@class='ng-scope']")).Click();
            
            employmentstatus = employmentstatus.Trim();
            driver.FindElement(By.XPath("//li/div/span[@class='ng-scope' and text()='"+ employmentstatus + "']")).Click();
               
        }
        public void EnterSalary(string salary)
        {
            driver.FindElement(By.XPath("//div[@help-id='AnnualIncome']//input")).Click();
            driver.FindElement(By.XPath("//div[@help-id='AnnualIncome']//input")).SendKeys(salary);
        }
        public void ChooseMemberCont(string membercont)
        {
            membercont = membercont.Trim(); 
            driver.FindElement(By.XPath("//div//span[@class='ng-scope' and text() ='"+ membercont + "']")).Click();

        }

        public void Chooseriskprof(string riskprof)
        {
            riskprof = riskprof.Trim();
            driver.FindElement(By.XPath("//div//span[@class='ng-scope' and text() ='"+ riskprof + "']")).Click();
        }
        
        public void Presskiwisaverproj()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div//span[@class='label' and text()='View your KiwiSaver retirement projections']")));
            driver.FindElement(By.XPath("//div//span[@class='label' and text()='View your KiwiSaver retirement projections']")).Click();   
        }
        public bool AssertKiwiSaverResult()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='highcharts-container']")));
            //Boolean resultdisplayed = driver.FindElement(By.XPath("//div[@help-id='Results']//button")).isDisplayed();
            var elements = driver.FindElements(By.XPath("//div[@class='highcharts-container']"));
            if (elements.Count > 0)
                return true;
            else
                return false;
                           
        }
        public void Populatekiwisaverbalance(string kiwisaverbal)
        {
            driver.FindElement(By.XPath("//div[@help-id='KiwiSaverBalance']//input")).Click();
            driver.FindElement(By.XPath("//div[@help-id='KiwiSaverBalance']//input")).SendKeys(kiwisaverbal);
        }
        public void Populatecontrib(string currentcontribution)
        {
            driver.FindElement(By.XPath("//div[@help-id='VoluntaryContributions']//input")).Click();
            driver.FindElement(By.XPath("//div[@help-id='VoluntaryContributions']//input")).SendKeys(currentcontribution);

        }
        public void Selectfrequency(string frequency)
        {
            frequency = frequency.Trim();
            driver.FindElement(By.XPath("//div[@class='well-value ng-binding']/span[@class='ng-binding ng-scope']")).Click();
            driver.FindElement(By.XPath("//div//span[@class='ng-binding ng-scope' and text() ='" + frequency + "']")).Click();
        }
        public void Populatesavingsgoal(string savingsgoal)
        {
            driver.FindElement(By.XPath("//div[@help-id='SavingsGoal']//input")).Click();
            driver.FindElement(By.XPath("//div[@help-id='SavingsGoal']//input")).SendKeys(savingsgoal);

        }

    }
    
}
