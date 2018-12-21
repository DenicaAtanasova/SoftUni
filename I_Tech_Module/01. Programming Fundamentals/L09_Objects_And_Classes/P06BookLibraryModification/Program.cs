using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace P06BookLibraryModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Book> bookList = new List<Book>();

            while (n-- > 0)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string title = input[0];
                string author = input[1];
                string publisher = input[2];
                DateTime releaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                int isbnNumber = int.Parse(input[4]);
                double price = double.Parse(input[5]);

                Book book = new Book
                {
                    Title = title,
                    Author = author,
                    Publiser = publisher,
                    ReleaseDate = releaseDate,
                    ISBNnumber = isbnNumber,
                    Price = price
                };
                bookList.Add(book);
            }
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            List<Book> booksReleasedAfterDate = new List<Book>();
            foreach (var book in bookList)
            {
                if (book.ReleaseDate > date)
                {
                    booksReleasedAfterDate.Add(book);
                }
            }
            foreach (var book in booksReleasedAfterDate
                                    .OrderBy(x => x.ReleaseDate)
                                    .ThenBy(x => x.Title))
            {
                Console.WriteLine("{0} -> {1}", book.Title, (book.ReleaseDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)));
            }
        }
    }
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publiser { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ISBNnumber { get; set; }
        public double Price { get; set; }
    }
}
