using System;
using TechTalk.SpecFlow.Assist;
using System.Configuration;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestAutomationQSightSeleniumSpecflowWeb
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly Driver driver;
        private readonly LoginPage loginPage;
        public LoginStepDefinitions(Driver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(this.driver);
        }

        [Given(@"I navigate to QSight application")]
        public void GivenINavigateToQSightApplication()
        {
            ExcelUtility.readExcelDataFileName("DataFile", "Sheet1");
            Driver.getDriver().Manage().Window.Maximize();
            Driver.getDriver().Navigate().GoToUrl(ExtractedValue.GetExtractedValue("baseUrl_Stage"));
            Thread.Sleep(1000);
        }

        [Given(@"I enter valid username password  and click on login")]
        public void GivenIEnterValidUsernamePasswordAndClickOnLogin(Table table)
        {
            dynamic data = table.CreateDynamicInstance(false);
            string password = SymmetricDecryptor.DecryptToString(data.password);
            loginPage.Login(data.username, password);
            Thread.Sleep(1000);
        }

        [Then(@"I select department")]
        public void ThenISelectDepartment()
        {
            SeleniumUtilities.SelectFromDropdown(Driver.getDriver().FindElement(By.Id("uID")), "General Hosp QA - Catheterization Lab");
        }

        [Then(@"I click on Continue button")]
        public void ThenIClickOnContinueButton()
        {
            loginPage.ClickOnContinue();
        }

        [Then(@"I verify landing page Add Product to Hospital Inventory")]
        public void ThenIVerifyLandingPageAddProductToHospitalInventory()
        {
            string headerInventoryAdd = loginPage.GetHeaderText(); //Driver.getDriver().FindElement(By.XPath("//*[@id=\"page-wrapper\"]/div/div[1]/h1")).Text;
            Console.WriteLine("*** headerInventoryAdd: " + headerInventoryAdd);
            Assert.True(headerInventoryAdd.Contains("Add Product to Hospital Inventory"));
        }

        [Then(@"I click on logout link")]
        public void ThenIClickOnLogoutLink()
        {
            Driver.getDriver().FindElement(By.XPath("(//*[@id=\"navbar\"]//a[@href='/Base/LogOut'])[1]")).Click();
        }

        [When(@"I click on logout link")]
        public void WhenIClickOnLogoutLink()
        {
            Driver.getDriver().FindElement(By.XPath("(//*[@id=\"navbar\"]//a[@href='/Base/LogOut'])[1]")).Click();
        }

        [Then(@"I verify I am logged out")]
        public void ThenIVerifyIAmLoggedOut()
        {
            Assert.True(Driver.getDriver().FindElement(By.Id("btnSubmit")).Displayed);
            string currentUrl = Driver.getDriver().Url;
            Console.WriteLine("currentUrl: " + currentUrl);
            Assert.True(currentUrl.Contains("login")); 
            Driver.closeDriver(); 
        }
    }
}
