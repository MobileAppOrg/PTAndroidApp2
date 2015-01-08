using System;
using Xamarin.Forms;

namespace PTAndroidApp
{
	public class SearchSoapPatientPage : ContentPage   
	{
		public SearchSoapPatientPage()
		{
			var searchBar = new SearchBar {
				Placeholder = "Search Patient"
			};

			//change itemsource on what the data from webapi 
			string[] PatientName = {"Temyung Sakitan", "Apung Puli", "Sicky Wander", "Aspak Buntuk", "Aspak Buntuk", "Aspak Buntuk", "Aspak Buntuk", "Aspak Buntuk"} ;

			ListView lstpatient = new ListView { ItemsSource = PatientName };

			//scroll view for patient list
			var scrlview = new ScrollView {
				Padding = new Thickness (20),
				Content = new StackLayout {
					Children = { lstpatient }
				}
			};

			//content of the page
			Content = new StackLayout {
				Children = {
					searchBar,
					scrlview
				}
			};
		}
	}
}

