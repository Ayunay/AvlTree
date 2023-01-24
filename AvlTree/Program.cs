using System.Diagnostics;
using System.Xml.Linq;

namespace AvlTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random Random = new Random();
            Stopwatch Watch = new Stopwatch();

            TreeAdd Add = new TreeAdd();
            TreeCheck Check = new TreeCheck();
            TreeDelete Delete = new TreeDelete();
            TreePrint Print = new TreePrint();

            Node root = null;

            // height: 0 - 1 - 2 - 3 - 4  - 5  - 6
            // nodes:  1 - 2 - 4 - 8 - 16 - 32 - 64
            // size:   1 - 3 - 7 - 15- 31 - 63 - 127
            int size = 15;

            int[] zahlen = new int[size];// { 7,3,10,2,5,9,4,1,6,11,14,13,12};
            
            // Create Array 
            for (int i = 0; i < zahlen.Length; i++)
            {
                zahlen[i] = Random.Next(1, size+1);
                //zahlen[i] = i; 
            }

            // Insert Array numbers into Tree
            for (int i = 0; i < zahlen.Length; i++)
            {
                root = Add.Add(root, zahlen[i]);

                Console.WriteLine($"\nADD: {zahlen[i]}");
                Print.PrintTree(root, 31);

                // Check Rotation
                root = Check.CheckRotateNeed(root);

            }


            // Print out the Tree
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nFINAL TREE:");
            Print.PrintTree(root, zahlen.Length+5);
            Console.WriteLine("\n");
            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Print.TraversIn(root);
            Console.WriteLine("");

            Console.ResetColor();
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
                string searchString = Console.ReadLine();
                int searchNumber;
                int.TryParse(searchString, out searchNumber);
                Check.Search(root, searchNumber);
                break;
        }
        */
        //}
        //Console.Clear();
        //}

        /*
            Console.WriteLine("Starte die Füllung des Arrays...");
            Watch.Start();
            // Do smth
            Watch.Stop();
            Console.WriteLine($"Es hat {Watch.ElapsedMilliseconds} Millisekunden gedauert");
            */

    }
}