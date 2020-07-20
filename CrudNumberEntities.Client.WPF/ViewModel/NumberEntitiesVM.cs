using CrudNumberEntities.Client.WPF.HubClientsTwoWayComm;
using CrudNumberEntities.Client.WPF.Utils;
using CrudNumberEntities.Common.DataModels;
using System.Collections.ObjectModel;

namespace CrudNumberEntities.Client.WPF.ViewModel
{
    public class NumberEntitiesVM : ObservableBase
    {
        private readonly NumbersHubClient _numbersHubClient;
        private NumberEntityVM _selectedNumber;

        internal NumberEntitiesVM(
            NumbersHubClient numbersHubClient,
            NumberEntities numberEntities = null)
        {
            _numbersHubClient = numbersHubClient;
            _numbersHubClient.NumberCreated += OnNumberCreated;

            CreateCommand = new DelegateCommand(Create);

            if (numberEntities != null)
            {
                foreach (var numberEntitiy in numberEntities.ListOfNumbers)
                {
                    var numberEntityVM = new NumberEntityVM(numberEntitiy, _numbersHubClient);
                    NumberEntitiyVMs.Add(numberEntityVM);
                }
            }
        }

        public ObservableCollection<NumberEntityVM> NumberEntitiyVMs { get; } = new ObservableCollection<NumberEntityVM>();
        public DelegateCommand CreateCommand { get; }

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

        private async void Create(object obj)
        {
            await _numbersHubClient.ServerHub.Create();
        }

        private void OnNumberCreated(NumberEntitiy numberEntitiy)
        {
            var numberEntityVM = new NumberEntityVM(numberEntitiy, _numbersHubClient);
            NumberEntitiyVMs.Add(numberEntityVM);
            SelectedNumber = numberEntityVM; //Demo
        }
    }
}
