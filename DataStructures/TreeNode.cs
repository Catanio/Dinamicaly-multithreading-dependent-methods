using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class TreeNode<T>: IEnumerable<TreeNode<T>>
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

        public TreeNode<T> AddRange(IEnumerable<T> collection)
        {
            foreach(var element in collection)
                this.Add(element);

            return this;
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

        public void Remeasure()
        {
            Depth = Parent == null ? 0 : Parent.Depth + 1;
            if (Subtrees != null)
                foreach (var next in Subtrees)
                    next.Remeasure();
        }

        public int CountTreeNodes()
        {
            var count = 0;
            foreach (var node in this.FindRoot())
                count++;

            return count;
        }

        public int CountBranchNodes()
        {
            var count = 0;
            foreach (var node in this)
                count++;

            return count;
        }

        public TreeNode<T> FindInTree(T key)
        {
            foreach (var i in this.FindRoot())
                if (key.Equals(i.Data))
                    return i;

            return null;
        }

        public void JoinBranch(TreeNode<T> sub)
        {
            Subtrees.Add(sub);
            sub.Parent = this;
            FindRoot().Remeasure();
        }

        /// <summary>
        /// Remove the branch from tree, unassociating it's parent
        /// </summary>
        /// <returns>tree root from where it was removed</returns>
        public TreeNode<T> Cut()
        {
            var root = FindRoot();

            Parent.Subtrees.Remove(this);
            Parent = null;

            root.Remeasure();
            this.Remeasure();

            return root;
        }

        //TODO: implement a pre-order and post-order retrival
        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            yield return this;

            foreach (var childNode in Subtrees)
                foreach (var childEnumerated in childNode)
                    yield return childEnumerated;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}