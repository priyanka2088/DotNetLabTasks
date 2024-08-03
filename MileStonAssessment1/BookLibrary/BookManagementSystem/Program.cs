using BookLibrary;
namespace BookManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating List of Book Class Objects 
            List<Book> books = new List<Book>();
            Console.WriteLine("=========Book Management system=========");
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Display all Books");
                Console.WriteLine("3. Delete a Book by ID");
                Console.WriteLine("4. Exit");
                Console.Write("Choose your Option: ");

                char option;
                if (!char.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Please Enter correct Option");
                }
                else
                {

                    switch (option)
                    {
                        case '1':
                            AddBook(books);
                            break;
                        case '2':
                            DisplayBooks(books);
                            break;
                        case '3':
                            DeleteBook(books);
                            break;
                        case '4':
                            Console.WriteLine("Thank you, Visit again");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }
            }
        }

        // Add New Book
        static void AddBook(List<Book> books)
        {
            Book newBook = new Book(0, "", "", 0.0, "", 0); 
            newBook.AddBookDetails();                    
            books.Add(newBook);                             
            Console.WriteLine("Book added successfully.");
        }

        // Display all books
        static void DisplayBooks(List<Book> books)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine($"Book ID: {book.BookID}, Book Name: {book.BookName}, ISBN No: {book.ISBNNo}, Price: {book.Price}, " +
                                  $"Publisher: {book.Publisher},No of Pages: {book.NumberOfPages}, Language: {book.Language}, " +
                                  $"LoT: {book.LoT}, Summary: {book.Summary}");
            }
        }

        //Delete Book by ID
        static void DeleteBook(List<Book> books)
        {
            Console.WriteLine("Enter the Book ID to delete: ");
            string id = Console.ReadLine();
            int bookId;
            bool ISValidId = int.TryParse(id,out bookId);
            while (!ISValidId)
            {
                Console.WriteLine("Enter Book ID in Correct Format :");
                id= Console.ReadLine();
                if (id.Length == 5)
                {
                    ISValidId = int.TryParse(id, out bookId);
                }
                else
                {
                    ISValidId = false;
                }
                
            }
    
            Book filteredBook = books.Find(b => b.BookID == bookId);        
            if ( filteredBook!= null)
            {
                books.Remove(filteredBook);
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }
}