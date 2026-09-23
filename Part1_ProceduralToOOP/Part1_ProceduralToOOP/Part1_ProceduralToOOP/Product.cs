using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Product
    {
        public int Id { get; }
        public string? Name { get; } = null!;
        public decimal Price { get; }

        public int Stock { get; private set; }
        public Product(int id, string? name, decimal price, int stock)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            if (stock < 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public bool HasEnoughStock(int quantity)
        { 
            return Stock >= quantity;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity > Stock)
            {
                throw new InvalidOperationException("Not enough stock available");
            }
            Stock -= quantity;
        }
    }
}
