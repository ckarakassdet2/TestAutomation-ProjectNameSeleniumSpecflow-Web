using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationQSightSeleniumSpecflowWeb
{
    public class Driver 
    {
        private static WebDriver driver;
        private static string browserType; 

        private Driver() 
        {
           
        }
        public static WebDriver getDriver(string browserType)
        {
            browserType = ExtractedValue.GetExtractedValue("browserType");
            if (driver == null)
            {
                browserType = browserType == null ? ExtractedValue.GetExtractedValue("browserType") : browserType;

                switch (browserType)
                {
                    case "chrome":
                        ChromeOptions chromeOption = new ChromeOptions();
                        chromeOption.AddArgument("start-maximized");
                        chromeOption.AddArgument("--disable-gpu");
                        chromeOption.AddArgument("--disable-notifications");
                        driver = new ChromeDriver(DriverUtility.GetDriverExe("chromedriver"),chromeOption);
                        break;

                    case "chromeHeadless":
                        ChromeOptions chromeOptionHeadless = new ChromeOptions();
                        chromeOptionHeadless.AddArgument("--headless");
                        driver = new ChromeDriver(chromeOptionHeadless);
                        break;

                    case "edge":
                        EdgeOptions edgeOption = new EdgeOptions();
                        edgeOption.AddArgument("start-maximized");
                        edgeOption.AddArgument("--disable-gpu");
                        edgeOption.AddArgument("--disable-notifications"); 
                        driver = new EdgeDriver(DriverUtility.GetDriverExe("msedgedriver"), edgeOption);
                        break;

                    case "edgeHeadless":
                        EdgeOptions edgeOptionHeadless = new EdgeOptions();
                        edgeOptionHeadless.AddArgument("--headless");
                        driver = new EdgeDriver(edgeOptionHeadless);
                        break;
                }              
            }
            return driver;
        }
        public static WebDriver getDriver()
        {
            return getDriver(null); 
        }
        public static void closeDriver()
        { 
            if(driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }        
    }
}
