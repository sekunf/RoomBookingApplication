using Microsoft.Maui.Controls;
using RoomBookingApplication.BusinessLogic;
using System;

namespace RoomBookingApplication.Pages
{
    public partial class EditBookingPage : ContentPage
    {
        private Booking SelectedBooking; 
        private BookingManager BookingManager;


        public EditBookingPage(Booking SelectedBooking, BookingManager BookingManager)
        {
            InitializeComponent();

            this.SelectedBooking = SelectedBooking;
            this.BookingManager = BookingManager;

            RoomNameLabel.Text = SelectedBooking.AssociatedRoom.RoomName;
            BookingDatePicker.Date = SelectedBooking.BookingDate;
            StartTimePicker.Time = SelectedBooking.StartTime;
            EndTimePicker.Time = SelectedBooking.EndTime;
            ParticipantCountEntry.Text = SelectedBooking.ParticipantCount.ToString();

            

        }



        private async void UpdateBookingButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                int newParticipantCount = int.Parse(ParticipantCountEntry.Text);

                if (BookingManager.BookingIsValid(SelectedBooking, newParticipantCount, SelectedBooking.AssociatedRoom))
                {
                    SelectedBooking.BookingDate = BookingDatePicker.Date;
                    SelectedBooking.StartTime = StartTimePicker.Time;
                    SelectedBooking.EndTime = EndTimePicker.Time;
                    SelectedBooking.ParticipantCount = newParticipantCount;
                    await DisplayAlert("Sucessful", $"Booking Updated Sucessfully", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }


        private async void DeleteBookingButton_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                bool userAcceptance = await DisplayAlert("Confirmation", "Are you sure you want to delete this booking?", "Yes", "No");

                if (userAcceptance)
                {
                    BookingManager.DeleteBooking(SelectedBooking);
                    await DisplayAlert("Success", "Booking deleted successfully.", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

    }
}

