using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    public class TreePrintTravers
    {
        /// <summary>
        /// Print the whole Tree in Pre-Order (Root-Left-Right)
        /// </summary>
        /// <param name="node">The Root node</param>
        public void TraversPre(Node node)
        {
            if (node == null) return;

            if (node.value < 10) Console.Write(" ");
            Console.Write($"{node.value} ");

            TraversPre(node.Left);
            TraversPre(node.Right);
        }

        /// <summary>
        /// Print the whole Tree in In-Order (sorted from small to big - Left-Root-Right)
        /// </summary>
        /// <param name="node">The Root node</param>
        public void TraversIn(Node node)
        {
            if (node == null) return;

            if (node.Left != null)
                TraversIn(node.Left);

            if (node.value < 10) Console.Write(" ");
            Console.Write($"{node.value} ");

            if (node.Right != null)
                TraversIn(node.Right);
        }

        /// <summary>
        /// Print the whole Tree in In-Order (sorted from small to big - Left-Root-Right)
        /// </summary>
        /// <param name="node">The root node</param>
        /// <param name="nodeCount">dont insert anything (or 0)</param>
        /// <returns>How many nodes are in the tree (int)</returns>
        public int TraversInCount(Node node, int nodeCount = 0)
        {
            if (node == null) return nodeCount;

            if (node.Left != null)
                nodeCount = TraversInCount(node.Left, nodeCount);

            Console.Write($"{node.value} ");
            nodeCount++;

            if (node.Right != null)
                nodeCount = TraversInCount(node.Right, nodeCount);

            return nodeCount;
        }

        /// <summary>
        /// Print the whole tree in Post-Order (Left-Right-Root)
        /// </summary>
        /// <param name="node">The root node</param>
        public void TraversPost(Node node)
        {
            if (node == null) return;

            if (node.Left != null)
                TraversPost(node.Left);

            if (node.Right != null)
                TraversPost(node.Right);

            if (node.value < 10) Console.Write(" ");
            Console.Write($"{node.value} ");
        }
    }
}
