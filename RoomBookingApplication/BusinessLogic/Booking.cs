using System;
using RoomBookingApplication.BusinessLogic;
namespace RoomBookingApplication.BusinessLogic
{
    public class Booking
    {
       

        public int BookingId { get; set; }
            public DateTime BookingDate { get; set; }
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }
            public int ParticipantCount { get; set; }


            public Rooms AssociatedRoom { get; set; }


            private static int _nextRequestID = 1;


            public Booking()
            {
                BookingId = _nextRequestID++;

            }

        


            public bool IsDurationValid()
            {
            return StartTime < EndTime;
        }

            public bool IsDurationTooLong()
            {
                TimeSpan duration = EndTime - StartTime;

                if (duration.TotalHours <= 3)
                {
                    return false;
                }

                return true;
            }
        public bool IsBookingDateTooFar()
        {
            TimeSpan difference = BookingDate - DateTime.Now;

            
            return difference.TotalDays > 3;
        }

        public static Booking Parse(string csvString)
        {
            var data = csvString.Split(',');
            if (data.Length == 5)
            {
                DateTime bookingDate = DateTime.Parse(data[0]);
                TimeSpan startTime = TimeSpan.Parse(data[1]);
                TimeSpan endTime = TimeSpan.Parse(data[2]);
                int participantCount = int.Parse(data[3]);
                string roomName = data[4];

                BookingManager bookingManager = new BookingManager();
                Rooms associatedRoom = bookingManager.FindRoomByName(roomName);

                return new Booking
                {
                    BookingDate = bookingDate,
                    StartTime = startTime,
                    EndTime = endTime,
                    ParticipantCount = participantCount,
                    AssociatedRoom = associatedRoom
                };
            }
            return null;
        }




    }
}

