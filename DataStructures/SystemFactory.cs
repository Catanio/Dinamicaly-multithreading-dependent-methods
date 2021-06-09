using DataStructures;
using DataStructures.Definitions;
using System;

namespace Multithread_ETL
{
    class SystemFactory
    {
        public static ISystem Create(SystemTypes systemType)
        {
            return systemType switch
            {
                SystemTypes.System_A => throw new NotImplementedException(),
                SystemTypes.System_B => throw new NotImplementedException(),
                SystemTypes.System_C => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException($"The system {systemType} doesn't exists")
            };
        }
    }
}
