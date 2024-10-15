using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTest
{
    internal class LoginSection
    {
            private readonly IWebDriver _driver;
            private readonly WebDriverWait _wait;

            public LoginSection(IWebDriver driver)
            {
                _driver = driver;
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            }

            // Using XPath to locate elements
            public IWebElement UsernameField => _wait.Until(d => d.FindElement(By.XPath("//input[@id='user-name']")));
            public IWebElement PasswordField => _wait.Until(d => d.FindElement(By.XPath("//input[@id='password']")));
            public IWebElement LoginButton => _wait.Until(d => d.FindElement(By.XPath("//input[@id='login-button']")));

            public void EnterUserName(string userName)
            {
                UsernameField.SendKeys(userName); // Using XPath
            }

            public void EnterPassword(string password)
            {
                PasswordField.SendKeys(password);
            }

            public void ClickLoginButton()
            {
                LoginButton.Click();
            }

            public void Login(string username, string password)
            {
                EnterUserName(username);
                EnterPassword(password);
                ClickLoginButton();
            }
        }
 }
