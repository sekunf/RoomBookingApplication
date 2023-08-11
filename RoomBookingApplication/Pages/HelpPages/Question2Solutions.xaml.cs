namespace RoomBookingApplication.Pages.HelpPages;

public partial class Question2Solutions : ContentPage
{
	public Question2Solutions()
	{
		InitializeComponent();
	}

    private async void BackToHelp_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }


}
