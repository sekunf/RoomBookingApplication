namespace RoomBookingApplication.Pages;
using RoomBookingApplication.BusinessLogic;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void LoginButton_Clicked(System.Object sender, System.EventArgs e)
    {
		
		string username = UsernameEntry.Text;
		string password = PasswordEntry.Text;

		try
		{
			User.Login(username, password);
			DisplayAlert("Login succesful!", "Welcome to Room Booking", "Ok");

            MyBookingsPage myBookingsPage = new MyBookingsPage();
            await Navigation.PushAsync(myBookingsPage);

        }

        catch (ArgumentException ex)
		{
			DisplayAlert("Error", ex.Message, "ok");
		}

    }

	
}


