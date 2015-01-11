using System;
using Xamarin.Forms;
using System.Collections.Generic;
using PTAndroidApp.Models;

namespace PTAndroidApp
{
	public class SearchSoapPatientPage : ContentPage   
	{
		// Search Patient Page for SOAP
		public SearchSoapPatientPage()
		{

			PatientManager pmgr = new PatientManager ();
			List<PatientListItemModel> pList = pmgr.getPatientsList ();
			ListView lstpatient = new ListView { RowHeight = 40 };

			lstpatient.ItemsSource = pList;
			lstpatient.ItemTemplate = new DataTemplate(typeof(PatientCell));

			lstpatient.ItemSelected += async (sender, e) => {
				PatientListItemModel selectedItem = (PatientListItemModel)e.SelectedItem;
				await Navigation.PushAsync(new PatientSoapPage(selectedItem.PatientId));
				//await DisplayAlert("Tapped!", selectedItem.PatientId + " was tapped.", "OK");
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

	// SOAP List Page of a given Patient
	public class PatientSoapPage: ContentPage
	{
		public PatientSoapPage(int id)
		{
			ToolbarItem t1 = new ToolbarItem();
			t1.Text = "Add";
			t1.Icon = "ic_action_new.png";
			t1.Clicked += delegate {
				Navigation.PushAsync(new SoapPage(id));
			};


			SoapManager smgr = new SoapManager ();
			List<SoapListItemModel> sList = smgr.GetSoapList (id);

			ListView lstsoap = new ListView { RowHeight = 40 };

			lstsoap.ItemsSource = sList;
			lstsoap.ItemTemplate = new DataTemplate(typeof(SoapCell));

			lstsoap.ItemSelected += async (sender, e) => {
				SoapListItemModel selectedItem = (SoapListItemModel)e.SelectedItem;
				await DisplayAlert("Tapped!", selectedItem.PatientVisitId + " was tapped.", "OK");
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

	public class SoapPage:ContentPage
	{
		public SoapPage(int patientId){
			PatientManager patientMgr = new PatientManager ();
			SoapManager soapMgr = new SoapManager ();
			PatientVisit soap = new PatientVisit ();
			Patient patient = new Patient ();

			BindingContext = soap;

			var txtPatientVisitId = new Editor ();
			var txtPatientId = new Editor(){};
			var lblFirstName = new Label() { Text = "FirstName" };
			var txtFirstName = new Editor();
			var lblAge = new Label { Text = "Age" };
			var txtAge = new Editor();
			var btnSave = new Button ();

			//txtPatientVisitId.SetBinding(txtPatientVisitId.Text,"");
			txtPatientId.SetBinding(Editor.TextProperty,"PatientId");
			txtFirstName.SetBinding (Editor.TextProperty, "FirstName");
			txtAge.SetBinding (Editor.TextProperty, "Age");
			btnSave.Text = "Save";

			patient = patientMgr.GetPatient (patientId);
			soap.FirstName = patient.FirstName;
			soap.LastName = patient.LastName;
			soap.Age =  DateTime.Now.Year - patient.DateOfBirth.Year;

			btnSave.Clicked += delegate {
				soapMgr.Add(soap);
			};


			Content = new StackLayout{ 
				Children = { 
					txtPatientVisitId, 
					txtPatientId, 
					lblFirstName,txtFirstName,
					lblAge, txtAge,
					btnSave
				}
			};
		}
	}
}

