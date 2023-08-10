using System;
namespace RoomBookingApplication.BusinessLogic
{
	public class Rooms
	{

        

        public enum Campus
        {
            DAV,
            HMC,
            TRA
        }

        public enum Type
        {
            GroupStudy,
            IndividualStudy,
            SilentSTudy,
            
        }
            
        public class Room
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

            public Type RoomType { get; set; }


            public Room(int seatingCapacity, Campus campus, Type roomType)
            {
                
                SeatingCapacity = seatingCapacity;
                Campus = campus;
                RoomType = roomType;
                RoomNumber = _nextRoomNumber++;
            }

        }
    }


}


