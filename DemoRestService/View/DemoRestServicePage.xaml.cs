using Xamarin.Forms;

namespace DemoRestService
{
	public partial class DemoRestServicePage : ContentPage
	{
		public DemoRestServicePage()
		{
			InitializeComponent();
			this.BindingContext = new MainPageViewModel();
		}

		void AddContact_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new AddContactPage());
		}

		void Contact_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			Navigation.PushAsync(new UpdateContactPage((Contact)e.Item));
		}
	}
}
