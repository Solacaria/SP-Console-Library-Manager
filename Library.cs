using Bilbiotek;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static Bilbiotek.UI;
using System.Diagnostics.Metrics;

namespace Bilbiotek
{
    public class Library
    {
        /// <summary>
        /// Adds Title and Author to a new book and saves it in the list
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(SavedListsAndData list)
        {
            Console.Clear();
            Console.Write("Title of the book: ");
            string title = Console.ReadLine();
            Console.Write("Author of the book: ");
            string author = Console.ReadLine();
            while (true)
            {
                Console.Write("Year book was published: ");
                if (int.TryParse(Console.ReadLine(), out int published))//Prohibits a crash if a char is entered.
                {
                    //Adds the users inputs into a new book object
                    Book newBook = new Book { Title = title, Author = author, Published = published };
                    list.AvailableBooks.Add(newBook); //Adds the object to the list of available books.
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Book has been added to the library.");
                    Console.ResetColor();
                    ReturnToMainMenu();
                    break;
                }
                else InvalidUserInput();
            }
      
        }
        /// <summary>
        /// Lets user input information about person lending the book, and which book he/she wants to borrow.
        /// </summary>
        /// <param name="book"></param>
        /// <param name="person"></param>
        public void LendBook(Book.Borrower person, SavedListsAndData list)
        {       
            //Kommentera mera
            Console.Clear();
             if (list.AvailableBooks.Count > 0) //makes sure there's books in the list before proceeding.
             {
                ShowAvailableBooks(list); //Simply lists what books are available to borrow.
                Console.WriteLine();
                Console.WriteLine("This is the list of available books.");               
                Console.Write($"Chose from one of the options 1-{list.AvailableBooks.Count}: "); //shows a number matching the number of elements in the list.              
                if (int.TryParse(Console.ReadLine(), out int userInput))//Prohibits a crash if a char is entered.
                {
                    //removes 1 from user input to match the numbers in the list (behind the scenes action). First book = index 0, but listed as 1. 
                    if (userInput - 1 >= 0 && userInput - 1 < list.AvailableBooks.Count)
                    {
                        Book selectedBook = list.AvailableBooks[userInput - 1]; //Creates a new instance of a book matching the users selection.
                        int counter = person.NumberBooks; //saves the number of total books saved by a single person.
                        Console.WriteLine($"You selected: {selectedBook.Title}"); //show the selected book
                        Console.WriteLine();
                        Console.Write("Borrowers name: ");
                        string nameInput = Console.ReadLine();
                        Console.Write("Borrowers ID: ");
                        string idInput = Console.ReadLine();

                        //Removes the book to the list of available books.
                        selectedBook.IsBorrowed = true; //Sets the book as borrowed.

                        counter++; 
                        //Adds the book and personinfo to the list.
                        Book.Borrower newPerson = new Book.Borrower { BorrowerName = nameInput, BorrowerID = idInput, Title = selectedBook.Title, Published = selectedBook.Published, Author = selectedBook.Author, NumberBooks = counter };
                        list.BorrowedBooks.Add(newPerson); //Takes the book object and adds it to the list
                        list.AvailableBooks.Remove(selectedBook); //removes it from the list of available books
                        ReturnToMainMenu();
                    }
                    else
                    {
                        InvalidUserInput();
                    }
                }
                else
                {
                    InvalidUserInput();                   
                }
             }
             else
             {
                 Console.WriteLine("Library is out of books. Please come back at another time."); //If the list AvailableBooks is empty.
                 ReturnToMainMenu();
             }
         }
        /// <summary>
        /// Lets the user return a book. Using borrowers name and ID.
        /// </summary>
        /// <param name="list"></param>
        public void ReturnBook(SavedListsAndData list)
        {
            int counter = 1;            
            Console.Clear();     
            if (list.BorrowedBooks.Count > 0) //makes sure there's books in the list before proceeding.
            {
                Console.Write("Who's returning the book? ");
                string returner = Console.ReadLine();

                for (int i = 0; i < list.BorrowedBooks.Count; i++) //loops through the list X-times to find a match to "returner"
                {
                    if (returner.ToLower() == list.BorrowedBooks[i].BorrowerName.ToLower()) // checks to see if there's a match in the list
                    {
                        Console.Write($"\"{list.BorrowedBooks[i].BorrowerName}\" found. Enter ID: ");
                        string idNumber = Console.ReadLine();
                        if (idNumber == list.BorrowedBooks[i].BorrowerID) //checks to see if there's a match in the list
                        {
                            Console.Clear();
                            foreach (var books in list.BorrowedBooks) //Loops through the list
                            {
                                if (books.BorrowerName.ToLower() == returner.ToLower())
                                {
                                    Console.WriteLine($"{counter} \t{books.Title}"); //If a match is found, lists all borrowed books by that person
                                    counter++;
                                }
                            }
                            //lets the user select which book to return from the list.
                            Console.Write("Enter the number of the book you would like to return? ");                            
                            if (int.TryParse(Console.ReadLine(), out int userInput)) //Prohibits a crash if a char is entered.
                            {
                                if (userInput >= 1 && userInput < counter)
                                {
                                    Book.Borrower selectedBook = list.BorrowedBooks[userInput - 1];
                                    Console.WriteLine($"You've successfully returned {selectedBook.Title}");
                                    //takes the info of the book, creates a new object and adds it back to the list of available books then removing it from BorrowedBooks
                                    Book.Borrower returnBook = new Book.Borrower { Title = selectedBook.Title, Published = selectedBook.Published, Author = selectedBook.Author, BorrowerName = returner };
                                    list.AvailableBooks.Add(returnBook);
                                    list.BorrowedBooks.Remove(selectedBook);

                                    ReturnToMainMenu();
                                }
                                else InvalidUserInput();
                            }
                            else InvalidUserInput();
                        }
                        else
                        {
                            Console.WriteLine($"{idNumber} doesnt match the {returner}.");
                            ReturnToMainMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{returner} does not match any current borrowers.");
                        ReturnToMainMenu();
                    }
                }              
            }
            else
            {
                Console.WriteLine("No books have been borrowed. All books are accounted for.");
                ReturnToMainMenu();
            }
        }
        /// <summary>
            /// Prints out currently available books in the library.
            /// </summary>
            /// <param name="lista"></param>
        public void ShowAvailableBooks(SavedListsAndData list)
        {            
            int counter = 1;  
            if (list.AvailableBooks.Count > 0) //makes sure there are books
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Title".PadRight(33) + "Author".PadRight(25) + "Publishing year"); //spaces header distance 
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.ResetColor();

                foreach (Book book in list.AvailableBooks) //Lists up all books
                {
                    Console.Write(counter + ": ");                   
                    Console.WriteLine(book.Title.PadRight(30) + book.Author.PadRight(25) + book.Published); //spaces property distance
                    counter++;                                       
                }                
            }
            else Console.WriteLine("There are currently no available books.");
        }
        /// <summary>
        /// Prints out a list of borrowed books, and who borrowed them.
        /// </summary>
        /// <param name="person"></param>
        public void ShowBorrowedBooks(List<Book.Borrower> person)
        {           
            Console.Clear();
            if (person.Count > 0) //makes sure there are borrowers
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Title".PadRight(25) + "\tBorrower".PadRight(20) + "\tBorrower ID"); //spaces header distance
                Console.WriteLine("------------------------------------------------------------------");
                Console.ResetColor();
                foreach (Book.Borrower p in person) 
                {
                    Console.WriteLine($"{p.Title.PadRight(25)} \t{p.BorrowerName.PadRight(15)} \t{p.BorrowerID}"); //spaces propety distance
                    Console.WriteLine();
                }
                ReturnToMainMenu();
            }
            else
            {
                Console.WriteLine("No books have been borrowed. All are accounted for.");
                ReturnToMainMenu();
            }
        }
        /// <summary>
        /// Adds a few books to the library so its not empty from start.
        /// </summary>
        /// <param name="book"></param>
        public void DefaultBooks(SavedListsAndData list)
        {
            Console.Clear();
            //Just adds 5 books to the library, eases testing.
            Book newBook1 = new Book { Title = "Moby dick", Author = "Herman MelVille", Published = 1851, IsBorrowed = false };
            Book newBook2 = new Book { Title = "1984", Author = "George Orwell", Published = 1949, IsBorrowed = false };
            Book newBook3 = new Book { Title = "To kill a mockingbird", Author = "Harper Lee", Published = 1960, IsBorrowed = false };
            Book newBook4 = new Book { Title = "Pride and prejudice", Author = "Jane Austen", Published = 1813, IsBorrowed = false };
            Book newBook5 = new Book { Title = "The great Gatsby", Author = "F. Scott Fitzgerald", Published = 1925, IsBorrowed = false };

            list.AvailableBooks.Add(newBook1);
            list.AvailableBooks.Add(newBook2);
            list.AvailableBooks.Add(newBook3);
            list.AvailableBooks.Add(newBook4);
            list.AvailableBooks.Add(newBook5);

            Console.WriteLine("Five books have been added to the library.");            
            ReturnToMainMenu();
        }
    }
}