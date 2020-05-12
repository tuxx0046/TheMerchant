using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQLite;
using TheMerchant.Classes;

namespace TheMerchant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Market SelectedMarket { get; set; }

        Market netto = new Market("Netto", 2);
        Market bilka = new Market("Bilka", 3);
        Market superbrugsen = new Market("SuperBrugsen", 2);
        Market kvickly = new Market("Kvickly", 3);
        Market irma = new Market("Irma", 1);
        public List<Market> Markets { get; set; }

        Merchant theKobman = new Merchant(25);

        List<Item> items;

        State state = new State();

        public delegate void SellItemHandler(Item item);
        public event SellItemHandler SellItemEvent;

        public MainWindow()
        {
            InitializeComponent();
            Markets = new List<Market>();
            Loaded += InitializeGame;
            SellItemEvent += theKobman.SellItem;
        }

        private void InitializeGame(object sender, RoutedEventArgs args)
        {
            Markets.Add(netto);
            Markets.Add(bilka);
            Markets.Add(superbrugsen);
            Markets.Add(kvickly);
            Markets.Add(irma);

            SetMarketNeighbours();
            InitItems();
            FillMarketInventories();
            FillMerchantInventory();

            neighbouringMarkets.ItemsSource = Markets[0].Neighbours;
            SelectedMarket = Markets[0];
            merchantInventory.DataContext = theKobman;

            currentMarket.DataContext = SelectedMarket;
            marketName.Content = SelectedMarket.Name.ToString();

            // TODO check for database status
            theKobman.TravelToMarket(SelectedMarket);

            state.Money = 50;
            state.ResidingMarketName = SelectedMarket.Name;

            lblMoney.DataContext = state;
        }

        /// <summary>
        /// Set neighbours for each market
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SetMarketNeighbours()
        {
            netto.Neighbours.Add(bilka);
            netto.Neighbours.Add(superbrugsen);
            netto.Neighbours.Add(irma);
            bilka.Neighbours.Add(netto);
            bilka.Neighbours.Add(irma);
            superbrugsen.Neighbours.Add(netto);
            superbrugsen.Neighbours.Add(kvickly);
            superbrugsen.Neighbours.Add(irma);
            kvickly.Neighbours.Add(superbrugsen);
            kvickly.Neighbours.Add(irma);
            irma.Neighbours.Add(netto);
            irma.Neighbours.Add(bilka);
            irma.Neighbours.Add(superbrugsen);
            irma.Neighbours.Add(kvickly);

            
        }

        /// <summary>
        /// Travel to chosen market
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TravelToMarket(object sender, RoutedEventArgs e)
        {
            // Reset prices for market before moving to new market
            ResetPrices(SelectedMarket);
            
            // Set new market
            SelectedMarket = neighbouringMarkets.SelectedItem as Market;

            // Change prices for the new market
            SelectedMarket.FluctuatePrices();

            // Update Viewlist & Label with new market
            currentMarket.DataContext = SelectedMarket;
            marketName.Content = SelectedMarket.Name.ToString();
            neighbouringMarkets.ItemsSource = SelectedMarket.Neighbours;
        }

        /// <summary>
        /// Create Item objects for market inventories
        /// </summary>
        private void InitItems()
        {
            items = new List<Item>()
            {
                new Item("Carrot", 3),
                new Item("Potato", 2),
                new Item("Bell Pepper", 4),
                new Item("Cucumber", 3),
                new Item("Lettuce", 5),
                new Item("Spinach", 5),
                new Item("Pak Choy", 6),
                new Item("Turnip", 10),
                new Item("Avocado", 7),
                new Item("Tomato", 3),
                new Item("Melon", 12),
                new Item("Squash", 4),
                new Item("Cauliflower", 4),
                new Item("Broccoli", 5),
                new Item("Celery", 3),
                new Item("Garlic", 2),
                new Item("Cheese", 4),
                new Item("Wood", 2),
                new Item("Rice", 2),
                new Item("Milk", 3),
            };
        }

        /// <summary>
        /// Put random Items in each market in Markets
        /// </summary>
        private void FillMarketInventories()
        {
            int index = 0;
            foreach (Market m in Markets)
            {
                for (int i = index; i < index + 4; i++)
                {
                    m.Inventory.Add(items[i]);
                }
                index += 4;
            }
        }

        /// <summary>
        /// Resets prices to default, to avoid inflation
        /// </summary>
        /// <param name="market"></param>
        private void ResetPrices(Market market)
        {
            foreach (Item item in market.Inventory)
            {
                item.ResetPrice();
            }
        }

        /// <summary>
        /// Give the merchant some random items to start with
        /// </summary>
        private void FillMerchantInventory()
        {
            items.Shuffle();
            for (int i = 0; i < 5; i++)
            {
                theKobman.Inventory.Add(items[i]);
            }
        }

        private void btnSell_Click(object sender, RoutedEventArgs e)
        {
            Item itemToSell = merchantInventory.SelectedItem as Item;
            if (SelectedMarket.Inventory.Contains(itemToSell))
            {
                state.Money = state.Money - itemToSell.SellPrice;
                OnItemSell(itemToSell);
                UpdateControls();
            }
        }

        protected virtual void OnItemSell(Item item)
        {
            if (SellItemEvent != null)
            {
                SellItemEvent(item);
            }
        }

        private void UpdateControls()
        {
            merchantInventory.Items.Refresh();
            merchantInventory.ItemsSource = theKobman.Inventory;
            lblMoney.Content = state.Money.ToString();
        }
    }
}