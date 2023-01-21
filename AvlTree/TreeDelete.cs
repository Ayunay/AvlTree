using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    internal class TreeDelete
    {
        public void Delete(Node node, int value)
        {
            // if left child exists - move it up to the parents position
            if (node.Left != null)
            {
                Node tempParent = node.Parent;
                node = node.Left;
                node.Left = tempParent;
            }
            // if a right child exists (no matter the left child) - move the right one to the parents position
            else
            {
                Node tempParent = node.Parent;
                node = node.Right;
                node.Parent = tempParent;
            }
        }
    }
}
