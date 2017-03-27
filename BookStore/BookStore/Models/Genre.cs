using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Genre
    {
        public virtual int GenreId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual List<Book> Books { get; set; }

    }
}