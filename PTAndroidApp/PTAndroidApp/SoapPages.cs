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

	public class SoapPage:CarouselPage
	{

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			DisplayAlert ("Carousel Page Main", "OnAppearing", "OK");
		}

		public SoapPage(int patientId){
			DisplayAlert ("Carousel Page Main", "Constructor", "OK");
			PatientManager patientMgr = new PatientManager ();
			SoapManager soapMgr = new SoapManager ();
			PatientVisit soap = new PatientVisit ();
			Patient patient = new Patient ();


			patient = patientMgr.GetPatient (patientId);
			soap.FirstName = patient.FirstName;
			soap.LastName = patient.LastName;
			soap.Age =  DateTime.Now.Year - patient.DateOfBirth.Year;
			soap.Address = patient.Address;
			soap.CityTown = patient.CityTown;
			soap.Province = patient.Province;
			soap.CityTown = patient.CivilStatus;
			soap.HandedNess = patient.HandedNess;
			soap.Sex = patient.Gender;
			soap.Occupation = patient.Occupation;
			soap.Religion = patient.Religion;

			BindingContext = soap;

			Children.Add (new PatientGeneralInfoPage ());
		}
			
	}

	public class PatientGeneralInfoPage:ContentPage
	{
		public PatientGeneralInfoPage(){


			TableView tblForm = CreateTable ();	
			var btnSave = new Button (){Text = "Save"};



//			btnSave.Clicked += delegate {
//				soapMgr.Add(soap);
//			};


			Content = new StackLayout{ 
				Children = { 
					tblForm,
					btnSave
				}
			};
		}

		static TableView CreateTable(){
			var txtPatientVisitId = new EntryCell (){ Label = "Patient Visit Id: ", Keyboard = Keyboard.Numeric };
			var txtPatientId = new EntryCell (){ Label = "Patient Id: ", Keyboard= Keyboard.Numeric };
			var txtFirstName = new EntryCell (){ Label = "First Name: "};
			var txtLastName = new EntryCell (){ Label = "Last Name: "};
			var txtAge = new EntryCell (){ Label = "Age: ", Keyboard = Keyboard.Numeric };
			var lblGender = new Label (){ FontSize = 24, Text = "Gender: ",HorizontalOptions = LayoutOptions.Start, HeightRequest = 40,WidthRequest = 100};
			var genderPicker = new Picker (){ Items = { "M", "F" }, Title = "Gender" };
			var txtGender = new Entry (){ IsVisible = false  };
			var txtAddress = new EntryCell(){ Label = "Address: " };
			ViewCell gendercell = new ViewCell{View = new StackLayout(){
					Children = {
						lblGender,
						new ContentView { Content = genderPicker, HorizontalOptions = LayoutOptions.FillAndExpand },
						txtGender
					},
					Orientation = StackOrientation.Horizontal
				}
			};

			txtPatientVisitId.SetBinding(EntryCell.TextProperty,"PatientVisitId");
			txtPatientId.SetBinding(EntryCell.TextProperty,"PatientId");
			txtFirstName.SetBinding (EntryCell.TextProperty, "FirstName");
			txtLastName.SetBinding (EntryCell.TextProperty, "LastName");
			txtAge.SetBinding (EntryCell.TextProperty, "Age");
			txtGender.SetBinding (Picker.SelectedIndexProperty, "Sex");
			txtAddress.SetBinding (EntryCell.TextProperty, "Address");
			genderPicker.SelectedIndexChanged += delegate(object sender, EventArgs e) {
				if (genderPicker.SelectedIndex == -1)
				{
					txtGender.Text = "";
				}
				else
				{
					txtGender.Text = genderPicker.Items[genderPicker.SelectedIndex];
				}
			};

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection () {
						txtPatientVisitId,
						txtPatientId,
						txtFirstName,
						txtLastName,
						txtAge,
						gendercell,
						txtAddress,
					}
				}
			};
		}
	}
}

