using DesktopMTG.Models;
using DesktopMTG.Services;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DesktopMTG
{
    /// <summary>
    /// Interaction logic for EditView.xaml
    /// </summary>
    public partial class EditView : Window
    {
        private string _id;
        private Card oldCard;
        public EditView(Card card)
        {
            InitializeComponent();
            _id = card.Id;
            Name.Text = card.Name;
            oldCard = card;
        }

        private async void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            var Card = new Card();
            Card = oldCard;
            Card.Name = Name.Text;
            await CardService.Service.EditCard(_id, Card);
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
        }
    }
}
