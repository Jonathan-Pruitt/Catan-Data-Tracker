using CatanCompanion.models;
using CatanCompanion.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace CatanCompanion.view_models
{
    internal class PlayerViewModel : INotifyPropertyChanged
    {
        private string _playerName;
        private SettlementModel[] _settlements;
        private CityModel[] _cities;

        public string PlayerName
        {
            get => _playerName;
            set
            {
                _playerName = value;
                OnPropertyChanged();
            }
        }

        public SettlementModel[] Settlements
        {
            get => _settlements;
            set
            {
                _settlements = value;
                OnPropertyChanged();
            }
        }

        public CityModel[] Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                OnPropertyChanged();
            }
        }

        public ICommand SavePlayerCommand { get; }

        public PlayerViewModel()
        {
            SavePlayerCommand = new RelayCommand(ExecuteSavePlayer, CanSavePlayer);
        }

        private void ExecuteSavePlayer(object parameter)
        {
            PlayerModel newPlayer = new PlayerModel();
        }

        private bool CanSavePlayer(object parameter)
        {
            return !string.IsNullOrWhiteSpace(PlayerName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
