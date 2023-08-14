using RoomBookingApplication.BusinessLogic;
namespace RoomBookingApplication.Pages;

public partial class AddBookingPage : ContentPage
{
 
    Rooms SelectedRoom;
    
    BookingManager BookingManager;
   

    public AddBookingPage(Rooms SelectedRoom, BookingManager BookingManager)
    {
        InitializeComponent();
        this.SelectedRoom = SelectedRoom;
        this.BookingManager = BookingManager;
        RoomNameLabel.Text = SelectedRoom.RoomName; 

        BindingContext = this;
    }

    private async void AddBookingButton_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            DateTime bookingDate = BookingDatePicker.Date;
            TimeSpan startTime = StartTimePicker.Time;
            TimeSpan endTime = EndTimePicker.Time;
            int participantCount = int.Parse(ParticipantCountEntry.Text);

            BookingManager.AddBooking(SelectedRoom.RoomName, bookingDate, startTime, endTime, participantCount);

            await DisplayAlert("Success", "Booking added successfully", "OK");
            await Navigation.PopAsync();
            

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}
