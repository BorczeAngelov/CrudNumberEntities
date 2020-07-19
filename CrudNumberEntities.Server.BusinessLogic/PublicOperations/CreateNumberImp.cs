using CrudNumberEntities.Common.DataModels;
using System;

namespace CrudNumberEntities.Server.BusinessLogic.PublicOperations
{
    public static class CreateNumberImp
    {
        public static NumberEntitiy CreateRandomNumber()
        {
            var newNumberEntitiy = new NumberEntitiy()
            {
                Guid = Guid.NewGuid(),
                Value = 42 //TODO: Implement random generator
            };
            return newNumberEntitiy;
        }
    }
}
