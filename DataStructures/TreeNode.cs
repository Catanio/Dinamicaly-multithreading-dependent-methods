using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class TreeNode<T>
    {
        public T Data;
        public int Depth;
        public TreeNode<T> Parent;
        public List<TreeNode<T>> Subtrees;

        public TreeNode(T data)
        {
            Data = data;
            Parent = null;
            Subtrees = new List<TreeNode<T>>(); ;
        }

        public TreeNode<T> Add(T data)
        {
            var newNode = new TreeNode<T>(data)
            {
                Parent = this,
                Depth = Depth + 1
            };

            Subtrees.Add(newNode);
            return newNode;
        }

        public TreeNode<T> FindRoot()
        {
            var root = this;

            while (root.Parent != null)
                root = root.Parent;

            return root;
        }

        public int TreeDepth()
        {
            var root = FindRoot();
            return TraversalDepth(root);

            static int TraversalDepth(TreeNode<T> node, int maxDepth = 0)
            {

                foreach (var next in node.Subtrees)
                    maxDepth = TraversalDepth(next, maxDepth);

                return maxDepth > node.Depth ? maxDepth : node.Depth;
            }
        }

        public TreeNode<T> FindTraversal(T key) => FindRoot().Traversal(key);

        public void Remeasure()
        {
            Depth = Parent == null ? 0 : Parent.Depth + 1;
            if (Subtrees != null)
                foreach (var next in Subtrees)
                    next.Remeasure();
        }

        public void JoinBranch(TreeNode<T> sub)
        {
            Subtrees.Add(sub);
            sub.Parent = this;
            FindRoot().Remeasure();
        }

        private TreeNode<T> Traversal(T key)
        {
            if (Data.Equals(key)) return this;

            if (Subtrees.Count > 0)
                foreach (var next in Subtrees)
                {
                    var a = next.Traversal(key);
                    if (a != null) return a;
                }

            return null;
        }
    }
}