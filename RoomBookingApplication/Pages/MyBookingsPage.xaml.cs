namespace RoomBookingApplication.Pages;

public partial class MyBookingsPage : ContentPage
{
	public MyBookingsPage()
	{
		InitializeComponent();
	}

    void HelpPageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        HelpPage helpPage = new HelpPage();
        Navigation.PushAsync(helpPage);
    }
}
