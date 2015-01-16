using System;
using Xamarin.Forms;
using System.Collections.Generic;
using PTAndroidApp.Models;
using PTAndroidApp.Controls;

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
			Title = "Add SOAP";
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
			Children.Add (new AdmissiontInfoPage ());
		}
			
	}

	public class PatientGeneralInfoPage:ContentPage
	{
		public PatientGeneralInfoPage(){
			Title = "General Info";
			TableView tblForm = CreateTable ();

			Content = new StackLayout{ 
				Children = { 
					tblForm
				}
			};
		}

		static TableView CreateTable(){
			var PatientVisitId = new EntryCell (){ Label = "Patient Visit Id: ", Keyboard = Keyboard.Numeric };
			var PatientId = new EntryCell (){ Label = "Patient Id: ", Keyboard= Keyboard.Numeric };
			var FirstName = new EntryCell (){ Label = "First Name: "};
			var LastName = new EntryCell (){ Label = "Last Name: "};
			var Age = new EntryCell (){ Label = "Age: ", Keyboard = Keyboard.Numeric };
			var genderPicker = new Picker (){ Items = { "M", "F" }, Title = "Gender" };
			var Gender = new Entry (){ IsVisible = false  };
			var Address = new EntryCell (){ Label = "Address: " };
			var CityTown = new EntryCell (){ Label = "City/Town: "};
			var Province = new EntryCell (){ Label = "Province: "};
			var civilStatusPicker = new Picker (){ Items = { "Single", "Married", "Divorced", "Widowed" }, Title = "Civil Status" };
			var CivilStatus = new Entry (){ IsVisible = false };
			var handedNessPicker = new Picker (){ Items = { "Right","Left" }, Title = "Handedness" };
			var HandedNess = new Entry (){ IsVisible = false };
			var Occupation = new EntryCell (){ Label = "Occupation: "};
			var Religion = new EntryCell (){ Label = "Religion: "};

			ViewCell gendercell = new ViewCell{View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Gender: ",HorizontalOptions = LayoutOptions.Start, HeightRequest = 40 },
						new ContentView { Content = genderPicker, HorizontalOptions = LayoutOptions.FillAndExpand },
						Gender
					},
					Orientation = StackOrientation.Horizontal
				}
			};

			genderPicker.SelectedIndexChanged += delegate(object sender, EventArgs e) {
				if (genderPicker.SelectedIndex == -1)
					Gender.Text = null;
				else
					Gender.Text = genderPicker.Items[genderPicker.SelectedIndex];
			};

			ViewCell civilstatuscell = new ViewCell{View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Civil Status: ",HorizontalOptions = LayoutOptions.Start, HeightRequest = 40 },
						new ContentView { Content = civilStatusPicker, HorizontalOptions = LayoutOptions.FillAndExpand },
						CivilStatus
					},
					Orientation = StackOrientation.Horizontal
				}
			};

			civilStatusPicker.SelectedIndexChanged += delegate(object sender, EventArgs e) {
				if (civilStatusPicker.SelectedIndex == -1)
					CivilStatus.Text = null;
				else
					CivilStatus.Text = civilStatusPicker.Items [civilStatusPicker.SelectedIndex];
			};

			ViewCell handednesscell = new ViewCell{View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Handedness: ",HorizontalOptions = LayoutOptions.Start, HeightRequest = 40 },
						new ContentView { Content = handedNessPicker, HorizontalOptions = LayoutOptions.FillAndExpand },
						HandedNess
					},
					Orientation = StackOrientation.Horizontal
				}
			};

			handedNessPicker.SelectedIndexChanged += delegate(object sender, EventArgs e) {
				if (handedNessPicker.SelectedIndex == -1)
					HandedNess.Text = null;
				else
					HandedNess.Text = handedNessPicker.Items[handedNessPicker.SelectedIndex];
			};

			PatientVisitId.SetBinding(EntryCell.TextProperty,"PatientVisitId");
			PatientId.SetBinding(EntryCell.TextProperty,"PatientId");
			FirstName.SetBinding (EntryCell.TextProperty, "FirstName");
			LastName.SetBinding (EntryCell.TextProperty, "LastName");
			Age.SetBinding (EntryCell.TextProperty, "Age");
			Gender.SetBinding (Entry.TextProperty, "Sex");
			Address.SetBinding (EntryCell.TextProperty, "Address");
			CityTown.SetBinding (EntryCell.TextProperty, "CityTown");
			Province.SetBinding (EntryCell.TextProperty, "Province");
			CivilStatus.SetBinding (Entry.TextProperty, "CivilStatus");
			HandedNess.SetBinding (Entry.TextProperty, "HandedNess");
			Occupation.SetBinding (EntryCell.TextProperty, "Occupation");
			Religion.SetBinding (EntryCell.TextProperty, "Religion");

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection () {
						PatientVisitId,
						PatientId,
						FirstName,
						LastName,
						Age,
						gendercell,
						Address,
						CityTown,
						Province,
						civilstatuscell,
						handednesscell,
						Occupation,
						Religion
					}
				}
			};
		}
	}
	public class AdmissiontInfoPage:ContentPage
	{
		public AdmissiontInfoPage(){
			Title = "Admission Info";
			TableView tblForm = CreateTable ();

			Content = new StackLayout{ 
				Children = { 
					tblForm
				}
			};
		}

		static TableView CreateTable(){
			var patientTypePicker = new Picker (){ Items = { "In-Patient","Out-Patient" }, Title = "Patient Type" };
			var PatientType = new Entry (){ IsVisible = false };
			var DateOfAdmission = new MyDatePicker ();
			var DateOfConsultation = new MyDatePicker ();
			var Surgeon = new EntryCell (){ Label = "Surgeon: "};
			var DateOfSurgery = new MyDatePicker ();
			var GeneralPhysician = new EntryCell (){ Label = "General Physician: "};
			var Orthopedic = new EntryCell (){ Label = "Orthopedic: "};
			var Neurologist = new EntryCell (){ Label = "Neurologist: "};
			var Cardiologist = new EntryCell (){ Label = "Cardiologist: "};
			var Opthalmologoist = new EntryCell (){ Label = "Opthalmologoist: "};
			var Pulmonologist = new EntryCell (){ Label = "Pulmonologist: "};
			var OtherDoctor = new EntryCell (){ Label = "OtherDoctor: "};
			var ReferringDoctor = new EntryCell (){ Label = "Referring Doctor: "};
			var DateOfReferral = new MyDatePicker ();
			var DateOfInitialEvaluation = new MyDatePicker ();
			var Diagnosis = new EntryCell (){ Label = "Diagnosis: "};

			ViewCell patienttypecell = new ViewCell{View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Patient Type: ",HorizontalOptions = LayoutOptions.Start, HeightRequest = 40 },
						new ContentView { Content = patientTypePicker, HorizontalOptions = LayoutOptions.FillAndExpand },
						PatientType
					},
					Orientation = StackOrientation.Horizontal
				}
			};

			patientTypePicker.SelectedIndexChanged += delegate(object sender, EventArgs e) {
				if (patientTypePicker.SelectedIndex == -1)
					PatientType.Text = null;
				else
					PatientType.Text = patientTypePicker.Items[patientTypePicker.SelectedIndex];
			};

			ViewCell DateOfAdmissionCell = new ViewCell{View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Date Of Admission: ",HorizontalOptions = LayoutOptions.Start, HeightRequest = 40 },
						new ContentView { Content = DateOfAdmission, HorizontalOptions = LayoutOptions.FillAndExpand }
					},
					Orientation = StackOrientation.Horizontal
				}
			};

			ViewCell DateOfConsultationCell = new ViewCell{View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Date Of Consultation: ",HorizontalOptions = LayoutOptions.Start, HeightRequest = 40 },
						new ContentView { Content = DateOfConsultation, HorizontalOptions = LayoutOptions.FillAndExpand }
					},
					Orientation = StackOrientation.Horizontal
				}
			};

			ViewCell DateOfSurgeryCell = new ViewCell{View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Date Of Surgery: ",HorizontalOptions = LayoutOptions.Start, HeightRequest = 40 },
						new ContentView { Content = DateOfSurgery, HorizontalOptions = LayoutOptions.FillAndExpand }
					},
					Orientation = StackOrientation.Horizontal
				}
			};

			ViewCell DateOfReferralCell = new ViewCell{View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Date Of Referral: ",HorizontalOptions = LayoutOptions.Start, HeightRequest = 40 },
						new ContentView { Content = DateOfReferral, HorizontalOptions = LayoutOptions.FillAndExpand }
					},
					Orientation = StackOrientation.Horizontal
				}
			};

			ViewCell DateOfInitialEvaluationCell = new ViewCell{View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Date Of IE: ",HorizontalOptions = LayoutOptions.Start, HeightRequest = 40 },
						new ContentView { Content = DateOfInitialEvaluation, HorizontalOptions = LayoutOptions.FillAndExpand }
					},
					Orientation = StackOrientation.Horizontal
				}
			};

			PatientType.SetBinding (Entry.TextProperty, "PatientType");
			DateOfAdmission.SetBinding (MyDatePicker.NullableDateProperty, "DateOfAdmission");
			DateOfConsultation.SetBinding (MyDatePicker.NullableDateProperty, "DateOfConsultation");

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection () {
						patienttypecell,
						DateOfAdmissionCell,
						DateOfConsultationCell,
						Surgeon,
						DateOfSurgeryCell,
						GeneralPhysician,
						Orthopedic,
						Neurologist,
						Cardiologist,
						Opthalmologoist,
						Pulmonologist,
						OtherDoctor,
						ReferringDoctor,
						DateOfReferralCell,
						DateOfInitialEvaluationCell,
						Diagnosis
					}
				}
			};

		}
	}
}

