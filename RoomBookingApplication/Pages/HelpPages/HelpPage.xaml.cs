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
        Question2Solutions question2Solutions = new Question2Solutions();
        Navigation.PushAsync(question2Solutions);
    }

    void Question3_Clicked(System.Object sender, System.EventArgs e)
    {
        Question3Solutions question3Solutions = new Question3Solutions();
        Navigation.PushAsync(question3Solutions);
    }

    void Question1_Clicked(System.Object sender, System.EventArgs e)
    {
        Question1Solutions question1Solutions = new Question1Solutions();
        Navigation.PushAsync(question1Solutions);
    }
}
