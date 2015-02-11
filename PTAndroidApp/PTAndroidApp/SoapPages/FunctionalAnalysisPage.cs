using System;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace PTAndroidApp
{
	public class FunctionalAnalysisPage : ContentPage
	{
		public FunctionalAnalysisPage ()
		{
			var tblLayout = CreateTable ();

			Content = tblLayout;
		}

		static TableView CreateTable()
		{
			var lblAdlsAxWriting = new Label { Text="Writing", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var AdlsAxWriting = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			AdlsAxWriting.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxWriting");

			var lblAdlsAxCleaningHouse = new Label { Text="Cleaning House", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var AdlsAxCleaningHouse = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			AdlsAxCleaningHouse.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxCleaningHouse");

			var lblAdlsAxCooking = new Label { Text="Cooking", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var AdlsAxCooking = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			AdlsAxCooking.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxCooking");

			var lblAdlsAxEating = new Label { Text="Eating", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var AdlsAxEating = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			AdlsAxEating.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxEating");

			var lblAdlsAxTurningDoorKnob = new Label { Text="Turning doorknobs", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var AdlsAxTurningDoorKnob = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			AdlsAxTurningDoorKnob.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxTurningDoorKnob");

			var lblAdlsAxUsingKeys = new Label { Text="Using keys", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var AdlsAxUsingKeys = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			AdlsAxUsingKeys.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxUsingKeys");

			var lblAdlsAxOpeningBottle = new Label { Text="Opening bottles or jars", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var AdlsAxOpeningBottle = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			AdlsAxOpeningBottle.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxOpeningBottle");

			var lblAdlsAxBrushingTeeth = new Label { Text="Brushing teeth", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var AdlsAxBrushingTeeth = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			AdlsAxBrushingTeeth.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxBrushingTeeth");

			var lblAdlsAxTyingShoeLace = new Label { Text="Tying shoe laces", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var AdlsAxTyingShoeLace = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			AdlsAxTyingShoeLace.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxTyingShoeLace");

			var lblAdlsAxWashingDishes = new Label { Text="Washing dishes", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var AdlsAxWashingDishes = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			AdlsAxWashingDishes.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxWashingDishes");

			var lblAdlsAxSweepingFloor = new Label { Text="Sweeping the floor", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var AdlsAxSweepingFloor = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			AdlsAxSweepingFloor.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxSweepingFloor");

			var lblAdlsAxOthers = new Label { Text="Others:", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var AdlsAxOthers = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			AdlsAxOthers.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxOthers");

			var AdlsAxOthersText = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Others" };
			AdlsAxOthersText.SetBinding (Entry.TextProperty, "FunctionalAnalysis.AdlsAxOthersText");

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("ADLs Ax"){
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { AdlsAxWriting, lblAdlsAxWriting }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { AdlsAxCleaningHouse, lblAdlsAxCleaningHouse }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { AdlsAxCooking, lblAdlsAxCooking }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { AdlsAxEating, lblAdlsAxEating }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { AdlsAxTurningDoorKnob, lblAdlsAxTurningDoorKnob }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { AdlsAxUsingKeys, lblAdlsAxUsingKeys }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { AdlsAxOpeningBottle, lblAdlsAxOpeningBottle }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { AdlsAxBrushingTeeth, lblAdlsAxBrushingTeeth }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { AdlsAxTyingShoeLace, lblAdlsAxTyingShoeLace }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { AdlsAxWashingDishes, lblAdlsAxWashingDishes }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { AdlsAxSweepingFloor, lblAdlsAxSweepingFloor }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { AdlsAxOthers, lblAdlsAxOthers }
							} 
						},
						new ViewCell { View = AdlsAxOthersText }
					}
				}
			};
		}
	}
}


