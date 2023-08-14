using RoomBookingApplication.BusinessLogic;
using System;


namespace RoomBookingApplication.Pages
{
    public partial class UserProfilePage : ContentPage
    {
        // Assuming you're passing the username of the current logged in user to this page
        private string _currentUsername;

        public UserProfilePage(string username)
        {
            InitializeComponent();

            // Store the username
            _currentUsername = username;

            // Display details
            UsernameLabel.Text = username;
            PasswordEntry.Text = User.UserInfo[username]; // Note: Displaying password in plain text isn't recommended. This is just for the example.
        }

        private void OnUpdatePasswordClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordEntry.Text))
            {
                DisplayAlert("Error", "Password cannot be empty", "OK");
                return;
            }

            // Update password in the dictionary
            User.UserInfo[_currentUsername] = PasswordEntry.Text;
            DisplayAlert("Success", "Password updated successfully!", "OK");
        }
    }
}