using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public int SearchValue(Node root, int value, int count = 0)
        {
            if (root != null & root.value == value) count++;

            if (value >= root.value && root.Right != null)
                count = SearchValue(root.Right, value, count);

            else if (value <= root.value && root.Left != null)
                count = SearchValue(root.Left, value, count);

            return count;
        }

        public Node SearchNode(Node root, int value, Node foundNode = null)
        {
            if (root != null & root.value == value) return root;

            if (value >= root.value && root.Right != null)
                foundNode = SearchNode(root.Right, value, foundNode);

            else if (value <= root.value && root.Left != null)
                foundNode = SearchNode(root.Left, value, foundNode);

            return foundNode;
        }
    }
}
