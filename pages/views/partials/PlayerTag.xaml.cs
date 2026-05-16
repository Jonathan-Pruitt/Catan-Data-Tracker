using System;
using System.Collections.Generic;
using System.Reflection;
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
    /// Interaction logic for PlayerTag.xaml
    /// </summary>
    public partial class PlayerTag : UserControl
    {
        public PlayerTag()
        {
            InitializeComponent();
        }

        public event EventHandler<PlayerRemovedEventArgs> RemovePlayer;

        private int _playerIndex;
        private string _playerName;

        public int PlayerIndex
        {
            get { return _playerIndex; }
        }
        
        public string PlayerName
        {
            get { return _playerName; }
        }

        protected virtual void OnRemovePlayer(PlayerRemovedEventArgs e)
        {
            RemovePlayer?.Invoke(this, e);
        }

        public void SetPlayerData(int index, string name)
        {
            _playerIndex = index;
            _playerName = name;
            lblPlayerName.Content = _playerName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnRemovePlayer(new PlayerRemovedEventArgs(PlayerIndex));
        }
    }

    public class PlayerRemovedEventArgs : EventArgs
    {
        // CONSTRUCTOR
        public PlayerRemovedEventArgs(int playerIndex) => PlayerIndex = playerIndex;
        
        public int PlayerIndex { get; }
    }
}
