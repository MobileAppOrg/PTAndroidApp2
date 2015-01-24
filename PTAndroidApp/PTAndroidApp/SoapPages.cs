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
			//DisplayAlert ("Carousel Page Main", "OnAppearing", "OK");
		}

		public SoapPage(int patientId){
			Title = "Add SOAP";
			//DisplayAlert ("Carousel Page Main", "Constructor", "OK");
			PatientManager patientMgr = new PatientManager ();
			SoapManager soapMgr = new SoapManager ();
			PatientVisit soap = new PatientVisit ();
			Patient patient = new Patient ();

			patient = patientMgr.GetPatient (patientId);
			soap.PatientId = patient.PatientId;
			soap.FirstName = patient.FirstName;
			soap.LastName = patient.LastName;
			soap.Age =  DateTime.Now.Year - patient.DateOfBirth.Year;
			soap.Address = patient.Address;
			soap.CityTown = patient.CityTown;
			soap.Province = patient.Province;
			soap.CivilStatus = patient.CivilStatus;
			soap.HandedNess = patient.HandedNess;
			soap.Sex = patient.Gender;
			soap.Occupation = patient.Occupation;
			soap.Religion = patient.Religion;

			BindingContext = soap;

			Children.Add (new PatientGeneralInfoPage ());
			Children.Add (new AdmissiontInfoPage ());
			Children.Add (new DrugHxPage ());

			ToolbarItems.Add (new ToolbarItem(){
				Icon = "",
				Text = "Save",
				Command = new Command(()=>new SoapManager().Add(soap))
			});
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
			var PatientVisitId = new EntryCell (){ Label = "Patient Visit Id: ", Keyboard = Keyboard.Telephone };
			var PatientId = new EntryCell (){ Label = "Patient Id: ", Keyboard= Keyboard.Numeric };
			var FirstName = new EntryCell (){ Label = "First Name: "};
			var LastName = new EntryCell (){ Label = "Last Name: "};
			var Age = new EntryCell (){ Label = "Age: ", Keyboard = Keyboard.Numeric };
			var GenderPicker = new Picker (){ Items = { "M", "F" }, Title = "Gender", HorizontalOptions = LayoutOptions.FillAndExpand };
			var Address = new EntryCell (){ Label = "Address: " };
			var CityTown = new EntryCell (){ Label = "City/Town: "};
			var Province = new EntryCell (){ Label = "Province: "};
			var CivilStatusPicker = new Picker (){ Items = { "Single", "Married", "Divorced", "Widowed" }, Title = "Civil Status", HorizontalOptions = LayoutOptions.FillAndExpand };
			var CivilStatus = new Entry (){ IsVisible = false };
			var handedNessPicker = new Picker (){ Items = { "Right","Left" }, Title = "Handedness", HorizontalOptions = LayoutOptions.FillAndExpand };
			var HandedNess = new Entry (){ IsVisible = false };
			var Occupation = new EntryCell (){ Label = "Occupation: "};
			var Religion = new EntryCell (){ Label = "Religion: "};

			ViewCell gendercell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 22, Text = "Gender: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
						GenderPicker
					},
					Padding = new Thickness(5,1,1,1),
					HorizontalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Horizontal
				}
			};

			ViewCell civilstatuscell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Civil Status: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
						CivilStatusPicker
					},
					Padding = new Thickness(5,1,1,1),
					HorizontalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Horizontal
				}
			};

//			civilStatusPicker.SelectedIndexChanged += delegate(object sender, EventArgs e) {
//				if (civilStatusPicker.SelectedIndex == -1)
//					CivilStatus.Text = null;
//				else
//					CivilStatus.Text = civilStatusPicker.Items [civilStatusPicker.SelectedIndex];
//			};

			ViewCell handednesscell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Handedness: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
						handedNessPicker,
						HandedNess
					},
					Padding = new Thickness(5,1,1,1),
					HorizontalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Horizontal
				}
			};

			handedNessPicker.SelectedIndexChanged += delegate(object sender, EventArgs e) {
				if (handedNessPicker.SelectedIndex == -1)
					HandedNess.Text = null;
				else
					HandedNess.Text = handedNessPicker.Items[handedNessPicker.SelectedIndex];
			};

			PatientVisitId.SetBinding(EntryCell.TextProperty,"PatientVisitId", BindingMode.TwoWay);
			PatientId.SetBinding(EntryCell.TextProperty,"PatientId", BindingMode.TwoWay);
			FirstName.SetBinding (EntryCell.TextProperty, "FirstName", BindingMode.TwoWay);
			LastName.SetBinding (EntryCell.TextProperty, "LastName", BindingMode.TwoWay);
			Age.SetBinding (EntryCell.TextProperty, "Age", BindingMode.TwoWay);
			GenderPicker.SetBinding (Picker.SelectedIndexProperty, "Sex", BindingMode.TwoWay,new IndexToGenderConverter());
			Address.SetBinding (EntryCell.TextProperty, "Address", BindingMode.TwoWay);
			CityTown.SetBinding (EntryCell.TextProperty, "CityTown", BindingMode.TwoWay);
			Province.SetBinding (EntryCell.TextProperty, "Province", BindingMode.TwoWay);
			CivilStatusPicker.SetBinding(Picker.SelectedIndexProperty, "CivilStatus", BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = new List<string>(){ "Single", "Married", "Divorced", "Widowed" }});
			HandedNess.SetBinding (Entry.TextProperty, "HandedNess", BindingMode.TwoWay);
			Occupation.SetBinding (EntryCell.TextProperty, "Occupation", BindingMode.TwoWay);
			Religion.SetBinding (EntryCell.TextProperty, "Religion", BindingMode.TwoWay);

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
			var patientTypePicker = new Picker (){ Items = { "In-Patient","Out-Patient" }, Title = "Patient Type", HorizontalOptions = LayoutOptions.FillAndExpand };
			var PatientType = new Entry (){ IsVisible = false };
			//var DateOfAdmission = new  DatePickerButton(){ HorizontalOptions = LayoutOptions.FillAndExpand };
			var DateOfAdmission = new EntryCell (){ Label = "Admission Date: " };
			//var DateOfConsultation = new DatePickerButton (){ HorizontalOptions = LayoutOptions.FillAndExpand };
			var DateOfConsultation = new EntryCell (){ Label = "Consultation Date: " };
			var Surgeon = new EntryCell (){ Label = "Surgeon: " };
			//var DateOfSurgery = new DatePickerButton (){ HorizontalOptions = LayoutOptions.FillAndExpand };
			var DateOfSurgery = new EntryCell (){ Label = "Surgery Date: " };
			var GeneralPhysician = new EntryCell (){ Label = "General Physician: "};
			var Orthopedic = new EntryCell (){ Label = "Orthopedic: "};
			var Neurologist = new EntryCell (){ Label = "Neurologist: "};
			var Cardiologist = new EntryCell (){ Label = "Cardiologist: "};
			var Opthalmologoist = new EntryCell (){ Label = "Opthalmologoist: "};
			var Pulmonologist = new EntryCell (){ Label = "Pulmonologist: "};
			var OtherDoctor = new EntryCell (){ Label = "Other Doctor: "};
			var ReferringDoctor = new EntryCell (){ Label = "Referring Doctor: " };
			//var DateOfReferral = new DatePickerButton () { HorizontalOptions = LayoutOptions.FillAndExpand };
			var DateOfReferral = new EntryCell () { Label = "Date Of Referral: " };
			//var DateOfInitialEvaluation = new DatePickerButton (){ HorizontalOptions = LayoutOptions.FillAndExpand };
			var DateOfInitialEvaluation = new EntryCell (){ Label = "Date Of IE: " };
			var Diagnosis = new EntryCell (){ Label = "Diagnosis: "};

			ViewCell patienttypecell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Patient Type: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
						patientTypePicker,
						PatientType
					},
					Padding = new Thickness(5,1,1,1),
					HorizontalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Horizontal
				}
			};

			patientTypePicker.SelectedIndexChanged += delegate(object sender, EventArgs e) {
				if (patientTypePicker.SelectedIndex == -1)
					PatientType.Text = null;
				else
					PatientType.Text = patientTypePicker.Items[patientTypePicker.SelectedIndex];
			};

			#region Commented Date Cells
//			ViewCell DateOfAdmissionCell = new ViewCell{
//				Height = 100,
//				View = new StackLayout(){
//					Children = {
//						new Label (){ FontSize = 20, Text = "Date Of Admission: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
//						DateOfAdmission,
//						//DateOfAdmissionPicker
//					},
//					Padding = new Thickness(5,1,1,1),
//					HorizontalOptions = LayoutOptions.Fill,
//					Orientation = StackOrientation.Horizontal
//				}
//			};

//			ViewCell DateOfConsultationCell = new ViewCell{
//				Height = 100,
//				View = new StackLayout(){
//					Children = {
//						new Label (){ FontSize = 20, Text = "Date Of Consultation: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
//						DateOfConsultation
//					},
//					Padding = new Thickness(5,1,1,1),
//					HorizontalOptions = LayoutOptions.Fill,
//					Orientation = StackOrientation.Horizontal
//				}
//			};

//			ViewCell DateOfSurgeryCell = new ViewCell{
//				Height = 100,
//				View = new StackLayout(){
//					Children = {
//						new Label (){ FontSize = 20, Text = "Date Of Surgery: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
//						DateOfSurgery
//					},
//					Padding = new Thickness(5,1,1,1),
//					HorizontalOptions = LayoutOptions.Fill,
//					Orientation = StackOrientation.Horizontal
//				}
//			};

//			ViewCell DateOfReferralCell = new ViewCell{
//				Height = 100,
//				View = new StackLayout(){
//					Children = {
//						new Label (){ FontSize = 20, Text = "Date Of Referral: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
//						DateOfReferral
//					},
//					Padding = new Thickness(5,1,1,1),
//					HorizontalOptions = LayoutOptions.Fill,
//					Orientation = StackOrientation.Horizontal
//				}
//			};

//			ViewCell DateOfInitialEvaluationCell = new ViewCell{
//				Height = 100,
//				View = new StackLayout(){
//					Children = {
//						new Label (){ FontSize = 20, Text = "Date Of IE: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
//						DateOfInitialEvaluation
//					},
//					Padding = new Thickness(5,1,1,1),
//					HorizontalOptions = LayoutOptions.Fill,
//					Orientation = StackOrientation.Horizontal
//				}
//			};

//			DateOfAdmissionPicker.DateSelected += async (object sender, DateChangedEventArgs e) => {
//				Console.WriteLine(sender);
//				Console.WriteLine(e);
//			};
			#endregion

			PatientType.SetBinding (Entry.TextProperty, "PatientType", BindingMode.TwoWay);
			DateOfAdmission.SetBinding (EntryCell.TextProperty, "DateOfAdmission", BindingMode.TwoWay,new StringToNullDateTimeConverter());
			DateOfConsultation.SetBinding (EntryCell.TextProperty, "DateOfConsultation", BindingMode.TwoWay,new StringToNullDateTimeConverter());
			Surgeon.SetBinding (EntryCell.TextProperty, "Surgeon", BindingMode.TwoWay);
			DateOfSurgery.SetBinding (EntryCell.TextProperty, "DateOfSurgery", BindingMode.TwoWay,new StringToNullDateTimeConverter());
			GeneralPhysician.SetBinding (EntryCell.TextProperty, "GeneralPhysician", BindingMode.TwoWay);
			Orthopedic.SetBinding (EntryCell.TextProperty, "Orthopedic", BindingMode.TwoWay);
			Neurologist.SetBinding (EntryCell.TextProperty, "Neurologist", BindingMode.TwoWay);
			Cardiologist.SetBinding (EntryCell.TextProperty, "Cardiologist", BindingMode.TwoWay);
			Opthalmologoist.SetBinding (EntryCell.TextProperty, "Opthalmologoist", BindingMode.TwoWay);
			Pulmonologist.SetBinding (EntryCell.TextProperty, "Pulmonologist", BindingMode.TwoWay);
			OtherDoctor.SetBinding (EntryCell.TextProperty, "OtherDoctor", BindingMode.TwoWay);
			ReferringDoctor.SetBinding (EntryCell.TextProperty, "ReferringDoctor", BindingMode.TwoWay);
			DateOfReferral.SetBinding (EntryCell.TextProperty, "DateOfReferral", BindingMode.TwoWay,new StringToNullDateTimeConverter());
			DateOfInitialEvaluation.SetBinding (EntryCell.TextProperty, "DateOfInitialEvaluation", BindingMode.TwoWay,new StringToNullDateTimeConverter());
			Diagnosis.SetBinding (EntryCell.TextProperty, "Diagnosis", BindingMode.TwoWay);

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection () {
						patienttypecell,
						DateOfAdmission,
						DateOfConsultation,
						Surgeon,
						DateOfSurgery,
						GeneralPhysician,
						Orthopedic,
						Neurologist,
						Cardiologist,
						Opthalmologoist,
						Pulmonologist,
						OtherDoctor,
						ReferringDoctor,
						DateOfReferral,
						DateOfInitialEvaluation,
						Diagnosis
					}
				}
			};

		}
	}




	public class pmhxpage:ContentPage 
	{
		public pmhxpage ()
		{
			var trauma = traumas ();
			var athritis = Arthritis ();
			var dm = DM ();
			var allergies = Allergies ();
			var surgery = Surgery ();
			var surgery2 = Surgery2 ();
			var hospitalization = Hospitalization ();
			var hospitalization2 = Hospitalization2 ();
			var cardiovascularDisease = CardiovascularDisease ();
			var pulmonaryCondition = PulmonaryCondition ();
			var neurologyCondition = NeurologyCondition ();
			var cancer = Cancer ();
			var others = Others ();

			var pmhxcontrols = new ScrollView {
				Content = new StackLayout {
					Children = { trauma, athritis, dm, allergies, surgery, surgery2,
						hospitalization, hospitalization2, cardiovascularDisease,
						pulmonaryCondition, neurologyCondition, cancer, others}
				}
			};
			Content = new StackLayout {
				Children = { pmhxcontrols }
			};
		}

		static StackLayout traumas ()
		{
			var lbltrauma = new Label {
				Text = "Trauma", FontSize = 17,
				VerticalOptions = LayoutOptions .EndAndExpand };
				
			var switchTrauma = new Switch {
				VerticalOptions = LayoutOptions .EndAndExpand,
				};

			var txttrauma = new Entry {
				Placeholder = "Trauma",
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			var traumaRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = {  lbltrauma, switchTrauma, txttrauma }
			};
			return traumaRow;
		}


		static StackLayout Arthritis  ()
		{
			var lblAthritis = new Label {
				Text = "Arthritis"
			};
			var switchAthritis = new Switch {
			};

			var ArthritisRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal  ,
				Children = { lblAthritis, switchAthritis  }
			};
					
			return ArthritisRow;
		}
			
		static StackLayout DM()
		{
			var pckDM = new Picker () { Items = { "IDDM", "NIDDM", }, 
				Title = "Select DM", 
				HorizontalOptions = LayoutOptions.StartAndExpand
			};
					
			var DMrow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = {pckDM}
			};
			return DMrow;
		}
			
		static StackLayout Allergies ()
		{
			var lblallergies = new Label {
				Text = "Allergies"};
			var switchAllergies = new Switch {
			};
			var AllergiesRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { lblallergies, switchAllergies }
			};
					
			return AllergiesRow;
		}

		static StackLayout Surgery ()
		{
			var lblSurgery = new Label {
				Text = "Surgery"};

			var dtSurgery = new DatePicker {
				Format = "D",

			};
			var SurgerysRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { lblSurgery,dtSurgery,}
			};
			return SurgerysRow;
		}

		static StackLayout Surgery2 ()
		{
			var txtSurgery = new Entry {
				Placeholder = "Surgical Procedure",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			var SurgerysRow= new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = {txtSurgery}
			};
			return SurgerysRow;
		}

		static StackLayout Hospitalization ()
		{
			var lblHospitalization = new Label {
				Text = "Hospitalization"};

			var dtHospitalization = new DatePicker {
				Format = "D",
			};
			var HospitalizationRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { lblHospitalization,dtHospitalization,}
			};
			return HospitalizationRow;
		}

		static StackLayout Hospitalization2 ()
		{
			var txtHospitalization = new Entry {
				Placeholder = "Specification of disease",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			var Hospitalization2Row= new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { txtHospitalization}
			};
			return Hospitalization2Row;
		}
			
		static StackLayout CardiovascularDisease ()
		{
			var lblCardiovascularDisease = new Label {
				Text = "Cardiovascular Disease"};

			var txtCardiovascularDisease = new Entry  {
				Placeholder = "Cardiovascular Disease"
			};

			var CardiovascularDiseaseRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { lblCardiovascularDisease,txtCardiovascularDisease}
			};
			return CardiovascularDiseaseRow;
		}

		static StackLayout PulmonaryCondition ()
		{
			var lblPulmonaryCondition = new Label {
				Text = "Pulmonary Condition"};

			var txtPulmonaryCondition = new Entry  {
				Placeholder = "Pulmonary Condition"
			};

			var PulmonaryConditionRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { lblPulmonaryCondition,txtPulmonaryCondition}
			};
			return PulmonaryConditionRow;
		}

		static StackLayout NeurologyCondition ()
		{
			var lblNeurologyCondition = new Label {
				Text = "Neurology Condition"};

			var txtNeurologyCondition = new Entry  {
				Placeholder = "Neurology Condition"
			};

			var NeurologyConditionRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { lblNeurologyCondition,txtNeurologyCondition}
			};
			return NeurologyConditionRow;
		}

		static StackLayout Cancer  ()
		{
			var lblCancer = new Label {
				Text = "Cancer"
			};
			var switchCancer = new Switch {
			};
				
			var CancerRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal  ,
				Children = { lblCancer, switchCancer  }
			};
			return CancerRow;
		}

		static StackLayout Others  ()
		{
			var lblOthers = new Label {
				Text = "Others"
			};
			var txtOthers = new Entry  {
				Placeholder = "Specify others",
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			var OthersRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal  ,
				Children = { lblOthers, txtOthers  }
			};

			return OthersRow;
		}

	}

	public class AncillaryPage:ContentPage 
	{
		Grid gr = new Grid ();
	
		public AncillaryPage ()
		{
			var lblAncillaryProc = new Label {
				Text = "Ancillary Procedure", FontSize = 17,
				VerticalOptions = LayoutOptions .EndAndExpand,
				HorizontalOptions = LayoutOptions .Center };

			var pckAncillary = new Picker () { Items = { "XRAY", "MRI", "Blood Test","NCV","EMG","CT SCAN"}, 
				Title = "List of Procedure", 
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			var txtAncillary = new Entry {
				Placeholder = "Other Procedures",
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			var dtAncillary = new DatePicker {
				Format = "D",

			};
			var btnAdd = new Button {
				Text = "Add Ancillary",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			var AncillaryControls = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical ,
				Children = {  lblAncillaryProc, pckAncillary, txtAncillary,
					dtAncillary, btnAdd }
			};
					

			btnAdd.Clicked += delegate {
				int i = gr.Children.Count;
				gr.Children.Add(new Label{Text = pckAncillary.Items [pckAncillary .SelectedIndex ], FontSize= 15, VerticalOptions = LayoutOptions.Start , HorizontalOptions = LayoutOptions .CenterAndExpand },0,i);
				gr.Children.Add(new Label{Text = dtAncillary .Date .ToString (), FontSize = 15, VerticalOptions = LayoutOptions.Start , HorizontalOptions = LayoutOptions .CenterAndExpand },1,i);
				gr.Children.Add(new Label{Text = txtAncillary.Text,FontSize = 15, VerticalOptions = LayoutOptions.Start , HorizontalOptions = LayoutOptions.CenterAndExpand  },2,i);
			}; 


			var AncillaryList = new ScrollView {
				Content = new StackLayout {
					Children = {gr}
				}

			};

			Content = new StackLayout {
				Children = { AncillaryControls, AncillaryList }
			};
		}


	}
}

