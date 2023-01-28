using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AvlTree
{
    internal class TreeRotate
    {
        /// <summary>
        /// Main nodes to rotate: node + node.Left  + node.Left.Left
        /// </summary>
        /// <param name="node">The node with the height differnence of 2 / -2</param>
        /// <returns></returns>
        public Node RotateRightRight(Node node)
        {
            if (node.Parent != null)
            {
                // Parent of the new root node = my parent
                node.Left.Parent = node.Parent;

                // Is the Root tree right or left of the parent
                if (node.Parent.value > node.value)
                    node.Parent.Left = node.Left;
                else node.Parent.Right = node.Left;
            }
            else node.Left.Parent = null;

            // save the right child of node.Left in temp and set its parent
            Node temp = null;
            if (node.Left.Right != null)
            {
                temp = node.Left.Right;
                temp.Parent = node;
            }

            // node.Left as Parent of node
            node.Left.Right = node;
            node.Parent = node.Left;

            // set the left child of root.Right (as temp or null)
            if (temp != null)
                node.Left = temp;
            else node.Left = null;

            return node.Parent;
        }

        /// <summary>
        /// Main nodes to rotate: node + node.Left + node.Left.Right
        /// </summary>
        /// <param name="node">The node with the height differnence of 2 / -2</param>
        /// <returns></returns>
        public Node RotateLeftRight(Node node)
        {
            // Set Parent of new root node
            if (node.Parent != null)
            {
                // Parent of the new root node = my parent
                node.Left.Right.Parent = node.Parent;

                // Is the Root tree right or left of the parent
                if (node.Parent.value > node.value)
                    node.Parent.Left = node.Left.Right;
                else node.Parent.Right = node.Left.Right;
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

        /// <summary>
        /// Main nodes to rotate: node + node.Right + node.Right.Left
        /// </summary>
        /// <param name="node">The node with the height differnence of 2 / -2</param>
        /// <returns></returns>
        public Node RotateRightLeft(Node node)
        {
            // Set Parent of new root node
            if (node.Parent != null)
            {
                // Parent of the new root node = my parent
                node.Right.Left.Parent = node.Parent;

                // Is the Root tree right or left of the parent
                if (node.Parent.value > node.value)
                    node.Parent.Left = node.Right.Left;
                else node.Parent.Right = node.Right.Left;
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

        /// <summary>
        /// Main nodes to rotate: node + node.Right + node.Right.Right
        /// </summary>
        /// <param name="node">The node with the height differnence of 2 / -2</param>
        /// <returns></returns>
        public Node RotateLeftLeft(Node node)
        {
            // Set Parent of new root node
            if (node.Parent != null)
            {
                // Parent of the new root node = my parent
                node.Right.Parent = node.Parent;

                // Is the Root tree right or left of the parent
                if (node.Parent.value > node.value)
                    node.Parent.Left = node.Right;
                else node.Parent.Right = node.Right;
            }
            else node.Right.Parent = null;

            // save the left child of node.Right in temp and set its parent
            Node temp = null;
            if (node.Right.Left != null)
            {
                temp = node.Right.Left;
                temp.Parent = node;
            }

            // node.Right as Parent of node
            node.Right.Left = node;
            node.Parent = node.Right;

            // set the right child of root.Left (as temp or null)
            if (temp != null)
                node.Right = temp;
            else node.Right = null;

            return node.Parent;
        }
    }
}
