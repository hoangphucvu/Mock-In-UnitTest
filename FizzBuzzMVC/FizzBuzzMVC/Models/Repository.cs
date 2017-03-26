using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzMVC.Models
{
    public interface Repository
    {
        List<Product> GetAll();
    }
}
