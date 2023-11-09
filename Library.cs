using Bilbiotek;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;



/*Lägga till nya böcker i biblioteket.
Låna ut böcker till låntagare.
Återlämna böcker.
Visa tillgängliga böcker.
Visa låntagare och deras lånade böcker.
Använd listor och/eller andra lämpliga datastrukturer/filer för att hantera samlingar av böcker och låntagare.*/
namespace Bilbiotek
{
    public class Library
    {
        /// <summary>
        /// Adds Title and Author to a new book and saves it in the list
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            Console.Clear();
            Console.Write("Title of the book: ");
            string title = Console.ReadLine();
            Console.Write("Author of the book: ");
            string author = Console.ReadLine();
            Console.Write("Year book was published: ");
            int published = int.Parse(Console.ReadLine());

            Book newBook = new Book { Title = title, Author = author, Published = published };
            SavedListsAndData.availableBooks.Add(newBook);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Book has been added to the library.");
            Console.ResetColor();
            UI.ReturnToMainMenu();
        }
        /// <summary>
        /// Lets user input information about person lending the book, and which book he/she wants to borrow.
        /// </summary>
        /// <param name="book"></param>
        /// <param name="person"></param>
        public void LendBook(Book.Person person)
        {
            Console.Clear();
             if (SavedListsAndData.availableBooks.Count > 0)
             {
                 ShowAvailableBooks(); //Simply lists what books are available to borrow.
                 Console.WriteLine();
                Console.WriteLine("This is the list of available books.");
                Console.Write($"Chose from one of the options 1-{SavedListsAndData.availableBooks.Count}: ");
                 int userInput = int.Parse(Console.ReadLine());

                 //removes 1 from user input to match the numbers in the list (behind the scenes action). First book = index 0, but listed as 1. 
                 if (userInput - 1 >= 0 && userInput - 1 < SavedListsAndData.availableBooks.Count)
                 {
                     Book selectedBook = SavedListsAndData.availableBooks[userInput - 1]; //Creates a new instance of a book matching the users selection.

                     Console.WriteLine($"You selected: {selectedBook.Title}");
                     Console.WriteLine();
                     Console.Write("Borrowers name: ");
                     string nameInput = Console.ReadLine();
                     Console.Write("Borrowers ID: ");
                     string idInput = Console.ReadLine();

                      //Removes the book to the list of available books.
                     selectedBook.IsBorrowed = true; //Sets the book as borrowed.
                    

                     //Adds the book and personinfo to the list.
                     Book.Person newPerson = new Book.Person { Name = nameInput, PersonID = idInput, Title = selectedBook.Title, Published = selectedBook.Published, Author = selectedBook.Author};
                     SavedListsAndData.borrowedBooks.Add(newPerson);
                    SavedListsAndData.availableBooks.Remove(selectedBook);
                    UI.ReturnToMainMenu();
                 }
                 else
                 {
                     Console.WriteLine("Invalid selection.");
                     UI.ReturnToMainMenu();
                 }
             }
             else
             {
                 Console.WriteLine("Library is out of books. Please come back at another time.");
                 UI.ReturnToMainMenu();
             }
         }
        public void ReturnBook()
        {
            int counter = 1;
            //TODO kolla så man inte fastnar i en loop ifall namnet/ID inte matcher.
            Console.Clear();
            retryName:
            Console.Write("Who's returning the book? ");
            string returner = Console.ReadLine();
            for (int i = 0; i < SavedListsAndData.borrowedBooks.Count; i++)
            {
                if (returner.ToLower() == SavedListsAndData.borrowedBooks[i].Name.ToLower())
                {
                    Console.Write($"{SavedListsAndData.borrowedBooks[i].Name} found. Enter ID: ");
                    retryID:
                    string idNumber = Console.ReadLine();
                    if (idNumber == SavedListsAndData.borrowedBooks[i].PersonID)
                    {
                        foreach (var books in SavedListsAndData.borrowedBooks)
                        {
                            if (books.Name.ToLower() == returner.ToLower())
                            {
                                Console.WriteLine($"{counter} \t{books.Title}");
                                counter++;
                            }
                        } 
                        Console.Write("What book would you like to return? ");
                        int userInput = int.Parse(Console.ReadLine());
                        if (userInput >= 1 && userInput < counter)
                        {
                            Book.Person selectedBook = SavedListsAndData.borrowedBooks[userInput - 1];
                            Console.WriteLine($"You've successfully returned {selectedBook.Title}");
                            Book.Person returnBook = new Book.Person { Title = selectedBook.Title, Published = selectedBook.Published, Author = selectedBook.Author };
                            SavedListsAndData.availableBooks.Add(returnBook);
                            SavedListsAndData.borrowedBooks.Remove(selectedBook);
                            
                            UI.ReturnToMainMenu();
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID number doesnt match the name.");
                        goto retryID;
                    }
                }              
            }
        }
        /// <summary>
            /// Prints out currently available books in the library.
            /// </summary>
            /// <param name="lista"></param>
        public void ShowAvailableBooks()
        {
            int counter = 1;  
            if (SavedListsAndData.availableBooks.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Title".PadRight(33) + "Author".PadRight(25) + "Publishing year");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.ResetColor();
                foreach (Book book in SavedListsAndData.availableBooks)
                {
                    if (!book.IsBorrowed) //Makes sure only available books are listed.
                    {
                        Console.Write(counter + ": ");
                        string title = book.Title.PadRight(30);
                        Console.WriteLine(title + book.Author.PadRight(25) + book.Published);
                        counter++;
                    }
                }
            }
            else Console.WriteLine("There are currently no available books.");
        }
        /// <summary>
        /// Prints out a list of borrowed books, and who borrowed them.
        /// </summary>
        /// <param name="person"></param>
        public void ShowBorrowedBooks(List<Book.Person> person)
        {
            Console.Clear();
            if (person.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Title".PadRight(25) + "\tBorrower".PadRight(20) + "\tBorrower ID");
                Console.WriteLine("-------------------------------------------------------------");
                Console.ResetColor();
                foreach (Book.Person p in person)
                {
                    Console.WriteLine($"{p.Title.PadRight(25)} \t{p.Name.PadRight(15)} \t{p.PersonID}");
                    Console.WriteLine();
                }
                UI.ReturnToMainMenu();
            }
            else
            {
                Console.WriteLine("No books have been borrowed. All are accounted for.");
                UI.ReturnToMainMenu();
            }
        }
        /// <summary>
        /// Adds a few books to the library so its not empty from start.
        /// </summary>
        /// <param name="book"></param>
        public void DefaultBooks()
        {
            Console.Clear();
            Book newBook1 = new Book { Title = "Moby dick", Author = "Herman MelVille", Published = 1851, IsBorrowed = false };
            Book newBook2 = new Book { Title = "1984", Author = "George Orwell", Published = 1949, IsBorrowed = false };
            Book newBook3 = new Book { Title = "To kill a mockingbird", Author = "Harper Lee", Published = 1960, IsBorrowed = false };
            Book newBook4 = new Book { Title = "Pride and prejudice", Author = "Jane Austen", Published = 1813, IsBorrowed = false };
            Book newBook5 = new Book { Title = "The great Gatsby", Author = "F. Scott Fitzgerald", Published = 1925, IsBorrowed = false };

            SavedListsAndData.availableBooks.Add(newBook1);
            SavedListsAndData.availableBooks.Add(newBook2);
            SavedListsAndData.availableBooks.Add(newBook3);
            SavedListsAndData.availableBooks.Add(newBook4);
            SavedListsAndData.availableBooks.Add(newBook5);

            Console.WriteLine("Five books have been added to the library.");            
            UI.ReturnToMainMenu();
        }
    }
}

