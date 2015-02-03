using System;

using Xamarin.Forms;

namespace PTAndroidApp
{
	public class BalanceAndTolerancePage : ContentPage
	{
		private static Button btnLegend = new Button {  WidthRequest = 30, Text = "!"};

		public BalanceAndTolerancePage ()
		{
			btnLegend .Clicked  += delegate {
				string str = "\n" +
					"---------------- NORMAL ------------------\n\nBalance = Can assume, maintain, weight shift, and challenge\n\nTolerance = 45-60 min\n\n" +
					"------------------ GOOD --------------------\n\nBalance = Can assume, maintain, and weight shift\n\nTolerance = 30-45 min\n\n" +
					"------------------ FAIR ----------------------\n\nBalance = Can assume, and maintain\n\nTolerance = 15-30 min\n\n" +
					"------------------ POOR --------------------\n\nBalance = Can assume\n\nTolerance = >15 min";


				DisplayAlert ("BALANCE AND TOLERANCE LEGEND", str, "OK");

			};




			var form = CreateTable ();
			Content = new StackLayout { 
				Children = {
					form
				}
			};



		}
			

		static TableView CreateTable ()
		{



//			var lblSitting = new Label{FontSize = 18, Text = "Sitting: ", HorizontalOptions = LayoutOptions.StartAndExpand, YAlign = TextAlignment.Center };
//			var pickerSitting = new Picker{Title = "Select Rating", Items = { "Normal",
//					"Good", "Fair","Poor" },
//				VerticalOptions = LayoutOptions.Start,
//				HorizontalOptions = LayoutOptions.FillAndExpand};

//			var lblStanding = new Label{FontSize = 18, Text = "Standing: ", HorizontalOptions = LayoutOptions.StartAndExpand, YAlign = TextAlignment.Center  };
//			var pickerStanding = new Picker{Title = "Select Rating", Items = { "Normal",
//					"Good", "Fair","Poor" },
//				VerticalOptions = LayoutOptions.Start,
//				HorizontalOptions = LayoutOptions.FillAndExpand};


			var txtFindings = new EntryCell { Placeholder = "Findings"};
			var txtSignificance = new EntryCell { Placeholder = "Significance"};


			var SittingBalTol = new BalTolCell ();
			var StandingBalTol = new BalTolCell (){};

			SittingBalTol.picker .SelectedIndexChanged += delegate {

				switch (SittingBalTol.picker.SelectedIndex)
				{
				case 0:
					SittingBalTol.lblBalance.Text  = "Can assume, maintain, weight shift, and challenge.";
					SittingBalTol.lblTolerance.Text  ="45-60 min";
					break;
				case 1:
					SittingBalTol.lblBalance.Text  = "Can assume, maintain, and weight shift.";
					SittingBalTol.lblTolerance.Text  ="30-45 min";
					break;
				case 2:
					SittingBalTol.lblBalance.Text  = "Can assume, and maintain.";
					SittingBalTol.lblTolerance.Text  ="15-30 min";
					break;

				case 3:
					SittingBalTol.lblBalance.Text  = "Can assume.";
					SittingBalTol.lblTolerance.Text  =">15 min";

					break;

				default:
					SittingBalTol.lblBalance.Text  = "";
					SittingBalTol.lblTolerance.Text  ="";	
					break;
				}


			};

			StandingBalTol.picker .SelectedIndexChanged += delegate {

				switch (StandingBalTol.picker.SelectedIndex)
				{
				case 0:
					StandingBalTol.lblBalance.Text  = "Can assume, maintain, weight shift, and challenge.";
					StandingBalTol.lblTolerance.Text  ="45-60 min";
					break;
				case 1:
					StandingBalTol.lblBalance.Text  = "Can assume, maintain, and weight shift.";
					StandingBalTol.lblTolerance.Text  ="30-45 min";
					break;
				case 2:
					StandingBalTol.lblBalance.Text  = "Can assume, and maintain.";
					StandingBalTol.lblTolerance.Text  ="15-30 min";
					break;

				case 3:
					StandingBalTol.lblBalance.Text  = "Can assume.";
					StandingBalTol.lblTolerance.Text  =">15 min";

					break;

				default:
					StandingBalTol.lblBalance.Text  = "";
					StandingBalTol.lblTolerance.Text  ="";	
					break;
				}


			};

			SittingBalTol.lblBalance.SetBinding  (Label .TextProperty, "BalanceTolerance.SittingBalance", BindingMode.TwoWay);
			SittingBalTol.lblTolerance.SetBinding  (Label .TextProperty, "BalanceTolerance.SittingTolerance", BindingMode.TwoWay);

			StandingBalTol.lblBalance.SetBinding  (Label .TextProperty, "BalanceTolerance.StandingBalance", BindingMode.TwoWay);
			StandingBalTol.lblTolerance.SetBinding  (Label .TextProperty, "BalanceTolerance.StandingTolerance", BindingMode.TwoWay);

			txtFindings.SetBinding (EntryCell .TextProperty, "BalanceTolerance.Findings", BindingMode.TwoWay);
			txtSignificance.SetBinding (EntryCell .TextProperty, "BalanceTolerance.Significance", BindingMode.TwoWay);

			return new TableView (){
				Intent = TableIntent .Form,
				HasUnevenRows = true ,
				Root = new TableRoot  (){
					new TableSection ("BALANCE AND TOLERANCE"){
						new ViewCell {View = new Label{FontSize=15, Text = "Sitting", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						SittingBalTol,
						new ViewCell {View = new Label{FontSize=15, Text = "Standing", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						StandingBalTol,
						txtFindings,
						txtSignificance
					}
				}

			};
					
		}

		public class BalTolCell : ViewCell
		{

			public Picker picker = new Picker{Title = "Select Rating", Items = { "Normal",
					"Good", "Fair","Poor" },
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.FillAndExpand};


			public Label lblBalance = new Label{FontSize = 14, Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center  };
			public Label lblB = new Label{FontSize = 16, Text = "Balance: ", VerticalOptions = LayoutOptions .Center , HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center  };

			public Label lblTolerance = new Label{FontSize = 16, Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center };
			public Label lblT = new Label{FontSize = 14, Text = "Tolerance: ", VerticalOptions = LayoutOptions .Center , HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center };


			public BalTolCell(){
				Height = 150;
				View = new StackLayout {
					Orientation = StackOrientation.Vertical,
					Children = {
						new StackLayout () {
							Orientation = StackOrientation.Horizontal ,
							Padding = new Thickness(0,0,0,0),
							Children = { picker }},

						new StackLayout () {
							Padding = new Thickness(0,0,0,0),
							Orientation = StackOrientation.Vertical ,
							Children = {lblB, lblBalance }},

						new StackLayout () {
							Orientation = StackOrientation.Vertical ,
							Padding = new Thickness(0,0,0,0),
							Children = {lblT, lblTolerance }}
	
					}
				};
			}
		}







	}
}


