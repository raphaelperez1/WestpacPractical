using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace WestpacPractical
{
    class Class1 : BasePage
    {
        BasePage _basepage;
        HomePage _homepage;
        KiwisaverCalculatorHomePage _kiwisaverhome;
        [Test]
    public void KiwiSaver()
        {
            _homepage = new HomePage(driver);
            _kiwisaverhome = new KiwisaverCalculatorHomePage(driver);
            _homepage.GotoURL();
            _homepage.NavigatetoKiwisaver();
            _homepage.NavigatetoKiwiSaverCalulator();
            _kiwisaverhome.GetStartedKiwiSaver();
            _kiwisaverhome.CheckCurrentAgeHelpinfo();

        }

    [TearDown]
    public void Teardown()
        {
            _basepage = new BasePage();
            _basepage.CloseBroser();
        }
    }
}
