using CrudNumberEntities.Client.WPF.HubClientsTwoWayComm;
using CrudNumberEntities.Client.WPF.Utils;
using CrudNumberEntities.Common.DataModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CrudNumberEntities.Client.WPF.ViewModel
{
    public class MainWindowVM : ObservableBase
    {
        private readonly NumbersHubClient _numbersHubClient;
        private NumberEntitiesVM _numberEntitiesVM;
        private bool _isConnected;

        public MainWindowVM()
        {
            _numbersHubClient = new NumbersHubClient();
            _numbersHubClient.StartingValuesLoaded += OnStartingValuesLoaded;

            ConnectCommand = new DelegateCommand(Connect, arg => !IsConnected);
        }

        private void OnStartingValuesLoaded(IEnumerable<NumberEntitiy> numbers)
        {
            NumberEntitiesVM = new NumberEntitiesVM(numbers, _numbersHubClient);
        }

        public DelegateCommand ConnectCommand { get; }

        public NumberEntitiesVM NumberEntitiesVM
        {
            get => _numberEntitiesVM;
            private set
            {
                if (_numberEntitiesVM != value)
                {
                    _numberEntitiesVM = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsConnected
        {
            get => _isConnected;
            private set
            {
                if (_isConnected != value)
                {
                    _isConnected = value;
                    OnPropertyChanged();
                }
            }
        }

        private async void Connect(object obj)
        {
            try
            {
                await _numbersHubClient.ConnectWithServerHub();
                IsConnected = true;
                ConnectCommand.RaiseCanExecuteChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
