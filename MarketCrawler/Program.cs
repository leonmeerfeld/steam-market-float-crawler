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
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the listening page link from market:");
            string listeningPage = Console.ReadLine();
            Console.Write("Enter the number of pages to be scanned:");
            int nmbrPages = 0;

            try
            {
                nmbrPages = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Environment.Exit(0);
            }

            IWebDriver driver = new FirefoxDriver();
            GotoURL URL = new GotoURL();

            MarketInteraction MI = new MarketInteraction();

            //Goes to the steam market listing page
            URL.gotoURL(driver, listeningPage);

            string[] specLinks = new string[] { };

            for (int page = 1; page <= nmbrPages; page++)
            {
                //Stores the specatate links in this array:
                specLinks = MI.getSpecLink(driver, nmbrPages);

                //Goes to the next market page
                MI.nextPage(driver);
            }

            //Goes to glws.org to check float values
            URL.gotoURL(driver, "https://glws.org");

            Floats floats = new Floats();

            string[] floatArray = new string[specLinks.Count()];

            //Output in Console
            Console.WriteLine("Floatvalues:");
            Console.WriteLine("-----------------------------------------------");

            for (int j = 0; j < nmbrPages * 10; j++)
            {
                if(j % 10 == 0)
                {
                    Console.WriteLine("Page {0}", (j / 10) + 1);
                }

                Console.WriteLine(Convert.ToString(j + 1) + ": \t" + floats.checkFloat(driver, specLinks[j]));
            }
            Console.WriteLine("-----------------------------------------------");
            Console.ReadKey();
            driver.Close();
        }
    }
}