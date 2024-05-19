using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Bilbiotek.Book;

namespace Bilbiotek
{
    /// <summary>
    /// Book-class containing private fields and constructors. Title, Author, Published and IsBorrowed.
    /// </summary>
    public class Book
    {
        private string title;
        private string author;
        private int published;
        private bool isBorrowed;
        private string borrowerName;
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
        public string BorrowerName
        {
            get { return borrowerName; }
            set { borrowerName = value; }
        }
        /// <summary>
        /// Takes the book-object and splits it down to a string with each coresponding propety in the right place.
        /// </summary>
        /// <returns></returns>
        public string ToCsvStringBook() 
        {
            return $"{title},{author},{published},{isBorrowed}, {borrowerName}";
        }
        /// <summary>
        /// Person-class containing private fields and constructors. Name, PersonID and NumberOfBoks. Inherits from Book.
        /// </summary>
        public class Borrower : Book
        {
         
            private string borrowerID;
            private int numberBooks;         
            public string BorrowerID
            {
                get { return borrowerID; }
                set { borrowerID = value; }
            }
            public int NumberBooks
            {
                get { return numberBooks; }
                set {  numberBooks = value; }
            }
            /// <summary>
            /// Takes the borrower-object and splits it down to a string with each coresponding propety in the right place.
            /// </summary>
            /// <returns></returns>
            public string ToCsvStringBorrower()
            {
                return $"{title},{author},{published},{isBorrowed}, {borrowerName},{borrowerID},{numberBooks}";
            }
        }
    }
}
