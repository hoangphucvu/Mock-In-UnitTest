using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BookStoreDbInitializer : DropCreateDatabaseAlways<BookStoreContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            context.Authors.Add(new Author { Name = "Jesse Liberty" });
            context.Authors.Add(new Author { Name = "Dickens" });
            context.Authors.Add(new Author { Name = "Melville" });
            context.Authors.Add(new Author { Name = "Stephenson" });
            context.Genres.Add(new Genre { Name = "Programming" });
            context.Genres.Add(new Genre { Name = "Non-Fiction" });

            context.Books.Add(new Book
            {
                Author = new Author { Name = "Proust" },
                Genre = new Genre { Name = "Fiction" },
                Price = 19.95m,
                Title = "In Search of Lost Time"
            });


            base.Seed(context);
        }
    }
}