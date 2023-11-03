using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilbiotek
{
    public class UI
    {
        
        private LibraryManager _libraryManager;
        private Library _library;
        public UI(Library library, LibraryManager libraryManager)
        {
            _libraryManager = libraryManager;
            _library = library;
        }

        public void MainMenu()
        {
            LibraryManager.Book bookManager = new LibraryManager.Book();
            _library.DefaultBooks(bookManager);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hi and welcome to Krolles Library. Please chose an option below.");
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("1)\t Add a new book.");
                Console.WriteLine("2)\t Lend a book");
                Console.WriteLine("3)\t Return a book");
                Console.WriteLine("4)\t Show available books");
                Console.WriteLine("5)\t Show borrowed books and borrower");
                Console.WriteLine("6)\t Exit program.");
                Console.Write("\nWhich option will it be (1-5) ?: ");
                if (int.TryParse(Console.ReadLine(), out int menuOption))
                {
                    switch (menuOption)
                    {
                        case 1:                
                            _library.AddBook(bookManager);                        
                            break;

                        case 2:


                            break;
                        case 3:

                            break;

                        case 4:
                            _library.ShowAvailableBooks(bookManager.allBooks);
                            break;

                        case 5:
                            
                            break;

                        case 6:
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Thanks for coming. Take care.");
                            Environment.Exit(0);
                            break;


                        default:
                            InvalidUserInput();
                            break;
                    }
                }
                else InvalidUserInput();
            }
            
        }
        /// <summary>
        /// Standard error respons.
        /// </summary>
        public static void InvalidUserInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Please input a valid option!");
            Console.ResetColor();
            Console.ReadKey();
        }
        /// <summary>
        /// Shows a message in a fancy color, to press enter to return to MainMenu()
        /// </summary>
        public static void ReturnToMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.Write("Press \"Enter\" to return to main menu");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }
    }
}
