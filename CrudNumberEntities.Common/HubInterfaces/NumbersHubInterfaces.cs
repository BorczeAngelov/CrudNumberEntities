using CrudNumberEntities.Common.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudNumberEntities.Common.HubInterfaces
{
    public interface INumbersHub
    {
        Task Create();
        Task Update(NumberEntitiy number);
        Task Delete(NumberEntitiy number);
    }

    public interface INumbersHubClient
    {
        void InvokeCreate(NumberEntitiy number);
        void InvokeUpdate(NumberEntitiy number);
        void InvokeDelete(NumberEntitiy number);
        void InvokeLoadStartingValues(IEnumerable<NumberEntitiy> numbers);
    }

    public interface INumbersHubClientTwoWayComm : INumbersHubClient
    {
        event Action<NumberEntitiy> NumberCreated;
        event Action<NumberEntitiy> NumberUpdated;
        event Action<NumberEntitiy> NumberDeleted;
        event Action<IEnumerable<NumberEntitiy>> StartingValuesLoaded;

        INumbersHub ServerHub { get; }

        Task ConnectWithServerHub();
    }
}
