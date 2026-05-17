using System;
using System.Collections.Generic;
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

namespace CatanCompanion
{
    /// <summary>
    /// Interaction logic for PageSetup.xaml
    /// </summary>

    public partial class PageSetup : Page
    {
        private string _gameVersion;
        private List<string> _playerNames = new List<string>();

        public PageSetup()
        {
            InitializeComponent();

        }

        private void AddPlayer()
        {
            _playerNames.Add(txtbxPlayer.Text);
            UpdatePlayersView();
            txtbxPlayer.Text = "";
        }

        private void RemovePlayer(object sender, RoutedEventArgs e)
        {
            if (sender is DisplayBox boxToDelete)
            {
                _playerNames.RemoveAt(boxToDelete.Id);
            }
            UpdatePlayersView();
        }

        private void UpdatePlayersView()
        {
            stkpnlPlayers.Children.Clear();
            DisplayBox[] players = new DisplayBox[_playerNames.Count];

            int index = 0;
            foreach (string name in _playerNames)
            {
                players[index] = new DisplayBox(index);
                players[index].DisplayValue = name;
                players[index].MinWidth = 75;
                players[index].DeleteRequest += RemovePlayer;
                stkpnlPlayers.Children.Add(players[index]);
                index++;
            }
        }

        private void cbGameVersion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // UPDATE SELECTION ON 'PARENT' GAME
            // DISPLAY OR HIDE 'GOLD' RESOURCE BASED ON VERSION INFO
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddPlayer();
        }

        private void txtbxPlayer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            AddPlayer();
        }
    }
}
