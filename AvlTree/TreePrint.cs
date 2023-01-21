using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Console.WriteLine(node.value);

            if (node.Right != null)
                TraversIn(node.Right);
        }

        public void PrintTree01()
        {

        }
    }
}
