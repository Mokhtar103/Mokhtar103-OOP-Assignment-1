using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class OrderSystem
    {
        private readonly List<Customer> _customers = new List<Customer>();
        private readonly List<Product> _products = new List<Product>();

        private readonly List<Order> _orders = new List<Order>();

        private Customer? FindCustomerById(int id)
        {
            for (int i = 0; i < _customers.Count; i++)
            {
                if (_customers[i].Id == id)
                {
                    return _customers[i];
                }
            }

            return null;
        }

        private Product? FindProductById(int id)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Id == id)
                {
                    return _products[i];
                }
            }

            return null;
        }

        private Order? FindOrderById(int id)
        {
            for (int i = 0; i < _orders.Count; i++)
            {
                if (_orders[i].Id == id)
                {
                    return _orders[i];
                }
            }

            return null;
        }

        public void AddCustomer(int id, string name, string email, string city, bool isVip)
        {
            if (FindCustomerById(id) != null)
            {
                Console.WriteLine($"Customer with id {id} already exists");
                return;
            }

            var customer = new Customer(id, name, email, city, isVip);

            _customers.Add(customer);
        }

        public void PrintCustomers()
        {
            Console.WriteLine($"\n=== ({_customers.Count}) CUSTOMERS ===");

            foreach (Customer customer in _customers)
            {
                Console.WriteLine(
                    $"#{customer.Id}  " +
                    $"{customer.Name}  " +
                    $"<{customer.Email}>  " +
                    $"{customer.City}  " +
                    $"vip={(customer.IsVip ? "yes" : "no")}"
                );
            }
        }

        public void AddProduct(int id, string name, decimal price, int stock)
        {
            if (FindProductById(id) != null)
            {
                Console.WriteLine($"ERROR: product id {id} already exists.");
                return;
            }

            var product = new Product(id, name, price, stock);

            _products.Add(product);
        }

        public void PrintProducts()
        {
            Console.WriteLine($"\n=== ({_products.Count}) PRODUCTS ===");

            foreach (Product product in _products)
            {
                Console.WriteLine(
                    $"#{product.Id}  " +
                    $"{product.Name}  " +
                    $"price={product.Price:F2}  " +
                    $"stock={product.Stock}"
                );
            }
        }

        public Order? CreateOrder(int orderId, int customerId, string date)
        {
            if (FindOrderById(orderId) != null)
            {
                Console.WriteLine($"Order with id {orderId} already exists");
                return null;
            }

            Customer? customer = FindCustomerById(customerId);

            if (customer == null)
            {
                Console.WriteLine($"Customer with id {customerId} not found");

                return null;
            }

            var order = new Order(orderId, customer, date);

            _orders.Add(order);

            return order;
        }

        public void AddItemToOrder(int orderId, int productId, int quantity)
        {
            Order? order = FindOrderById(orderId);

            if (order == null)
            {
                Console.WriteLine($"Order with id {orderId} not found");
                return;
            }

            Product? product = FindProductById(productId);

            if (product == null)
            {
                Console.WriteLine($"Product with id {productId} not found");

                return;
            }

            order.AddItem(product, quantity);
        }

        public void MarkOrderPaid(int orderId)
        {
            Order? order = FindOrderById(orderId);

            if (order == null)
            {
                Console.WriteLine($"Order with id {orderId} not found");

                return;
            }

            order.Pay();
        }

        public void PrintOrder(int orderId)
        {
            Order? order = FindOrderById(orderId);

            if (order == null)
            {
                Console.WriteLine($"Order with id {orderId} not found");

                return;
            }

            Console.WriteLine($"\n=== ORDER #{order.Id} ===");
            Console.WriteLine($"Date: {order.Date}");

            Console.WriteLine(
                $"Customer: {order.Customer.Name} " +
                $"(#{order.Customer.Id})"
            );

            Console.WriteLine(
                $"Paid: {(order.IsPaid ? "yes" : "no")}"
            );

            Console.WriteLine("Items:");

            foreach (var item in order.Items)
            {
                decimal itemTotal = item.GetLineTotal();

                Console.WriteLine(
                    $"  - {item.Product.Name}  " +
                    $"x{item.Quantity}  " +
                    $"@{item.Product.Price:F2}  " +
                    $"= {itemTotal:F2}"
                );
            }

            Console.WriteLine(
                $"TOTAL: {order.CalculateTotal():F2}"
            );
        }

        public void PrintAllOrders()
        {
            Console.WriteLine(
                $"\n=== ALL ORDERS ({_orders.Count}) ==="
            );

            foreach (Order order in _orders)
            {
                PrintOrder(order.Id);
            }
        }

        public decimal CalculateTotalSales()
        {
            decimal total = 0;

            foreach (Order order in _orders)
            {
                if (order.IsPaid)
                {
                    total += order.CalculateTotal();
                }
            }

            return total;
        }

    }
}
