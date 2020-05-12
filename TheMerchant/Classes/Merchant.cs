using System;
using System.Collections.Generic;
using System.Text;
using TheMerchant.Classes.Abstract;

namespace TheMerchant.Classes
{ 
    public class Merchant : Trader
    {
        private int money;
        public int Money { get { return money; } set { money = value; } }
        private Market currentStay;
        public Market CurrentStay { get { return currentStay; } set { currentStay = value; } }
        
        public Merchant(int money)
        {
            this.money = money;
        }



        public void TravelToMarket(Market newStay)
        {
            currentStay = newStay;
        }
    }
}
