using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
    public enum RoomType
    {
        Single,
        Double,
        Suite

    }
    public class Room
    {
        public int Number { get; }

        public RoomType? Type { get; } = null!;

        public decimal NightlyRate { get; private set; }

        public bool IsUnderMaintenance { get; private set; } = false;

        public Room(int number, RoomType type, decimal initialRate)
        {
            if (initialRate < 0)
                throw new ArgumentException("Nightly rate cannot be negative");

            Number = number;
            Type = type;
            NightlyRate = initialRate;
        }

        public void UpdateNightlyRate(decimal newRate)
        {
            if (newRate < 0)
                throw new ArgumentException("Nightly rate cannot be negative");

            NightlyRate = newRate;
        }

        public void StartMaintenance()
        {
            if (IsUnderMaintenance)
                throw new InvalidOperationException("Room is already under maintenance.");

            IsUnderMaintenance = true;
        }

        public void EndMaintenance()
        {
            if (!IsUnderMaintenance)
                throw new InvalidOperationException("Room is not currently under maintenance.");

            IsUnderMaintenance = false;
        }

    }
}
