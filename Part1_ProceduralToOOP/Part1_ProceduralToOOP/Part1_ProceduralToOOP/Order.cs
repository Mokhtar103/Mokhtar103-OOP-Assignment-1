using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Part1_ProceduralToOOP
{
    public class Order
    {
        private readonly List<OrderLine> _orderLines = new List<OrderLine>();

        public int Id { get; }

        public Customer Customer { get; } = null!;

        public string Date { get; } = null!;

        public bool IsPaid { get; private set; }

        public IReadOnlyList<OrderLine> Items => _orderLines;

        public Order(int id, Customer customer, string date)
        {

            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));
            if (string.IsNullOrWhiteSpace(date))
                throw new ArgumentNullException(nameof(date));

            Id = id;
            Customer = customer;
            Date = date;
            IsPaid = false;
        }

        public bool AddItem(Product product, int quantity)
        {
            if (IsPaid)
            {
                Console.WriteLine("Cannot change a paid order");
                return false;
            }
            
            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be positive");
                return false;
            }

            if (!product.HasEnoughStock(quantity))
            {
                Console.WriteLine($"not enough stock for {product.Name} product");
                return false;
            }

            product.ReduceStock(quantity);

            var item = new OrderLine(product, quantity);

            _orderLines.Add(item);

            return true;

        }

        public decimal CalculateTotal()
        {
            decimal total = 0;

            foreach (var item in _orderLines)
            {
                total += item.GetLineTotal();
            }

            return Customer.ApplyDiscount(total);
        }

        public bool Pay()
        {
            if (_orderLines.Count == 0)
            {
                Console.WriteLine("Cannot pay an empty order");
                return false;
            }

            IsPaid = true;
            return true;
        }
    }
}
