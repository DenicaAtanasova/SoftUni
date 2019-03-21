namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                //Console.WriteLine(GetBooksByAgeRestriction(db, "TeEn"));
                //Console.WriteLine(GetGoldenBooks(db));
                //Console.WriteLine(GetBooksByPrice(db));
                //Console.WriteLine(GetBooksNotReleasedIn(db, 2000));
                //Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));
                //Console.WriteLine(GetBooksReleasedBefore(db, "30-12-1989"));
                //Console.WriteLine(GetAuthorNamesEndingIn(db, "dy"));
                //Console.WriteLine(GetBookTitlesContaining(db, "WOR"));
                //Console.WriteLine(GetBooksByAuthor(db, "R"));
                //Console.WriteLine(CountBooks(db, 40));
                //Console.WriteLine(CountCopiesByAuthor(db));
                //Console.WriteLine(GetTotalProfitByCategory(db));
                //Console.WriteLine(GetMostRecentBooks(db));
                //IncreasePrices(db);
                Console.WriteLine(RemoveBooks(db));
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var filteredBooks = context
                            .Books
                            .Where(b => b.AgeRestriction == ageRestriction)
                            .Select(b => b.Title)
                            .OrderBy(t => t)
                            .ToArray();

            return String.Join(Environment.NewLine, filteredBooks);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldEdition = Enum.Parse<EditionType>("Gold");

            var filteredBooks = context

                .Books
                .Where(b => b.EditionType == goldEdition)
                .Where(b => b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, filteredBooks);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var filteredBooks = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} -" +
                $" ${b.Price:F2}")
                .ToArray();

            return String.Join(Environment.NewLine, filteredBooks);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var filteredBooks = context
                .Books
                .Where(b =>b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, filteredBooks);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var filteredBooks = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return String.Join(Environment.NewLine, filteredBooks);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var filteredBooks = context.Books
                .Where(b => b.ReleaseDate < releaseDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
                .ToArray();

            return String.Join(Environment.NewLine, filteredBooks);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var filteredAuthors = context.Authors
               .Where(a => a.FirstName.EndsWith(input))
               .Select(a => $"{a.FirstName} {a.LastName}")
               .OrderBy(a => a)
               .ToArray();

            return String.Join(Environment.NewLine, filteredAuthors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var filteredBooks = context.Books
               .Where(b => b.Title.ToLower().Contains(input.ToLower()))
               .Select(b => b.Title)
               .OrderBy(b => b)
               .ToArray();

            return String.Join(Environment.NewLine, filteredBooks);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var filteredBooks = context.Books
               .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
               .OrderBy(b => b.BookId)
               .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
               .ToArray();

            return String.Join(Environment.NewLine, filteredBooks);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var bookCopies = context.Authors
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .Select(x => $"{x.FullName} - {x.Copies}")
                .ToArray();

            return String.Join(Environment.NewLine, bookCopies);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoriesProfit = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.CategoryName)
                .Select(x => $"{x.CategoryName} ${x.Profit:F2}")
                .ToArray();

            return String.Join(Environment.NewLine, categoriesProfit);                
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks.Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate
                    })
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .Select(b => $"{b.Title} ({b.ReleaseDate.Value.Year})")
                })
                .OrderBy(x => x.CategoryName)
                .Select(x => $"--{x.CategoryName}" + Environment.NewLine + string.Join(Environment.NewLine, x.Books));

            return string.Join(Environment.NewLine, categories);
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(b => b.Price += 5);

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var deletedBooks = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.RemoveRange(deletedBooks);
            context.SaveChanges();

            return deletedBooks.Length;
        }
    }
}
