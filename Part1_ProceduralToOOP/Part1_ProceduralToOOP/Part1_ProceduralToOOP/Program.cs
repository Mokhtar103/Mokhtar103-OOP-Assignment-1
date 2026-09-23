namespace Part1_ProceduralToOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orderSystem = new OrderSystem();

            SeedSampleData(orderSystem);
            RunDemoScenario(orderSystem);

            orderSystem.PrintCustomers();
            orderSystem.PrintProducts();
            orderSystem.PrintAllOrders();

            Console.WriteLine(
                $"\nPaid sales total after demo: " +
                $"{orderSystem.CalculateTotalSales():F2}");

            RunInteractiveMenu(orderSystem);

        }
        public static void SeedSampleData(OrderSystem system)
        {
            system.AddCustomer(
                1,
                "Mona Ali",
                "mona@example.com",
                "Cairo",
                true
            );

            system.AddCustomer(
                2,
                "Omar Hassan",
                "omar@example.com",
                "Alexandria",
                false
            );

            system.AddCustomer(
                3,
                "Sara Nabil",
                "sara@example.com",
                "Giza",
                false
            );

            system.AddProduct(
                101,
                "USB Cable",
                50.0m,
                100
            );

            system.AddProduct(
                102,
                "Wireless Mouse",
                250.0m,
                40
            );

            system.AddProduct(
                103,
                "Mechanical Keyboard",
                1200.0m,
                15
            );

            system.AddProduct(
                104,
                "Laptop Stand",
                400.0m,
                25
            );
        }

        static void RunDemoScenario(OrderSystem system)
        {
            system.CreateOrder(
                1001,
                1,
                "2026-09-15"
            );

            system.AddItemToOrder(
                1001,
                101,
                2
            );

            system.AddItemToOrder(
                1001,
                102,
                1
            );

            system.MarkOrderPaid(1001);

            system.CreateOrder(
                1002,
                2,
                "2026-09-15"
            );

            system.AddItemToOrder(
                1002,
                103,
                1
            );

            system.AddItemToOrder(
                1002,
                104,
                1
            );

            system.CreateOrder(
                1003,
                3,
                "2026-09-16"
            );

            system.AddItemToOrder(
                1003,
                101,
                5
            );

            system.MarkOrderPaid(1003);
        }

        static void RunInteractiveMenu(OrderSystem system)
        {
            int choice = -1;

            while (choice != 0)
            {
                Console.WriteLine("\n---------- MENU ----------");
                Console.WriteLine("1) Print customers");
                Console.WriteLine("2) Print products");
                Console.WriteLine("3) Print all orders");
                Console.WriteLine("4) Print one order by id");
                Console.WriteLine("5) Create order");
                Console.WriteLine("6) Add item to order");
                Console.WriteLine("7) Mark order paid");
                Console.WriteLine("8) Show paid sales total");
                Console.WriteLine("0) Exit");
                Console.Write("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        system.PrintCustomers();
                        break;

                    case 2:
                        system.PrintProducts();
                        break;

                    case 3:
                        system.PrintAllOrders();
                        break;

                    case 4:
                        Console.Write("Order id: ");
                        int orderId = int.Parse(Console.ReadLine()!);

                        system.PrintOrder(orderId);
                        break;

                    case 5:
                        Console.Write("Order id: ");
                        int newOrderId = int.Parse(Console.ReadLine()!);

                        Console.Write("Customer id: ");
                        int customerId = int.Parse(Console.ReadLine()!);

                        Console.Write("Date: ");
                        string date = Console.ReadLine()!;

                        system.CreateOrder(newOrderId, customerId ,date);

                        break;

                    case 6:
                        Console.Write("Order id: ");
                        int itemOrderId = int.Parse(Console.ReadLine()!);

                        Console.Write("Product id: ");
                        int productId = int.Parse(Console.ReadLine()!);

                        Console.Write("Quantity: ");
                        int quantity = int.Parse(Console.ReadLine()!);

                        system.AddItemToOrder(itemOrderId, productId, quantity);

                        break;

                    case 7:
                        Console.Write("Order id: ");
                        int paymentOrderId = int.Parse(Console.ReadLine()!);

                        system.MarkOrderPaid(paymentOrderId);
                        break;

                    case 8:
                        Console.WriteLine(
                            $"Paid sales total: " +
                            $"{system.CalculateTotalSales():F2}"
                        );

                        break;

                    case 0:
                        Console.WriteLine("Bye");
                        break;

                    default:
                        Console.WriteLine("Unknown choice");
                        break;
                }
            }
        }
    }
}
