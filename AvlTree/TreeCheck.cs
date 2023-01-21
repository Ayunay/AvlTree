using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    internal class TreeCheck
    {
        /// <summary>
        /// Search for a number in the Tree
        /// </summary>
        /// <param name="root">Insert the root of the tree</param>
        public void Search(Node root)
        {
            string searchString = Console.ReadLine();
            int searchNumber;
            int.TryParse(searchString, out searchNumber);

            bool exists = SearchPre(root, searchNumber);
            if (exists) Console.WriteLine("Number exists");
            else Console.WriteLine("Number does not exists");
        }

        /// <summary>
        /// Search function?? as pre-order -- does not work yet
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <param name="goLeft"></param>
        /// <returns></returns>
        public bool SearchPre(Node node, int value)
        {
            if (node.value == null) return false;

            else if (node.value < value)
                return SearchPre(node.Left, value);

            else if (node.value > value)
                return SearchPre(node.Right, value);

            else return true;   // if node.value = value
        }
    }
}
