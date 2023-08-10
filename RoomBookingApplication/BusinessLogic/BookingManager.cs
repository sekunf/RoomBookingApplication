using System;
using System.Collections.Generic;
using System.Linq;
using static RoomBookingApplication.BusinessLogic.Rooms;

namespace RoomBookingApplication.BusinessLogic
{
    public class BookingManager
    {
        private List<Rooms> _roomsList; // Changed type to List<Room>
        private List<Booking> _bookings;

        public BookingManager()
        {
            _roomsList = new List<Rooms>();
            _bookings = new List<Booking>();
        }

        public void AddRoom(int seatingCapacity, Campus campus, RoomType roomType)
        {
            Rooms newRoom = new (seatingCapacity, campus, roomType);

            _roomsList.Add(newRoom);  // Added this line to actually add the room
        }

        public void AddBooking(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));

            if (booking.IsDurationValid() && !booking.IsDurationTooLong())
            {
                _bookings.Add(booking);
            }
            else
            {
                throw new InvalidOperationException("Booking duration is invalid.");
            }
        }

        public List<Booking> GetBookingsForRoom(Rooms room)
        {
            if (room == null)
                throw new ArgumentNullException(nameof(room));

            return _bookings.Where(b => b.AssociatedRoom != null && b.AssociatedRoom.RoomNumber == room.RoomNumber).ToList();
        }

        // Optionally, you can add other utility methods as you mentioned.
    }
}
