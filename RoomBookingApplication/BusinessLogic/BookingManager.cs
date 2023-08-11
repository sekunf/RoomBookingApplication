using System;
using System.Collections.Generic;
using System.Linq;
using static RoomBookingApplication.BusinessLogic.Rooms;

namespace RoomBookingApplication.BusinessLogic
{
    public class BookingManager
    {
        private List<Rooms> _roomsList;
        private List<Booking> _bookings;

        public BookingManager()
        {
            _roomsList = new List<Rooms>();
            _bookings = new List<Booking>();
        }

        public void AddRoom(int seatingCapacity, Campus campus, RoomType roomType)
        {
            Rooms newRoom = new Rooms(seatingCapacity, campus, roomType);
            _roomsList.Add(newRoom);
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

        // New method to retrieve a list of all rooms
        public List<Rooms> GetAllRooms()
        {
            return _roomsList;
        }

        // New method to fetch a specific booking by its ID
        public Booking GetBookingById(int id)
        {
            return _bookings.FirstOrDefault(b => b.BookingId == id);
        }

        // New method to update a booking
        public void UpdateBooking(Booking updatedBooking)
        {
            var existingBooking = _bookings.FirstOrDefault(b => b.BookingId == updatedBooking.BookingId);

            if (existingBooking == null)
                throw new InvalidOperationException("Booking doesn't exist.");

            existingBooking.BookingDate = updatedBooking.BookingDate;
            existingBooking.StartTime = updatedBooking.StartTime;
            existingBooking.EndTime = updatedBooking.EndTime;
            existingBooking.ParticipantCount = updatedBooking.ParticipantCount;
            existingBooking.AssociatedRoom = updatedBooking.AssociatedRoom;
        }
    }
}
