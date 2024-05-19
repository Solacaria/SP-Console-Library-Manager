using Bilbiotek;

//Creating objects of each class
Book manager = new Book();
Library library = new Library();
Book.Borrower person = new Book.Borrower();
SavedListsAndData savedLists = new SavedListsAndData();

string csvFilePathBook = "BookList.csv"; 
string csvFilePathPerson = "PersonList.csv";

if (File.Exists("BookList.csv")) //checks if file exists 
{
    savedLists.LoadAllBooks(csvFilePathBook);
}
if (File.Exists("PersonList.csv"))//checks if file exists 
{
    savedLists.LoadAllBorrowers(csvFilePathPerson);
}

//Creates an object of UI with all other objects
UI userUI = new UI(library, manager, person, savedLists);
userUI.MainMenu(); //starts the main menu







