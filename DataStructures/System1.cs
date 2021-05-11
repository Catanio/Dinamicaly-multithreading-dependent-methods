using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class System1: ISystem
    {
        public System1()
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

            TableDependencies = new()
            {
                {
                    Tables.table1,
                    new List<Tables> { Tables.table2, Tables.table3, Tables.table4 }
                },
                {
                    Tables.table2,
                    new List<Tables> { Tables.table5 }
                },
                {
                    Tables.table3,
                    new List<Tables> { Tables.table6, Tables.table9 }
                },
                {
                    Tables.table4,
                    new List<Tables> { Tables.table7 }
                },
            };


        }
    }
}
