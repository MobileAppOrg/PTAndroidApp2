using System;

using Xamarin.Forms;

namespace PTAndroidApp
{
	public class GaitAssmentPage : ContentPage
	{
		public GaitAssmentPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


