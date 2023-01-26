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
            TreePrint Print = new TreePrint();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Print.PrintTreeMain(node, 31);

            // Search the highest number of the left side --> temp
            Node temp = GoToRightNode(node);
            Console.WriteLine("Temp: " + temp.value);

            Node tempParent = GoToRightNode(node).Parent;
            Console.WriteLine("TempParent: " + tempParent.value);

            (temp, Node tempChild) = CreateTempLeft(node, temp);

            Console.WriteLine("TempChild: " + tempChild.value);

            tempParent.Right = tempChild;

            
            Print.PrintTreeMain(node, 31);
            Console.ResetColor();

            /*
            // left child of temp on the position of temp (temp has no right child and it is the right child of its parent)
            if (temp.Left != null)
            {
                temp.Left.Parent = temp.Parent;
                temp.Parent.Right = temp.Left;
            }
            else temp.Parent.Right = null;

            node.value = temp.value;

            node = SwitchTempToRoot(node, temp);
            */
            return node;
        }

        private (Node, Node) CreateTempLeft(Node node, Node temp)
        {
            // SET PARENT
            if (node.Parent != null)
            {
                // Parent of the new root node = my parent
                temp.Parent = node.Parent; // child knows parent

                // Is the Root tree right or left of the parent
                if (node.Parent.value > node.value)
                    node.Parent.Left = temp;
                else node.Parent.Right = temp;  // parent knows child
            }
            else temp.Parent = null;

            // Save Child of temp (he can only have one child)
            Node tempChild = null;
            if (temp.Left != null) tempChild = temp.Left;
            else if (temp.Right != null) tempChild = temp.Right;
            if (tempChild.Parent != null) tempChild.Parent = null;  // Make sure that "temp" is out of the way

            temp.Left = node.Left;
            node.Left.Parent = temp;
            temp.Right = node.Right;
            node.Right.Parent = temp;

            return (temp, tempChild);
        }

        private Node MakeRightToRoot(Node node)
        {
            // Search the lowest number of the right side
            Node temp = GoToLeftNode(node);
            Console.WriteLine("TEMP: " + temp.value);



            /*
            // right child of temp on the position of temp (temp has no left child and it is the left child of its parent)
            if (temp.Right != null)
            {
                temp.Right.Parent = temp.Parent;
                temp.Parent.Left = temp.Right;
            }
            else temp.Parent.Left = null;
            
            int tempValue = temp.value;

            temp.Parent = SwitchTempChild(temp.Parent, temp.Right, false);

            node.value = tempValue;

            node = SwitchTempToRoot(node, temp);
            */
            return node;
        }
        /*
        private Node SwitchTempChild(Node parent, Node child, bool leftTree)
        {
            child.Parent = parent;
            if (leftTree) parent.Right = child;
            else parent.Left = child;

            return parent;
        }
        
        private Node SwitchTempToRoot(Node node, Node temp)
        {
            // Connect node.Parent and temp
            if (node.Parent != null)
            {
                // Parent of the new root node = my parent
                temp.Parent = node.Parent; // child knows parent

                // Is the Root tree right or left of the parent
                if (node.Parent.value > node.value)
                    node.Parent.Left = temp;
                else node.Parent.Right = temp;  // parent knows child
            }
            else temp.Parent = null;

            // temp mit den childs ver node verbinden
            if (node.Right != null)
            {
                node.Right.Parent = temp;
                temp.Right = node.Right;
            }
            else temp.Right = null;

            if (node.Left != null)
            {
                node.Left.Parent = temp;
                temp.Left = node.Left;
            }
            else temp.Left = null;

            // node endgültig mit temp überschreiben
            node = temp;

            return node;
        }
        */
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
