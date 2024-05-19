using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilbiotek
{
    /// <summary>
    /// Basic user interface design with a switchcase and 2 standardised response methods.
    /// </summary>
    public class UI
    {
        private Book _book;
        private Library _library;
        private Book.Borrower _person;
        private SavedListsAndData _savedListsAndData;
        public UI(Library library, Book book, Book.Borrower person, SavedListsAndData list)
        {
            _book = book;
            _library = library;
            _person = person;
            _savedListsAndData = list;
        }

        public void MainMenu()
        {     
            //Menu will loop until a choise is made
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
                Console.WriteLine("\n8)\t Add 5 books (Test feature)");
                Console.Write("\nWhich option will it be (1-6) ?: ");
                #endregion
                if (int.TryParse(Console.ReadLine(), out int menuOption))//Prohibits a crash if a char is entered.
                {
                    switch (menuOption)
                    {
                        case 1:                
                            _library.AddBook(_savedListsAndData); //lets user add a book                   
                            break;
                        case 2:                        
                            _library.LendBook(_person, _savedListsAndData); //lets user lend out a book
                            break;
                        case 3:                       
                            _library.ReturnBook(_savedListsAndData); //Lets user return a borrowed book
                            break;
                        case 4:
                            Console.Clear();
                            _library.ShowAvailableBooks(_savedListsAndData); //Displays current available books
                            ReturnToMainMenu();
                            break;
                        case 5:
                            _library.ShowBorrowedBooks(_savedListsAndData.BorrowedBooks); //displays current borrowed books
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine();
                            SavedListsAndData.SaveAllData(_savedListsAndData); //Saves all current data
                            Console.WriteLine("Thanks for coming. Take care.");
                            Environment.Exit(0); 
                            break;
                        case 8:
                            _library.DefaultBooks(_savedListsAndData); //Adds 5 books to AvailableBooks
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
