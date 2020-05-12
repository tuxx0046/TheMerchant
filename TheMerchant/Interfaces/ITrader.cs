using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Text;
using TheMerchant.Classes;

namespace TheMerchant
{
    public interface ITrader
    {
        void BuyItem(Item item);
        void SellItem(Item item);
    }
}
