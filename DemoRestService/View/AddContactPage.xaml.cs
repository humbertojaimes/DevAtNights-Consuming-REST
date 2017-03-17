using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DemoRestService
{
	public partial class AddContactPage : ContentPage
	{
		public AddContactPage()
		{
			InitializeComponent();
			this.BindingContext = new AddContactVM();
		}
	}
}
