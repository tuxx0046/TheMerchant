using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Classes
{
    class ItemName
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
