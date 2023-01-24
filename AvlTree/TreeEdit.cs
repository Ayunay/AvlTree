using System;
using System.Collections.Generic;
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
            int newNode = 0;
            string input;
            bool validInput = false;

            // User Input
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

            while (!validInput)
            {
                input = Console.ReadLine();

                if (!int.TryParse(input, out newNode) || newNode < 0)
                    Outsorced.WriteColor(true, ConsoleColor.DarkRed, "This is an invalid input, please enter a positive number");
                else validInput = true;
            }
            Console.Clear();

            Console.WriteLine(Outsorced.addSign);
            if (root != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Your olf tree:");
                Print.PrintTreeMain(root, 31);
            }
            Outsorced.WriteColor(true, ConsoleColor.Magenta, $"Add number {newNode} to the tree.");

            // Add and rotate
            root = Add.Add(root, newNode);
            root = Check.CheckRotateNeed(root);

            // Print the Tree
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nYOUR NEW TREE:");
            Print.PrintTreeMain(root, 31);

            Outsorced.WriteColor(true, ConsoleColor.DarkGray, "\nPress any key to continue");
            Console.ReadKey();

            Console.Clear();

            return root;
        }

        /// <summary>
        /// Search a node in the tree
        /// </summary>
        /// <param name="root">The root of the tree</param>
        /// <returns></returns>
        public void SearchNode(Node root)
        {
            int searchValue = 0;
            string input;
            bool validInput = false;

            // User Input
            Console.WriteLine(Outsorced.addSign);
            Console.WriteLine("\nInsert a number you want to search in the tree.\n");

            while (!validInput)
            {
                input = Console.ReadLine();

                if (!int.TryParse(input, out searchValue) || searchValue < 0)
                    Outsorced.WriteColor(true, ConsoleColor.DarkRed, "This is an invalid input, please enter a positive number");
                else validInput = true;
            }
            Console.Clear();
            Outsorced.WriteColor(true, ConsoleColor.Magenta, $"Search number {searchValue} in the tree.");

            // Search
            int count = Search.SearchValue(root, searchValue);
            if (count == 0) 
                Outsorced.WriteColor(true, ConsoleColor.Red, "The number does not exist in the tree.");
            else Outsorced.WriteColor(true, ConsoleColor.Green, $"The number is in the tree {count} times.");

            // Print the Tree
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nYOUR TREE:");
            Print.PrintTreeMain(root, 31);
            Console.ResetColor();

            Outsorced.WriteColor(true, ConsoleColor.DarkGray, "\nPress any key to continue");
            Console.ReadKey();

            Console.Clear();
        }

        /// <summary>
        /// Delete a node of the tree and resort it so that there is no gap
        /// </summary>
        /// <param name="root">The root of the tree</param>
        /// <returns></returns>
        public Node DeleteNode(Node root)
        {
            int deleteValue = 0;
            string input;
            bool validInput = false;

            // User Input
            Console.WriteLine(Outsorced.addSign);
            Console.WriteLine("\nInsert a number you want to delete from the tree.");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Your actual tree:");
            Print.PrintTreeMain(root, 31);
            Console.ResetColor();

            while (!validInput)
            {
                input = Console.ReadLine();

                if (!int.TryParse(input, out deleteValue) || deleteValue < 0)
                    Outsorced.WriteColor(true, ConsoleColor.DarkRed, "This is an invalid input, please enter a number from the Tree");
                else validInput = true;
            }
            //Console.Clear();
            Outsorced.WriteColor(true, ConsoleColor.Magenta, $"Add number {deleteValue} to the tree.");

            // Delete
            Node deleteNode = Search.SearchNode(root, deleteValue, null);
            //root = Delete.DeleteMain(root, deleteNode);

            // Print the Tree
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nYOUR TREE:");
            Print.PrintTreeMain(root, 15);
            Console.ResetColor();

            Outsorced.WriteColor(true, ConsoleColor.DarkGray, "\nPress any key to continue");
            Console.ReadKey();

            Console.Clear();

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

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nYOUR TREE:");
            Print.PrintTreeMain(root, 31);
            Console.ResetColor();

            Outsorced.WriteColor(true, ConsoleColor.Green, "\nTREE NUMBERS SORTED:");
            Console.ForegroundColor = ConsoleColor.Blue;
            int count = PrintTravers.TraversInCount(root);

            Outsorced.WriteColor(true, ConsoleColor.Green, $"\nThere are {count} nodes in the tree.");
            Console.ResetColor();

            Outsorced.WriteColor(true, ConsoleColor.DarkGray, "\nPress any key to continue");
            Console.ReadKey();

            Console.Clear();
        }
    }
}
