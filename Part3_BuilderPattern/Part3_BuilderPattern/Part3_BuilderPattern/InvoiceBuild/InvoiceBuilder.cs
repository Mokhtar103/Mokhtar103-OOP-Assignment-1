using Part3_BuilderPattern.AddressBuild;
using Part3_BuilderPattern.OrderBuild;
using System;
using System.Collections.Generic;
using System.Text;

namespace Part3_BuilderPattern.InvoiceBuild
{
    public class InvoiceBuilder
    {
        private int _invoiceId;
        private string? _customerName;
        private string? _customerEmail;
        private string? _customerPhone;

        private Address? _billingAddress = null!;
        private Address? _shippingAddress = null!;

        private Order? _order = null!;

        public InvoiceBuilder(
        int invoiceId,
        string customerName,
        string customerPhone,
        Address billingAddress,
        Address shippingAddress,
        Order order
       )
        {
            _invoiceId = invoiceId;
            _customerName = customerName;
            _customerPhone = customerPhone;
            _billingAddress = billingAddress;
            _shippingAddress = shippingAddress;
            _order = order;
        }
        public InvoiceBuilder SetCustomerEmail(string customerEmail)
        {
            _customerEmail = customerEmail;
            return this;
        }

        public Invoice Build()
        {
            
            return new Invoice(
                _invoiceId,
                _customerName,
                _customerEmail,
                _customerPhone,
                _billingAddress,
                _shippingAddress,
                _order  
            );
        }
    }
}
