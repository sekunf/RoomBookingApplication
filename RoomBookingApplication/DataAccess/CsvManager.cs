using RoomBookingApplication.BusinessLogic;

namespace RoomBookingApplication.DataAccess
{
    public class CsvManager
    {
        private readonly string _roomsFilePath = "rooms.csv";
        private readonly string _bookingsFilePath = "bookings.csv";

        public void SaveRooms(List<Rooms> rooms)
        {
            using (StreamWriter writer = new StreamWriter(_roomsFilePath))
            {
                foreach (var room in rooms)
                {
                    writer.WriteLine($"{room.RoomName},{room.SeatingCapacity},{room.Campus},{room.RoomType}");
                }
            }
        }

       

        public void SaveBookings(List<Booking> bookings)
        {
            using (StreamWriter writer = new StreamWriter(_bookingsFilePath))
            {
                foreach (var booking in bookings)
                {
                    writer.WriteLine($"{booking.BookingDate},{booking.StartTime},{booking.EndTime},{booking.ParticipantCount},{booking.AssociatedRoom.RoomName}");
                }
            }
        }

        public List<Rooms> LoadRooms()
        {
            if (File.Exists(_roomsFilePath))
            {
                List<Rooms> rooms = new List<Rooms>();
                string[] roomStrings = File.ReadAllLines(_roomsFilePath);

                foreach (string roomString in roomStrings)
                {
                    Rooms room = Rooms.Parse(roomString);
                    rooms.Add(room);
                }

                return rooms;
            }
            else
            {
                return null; 
            }
        }

        public List<Booking> LoadBookings()
        {
            if (File.Exists(_bookingsFilePath))
            {
                List<Booking> bookings = new List<Booking>();
                string[] bookingStrings = File.ReadAllLines(_bookingsFilePath);

                foreach (string bookingString in bookingStrings)
                {
                    Booking booking = Booking.Parse(bookingString);
                    bookings.Add(booking);
                }

                return bookings;
            }
            else
            {
                return null; 
            }
        }
    }
}
