using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumUITests
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        // TU01
        [Test]
        public void ÏnvalidRequestedUnits()
        {
            IWebElement textBox;
            IWebElement searchButton;
            IWebElement totalCost;

            // Arrange
            string URL = "https://localhost:44359/";
            driver.Manage().Window.Maximize();
            driver.Url = URL;

            //Act
            Thread.Sleep(2000);
            textBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-table-container > table > tbody > tr:nth-child(1) > td:nth-child(3) > div > div > div > input"));
            textBox.SendKeys("15");
            searchButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-toolbar.mud-toolbar-gutters.mud-table-toolbar > div.mud-input-control.mud-input-input-control.mt-0 > div > div > input"));
            searchButton.Click();
            Thread.Sleep(2000);
            totalCost = driver.FindElement(By.CssSelector("#banner > div > div > h6"));
            //Assert
            Thread.Sleep(2000);
            string expectedCost = "Costo total: ₡ 5.000,00";
            Assert.IsTrue(totalCost.Text.Equals(expectedCost));
        }

        // TU02
        [Test]
        public void SearchProduct()
        {
            IWebElement searchButton;
            IWebElement auxButton;
            IWebElement table;

            // Arrange
            string URL = "https://localhost:44359/";
            driver.Manage().Window.Maximize();
            driver.Url = URL;

            //Act
            Thread.Sleep(2000);
            searchButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-toolbar.mud-toolbar-gutters.mud-table-toolbar > div.mud-input-control.mud-input-input-control.mt-0 > div > div > input"));
            searchButton.SendKeys("pepsi");
            auxButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-table-pagination > ul > li.mud-pagination-item.mud-pagination-item-selected > button > span"));
            auxButton.Click();
            Thread.Sleep(2000);

            table = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-table-container > table > tbody > tr > td:nth-child(1)"));
            //Assert
            Assert.IsTrue(table.Text.Equals("Pepsi"));
        }

        // TU03
        [Test]
        public void CancelPurchase()
        {
            IWebElement textBox;
            IWebElement searchButton;
            IWebElement totalCost;
            IWebElement buyButton;
            IWebElement cancelButton;

            // Arrange
            string URL = "https://localhost:44359/";
            driver.Manage().Window.Maximize();
            driver.Url = URL;

            //Act
            Thread.Sleep(2000);
            textBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-table-container > table > tbody > tr:nth-child(1) > td:nth-child(3) > div > div > div > input"));
            textBox.SendKeys("4");
            searchButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-toolbar.mud-toolbar-gutters.mud-table-toolbar > div.mud-input-control.mud-input-input-control.mt-0 > div > div > input"));
            searchButton.Click();
            Thread.Sleep(2000);
            buyButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-toolbar.mud-toolbar-gutters.mud-table-toolbar > button > span"));
            buyButton.Click();
            Thread.Sleep(2000);
                
            cancelButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-overlay-content > div > div > div.mud-toolbar.mud-toolbar-gutters.mud-table-toolbar > button.mud-button-root.mud-button.mud-button-filled.mud-button-filled-transparent.mud-button-filled-size-small.mud-ripple > span"));
            cancelButton.Click();
            Thread.Sleep(2000);


            //Assert
            Thread.Sleep(2000);
            totalCost = driver.FindElement(By.CssSelector("#banner > div > div > h6"));
            string expectedCost = "Costo total: ₡ 2.000,00";
            Assert.IsTrue(totalCost.Text.Equals(expectedCost));
        }
    }
}