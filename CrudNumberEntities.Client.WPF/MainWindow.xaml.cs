using CrudNumberEntities.Client.WPF.HubClientsTwoWayComm;
using System.Windows;

namespace CrudNumberEntities.Client.WPF
{
    public partial class MainWindow : Window
    {
        private readonly NumbersHubClient _numbersHubClient;

        public MainWindow()
        {
            InitializeComponent();

            _numbersHubClient = new NumbersHubClient();
        }

        private async void OnConnectClick(object sender, RoutedEventArgs e)
        {
            await _numbersHubClient.ConnectWithServerHub();
        }
    }
}
