using DesktopMTG.Models;
using DesktopMTG.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace DesktopMTG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            initCards();
            List<string> data = new List<string>();
            data.Add("");
            data.Add("Artifact");
            data.Add("Basic");
            data.Add("Conspiracy");
            data.Add("Creature");
            data.Add("Eaturecray");
            data.Add("Ever");
            data.Add("Host");
            data.Add("Instant");
            data.Add("Land");
            data.Add("Legendary");
            data.Add("Ongoing");
            data.Add("Plane");
            data.Add("Planeswalker");
            data.Add("Scariest");
            data.Add("Scheme");
            data.Add("See");
            data.Add("Sorcery");
            data.Add("Summon");
            data.Add("Tribal");
            data.Add("Vanguard");
            data.Add("World");
            comboCardType.ItemsSource = data;
        }

        private List<Card> _Cards;

        private async Task<IEnumerable<Card>> InitCards()
        {
            _Cards = (await CardService.Service.GetAll()).OrderBy(s => s.Name).ToList();
            lvUsers.ItemsSource = _Cards;
            return _Cards;
        }

        private void SortCards()
        {
            lvUsers.ItemsSource = _Cards.FindAll(s => s.Name.Contains(SearchBox.Text));
            lvUsers.ItemsSource = _Cards.FindAll(s => s.OriginalType.Contains(comboCardType.Text));
        }

        private async void initCards()
        {
            InitializeComponent();
            await InitCards();
            SortCards();
        }

        private async void btnCreateCard_Click(object sender, RoutedEventArgs e)
        {
            AddView inputDialog = new AddView();
            if (inputDialog.ShowDialog() == true)
            {
                await InitCards();
            }
        }

        private async void DeleteCard_Click(object sender, RoutedEventArgs e)
        {
            string id = (sender as Button).Uid;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                await CardService.Service.DeleteCard(id);
                await InitCards();
            }
        }

        private async void EditCard_Click(object sender, RoutedEventArgs e)
        {
            string id = (sender as Button).Uid;
            Card card = await CardService.Service.GetCard(id);
            EditView inputDialog = new EditView(card);
            if (inputDialog.ShowDialog() == true)
            {
                await InitCards();
            }
        }

        private void CopyCard_Click(object sender, RoutedEventArgs e)
        {
            string id = (sender as Button).Uid;
            Clipboard.SetText(id);
        }

        private async void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            Window1 inputDialog = new Window1();
            if (inputDialog.ShowDialog() == true)
            {
                await InitCards();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SortCards();
        }

        private void comboCardType_DropDownClosed(object sender, EventArgs e)
        {
            SortCards();
        }
    }
}
