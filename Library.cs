using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bilbiotek.LibraryManager;


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
            Book newBook = new Book { Title = title, Author = author };
            book.allBooks.Add(newBook);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Book has been added to the library.");
            Console.ResetColor();
            UI.ReturnToMainMenu();
        }      
        public void LendBook()
        {

        }
        public void ReturnBook()
        {

        }
        /// <summary>
        /// Prints out currently available books in the library.
        /// </summary>
        /// <param name="lista"></param>
        public void ShowAvailableBooks(List<Book> lista)
        {            
            Console.Clear();
            Console.WriteLine("Title".PadRight(30) + "Author");
            Console.WriteLine("---------------------------------------------");
            foreach (Book book in lista)
            {
                if (!book.IsBorrowed) //Makes sure only available books are listed.
                {
                    string title = book.Title.PadRight(30);
                    Console.WriteLine(title + book.Author);
                }                    
            }
            UI.ReturnToMainMenu();
        }
        public void ShowBorrowedBooks(List<Book> lista)
        {

            //TODO Se till att den även tar med personinfo när den listar upp
            Console.Clear();
            Console.WriteLine("Title".PadRight(30) + "Author");
            Console.WriteLine("---------------------------------------------");
            foreach (Book book in lista)
            {
                if (book.IsBorrowed) //Makes sure only unavailable books are listed.
                {
                    string title = book.Title.PadRight(30);
                    Console.WriteLine(title + book.Author);
                    //Här borde den visa personen
                }
            }
            UI.ReturnToMainMenu();
        }
        /// <summary>
        /// Adds a few books to the library so its not empty from start.
        /// </summary>
        /// <param name="book"></param>
        public void DefaultBooks(Book book)
        {

            Book newBook1 = new Book { Title = "Moby dick", Author = "Herman MelVille", IsBorrowed = false };
            Book newBook2 = new Book { Title = "1984", Author = "George Orwell", IsBorrowed = false };
            Book newBook3 = new Book { Title = "To kill a mockingbird", Author = "Harper Lee", IsBorrowed = false };
            Book newBook4 = new Book { Title = "Pride and prejudice", Author = "Jane Austen", IsBorrowed = false };
            Book newBook5 = new Book { Title = "The great Gatsby", Author = "F. Scott Fitzgerald", IsBorrowed = false };

            book.allBooks.Add(newBook1);
            book.allBooks.Add(newBook2);
            book.allBooks.Add(newBook3);
            book.allBooks.Add(newBook4);
            book.allBooks.Add(newBook5);
        }
    }
}
