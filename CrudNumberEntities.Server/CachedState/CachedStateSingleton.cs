using CrudNumberEntities.Common.DataModels;
using System.Collections.Generic;

namespace CrudNumberEntities.Server.CachedState
{
    internal class CachedStateSingleton
    {
        private static CachedStateSingleton _instance;
        private static readonly object _instanceSyncLock = new object();

        private List<NumberEntitiy> _numberEntities;
        private readonly object _numberEntitiesSyncLock = new object();

        private CachedStateSingleton()
        {
            NumberEntities = new List<NumberEntitiy>();
        }

        internal static CachedStateSingleton GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceSyncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CachedStateSingleton();
                        }
                    }
                }
                return _instance;
            }
        }

        internal List<NumberEntitiy> NumberEntities
        {
            get
            {
                lock (_numberEntitiesSyncLock)
                {
                    return _numberEntities;
                }
            }
            private set
            {
                lock (_numberEntitiesSyncLock)
                {
                    _numberEntities = value;
                }
            }
        }
    }
}
