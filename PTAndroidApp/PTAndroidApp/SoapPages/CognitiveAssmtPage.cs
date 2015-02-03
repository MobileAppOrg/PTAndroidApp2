using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
namespace PTAndroidApp
{
	public class CognitiveAssmtPage : ContentPage
	{ 
		private static Button btnQuestion = new Button {  WidthRequest = 30, Text = "!"};
		private static Picker LTQuestion = new Picker () { 
			Title = "Click To Select LongTerm Question", HeightRequest = 70,
			HorizontalOptions =  LayoutOptions .FillAndExpand, 
			VerticalOptions = LayoutOptions .StartAndExpand,
			Items = {
				"When is your birthday?",
				"When is your date of marriage?",
				"Who is the first president?",
				"When is the date of Independence day of the Philippines?",
				"Others"
			}};
		private static Entry txtOthers = new Entry {IsVisible  = false, Placeholder = "Long Term Question"};



		public static void AppearingEvent(){
			if (LTQuestion.SelectedIndex == 4 )
			{
				txtOthers .IsVisible  = true;
				txtOthers .Text = "";
				txtOthers .Focus();
}
			else
			{
				txtOthers .IsVisible  = false;
			}
		}


		protected override void OnAppearing ()
		{
			AppearingEvent ();
		}



		public CognitiveAssmtPage ()
		{
			var form = CreateTable ();

			btnQuestion .Clicked  += delegate {
				 string str = "Provide the patient with a series of words or numbers, patient should repeat the sequence immediately “Apple, Bag, Cow, Dog, Egg, Frog”";

				DisplayAlert ("Short Term Question", str, "OK");

			};

			Content = new StackLayout { 
				Children = {
					form
				}
			};
		}

		static TableView CreateTable ()
		{
			Entry txtPatientVisitId = new Entry (){ IsVisible = false };
			txtPatientVisitId.SetBinding (Entry.TextProperty,"PatientVisitId", BindingMode.TwoWay);

			var txtSTQuestion = new Entry  {Placeholder = "Short Term Question", HorizontalOptions =LayoutOptions .FillAndExpand };
			var txtSTResponse = new EntryCell  { Placeholder = "Short Term Response"};
			List<string> LTQuestions = new List<string> (){ "When is your birthday?",
				"When is your date of marriage?",
				"Who is the first president?",
				"When is the date of Independence day of the Philippines?",
				"Others: (text box)"};

			var txtLTResponse = new EntryCell { Placeholder = "Long Term Response"};
			var txtFindings = new EntryCell { Placeholder = "Findings"};
			var txtSignificance = new EntryCell { Placeholder = "Significance"};


			LTQuestion.SelectedIndexChanged += delegate {

				try {
				txtOthers.Text  = LTQuestion.Items [LTQuestion.SelectedIndex ].ToString ();
					AppearingEvent ();
				}
				catch{

					return;
				}
			};
				


			ViewCell STcell = new ViewCell {
				View = new StackLayout () {
					Children = {
						txtSTQuestion,
						btnQuestion
					}, Orientation = StackOrientation.Horizontal,
					Padding = 0, Spacing =0}
			};

			ViewCell LTcell = new ViewCell {
				Height = 115,
				View = new StackLayout () {
					Children = {
						LTQuestion,txtOthers
					}, Orientation = StackOrientation.Vertical,
					Padding = 0, Spacing =0}
			};



			txtSTResponse.SetBinding (EntryCell .TextProperty, "CognitiveAssmt.STResponse", BindingMode.TwoWay);
			txtSTQuestion.SetBinding (Entry .TextProperty, "CognitiveAssmt.STQuestion", BindingMode.TwoWay);
			txtOthers.SetBinding (Entry .TextProperty, "CognitiveAssmt.LTQuestion", BindingMode.TwoWay);
			txtLTResponse.SetBinding (EntryCell .TextProperty, "CognitiveAssmt.LTResponse", BindingMode.TwoWay);
			txtFindings.SetBinding (EntryCell .TextProperty, "CognitiveAssmt.Findings", BindingMode.TwoWay);
			txtSignificance.SetBinding (EntryCell .TextProperty, "CognitiveAssmt.Significance", BindingMode.TwoWay);


			return new TableView (){
			Intent = TableIntent .Form,
				HasUnevenRows = true,
				Root = new TableRoot  (){
					new TableSection ("COGNITIVE ASSESSMENT"){
						STcell,txtSTResponse,
						LTcell,
						txtLTResponse,
						txtFindings,
						txtSignificance

					}


				}
			
			};


		}




	}
}


