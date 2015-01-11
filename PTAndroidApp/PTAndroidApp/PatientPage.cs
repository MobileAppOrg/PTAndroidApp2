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

			var label = new Label ();
			label.Text = "List of Patients";
			label.Font = Font.SystemFontOfSize (15);
			label.TextColor = Color.Silver;
			label.HorizontalOptions = LayoutOptions.CenterAndExpand;
			var header = label;

			var SrchbarPatient = new SearchBar {
				Placeholder = "Search Patient"
			};


			PatientManager patient = new PatientManager ();
			List <Patient> plists = patient.GetPatient();

			var patients = new Patient ();
			List <PatientListItemModel> plist = patient.getPatientsList ();


			ListView lstpatient = new ListView {
				RowHeight = 40 

			};


			lstpatient.ItemsSource = plists;
			//set data template for the listview
			lstpatient.ItemTemplate = new DataTemplate(typeof(PatientView));
			var btnAddPatient = new Button{
				Text = "Add Patient",
				HorizontalOptions =LayoutOptions.Start
			};



			/////edit


			lstpatient.ItemTapped += delegate {
				/// 

				var ID = new Label {
					Text  = lstpatient .SelectedItem.ToString () 
					
				};

				     
				PatientManager patientManager = new PatientManager ();
				List <Patient> plt = patientManager.GetPatientbyID(int.Parse (ID.Text.ToString ()));


				ListView lstp = new ListView {
					RowHeight = 40 
				};		lstp.ItemsSource = plt;
				var name = new Label {};
				name.SetBinding(Label.TextProperty, "FirstName");
				Navigation .PushModalAsync (new AddPatients  ("",1,name.Text ,"",
					DateTime .Now ,"","","","","","",""));

			};






			btnAddPatient .Clicked += delegate {
				Navigation .PushModalAsync (new AddPatients  ("",1,"","",
					DateTime .Now ,"","","","","","",""));

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
				var FName = new Label
				{};

				FName .SetBinding(Label.TextProperty, "FirstName");
				FName.HeightRequest = 40;
				var LName = new Label
				{};
				LName .SetBinding(Label.TextProperty, "LastName");
				LName.HeightRequest = 40;
				var FieldData = CreateNameLayout();


				var DataView = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					Children = { FName,LName,  FieldData }
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
		public AddPatients(string mode,int PtId,
			string FirstName, 
			string LastName,
			DateTime DateOfBirth,
			string CivilStatus,
			string HandedNess,
			string Gender,
			string Occupation,
			string Address,
			string Religion,
			string Nationality) 
		{
			var Header = new Label
			{
				Text = "Add Patient Info",
				HorizontalOptions= LayoutOptions.CenterAndExpand,
			};
			var pstControlLayout = lstPatientControls ("",PtId,FirstName,LastName,
				DateOfBirth ,CivilStatus,HandedNess,Gender,Occupation,Address,Religion,
				Nationality);
			Content = new StackLayout {
				Children = {
					Header,
					pstControlLayout
				
				}
			};
		
		}
		
		static ScrollView  lstPatientControls (string mode,int PtId,
			string FirstName, 
			string LastName,
			DateTime DateOfBirth,
			string CivilStatus,
			string HandedNess,
			string Gender,
			string Occupation,
			string Address,
			string Religion,
			string Nationality) 
		{

			//if (mode == "new") {
				var txtFName = new Entry {
					Placeholder = "First Name",
					Text = FirstName,
					};


				var txtLName = new Entry {
					Placeholder = "Last Name",
					Text = LastName
				};
				var DtOfBirth = new DatePicker {
					Format = "D",
					Date  = DateOfBirth.Date,

				};
				//change to spinner
				var txtCivilStatus = new Entry {
					Placeholder = "Civil Status",
					Text = CivilStatus
				};
				var txtHandedNess = new Entry {
					Placeholder = "Handedness",
					Text = HandedNess
				};
				var txtGender = new Entry {
					Placeholder = "Gender",
					Text = Gender
				};
				var txtOccupation = new Entry {
					Placeholder = "Occupation",
					Text = Occupation
				};
				var txtAddress = new Entry {
					Placeholder = "Address",
					Text = Address
				};
				var txtReligion = new Entry {
					Placeholder = "Religion",
					Text = Religion
				};
				var txtNationality = new Entry {
					Placeholder = "Nationality",
					Text = Religion
				};
				var btnSave = new Button {
					Text = "Save",
					//HorizontalOptions = LayoutOptions.End,
					VerticalOptions =LayoutOptions .End 
				};
			
				btnSave.Clicked += delegate {
				//patientModels ptmodel = new patientModels ("",0,txtFName.Text,
					//txtLName.Text,DateOfBirth.Date,txtCivilStatus.Text,
					//txtHandedNess.Text,txtGender.Text,txtOccupation.Text,
					//txtAddress.Text,txtReligion.Text,
				//	txtNationality.Text);
				Patient patientModel = new Patient {
						PatientId = PtId,
						FirstName = txtFName.Text,
						LastName = txtLName.Text,
						DateOfBirth = DateOfBirth.Date,
						CivilStatus = txtCivilStatus.Text,
						HandedNess = txtHandedNess.Text,
						Gender = txtGender.Text,
						Occupation = txtOccupation.Text,
						Address = txtAddress.Text,
						Religion = txtReligion.Text,
						Nationality = txtNationality.Text  
					};


				PatientManager patient = new PatientManager ();
					var success = patient.Add (patientModel);
				};
			
				var pstControlsLayout = new ScrollView {
					VerticalOptions = LayoutOptions.FillAndExpand,
					Content = new StackLayout {
						Children = {
							txtFName, txtLName, DtOfBirth, txtCivilStatus,
							txtHandedNess, txtGender, txtOccupation, txtAddress, txtReligion,
							txtNationality, btnSave
						}
					}
				};
				return pstControlsLayout;

			//};
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

