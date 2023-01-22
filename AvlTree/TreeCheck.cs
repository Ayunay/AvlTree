using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AvlTree
{
    internal class TreeCheck
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
                count += SearchPre(node.Left, value, count);

            else if (node.value >= value && node.Right != null)
                count += SearchPre(node.Right, value, count);

            return count;
        }

        /// <summary>
        /// Post order to go through every node from bottom to top, to check if something needs to rotate
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node CheckRotateNeed(Node root)
        {
            if (root.Left != null)
                CheckRotateNeed(root.Left);

            if (root.Right != null)
                CheckRotateNeed(root.Right);

            root = CheckHeight(root);

            return root;
        }

        /// <summary>
        /// Check the Height of the current node, to see if a rotation is needed
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node CheckHeight(Node node)
        {
            int height = 0;

            if (height < 0) Console.Write(height + " ");
            else if (height >= 0) Console.Write(" " + height + " ");

            if (height < -1 || height > 1)
                WhichRotation(node);

            return node;
        }

        private Node WhichRotation(Node node)
        {
            Console.WriteLine("Rotate " + node.value);
            return node;
        }
    }
}
