using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumSpecflow.PagesHandler
{
    class HomePage
    {
		private IWebDriver _driver;

		private IWebElement SearchBarInput => _driver.FindElement(By.Id("search_query_top"));
		private IWebElement SearchButton => _driver.FindElement(By.CssSelector(".btn.btn-default.button-search"));
		private IWebElement ResultsCounterMessage => _driver.FindElement(By.ClassName("heading-counter"));
		private IWebElement AlertWarningMessage => _driver.FindElement(By.CssSelector(".alert.alert-warning"));


		public HomePage(IWebDriver driver) => _driver = driver;

		public void InputItemToSearch(string item)
		{
			SearchBarInput.Clear();
			SearchBarInput.SendKeys(item);
		}

		public void ClickOnSearchButton()
		{
			SearchButton.Click();
		}

		public String GetResultsCounterMessage()
		{
			return ResultsCounterMessage.Text;
		}

		public Boolean IsAlertWarningDisplayed()
		{
			return AlertWarningMessage.Displayed;
		}

		public String GetAlertWarningText()
		{
			return AlertWarningMessage.Text;
		}
	}
}
