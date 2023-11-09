using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Bilbiotek.Book;

namespace Bilbiotek
{
    public static class SavedListsAndData
    {        
        public static List<Book> availableBooks = new List<Book>();       
        public static List<Person> borrowedBooks  = new List<Person>();
    }
    /// <summary>
    /// Book-class containing private fields and constructors. Title, Author, Published and IsBorrowed.
    /// </summary>
    public class Book
    {
        private string title;
        private string author;
        private int published;
        private bool isBorrowed;       
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public int Published
        {
            get { return published; }
            set { published = value; }
        }
        public bool IsBorrowed
        {
            get { return isBorrowed; }
            set { isBorrowed = value; }
        }    

        /// <summary>
        /// Person-class containing private fields and constructors. Name, PersonID and NumberOfBoks. Inherits from Book.
        /// </summary>
        public class Person : Book
        {
            private string name;
            private string personID;
         
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
        

        }
    }
}
