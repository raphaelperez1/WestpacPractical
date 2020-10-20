using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace WestpacPractical.Stepdefinition
{
    [Binding]
    class SpecFlowFeatureSteps : BasePage
    {
        HomePage _homepage;
        KiwisaverCalculatorHomePage _kiwisaverhome;
        BasePage _basepage;

        [Given(@"I am at the Kiwisaver Calculator Homepage")]
        public void GivenImAtKiwisaverHomepage()
        {
            _homepage = new HomePage(driver);
            _kiwisaverhome = new KiwisaverCalculatorHomePage(driver);
            _homepage.GotoURL();
            _homepage.NavigatetoKiwisaver();
            _homepage.NavigatetoKiwiSaverCalulator();
            _kiwisaverhome.GetStartedKiwiSaver();
        }

        [Given(@"I enter current age as (.*)")]
        public void Entercurrentage(string p0)
        {
            _kiwisaverhome.EnterCurrentAge(p0);
        }

        [Given(@"I select employment status as (.*)")]
        public void Selectemploymentstatus(string p0)
        {
            _kiwisaverhome.SelectEmploymentStatus(p0);
        }
        [Given(@"I enter Salary as (.*)")]

        public void Entersalary(string p0)
        {
            _kiwisaverhome.EnterSalary(p0);
        }
        [Given(@"I choose member contribution as(.*)")]
        public void Choosemembercont(string p0)
        {
            _kiwisaverhome.ChooseMemberCont(p0);
        }
        [Given(@"I choose risk profile as(.*)")]

        public void Chooseriskprof(string p0)
        {
            _kiwisaverhome.Chooseriskprof(p0);
        }
        [When(@"I press the Kiwisaver retirement projection")]
        public void PressKiwisaverProj()
        {
            _kiwisaverhome.Presskiwisaverproj();
        }
        [Then(@"the projected balance is shown")]
        public void ThenKiwiSaverProjShown()
        {
            var isdisplayed =_kiwisaverhome.AssertKiwiSaverResult();
            Assert.IsTrue(isdisplayed);
            _basepage = new BasePage();
            _basepage.CloseBroser();
        }
    }
}
