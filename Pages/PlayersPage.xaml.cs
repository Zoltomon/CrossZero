using CrossZero.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrossZero.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlayersPage.xaml
    /// </summary>
    public partial class PlayersPage : Page
    {
        public PlayersPage()
        {
            InitializeComponent();
        }

        private void BtnReady_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(TxbNamePlayer1.Text) || string.IsNullOrWhiteSpace(TxbNamePlayer2.Text)) 
                {
                    MessageBox.Show("Введите имена игроков");
                }
                else
                {
                    string name1 = TxbNamePlayer1.Text;
                    string name2 = TxbNamePlayer2.Text;
                    NavigateClass.navigate.Navigate(new CrossZeroPage(name1, name2));
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
