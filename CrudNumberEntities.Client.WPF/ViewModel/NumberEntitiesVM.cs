using CrudNumberEntities.Client.WPF.HubClientsTwoWayComm;
using CrudNumberEntities.Client.WPF.Utils;
using CrudNumberEntities.Common.DataModels;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace CrudNumberEntities.Client.WPF.ViewModel
{
    public class NumberEntitiesVM : ObservableBase
    {
        private readonly NumbersHubClient _numbersHubClient;

        internal NumberEntitiesVM(
            NumbersHubClient numbersHubClient,
            NumberEntities numberEntities = null)
        {
            _numbersHubClient = numbersHubClient;
            _numbersHubClient.NumberCreated += OnNumberCreated;
            _numbersHubClient.NumberDeleted += OnNumberDeleted;

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

        private async void Create(object obj)
        {
            await _numbersHubClient.ServerHub.Create();
        }

        private void OnNumberCreated(NumberEntitiy numberEntitiy)
        {
            var numberEntityVM = new NumberEntityVM(numberEntitiy, _numbersHubClient);
            NumberEntitiyVMs.Add(numberEntityVM);
        }

        private void OnNumberDeleted(NumberEntitiy numberEntitiy)
        {
            var numberEntityVM = NumberEntitiyVMs.FirstOrDefault(x => x.Guid == numberEntitiy.Guid);
            if (numberEntityVM != null)
            {
                Debug.Assert(NumberEntitiyVMs.Contains(numberEntityVM));
                NumberEntitiyVMs.Remove(numberEntityVM);
            }
        }
    }
}
