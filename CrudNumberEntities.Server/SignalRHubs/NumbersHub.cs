using CrudNumberEntities.Common.DataModels;
using CrudNumberEntities.Common.HubInterfaces;
using CrudNumberEntities.Server.BusinessLogic.PublicOperations;
using CrudNumberEntities.Server.CachedState;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNumberEntities.Server.SignalRHubs
{
    internal class NumbersHub : Hub, INumbersHub
    {
        public override Task OnConnectedAsync()
        {
            var startingValues = CachedStateSingleton.GetInstance.NumberEntities;
            Clients.Caller.SendAsync(nameof(INumbersHubClient.InvokeLoadStartingValues), startingValues);
            return base.OnConnectedAsync();
        }

        public async Task Create()
        {
            var newNumber = CreateNumberImp.CreateNumberEntity();
            CachedStateSingleton.GetInstance.NumberEntities.Add(newNumber);
            await Clients.All.SendAsync(nameof(INumbersHubClient.InvokeCreate), newNumber);
        }

        public async Task Update(NumberEntitiy clientNumber)
        {
            var numberEntitiyFromCache = CachedStateSingleton.GetInstance.NumberEntities.First(x => x.Guid == clientNumber.Guid);
            UpdateNumberImp.UpdateNumber(numberEntitiyFromCache);
            await Clients.All.SendAsync(nameof(INumbersHubClient.InvokeUpdate), numberEntitiyFromCache);
        }

        public async Task Delete(NumberEntitiy clientNumber)
        {
            var numberEntitiyFromCache = CachedStateSingleton.GetInstance.NumberEntities.First(x => x.Guid == clientNumber.Guid);
            CachedStateSingleton.GetInstance.NumberEntities.Remove(numberEntitiyFromCache);
            await Clients.All.SendAsync(nameof(INumbersHubClient.InvokeDelete), numberEntitiyFromCache);
        }
    }
}
