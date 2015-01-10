using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Android;


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

			var patients = new Patient ();
			List <PatientModel> plist = patients.GetPatient ();

			ListView lstpatient = new ListView {
				RowHeight = 40 

			};
			lstpatient.ItemsSource = plist;
			//set data template of the listview
			lstpatient.ItemTemplate = new DataTemplate(typeof(PatientView));


			var btnAddPatient = new Button{
				Text = "Add Patient",
				HorizontalOptions =LayoutOptions.Start
			};

			btnAddPatient .Clicked += delegate {
				Navigation .PushModalAsync (new AddPatients (0,"","",DateTime .Today,"","","","","","",""));

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
				var FieldName = new Label
				{
					HorizontalOptions= LayoutOptions.FillAndExpand
				};

				FieldName .SetBinding(Label.TextProperty, "DisplayName");
				FieldName.HeightRequest = 40;

				var FieldData = CreateNameLayout();

				var DataView = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					Children = { FieldName, FieldData }
				};
				View = DataView ;
			}
			static StackLayout CreateNameLayout()
			{
				//for editing purposes
				var patientId = new Label {
					IsVisible = false,
				};
				patientId.SetBinding(Label.TextProperty, "PatientId");


				var PatientName = new Label
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
				};

				PatientName.SetBinding(Label.TextProperty, "FirstName" + " " + "LastName");
				var nameLayout = new StackLayout()
				{
					HorizontalOptions = LayoutOptions.StartAndExpand,
					Orientation = StackOrientation.Vertical,
					Children = { patientId, PatientName }
				};
				return nameLayout;
			}

		};


	}



	public class AddPatients: ContentPage 
	{
		public AddPatients(int PatientId,
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
				HorizontalOptions= LayoutOptions.CenterAndExpand 
			};

			var btnSave = new Button {
				Text = "Save",
				HorizontalOptions= LayoutOptions.End 

			};
			var pstControlLayout = lstPatientControls ();



			btnSave.Clicked += delegate {
				PatientModel patient = new PatientModel {


				};


				Patient p = new Patient();
				var success = p.Add(patient);
				if (success)
					DisplayAlert("Success","Success!","Close");
				else
					DisplayAlert("Error","Error!", "Close");

				Navigation.PopModalAsync();
			};





			Content = new StackLayout {
				Children = {
					Header,
					pstControlLayout,
					btnSave
				}
			};

		}


		static ScrollView  lstPatientControls ()
		{
			var txtFName = new Entry  {
				Placeholder = "First Name",

			};
			var txtLName = new Entry  {
				Placeholder = "Last Name"
			};
			var DateOfBirth = new DatePicker   {
				Format="D"
			};
			//change to spinner
			var CivilStatus = new Entry {
				Placeholder = "Civil Status"
			};
			var HandedNess = new Entry {
				Placeholder = "Handedness"
			};
			var Gender = new Entry {
				Placeholder = "Gender"
			};
			var Occupation = new Entry {
				Placeholder = "Occupation"
			};
			var Address = new Entry {
				Placeholder = "Address"
			};
			var Religion = new Entry {
				Placeholder = "Religion"
			};
			var Nationality = new Entry {
				Placeholder = "Nationality"
			};

			var pstControlsLayout = new ScrollView {
				VerticalOptions = LayoutOptions.FillAndExpand ,
				Content = new StackLayout  {
					Children = {

						txtFName, txtLName, DateOfBirth, CivilStatus,
						HandedNess, Gender, Occupation, Address, Religion,
						Nationality
					}

				}
			};

			return pstControlsLayout;

		}

		//static string  PtModel (string DataMode)
		//{

		//	var scrviewPatient =  lstPatientControls ();
		//PatientModel patient = new PatientModel {

		//	FirstName = txtFirstName.Text,
		//LastName = txtLastName.Text,
		//DateOfBirth = txtDateOfBirth.Date


		//};

		//	return patient;
		//}





	};


}

