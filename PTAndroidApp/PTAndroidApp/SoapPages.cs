using System;
using System.Collections.Generic;
using PTAndroidApp.Controls;
using PTAndroidApp.Models;
using Xamarin.Forms;
using PTAndroidApp.ValueConverters;

namespace PTAndroidApp
{
	public class SearchSoapPatientPage : ContentPage   
	{
		protected override void OnAppearing ()
		{
			RefreshList ();
		}

		public static void RefreshList(){
			plist = pmgr.getPatientsList ();
			lstpatient.RowHeight = 40;
			lstpatient.ItemsSource = plist;
			lstpatient.ItemTemplate = new DataTemplate(typeof(PatientCell));
		}

		private static List<PatientListItemModel> plist = new List<PatientListItemModel> ();
		private static ListView lstpatient = new ListView();
		private static PatientManager pmgr  = new PatientManager();

		// Search Patient Page for SOAP
		public SearchSoapPatientPage()
		{
			lstpatient.ItemSelected += async (sender, e) => {
				PatientListItemModel selectedItem = (PatientListItemModel)e.SelectedItem;
				await Navigation.PushAsync(new PatientSoapPage(selectedItem.PatientId));
			};

			Content = lstpatient;	//content of the page
		}
	}

	// View Cell for Patient
	public class PatientCell: ViewCell
	{
		public PatientCell()
		{
			var nameLabel = new Label { HorizontalOptions= LayoutOptions.FillAndExpand };

			nameLabel.SetBinding(Label.TextProperty, "DisplayName");
			nameLabel.HeightRequest = 40;

			var nameLayout = CreateNameLayout();

			var viewLayout = new StackLayout()
			{Orientation = StackOrientation.Horizontal,
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

	// SOAP List Page of a given Patient
	public class PatientSoapPage: ContentPage
	{
		protected override void OnAppearing ()
		{
			RefreshList ();
		}

		private static void RefreshList(){
			sList = smgr.GetSoapList (_patientId);
			lstsoap.RowHeight = 40;
			lstsoap.ItemsSource = sList;
			lstsoap.ItemTemplate = new DataTemplate(typeof(SoapCell));
		}

		private static List<SoapListItemModel> sList = new List<SoapListItemModel> ();
		private static ListView lstsoap = new ListView();
		private static SoapManager smgr  = new SoapManager();
		private static int _patientId;

		public PatientSoapPage(int id)
		{
			_patientId = id;

			ToolbarItem t1 = new ToolbarItem();
			t1.Text = "Add";
			t1.Icon = "ic_action_new.png";
			t1.Clicked += delegate {
				Navigation.PushAsync(new SoapPage(id));
			};

			lstsoap.ItemSelected += async (sender, e) => {
				SoapListItemModel selectedItem = (SoapListItemModel)e.SelectedItem;
				//await DisplayAlert("Tapped!", selectedItem.PatientVisitId + " was tapped.", "OK");
				Navigation.PushAsync(new SoapPage(selectedItem.PatientVisitId,"Edit"));
			};

			ToolbarItems.Add (t1);

			//content of the page
			Content = lstsoap;
		}
	}

	public class SoapCell: ViewCell
	{
		public SoapCell()
		{
			var lblId = new Label { IsVisible = false };

			lblId.SetBinding(Label.TextProperty, "PatientVisitId");

			var lblDate = new Label { HorizontalOptions= LayoutOptions.FillAndExpand };

			lblDate.SetBinding(Label.TextProperty, "Date");
			lblDate.HeightRequest = 40;

			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = { lblId, lblDate }
			};

			View = viewLayout;
		}
	}
}

