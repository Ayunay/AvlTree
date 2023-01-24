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
        /// Search for a number in the Tree -- DOES NOT WORK YET
        /// </summary>
        /// <param name="root">Insert the root of the tree</param>
        public void Search(Node root, int searchNumber)
        {
            int count = SearchPre(root, searchNumber, 0);
            if (count == 0) Console.WriteLine("The number does not exist in the tree.");
            else Console.WriteLine($"The number is in the tree {count} times.");
        }

        private int SearchPre(Node node, int value, int count)
        {
            if (node != null & node.value == value) count++;

            if (node.value <= value && node.Left != null)
                count = SearchPre(node.Left, value, count);

            else if (node.value >= value && node.Right != null)
                count = SearchPre(node.Right, value, count);

            return count;
        }

        public Node SearchNode(Node root, int searchNumber)
        {
            return new Node();
        }
    }
}
