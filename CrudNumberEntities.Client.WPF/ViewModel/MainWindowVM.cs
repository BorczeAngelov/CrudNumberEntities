using CrudNumberEntities.Client.WPF.HubClientsTwoWayComm;
using CrudNumberEntities.Client.WPF.Utils;
using CrudNumberEntities.Common.DataModels;
using System;
using System.Windows;

namespace CrudNumberEntities.Client.WPF.ViewModel
{
    public class MainWindowVM : ObservableBase
    {
        private readonly NumbersHubClient _numbersHubClient;

        private bool _isConnected;

        public MainWindowVM()
        {
            _numbersHubClient = new NumbersHubClient();

            ConnectCommand = new DelegateCommand(Connect, arg => !IsConnected);
            NumberEntitiesVM= new NumberEntitiesVM(_numbersHubClient);
        }

        public DelegateCommand ConnectCommand { get; }
        public NumberEntitiesVM NumberEntitiesVM { get; }

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
