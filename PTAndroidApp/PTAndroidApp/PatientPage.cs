using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Android;
using System.Threading.Tasks;
using PTAndroidApp.Models;
using System.Collections.ObjectModel;
using Android.App;
using Android.Runtime;
using Android.Views;
using Android.OS;
using System .Linq ;
using Android.Provider;



namespace PTAndroidApp
{


	public class SearchPatientPage : ContentPage   

	{
	

	
			public SearchPatientPage()
		{		
		
			BackgroundColor = Color.White; 
			Title = "List of Patients";

			var SrchbarPatient = new SearchBar {
				Placeholder = "Search Patient",
			};

			PatientManager pmgr = new PatientManager ();
			List <PatientListItemModel> plist = pmgr.getPatientsList ();

			ListView lstpatient = new ListView { RowHeight = 40 };

			lstpatient.ItemsSource = plist;
			lstpatient.ItemTemplate = new DataTemplate(typeof(PatientView));
		
			SrchbarPatient.TextChanged += async (sender, e) => {
				lstpatient.ItemsSource = plist.Where(patient => patient.DisplayName.ToLower().Contains(SrchbarPatient.Text .ToLower())).ToList();
			};


			/////edit
			lstpatient.ItemSelected += async (sender, e) => {
			PatientListItemModel selectedItem = (PatientListItemModel)e.SelectedItem;
			var ID = selectedItem.PatientId;
			Navigation.PushAsync  (new AddPatients  ("Edit",ID));
				};
				
			var btnAddPatient = new Button{ 
				Text = "Add Patient",
				TextColor = Color.Black ,
				HorizontalOptions =LayoutOptions.CenterAndExpand 
				};

			btnAddPatient .Clicked += delegate {
				Navigation .PushModalAsync (new AddPatients  ("Add"));

				};
				
			//content of the page
			Content = new StackLayout {
				Children = {
					SrchbarPatient,
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

				var DisplayName = new Label   {
					TextColor = Color.Black ,
					Font = Font.SystemFontOfSize (16),
					HorizontalOptions = LayoutOptions.Center
				};

				DisplayName.SetBinding(Label.TextProperty, "DisplayName");
				DisplayName.HeightRequest = 30;


				var FieldData = CreateNameLayout();
				var DataView = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					Children = { DisplayName,FieldData}
				};
				View = DataView ;
			}

			static StackLayout  CreateNameLayout()
			{
				//for editing purposes
				var patientId = new Label {
					IsVisible =false,
				};

				patientId.SetBinding(Label.TextProperty, "PatientId");

				var nameLayout = new StackLayout()
				{
					HorizontalOptions = LayoutOptions.StartAndExpand,
					Orientation = StackOrientation.Horizontal  ,
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

			BackgroundColor = Color.White; 
			Title = "List of Patients";

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
			var txtPatientId = new Entry {TextColor = Color.Black,};
			txtPatientId.SetBinding (Entry.TextProperty, "PatientId");

			var txtFName = new Entry { Placeholder = "First Name" ,
			TextColor = Color.Black,};
			txtFName.SetBinding (Entry.TextProperty, "FirstName");

			var txtLName = new Entry { Placeholder = "Last Name",TextColor = Color.Black, };
			txtLName.SetBinding (Entry.TextProperty, "LastName");

			var DtOfBirth = new DatePicker { Format = "D", };
			DtOfBirth.SetBinding (DatePicker.DateProperty, "DateOfBirth");

			//change to spinner
			var txtCivilStatus = new Entry { Placeholder = "Civil Status",TextColor = Color.Black, };
			txtCivilStatus.SetBinding(Entry.TextProperty,"CivilStatus");

			var txtHandedNess = new Entry { Placeholder = "Handedness" ,TextColor = Color.Black,};
			txtHandedNess.SetBinding (Entry.TextProperty, "HandedNess");

			Picker pckGender = new Picker{Title = "Gender",
			VerticalOptions = LayoutOptions.CenterAndExpand,};
			string [] genderList = {"Male","Female"};
			foreach (string gender in genderList)
			{pckGender.Items.Add(gender);}
			pckGender.SetBinding (Entry.TextProperty, "Gender");
			pckGender.SetBinding (Entry.TextColorProperty , "Black");

			var txtOccupation = new Entry { Placeholder = "Occupation",TextColor = Color.Black, };
			txtOccupation.SetBinding (Entry.TextProperty, "Occupation");

			var txtAddress = new Entry { Placeholder = "Address",TextColor = Color.Black, };
			txtAddress.SetBinding (Entry.TextProperty, "Address");

			var txtReligion = new Entry { Placeholder = "Religion",TextColor = Color.Black, };
			txtReligion.SetBinding (Entry.TextProperty, "Religion");

			var txtCityTown = new Entry { Placeholder = "City Town",TextColor = Color.Black, };
			txtCityTown.SetBinding (Entry.TextProperty, "CityTown");

			var txtProvince = new Entry { Placeholder = "Province",TextColor = Color.Black, };
			txtProvince.SetBinding (Entry.TextProperty, "Province");



			var btnSave = new Button { Text = "Save",TextColor = Color.Black,
				BackgroundColor = Color.Silver,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				//HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			var btnDel = new Button { Text = "Delete", 
				TextColor = Color.Black,
				BackgroundColor = Color.Silver,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				//HorizontalOptions  = LayoutOptions.CenterAndExpand
				};



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
						txtHandedNess, pckGender, txtOccupation,
						txtAddress,txtProvince,txtCityTown,
						txtReligion,btnSave,btnDel
					}
				}
			};
		
			return pstControlsLayout;
		}
	}


		

}

