using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    internal class TreeAdd
    {
        TreeCheck Check = new TreeCheck();
        private bool parentExist = false;
        private Node tempParent;

        /// <summary>
        /// Add a new node to the tree: Sort the number to its right position and eventually rotate the tree to be balanced
        /// </summary>
        /// <param name="root">The root of the existing tree</param>
        /// <param name="value">The number that should be added</param>
        /// <returns></returns>
        public Node Add(Node root, int value)
        {
            root = Insert(root, value);
            root = Check.CheckRotateNeed(root);

            return root;
        }

        /// <summary>
        /// Add the node to the tree and sort it after its value (does not rotate yet)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Node Insert(Node root, int value)
        {
            // if there is no node, create one
            if (root == null)
            {
                root = new Node();
                root.value = value;

                if (parentExist)        // if node has a parent (only false when its the first root)
                    root.Parent = tempParent;   // set the saved Node as Parent 
                parentExist = false;    // reset boolean for the next Insertion
            }
            // if the value is smaller than the node, go to the left child
            else if (value < root.value)
            {
                parentExist = true;
                tempParent = root;      // save Parent to say the Child I am your parent
                root.Left = Add(root.Left, value);
            }
            // if the value is greater than the node, go to the right child
            else if (value >= root.value)
            {
                parentExist = true;
                tempParent = root;
                root.Right = Add(root.Right, value);
            }

            return root;
        }
    }
}
