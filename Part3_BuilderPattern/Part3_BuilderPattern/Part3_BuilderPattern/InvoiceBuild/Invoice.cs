using Part3_BuilderPattern.AddressBuild;
using Part3_BuilderPattern.OrderBuild;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Part3_BuilderPattern.InvoiceBuild
{

    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string? CustomerName { get; set; } = null!;
        public string? CustomerEmail { get; set; } = null!;
        public string? CustomerPhone { get; set; } = null!;

        public Address? BillingAddress { get; } = null!;
        public Address? ShippingAddress { get; } = null!;

        public Order? Order { get; } = null!;

        public Invoice(
        int invoiceId,
        string customerName,
        string customerEmail,
        string customerPhone,
        Address billingAddress,
        Address shippingAddress,
        Order order

        )

        {
            InvoiceId = invoiceId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            Order = order;
        }
    }

}
