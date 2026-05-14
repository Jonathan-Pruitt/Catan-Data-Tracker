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
        private LinkedList<string> _playerNames = new LinkedList<string>();

        public PageSetup()
        {
            InitializeComponent();
        }

        private void AddPlayer()
        {
            _playerNames.AddLast(txtbxPlayer.Text);
            UpdatePlayersView();
            txtbxPlayer.Text = "";
        }

        private void UpdatePlayersView()
        {
            stkpnlPlayers.Children.Clear();
            Label[] players = new Label[_playerNames.Count];
            int index = 0;
            foreach (string name in _playerNames)
            {
                players[index] = new Label();
                players[index].Content = name;
                stkpnlPlayers.Children.Add(players[index]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // RETRIEVE THE PLAYER-NAME FROM txtbxPlayer
            // ADD NAME TO _playerNames
            // RENDER UPDATED _playerNames TO stkpPlayers
            AddPlayer();
        }

        private void cbGameVersion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // UPDATE SELECTION ON 'PARENT' GAME
            // DISPLAY OR HIDE 'GOLD' RESOURCE BASED ON VERSION INFO
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
