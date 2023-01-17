using System.Diagnostics;
using System.Xml.Linq;

namespace AvlTree
{
    class Node
    {
        public int value;
        public Node Left;
        public Node Right;
        public Node Parent;
    }

    class Tree
    {
        public Node Insert(Node root, int value, Node parent)
        {
            if (root == null)
            {
                root = new Node();
                root.value = value;
                root.Parent = parent;
            }
            else if (value <= root.value)
            {
                //bool isRightChild = false;
                if (root.Parent != null)
                {
                    bool leftChild = CheckChild(root.Parent.Left);
                    bool rightChild = CheckChild(root.Parent.Right);

                    if (!rightChild && leftChild)
                    {
                        if (root.Parent.Right == null)
                        {
                            //Rotate(root.Parent, value);
                            root.Parent.Right = Insert(root.Parent.Right, root.Parent.value, root.Parent);
                        }

                        root.Parent.value = root.value;

                        root.value = value;
                    }
                    else if(rightChild && !leftChild)
                    {
                        if (root.Parent.Left == null)
                        {
                            //Rotate(root.Parent, value);
                            root.Parent.Left = Insert(root.Parent.Left, root.Parent.value, root.Parent);
                        }

                        root.Parent.value = root.value;

                        root.value = value;
                    }
                    else root.Left = Insert(root.Left, value, root);
                }
                else
                {
                    root.Left = Insert(root.Left, value, root);
                }
            }
            else if(value > root.value)
            {
                if (root.Parent != null)
                {
                    bool leftChild = CheckChild(root.Parent.Left);
                    bool rightChild = CheckChild(root.Parent.Right);

                    if (!rightChild && leftChild)
                    {
                        if (root.Parent.Right == null)
                        {
                            //Rotate(root.Parent, value);
                            root.Parent.Right = Insert(root.Parent.Right, root.Parent.value, root.Parent);
                        }

                        root.Parent.value = root.value;

                        root.value = value;
                    }
                    else if (rightChild && !leftChild)
                    {
                        if (root.Parent.Left == null)
                        {
                            //Rotate(root.Parent, value);
                            root.Parent.Left = Insert(root.Parent.Left, root.Parent.value, root.Parent);
                        }

                        root.Parent.value = root.value;

                        root.value = value;
                    }
                    else root.Right = Insert(root.Right, value, root);
                }
                else
                {
                    root.Right = Insert(root.Right, value, root);
                } 
            }

            return root;
        }

        public Node Rotate(Node root, int value)
        {
            return null;
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

        /// <summary>
        /// Search function?? as pre-order
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <param name="goLeft"></param>
        /// <returns></returns>
        public bool SearchPre(Node node, int value)
        {
            bool search = false;

            if (search) return true;
            else if (node.value == value) search = true;
            else if (node.value < value)
            {
                search = SearchPre(node.Left, value);
                search = SearchPre(node.Right, value);
            }

            return search;
        }

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
            if (node.Left != null)
                TraversIn(node.Left);
            if (node != null)
                Console.WriteLine(node.value);
            if (node.Right != null)
                TraversIn(node.Right);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Stopwatch watch = new Stopwatch();
            Tree tree = new Tree();

            Node root = null;

            int size = 10;
            int[] zahlen = new int[size];

            Console.WriteLine("Starte die Füllung des Arrays...");
            watch.Start();

            for (int i = 0; i < zahlen.Length; i++)
            {
                zahlen[i] = random.Next(size);
            }

            watch.Stop();
            Console.WriteLine($"Es hat {watch.ElapsedMilliseconds} Millisekunden gedauert");

            Console.WriteLine("\nStarte die Insertion des Arrays in einen Baum");
            watch = Stopwatch.StartNew();

            for (int i = 0; i < zahlen.Length; i++)
            {
                root = tree.Insert(root, zahlen[i], null);
            }

            watch.Stop();
            Console.WriteLine($"Es hat {watch.ElapsedMilliseconds} Millisekunden gedauert\n");

            tree.TraversIn(root);
            Console.ReadKey();
        }



            //bool gameFlow = true;

            //while (gameFlow)
            //{
                //Outsorced outsorced = new Outsorced();
                //EditTree editTree = new EditTree();
                
                // Menu "Do you want to play the Game or exit?"
                //gameFlow = outsorced.MenuSelector();

                //if (gameFlow)
                //{
                    /*
                    char edit = outsorced.HowToEditTree();

                    switch (edit)
                    {
                        case '1':
                            editTree.Add();
                            break;

                        case '2':
                            editTree.Delete();
                            break;

                        case '3':
                            editTree.Search();
                            break;
                    }
                    */
                //}
                //Console.Clear();
            //}
        
    }
}