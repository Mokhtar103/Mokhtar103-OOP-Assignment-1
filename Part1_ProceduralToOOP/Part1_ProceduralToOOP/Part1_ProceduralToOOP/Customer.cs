using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Customer
    {
        public int Id { get; }
        public string? Name { get; } = null!;

        public string Email { get; } = null!;

        public string? City { get; } = null!;

        public bool IsVip { get; }

        public Customer(int id, string? name, string email, string? city, bool isVip)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            Id = id;
            Name = name;
            Email = email;
            City = city;
            IsVip = isVip;
        }

        public decimal ApplyDiscount(decimal totalAmount)
        {
            if (IsVip)
            {
                return totalAmount * 0.9m;
            }
            return totalAmount;
        }


    }
}
