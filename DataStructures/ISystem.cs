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
        
        protected TreeNode<Tables> TableDependencies = new(Tables.root);
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
            var done = new List<Tables>();

            var tableValues = Enum.GetValues(typeof(Tables));
            var totalMembers = tableValues.Length;

            int[] tableDepths = new int[totalMembers];
            foreach (Tables table in tableValues)
                tableDepths[(int) table] = Dependency.FindTraversal(table).Depth;
                
            for (int i = Dependency.TreeDepth() ; i >= 0; i++)
            {
                if (selectedAndNotDone(Tables.table1) && i == tableDepths[(int)Tables.table1]) {
                    done.Add(Tables.table1);
                    tasks.Add(Task.Run(Function1));
                }

                if (selectedAndNotDone(Tables.table2) && i == tableDepths[(int)Tables.table2]) {
                    done.Add(Tables.table2);
                    tasks.Add(Task.Run(Function2));
                }

                if (selectedAndNotDone(Tables.table3) && i == tableDepths[(int)Tables.table3]) {
                    done.Add(Tables.table3);
                    tasks.Add(Task.Run(Function3));
                }

                if (selectedAndNotDone(Tables.table4) && i == tableDepths[(int)Tables.table4]) {
                    done.Add(Tables.table4);
                    tasks.Add(Task.Run(Function4));
                }

                if (selectedAndNotDone(Tables.table5) && i == tableDepths[(int)Tables.table5]) {
                    done.Add(Tables.table5);
                    tasks.Add(Task.Run(Function5));
                }


                Task.WaitAll(tasks.ToArray());
            }

            bool selectedAndNotDone(Tables table)
            {
                return selected.Contains(table) && !done.Contains(table);
            }
        }
    }
}
