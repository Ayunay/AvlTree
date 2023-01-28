using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    internal class TreeDelete
    {
        /// <summary>
        /// Deletes a node in the tree and sort the rest of the tree so that there is no gap the the position of the deleted node
        /// </summary>
        /// <param name="root">The root of the Tree</param>
        /// <param name="deleteNode">The node that should be deleted</param>
        /// <returns></returns>
        public Node Delete(Node root, Node deleteNode)
        {
            if (root.Left == null && root.Right == null) return null;   // if both childs are null
            else if (root.Left == null) return root.Right;              // if one child is null, the other gets the new root
            else if (root.Right == null) return root.Left;
            else return DeleteCheck(deleteNode);                        // if both childs exist, make one of then to the new root
        }

        /// <summary>
        /// Delete the root and make the child with the most height to the new root
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node DeleteCheck(Node node)
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

        /// <summary>
        /// Move the left-child-tree of the  node up to the position of the deleted node (because it has more height than the right tree)
        /// </summary>
        /// <param name="node">The node which should be deleted</param>
        /// <returns>The Node on the position of the deleted node</returns>
        private Node MakeLeftToRoot(Node node)
        {
            // Search the highest number of the left side --> temp
            Node temp = GoToRightNode(node.Left);
            
            Node tempParent = temp.Parent;

            // Move the child of temp 
            if (tempParent != node)
                tempParent.Right = SetTempChild(temp);  // as right child of temp.Parent
            else node.Left = SetTempChild(temp);        // as left child of root / new temp

            // create Temp (the new node) -- note: temp does not exist in the node-tree, there it is already overwritten with its child
            node = CreateTemp(node, temp);

            return node;
        }

        /// <summary>
        /// Move the right-child-tree of the node up to the position of the deleted node
        /// </summary>
        /// <param name="node">The node which should be deleted</param>
        /// <returns>The Node on the position of the deleted node</returns>
        private Node MakeRightToRoot(Node node)
        {
            // Search the highest number of the right side --> temp
            Node temp = GoToLeftNode(node.Right);

            Node tempParent = temp.Parent;

            // Move the child of temp 
            if (tempParent != node)
                tempParent.Left = SetTempChild(temp);   // as left child of temp.Parent
            else node.Right = SetTempChild(temp);       // as right child of node / new Temp

            // create Temp (the new node) -- note: temp does not exist in the node-tree, there it is already overwritten with its child
            node = CreateTemp(node, temp);

            return node;
        }

        /// <summary>
        /// If temp has a child: set the parent of the child to the parent of temp to overwrite temp with its child
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private Node SetTempChild(Node temp)
        {
            // Save Child of temp (he can only have one child)
            Node tempChild = null;
            if (temp.Left != null) tempChild = temp.Left;
            else if (temp.Right != null) tempChild = temp.Right;

            // Set temp.Parent to child.Parent
            if (tempChild.Parent != null) tempChild.Parent = temp.Parent;

            return tempChild;
        }

        /// <summary>
        /// Temp = Node (set all node connections to temp: parent and childs)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        private Node CreateTemp(Node node, Node temp)
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

            // SET CHILDS
            temp.Left = node.Left;
            node.Left.Parent = temp;

            temp.Right = node.Right;
            node.Right.Parent = temp;

            return temp;
        }

        /// <summary>
        /// Return the "leftest" node - to get the smallest number of the right tree
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node GoToLeftNode(Node node)
        {
            if (node.Left != null) node = GoToLeftNode(node.Left);
            else if (node.Left == null) return node;
            return node;
        }
        
        /// <summary>
        /// Return the "rightest" node - to get the highest number of the left tree
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node GoToRightNode(Node node)
        {
            if (node.Right != null) node = GoToRightNode(node.Right);
            else if (node.Right == null) return node;
            return node;
        }
    }
}
