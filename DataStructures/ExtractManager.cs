using DataStructures.Definitions;
using Multithread_ETL;
using System.Collections.Generic;

namespace DataStructures
{
    public class ExtractManager
    {
        internal readonly ISystem system;

        public ExtractManager(Definitions.SystemTypes systemType)
        {
            system = SystemFactory.Create(systemType);
        }

        public void BeginExtraction(List<Tables> tables) => system.RunExtractionAsync(tables);


    }
}
