using Part3_BuilderPattern.AddressBuild;
using Part3_BuilderPattern.InvoiceBuild;
using Part3_BuilderPattern.OrderBuild;

namespace Part3_BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Address billingAddress = new AddressBuilder("123 Main Street", "Alexandria", "Egypt")
                                        .SetState("Alexandria")
                                        .SetZipCode("21500")
                                        .Build();

            Address shippingAddress = new AddressBuilder("456 King Street", "Cairo", "Egypt")
                                          .SetState("Cairo")
                                          .SetZipCode("11511")
                                          .Build();

            Order order = new OrderBuilder(DateTime.Now, 1000m, 100m, 90m, 990m)
                              .SetPaymentMethod("Credit Card")
                              .SetCurrency("EGP")
                              .Build();

            Invoice invoice = new InvoiceBuilder(1001,"Ahmed Mohamed", "01012345678", billingAddress, shippingAddress, order)
                                .Build();
        }
    }
}
