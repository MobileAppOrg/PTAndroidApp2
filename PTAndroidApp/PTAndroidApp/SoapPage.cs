using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class SearchSoapPatientPage : ContentPage   
	{
		public SearchSoapPatientPage()
		{
			var searchBar = new SearchBar {
				Placeholder = "Search Patient"
			};

			Patient pmgr = new Patient ();
			List<PatientListItemModel> pList = pmgr.getPatientsList ();

			ListView lstpatient = new ListView { RowHeight = 40 };

			lstpatient.ItemsSource = pList;
			lstpatient.ItemTemplate = new DataTemplate(typeof(PatientCell));

			//content of the page
			Content = new StackLayout {
				Children = {
					searchBar,
					lstpatient
				}
			};
		}
	}

	public class PatientCell: ViewCell
	{
		public PatientCell()
		{
			var nameLabel = new Label
			{
				HorizontalOptions= LayoutOptions.FillAndExpand
			};

			nameLabel.SetBinding(Label.TextProperty, "DisplayName");
			nameLabel.HeightRequest = 40;

			var nameLayout = CreateNameLayout();

			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = { nameLabel, nameLayout }
			};
			View = viewLayout;
		}

		static StackLayout CreateNameLayout()
		{
			var patientId = new Label {
				IsVisible = false,
			};

			patientId.SetBinding(Label.TextProperty, "PatientId");

			var lastVisit = new Label {
				HorizontalOptions= LayoutOptions.FillAndExpand
			};

			lastVisit.SetBinding(Label.TextProperty, "LastVisit");

			var addressLabel = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			addressLabel.SetBinding(Label.TextProperty, "Address");

			var nameLayout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { patientId, addressLabel }
			};
			return nameLayout;
		}

	}


}

