using RoomBookingApplication.BusinessLogic;
namespace RoomBookingApplication.Pages
{

    public partial class RoomListPage : ContentPage
    {
        Rooms _selectedRoom;
        BookingManager BookingManager;

        public Rooms SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                if (_selectedRoom == value)
                    return;

                _selectedRoom = value;
                OnPropertyChanged();
            }
        }
        public RoomListPage(BookingManager BookingManager)
        {
            InitializeComponent();
            BindingContext = BookingManager;

            this.BookingManager = BookingManager;
        }

        void BookRoomBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            AddBookingPage addBookingPage = new AddBookingPage(SelectedRoom, BookingManager);
            Navigation.PushAsync(addBookingPage);
        }
    }
}