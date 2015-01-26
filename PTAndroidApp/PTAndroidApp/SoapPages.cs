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
			lstpatient.RowHeight = 70;
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
			var nameLabel = new Label { FontSize = 20, HorizontalOptions= LayoutOptions.FillAndExpand };
			nameLabel.SetBinding(Label.TextProperty, "DisplayName");

			var patientId = new Label { FontSize = 12, HorizontalOptions= LayoutOptions.Start };
			patientId.SetBinding(Label.TextProperty, new Binding(path:"PatientId",stringFormat:"ID: {0}"));

			var addressLabel = new Label { FontSize = 12, HorizontalOptions = LayoutOptions.FillAndExpand };
			addressLabel.SetBinding(Label.TextProperty, new Binding(path:"Address",stringFormat:"Address: {0}"));

			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children = { nameLabel, 
					new StackLayout {
						Orientation = StackOrientation.Horizontal,
						Children = {patientId , addressLabel }
					} 
				}
			};
			View = viewLayout;
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
			lstsoap.RowHeight = 60;
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
				await Navigation.PushAsync(new SoapPage(selectedItem.PatientVisitId,"Edit"));
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
			var lblId = new Label { FontSize = 20, HorizontalOptions = LayoutOptions.FillAndExpand };
			lblId.SetBinding(Label.TextProperty, new Binding(path:"PatientVisitId",stringFormat:"SOAP ID: {0}"));

			var lblDate = new Label { FontSize = 12, HorizontalOptions= LayoutOptions.FillAndExpand };
			lblDate.SetBinding(Label.TextProperty, new Binding(path: "Date",stringFormat:"Date of Admission: {0:D}"));

			var viewLayout = new StackLayout()
			{
				Children = { lblId, lblDate }
			};

			View = viewLayout;
		}
	}
}

