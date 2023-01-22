using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AvlTree
{
    /// <summary>
    /// RightRight = node + node.Left  + node.Left
    /// LeftRight  = node + node.Left  + node.Right
    /// RightLeft  = node + node.Right + node.Left
    /// LeftLeft   = node + node.Right + node.Right
    /// </summary>
    internal class TreeRotate
    {
        public Node RotateRightRight(Node node)
        {

            return node;
        }

        public Node RotateLeftRight(Node node)
        {

            return node;
        }

        public Node RotateRightLeft(Node node)
        {

            return node;
        }

        public Node RotateLeftLeft(Node node)
        {

            return node;
        }
    }
}
