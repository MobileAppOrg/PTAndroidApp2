using System;

using Xamarin.Forms;
using PTAndroidApp.ValueConverters;

namespace PTAndroidApp
{
	public class VolMeasPage : ContentPage
	{
		public VolMeasPage ()
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


			var VolMeasurement = new	HGSCell ();


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

			VolMeasurement.txtRightHand.SetBinding(Entry.TextProperty,"VolumetricMeasurement.Right", BindingMode .TwoWay , new StringToDecimal());
			VolMeasurement.txtLefttHand.SetBinding(Entry.TextProperty, "VolumetricMeasurement.Left", BindingMode .TwoWay ,  new StringToDecimal());
			VolMeasurement.txtDifference.SetBinding(Entry.TextProperty, "VolumetricMeasurement.Difference", BindingMode .TwoWay ,  new StringToDecimal());


			Findings.SetBinding (Editor.TextProperty, "VolumetricMeasurement.Findings", BindingMode.TwoWay);
			Significance.SetBinding (Editor.TextProperty, "VolumetricMeasurement.Significance", BindingMode.TwoWay);


			return new TableView()
			{
				BackgroundColor = Color.Transparent ,
				HasUnevenRows = true,
				Intent = TableIntent.Form ,
				Root =  new TableRoot (){
					new TableSection ("Volumetric Measurement")
					{
					
						VolMeasurement,
						FindingsCell,
						SignificanceCell

					}


				}
			};

		}



		public class HGSCell : ViewCell
		{
			public Entry txtRightHand = new Entry {HorizontalOptions = LayoutOptions .FillAndExpand ,Placeholder = "(ml)", Keyboard = Keyboard.Numeric  };
			public Entry txtLefttHand = new Entry  {HorizontalOptions = LayoutOptions .FillAndExpand , Placeholder = "(ml)", Keyboard = Keyboard.Numeric  };
			public Entry txtDifference = new Entry  {HorizontalOptions = LayoutOptions .FillAndExpand , Placeholder = "(ml)", Keyboard = Keyboard.Numeric  };



			public HGSCell(){

				View=	new StackLayout () {

					Orientation = StackOrientation.Vertical,
					HorizontalOptions= LayoutOptions .Fill ,
					Padding = new Thickness(0,0,0,0),
					Children = { 
						 new StackLayout () {
							Orientation = StackOrientation.Horizontal,
							HorizontalOptions= LayoutOptions .Fill ,
							Padding = new Thickness(0,0,0,0),
							Children = { 
								new Label (){FontSize = 16,VerticalOptions = LayoutOptions .End ,  HorizontalOptions = LayoutOptions .FillAndExpand, Text = "(R) Dominant Hand:"},

								txtRightHand,

								new Label (){FontSize = 16,VerticalOptions = LayoutOptions .End , HorizontalOptions = LayoutOptions .FillAndExpand, Text = "(L) Non-Dominant Hand:"},
								txtLefttHand,

							}

						},


							new StackLayout () {
								Orientation = StackOrientation.Horizontal,
								HorizontalOptions= LayoutOptions .StartAndExpand ,
								Padding = new Thickness(0,0,0,0),
								Children = { 
									new Label (){FontSize = 16,VerticalOptions = LayoutOptions .End , HorizontalOptions = LayoutOptions .StartAndExpand, Text = "Difference:"},
									txtDifference

								}

							}


					}
				};


			}

		}
	}
}


