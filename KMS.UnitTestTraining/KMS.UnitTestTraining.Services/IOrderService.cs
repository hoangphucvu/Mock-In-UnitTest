using KMS.UnitTestTraining.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.UnitTestTraining.Services
{
    public interface IOrderService
    {
        void AddNewOrder(IList<Product> product);
        void UpdateProductQuantity(int orderId, int productId, int quantity);
        IList<Product> GetAllProductByOrderId(int orderId);
        decimal CalculateFinalPrice(int orderId);
    }
}
