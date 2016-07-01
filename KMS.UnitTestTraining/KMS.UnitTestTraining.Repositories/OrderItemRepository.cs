using KMS.UnitTestTraining.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.UnitTestTraining.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {

        public OrderItem GetOrderItemById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<OrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
