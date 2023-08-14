using System;
using System.Collections.Generic;
using System.Linq;
using static RoomBookingApplication.BusinessLogic.Rooms;
using RoomBookingApplication.DataAccess;

namespace RoomBookingApplication.BusinessLogic
{
    public class BookingManager
    {
        private List<Rooms> _roomsList;
        private List<Booking> _bookings;
        public List<Rooms> filteredRooms = new List<Rooms>();
        public List<Rooms> RoomsList
        {
            get { return _roomsList; }
            set { _roomsList = value; }
        }

        public List<Booking> Bookings
        {
            get { return _bookings; }
            set { _bookings = value; }
        }

        public BookingManager()
        {
            _roomsList = new List<Rooms>();
            _bookings = new List<Booking>();
        }

        CsvManager CsvManager = new CsvManager();
        
        public void AddRoom(int seatingCapacity, Campus campus, RoomType roomType)
        {
            Rooms newRoom = new Rooms(seatingCapacity, campus, roomType);
            _roomsList.Add(newRoom);
            CsvManager.SaveRooms(RoomsList);
        }

        public void AddBooking(string roomName, DateTime bookingDate, TimeSpan startTime, TimeSpan endTime, int participantCount)
        {
            Booking booking = new Booking();

           
            booking.BookingDate = bookingDate;
            booking.StartTime = startTime;
            booking.EndTime = endTime;
            booking.ParticipantCount = participantCount;

            
            Rooms room = FindRoomByName(roomName);
            booking.AssociatedRoom = room;

            if (BookingIsValid(booking, participantCount, room))
            {
                _bookings.Add(booking);
                CsvManager.SaveBookings(Bookings);
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
                throw new Exception("Booking duration is too long\nCannot be longer than 3 Hours.");
            }
            else if (participantCount > room.SeatingCapacity)
            {
                throw new Exception($"Participant count exceeds room seating capacity\nRoom only seats {room.SeatingCapacity} people.");
            }
            else if (booking.IsBookingDateTooFar())
            {
                throw new Exception("The booking is more than 3 days from today.");
            }
            else if (HasConflictingBooking(booking, Bookings))
            {
                throw new Exception("There is a conflicting booking for the same room and time.");
            }

            return true;
        }

        private bool HasConflictingBooking(Booking newBooking, List<Booking> existingBookings)
        {
            foreach (var existingBooking in existingBookings)
            {
                if (existingBooking.AssociatedRoom == newBooking.AssociatedRoom &&
                    (newBooking.StartTime < existingBooking.EndTime) &&
                    (newBooking.EndTime > existingBooking.StartTime))
                {
                    return true; // Conflicting booking found
                }
            }

            return false; // No conflicting booking found
        }

        // run it in the here so it checks for the 3 days greater or not
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
        

        //FILTERS

        public List<Rooms> FilterRoomsByCampus(Campus campus)
        {
            List<Rooms> newFilteredRooms = new List<Rooms>();

            if (filteredRooms.Count == 0)
            {
                foreach (var room in _roomsList)
                {
                    if (room.Campus == campus)
                    {
                        newFilteredRooms.Add(room);
                    }
                }
            }
            else
            {
                foreach (var room in filteredRooms)
                {
                    if (room.Campus == campus)
                    {
                        newFilteredRooms.Add(room);
                    }
                }
            }

            filteredRooms = newFilteredRooms;
            return filteredRooms;
        }

        public List<Rooms> FilterRoomsByRoomType(RoomType roomType)
        {
            List<Rooms> newFilteredRooms = new List<Rooms>();

            if (filteredRooms.Count == 0)
            {
                foreach (var room in _roomsList)
                {
                    if (room.RoomType == roomType)
                    {
                        newFilteredRooms.Add(room);
                    }
                }
            }
            else
            {
                foreach (var room in filteredRooms)
                {
                    if (room.RoomType == roomType)
                    {
                        newFilteredRooms.Add(room);
                    }
                }
            }

            filteredRooms = newFilteredRooms;
            return filteredRooms;
        }



        public void ClearFilters()
        {
            filteredRooms = new List<Rooms>();
            
        }


        //-DUMMY DATA

        public void GenerateRandomRooms()
        {

            Random random = new Random();
            for (int i = 0; i < 35; i++)
            {
                int randomSeatingCapacity = random.Next(1, 11); 
                Campus randomCampus = (Campus)random.Next(0,3);
                RoomType randomRoomType = (RoomType)random.Next(0,3);

                AddRoom(randomSeatingCapacity, randomCampus, randomRoomType);
            }

        }
    }
}

