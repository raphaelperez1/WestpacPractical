using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace WestpacPractical
{
    class BasePage
    {
        protected static OpenQA.Selenium.IWebDriver driver;
        protected string baseUrl;

        public BasePage()
        {
            if (driver == null)
            {
                switch (Settings1.Default.browser)
                {
                    case "Chrome":
                        driver = new ChromeDriver();
                        break;
                    case "Firefox":
                        driver = new FirefoxDriver();
                        break;
                    case "IE":
                        driver = new InternetExplorerDriver();
                        break;
                    default:
                        Console.WriteLine("Unknown browser, please check if browser is correct");
                        break;
                }
            }
            driver.Manage().Window.Maximize();
            baseUrl = Settings1.Default.baseURL;
        }
           
        public void CloseBroser()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
            driver = null;
        }

    }
}
