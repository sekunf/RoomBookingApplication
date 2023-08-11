using System;
using System.Collections.Generic;
using System.Linq;
//using static Android.Provider.DocumentsContract;
//using static Android.Provider.DocumentsContract;
using static RoomBookingApplication.BusinessLogic.Rooms;

namespace RoomBookingApplication.BusinessLogic
{
    public class BookingManager
    {
        private List<Rooms> _roomsList;
        private List<Booking> _bookings;

        public List<Rooms> RoomsList
        {
            get { return _roomsList; }
        }

        public List<Booking> Bookings
        {
            get { return _bookings; }
        }

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

        public void AddBooking(string roomName, DateTime bookingDate, TimeSpan startTime, TimeSpan endTime, int participantCount)
        {
            Booking booking = new Booking();

            // Set properties for the newly created booking
            booking.BookingDate = bookingDate;
            booking.StartTime = startTime;
            booking.EndTime = endTime;
            booking.ParticipantCount = participantCount;

            
            Rooms room = FindRoomByName(roomName);
            booking.AssociatedRoom = room;

            if (BookingIsValid(booking, participantCount, room))
            {
                _bookings.Add(booking);
            }
           


        }

        public bool BookingIsValid(Booking booking, int participantCount, Rooms room)
        {
            if (!booking.IsDurationValid())
            {
                throw new Exception("Booking duration is invalid.");
            }
            else if (booking.IsDurationTooLong())
            {
                throw new Exception("Booking duration is too long.");
            }
            else if (participantCount > room.SeatingCapacity)
            {
                throw new Exception("Participant count exceeds room seating capacity.");
            }

            return true;
        }


        public Rooms FindRoomByName(string roomName)
        {
            foreach (Rooms room in _roomsList)
            {
                if (room.RoomName == roomName)
                {
                    return room;
                }
            }

            return null; // Room with the given name was not found
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

        public void DeleteBooking(Booking deleteBooking)
        {
            if (deleteBooking == null)
                throw new ArgumentException("Booking doesn't exist");
            _bookings.Remove(deleteBooking);
        }

        public void DeleteRooms(Rooms rooms)
        {
            if (rooms == null)
                throw new ArgumentException("Booking doesn't exist");
            _roomsList.Remove(rooms);
        }


    }
}
