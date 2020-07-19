using CrudNumberEntities.Client.WPF.HubClientsTwoWayComm;
using CrudNumberEntities.Common.DataModels;
using System.Windows;

namespace CrudNumberEntities.Client.WPF
{
    public partial class MainWindow : Window
    {
        private readonly NumbersHubClient _numbersHubClient;
        private NumberEntitiy _number;

        public MainWindow()
        {
            InitializeComponent();

            _numbersHubClient = new NumbersHubClient();
            _numbersHubClient.NumberCreated += OnNumberCreated;
            _numbersHubClient.NumberUpdated += OnNumberUpdated;
        }

        private void OnNumberCreated(NumberEntitiy newNumber)
        {
            _number = newNumber;
            NumberTextBox.Text = _number.Value.ToString();
        }

        private void OnNumberUpdated(NumberEntitiy existingNumber)
        {
            _number = existingNumber;
            NumberTextBox.Text = _number.Value.ToString();
        }

        private async void OnConnectClick(object sender, RoutedEventArgs e)
        {
            await _numbersHubClient.ConnectWithServerHub();
        }

        private void OnCreateClick(object sender, RoutedEventArgs e)
        {
            _numbersHubClient.ServerHub.Create();
        }

        private void OnUpdateClick(object sender, RoutedEventArgs e)
        {
            _numbersHubClient.ServerHub.Update(_number);
        }
    }
}
