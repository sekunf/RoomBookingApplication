using RoomBookingApplication.Pages.HelpPages;

namespace RoomBookingApplication.Pages;

public partial class HelpPage : ContentPage
{
	public HelpPage()
	{
		InitializeComponent();
	}

   

    void Question2_Clicked(System.Object sender, System.EventArgs e)
    {

    }

    void Question3_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void Question1_Clicked(System.Object sender, System.EventArgs e)
    {
        Question1Solutions question1Solutions = new Question1Solutions();
        Navigation.PushAsync(question1Solutions);
    }
}
