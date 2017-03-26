using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FizzBuzzMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}