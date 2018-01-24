using BookShopSystem.Data;
using BookShopSystem.Models;
using System;
using System.Linq;
using System.Globalization;

namespace BookShopQueries
{
    class StartUp
    {
        static void Main(string[] args)
        {
            // Undo the comments 1 by 1 to check each tast.
            BookShopContext context = new BookShopContext();

            // 1.Books Titles by Age Restriction
            //string word = Console.ReadLine().ToLower();
            //BooksTitlesByAgeRestriction(word);

            // 2.Golden Books
            //GoldenBooks();

            // 3.Books by Price
            //BooksByPrice();

            // 4.Not Released Books
            //int year = int.Parse(Console.ReadLine());
            //NotReleasedBooks(year);

            // 5.Books Titles by Categories
            //string[] categoryNames = Console.ReadLine().Split(' ').Select(p => p.ToLower()).ToArray();
            //BooksTitlesByCategories(categoryNames);

            // 6.Books Released Before Date
            //int[] dateInput = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
            //DateTime date = new DateTime(dateInput[2], dateInput[1], dateInput[0]);
            //BooksReleasedBeforeDate(date);

            // 7.Authors Search
            //string part = Console.ReadLine().ToLower();
            //AuthorSearch(part);

            // 8.Books Search
            //string part = Console.ReadLine().ToLower();
            //BookSearch(part);

            // 9.Book Title Search
            //string part = Console.ReadLine().ToLower();
            //BookTitleSearch(part);

            // 10.Count Books
            //int symbolLimit = int.Parse(Console.ReadLine());
            //CountBooks(symbolLimit);

            // 11.Total Book Copies
            //TotalBookCopies();

            // 12.Find Profit
            //FindProfit();

            // 13.Most Recent Books
            //MostRecentBooks();

            // 14.Increase Book Copies
            //IncreaseBookCopies();

            // 15.Remove Books
            //RemoveBooks();

            // 16.Stored Procedure
            #region SQL Procedure
            /*CREATE PROCEDURE GetBooksCountByAuthor(@firstName varchar(30), @lastName Varchar(30))
              AS
              BEGIN
              SELECT COUNT(*) FROM Books
              WHERE AuthorId = (SELECT Id FROM Authors AS a
                                WHERE a.FirstName = @firstName AND a.LastName = @lastName)
              END*/
            #endregion
            //string[] authorName = Console.ReadLine().Split(' ');
            //StoredProcedure(authorName);            
        }

        public static void StoredProcedure(string[] name)
        {
            BookShopContext context = new BookShopContext();
            var count = context.Database.SqlQuery<int>($"EXEC dbo.GetBooksCountByAuthor {name[0]}, {name[1]}").First();
            Console.WriteLine($"{name[0]} {name[1]} has written {count} books");
        }

        public static void RemoveBooks()
        {
            BookShopContext context = new BookShopContext();
            int count = 0;
            foreach (var book in context.Books.Where(w => w.Copies < 4200))
            {
                count++;
                context.Books.Remove(book);
            }
            context.SaveChanges();
            Console.WriteLine($"{count} books were deleted");
        }

        public static void IncreaseBookCopies()
        {
            BookShopContext context = new BookShopContext();
            DateTime date = new DateTime(2013, 6, 6);
            int count = 0;
            foreach (var book in context.Books.Where(w => w.ReleaseDate.Value > date))
            {
                count++;
                book.Copies += 44;
            }
            context.SaveChanges();
            Console.WriteLine(count * 44);
        }

        public static void MostRecentBooks()
        {
            BookShopContext context = new BookShopContext();
            foreach (var category in context.Categories.Where(a => a.Books.Count() > 35).OrderByDescending(a => a.Books.Count()).Select(c => new { c.Name, c.Books }))
            {
                Console.WriteLine($"--{category.Name}: {category.Books.Count()} books");
                foreach (var book in category.Books.OrderByDescending(w => w.ReleaseDate).ThenBy(w => w.Title).Take(3))
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
        }

        public static void FindProfit()
        {
            BookShopContext context = new BookShopContext();
            foreach (var category in context.Categories.OrderByDescending(a => a.Books.Sum(b => b.Price * b.Copies)).ThenBy(w => w.Name))
            {
                Console.WriteLine($"{category.Name} - ${category.Books.Sum(b => b.Price * b.Copies)}");
            }
        }

        public static void TotalBookCopies()
        {
            BookShopContext context = new BookShopContext();
            foreach (var author in context.Authors.OrderByDescending(a => a.Books.Sum(b => b.Copies)))
            {                
                Console.WriteLine($"{author.FirstName} {author.LastName} - {author.Books.Sum(b => b.Copies)}");
            }        
        }

        public static void CountBooks(int limit)
        {
            BookShopContext context = new BookShopContext();
            var books = context.Books.Where(w => w.Title.Length > limit).ToList();
            Console.WriteLine(books.Count);
        }

        public static void BookTitleSearch(string part)
        {
            BookShopContext context = new BookShopContext();            
            foreach (var book in context.Books.Where(w => w.Author.LastName.ToLower().StartsWith(part)).OrderBy(w => w.Id))
            {                
                Console.WriteLine($"{book.Title} ({book.Author.FirstName} {book.Author.LastName})");                
            }
        }

    public static void BookSearch(string part)
        {
            BookShopContext context = new BookShopContext();
            foreach (var book in context.Books.Where(w => w.Title.Contains(part)))
            {
                Console.WriteLine(book.Title);
            }
        }

        public static void AuthorSearch(string part)
        {
            BookShopContext context = new BookShopContext();
            foreach(var author in context.Authors.Where(w => w.FirstName.EndsWith(part)))
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
            }
        }

        public static void BooksReleasedBeforeDate(DateTime date)
        {
            BookShopContext context = new BookShopContext();
            foreach(var book in context.Books.Where(w => w.ReleaseDate < date))
            {
                Console.WriteLine($"{book.Title} - {book.Edition} - {book.Price}");
            }
        }
        public static void BooksTitlesByCategories(string[] categoryNames)
        {
            BookShopContext context = new BookShopContext();
            foreach(var book in context.Books.Where(p => p.Categories.Any(w => categoryNames.Contains(w.Name.ToLower()))))
            {
                Console.WriteLine(book.Title);
            }
        }

        public static void NotReleasedBooks(int year)
        {
            BookShopContext context = new BookShopContext();
            var notReleased = context.Books.Where(b => b.ReleaseDate.Value.Year != year).OrderBy(w => w.Id).ToList();
            foreach(var book in notReleased)
            {
                Console.WriteLine(book.Title);
            }
        }

        public static void BooksByPrice()
        {
            BookShopContext context = new BookShopContext();
            var books = context.Books.Where(p => p.Price < 5 || p.Price > 40).OrderBy(w => w.Id).ToList();
            foreach (var Book in books)
            {
                Console.WriteLine($"{Book.Title} - {Book.Price}");
            }
        }

        public static void GoldenBooks()
        {
            BookShopContext context = new BookShopContext();
            var goldenBooks = context.Books.Where(g => (int)g.Edition == 2 && g.Copies < 5000).OrderBy(w => w.Id).ToList();
            foreach(var gBook in goldenBooks)
            {
                Console.WriteLine(gBook.Title);
            }
        }

        public static void BooksTitlesByAgeRestriction(string word)
        {
            BookShopContext context = new BookShopContext();
            int input = -1;
            switch (word)
            {
                case "minor": input = 0; break;
                case "teen": input = 1; break;
                case "adult": input = 2; break;

                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }
            var booksByAge = context.Books.Where(y => (int)y.AgeRestriction == input).ToList();
            foreach (var book in booksByAge)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
