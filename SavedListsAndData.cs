using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bilbiotek.Book;
using System.Text;
using System.Data;

namespace Bilbiotek
{
    /// <summary>
    /// Holds the lists and methods for saving/loading data.
    /// </summary>
    public class SavedListsAndData
    {
        private List<Book> availableBooks = new List<Book>();        
        private List<Borrower> borrowedBooks = new List<Borrower>();
        public List<Book> AvailableBooks
        {
            get { return availableBooks; }
            set { availableBooks = value; }
        }
        public List<Borrower> BorrowedBooks
        { 
            get { return borrowedBooks; }
            set { borrowedBooks = value; }
        }
       /// <summary>
       /// Saves all data from AvailableBooks and BorrowedBooks to csv files
       /// </summary>
       /// <param name="list"></param>
        public static void SaveAllData(SavedListsAndData list)
        {
            //Creates filepaths
            string csvFilePathBook = "BookList.csv"; 
            string csvFilePathPerson = "PersonList.csv";

            //Saves AvailableBooks list to a csv file
            using (StreamWriter write = new StreamWriter(csvFilePathBook))
            {       
                foreach (var book in list.AvailableBooks)
                {
                    write.WriteLine(book.ToCsvStringBook()); //Uses the method to convert properties into string
                }
            }
            //Saves BorrowedBooks list to a csv file
            using (StreamWriter writer = new StreamWriter(csvFilePathPerson))
            {               
                foreach (var borrower in list.borrowedBooks)
                {
                    writer.WriteLine(borrower.ToCsvStringBorrower());//Uses the method to convert properties into string
                }
            }
        }
        /// <summary>
        /// Loads all the data from csv and puts it in the AvailableBooks list
        /// </summary>
        /// <param name="filePath"></param>
        public void LoadAllBooks(string filePath)
        {
            using (StreamReader read = new StreamReader(filePath))
            {
                while (!read.EndOfStream) //Will loop until its loaded all data from the csv file
                {
                    string line = read.ReadLine(); //Takes the data from the csv-file and creates a series of long strings
                    string[] values = line.Split(","); //splits the "line" string at every comma and puts it into an array.

                    Book data = new Book(); //Creates a new objekt to return to list.
                    //Adds the value from each element into the coresponding property of the book class
                    if (int.TryParse(values[2], out int publishedValue)) //Makes sure it can parse the int
                    {
                        data.Title = values[0];
                        data.Author = values[1];
                        data.Published = publishedValue;
                        if (bool.TryParse(values[3], out bool borrowedValue)) //makes sure it can parse the bool
                        {
                            data.IsBorrowed = borrowedValue;
                        } 
                        data.BorrowerName = values[4];
                    }
                    AvailableBooks.Add(data); //adds each book back into the list.
                }
            }           
        }
        /// <summary>
        /// Loads all the data from csv and puts it in the BorrowedBooks list
        /// </summary>
        /// <param name="filePath"></param>
        public void LoadAllBorrowers(string filePath)
        {           
            using (StreamReader read = new StreamReader(filePath))
            {
                while (!read.EndOfStream)//Will loop until its loaded all data from the csv file
                {
                    string line = read.ReadLine();//Takes the data from the csv-file and creates a series of long strings
                    string[] values = line.Split(",");//splits the "line" string at every comma and puts it into an array.

                    Borrower data = new Borrower();//Creates a new objekt to return to list.
                    //Adds the value from each element into the coresponding property of the book class
                    if (int.TryParse(values[2], out int publishedValue))//Makes sure it can parse the int
                    {
                        data.Title = values[0];
                        data.Author = values[1];
                        data.Published = publishedValue;
                        if (bool.TryParse(values[3], out bool borrowedValue))//makes sure it can parse the bool
                        {
                            data.IsBorrowed= borrowedValue;   
                            data.BorrowerName = values[4];
                            data.BorrowerID = values[5];
                            if (int.TryParse(values[6], out int numberValue))//Makes sure it can parse the int
                            {
                                data.NumberBooks = numberValue;
                            }
                        }
                    }
                    BorrowedBooks.Add(data); //adds each book back into the list.
                }
            }
        }
    }
}
