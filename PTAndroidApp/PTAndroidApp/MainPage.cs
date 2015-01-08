using System;
using Xamarin.Forms;

namespace PTAndroidApp
{
	public class MainPage : ContentPage 
	{
		public MainPage()
		{
			//set date to display
			DateTime dtToday = DateTime.Today;
			string tt = "";

			if(dtToday .ToString ("tt") == "AM")
				tt = "Good Morning!";
			else
				tt= "Good Afternoon!";

			//control/views
			var lblHeader = new Label {
				Text = tt + "\n" + dtToday.ToString ("yy-MMM-dd ddd"),
				BackgroundColor = Color.Black,
				Font = Font.SystemFontOfSize (20),
				TextColor = Color.Silver ,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

		    var btnPatient = new Button {
				Text = "List Of Patients",
				TextColor = Color.Gray ,
				BackgroundColor = Color.Silver 
			};

			var btnSoap = new Button {
				Text = "List Of SOAPs",
				TextColor = Color.Gray ,
				//Text = TextAlignment .Center 
				BackgroundColor = Color.Silver
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
