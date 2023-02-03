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
                                Console.Clear();
                                break;

                            case '3':
                                if(root != null) Edit.SearchNode(root);
                                else Outsorced.WriteColor(true, ConsoleColor.Red, "Your Tree is empty");
                                Console.Clear();
                                break;

                            case '4':
                                if(root != null) Edit.PrintTree(root);
                                else Outsorced.WriteColor(true, ConsoleColor.Red, "Your Tree is empty");
                                Console.Clear();
                                break;

                            case '5':
                                if (root != null) Edit.PrintTreeDelegate(root);
                                else Outsorced.WriteColor(true, ConsoleColor.Red, "Your Tree is empty");
                                Console.Clear();
                                break;

                            case '6':
                                actualTree = false;
                                root = null;
                                break;
                        }
                        
                    }

                }
            }
            Console.Clear();
        }
    }
}