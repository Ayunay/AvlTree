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
        #region Search a Number

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
                count = SearchPre(node.Left, value, count);

            else if (node.value >= value && node.Right != null)
                count = SearchPre(node.Right, value, count);

            return count;
        }

        #endregion

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
                heightLeft = NodeHeight(node.Left, 0);
            if(node.Right != null)
                heightRight = NodeHeight(node.Right, 0);

            int height = heightRight - heightLeft;

            /*
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if (height == -2 || height == 2) 
                Console.ForegroundColor = ConsoleColor.Red;
            if (height < 0) Console.Write(height + " ");
            else if (height >= 0) Console.Write(" " + height + " ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            */
            if (height == -2 || height == 2)
                WhichRotation(node, height);

            return node;
        }

        /// <summary>
        /// Go through every child of every child of the node, to get the height balance of the node
        /// </summary>
        /// <param name="node">the node to check the height</param>
        /// <param name="height">insert 0</param>
        /// <returns></returns>
        private int NodeHeight(Node node, int height)
        {
            height++;
            int heightLeft = height;
            int heightRight = height;

            if (node.Left != null)
                heightLeft += NodeHeight(node.Left, 0);
            if (node.Right != null)
                heightRight += NodeHeight(node.Right, 0);

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
            Console.ResetColor();
            Console.WriteLine($"\n n:{node.value} \n");
            if (node.Parent != null)
                Print.PrintTree(node.Parent, 31);
            else Print.PrintTree(node, 31);
            Console.WriteLine("\n");
            
            // 2nd = Right Rotation
            if (height == -2)        
            {
                // if problem is directly at node (when node has only one child)
                if (node.Right == null)
                {
                    //one of them has to be null or there would be no imbalance
                    if (node.Left.Left != null) 
                        Rotate.RotateRightRight(node);  //RR
                    else if (node.Left.Right != null) 
                        Rotate.RotateLeftRight(node);   //LR
                }
                // if problem is down the tree (when node has two childs)
                else if (node.Left.Left.Left != null || node.Left.Left.Right != null) 
                    Rotate.RotateRightRight(node);      //RR
                else if (node.Left.Right.Left != null || node.Left.Right.Right != null) 
                    Rotate.RotateLeftRight(node);       //LR
            }
            // 2nd = Left Rotation
            else if (height == 2)   
            {
                // if problem is directly at node (when node has only one child)
                if (node.Left == null)
                {
                    //one of them has to be null or there would be no imbalance
                    if (node.Right.Left != null) 
                        Rotate.RotateRightLeft(node);   //RL
                    else if (node.Right.Right != null) 
                        Rotate.RotateLeftLeft(node);    //LL
                }
                // if problem is down the tree (when node has two childs)
                else if (node.Right.Right.Left != null || node.Right.Right.Right != null) 
                    Rotate.RotateLeftLeft(node);        //LL
                else if (node.Right.Left.Left != null || node.Right.Left.Right != null) 
                    Rotate.RotateRightLeft(node);       //RL
            }

            Console.WriteLine($"\n fix: {node.Parent.value} \n");
            if (node.Parent.Parent != null)
                Print.PrintTree(node.Parent.Parent, 31);
            else 
                Print.PrintTree(node.Parent, 31);
            Console.WriteLine("\n");

            return node;
        }
    }
}
