using CrudNumberEntities.Common.DataModels;
using CrudNumberEntities.Server.BusinessLogic.InternalOperations;

namespace CrudNumberEntities.Server.BusinessLogic.PublicOperations
{
    public static class CreateNumberImp
    {
        public static NumberEntitiy CreateNumberEntity()
        {
            return NumberEntityFactory.CreateRandomNumber();
        }
    }
}
