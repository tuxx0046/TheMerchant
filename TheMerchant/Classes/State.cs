using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TheMerchant.Classes
{
    public class State
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ResidingMarketName { get; set; }
        public int Money { get; set; }

        //private int money;
        //public int Money
        //{
        //    get { return money; }
        //    set
        //    {
        //        money = value;
        //        OnPropertyChanged("Money");
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
