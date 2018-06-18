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
using System.Windows.Shapes;

namespace DesktopMTG
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : Window
    {
        public AddView()
        {
            InitializeComponent();
        }

        private async void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            var card = new Card() { Id = "001", Name = Name.Text, OriginalType = "" };
            await CardService.Service.AddCard(card);
            this.DialogResult = true;
            List<string> list = new List<string>();
            using (var reader = new StreamReader(@"D:\ProjectMTG\MTG\DesktopMTG\Temp.txt"))
            {
                while (reader.EndOfStream != true)
                {
                    var line = reader.ReadLine();
                    list.Add(line);
                }  
            }
            foreach (string s in list)
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Credentials = new NetworkCredential("icedeltafire@gmail.com", "fhh7337azk91cb");
                smtpClient.EnableSsl = true;
                smtpClient.SendAsync("icedeltafire@gmail.com", s, "A new card was added", "The new card with name: " + Name.Text, new Object());
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
        }
    }
}
