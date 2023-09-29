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
    /// Логика взаимодействия для CrossZeroPage.xaml
    /// </summary>
    public partial class CrossZeroPage : Page
    {
        public string playerName1;
        public string playerName2;

        private string currentPlayerName;
        private string currentPlayerSymbol;

        private Button[,] board;
        private int currentPlayer;
        private bool gameOver;
        public CrossZeroPage(string playerName1, string playerName2)
        {
            InitializeComponent();

            playerName1 = playerName1;
            playerName2 = playerName2;
            TxbPlayer1.Text = playerName1;
            TxbPlayer2.Text = playerName2;

            InitializeBoard();


        }

        private void InitializeBoard()
        {
            board = new Button[3, 3]
            {
        { button00, button01, button02 },
        { button10, button11, button12 },
        { button20, button21, button22 }
            };

            currentPlayer = 0;
            gameOver = false;

            currentPlayerName = (currentPlayer % 2 == 0) ? playerName1 : playerName2;
            currentPlayerSymbol = (currentPlayer % 2 == 0) ? "X" : "O";

            foreach (var button in board)
            {
                button.Content = string.Empty;
                button.IsEnabled = true;
            }

            PlayerTurn.Text = $"Ход игрока {currentPlayerName} ({currentPlayerSymbol})";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameOver)
                return;

            var button = (Button)sender;
            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);

            if (board[row, col].Content == string.Empty)
            {
                board[row, col].Content = currentPlayerSymbol;
                currentPlayer++;

                if (CheckForWinner(row, col))
                {
                    MessageBox.Show($"Игрок со знаком ({currentPlayerSymbol}) имя игрока({currentPlayerName}) победил!");
                    gameOver = true;
                }
                else if (currentPlayer == 9)
                {
                    MessageBox.Show("Ничья!");
                    gameOver = true;
                }

                currentPlayerName = (currentPlayer % 2 == 0) ? playerName1 : playerName2;
                currentPlayerSymbol = (currentPlayer % 2 == 0) ? "X" : "O";

                PlayerTurn.Text = $"Ход игрока {currentPlayerName} ({currentPlayerSymbol})";
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigateClass.navigate.Navigate(new PlayersPage());
            }
            catch (Exception ex)
            {
            }
        }
        private bool CheckForWinner(int row, int col)
        {
            if (board[row, 0].Content != string.Empty &&
                board[row, 0].Content == board[row, 1].Content &&
                board[row, 1].Content == board[row, 2].Content)
            {
                return true;
            }

            if (board[0, col].Content != string.Empty &&
                board[0, col].Content == board[1, col].Content &&
                board[1, col].Content == board[2, col].Content)
            {
                return true;
            }

            if (row == col)
            {
                if (board[0, 0].Content != string.Empty &&
                    board[0, 0].Content == board[1, 1].Content &&
                    board[1, 1].Content == board[2, 2].Content)
                {
                    return true;
                }
            }

            if (row + col == 2)
            {
                if (board[0, 2].Content != string.Empty &&
                    board[0, 2].Content == board[1, 1].Content &&
                    board[1, 1].Content == board[2, 0].Content)
                {
                    return true;
                }
            }

            return false;

        }

        private void BtnBack_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigateClass.navigate.Navigate(new PlayersPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {
            InitializeBoard();
        }
    }
}
