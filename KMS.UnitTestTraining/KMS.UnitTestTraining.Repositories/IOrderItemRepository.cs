using KMS.UnitTestTraining.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.UnitTestTraining.Repositories
{
    public interface IOrderItemRepository
    {
        OrderItem GetOrderItemById(int id);
        IList<OrderItem> GetAll();
        void Insert(OrderItem orderItem);
        void Update(OrderItem orderItem);
    }
}
