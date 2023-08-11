//using static Android.Provider.ContactsContract.CommonDataKinds;
using RoomBookingApplication.BusinessLogic;
namespace RoomBookingApplication.Pages;

public partial class MyBookingsPage : ContentPage
{
	
        BookingManager _BookingManager = new BookingManager();


        public BookingManager BookingManager
        {
            get
            {
                return _BookingManager;
            }

        }

        public MyBookingsPage()
        {
        InitializeComponent();
            

            BindingContext = this;
        }

    void HelpPageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        HelpPage helpPage = new HelpPage();
        Navigation.PushAsync(helpPage);
    }

}

