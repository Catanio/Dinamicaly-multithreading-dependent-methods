using DataStructures.Definitions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStructures
{
    public abstract class ISystem
    {
        protected TreeNode<Tables> TableDependencies = new(Tables.root);

        public TreeNode<Tables> Dependencies { get; set; }


        protected abstract void ExtractFunction1();

        protected abstract void ExtractFunction2();

        protected abstract void ExtractFunction3();

        protected abstract void ExtractFunction4();

        protected abstract void ExtractFunction5();

        public TreeNode<Tables> MountDependencyTree()
        {
            var root = new TreeNode<Tables>(Tables.root);



            return Dependencies;
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


        public void RunExtractionAsync(List<Tables> selected)
        {
            var tasks = new List<Task>();
            var done = new List<Tables>();

            var tableValues = Enum.GetValues(typeof(Tables));
            var totalMembers = tableValues.Length;

            int[] tableDepths = new int[totalMembers];
            foreach (Tables table in tableValues)
                tableDepths[(int) table] = Dependencies.FindInTree(table).Depth;
                
            for (int depthTurn = Dependencies.TreeDepth() ; depthTurn >= 0; depthTurn++)
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
