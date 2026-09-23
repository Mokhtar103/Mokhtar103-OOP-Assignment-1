using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
    public class Hotel
    {
        private readonly List<Guest> _guests = new();
        private readonly List<Room> _rooms = new();
        private readonly List<Reservation> _reservations = new();

        public IReadOnlyList<Guest> Guests => _guests;
        public IReadOnlyList<Room> Rooms => _rooms;
        public IReadOnlyList<Reservation> Reservations => _reservations;

        public void AddGuest(Guest guest)
        {
            foreach (var assignedGuest in _guests)
            {
                if (assignedGuest.Id == guest.Id)
                {
                    throw new InvalidOperationException(
                    $"Guest with ID {guest.Id} already exists");
                }
            }
            
            _guests.Add(guest);
        }

        public void AddRoom(Room room)
        {

            foreach(var assignedRoom in _rooms)
            {
                if (assignedRoom.Number == room.Number)
                {
                    throw new InvalidOperationException(
                   $"Room {room.Number} already exists");
                }
            }

            _rooms.Add(room);
        }

        public Reservation CreateReservation(
        int reservationId,
        Guest guest,
        Room room,
        int nights,
        DateTime checkInDate,
        DateTime checkOutDate)
        {

            if (!_guests.Contains(guest))
            {
                throw new InvalidOperationException(
                    "Guest does not belong to this hotel");
            }

            if (!_rooms.Contains(room))
            {
                throw new InvalidOperationException(
                    "Room does not belong to this hotel");
            }

            foreach(var assignedReservation in _reservations)
            {
                if (assignedReservation.Id == reservationId)
                    throw new InvalidOperationException($"Reservation with ID {reservationId} already exists");
            }

            if (room.IsUnderMaintenance)
            {
                throw new InvalidOperationException(
                    $"Room {room.Number} is currently under maintenance");
            }


            foreach (Reservation reservation in _reservations)
            {
                if (reservation.Room == room &&
                    reservation.Status != ReservationStatus.Cancelled &&
                    reservation.Status != ReservationStatus.CheckedOut)
                {
                    bool overlaps =
                        checkInDate < reservation.CheckOutDate &&
                        checkOutDate > reservation.CheckInDate;

                    if (overlaps)
                    {
                        throw new InvalidOperationException($"Room {room.Number} is already booked for the selected dates.");
                    }
                }    
            }
            Reservation newReservation = new Reservation(
                   reservationId,
                   nights,
                   checkInDate,
                   checkOutDate,
                   room
               );

            _reservations.Add(newReservation);
            guest.AddReservation(newReservation);

            return newReservation;
        }
    }
}
