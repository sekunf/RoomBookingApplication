namespace RoomBookingApplication.Pages.HelpPages;

public partial class Question3Solutions : ContentPage
{
	public Question3Solutions()
	{
		InitializeComponent();
	}

    private async void BackToHelp_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
