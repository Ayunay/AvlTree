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
             * height = -2
             * 
             * Szenario 1 direct:
             * node has no right child
             * left child has a left child but no right child (--> LR-Rotation)
             * 
             * Szenario 2 indirect:
             * node has a right child, but this one has no more childs
             * left node has a left child but no right child (--> LR-Rotation)
             * left child of left child has one child (left or right)
             */

            if (node.Parent != null)
            {
                // Parent of the new root node = my parent
                node.Left.Parent = node.Parent; // child knows parent

                // Is the Root tree right or left of the parent
                if (node.Parent.value > node.value)
                    node.Parent.Left = node.Left;
                else node.Parent.Right = node.Left;  // parent knows child
            }
            else node.Left.Parent = null;

            node.Left.Right = node;     // I am the right child of the new node
            node.Parent = node.Left;    // and he is my parent

            node.Left = null;           // I dont have any childs (because my only child is my parent now)

            return node.Parent;
        }

        public Node RotateLeftRight(Node node)
        {
            /*
             * height = -2
             * 
             * Szenario 1 direct:
             * node has no right child
             * left child has a right child but no left child (--> RR-Rotation)
             * 
             * Szenario 2 indirect:
             * node has a right child, but this one has no more childs
             * left node has a right child but no left child (--> RR-Rotation)
             * right child of left child has one child (left or right)
             */

            if (node.Parent != null)
            {
                // Parent of the new root node = my parent
                node.Left.Right.Parent = node.Parent;       // new root knows parent

                // Is the Root tree right or left of the parent
                if (node.Parent.value > node.value)
                    node.Parent.Left = node.Left.Right;
                else node.Parent.Right = node.Left.Right;   // parent knows new root
            }
            else node.Left.Right.Parent = null;

            // save the child of node.Left.Right in temp
            Node temp = null;

            if (node.Left.Right.Right != null)
                temp = node.Left.Right.Right;
            else if (node.Left.Right.Left != null)
                temp = node.Left.Right.Left;

            if(temp != null)
            {
                // set the Parent of temp depending on its Relation to the new root (node.Left.Right)
                if (temp.value < node.Left.Right.value)
                    temp.Parent = node;
                else temp.Parent = node.Left;
            }

            // node.Left.Right as Parent of node.Left 
            node.Left.Parent = node.Left.Right;
            node.Left.Right.Left = node.Left;

            // node.Left.Right as Parent of node
            node.Parent = node.Left.Right;
            node.Left.Right.Right = node;
            
            // delete overflow (and later override one of them with temp)
            node.Parent.Left.Right = null;
            node.Left = null;

            if(temp != null)
            {
                // set temp node as child of root.Left or root.Right depending on its Relation to root.value
                if (temp.value < node.Parent.value)
                    node.Parent.Left.Right = temp;
                else node.Left = temp;
            }

            return node.Parent;
        }

        public Node RotateRightLeft(Node node)
        {
            /*
             * height = +2
             * 
             * Szenario 1 direct:
             * node has no left child
             * right child has a left child but no right child (--> LL-Rotation)
             * 
             * Szenario 2 indirect:
             * node has a left child, but this one has no childs
             * right node has a left child but no right child (--> LL-Rotation)
             * left child of right child has one child (left or right)
             */

            if (node.Parent != null)
            {
                // Parent of the new root node = my parent
                node.Right.Left.Parent = node.Parent;       // new root knows parent

                // Is the Root tree right or left of the parent
                if (node.Parent.value > node.value)
                    node.Parent.Left = node.Right.Left;
                else node.Parent.Right = node.Right.Left;   // parent knows new root
            }
            else node.Right.Left.Parent = null;

            // save the child of node.Right.Left in temp
            Node temp = null;

            if (node.Right.Left.Left != null)
                temp = node.Right.Left.Left;
            else if(node.Right.Left.Right != null)
                temp = node.Right.Left.Right;

            if(temp != null)
            {
                // set the Parent of temp depending on its Relation to the new root (node.Right.Left)
                if (temp.value < node.Right.Left.value)
                    temp.Parent = node;
                else temp.Parent = node.Right;
            }

            // node.Right.Left as Parent of node.Right 
            node.Right.Parent = node.Right.Left;
            node.Right.Left.Right = node.Right;

            // node.Right.Left as Parent of node
            node.Parent = node.Right.Left;
            node.Right.Left.Left = node;

            // delete overflow (and later override one of them with temp)
            node.Parent.Right.Left = null;
            node.Right = null;

            if(temp != null)
            {
                // set temp node as child of root.Left or root.Right depending on its Relation to root.value
                if (temp.value < node.Parent.value)
                    node.Right = temp;
                else node.Parent.Right.Left = temp;
            }

            return node.Parent;
        }

        public Node RotateLeftLeft(Node node)
        {
            /*
             * height = +2
             * 
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
            else node.Right.Parent = null;

            node.Right.Left = node;     // I am the right child of the new node
            node.Parent = node.Right;    // and he is my parent

            node.Right = null;           // I dont have any childs (because my only child is my parent now)

            return node.Parent;
        }
    }
}
