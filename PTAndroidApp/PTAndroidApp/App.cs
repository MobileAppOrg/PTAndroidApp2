using System;
using Xamarin.Forms;

namespace PTAndroidApp
{



	public class App
	{

		public static Page GetMainPage ()
		{	
			return new StackMainPage ();
			//return new ContentPage { 
			//	Content = new StackMainLayout()
			//};
		}

		public static Page GetPatientPage ()
		{
			return new PatientMainPage ();

		}

	

		public static Page GetMasterPage ()
		{
			return new MasterPage();


		}


		public static Page SearchPatientPage ()
		{
			return new SearchPatientPage();

		}



	}







	public class StackMainPage:ContentPage	
	{
		public StackMainPage(){
			var btnPatient = new Button {
				Text = "Patient Management"
			};

			btnPatient.Clicked += delegate {
				Navigation.PushModalAsync(new PatientMainPage());
			};

			Content = new StackLayout (){
				Children = { btnPatient }
			};
		}
	}







	public class PatientMainPage:ContentPage 
	{
		public PatientMainPage(){
			var btnAddPatient = new Button {
				Text = "Add"
			};

			btnAddPatient.Clicked += delegate {

				Navigation.PushModalAsync(new AddPatientPage());

			};

			Content = new StackLayout (){
				Children = { btnAddPatient }
			};
		}
	}

	public class AddPatientPage:ContentPage
	{
		public AddPatientPage(){
			var lblFirstName = new Label {
				Text = "First Name:"
			};
			var txtFirstName = new Entry {
			};
			var lblLastName = new Label {
				Text = "Last Name:"
			};
			var txtLastName = new Entry {
			};
			var lblDateOfBirth = new Label {
				Text = "Date of Birth:"
			};
			var txtDateOfBirth = new DatePicker {
				Format="D"
			};

			var btnAddPatient = new Button {
				Text = "Save"
			};

			btnAddPatient.Clicked += delegate {
				PatientModel patient = new PatientModel {
					FirstName = txtFirstName.Text,
					LastName = txtLastName.Text,
					DateOfBirth = txtDateOfBirth.Date
				};

				Patient p = new Patient();
				var success = p.Add(patient);
				if (success)
					DisplayAlert("Success","Success!","Close");
				else
					DisplayAlert("Error","Error!", "Close");

				Navigation.PopModalAsync();
			};

			Content = new StackLayout (){
				Children = { 
					lblFirstName,
					txtFirstName,
					lblLastName,
					txtLastName,
					lblDateOfBirth,
					txtDateOfBirth,
					btnAddPatient 
				}
			};
		}
	}
		
}

