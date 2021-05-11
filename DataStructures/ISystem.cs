using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStructures
{
    abstract class ISystem
    {
        public enum Tables
        {
            root,
            table1,
            table2,
            table3,
            table4,
            table5,
            table6,
            table7,
            table8,
            table9,

        }

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

        protected Dictionary<Tables, List<Tables>> TableDependencies;
            
        public TreeNode<Tables> Dependency = new(Tables.root);


        void Function1()
        {
            Console.WriteLine("Função 1 foi chamada");
        }

        void Function2()
        {
            Console.WriteLine("Função 2 foi chamada");
        }

        void Function3()
        {
            Console.WriteLine("Função 3 foi chamada");
        }

        void Function4()
        {
            Console.WriteLine("Função 4 foi chamada");
        }

        void Function5()
        {
            Console.WriteLine("Função 5 foi chamada");
        }

        void DynamicThreadCreate(List<Tables> selected)
        {
            var tasks = new List<Task>();

            var table1 = Dependency.FindTraversal(Tables.table1);
            var table2 = Dependency.FindTraversal(Tables.table2);
            var table3 = Dependency.FindTraversal(Tables.table3);
            var table4 = Dependency.FindTraversal(Tables.table4);
            var table5 = Dependency.FindTraversal(Tables.table5);

            for (int i = Dependency.TreeDepth() ; i >= 0; i++)
            {
                if (selected.Contains(Tables.table1) && i == table1.Depth) tasks.Add(Task.Run(Function1));
                if (selected.Contains(Tables.table2) && i == table2.Depth) tasks.Add(Task.Run(Function2));
                if (selected.Contains(Tables.table3) && i == table3.Depth) tasks.Add(Task.Run(Function3));
                if (selected.Contains(Tables.table4) && i == table4.Depth) tasks.Add(Task.Run(Function4));
                if (selected.Contains(Tables.table5) && i == table5.Depth) tasks.Add(Task.Run(Function5));

                Task.WaitAll(tasks.ToArray());
            }
        }
    }
}
