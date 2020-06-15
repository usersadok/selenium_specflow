using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumSpecflow.Utils
{
	class DriverHandler
	{
		static IWebDriver driver = null;

		public static IWebDriver GetWebDriver(string browser)
        {
			switch (browser)
			{
				case "chrome":
					ChromeOptions options = new ChromeOptions();
					//The following option simulates the run on an iphone's resolution. If not required use 'start-maximized'
					options.AddArguments("--window-size=414,736");
					options.AddArguments("--disable-gpu");
                    driver = new ChromeDriver(options);
					break;

				case "firefox":
					driver = new FirefoxDriver();
					break;

				case "ie":
					driver = new InternetExplorerDriver();
					break;
				default:
					throw new InvalidOperationException($"{browser} browser is not supported");
			}
			return driver;
		}
	}
}
