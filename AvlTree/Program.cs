namespace AvlTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gameFlow = true;

            while (gameFlow)
            {
                Outsorced outsorced = new Outsorced();
                EditTree editTree = new EditTree();
                
                // Menu "Do you want to play the Game or exit?"
                gameFlow = outsorced.MenuSelector();

                if (gameFlow)
                {
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
                }
                Console.Clear();
            }
        }
    }
}