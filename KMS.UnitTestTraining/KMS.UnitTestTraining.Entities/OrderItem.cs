using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.UnitTestTraining.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public OrderItem(int orderItemId, int orderId, int productId, int quantity)
        {
            this.OrderItemId = orderItemId;
            this.OrderId = orderId;
            this.ProductId = productId;
            this.Quantity = quantity;
        }
    }
}
