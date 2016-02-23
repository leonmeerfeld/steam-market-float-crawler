using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;


namespace MarketCrawler
{
    class GotoURL
    {
        public void gotoURL(IWebDriver driver, string URL)
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
        }
    }
}
