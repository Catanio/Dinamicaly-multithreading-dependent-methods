using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DataStructureTests
{
    [TestClass]
    public class TreeTest
    {
        [TestMethod]
        public void FindNode()
        {
            /* Tree:
               1
               +--2
               |  +--5
               |
               +--3
               |  +--6
               |
               +--4
               
               0  1  2        <__depth
             */
            var root = new TreeNode<int>(1);
            root.Add(2).Add(5);
            root.Add(3).Add(6);
            root.Add(4);
                
            Assert.AreEqual(6, root.FindInTree(6).Data);
            Assert.AreEqual(2, root.FindInTree(6).Depth);

            Assert.AreEqual(1, root.FindInTree(1).Data);
            Assert.AreEqual(0, root.FindInTree(1).Depth);

            Assert.AreEqual(4, root.FindInTree(4).Data);
            Assert.AreEqual(1, root.FindInTree(4).Depth);
            root.FindInTree(5);
        }
        [TestMethod]
        public void MeasureDepth()
        {
            /* Tree:
               1
               +--2
               |  +--5
               |
               +--3
               |  +--6
               |     +--7
               |
               +--4
               
               0  1  2  3    :Depth
             */
            var root = new TreeNode<int>(1);
            Assert.AreEqual(0, root.TreeDepth());

            root.Add(2).Add(5);
            Assert.AreEqual(2, root.TreeDepth());

            root.Add(3).Add(6).Add(7);
            Assert.AreEqual(3, root.TreeDepth());

            root.Add(4);
            Assert.AreEqual(3, root.TreeDepth());

        }

        [TestMethod]
        public void JoiningTrees()
        {
            /*Tree:
               1
               +--2
               |  +--5
               |
               +--3
               |  +--6
               |     *--join--7
               |              +--8
               |
               +--4
               
               0  1  2        3  4      :Depth
             */


            //Arranje
            var root1 = new TreeNode<int>(1);
            root1.Add(2).Add(5);

            var joinPoint = root1.Add(3).Add(6);
            root1.Add(4);
            
            var root2 = new TreeNode<int>(7);
            var leafNode = root2.Add(8);

            //Act
            joinPoint.JoinBranch(root2);


            // Assert
            Assert.AreEqual(joinPoint.Data, 6);
            Assert.AreEqual(joinPoint.Depth, 2);

            Assert.AreEqual(root1.FindInTree(7).Parent.Data, 6);
            Assert.AreEqual(root1.FindInTree(7).Depth, 3);
            
            Assert.AreEqual(leafNode.Parent.Data, 7);
            Assert.AreEqual(leafNode.Data, 8);
            Assert.AreEqual(leafNode.Depth, 4);
        }

        [TestMethod]
        public void Foreach_InOrder()
        {
            
            // Arranje
            var root = new TreeNode<char>('a');
            root.AddRange(new[] { 'b', 'c', 'd' });
            root.Add('e').AddRange(new[] { 'f', 'g' });

            var rawValues = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            var nodeValues = new char[rawValues.Length];


            // Act
            var i = 0;
            foreach (var node in root)
            {
                nodeValues[i] = node.Data;
                i++;
            }

            // Assert
            for(i = 0; (i < rawValues.Length); i++)
                Assert.AreEqual(rawValues[i], nodeValues[i]);

        }

        [TestMethod]
        public void Cutting()
        {

            // Arranje
            var rawValuesA = new List<char>{ 'a', 'c', 'd', 'e', 'f', 'g'};
            var rawValuesB = new List<char>{ 'b', 'x', 'y' };

            var root = new TreeNode<char>('a');
            root.AddRange(new[] { 'b', 'c', 'd' });
            root.Add('e').AddRange(new[] { 'f', 'g' });

            var branchB = root.FindInTree('b');
            branchB.AddRange(new[] { 'x', 'y' });

            // Act
            var branchA= branchB.Cut();


            // Assert
            
            Assert.AreEqual(branchA.CountTreeNodes(), 6);
            Assert.AreEqual(branchB.CountBranchNodes(), 3);
            
            foreach (var node in branchB)
                Assert.IsTrue(rawValuesB.Contains(node.Data));

            foreach (var node in branchA)
                Assert.IsTrue(rawValuesA.Contains(node.Data));
        }

    }
}
