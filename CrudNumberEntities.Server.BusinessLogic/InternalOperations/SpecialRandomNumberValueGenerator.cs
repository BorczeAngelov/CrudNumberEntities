using System;

namespace CrudNumberEntities.Server.BusinessLogic.InternalOperations
{
    internal static class SpecialRandomNumberValueGenerator
    {
        internal static int GenerateSpecialStartingValue()
        {
            var random = new Random();
            return random.Next(42);
        }

        internal static int GenerateSpecialValue()
        {
            var random = new Random();
            return random.Next(2, 4);
        }
    }
}
