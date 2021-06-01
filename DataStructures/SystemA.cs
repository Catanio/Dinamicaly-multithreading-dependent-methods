using DataStructures.Definitions;

namespace DataStructures
{
    class SystemA: ISystem
    {
        public SystemA()
        {

            /*
             * 1
             * +--2
             * |  +--5
             * |
             * +--3
             * |  +--6
             * |  |  +--8
             * |  |
             * |  +--9
             * |
             * +--4
             *    +--7
             * 
             */
            TableDependencies.Add(Tables.table1)
                .AddRange(new[] { Tables.table2, Tables.table3, Tables.table4 });

            TableDependencies.Add(Tables.table2)
                .AddRange(new[] { Tables.table5 });

            TableDependencies.Add(Tables.table3)
                .AddRange(new[] { Tables.table6, Tables.table9 });

            TableDependencies.Add(Tables.table4)
                .AddRange(new[] { Tables.table7 });
        }
    }
}
