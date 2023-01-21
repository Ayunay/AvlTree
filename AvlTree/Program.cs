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
            int size = 7;

            int[] zahlen = new int[] { 5,12,3,11,7,4,10,2,8,1,13,6,9,14,15};
            /*
            // Create Array 
            for (int i = 0; i < zahlen.Length; i++)
            {
                //zahlen[i] = Random.Next(size);
                zahlen[i] = i; 
            }*/

            // Insert Array numbers into Tree
            for (int i = 0; i < zahlen.Length; i++)
            {
                root = Add.Add(root, zahlen[i]);
            }
            

            // Print out the Tree
            Print.PrintTree(root, zahlen.Length);
            Console.WriteLine("\n\n");
            Print.TraversIn(root);

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

        /*
            Console.WriteLine("Starte die Füllung des Arrays...");
            Watch.Start();
            // Do smth
            Watch.Stop();
            Console.WriteLine($"Es hat {Watch.ElapsedMilliseconds} Millisekunden gedauert");
            */

    }
}