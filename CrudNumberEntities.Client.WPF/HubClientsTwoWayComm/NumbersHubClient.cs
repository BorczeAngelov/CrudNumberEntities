using CrudNumberEntities.Common.DataModels;
using CrudNumberEntities.Common.HubInterfaces;
using CrudNumberEntities.Common.Utils;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudNumberEntities.Client.WPF.HubClientsTwoWayComm
{
    internal class NumbersHubClient : INumbersHubClientTwoWayComm
    {
        private readonly HubConnection _connection;

        public event Action<NumberEntitiy> NumberCreated;
        public event Action<NumberEntitiy> NumberUpdated;
        public event Action<NumberEntitiy> NumberDeleted;
        public event Action<IEnumerable<NumberEntitiy>> StartingValuesLoaded;

        public INumbersHub ServerHub { get; }

        internal NumbersHubClient()
        {
            _connection = new HubConnectionBuilder()
               .WithUrl(DemoUrlConstants.LocalHostUrl + DemoUrlConstants.NumbersHubEndpoint)
               .Build();

            _connection.On<NumberEntitiy>(nameof(InvokeCreate), InvokeCreate);
            _connection.On<NumberEntitiy>(nameof(InvokeUpdate), InvokeUpdate);
            _connection.On<NumberEntitiy>(nameof(InvokeDelete), InvokeDelete);
            _connection.On<IEnumerable<NumberEntitiy>>(nameof(InvokeLoadStartingValues), InvokeLoadStartingValues);

            ServerHub = new NumbersHubImp(_connection);
        }

        public async Task ConnectWithServerHub()
        {
            await _connection.StartAsync();
        }

        public void InvokeCreate(NumberEntitiy number)
        {
            NumberCreated?.Invoke(number);
        }

        public void InvokeUpdate(NumberEntitiy number)
        {
            NumberUpdated?.Invoke(number);
        }

        public void InvokeDelete(NumberEntitiy number)
        {
            NumberDeleted?.Invoke(number);
        }

        public void InvokeLoadStartingValues(IEnumerable<NumberEntitiy> numbers)
        {
            StartingValuesLoaded?.Invoke(numbers);
        }

        private class NumbersHubImp : INumbersHub
        {
            private readonly HubConnection _connection;

            public NumbersHubImp(HubConnection connection)
            {
                this._connection = connection;
            }

            public Task Create()
            {
                return _connection.InvokeAsync(nameof(Create));
            }

            public Task Update(NumberEntitiy number)
            {
                return _connection.InvokeAsync(nameof(Update), number);
            }

            public Task Delete(NumberEntitiy number)
            {
                return _connection.InvokeAsync(nameof(Delete), number);
            }
        }
    }
}
