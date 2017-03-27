using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Author
    {
        public virtual int AuthorId { get; set; }
        public virtual string Name { get; set; }
    }
}