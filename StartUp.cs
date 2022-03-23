using BookShop.Models;
namespace BookShop
{
    
    using Data;
    using System;
    using System.Linq;
    using System.Text;
    

    public class StartUp
    {
        public static void Main()
        {
            using BookShopContext db = new BookShopContext();
            
            //Console.WriteLine(GetBooksFullInformation(db));
            //Console.WriteLine(FilterDataByPrice(db));
            string filter = Console.ReadLine();
            Console.WriteLine(FilterDataByAuthor(db, filter));
        }

        //In the project “BookShop.Data” click on “Configuration.cs” 
        //Check if the server name in the path is the same like in Microsoft SQL Management Studio. 
        //If it's not, change it.

        // Get Books Full Information
        public static string GetBooksFullInformation(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books.Select(x => new { x.BookId, x.Title, x.Description, x.Price, x.Author.FirstName, x.Author.LastName });
            foreach(var book in books)
            {
                sb.Append($"ID:{book.BookId}");
                sb.Append($"Title:{book.Title}");
                sb.Append($"Description:{book.Description}");
                sb.Append($"Price:{book.Price:f2}");
                sb.Append($"Author:{book.FirstName}");
                sb.Append($"Author:{book.LastName}\n");
            }

            return sb.ToString().Trim();
        }

        // Filter Data by Price
        public static string FilterDataByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context.Books.Select(x => new { x.Title, x.Price });
            foreach(var book in books)
            {
                if(book.Price > 25)
                {
                    sb.Append($"{book.Title} - ${book.Price:f2} ");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Filter Data by Author
        public static string FilterDataByAuthor(BookShopContext context, string input)
        {

            var sb = new StringBuilder();

            var books = context.Books.Select(x => new { x.Title, x.Author.FirstName, x.Author.LastName });
            foreach(var book in books)
            {
                if (book.LastName == input)
                {
                    sb.Append($"{book.Title} ({book.FirstName} {book.LastName})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        // Change Description
        public static string ChangeDescription(BookShopContext context, int id)
        {
            StringBuilder sb = new StringBuilder();

            //ToDo...

            return sb.ToString().Trim();
        }

    }
}
