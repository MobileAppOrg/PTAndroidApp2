

using System;

using Xamarin.Forms;
using PTAndroidApp.ValueConverters;

namespace PTAndroidApp
{
	public class LandmarksPage : ContentPage
	{
		public LandmarksPage ()
		{
			var form = CreateTable ();
			Content = new StackLayout { 
				Children = {
					form
				}
			};
		}





		public TableView CreateTable(){

			var patientVisitIdLabel = new Label { IsVisible = false };
			patientVisitIdLabel.SetBinding (Label.TextProperty, "PatientVisitId");



			var VolMeasurement = new	LandmarksCell ();


			var Findings = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };
			var Significance = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };

			var FindingsCell = new ViewCell {
				//Height = 200,
				View = new StackLayout () {
					Children = {
						new Label (){FontSize = 16,VerticalOptions = LayoutOptions .Start ,HorizontalOptions = LayoutOptions .Fill, Text = "Findings:"},

						Findings },
					Orientation = StackOrientation.Horizontal
				}
			};


			var SignificanceCell = new ViewCell {
				//Height = 200,
				View = new StackLayout () {
					Children = {
						new Label (){FontSize = 16,VerticalOptions = LayoutOptions .Start ,HorizontalOptions = LayoutOptions .Fill, Text = "Significance:"},
						Significance },
					Orientation = StackOrientation.Horizontal
				}
			};

			VolMeasurement.txtRightHand.SetBinding(Entry.TextProperty,"FigureOfEight.Right", BindingMode .TwoWay , new StringToDecimal());
			VolMeasurement.txtLefttHand.SetBinding(Entry.TextProperty, "FigureOfEight.Left", BindingMode .TwoWay ,  new StringToDecimal());
			VolMeasurement.txtDifference.SetBinding(Entry.TextProperty, "FigureOfEight.Difference", BindingMode .TwoWay ,  new StringToDecimal());


			Findings.SetBinding (Editor.TextProperty, "FigureOfEight.Findings", BindingMode.TwoWay);
			Significance.SetBinding (Editor.TextProperty, "FigureOfEight.Significance", BindingMode.TwoWay);


			return new TableView()
			{
				BackgroundColor = Color.Transparent ,
				HasUnevenRows = true,
				Intent = TableIntent.Form ,
				Root =  new TableRoot (){
					new TableSection ("Figure of 8")
					{

						VolMeasurement,
						FindingsCell,
						SignificanceCell

					}


				}
			};

		}



		public class LandmarksCell : ViewCell
		{
			public Entry txtRightHand = new Entry {HorizontalOptions = LayoutOptions .FillAndExpand ,Placeholder = "(cm)", Keyboard = Keyboard.Numeric  };
			public Entry txtLefttHand = new Entry  {HorizontalOptions = LayoutOptions .FillAndExpand , Placeholder = "(cm)", Keyboard = Keyboard.Numeric  };
			public Entry txtDifference = new Entry  {HorizontalOptions = LayoutOptions .FillAndExpand , Placeholder = "(cm)", Keyboard = Keyboard.Numeric  };



			public LandmarksCell(){

				View=	new StackLayout () {

					Orientation = StackOrientation.Vertical,
					HorizontalOptions= LayoutOptions .Fill ,
					Padding = new Thickness(0,0,0,0),
					Children = { 
						new Label (){FontSize = 15,VerticalOptions = LayoutOptions .StartAndExpand , HorizontalOptions = LayoutOptions .CenterAndExpand, Text = "LANDMARKS\n•\tMidway of malleoli\n•\tCuboid\n•\t5cm proximal to 1st MTP head\n•\t3cm above lateral malleolus\n•\t2cm above medial malleolus\n"},

						new StackLayout () {
							Orientation = StackOrientation.Horizontal,
							HorizontalOptions= LayoutOptions .Fill ,
							Padding = new Thickness(0,0,0,0),
							Children = { 

								new Label (){FontSize = 15,VerticalOptions = LayoutOptions .End ,  HorizontalOptions = LayoutOptions .FillAndExpand, Text = "Right:"},

								txtRightHand,

								new Label (){FontSize = 15,VerticalOptions = LayoutOptions .End , HorizontalOptions = LayoutOptions .FillAndExpand, Text = "Left:"},
								txtLefttHand,

							}

						},
						new StackLayout () {
							Orientation = StackOrientation.Horizontal,
							HorizontalOptions= LayoutOptions .StartAndExpand ,
							Padding = new Thickness(0,0,0,0),
							Children = { 
								new Label (){FontSize = 15,VerticalOptions = LayoutOptions .End , HorizontalOptions = LayoutOptions .StartAndExpand, Text = "Difference:"},
								txtDifference

							}

						}


					}
				};


			}

		}
	}
}


