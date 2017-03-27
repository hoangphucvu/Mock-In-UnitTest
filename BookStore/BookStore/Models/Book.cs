using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        public virtual int BookId { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int AuthorId { get; set; }
        public virtual string Title { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Author Author { get; set; }
    }
}