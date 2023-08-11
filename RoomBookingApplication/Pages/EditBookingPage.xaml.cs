using Microsoft.Maui.Controls;
using RoomBookingApplication.BusinessLogic;
using System;

namespace RoomBookingApplication.Pages
{
    public partial class EditBookingPage : ContentPage
    {
        private Booking _currentBooking; 
        private BookingManager _bookingManager; 

        public EditBookingPage(Booking booking)
        {
            InitializeComponent();

            _currentBooking = booking;
            _bookingManager = new BookingManager();

           
            BookingDatePicker.Date = _currentBooking.BookingDate;
            StartTimePicker.Time = _currentBooking.StartTime;
            EndTimePicker.Time = _currentBooking.EndTime;
            ParticipantCountEntry.Text = _currentBooking.ParticipantCount.ToString();

           

        }

        

        private void UpdateBookingButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                
                _currentBooking.BookingDate = BookingDatePicker.Date;
                _currentBooking.StartTime = StartTimePicker.Time;
                _currentBooking.EndTime = EndTimePicker.Time;
                _currentBooking.ParticipantCount = int.Parse(ParticipantCountEntry.Text);

                

                DisplayAlert("Success", "Booking updated successfully!", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}
