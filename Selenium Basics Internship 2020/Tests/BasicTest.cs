using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Basics_Internship_2020.Tests
{
    class BasicTest
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

		[Test]
		public void UnsuccessfullLogIn()
		{
			driver.Navigate().GoToUrl("http://testing-ground.scraping.pro/login");

			driver.FindElement(By.Id("usr")).SendKeys("user");

			Thread.Sleep(2000);

			driver.FindElement(By.Id("pwd")).SendKeys("54321");

			Thread.Sleep(2000);

			driver.FindElement(By.CssSelector("[type='submit']")).Click();

			Thread.Sleep(2000);

			Assert.IsTrue(driver.FindElement(By.CssSelector("div#case_login > .error")).Displayed);
		}
	}
}
