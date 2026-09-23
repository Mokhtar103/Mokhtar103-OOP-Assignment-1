using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
    public class Guest
    {

        private readonly List<Reservation> _reservations = new();
        public int Id { get; }
        public string? FullName { get; } = null!;

        public string? PhoneNumber { get; } = null!;

        public IReadOnlyList<Reservation> Reservations => _reservations;

        public Guest(int id, string fullName, string phoneNumber)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("id must be greater than 0");
            if (String.IsNullOrWhiteSpace(fullName))
                throw new ArgumentNullException("Guest full name cannot be empty");
            if (String.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException("Guest phone number cannot be empty");

            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public void AddReservation(Reservation reservation)
        {
            _reservations.Add(reservation);
        }
    }
}
