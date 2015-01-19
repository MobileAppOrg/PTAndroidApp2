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
			Title = "List of Patients";

			ToolbarItem t1 = new ToolbarItem();
			t1.Text = "Add";
			t1.Icon = "ic_action_new.png";


			ToolbarItem t2 = new ToolbarItem();
			t2.Text = "Add";
			t2.Icon = "ic_action_refresh.png";


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

			lstpatient.ItemSelected += async (sender, e) => {
			PatientListItemModel selectedItem = (PatientListItemModel)e.SelectedItem;
			var ID = selectedItem.PatientId;
			Navigation.PushAsync  (new AddPatients  ("Edit",ID));
			};

			t1.Clicked += delegate {
				Navigation.PushAsync(new AddPatients  ("Add"));
			};

			t2.Clicked += delegate {
				SrchbarPatient .Text = "";
				lstpatient.ItemsSource = plist.Where(patient => patient.DisplayName.ToLower().Contains(SrchbarPatient.Text .ToLower())).ToList();
			};


			ToolbarItems.Add (t2);
			ToolbarItems.Add (t1);


			//content of the page
			Content = new StackLayout {
				Children = {
					SrchbarPatient,
					lstpatient, 

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

			Title = "Add Patient";

			if (mode=="Edit")
				patient = pmgr.GetPatient (patientId);

				BindingContext = patient;

			var pstControlLayout = lstPatientControls (mode);

			Content = new StackLayout {
				Children = {pstControlLayout }
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

			var CivilStatus = new Entry (){ IsVisible = false };
			CivilStatus.SetBinding (Entry.TextProperty, "CivilStatus");

			var civilStatusPicker = new Picker (){ Items = { "Single", "Married", "Divorced", "Widowed" }, 
				Title = "Civil Status", 
				HorizontalOptions = LayoutOptions.FillAndExpand };

	

			var HandedNess = new Entry (){ IsVisible = false };
			HandedNess.SetBinding (Entry.TextProperty, "HandedNess");

			var pckHandedNess = new Picker (){ Items = { "Right", "Left",}, 
				Title = "Handedness", 
				HorizontalOptions = LayoutOptions.FillAndExpand };
				
			var Gender = new Entry (){ IsVisible = false  };
			Gender.SetBinding (Entry.TextProperty, "Gender");

			var pckGender = new Picker (){ Items = { "Male", "Female",}, 
				Title = "Gender", 
				HorizontalOptions = LayoutOptions.FillAndExpand };
				
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
				VerticalOptions = LayoutOptions.StartAndExpand ,
			};


			if (mode == "Edit") {
				//CivilStatus
				//HandedNess
				//Gender

			}



			civilStatusPicker.SelectedIndexChanged += delegate(object sender, EventArgs e) {
				if (civilStatusPicker.SelectedIndex == -1)
					CivilStatus.Text = null;
				else
					CivilStatus.Text = civilStatusPicker.Items [civilStatusPicker.SelectedIndex];
			};

			pckHandedNess.SelectedIndexChanged += delegate(object sender, EventArgs e) {
				if (pckHandedNess.SelectedIndex == -1)
					HandedNess.Text = null;
				else
					HandedNess.Text = pckHandedNess.Items[pckHandedNess.SelectedIndex];
			};

			pckGender.SelectedIndexChanged += delegate(object sender, EventArgs e) {
				if (pckGender.SelectedIndex == -1)
					Gender.Text = null;
				else
					Gender.Text = pckGender.Items[pckGender.SelectedIndex];
			};
				
			var btnDel = new Button { Text = "Delete", 
				TextColor = Color.Black,
				BackgroundColor = Color.Silver,
				VerticalOptions = LayoutOptions.EndAndExpand  ,
				//HorizontalOptions  = LayoutOptions.CenterAndExpand
				};
				
			btnSave.Clicked  += async (sender, e) => {
				if (mode=="Add")
				{
					pmgr.Add(patient);
					await DisplayAlert ( txtFName.Text  + " " + txtLName.Text , "has been added!", "Ok");
					Navigation.PopAsync();
					Navigation.PushAsync (new SearchPatientPage());
				}
				else
				{
					pmgr.Edit(patient.PatientId,patient);
					await DisplayAlert ( txtFName.Text  + " " + txtLName.Text , "has been updated!", "Ok");
					Navigation.PopAsync();
					Navigation.PushAsync (new SearchPatientPage());
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
								Navigation.PopAsync();
								Navigation.PushAsync (new SearchPatientPage());
							}
			};

			var pstControlsLayout = new ScrollView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = new StackLayout {
					Children = {
						txtFName, txtLName, DtOfBirth,civilStatusPicker,
						CivilStatus,HandedNess, Gender,pckHandedNess,
						pckGender, txtOccupation,txtAddress,
						txtProvince,txtCityTown,txtReligion,btnSave,btnDel
					}
				}
			};

			return pstControlsLayout;
		}
	}


		

}

