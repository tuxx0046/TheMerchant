using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TheMerchant.Classes;

namespace TheMerchant.Classes.Abstract
{
    public abstract class Trader : ITrader
    {
        private string name;
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        public Trader(string name = "Trader")
        {
            this.name = name;
        }


        private List<Item> inventory = new List<Item>();
        public virtual List<Item> Inventory { get { return inventory; } set { inventory = value; } }

        public void BuyItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void SellItem(Item item)
        {
            Inventory.Remove(item);
        }
    }
}
