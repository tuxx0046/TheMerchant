using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Classes
{
    public class Item
    {
        public string Name { get; set; }
        private int defaultPrice;
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        
        public Item(string name, int price)
        {
            this.Name = name;
            this.BuyPrice = price;
            this.SellPrice = BuyPrice + 2;
            this.defaultPrice = price;
        }

        public void ResetPrice()
        {
            BuyPrice = defaultPrice;
            SellPrice = defaultPrice + 2;
        }
    }
}
