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
			var lblspace = new Label {
				HeightRequest = 26
			};

			var lblspace2 = new Label {
				HeightRequest = 20
			};

			var lblHeader = new Label {
				Text = tt + "\n" + dtToday.ToString ("yy-MMM-dd ddd"),
				Font = Font.SystemFontOfSize (20),
				TextColor = Color.Blue ,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

		    var btnPatient = new Button {
				Text = "List Of Patients",
				TextColor = Color.Black ,
				BackgroundColor = Color.Silver 
			};

			var btnSoap = new Button {
				Text = "List Of SOAPs",
				TextColor = Color.Black ,
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
					lblspace,
					lblHeader,
					lblspace2,
					btnPatient,
					btnSoap
				},
			};
		}
	}
}
