using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoBagGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bag<CryptoCoin> cryptoBag;
        private Iterator<CryptoCoin> coinIterator;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCryptoBag();
        }

        private void InitializeCryptoBag()
        {
            // Initialize the bag and add sample coins
            cryptoBag = new Bag<CryptoCoin>();
            cryptoBag.Add(new CryptoCoin("Bitcoin", "Icons/Bitcoin.png", 50000));
            cryptoBag.Add(new CryptoCoin("Ethereum", "Icons/Ethereum.png", 3500));
            cryptoBag.Add(new CryptoCoin("Litecoin", "Icons/Litecoin.png", 150));
            cryptoBag.Add(new CryptoCoin("Dogecoin", "Icons/Dogecoin.png", 0.05));
            cryptoBag.Add(new CryptoCoin("Ripple", "Icons/Ripple.png", 1.2));

            // Initialize the iterator
            coinIterator = cryptoBag.GetIterator();
        }

        private void DrawCoinButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if there are coins left to draw
            if (!coinIterator.IsEmpty())
            {
                // Get the next random coin
                CryptoCoin drawnCoin = coinIterator.Next();

                // Display the coin's details
                CoinDetails.Text = $"{drawnCoin.Name} - ${drawnCoin.Value}";

                // Set the coin icon, if available
                if (!string.IsNullOrEmpty(drawnCoin.IconPath))
                {
                    CoinIcon.Source = new BitmapImage(new Uri(drawnCoin.IconPath, UriKind.Relative));
                }
                else
                {
                    CoinIcon.Source = null;  // Clear the image if no icon is available
                }
            }
            else
            {
                // Display a message when all coins have been drawn
                CoinDetails.Text = "No more coins to draw!";
                CoinIcon.Source = null;
            }
        }
    }

}