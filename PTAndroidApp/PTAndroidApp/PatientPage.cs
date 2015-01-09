using System;
using Xamarin.Forms;

namespace PTAndroidApp
{
	public class SearchPatientPage : ContentPage   
	{

		public SearchPatientPage()
		{		

			var header = new Label {
				Text = "List of Patients",
				Font = Font .SystemFontOfSize (15),
				TextColor = Color .Silver, 
				HorizontalOptions  =  LayoutOptions.CenterAndExpand 
				};

			var SrchbarPatient = new SearchBar {
				Placeholder = "Search Patient"
			};


			//change itemsource on the data from webapi 

		
			//String[] PatientName = p.ToString["",""]();;



			//scroll view for patient list
			//var scrlview = new ScrollView {
			//	Padding = new Thickness (20),
			//	Content = new StackLayout {
				//	Children = { lstpatient }
			//}};

			var btnAddPatient = new Button {
				Text = "Add Patient",
				HorizontalOptions =LayoutOptions.Start , 
			};

			btnAddPatient .Clicked += delegate {


			};
		
				
			//var array = Patient.GetPatient <PatientModel>;
		

				ListView lstpatient = new ListView
			{
				//ItemsSource = array.ToString ()
			};


			//content of the page
			Content = new StackLayout {
				Children = {
					SrchbarPatient,
					header,
					lstpatient,
					btnAddPatient,
					}
			};

			//this.Content = RelativeLayout;
			//Content = new StackLayout {
				//Orientation = StackOrientation.Horizontal,
				////Children = 
				//{}};
		}
	}
}

