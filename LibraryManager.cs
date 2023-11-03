using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bilbiotek
{
    public class LibraryManager
    {
        
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public class Book : LibraryManager
        {
            public List<Book> allBooks { get; set; } = new List<Book>();
            private string author;
            private string borrower;
            private bool isBorrowed;

            public string Author
            {
                get { return author; }
                set { author = value; }
            }
            public string Borrower
            {
                get { return borrower; }
                set { borrower = value; }
            }
            public bool IsBorrowed
            {
                get { return isBorrowed; }
                set { isBorrowed = value; }
            }                       
        }

        public class Person
        {
            private string name;
            private string personID;
            private List<Book> borrowedBooks = new List<Book>();
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string PersonID
            {
                get { return personID; }
                set { personID = value; }
            }
            public List<Book> BorrowedBooks
            {
                get { return borrowedBooks; }
                set { borrowedBooks = value; }
            }
        }
        
    }
}
