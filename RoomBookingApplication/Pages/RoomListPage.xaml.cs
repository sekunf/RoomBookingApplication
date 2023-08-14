using RoomBookingApplication.BusinessLogic;
//using static Android.Provider.DocumentsContract;

namespace RoomBookingApplication.Pages;


public partial class RoomListPage : ContentPage
{

    BookingManager BookingManager;
    //Rooms _selectedRoom;
    public Rooms SelectedRoom;

    public RoomListPage(BookingManager BookingManager)
    {
        InitializeComponent();

        this.BookingManager = BookingManager;
        BindingContext = BookingManager;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RoomsListView.ItemsSource = null;
        RoomsListView.ItemsSource = BookingManager.RoomsList;

    }

    void BookRoomBtn_Clicked(object sender, EventArgs e)
    {
        SelectedRoom = (Rooms)RoomsListView.SelectedItem;
        if (SelectedRoom != null)
        {
            AddBookingPage addBookingPage = new AddBookingPage(SelectedRoom, BookingManager);
            Navigation.PushAsync(addBookingPage);
        }
        else
        {
            DisplayAlert("Error", "No room selected.", "OK");
        }
    }

    void FilterButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if (sender is Button button)
        {
            string buttonText = button.Text;

            switch (buttonText)
            {
                case "DAV":
                    BookingManager.FilterRoomsByCampus(Campus.DAV);
                    RoomsListView.ItemsSource = BookingManager.filteredRooms;
                    HMCButton.IsEnabled = false;
                    TRAButton.IsEnabled = false;
                    break;
                case "HMC":
                    BookingManager.FilterRoomsByCampus(Campus.HMC);
                    RoomsListView.ItemsSource = BookingManager.filteredRooms;
                    DAVButton.IsEnabled = false;
                    TRAButton.IsEnabled = false;
                    break;
                case "TRA":
                    BookingManager.FilterRoomsByCampus(Campus.TRA);
                    RoomsListView.ItemsSource = BookingManager.filteredRooms;
                    DAVButton.IsEnabled = false;
                    HMCButton.IsEnabled = false;
                    break;
                case "GroupStudy":
                    BookingManager.FilterRoomsByRoomType(RoomType.GroupStudy);
                    RoomsListView.ItemsSource = BookingManager.filteredRooms;
                    SilentStudyButton.IsEnabled = false;
                    IndividualStudyButton.IsEnabled = false;
                    break;
                case "SilentStudy":
                    BookingManager.FilterRoomsByRoomType(RoomType.SilentStudy);
                    RoomsListView.ItemsSource = BookingManager.filteredRooms;
                    GroupStudyButton.IsEnabled = false;
                    IndividualStudyButton.IsEnabled = false;
                    break;
                case "IndividualStudy":
                    BookingManager.FilterRoomsByRoomType(RoomType.IndividualStudy);
                    RoomsListView.ItemsSource = BookingManager.filteredRooms;
                    GroupStudyButton.IsEnabled = false;
                    SilentStudyButton.IsEnabled = false;
                    break;
            }
        }
    }

    void ClearFilterButton_Clicked(System.Object sender, System.EventArgs e)
    {
        BookingManager.ClearFilters();
        RoomsListView.ItemsSource = BookingManager.RoomsList;
        DAVButton.IsEnabled = true;
        HMCButton.IsEnabled = true;
        TRAButton.IsEnabled = true;
        GroupStudyButton.IsEnabled = true;
        SilentStudyButton.IsEnabled = true;
        IndividualStudyButton.IsEnabled = true;
    }

}