namespace RoomBookingApplication.Pages.HelpPages;

public partial class Question1Solutions : ContentPage
{
	public Question1Solutions()
	{
		InitializeComponent();
	}

    private async void BackToHelp_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
