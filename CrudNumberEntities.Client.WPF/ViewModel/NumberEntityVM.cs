using CrudNumberEntities.Client.WPF.HubClientsTwoWayComm;
using CrudNumberEntities.Client.WPF.Utils;
using CrudNumberEntities.Common.DataModels;
using System;

namespace CrudNumberEntities.Client.WPF.ViewModel
{
    public class NumberEntityVM : ObservableBase
    {
        private readonly NumberEntitiy _numberEntity;
        private readonly NumbersHubClient _numbersHubClient;

        internal NumberEntityVM(
            NumberEntitiy numberEntity,
            NumbersHubClient numbersHubClient)
        {
            _numberEntity = numberEntity;
            _numbersHubClient = numbersHubClient;

            UpdateCommand = new DelegateCommand(Update);
            DeleteCommand = new DelegateCommand(Delete);
            _numbersHubClient.NumberUpdated += OnNumberUpdated;
        }

        public DelegateCommand UpdateCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public Guid Guid { get => _numberEntity.Guid; }
        public int Value
        {
            get => _numberEntity.Value;
            set
            {
                if (_numberEntity.Value != value)
                {
                    _numberEntity.Value = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnNumberUpdated(NumberEntitiy existingNumber)
        {
            if (Guid == existingNumber.Guid)
            {
                Value = existingNumber.Value;
            }
        }

        private async void Update(object obj)
        {
            await _numbersHubClient.ServerHub.Update(_numberEntity);
        }

        private async void Delete(object obj)
        {
            await _numbersHubClient.ServerHub.Delete(_numberEntity);
        }
    }
}
