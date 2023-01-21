using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    internal class TreeAdd
    {
        public Node Add(Node node, int value)
        {
            if (node == null)
            {
                node = new Node();
                node.value = value;
            }
            else if (value <= node.value)
            {
                node.Left = Add(node.Left, value);
            }
            else if (value > node.value)
            {
                node.Right = Add(node.Right, value);
            }

            return node;
        }

        /* ERSTER VERSUCH
        public Node Insert(Node node, int value, Node parent)
        {
            // if there is no node, create one
            if (node == null)
            {
                node = new Node();
                node.value = value;
                node.Parent = parent;
            }
            // if the value is smaler than the node
            else if (value <= node.value)
            {
                // if there is a parent
                if (node.Parent != null)
                {
                    // check if he has childs
                    bool leftChild = CheckChild(node.Parent.Left);
                    bool rightChild = CheckChild(node.Parent.Right);

                    // when there is only a left child - rotate right 
                    if (!rightChild && leftChild)
                    {
                        if (node.Parent.Right == null)
                            node.Parent.Right = Insert(node.Parent.Right, node.Parent.value, node.Parent);

                        node.Parent.value = node.value;
                        node.value = value;
                    }
                    // when there is only a right child - rotate left
                    else if (rightChild && !leftChild)
                    {
                        if (node.Parent.Left == null)
                            node.Parent.Left = Insert(node.Parent.Left, node.Parent.value, node.Parent);

                        node.Parent.value = node.value;
                        node.value = value;
                    }
                    // when there are two or no childs, continue
                    else node.Left = Insert(node.Left, value, node);
                }
                else node.Left = Insert(node.Left, value, node);    // else create a new left child
            }
            // if the value is bigger than the node
            else if (value > node.value)
            {
                // if there is a parent
                if (node.Parent != null)
                {
                    // check if he has childs
                    bool leftChild = CheckChild(node.Parent.Left);
                    bool rightChild = CheckChild(node.Parent.Right);

                    // when there is only a left child - rotate right 
                    if (!rightChild && leftChild)
                    {
                        if (node.Parent.Right == null)
                            node.Parent.Right = Insert(node.Parent.Right, node.Parent.value, node.Parent);

                        node.Parent.value = node.value;
                        node.value = value;
                    }
                    // when there is only a right child - rotate left
                    else if (rightChild && !leftChild)
                    {
                        if (node.Parent.Left == null)
                            node.Parent.Left = Insert(node.Parent.Left, node.Parent.value, node.Parent);

                        node.Parent.value = node.value;
                        node.value = value;
                    }
                    // when there are two or no childs, continue
                    else node.Right = Insert(node.Right, value, node);
                }
                else node.Right = Insert(node.Right, value, node);  // else chreate a new right child
            }

            return node;
        }

        /// <summary>
        /// Checks if the inserted Child is existing
        /// </summary>
        /// <param name="child">child</param>
        /// <returns>true = child || false = no child</returns>
        public bool CheckChild(Node child)
        {
            if (child == null) return false;
            else return true;
        }
        */
    }
}
