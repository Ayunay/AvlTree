using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    internal class TreeEdit
    {
        TreeAdd Add = new TreeAdd();
        TreeCheck Check = new TreeCheck();
        TreeSearch Search = new TreeSearch();
        TreeDelete Delete = new TreeDelete();
        TreePrint Print = new TreePrint();
        TreePrintTravers PrintTravers = new TreePrintTravers();

        Outsorced Outsorced = new Outsorced();

        /// <summary>
        /// Add a node to the tree
        /// </summary>
        /// <param name="root">The root of the tree</param>
        /// <returns></returns>
        public Node AddNode(Node root)
        {
            // User Feesback
            Console.WriteLine(Outsorced.addSign);
            Console.WriteLine("\nInsert a number you want to add to the tree.\n" +
                              "The number has to be a full number (1 not 1.5) and greater than 0.");
            if(root != null)
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
            root = Check.CheckRotateNeed(root);

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

            // Search
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
            int deleteValue;

            while (deleteNode == null) ;
            {
                deleteValue = Input();
                deleteNode = Search.SearchNode(root, deleteValue);
            }
            root = Delete.DeleteMain(root, deleteNode);

            //Console.Clear();
            Outsorced.WriteColor(true, ConsoleColor.Magenta, $"Delete number {deleteValue} from the tree.");


            // Print final tree
            PrintTreeLines(root);

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

            Outsorced.WriteColor(true, ConsoleColor.Green, "TREE NUMBERS SORTED:");
            Console.ForegroundColor = ConsoleColor.Blue;
            int count = PrintTravers.TraversInCount(root);

            Outsorced.WriteColor(true, ConsoleColor.Green, $"\nThere are {count} nodes in the tree.\n");
            Console.ResetColor();

            PrintTreeLines(root);
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
            Print.PrintTreeMain(root, 15);
            Console.ResetColor();

            Outsorced.WriteColor(true, ConsoleColor.DarkGray, "\nPress any key to continue");
            Console.ReadKey();

            Console.Clear();
        }
    }
}
