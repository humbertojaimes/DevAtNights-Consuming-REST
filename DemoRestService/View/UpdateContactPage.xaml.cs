using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DemoRestService
{
	public partial class UpdateContactPage : ContentPage
	{
		public UpdateContactPage(Contact contact)
		{
			InitializeComponent();
			this.BindingContext = new UpdateContactVM(contact);
		}
	}
}
