using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    public class TreeEdit
    {
        TreeAdd Add = new TreeAdd();
        TreeCheck Check = new TreeCheck();
        TreeSearch Search = new TreeSearch();
        TreeDelete Delete = new TreeDelete();
        TreePrint Print = new TreePrint();
        TreePrintTravers PrintTravers = new TreePrintTravers();
        Outsorced Outsorced = new Outsorced();

        private delegate void PrintDelegate(Node root);

        /// <summary>
        /// Add a node to the tree
        /// </summary>
        /// <param name="root">The root of the tree</param>
        /// <returns></returns>
        public Node AddNode(Node root)
        {
            // User Feedback
            Console.WriteLine(Outsorced.addSign);
            Console.WriteLine("\nInsert a number you want to add to the tree.\n" +
                              "The number has to be a full number (1 not 1.5) and greater than 0.");
            if (root != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nYour actual tree:");
                Print.PrintTreeMain(root, 31);
                Console.ResetColor();
            }

            // USER INPUT
            int newNode = Input();

            // User Feedback
            Console.Clear();
            Console.WriteLine(Outsorced.addSign);
            if (root != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Your old tree:");
                Print.PrintTreeMain(root, 31);
            }
            Outsorced.WriteColor(true, ConsoleColor.Magenta, $"Add number {newNode} to the tree.");

            // ADD AND ROTATE
            root = Add.Add(root, newNode);

            // Print final tree
            PrintTreeLines(root);

            return root;
        }

        /// <summary>
        /// Search a node in the tree
        /// </summary>
        /// <param name="root">The root of the tree</param>
        /// <returns></returns>
        public void SearchNode(Node root)
        {
            // User Input
            Console.WriteLine(Outsorced.addSign);
            Console.WriteLine("\nInsert a number you want to search in the tree.\n");

            int searchValue = Input();

            Console.Clear();
            Outsorced.WriteColor(true, ConsoleColor.Magenta, $"Search number {searchValue} in the tree.");

            // SEARCH
            int count = Search.SearchValue(root, searchValue);

            if (count == 0)
                Outsorced.WriteColor(true, ConsoleColor.Red, "The number does not exist in the tree.");
            else Outsorced.WriteColor(true, ConsoleColor.Green, $"The number is in the tree {count} times.");

            // Print final tree
            PrintTreeLines(root);
        }

        /// <summary>
        /// Delete a node of the tree and resort it so that there is no gap
        /// </summary>
        /// <param name="root">The root of the tree</param>
        /// <returns></returns>
        public Node DeleteNode(Node root)
        {
            // User Input
            Console.WriteLine(Outsorced.addSign);
            Console.WriteLine("\nInsert a number you want to delete from the tree.");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Your actual tree:");
            Print.PrintTreeMain(root, 31);
            Console.ResetColor();

            // User Input and DELETE
            Node deleteNode = null;
            int deleteValue = 0;

            while (deleteNode == null)
            {
                deleteValue = Input();
                deleteNode = Search.SearchNode(root, deleteValue);
            }
            root = Delete.Delete(root, deleteNode);

            //Console.Clear();
            Outsorced.WriteColor(true, ConsoleColor.Magenta, $"Delete number {deleteValue} from the tree.\n");


            // Print final tree
            if (root != null) PrintTreeLines(root);
            else Outsorced.WriteColor(true, ConsoleColor.Cyan, "Your Tree is empty");

            return root;
        }

        /// <summary>
        /// Print out the whole tree and a sorted list of all numbers in the tree
        /// </summary>
        /// <param name="root">The root of the tree</param>
        /// <returns></returns>
        public void PrintTree(Node root)
        {
            Console.WriteLine(Outsorced.printSign);

            Outsorced.WriteColor(true, ConsoleColor.DarkYellow, "TREE NUMBERS (Pre-Order):");
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintTravers.TraversPre(root);

            Outsorced.WriteColor(true, ConsoleColor.DarkBlue, "\nTREE NUMBERS SORTED:");
            Console.ForegroundColor = ConsoleColor.Blue;
            int count = PrintTravers.TraversInCount(root);

            Outsorced.WriteColor(true, ConsoleColor.Green, $"\nThere are {count} nodes in the tree.");
            Outsorced.WriteColor(true, ConsoleColor.Green, $"The height of the tree is {Check.NodeHeight(root)}.\n");
            Console.ResetColor();

            PrintTreeLines(root);
        }

        public void PrintTreeDelegate(Node root)
        {
            PrintDelegate printDel = new PrintDelegate(DelegateMethod);
            printDel += PrintTravers.TraversPre;
            printDel += DelegateMethod;
            printDel += PrintTravers.TraversPost;
            printDel += DelegateMethod;
            printDel += PrintTravers.TraversIn;

            Console.WriteLine("First print Tree in Pre-Order, then in Post-Order, then in In-Order");
            printDel.Invoke(root);

            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Just a Method to make the PrintTreeDelegate Method nicer
        /// </summary>
        /// <param name="root"></param>
        private void DelegateMethod(Node root)
        {
            Random random = new Random();
            int colorInt = random.Next(1, 7);
            ConsoleColor color = ConsoleColor.White;

            switch (colorInt)
            {
                case 1:
                    color = ConsoleColor.Blue;
                    break;

                case 2:
                    color = ConsoleColor.Green;
                    break;

                case 3:
                    color = ConsoleColor.DarkYellow;
                    break;

                case 4:
                    color = ConsoleColor.Red;
                    break;

                case 5:
                    color = ConsoleColor.Magenta;
                    break;

                case 6:
                    color = ConsoleColor.Cyan;
                    break;
            }

            Console.ForegroundColor = color;
            Console.WriteLine();
        }

        /// <summary>
        /// Let the user insert a number (has to be positive and an int)
        /// </summary>
        /// <returns></returns>
        private int Input()
        {
            int value = 0;
            string input;
            bool validInput = false;

            while (!validInput)
            {
                input = Console.ReadLine();

                if (!int.TryParse(input, out value) || value < 0)
                    Outsorced.WriteColor(true, ConsoleColor.DarkRed, "This is an invalid input.");
                else validInput = true;
            }

            return value;
        }

        /// <summary>
        /// Print the actual tree
        /// </summary>
        /// <param name="root"></param>
        private void PrintTreeLines(Node root)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nYOUR TREE:");
            Print.PrintTreeMain(root, 31);
            Console.ResetColor();

            Outsorced.WriteColor(true, ConsoleColor.DarkGray, "\nPress any key to continue");
            Console.ReadKey();

            Console.Clear();
        }
    }
}
