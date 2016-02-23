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
    class Floats
    {
        public string checkFloat(IWebDriver driver, string specLink)
        {
            var specLinkInput = driver.FindElement(By.CssSelector("input[id='link']"));
            if( ! String.IsNullOrEmpty(specLink))
            {
                specLinkInput.SendKeys(specLink);
            }

            var checkButton = driver.FindElement(By.CssSelector("button[class='ui fluid large button']"));
            checkButton.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(6));

            IWebElement floatElement;

            try
            { 
                var floatDiv = driver.FindElement(By.CssSelector("div[class='preview k_wear_float']"));
                floatElement = floatDiv.FindElement(By.CssSelector("input[onclick='this.select()']"));
            }
            catch
            {
                return "ERROR";
            }
            return floatElement.GetAttribute("value");
        }
    }
}
