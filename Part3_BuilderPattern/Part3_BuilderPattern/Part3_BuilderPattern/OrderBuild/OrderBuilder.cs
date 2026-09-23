using System;
using System.Collections.Generic;
using System.Text;

namespace Part3_BuilderPattern.OrderBuild
{
    public class OrderBuilder
    {
        private DateTime _orderDate;
        private string? _paymentMethod;
        private string? _currency;

        private decimal _subTotal;
        private decimal _discountAmount;
        private decimal _taxAmount;
        private decimal _totalAmount;

        public OrderBuilder
            (DateTime orderdate,
            decimal subTotal,
            decimal discountAmount,
            decimal taxAmount,
            decimal totalAmount)
        {
            _orderDate = orderdate;
            _subTotal = subTotal;
            _discountAmount = discountAmount;
            _taxAmount = taxAmount;
            _totalAmount = totalAmount;
        }

        public OrderBuilder SetPaymentMethod(string paymentMethod)
        {
            _paymentMethod = paymentMethod;
            return this;
        }

        public OrderBuilder SetCurrency(string currency)
        {
            _currency = currency;
            return this;
        }

        public Order Build()
        {
            if (_orderDate == default)
                throw new InvalidOperationException("Order date is required.");

            if (string.IsNullOrWhiteSpace(_paymentMethod))
                throw new InvalidOperationException("Payment method is required.");

            if (string.IsNullOrWhiteSpace(_currency))
                throw new InvalidOperationException("Currency is required.");

            return new Order(
                _orderDate,
                _paymentMethod,
                _currency,
                _subTotal,
                _discountAmount,
                _taxAmount,
                _totalAmount);
        }

    }
}
