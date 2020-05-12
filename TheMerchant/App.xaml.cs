using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TheMerchant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "TheMerchant.db";
        static string folderPath = Environment.CurrentDirectory;
        internal static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }
}
