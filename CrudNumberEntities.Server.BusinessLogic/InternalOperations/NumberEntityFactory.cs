using CrudNumberEntities.Common.DataModels;
using System;

namespace CrudNumberEntities.Server.BusinessLogic.InternalOperations
{
    internal class NumberEntityFactory
    {
        public static NumberEntitiy CreateRandomNumber()
        {
            var newNumberEntitiy = new NumberEntitiy()
            {
                Guid = Guid.NewGuid(),
                Value = SpecialRandomNumberValueGenerator.GenerateSpecialStartingValue()
            };
            return newNumberEntitiy;
        }
    }
}
