using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    internal class TreeSearch
    {
        /// <summary>
        /// Search for a number in the Tree
        /// </summary>
        /// <param name="node">The root node</param>
        /// <param name="value">The searched number</param>
        /// <param name="count">Insert 0 or nothing</param>
        /// <returns>The amount of nodes with this number</returns>
        public int SearchValue(Node node, int value, int count = 0)
        {
            if (node != null & node.value == value) count++;

            if (value >= node.value && node.Right != null)
                count = SearchValue(node.Right, value, count);

            else if (value <= node.value && node.Left != null)
                count = SearchValue(node.Left, value, count);

            return count;
        }

        public Node SearchNode(Node root, int searchNumber)
        {
            return new Node();
        }
    }
}
