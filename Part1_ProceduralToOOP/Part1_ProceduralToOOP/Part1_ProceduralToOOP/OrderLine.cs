using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class OrderLine
    {
        public Product Product { get; } = null!;
        public int Quantity { get; }

        public OrderLine(Product product, int quantity)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            Product = product;
            Quantity = quantity;
        }

        public decimal GetLineTotal()
        {
            return Product.Price * Quantity;
        }

    }
}
