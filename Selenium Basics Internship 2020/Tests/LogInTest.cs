using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Basics_Internship_2020
{
	class SearchTest
	{
		private ChromeDriver driver;
		private readonly string homepage = "http://testing-ground.scraping.pro/login";

		private readonly string correctUserName = "admin";
		private readonly string correctPassword = "12345";

		private readonly string wrongUserName = "user";
		private readonly string wrongPassword = "54321";


		[SetUp]
		public void SetUp()
		{
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
		}

		[TearDown]
		public void CloseDriver()
		{
			driver.Quit();
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
			NavigateToURL(homepage);

			LogInPage logInPage = new LogInPage(driver);

			logInPage.EnterUserName(correctUserName);
			logInPage.EnterPassword(correctPassword);

			logInPage.ClickOnLogInButton();

			Assert.IsTrue(logInPage.IsLogInSuccessfull());
		}

		[Test]
		public void LogInErrorMessageSuccessfullyDisplayed()
		{
			NavigateToURL(homepage);

			LogInPage logInPage = new LogInPage(driver);

			logInPage.EnterUserName(wrongUserName);
			logInPage.EnterPassword(wrongPassword);

			logInPage.ClickOnLogInButton();

			Assert.IsTrue(logInPage.IsLogInErrorDispalyed());
		}
	}
}
