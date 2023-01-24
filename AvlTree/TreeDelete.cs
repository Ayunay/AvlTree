using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    internal class TreeDelete
    {
        public Node DeleteMain(Node root, Node deleteNode)
        {
            if (root.Left == null && root.Right == null) return null;   // if both childs are null
            else if (root.Left == null) return root.Right;              // if one child is null, the other gets the new root
            else if (root.Right == null) return root.Left;
            else return Delete(deleteNode);                             // if both childs exist, ...
        }

        /// <summary>
        /// Delete the root and make the child with the most height to the new root
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node Delete(Node node)
        {
            TreeCheck TreeCheck = new TreeCheck();

            // Check the total height of both child nodes
            int heightLeft = TreeCheck.NodeHeight(node.Left);   
            int heightRight = TreeCheck.NodeHeight(node.Right);

            // and make the one with the more height to the new root
            if (heightLeft > heightRight) 
                node = MakeLeftToRoot(node);
            else node = MakeRightToRoot(node);
            
            return node;
        }

        private Node MakeLeftToRoot(Node node)
        {
            // Search the highest number of the left side 
            Node temp = GoToRightNode(node);
            Console.WriteLine("TEMP: " +temp.value);

            return node;
        }

        private Node MakeRightToRoot(Node node)
        {
            // Search the lowest number of the right side
            Node temp = GoToLeftNode(node);
            Console.WriteLine("TEMP: " + temp.value);

            return node;
        }

        private Node GoToLeftNode(Node node)
        {
            if (node.Left != null) node = GoToLeftNode(node);
            return node;
        }
        
        private Node GoToRightNode(Node node)
        {
            if (node.Right != null) node = GoToRightNode(node);
            return node;
        }
    }
}
