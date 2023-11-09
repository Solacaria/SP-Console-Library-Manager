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
        
        private Book _book;
        private Library _library;
        private Book.Person _person;
        public UI(Library library, Book book, Book.Person person)
        {
            _book = book;
            _library = library;
            _person = person;
        }

        public void MainMenu()
        {       
           
            while (true)
            {
                #region Main menu
                Console.Clear();
                Console.WriteLine("Hi and welcome to Krolles Library. Please chose an option below.");
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("1)\t Add a new book.");
                Console.WriteLine("2)\t Lend a book");
                Console.WriteLine("3)\t Return a book");
                Console.WriteLine("4)\t Show available books");
                Console.WriteLine("5)\t Show borrowed books and borrower");
                Console.WriteLine("6)\t Exit program.");
                Console.WriteLine("\n8)\t Add 5 books (Admin feature)");
                Console.Write("\nWhich option will it be (1-6) ?: ");
                #endregion
                if (int.TryParse(Console.ReadLine(), out int menuOption))
                {
                    switch (menuOption)
                    {
                        case 1:                
                            _library.AddBook(_book);                        
                            break;

                        case 2:                        
                            _library.LendBook(_person);
                            break;
                        case 3:                       
                            _library.ReturnBook();
                            break;

                        case 4:
                            Console.Clear();
                            _library.ShowAvailableBooks();
                            ReturnToMainMenu();
                            break;

                        case 5:
                            _library.ShowBorrowedBooks(SavedListsAndData.borrowedBooks);
                            break;

                        case 6:
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Thanks for coming. Take care.");
                            Environment.Exit(0);
                            break;
                        case 8:
                            _library.DefaultBooks(); 
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
