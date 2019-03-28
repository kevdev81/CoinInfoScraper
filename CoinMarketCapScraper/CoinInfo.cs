using System;
using System.Collections.Generic;
using System.Text;

namespace CoinMarketCapScraper
{
    public class CoinInfo
    {
        public string Name { get; set; }
        public string MarketCap { get; set; }
        public string Price { get; set; }
        public string Volume { get; set; }
        public string CirculatingSupply { get; set; }
        public string Change { get; set; }
    }
}
