using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AvlTree
{
    internal class TreePrint
    {
        /// <summary>
        /// Print the whole Tree in Pre-Order
        /// </summary>
        /// <param name="node">The Root node</param>
        public void TraversPre(Node node)
        {
            if (node == null) return;

            Console.WriteLine(node.value);

            TraversPre(node.Left);
            TraversPre(node.Right);
        }

        /// <summary>
        /// Print the whole Tree in In-Order (sorted from small to big)
        /// </summary>
        /// <param name="node">The Root node</param>
        public void TraversIn(Node node)
        {
            if (node == null) return;

            if (node.Left != null)
                TraversIn(node.Left);

            Console.Write($"{node.value} ");

            if (node.Right != null)
                TraversIn(node.Right);
        }

        #region Print Tree as Tree Format
        /// <summary>
        /// Call the "PrintTree" Method to print the Tree in Tree Format (up-down)
        /// It can be valued in different sizes, depending on the amount of nodes in the tree
        /// Valid sizes are:
        /// - Height 0: 1
        /// - Height 1: 3
        /// - Height 2: 7
        /// - Height 3: 15
        /// - Height 4: 31
        /// Empty nodes in the tree are shown as the string "emptyNode"
        /// </summary>
        
        string emptyNode = " . ";   // Important: Chose a symbol and leave one space before and after
        
        /// <summary>
        /// Prints the Tree in a Tree form
        /// !! Note: its possible that some nodes are not shown, because your tree is too long (it can only show 5 height level)
        /// or the tree has more weight on one side ... to avoid that, use the maximum size of the tree (count = 31)
        /// </summary>
        /// <param name="root">root of the tree</param>
        /// <param name="count">amount of nodes in the tree ... or: 1 / 3 / 7 / 15 / 31 for the heights</param>
        public void PrintTree(Node root, int count)
        {
            // make sure that the count variable is one of the numbers, no matter what was inserted
            if (count <= 1) count = 1;
            else if (count <= 3) count = 3;
            else if (count <= 7) count = 7;
            else if (count <= 15) count = 15;
            else if (count <= 31) count = 31;
            else if (count > 31) count = 31;

            count--;    // count = 30

            // HEIGHT 0
            ForEmpty(count);   // 30
            PrintNode(root);
            Console.WriteLine();

            // HEIGHT 1
            if(count <= 30)
            {
                PrintChilds(root, count, true);         // 30
                Console.WriteLine();
            }
            count = (count / 2) - 1;                // count = 14

            // HEIGHT 2
            if(count <= 14)
            {
                PrintChilds(root.Left, count, true);    // 14
                PrintChilds(root.Right, count, false);  // 14
                Console.WriteLine();
            }
            count = (count / 2) - 1;                // count = 6

            if(count <= 6)
            {
                PrintTreeDown(root.Left, count, true);  // 6
                PrintTreeDown(root.Right, count, false);// 6
                Console.WriteLine();
            }
            count = (count / 2) - 1;                // count = 2

            if (count <= 2)
            {
                PrintTree4(root.Left, count);   // 2
                PrintTree4(root.Right, count);  // 2
            }
        }

        /// <summary>
        /// Intermediate Step for the height 4
        /// </summary>
        /// <param name="node"></param>
        /// <param name="count"></param>
        private void PrintTree4(Node node, int count)
        {
            // HEIGHT 4
            PrintTreeDown(node.Left, count, false);
            PrintTreeDown(node.Right, count, false);
        }

        /// <summary>
        /// Intermediate Step for the height 3 and 4 (no direct childs/grandchilds of the root)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="count"></param>
        /// <param name="first"></param>
        private void PrintTreeDown(Node node, int count, bool first)
        {
            // HEIGHT 3 / 4
            if (node.Left != null)
                PrintChilds(node.Left, count, first);     // 6
            else
            {
                ForEmpty(count / 2);
                Console.Write(emptyNode);
                ForEmpty(count - 1);
                Console.Write(emptyNode);

            }
            if (node.Right != null)
                PrintChilds(node.Right, count, false);      // 6
            else
            {
                ForEmpty(count - 1);
                Console.Write(emptyNode);
                ForEmpty(count - 1);
                Console.Write(emptyNode);

            }
        }

        /// <summary>
        /// Prints the left and right child of the inserted node
        /// </summary>
        /// <param name="root"></param>
        /// <param name="count"></param>
        /// <param name="first"></param>
        private void PrintChilds(Node node, int count, bool first)
        {
            // count = 14 | 6 | 2

            // LEFT NODE
            if (first) ForEmpty(count / 2); // 6 | 2 | 0
            else ForEmpty(count - 1);       // 13 | 5 | 1
        
            if(node.Left != null)
                PrintNode(node.Left);
            else
            {
                Console.Write(emptyNode);
            }

            // RIGHT NODE
            ForEmpty(count - 1);            // 13 | 5 | 1

            if(node.Right != null)
                PrintNode(node.Right);
            else
            {
                Console.Write(emptyNode);
            }
        }

        /// <summary>
        /// For Loop with (i = 0; i < max; i++) Console.Write(" ");
        /// </summary>
        /// <param name="max">loop counts</param>
        private void ForEmpty(int max)
        {
            for(int i = 0; i < max; i++)
            {
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Print the inserted node (its always XXX --> X1X / X10 / 100)
        /// </summary>
        /// <param name="node"></param>
        private void PrintNode(Node node)
        {
            if (node == null)
                Console.Write(emptyNode);
            else if (node.value < 10)
                Console.Write($" {node.value} ");
            else if (node.value < 100)
                Console.Write($" {node.value}");
        }

        #endregion
    }
}
