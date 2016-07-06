using KMS.UnitTestTraining.Entities;
using KMS.UnitTestTraining.Repositories;
using System;
using System.Collections.Generic;

namespace KMS.UnitTestTraining.Services
{
    public class OrderService : IOrderService
    {
        private decimal tax = 0.05M;
        private IOrderRepository orderRepository;
        private IOrderItemRepository orderItemRepository;
        private IProductRepository productRepository;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository)
        {
            if (orderRepository == null)
            {
                throw new ArgumentNullException("orderRepository params it not allow to null");
            }

            if (orderItemRepository == null)
            {
                throw new ArgumentNullException("orderItemRepository params it not allow to null");
            }

            if (productRepository == null)
            {
                throw new ArgumentNullException("productRepository params it not allow to null");
            }

            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
            this.productRepository = productRepository;
        }

        public void AddNewOrder(IList<Product> product)
        {
            if (product == null || product.Count == 0)
            {
                throw new ArgumentException("Product entities is empty");
            }

            Order newOrder = new Order(1, 1, "123 Cong Hoa");

            foreach (var productItem in product)
            {
                OrderItem orderItem = new OrderItem(1, newOrder.OrderId, productItem.Id, 1);
                orderItemRepository.Insert(orderItem);
            }
        }

        public decimal CalculateFinalPrice(int orderId)
        {
            if (orderId <= 0)
            {
                throw new ArgumentException("orderId is not valid");
            }

            decimal total = 0;
            int range = 50;
            var orderItemList = orderItemRepository.GetAll();

            foreach (var orderItem in orderItemList)
            {
                if (orderItem.OrderId == orderId)
                {
                    var product = productRepository.GetProductById(orderItem.ProductId);
                    if (product.Price > range)
                    {
                        total += product.Price * tax * orderItem.Quantity;
                    }
                    total += product.Price * orderItem.Quantity;
                }
            }
            return total;
        }

        public IList<Product> GetAllProductByOrderId(int orderId)
        {
            IList<Product> productList = new List<Product>();

            if (orderId <= 0)
            {
                throw new ArgumentException("Order id is not valid");
            }

            var orderItemList = orderItemRepository.GetAll();

            foreach (var order in orderItemList)
            {
                if (order.OrderId == orderId)
                {
                    var product = productRepository.GetProductById(order.ProductId);
                    productList.Add(product);
                }
            }

            return productList;
        }

        public void UpdateProductQuantity(int orderId, int productId, int quantity)
        {
            if (orderId <= 0)
            {
                throw new ArgumentException("orderID is not valid");
            }

            if (productId <= 0)
            {
                throw new ArgumentException("productId is not valid");
            }

            if (quantity < 0)
            {
                throw new ArgumentException("quantity is not valid");
            }

            var orderItemList = orderItemRepository.GetAll();

            foreach (var orderItem in orderItemList)
            {
                if (orderItem.OrderId == orderId && orderItem.ProductId == productId)
                {
                    orderItem.Quantity = quantity;
                }
            }
        }
    }
}