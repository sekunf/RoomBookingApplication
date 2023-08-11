using RoomBookingApplication.BusinessLogic;
namespace RoomBookingApplication.Pages;

public partial class AddBookingPage : ContentPage
{

    private Rooms SelectedRoom;
    
    private BookingManager BookingManager;
    public Booking booking;

    public AddBookingPage(Rooms SelectedRoom ,BookingManager BookingManager)
    {
        InitializeComponent();

        this.SelectedRoom = SelectedRoom;
        this.BookingManager = BookingManager;

        

    }

    private async void AddBookingButton_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            //int newParticipantCount = int.Parse(ParticipantCountEntry.Text);

            
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}
