﻿//using static Android.Provider.ContactsContract.CommonDataKinds;
using RoomBookingApplication.BusinessLogic;
using RoomBookingApplication.DataAccess;
namespace RoomBookingApplication.Pages;

public partial class MyBookingsPage : ContentPage
{

    public static string CurrentUser { get; set; }
    BookingManager _BookingManager = new BookingManager();
    CsvManager CsvManager = new CsvManager();

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

        
        if (CsvManager.LoadRooms() == null)
        {
            BookingManager.GenerateRandomRooms();
            CsvManager.SaveRooms(BookingManager.RoomsList);
        }
        else
        {
            BookingManager.RoomsList = CsvManager.LoadRooms();
        }

        
        //List<Booking> loadedBookings = CsvManager.LoadBookings();
        if (CsvManager.LoadBookings() != null)
        {
            BookingManager.Bookings = CsvManager.LoadBookings();
        }
        else
        {
            EditBookingBtn.IsEnabled = false;
        }

        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BookingsListView.ItemsSource = null;
        BookingsListView.ItemsSource = BookingManager.Bookings;

        if (BookingManager.Bookings.Count > 0)
        {
            EditBookingBtn.IsEnabled = true;
        }
    }

    void HelpPageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        HelpPage helpPage = new HelpPage();
        Navigation.PushAsync(helpPage);
    }

    void NewBookingBtnClicked(System.Object sender, System.EventArgs e)
    {
        RoomListPage roomListPage = new RoomListPage(BookingManager);
        Navigation.PushAsync(roomListPage);

    }

    void EditBookingBtnClicked(System.Object sender, System.EventArgs e)
    {
        EditBookingPage editBookingPage = new EditBookingPage(SelectedBooking,BookingManager);
        Navigation.PushAsync(editBookingPage);
    }

    void UserProfileButton_Clicked(System.Object sender, System.EventArgs e)
    {
        UserProfilePage userProfilePage = new UserProfilePage(MyBookingsPage.CurrentUser);
        Navigation.PushAsync(userProfilePage);
    }




}

