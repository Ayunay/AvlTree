using System.Diagnostics;
using System.Xml.Linq;

namespace AvlTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gameflow = true;

            while (gameflow)
            {
                Random Random = new Random();
                Stopwatch Watch = new Stopwatch();
                Outsorced Outsorced = new Outsorced();

                TreeEdit Edit = new TreeEdit();
                
                Node root = null;

                // "do you want to play the game or exit?"
                gameflow = Outsorced.MenuSelector();

                if (gameflow)
                {
                    bool actualTree = true;

                    while (actualTree)
                    {

                        // What do you want to do with your Tree?
                        char editSelect = Outsorced.HowToEditTree();

                        switch (editSelect)
                        {
                            case '1':
                                root = Edit.AddNode(root);
                                break;

                            case '2':
                                if(root != null) root = Edit.DeleteNode(root);
                                else Outsorced.WriteColor(true, ConsoleColor.Red, "Your Tree is empty");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case '3':
                                if(root != null) Edit.SearchNode(root);
                                else Outsorced.WriteColor(true, ConsoleColor.Red, "Your Tree is empty");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case '4':
                                if(root != null) Edit.PrintTree(root);
                                else Outsorced.WriteColor(true, ConsoleColor.Red, "Your Tree is empty");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case '5':
                                actualTree = false;
                                root = null;
                                break;
                        }
                        
                    }

                }
            }
            Console.Clear();
        }

        static private void WhileProgramming(Node root, Random Random, TreeAdd Add, TreePrint PrintTree, TreeCheck Check,TreePrintTravers PrintTravers)
        {
            

            // height: 0 - 1 - 2 - 3 - 4  - 5  - 6
            // nodes:  1 - 2 - 4 - 8 - 16 - 32 - 64
            // size:   1 - 3 - 7 - 15- 31 - 63 - 127
            int size = 15;

            int[] zahlen = new int[size];// { 7,3,10,2,5,9,4,1,6,11,14,13,12};

            // Create Array 
            for (int i = 0; i < zahlen.Length; i++)
            {
                zahlen[i] = Random.Next(1, size + 1);
                //zahlen[i] = i; 
            }

            // Insert Array numbers into Tree
            for (int i = 0; i < zahlen.Length; i++)
            {
                root = Add.Add(root, zahlen[i]);

                Console.WriteLine($"\nADD: {zahlen[i]}");
                PrintTree.PrintTreeMain(root, zahlen.Length + 5);

                // Check Rotation
                root = Check.CheckRotateNeed(root);

            }

            // Print out the Tree
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n>> FINAL TREE:");
            PrintTree.PrintTreeMain(root, zahlen.Length + 5);
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("\nNode Count: " + PrintTravers.TraversInCount(root));
            Console.WriteLine("");

            Console.ResetColor();
        }

        /* -- WATCH --
        Console.WriteLine("Starte die Füllung des Arrays...");
        Watch.Start();
        // Do smth
        Watch.Stop();
        Console.WriteLine($"Es hat {Watch.ElapsedMilliseconds} Millisekunden gedauert");
        */
    }
}