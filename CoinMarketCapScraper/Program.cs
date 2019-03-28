using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CoinMarketCapScraper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var results = new List<CoinInfo>();

            // 1. Download the HTML for the page.
            // https://coinmarketcap.com/

            var webClient = new WebClient();
            var html = webClient.DownloadString("https://coinmarketcap.com/");

            // 2. Use CSS selectors to find the table.

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var table = document.QuerySelector(".table");
            
            // 3. Loop over every row and create an object for each row.
            //    (  Name, Market Cap, Volume, Circulating Supply, Change%  )

            var rows = table.QuerySelectorAll("tr").Skip(1);

            foreach (var row in rows)
            {
                var coinInfo = new CoinInfo();
                // coinInfo.Name = row.QuerySelectorAll("td").Skip(1).First().TextContent;
                coinInfo.Name = row.QuerySelector("td:nth-child(2)").TextContent;
                coinInfo.MarketCap = row.QuerySelector("td:nth-child(3)").TextContent;
                coinInfo.Price = row.QuerySelector("td:nth-child(4)").TextContent;
                coinInfo.Volume = row.QuerySelector("td:nth-child(5)").TextContent;
                coinInfo.CirculatingSupply = row.QuerySelector("td:nth-child(6)").TextContent;
                coinInfo.Change = row.QuerySelector("td:nth-child(7)").TextContent;

                results.Add(coinInfo);
            }
                   
            // 4. Print out the results

            foreach (var coinInfo in results)
            {
                Console.WriteLine
                    ($"Name={coinInfo.Name}, " +
                    $"MarketCap={coinInfo.MarketCap}, " +
                    $"Price={coinInfo.Price}, " +
                    $"Volume={coinInfo.Volume}, " +
                    $"CirculatingSupply={coinInfo.CirculatingSupply}, " +
                    $"Change={coinInfo.Change}");
            }
        }
    }
}