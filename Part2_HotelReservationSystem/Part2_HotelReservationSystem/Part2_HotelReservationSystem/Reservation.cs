using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        CheckedIn,
        CheckedOut,
        Cancelled,


    }
    public class Reservation
    {
        public int Id { get; }
        public DateTime? CheckInDate { get; } = null!;

        public DateTime? CheckOutDate { get; } = null!;

        public int Nights { get; }

        public decimal TotalCost => Nights * Room.NightlyRate;

        public Room Room { get; } = null!;

        public ReservationStatus Status { get; private set; } = default;

        public Reservation(int id, int nights, DateTime checkInDate, DateTime checkOutDate, Room room)
        {
            if (room.IsUnderMaintenance)
                throw new InvalidOperationException("Cannot reserve a room that is currently under maintenance");

            if (nights <= 0)
                throw new ArgumentException("Number of nights must be greater than zero");

            if (checkOutDate <= checkInDate)
                throw new ArgumentException("Check-out date must be after check-in date");

            Id = id;
            Nights = nights;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Room = room;
            Status = ReservationStatus.Pending;
        }

        public void Confirm()
        {
            if (Status != ReservationStatus.Pending)
            {
                throw new InvalidOperationException(
                    "Only a pending reservation can be confirmed");
            }

            Status = ReservationStatus.Confirmed;
        }

        public void CheckIn()
        {
            if (Status != ReservationStatus.Confirmed)
            {
                throw new InvalidOperationException(
                    "A reservation must be confirmed before check-in");
            }

            Status = ReservationStatus.CheckedIn;
        }

        public void CheckOut()
        {
            if (Status != ReservationStatus.CheckedIn)
            {
                throw new InvalidOperationException(
                    "Only a checked-in reservation can be checked out");
            }

            Status = ReservationStatus.CheckedOut;
        }

        public void Cancel()
        {
            if (Status != ReservationStatus.Pending &&
            Status != ReservationStatus.Confirmed)
            {
                throw new InvalidOperationException(
                    "Only pending or confirmed reservations can be cancelled");
            }

            Status = ReservationStatus.Cancelled;
        }


    }
}
