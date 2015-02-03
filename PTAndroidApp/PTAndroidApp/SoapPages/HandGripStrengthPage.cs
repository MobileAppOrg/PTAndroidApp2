using System;

using Xamarin.Forms;
using PTAndroidApp.ValueConverters;

namespace PTAndroidApp
{
	public class HandGripStrengthPage : ContentPage
	{
		public HandGripStrengthPage ()
		{

			var form =  CreateTable();

			Content = new StackLayout { 
				Children = {
					form 
				}
			};
		}


		public TableView CreateTable(){

			var patientVisitIdLabel = new Label { IsVisible = false };
			patientVisitIdLabel.SetBinding (Label.TextProperty, "PatientVisitId");


			var Trial1 = new	HGSCell ();
			var Trial2 = new	HGSCell ();
			var Trial3 = new	HGSCell ();
			var Average = new	HGSCell ();
			var Findings = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };
			var Significance = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };


			ViewCell Trial1Cell = new ViewCell {
				View = new StackLayout () {
					BackgroundColor = Color.Silver ,
					Children = {patientVisitIdLabel,
						new Label (){YAlign = TextAlignment .Center , HorizontalOptions = LayoutOptions .StartAndExpand, Text = "Trial 1"},
						}}};
			ViewCell Trial2Cell = new ViewCell {
				View = new StackLayout () {
					BackgroundColor = Color.Silver ,
					Children = {
						new Label (){YAlign = TextAlignment .Center , HorizontalOptions = LayoutOptions .StartAndExpand, Text = "Trial 2"},
					}}};
			ViewCell Trial3Cell = new ViewCell {
				View = new StackLayout () {
					BackgroundColor = Color.Silver ,
					Children = {
						new Label (){YAlign = TextAlignment .Center , HorizontalOptions = LayoutOptions .StartAndExpand, Text = "Trial 3"},
					}}};
			ViewCell AvgCell = new ViewCell {
				View = new StackLayout () {
					BackgroundColor = Color.Silver ,
					Children = {
						new Label (){YAlign = TextAlignment .Center , HorizontalOptions = LayoutOptions .StartAndExpand, Text = "Average"},
					}}};

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

			Trial1.txtRightHand.SetBinding(Entry.TextProperty, "HandGripStrength.T1RightHand", BindingMode .TwoWay ,  new StringToDecimal());
			Trial1.txtLefttHand.SetBinding(Entry.TextProperty,  "HandGripStrength.T1LeftHand", BindingMode .TwoWay ,  new StringToDecimal());

			Trial2.txtRightHand.SetBinding(Entry.TextProperty,  "HandGripStrength.T2RightHand", BindingMode .TwoWay ,  new StringToDecimal());
			Trial2.txtLefttHand.SetBinding(Entry.TextProperty,  "HandGripStrength.T2LeftHand", BindingMode .TwoWay ,  new StringToDecimal());

			Trial3.txtRightHand.SetBinding(Entry.TextProperty,  "HandGripStrength.T3RightHand", BindingMode .TwoWay ,  new StringToDecimal());
			Trial3.txtLefttHand.SetBinding(Entry.TextProperty, "HandGripStrength.T3LeftHand", BindingMode .TwoWay ,  new StringToDecimal());

			Average.txtRightHand.SetBinding(Entry.TextProperty,  "HandGripStrength.AveRightHand", BindingMode .TwoWay ,  new StringToDecimal());
			Average.txtLefttHand.SetBinding(Entry.TextProperty,  "HandGripStrength.AveLeftHand", BindingMode .TwoWay ,  new StringToDecimal());

			Findings.SetBinding (Editor.TextProperty, "HandGripStrength.Findings", BindingMode.TwoWay);
			Significance.SetBinding (Editor.TextProperty, "HandGripStrength.Significance", BindingMode.TwoWay);


			return new TableView()
			{
				BackgroundColor = Color.Transparent ,
				HasUnevenRows = true,
				Intent = TableIntent.Form ,
				Root =  new TableRoot (){
					new TableSection ("Hand Grip Strength ")
					{
						Trial1Cell,
						Trial1,
						Trial2Cell,
						Trial2,
						Trial3Cell,
						Trial3,
						AvgCell,
						Average,
						FindingsCell,
						SignificanceCell

					}


				}
			};

		}



		public class HGSCell : ViewCell
		{
			public Entry txtRightHand = new Entry { Placeholder = "(kg)", Keyboard = Keyboard.Numeric  };
			public Entry txtLefttHand = new Entry  { Placeholder = "(kg)", Keyboard = Keyboard.Numeric  };



			public HGSCell(){

				View=	new StackLayout () {
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions= LayoutOptions .Fill ,
					Padding = new Thickness(0,0,0,0),
				Children = { 
						new Label (){FontSize = 16,VerticalOptions = LayoutOptions .End ,  HorizontalOptions = LayoutOptions .StartAndExpand, Text = "Right Hand:"},

						txtRightHand ,
						new Label (){FontSize = 16,VerticalOptions = LayoutOptions .End , HorizontalOptions = LayoutOptions .StartAndExpand, Text = "Left Hand:"},

						txtLefttHand}


				};


			}
		}










	}
}


