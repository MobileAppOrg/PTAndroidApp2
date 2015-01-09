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
				Font = Font .SystemFontOfSize (20),
				TextColor = Color .Silver, 
				HorizontalOptions  =  LayoutOptions.CenterAndExpand 
				
			};

			var SrchbarPatient = new SearchBar {
				Placeholder = "Search Patient"
			};


			//change itemsource on the data from webapi 
			string[] PatientName = {"1", "2", "4", "5", "3", "6", "7", "8"} ;

			ListView lstpatient = new ListView
			{
				ItemsSource = PatientName,
			};

			//scroll view for patient list
			var scrlview = new ScrollView {
				Padding = new Thickness (20),
				IsClippedToBounds = true,
				Content = new StackLayout {
					Children = { lstpatient }
				},
			};
			var btnAddPatient = new Button {
				Text = "Add Patient",
				HorizontalOptions =LayoutOptions .Start, 

			};
			var btnDelPatient = new Button {
				Text = "Delete Patient",
				HorizontalOptions  =LayoutOptions .End  
			};

			//content of the page
			Content = new StackLayout {
				Children = {
					SrchbarPatient,
					header,
					scrlview,
					btnAddPatient,
					btnDelPatient
				}
			};

			//this.Content = RelativeLayout;
			//Content = new StackLayout {
				//Orientation = StackOrientation.Horizontal,
				////Children = 
				//{
					
				//}
			//};
		}
	}
}

