using System;
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
                if(StartTime < EndTime)
                {
                    return true;
                }
                return false;
            }

            public bool IsDurationTooLong()
            {
                TimeSpan duration = EndTime - StartTime;

                if (duration.TotalHours > 3)
                {
                    return true;
                }

                return false;
            }

        


    }
}

