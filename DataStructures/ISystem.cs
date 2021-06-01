using DataStructures.Definitions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStructures
{
    abstract class ISystem
    {
        protected TreeNode<Tables> TableDependencies = new(Tables.root);
        public TreeNode<Tables> Dependency = new(Tables.root);


        void ExtractFunction1()
        {
            Console.WriteLine("Função 1 foi chamada");
        }

        void ExtractFunction2()
        {
            Console.WriteLine("Função 2 foi chamada");
        }

        void ExtractFunction3()
        {
            Console.WriteLine("Função 3 foi chamada");
        }

        void ExtractFunction4()
        {
            Console.WriteLine("Função 4 foi chamada");
        }

        void ExtractFunction5()
        {
            Console.WriteLine("Função 5 foi chamada");
        }

        public Action GetExtractionMethod(Tables table)
        {
            return table switch
            {
                Tables.table1 => ExtractFunction1,
                Tables.table2 => ExtractFunction2,
                Tables.table3 => ExtractFunction3,
                Tables.table4 => ExtractFunction4,
                Tables.table5 => ExtractFunction5,
                _ =>throw new ArgumentOutOfRangeException($"Can't extract table {table} as it doesn't exist")
            };
        }


        void RunExtractionAsync(List<Tables> selected)
        {
            var tasks = new List<Task>();
            var done = new List<Tables>();

            var tableValues = Enum.GetValues(typeof(Tables));
            var totalMembers = tableValues.Length;

            int[] tableDepths = new int[totalMembers];
            foreach (Tables table in tableValues)
                tableDepths[(int) table] = Dependency.FindTraversal(table).Depth;
                
            for (int depthTurn = Dependency.TreeDepth() ; depthTurn >= 0; depthTurn++)
            {
                foreach(Tables table in tableValues)
                {
                    if (depthTurn == tableDepths[(int)table] && selected.Contains(table) && !done.Contains(table))
                    {
                        done.Add(table);
                        tasks.Add(Task.Run(GetExtractionMethod(table)));
                    }
                }

                Task.WaitAll(tasks.ToArray());
            }
        }
    }
}
