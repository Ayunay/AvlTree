using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    internal class Outsorced
    {
        /// <summary>
        /// Play or Exit the Game
        /// </summary>
        /// <returns>true = play || false = exit</returns>
        public bool MenuSelector()
        {
            bool validMenuselection = false;
            bool gameFlow = true;

            Console.WriteLine(menuSign);
            Console.WriteLine("\nWhat do you want to do? \n" +
                                "1. Make a new AVL Tree \n" +
                                "2. Quit Application \n");

            while (!validMenuselection)
            {
                char menuSelection = Console.ReadKey(true).KeyChar;

                switch (menuSelection)
                {
                    case '1':
                        validMenuselection = true;
                        gameFlow = true;
                        break;

                    case '2':
                        validMenuselection = true;
                        gameFlow = false;
                        break;

                    default:
                        WriteColor(true, ConsoleColor.DarkRed, $"You insert > {menuSelection} < This is an invalid input.");
                        break;
                }
            }
            Console.Clear();

            return gameFlow;
        }

        /// <summary>
        /// What to do in the Tree? Add, Delete or Search an Element
        /// </summary>
        /// <returns></returns>
        public char HowToEditTree()
        {
            bool validMenuselection = false;

            Console.WriteLine(menuSign);
            Console.WriteLine("\nWhat do you want to do? \n" +
                                "1. Add a node \n" +
                                "2. Delete a node \n" +
                                "3. Search a node (value) \n" +
                                "4. Print the whole tree \n" +
                                "5. Exit my actual Tree > Important: This causes the tree to delete all data! \n");

            char menuSelection = '0';

            while (!validMenuselection)
            {
                menuSelection = Console.ReadKey(true).KeyChar;

                switch (menuSelection)
                {
                    case '1':
                        validMenuselection = true;
                        break;

                    case '2':
                        validMenuselection = true;
                        break;
                    
                    case '3':
                        validMenuselection = true;
                        break;

                    case '4':
                        validMenuselection = true;
                        break;

                    default:
                        WriteColor(true, ConsoleColor.DarkRed, $"You insert > {menuSelection} < This is an invalid input.");
                        break;
                }
            }
            Console.Clear();

            return menuSelection;
        }

        /// <summary>
        /// Checks if the User input is a number and is in the given range (amount of options)
        /// </summary>
        /// <param name="options">how many options are there to choose</param>
        /// <returns>The selected Option (int)</returns>
        public int UserInput(int options)
        {
            int selection = 0;
            bool validInput = false;

            while (!validInput)     // Check if a number has been entered for the choice 
            {
                char input = Console.ReadKey(true).KeyChar;

                if (!int.TryParse(input.ToString(), out selection) || selection == 0 || selection > options)
                    WriteColor(true, ConsoleColor.Red, "Please pick one option from above.");
                else validInput = true;
            }

            Console.Clear();

            return selection;
        }

        /// <summary>
        /// Console.Write(line) in Color
        /// </summary>
        /// <param name="line">true: Console.Write || false: Console.WriteLine</param>
        /// <param name="color"></param>
        /// <param name="text"></param>
        public void WriteColor(bool line, ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            if (line == true) Console.WriteLine(text);
            else Console.Write(text);
            Console.ResetColor();
        }

        // website for strings: http://patorjk.com/software/taag/#p=display&f=Graceful&t=Type

        public string menuSign = @"
  _  _  ____  __ _  _  _ 
 ( \/ )(  __)(  ( \/ )( \
 / \/ \ ) _) /    /) \/ (
 \_)(_/(____)\_)__)\____/
";
        public string addSign = @"
  __   ____  ____ 
 / _\ (    \(    \
/    \ ) D ( ) D (
\_/\_/(____/(____/
";
        public string deleteSign = @"
 ____  ____  __    ____  ____  ____ 
(    \(  __)(  )  (  __)(_  _)(  __)
 ) D ( ) _) / (_/\ ) _)   )(   ) _) 
(____/(____)\____/(____) (__) (____)
";
        public string searchSign = @"
 ____  ____   __   ____   ___  _  _ 
/ ___)(  __) / _\ (  _ \ / __)/ )( \
\___ \ ) _) /    \ )   /( (__ ) __ (
(____/(____)\_/\_/(__\_) \___)\_)(_/
";
        public string printSign = @"
 ____  ____  __  __ _  ____    ____  ____  ____  ____ 
(  _ \(  _ \(  )(  ( \(_  _)  (_  _)(  _ \(  __)(  __)
 ) __/ )   / )( /    /  )(      )(   )   / ) _)  ) _) 
(__)  (__\_)(__)\_)__) (__)    (__) (__\_)(____)(____)
";
    }
}
