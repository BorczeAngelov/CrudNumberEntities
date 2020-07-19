using CrudNumberEntities.Common.DataModels;

namespace CrudNumberEntities.Server.BusinessLogic.PublicOperations
{
    public static class UpdateNumberImp
    {
        public static void UpdateNumber(NumberEntitiy numberEntitiy)
        {
            numberEntitiy.Value--; //TODO: Implement random generator
        }
    }
}
