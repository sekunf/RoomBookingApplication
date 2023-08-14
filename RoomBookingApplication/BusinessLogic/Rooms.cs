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
        SilentStudy,
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
                _roomName = value;
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

        public int SeatingCapacity { get; set; }
        public Campus Campus { get; set; }
        public RoomType RoomType { get; set; }

        public Rooms(int seatingCapacity, Campus campus, RoomType roomType)
        {
            SeatingCapacity = seatingCapacity;
            Campus = campus;
            RoomType = roomType;
            RoomNumber = _nextRoomNumber++;
            RoomName = $"{Campus} {RoomNumber}"; // Construct the room name
        }

        public static Rooms Parse(string csvString)
        {
            var data = csvString.Split(',');
            if (data.Length == 4)
            {
                int seatingCapacity = int.Parse(data[1]);
                Campus campus = (Campus)Enum.Parse(typeof(Campus), data[2]);
                RoomType roomType = (RoomType)Enum.Parse(typeof(RoomType), data[3]);

                return new Rooms(seatingCapacity, campus, roomType)
                {
                    RoomName = data[0]
                };
            }
            return null;
        }

    }
}
