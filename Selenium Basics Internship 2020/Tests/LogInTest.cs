using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Basics_Internship_2020
{
	public class LogInTest
	{
		private ChromeDriver driver;

		[SetUp]
		public void SetUp()
		{
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
		}

		[TearDown]
		public void CloseDriver()
		{
			driver.Dispose();
		}

		public void NavigateToURL(string url)
		{
			driver.Url = url;
		}

		public IWebDriver GetDriver
		{
			get { return driver; }
		}

		[Test]
		public void LogInSuccessfully()
		{
			LogInPage logInPage = new LogInPage(driver);

			NavigateToURL(logInPage.homepage);

			logInPage.EnterUserName(logInPage.correctUserName);
			logInPage.EnterPassword(logInPage.correctPassword);

			logInPage.ClickOnLogInButton();

			Assert.IsTrue(logInPage.IsLogInSuccessfull());
		}

		[Test]
		public void LogInErrorMessageSuccessfullyDisplayed()
		{
			LogInPage logInPage = new LogInPage(driver);

			NavigateToURL(logInPage.homepage);

			logInPage.EnterUserName(logInPage.wrongUserName);
			logInPage.EnterPassword(logInPage.wrongPassword);

			logInPage.ClickOnLogInButton();

			Assert.IsTrue(logInPage.IsLogInErrorDispalyed());
		}
	}
}
