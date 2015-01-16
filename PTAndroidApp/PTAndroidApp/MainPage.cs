using System;
using Xamarin.Forms;

namespace PTAndroidApp
{
	public class MainPage : ContentPage 
	{
		public MainPage()
		{

			BackgroundColor = Color.White; 
			Title = "SOAP APPLICATION";
			//set date to display

			DateTime dtToday = DateTime.Now;
			string tt = "";
			tt = dtToday.ToString ("tt");

				if( tt == "AM")
				tt = "Good Morning!";
			else
				tt= "Good Afternoon!";

			//control/views
			var lblHeader = new Label {
				Text = tt + "\n" + dtToday.ToString ("yy-MMM-dd ddd"),
				BackgroundColor = Color.Transparent,
				Font = Font.SystemFontOfSize (20),
				TextColor = Color.Black ,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};

		    var btnPatient = new Button {
				Text = "List Of Patients",
				TextColor = Color.Black ,
				HorizontalOptions = LayoutOptions.Center,
				//VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Color.Silver ,
			};
			 
			var btnSoap = new Button {
				Text = "List Of SOAPs",
				TextColor = Color.Black ,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Silver,
			};

			btnPatient.Clicked += delegate {
				Navigation.PushAsync(new SearchPatientPage());
			};

			btnSoap.Clicked += delegate {
				Navigation.PushAsync(new SearchSoapPatientPage());
			};

			Content = new StackLayout {

				Children = {
					lblHeader,
					btnPatient,
					btnSoap
				},
			};
		}
	}
}

