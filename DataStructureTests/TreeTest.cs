using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
                
            Assert.AreEqual(6, root.FindTraversal(6).Data);
            Assert.AreEqual(2, root.FindTraversal(6).Depth);

            Assert.AreEqual(1, root.FindTraversal(1).Data);
            Assert.AreEqual(0, root.FindTraversal(1).Depth);

            Assert.AreEqual(4, root.FindTraversal(4).Data);
            Assert.AreEqual(1, root.FindTraversal(4).Depth);
            root.FindTraversal(5);
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

            Assert.AreEqual(joinPoint.Data, 6);
            Assert.AreEqual(joinPoint.Depth, 2);

            Assert.AreEqual(root1.FindTraversal(7).Parent.Data, 6);
            Assert.AreEqual(root1.FindTraversal(7).Depth, 3);
            
            Assert.AreEqual(leafNode.Parent.Data, 7);
            Assert.AreEqual(leafNode.Data, 8);
            Assert.AreEqual(leafNode.Depth, 4);
        }
    }
}
