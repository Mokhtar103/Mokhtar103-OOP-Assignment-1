namespace Part2_HotelReservationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel();

            Guest guest1 = new Guest(
                1,
                "Ahmed Mohamed",
                "01012345678"
            );

            Guest guest2 = new Guest(
                2,
                "Omar Ali",
                "01198765432"
            );

            hotel.AddGuest(guest1);
            hotel.AddGuest(guest2);


            Room room101 = new Room(
                101,
                RoomType.Single,
                100m
            );

            Room room201 = new Room(
                201,
                RoomType.Double,
                200m
            );

            Room room301 = new Room(
                301,
                RoomType.Suite,
                500m
            );

            hotel.AddRoom(room101);
            hotel.AddRoom(room201);
            hotel.AddRoom(room301);



            Reservation reservation1 = hotel.CreateReservation(
                1001,
                guest1,
                room201,
                3,
                new DateTime(2026, 10, 1),
                new DateTime(2026, 10, 5)
            );

            Console.WriteLine("Reservation created successfully.");
            Console.WriteLine($"Reservation ID: {reservation1.Id}");
            Console.WriteLine($"Guest: {guest1.FullName}");
            Console.WriteLine($"Room: {reservation1.Room.Number}");
            Console.WriteLine($"Total Nights: {reservation1.Nights}");
            Console.WriteLine($"Status: {reservation1.Status}");
            Console.WriteLine($"Total Cost: {reservation1.TotalCost}");




            reservation1.Confirm();

            Console.WriteLine();
            Console.WriteLine($"Status after confirmation: {reservation1.Status}");



            reservation1.CheckIn();

            Console.WriteLine($"Status after check-in: {reservation1.Status}");




            reservation1.CheckOut();

            Console.WriteLine($"Status after check-out: {reservation1.Status}");



            Console.WriteLine();
            Console.WriteLine($"{guest1.FullName}'s Reservation History:");

            foreach (Reservation reservation in guest1.Reservations)
            {
                Console.WriteLine(
                    $"Reservation {reservation.Id} - " +
                    $"Room {reservation.Room.Number} - " +
                    $"{reservation.Status} - " +
                    $"Total: {reservation.TotalCost}"
                );

            }
        }
    }
}
