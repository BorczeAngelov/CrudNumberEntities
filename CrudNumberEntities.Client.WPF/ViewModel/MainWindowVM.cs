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
        private NumberEntityVM _selectedNumber;

        public MainWindowVM()
        {
            ConnectCommand = new DelegateCommand(Connect, arg => !IsConnected);
            CreateCommand = new DelegateCommand(Create);

            _numbersHubClient = new NumbersHubClient();
            _numbersHubClient.NumberCreated += OnNumberCreated;
        }

        public DelegateCommand ConnectCommand { get; }
        public DelegateCommand CreateCommand { get; }

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

        public NumberEntityVM SelectedNumber
        {
            get => _selectedNumber;
            set
            {
                if (_selectedNumber != value)
                {
                    _selectedNumber = value;
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

        private async void Create(object obj)
        {
            await _numbersHubClient.ServerHub.Create();
        }

        private void OnNumberCreated(NumberEntitiy newNumber)
        {
            var newVM = new NumberEntityVM(newNumber, _numbersHubClient);
            SelectedNumber = newVM;
        }
    }
}
