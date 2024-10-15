using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
namespace SeleniumTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Initialize the Chrome driver
            IWebDriver driver = new ChromeDriver();
            Console.WriteLine("Navigating to Sauce Demo site...");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();

            // Create an instance of the LoginPage
            LoginSection loginPage = new LoginSection(driver);

            // Use the login method
            try
            {
                Console.WriteLine("Attempting to log in...");
                loginPage.Login("standard_user", "secret_sauce");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Verify successful login
            string currentUrl = driver.Url;
            if (currentUrl == "https://www.saucedemo.com/inventory.html")
            {
                Console.WriteLine($"Login successful. Current URL: {currentUrl}");
            }
            else
            {
                Console.WriteLine("Login failed.");
            }


            driver.Quit();
        }

    }
}