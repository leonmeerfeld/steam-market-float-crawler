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
    class MarketInteraction
    {
        public void nextPage(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("span[id='searchResults_btn_next']")).Click();
            System.Threading.Thread.Sleep(2000);
        }

        string[] specLinks = new string[100];
        int j = 0;

        public string[] getSpecLink(IWebDriver driver, int nmbrPages)
        {
            var arrows = driver.FindElements(By.ClassName("market_actionmenu_button"));

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;

            string jscript_enable = "";
            string jscript_disable = "";

            

            for (int i = 0; i < 10; i++ )
            {
                //Enables the little arrow element so it is visible and clickable
                jscript_enable =   "document.getElementsByClassName('market_actionmenu_button')[" + 
                            Convert.ToString(i) + 
                            "].style.display='block';";
                js.ExecuteScript(jscript_enable);

                arrows[i].Click();

                specLinks[j] = driver.FindElement(By.CssSelector("a[class='popup_menu_item']")).GetAttribute("href");
                j++;

                //Disables the little arrow element so there is only one visable
                jscript_disable = "document.getElementsByClassName('market_actionmenu_button')[" +
                            Convert.ToString(i) +
                            "].style.display='none';";
                js.ExecuteScript(jscript_disable);
            }
            return specLinks;
        }
    }
}
