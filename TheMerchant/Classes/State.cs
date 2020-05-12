using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TheMerchant.Classes
{
    public class State: INotifyPropertyChanged
    {
        public string ResidingMarketName { get; set; }
        public int Money { get; set; }

        //public int Money 
        //{ 
        //    get; 
        //    set {
        //    } 
        //}

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
