namespace BookShopSystem
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            BookShopContext context = new BookShopContext();
            context.Database.Initialize(true);
            SetRelatedBooks(context);
            var bookCount = context.Books.Count();
        }

        private static void SetRelatedBooks(BookShopContext context)
        {
            Console.WriteLine("\n**************************************************************");
            Console.WriteLine("Solution to Step 6.Related Books - Make first 3 books related\n");

            // Set Related Books
            List<Book> books = context.Books.Take(3).ToList();
            books[0].RelatedBooks.Add(books[1]);
            books[1].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);
            books[2].RelatedBooks.Add(books[0]);
            context.SaveChanges();

            // Query Related Books
            books = context.Books.Take(3).ToList();
            foreach (Book book in books)
            {
                Console.WriteLine($"--{book.Title}");
                foreach (Book relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.Title);
                }
            }
        }
    }
}
