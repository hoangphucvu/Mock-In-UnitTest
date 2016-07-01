using KMS.UnitTestTraining.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.UnitTestTraining.Repositories
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
    }
}
