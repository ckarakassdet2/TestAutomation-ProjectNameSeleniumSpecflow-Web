using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationQSightSeleniumSpecflowWeb
{
    public class SeleniumUtilities
    {
        public static void WaitCustom(int seconds)
        {
			try
			{
				Thread.Sleep(seconds * 1000); 
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message); 	
			}
        }

        public static void PauseExecution()
        {
            WaitCustom(1000); 
        }

		public static void ClickWithWait(IWebDriver driver, By by, int attempts)
		{
			int counter = 0;
			while (counter <= attempts)
			{
				try
				{
					driver.FindElement(by).Click();
					break; 
				}
				catch (Exception exc)
				{
					Console.WriteLine(exc.Message);
					Console.WriteLine("Attemped: " + ++counter);
					WaitCustom(1); 
				}
			}
		}

        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static string GetTextFromDropdownList(IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }

        public static void EnterText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        public static void Click(IWebElement element)
        {
            element.Click();
        }

        public static void SelectFromDropdown(IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }


    }
}
