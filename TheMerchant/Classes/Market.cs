using SQLite;
using System;
using System.Collections.Generic;
using TheMerchant.Classes;
using TheMerchant.Classes.Abstract;

namespace TheMerchant
{
    public class Market: Trader
    {
        private List<Market> neighbours = new List<Market>();
        public List<Market> Neighbours
        {
            get { return neighbours; }
            set { neighbours = value; }
        }

        private int travelExpenses;
        public int TravelExpenses { get { return travelExpenses; } set { travelExpenses = value; } }

        public Market() { }
        public Market(string name, int travelExpenses) : base(name)
        {
            this.travelExpenses = travelExpenses;
        }

        public void FluctuatePrices()
        {
            int[] fluctuations = new int[] { -2, -1, 0, 1, 2, 3, 4, 5, 6 };
            Random rnd = new Random();
            foreach (Item item in Inventory)
            {
                item.BuyPrice = item.BuyPrice + fluctuations[rnd.Next(0, fluctuations.Length)];
                item.SellPrice = item.BuyPrice + 3;
            }
        }
    }
}
