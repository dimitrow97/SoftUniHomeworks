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
            //Go to the Context and remove the comment tags from the migrate to latest version
            //Compile to create the db
            //Go back and place the comment tags from where you deleted them
            //Move on to BookShopQueries
            BookShopContext context = new BookShopContext();
            context.Database.Initialize(true);
            SetRelatedBooks(context);
            var bookCount = context.Books.Count();
        }

        private static void SetRelatedBooks(BookShopContext context)
        {        
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
