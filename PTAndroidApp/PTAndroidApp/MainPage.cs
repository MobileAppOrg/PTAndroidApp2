using System;
using Xamarin.Forms;

namespace PTAndroidApp
{
	public class MainPage : ContentPage 
	{
		public MainPage()
		{
			//set date to display
			RelativeLayout header = CreateHeader();
			var bodybackground = new Image (){ Source = "mainbg.png", Aspect = Aspect.AspectFill };

		    var btnPatient = new Button {
				Opacity = 100,
				BackgroundColor = Color.Silver,
				Text = "List Of Patients",
				TextColor = Color.Black,
				BorderRadius = 0
			};

			var btnSoap = new Button {
				Opacity = 100,
				BackgroundColor = Color.Silver,
				Text = "List Of SOAPs",
				TextColor = Color.Black,
				BorderRadius = 0
			};

			btnPatient.Clicked += delegate {
				DateTime dtToday = DateTime.Today;
				string tt = "";

				if(dtToday .ToString ("tt") == "AM")
					tt = "Good Morning!";
				else
					tt= "Good Afternoon!";


				//Navigation.PushAsync(new SearchPatientPage());
			};

			btnSoap.Clicked += delegate {
				Navigation.PushAsync(new SearchSoapPatientPage());

			};


				
			var body = new RelativeLayout () {
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var buttons = new StackLayout () {
				Children = {btnPatient,btnSoap}
			};

			body.Children.Add(bodybackground, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => { return parent.Width; }),
				Constraint.RelativeToParent ((parent) => { return parent.Height; }));

			body.Children.Add (buttons, 
				Constraint.Constant (0), 
				Constraint.Constant (5),
				Constraint.RelativeToParent ((parent) => { return parent.Width; }),
				Constraint.RelativeToParent ((parent) => { return parent.Height; }));

			Content = new StackLayout {
				Spacing = 0,
				//BackgroundColor = Color.Silver,
				Orientation = StackOrientation.Vertical,
				Children = {
					header,
					body
				}
			};
		}

		public static RelativeLayout CreateHeader()
		{


			DateTime dtToday = DateTime.Today;
			string tt = "";

			if(dtToday .ToString ("tt") == "AM")
				tt = "Good Morning!";
			else
				tt= "Good Afternoon!";

			//control/views
			var lblHeader = new Label {
				Text = tt + "\n" + dtToday.ToString ("yy-MMM-dd ddd"),
				FontAttributes = FontAttributes.Bold,
				FontSize = 30,
				FontFamily = "",	
				TextColor = Color.Navy,

				HorizontalOptions = LayoutOptions.CenterAndExpand,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			var headerImage = new Image (){
				Aspect = Aspect.AspectFill,
				Source = "sanfernando.jpg"
			};

			var header = new RelativeLayout (){
				Padding = 0,
				HeightRequest = 200,
				VerticalOptions = LayoutOptions.Start
			};

			header.Children.Add(headerImage, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => { return parent.Width; }),
				Constraint.RelativeToParent ((parent) => { return parent.Height; }));

			header.Children.Add (lblHeader, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => { return parent.Width; }),
				Constraint.RelativeToParent ((parent) => { return parent.Height; }));

			return header;
		}
	}
}
