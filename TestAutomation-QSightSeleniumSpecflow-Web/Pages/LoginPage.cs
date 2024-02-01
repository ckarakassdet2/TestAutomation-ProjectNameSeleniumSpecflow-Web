using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationQSightSeleniumSpecflowWeb
{
    public class LoginPage
    {
        private Driver _driver; 
        public LoginPage(Driver driver) => _driver = driver;
        private IWebElement txtUsername => Driver.getDriver().FindElement(By.Id("UserName"));
        private IWebElement txtPassword => Driver.getDriver().FindElement(By.Id("Password"));
        private IWebElement btnLogin => Driver.getDriver().FindElement(By.Id("btnSubmit"));
        private IWebElement btnContinue => Driver.getDriver().FindElement(By.XPath("//*[@id='frmMultiDepartment']/div[2]/button"));
        private IWebElement headerInventoryAdd => Driver.getDriver().FindElement(By.XPath("//*[@id=\"page-wrapper\"]/div/div[1]/h1")); 


        // METHODS 
        public void Login(string username, string password)
        {
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
            btnLogin.Click();
        }

        public void ClickOnContinue()
        { 
            btnContinue.Click();
        }

        public string GetHeaderText() => headerInventoryAdd.Text; 
        



    }
}
