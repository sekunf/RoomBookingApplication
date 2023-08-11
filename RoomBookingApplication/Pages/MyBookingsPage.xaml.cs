//using static Android.Provider.ContactsContract.CommonDataKinds;
using RoomBookingApplication.BusinessLogic;
namespace RoomBookingApplication.Pages;

public partial class MyBookingsPage : ContentPage
{
	

        BookingManager _BookingManager = new BookingManager();

		

   



    public BookingManager BookingManager{ get { return _BookingManager; } }

    Booking _selectedBooking;
    public Booking SelectedBooking
    {
        get { return _selectedBooking; }
        set
        {
            if (_selectedBooking == value)
                return;

            _selectedBooking = value;
            OnPropertyChanged();
        }
    }



    public MyBookingsPage()
    {

        InitializeComponent();
            
        BookingManager.AddRoom(4, Campus.DAV, RoomType.GroupStudy);
        BookingManager.AddRoom(4, Campus.DAV, RoomType.GroupStudy);
        BookingManager.AddRoom(4, Campus.HMC, RoomType.GroupStudy);

        DateTime dummyBookingDate = new DateTime(2023, 8, 12); // Dummy booking date
        TimeSpan startTime = new TimeSpan(10, 0, 0); // Start time
        TimeSpan endTime = new TimeSpan(13, 0, 0); // End time
        int participantCount = 4; // Participant count

        BookingManager.AddBooking("DAV 102", dummyBookingDate, startTime, endTime, participantCount);

        BindingContext = this;
    }

    void HelpPageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        HelpPage helpPage = new HelpPage();
        Navigation.PushAsync(helpPage);
    }

    void NewBookingBtnClicked(System.Object sender, System.EventArgs e)
    {

    }

    void EditBookingBtnClicked(System.Object sender, System.EventArgs e)
    {
        EditBookingPage editBookingPage = new EditBookingPage(SelectedBooking,BookingManager);
        Navigation.PushAsync(editBookingPage);
    }
}

