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
using PTAndroidApp.ValueConverters;



namespace PTAndroidApp
{


	public class SearchPatientPage : ContentPage
	{
		protected override void OnAppearing ()
		{
			RefreshList ();
		}

		public static void RefreshList(){
			plist = pmgr.getPatientsList ();
			lstpatient.RowHeight = 60;
			lstpatient.ItemsSource = plist;
			lstpatient.ItemTemplate = new DataTemplate(typeof(PatientView));
		}
			
		private static List<PatientListItemModel> plist = new List<PatientListItemModel> ();
		private static ListView lstpatient = new ListView();
		private static PatientManager pmgr  = new PatientManager();

		public SearchPatientPage()
		{
			Title = "List of Patients";

			ToolbarItem t1 = new ToolbarItem();
			t1.Text = "Add";
			t1.Icon = "ic_action_new.png";

			ToolbarItem t2 = new ToolbarItem();
			t2.Text = "Refresh";
			t2.Icon = "ic_action_refresh.png";

			var SrchbarPatient = new SearchBar {
				Placeholder = "Search Patient",
			};

			//RefreshList ();
		
			SrchbarPatient.TextChanged += async (sender, e) => {
				lstpatient.ItemsSource = plist.Where(patient => patient.DisplayName.ToLower().Contains(SrchbarPatient.Text .ToLower())).ToList();
			};

			lstpatient.ItemSelected += async (sender, e) => {
				PatientListItemModel selectedItem = (PatientListItemModel)e.SelectedItem;
				var ID = selectedItem.PatientId;
				await Navigation.PushAsync  (new AddPatients  ("Edit",ID));
			};

			t1.Clicked += delegate {
				Navigation.PushAsync(new AddPatients  ("Add"));
			};

			t2.Clicked += delegate {
				RefreshList();
			};
				
			ToolbarItems.Add (t2);
			ToolbarItems.Add (t1);

			//content of the page
			Content = new StackLayout {
				Children = {
					SrchbarPatient,
					lstpatient}
				};
			}

		//list view data template type
		public class PatientView:ViewCell 
		{
			public PatientView()
			{
				var DisplayName = new Label   {
					FontSize = 20,
					HorizontalOptions = LayoutOptions.StartAndExpand 
				};
				DisplayName.SetBinding(Label.TextProperty, "DisplayName");
				var FieldData = CreateNameLayout();
				var DataView = new StackLayout()
				{
					Orientation = StackOrientation.Vertical,
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
				var patientAddress = new Label {
					FontSize = 12
				};
				patientId.SetBinding(Label.TextProperty, "PatientId");
				patientAddress.SetBinding( Label.TextProperty, "Address");
				var nameLayout = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal  ,
					Children = { patientId,patientAddress}
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
			// Picker Choices
			List<string> listCivilStatus = new List<string> (){ "Single", "Married", "Divorced", "Widowed" };
			List<string> listHandedness = new List<string> (){ "Right", "Left" };
			List<string> listGender = new List<string> (){ "M", "F" };

			var txtPatientId = new Entry {};
			txtPatientId.SetBinding (Entry.TextProperty, "PatientId", BindingMode.TwoWay);

			var txtFName = new Entry { Placeholder = "First Name" };
			txtFName.SetBinding (Entry.TextProperty, "FirstName", BindingMode.TwoWay);

			var txtLName = new Entry { Placeholder = "Last Name" };
			txtLName.SetBinding (Entry.TextProperty, "LastName", BindingMode.TwoWay);

			var DtOfBirth = new DatePicker { Format = "D", };
			DtOfBirth.SetBinding (DatePicker.DateProperty, "DateOfBirth", BindingMode.TwoWay);

			var civilStatusPicker = new Picker (){ Items = { "Single", "Married", "Divorced", "Widowed" }, 
				Title = "Civil Status", 
				HorizontalOptions = LayoutOptions.FillAndExpand };

			civilStatusPicker.SetBinding (Picker.SelectedIndexProperty, "CivilStatus", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ItemList = listCivilStatus});

			var pckHandedNess = new Picker (){ Items = { "Right", "Left" }, 
				Title = "Handedness", 
				HorizontalOptions = LayoutOptions.FillAndExpand };

			pckHandedNess.SetBinding (Picker.SelectedIndexProperty, "HandedNess", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ItemList = listHandedness});

			var pckGender = new Picker (){ Items = { "M", "F" }, 
				Title = "Gender", 
				HorizontalOptions = LayoutOptions.FillAndExpand };

			pckGender.SetBinding (Picker.SelectedIndexProperty, "Gender",
				BindingMode.TwoWay, new IndexToGenericListConverter(){ItemList = listGender});
				
			var txtOccupation = new Entry { Placeholder = "Occupation"};
			txtOccupation.SetBinding (Entry.TextProperty, "Occupation", BindingMode.TwoWay);

			var txtAddress = new Entry { Placeholder = "Address" };
			txtAddress.SetBinding (Entry.TextProperty, "Address", BindingMode.TwoWay);

			var txtReligion = new Entry { Placeholder = "Religion"};
			txtReligion.SetBinding (Entry.TextProperty, "Religion", BindingMode.TwoWay);

			var txtCityTown = new Entry { Placeholder = "City Town" };
			txtCityTown.SetBinding (Entry.TextProperty, "CityTown", BindingMode.TwoWay);

			var txtProvince = new Entry { Placeholder = "Province"};
			txtProvince.SetBinding (Entry.TextProperty, "Province", BindingMode.TwoWay);

			var btnSave = new Button { Text = "Save",TextColor = Color.Black,
				BackgroundColor = Color.Silver,
				HorizontalOptions = LayoutOptions.FillAndExpand };

			var btnDel = new Button { Text = "Delete", 
				TextColor = Color.Black,
				BackgroundColor = Color.Silver,
				HorizontalOptions = LayoutOptions .FillAndExpand };

			var buttons = new StackLayout {
				Children = {btnDel,btnSave},
				Orientation = StackOrientation .Horizontal };
				
			btnSave.Clicked  += async (sender, e) => {
				if (mode=="Add")
				{
					pmgr.Add(patient);
					await DisplayAlert ( txtFName.Text  + " " + txtLName.Text , "has been added!", "Ok");
				//Navigation.PushAsync (new SearchPatientPage());
					await Navigation.PopAsync();

				}
				else
				{
					pmgr.Edit(patient.PatientId,patient);
					await DisplayAlert ( txtFName.Text  + " " + txtLName.Text , "has been updated!", "Ok");
					await Navigation.PopAsync();

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
								await Navigation.PopAsync();
								}
			};

			var pstControlsLayout = new ScrollView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = new StackLayout {
					Children = {
						txtFName, txtLName, DtOfBirth,
						civilStatusPicker,pckHandedNess,pckGender,
						txtOccupation,txtAddress,
						txtProvince,txtCityTown,txtReligion,buttons}
				}
			};

			return pstControlsLayout;
		}
	}


		

}

