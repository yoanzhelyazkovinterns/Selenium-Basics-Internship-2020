using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Selenium_Basics_Internship_2020.StepBindings
{
    [Binding]
    public class LogInSteps : IDisposable
    {
        private ChromeDriver driver = new ChromeDriver();

        [Given(@"I open Web Scraper Testing Ground website")]
        public void GivenIOpenWebScraperTestingGroundWebsite()
        {
            LogInPage logInPage = new LogInPage(driver);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(logInPage.homepage);
        }

        [When(@"I enter username ""(.*)""")]
        public void WhenIEnterUsername(string username)
        {
            LogInPage logInPage = new LogInPage(driver);
            logInPage.EnterUserName(username);
        }

        [When(@"I enter password ""(.*)""")]
        public void WhenIEnterPassword(string password)
        {
            LogInPage logInPage = new LogInPage(driver);
            logInPage.EnterPassword(password);
        }

        [When(@"I click on the LogIn button")]
        public void WhenIClickOnTheLogInButton()
        {
            LogInPage logInPage = new LogInPage(driver);
            logInPage.ClickOnLogInButton();
        }

        [Then(@"I should see Greeting message")]
        public void ThenIShouldSeeGreetingMessage()
        {
            LogInPage logInPage = new LogInPage(driver);
            Assert.IsTrue(logInPage.IsLogInSuccessfull());
        }

        [Then(@"I should see Error message displayed")]
        public void ThenIShouldSeeErrorMessageDisplayed()
        {
            LogInPage logInPage = new LogInPage(driver);
            Assert.IsTrue(logInPage.IsLogInErrorDispalyed());
        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }
    }
}