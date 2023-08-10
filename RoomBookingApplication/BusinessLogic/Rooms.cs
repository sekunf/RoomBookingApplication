using System;
namespace RoomBookingApplication.BusinessLogic
{
	
        
        public enum Campus
        {
            DAV,
            HMC,
            TRA
        }

        public enum RoomType
        {
            GroupStudy,
            IndividualStudy,
            SilentSTudy,
            
        }
            
        public class Rooms
        {
            private string _roomName;
            private int _roomNumber;
            private static int _nextRoomNumber = 101;

            public string RoomName
            {
                get
                {
                    return _roomName;
                }
                set
                {
                    _roomName = $"{Campus} {_roomNumber}";
                }
            }


            public int RoomNumber
            {
                get
                {
                    return _roomNumber;
                }

                set
                {
                    _roomNumber = value;
                }
            }

            public int SeatingCapacity
            {
                get;
                set;
            }

            public Campus Campus
            {
                get;
                set;
            }

            public RoomType RoomType { get; set; }


            public Rooms(int seatingCapacity, Campus campus, RoomType roomType)
            {
                SeatingCapacity = seatingCapacity;
                Campus = campus;
                RoomType = roomType;
                RoomNumber = _nextRoomNumber++;
            }

        }
    


}


