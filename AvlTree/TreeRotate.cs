using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AvlTree
{
    /// <summary>
    /// RightRight = node + node.Left  + node.Left
    /// LeftRight  = node + node.Left  + node.Right
    /// RightLeft  = node + node.Right + node.Left
    /// LeftLeft   = node + node.Right + node.Right
    /// </summary>
    internal class TreeRotate
    {
        public Node RotateRightRight(Node node)
        {
            /*
             * Szenario 1 direct:
             * node has no right child
             * left child has a left child but no right child (--> LR-Rotation)
             * 
             * Szenario 2 indirect:
             * node has a right child, but this one has no more childs
             * left node has a left child but no right child (--> LR-Rotation)
             * left child of left child has one child (left or right)
             */

            if(node.Parent != null)
            {
                // Parent of the new root node = my parent
                node.Left.Parent = node.Parent; // child knows parent

                // Is the ROot tree right or left of the parent
                if (node.Parent.value > node.value) 
                    node.Parent.Left = node.Left;
                else node.Parent.Right = node.Left;  // parent knows child
            }

            node.Left.Right = node;     // I am the right child of the new node
            node.Parent = node.Left;    // and he is my parent

            node.Left = null;           // I dont have any childs (because my only child is my parent now)

            return node.Parent;
        }

        public Node RotateLeftRight(Node node)
        {
            

            return node;
        }

        public Node RotateRightLeft(Node node)
        {

            return node;
        }

        public Node RotateLeftLeft(Node node)
        {
            /*
             * Szenario 1 direct:
             * node has no left child
             * right child has a right child but no left child (--> RL-Rotation)
             * 
             * Szenario 2 indirect:
             * node has a left child, but this one has no childs
             * right node has a right child but no left child (--> RL-Rotation)
             * right child of right child has one child (left or right)
             */

            if (node.Parent != null)
            {
                // Parent of the new root node = my parent
                node.Right.Parent = node.Parent; // child knows parent

                // Is the ROot tree right or left of the parent
                if (node.Parent.value > node.value)
                    node.Parent.Left = node.Right;
                else node.Parent.Right = node.Right;  // parent knows child
            }

            node.Right.Left = node;     // I am the right child of the new node
            node.Parent = node.Right;    // and he is my parent

            node.Right = null;           // I dont have any childs (because my only child is my parent now)

            return node.Parent;
        }
    }
}
