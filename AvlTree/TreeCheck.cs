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
        #region Check Height of all Nodes to check if we need to rotate

        TreeRotate Rotate = new TreeRotate();
        TreePrint Print = new TreePrint();

        /// <summary>
        /// Post order to go through every node from bottom to top, to check if something needs to rotate
        /// </summary>
        /// <param name="root">The Root of the Tree</param>
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
        /// <param name="node">The actual node to check</param>
        /// <returns></returns>
        private Node CheckHeight(Node node)
        {
            int heightLeft = 0;
            int heightRight = 0;

            if(node.Left != null)
                heightLeft = NodeHeight(node.Left);
            if(node.Right != null)
                heightRight = NodeHeight(node.Right);

            int height = heightRight - heightLeft;

            if (height == -2 || height == 2)
                node = WhichRotation(node, height);

            return node;
        }

        /// <summary>
        /// Go through every child of every child of the node, to get the height balance of the node
        /// </summary>
        /// <param name="node">the node to check the height</param>
        /// <param name="height">insert 0</param>
        /// <returns></returns>
        public int NodeHeight(Node node, int height = 0)
        {
            height++;
            int heightLeft = height;
            int heightRight = height;

            if (node.Left != null)
                heightLeft += NodeHeight(node.Left);
            if (node.Right != null)
                heightRight += NodeHeight(node.Right);

            // take the higher value (either left or right) to avoid double the height at 2 childs
            height = heightLeft > heightRight ? heightLeft : heightRight;   

            return height;
        }

        #endregion

        /// <summary>
        /// Checks which rotation has to be done with an imbalanced node
        /// </summary>
        /// <param name="node">The imbalanced node</param>
        /// <param name="height">The height of the node (should be -2 or 2)</param>
        /// <returns></returns>
        private Node WhichRotation(Node node, int height)
        {
            /*
             * RightRight = node + node.Left + node.Left
             * RightLeft = node + node.Right + node.Left
             * LeftLeft = node + node.Right + node.Right
             * LeftRight = node + node.Left + node.Right
             */

            //PRINT TREE
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nROTATE node {node.value} cause of height {height}");
            Console.ResetColor();

            // 2nd = Right Rotation
            if (height == -2)        
            {
                // if problem is directly at node (when node has only one child)
                if (node.Right == null)
                {
                    //one of them has to be null or there would be no imbalance
                    if (node.Left.Left != null) 
                        node = Rotate.RotateRightRight(node);  //RR
                    else if (node.Left.Right != null)
                        node = Rotate.RotateLeftRight(node);   //LR
                }
                // if problem is down the tree (when node has two childs)
                else if (node.Left.Left.Left != null || node.Left.Left.Right != null)
                    node = Rotate.RotateRightRight(node);      //RR
                else if (node.Left.Right.Left != null || node.Left.Right.Right != null)
                    node = Rotate.RotateLeftRight(node);       //LR
            }
            // 2nd = Left Rotation
            else if (height == 2)   
            {
                // if problem is directly at node (when node has only one child)
                if (node.Left == null)
                {
                    //one of them has to be null or there would be no imbalance
                    if (node.Right.Left != null)
                        node = Rotate.RotateRightLeft(node);   //RL
                    else if (node.Right.Right != null)
                        node = Rotate.RotateLeftLeft(node);    //LL
                }
                // if problem is down the tree (when node has two childs)
                else if (node.Right.Right.Left != null || node.Right.Right.Right != null)
                    node = Rotate.RotateLeftLeft(node);        //LL
                else if (node.Right.Left.Left != null || node.Right.Left.Right != null)
                    node = Rotate.RotateRightLeft(node);       //RL
            }

            return node;
        }
    }
}
