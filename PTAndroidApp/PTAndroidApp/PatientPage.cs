using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Android;
using System.Threading.Tasks;
using PTAndroidApp.Models;


namespace PTAndroidApp
{


	public class SearchPatientPage : ContentPage   
	{
		

		public SearchPatientPage()
		{		
			int IDs = 0;
			var label = new Label ();
			label.Text = "List of Patients";
			label.Font = Font.SystemFontOfSize (15);
			label.TextColor = Color.Silver;
			label.HorizontalOptions = LayoutOptions.CenterAndExpand;
			var header = label;

			var SrchbarPatient = new SearchBar {
				Placeholder = "Search Patient"
			};

			PatientManager pmgr = new PatientManager ();
			List <PatientListItemModel> plist = pmgr.getPatientsList ();

			ListView lstpatient = new ListView { RowHeight = 40 };

			lstpatient.ItemsSource = plist;
			//set data template for the listview
			lstpatient.ItemTemplate = new DataTemplate(typeof(PatientView));

			/////edit
			lstpatient.ItemSelected += async (sender, e) => {
				PatientListItemModel selectedItem = (PatientListItemModel)e.SelectedItem;
				var ID = selectedItem.PatientId;
				 Navigation.PushAsync  (new AddPatients  ("Edit",ID));
				IDs = ID;
			};


			SrchbarPatient.TextChanged += async (sender, e) => {
				//trial
				//List <Patient> pp = pmgr.GetPatientbyID (IDs);
				//lstpatient .ItemsSource = pp;
				//lstpatient.ItemTemplate = new DataTemplate(typeof(PatientView));
			};

			var btnAddPatient = new Button{
				Text = "Add Patient",
				HorizontalOptions =LayoutOptions.Start
			};

			btnAddPatient .Clicked += delegate {
				Navigation .PushModalAsync (new AddPatients  ("Add"));

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

		}
			
		//list view data template type
		public class PatientView:ViewCell 
		{
			public PatientView()
			{
				var DisplayName = new Label{};
				DisplayName.SetBinding(Label.TextProperty, "DisplayName");
				DisplayName.HeightRequest = 40;

				var FieldData = CreateNameLayout();


				var DataView = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					Children = { DisplayName, FieldData }
				};
				View = DataView ;
			}

			static StackLayout CreateNameLayout()
			{
				//for editing purposes
				var patientId = new Label {
					IsVisible =true ,
				};
				patientId.SetBinding(Label.TextProperty, "PatientId");
				var nameLayout = new StackLayout()
				{
					HorizontalOptions = LayoutOptions.StartAndExpand,
					Orientation = StackOrientation.Vertical,
					Children = { patientId}
				};	
				return nameLayout;
			}

		};

			
	}
		

	public class AddPatients: ContentPage 
	{
		static Patient patient;
		static PatientManager pmgr;

		public AddPatients(string mode,int patientId=0) 
		{
			pmgr = new PatientManager ();
			patient = new Patient ();

			if (mode=="Edit")
				patient = pmgr.GetPatient (patientId);

				BindingContext = patient;

			var Header = new Label
			{
				Text = "Add Patient Info",
				HorizontalOptions= LayoutOptions.CenterAndExpand,
			};

			var pstControlLayout = lstPatientControls (mode);

			Content = new StackLayout {
				Children = { Header, pstControlLayout }
			};
		}
		
		public ScrollView  lstPatientControls (string mode) 
		{
			var txtPatientId = new Entry {};
			txtPatientId.SetBinding (Entry.TextProperty, "PatientId");

			var txtFName = new Entry { Placeholder = "First Name" };
			txtFName.SetBinding (Entry.TextProperty, "FirstName");

			var txtLName = new Entry { Placeholder = "Last Name" };
			txtLName.SetBinding (Entry.TextProperty, "LastName");

			var DtOfBirth = new DatePicker { Format = "D" };
			DtOfBirth.SetBinding (DatePicker.DateProperty, "DateOfBirth");

			//change to spinner
			var txtCivilStatus = new Entry { Placeholder = "Civil Status" };
			txtCivilStatus.SetBinding(Entry.TextProperty,"CivilStatus");

			var txtHandedNess = new Entry { Placeholder = "Handedness" };
			txtHandedNess.SetBinding (Entry.TextProperty, "HandedNess");

			var txtGender = new Entry { Placeholder = "Gender" };
			txtGender.SetBinding (Entry.TextProperty, "Gender");

			var txtOccupation = new Entry { Placeholder = "Occupation" };
			txtOccupation.SetBinding (Entry.TextProperty, "Occupation");

			var txtAddress = new Entry { Placeholder = "Address" };
			txtAddress.SetBinding (Entry.TextProperty, "Address");

			var txtReligion = new Entry { Placeholder = "Religion" };
			txtReligion.SetBinding (Entry.TextProperty, "Religion");

			var txtNationality = new Entry { Placeholder = "Nationality" };
			txtNationality.SetBinding (Entry.TextProperty, "Nationality");

			var btnSave = new Button { Text = "Save", VerticalOptions = LayoutOptions.Start  };

			var btnDel = new Button { Text = "Delete", VerticalOptions = LayoutOptions.End };

			btnSave.Clicked  += async (sender, e) => {
				if (mode=="Add")
				{
					pmgr.Add(patient);
					await DisplayAlert ( txtFName.Text  + " " + txtLName.Text , "has been added!", "Ok");
				}
				else
				{
					pmgr.Edit(patient.PatientId,patient);
				}
					
			};


			var btn = new bool ();
			btnDel.Clicked += async (sender, e) => {

					if (mode=="Add")
						pmgr.Add(patient);
					else
						 btn = await DisplayAlert ("Question?", "Are you sure you want to delete " + txtFName.Text  + " " + txtLName.Text  , "Yes", "No");
							if (btn)
							{
								pmgr.Delete(patient.PatientId);
								await DisplayAlert ( txtFName.Text  + " " + txtLName.Text , "has been deleted!", "Ok");
							}
			};


			var pstControlsLayout = new ScrollView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = new StackLayout {
					Children = {
						txtFName, txtLName, DtOfBirth, txtCivilStatus,
						txtHandedNess, txtGender, txtOccupation, txtAddress, txtReligion,
						txtNationality, btnSave,btnDel
					}
				}
			};
		
			return pstControlsLayout;
		}
	}

	public class patientModels: Patient 
	{

		public patientModels  (string mode,int PtId,
			string FirstName, 
			string LastName,
			DateTime DateOfBirth,
			string CivilStatus,
			string HandedNess,
			string Gender,
			string Occupation,
			string Address,
			string Religion,
			string Nationality) {

			Patient patientModel = new Patient {
				FirstName = FirstName,
				LastName = LastName,
				DateOfBirth = DateOfBirth,
				CivilStatus = CivilStatus,
				HandedNess = HandedNess,
				Gender = Gender,
				Occupation =Occupation,
				Address = Address,
				Religion = Religion,
				Nationality = Nationality  
				};	 


			}
		}

}

