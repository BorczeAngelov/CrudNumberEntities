using CrudNumberEntities.Common.DataModels;
using CrudNumberEntities.Common.HubInterfaces;
using CrudNumberEntities.Server.BusinessLogic.PublicOperations;
using Microsoft.AspNetCore.SignalR;
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
            var newNumber = CreateNumberImp.CreateNumberEntity();
            await Clients.All.SendAsync(nameof(INumbersHubClient.InvokeCreate), newNumber);
        }

        public async Task Update(NumberEntitiy number)
        {
            UpdateNumberImp.UpdateNumber(number);
            await Clients.All.SendAsync(nameof(INumbersHubClient.InvokeUpdate), number);
        }

        public async Task Delete(NumberEntitiy number)
        {
            await Clients.All.SendAsync(nameof(INumbersHubClient.InvokeDelete), number);
        }
    }
}
