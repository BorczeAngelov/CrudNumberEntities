using CrudNumberEntities.Common.DataModels;
using CrudNumberEntities.Common.HubInterfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace CrudNumberEntities.Server.SignalRHubs
{
    internal class NumbersHub : Hub, INumbersHub
    {
        public override Task OnConnectedAsync()
        {
            //TODO: read current global state
            return base.OnConnectedAsync();
        }

        public async Task Create()
        {
            throw new NotImplementedException();
            NumberEntitiy number = null;
            await Clients.All.SendAsync(nameof(INumbersHubClient.InvokeCreate), number);
        }

        public async Task Update(NumberEntitiy number)
        {
            throw new NotImplementedException();
            NumberEntitiy updatedNumber = null;
            await Clients.All.SendAsync(nameof(INumbersHubClient.InvokeUpdate), updatedNumber);
        }

        public async Task Delete(NumberEntitiy number)
        {
            throw new NotImplementedException();
            await Clients.All.SendAsync(nameof(INumbersHubClient.InvokeDelete), number);
        }
    }
}
