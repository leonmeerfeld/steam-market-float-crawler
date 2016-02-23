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

            //string[] specLinks = new string[]
            //{ 
            //    "steam://rungame/730/76561202255233023/+csgo_econ_action_preview%20M720935946983328154A4273039631D2659516492517370764",
            //    "steam://rungame/730/76561202255233023/+csgo_econ_action_preview%20M787364041486792625A4272698866D9413234075445521288",
            //    "steam://rungame/730/76561202255233023/+csgo_econ_action_preview%20M719810047076134603A4271976243D16448450704125365574",
            //    "steam://rungame/730/76561202255233023/+csgo_econ_action_preview%20M720935946982894064A4209901121D9413234075445521288",
            //    "steam://rungame/730/76561202255233023/+csgo_econ_action_preview%20M720935946982894344A4209902094D16448450704125365574"
            //};

            Floats floats = new Floats();

            string[] floatArray = new string[specLinks.Count()];

            //for (int i = 0; i < nmbrPages * 10; i++)
            //{
            //    floatArray[i] = floats.checkFloat(driver, specLinks[i]);
            //}

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