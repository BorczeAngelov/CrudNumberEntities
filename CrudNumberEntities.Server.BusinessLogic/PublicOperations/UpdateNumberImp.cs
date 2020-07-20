using CrudNumberEntities.Common.DataModels;
using CrudNumberEntities.Server.BusinessLogic.InternalOperations;

namespace CrudNumberEntities.Server.BusinessLogic.PublicOperations
{
    public static class UpdateNumberImp
    {
        public static void UpdateNumber(NumberEntitiy numberEntitiy)
        {
            numberEntitiy.Value -= SpecialRandomNumberValueGenerator.GenerateSpecialValue();
        }
    }
}
