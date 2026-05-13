using CatanCompanion.pages.views.partials;
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
        private string _gameVersion = "Classic";
        private List<string> _playerNames = new List<string>();

        public PageSetup()
        {
            InitializeComponent();
            cbGameVersion.SelectionChanged += cbGameVersion_SelectionChanged;
        }

        private void cbGameVersion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // HIDE {GOLD} WHEN 'SEAFARERS' GAME IS NOT SELECTED
            if (cbGameVersion?.SelectedItem is ComboBoxItem cbitem)
            {
                inlistGold.Visibility = cbitem.Content.ToString() == "Seafarers" ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void InputAndList_DataSubmitted(object sender, ListSubmittedEventArgs e)
        {
            string identifier = e.Key;
            List<string> collectedData = e.Items;

            switch (identifier)
            {
                case "wheat":
                    // pass collection to game logic
                    break;
                case "brick":
                    // pass collection to game logic
                    break;
                case "ore":
                    // pass collection to game logic
                    break;
                case "sheep":
                    // pass collection to game logic
                    break;
                case "wood":
                    // pass collection to game logic
                    break;
                case "gold":
                    // pass collection to game logic
                    break;
                case "players":
                    // pass collection to game logic
                    break;
                default:
                    MessageBox.Show("Error: No list-logic provided to be returned");
                    break;
            }
        }
    }
}
