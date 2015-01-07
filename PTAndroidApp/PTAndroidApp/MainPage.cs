using System;
using Xamarin.Forms;




namespace PTAndroidApp
{

	public class MainPage
	{

		public static Page GetMasterPage ()
		{
			return new NavigationPage ( new MasterPage());
			//return new MasterPage();
		}

		public static Page SearchPatientPage ()
		{
			return new NavigationPage(new SearchPatientPage());
		}

	}





	public class MasterPage : ContentPage 
	{

		public MasterPage(){

			//set date to display
			DateTime dtToday = DateTime.Today;
			string tt = "";

			if(dtToday .ToString ("tt") == "AM")
			{
				tt = "Good Morning!";
			}
			else
			{
				tt= "Good Afternoon!";
			}


			//control/views
			var lblHeader = new Label {
				Text = tt + "\n" + dtToday.ToString ("yy-MMM-dd ddd"),
				BackgroundColor = Color.Black,
				Font = Font.SystemFontOfSize (20),
				TextColor = Color.Silver ,
				HorizontalOptions = LayoutOptions.CenterAndExpand,

				 	
			};


		     var btnPatient = new Button {
				Text = "List Of Patients",
				TextColor = Color.Gray ,
				BackgroundColor = Color.Silver 
			};

			var btnSoap = new Button {
				Text = "List Of SOAPs",
				TextColor = Color.Gray ,
				//Text = TextAlignment .Center 
				BackgroundColor = Color.Silver  

			};

			btnPatient.Clicked += delegate {
				Navigation.PushAsync(new SearchPatientPage ());
			};


			Content = new StackLayout {
				Children = {
					lblHeader,
					btnPatient,
					btnSoap
				}
			};
				



//			Master = new ContentPage 
//			{
//				Content = new StackLayout
//				{
//					Children = 
//					{
//						lblHeader
//					}
//				},
//					Title = "Master˚"
//			};


//			Detail = new NavigationPage(new ContentPage 
//				{ Content = new StackLayout
//					{
//						Children = 
//						{
//							lblHeader,
//							btnPatient,
//							btnSoap
//						},
//					}
//				}
//			);
				

		}



	}



		public class SearchPatientPage : ContentPage   
		{
		public SearchPatientPage()
		{

		
			var SrchbarPatient = new SearchBar {
				Placeholder = "Search Patient"
			};


			//change itemsource on what the data from webapi 
			string[] PatientName = {"Temyung Sakitan", "Apung Puli", "Sicky Wander", "Aspak Buntuk", "Aspak Buntuk", "Aspak Buntuk", "Aspak Buntuk", "Aspak Buntuk"} ;

			ListView lstpatient = new ListView
			{
				ItemsSource = PatientName ,
				 
				
			};



			//scroll view for patient list

				var scrlview = new ScrollView {

					Padding = new Thickness (20),

					Content = new StackLayout {

					Children = {
					
						lstpatient,
						}
					}
				};
		
			
			//content of the page
			Content = new StackLayout {

				Children = {
					SrchbarPatient,
					scrlview
				}

			};

		

		}


	
	}



}
