using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium_Basics_Internship_2020
{
	class LogInPage
	{
		public string homepage = "http://testing-ground.scraping.pro/login";

		public readonly string correctUserName = "admin";
		public readonly string correctPassword = "12345";

		public readonly string wrongUserName = "user";
		public readonly string wrongPassword = "54321";

		private IWebDriver driver;

		readonly By userNameField = By.Id("usr");
		readonly By passwordField= By.Id("pwd");
		readonly By logInButton = By.CssSelector("[type='submit']");
		readonly By welcomeMessage = By.CssSelector("div#case_login > .success");
		readonly By errorMessage = By.CssSelector("div#case_login > .error");

		public LogInPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void EnterUserName(string userName)
		{
			driver.FindElement(userNameField).Clear();
			driver.FindElement(userNameField).SendKeys(userName);
		}

		public void EnterPassword(string password)
		{
			driver.FindElement(passwordField).Clear();
			driver.FindElement(passwordField).SendKeys(password);
		}

		public void ClickOnLogInButton()
		{
			driver.FindElement(logInButton).Click();
		}

		public bool IsLogInSuccessfull()
		{
			return driver.FindElement(welcomeMessage).Displayed;
		}

		public bool IsLogInErrorDispalyed()
		{
			return driver.FindElement(errorMessage).Displayed;
		}
	}
}
