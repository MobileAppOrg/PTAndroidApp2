using System;

using Xamarin.Forms;
using XLabs.Forms.Controls;
using PTAndroidApp.ValueConverters;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class PulmonaryAssmt5 : ContentPage
	{
		public PulmonaryAssmt5 ()
		{
			var tblLayout = CreateTable ();

			Content = tblLayout;
		}

		static TableView CreateTable()
		{
			//var lblPercussion = new Label { Text="Body Type:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var Percussion = new Picker { HorizontalOptions = LayoutOptions.FillAndExpand, Title = "Select...",
				Items = { "Normal note","Dull note","Flat note","Tympanic note","Hypersonant note", "Others" } };
			var PercussionOthers = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Others" };
			Percussion.SetBinding (Picker.SelectedIndexProperty, "PulmonaryAssmt.Percussion",BindingMode.TwoWay, 
				new IndexToGenericListConverter { ItemList = new List<string>(){ "Normal note","Dull note","Flat note","Tympanic note","Hypersonant note","Others"}});
			PercussionOthers.SetBinding (Entry.TextProperty,"PulmonaryAssmt.PercussionOthers");

			var lblTrachael = new Label { Text="Trachael", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var Trachael = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			Trachael.SetBinding (CheckBox.CheckedProperty, "Auscultation.Trachael");

			var lblBronchial = new Label { Text="Bronchial", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var Bronchial = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			Bronchial.SetBinding (CheckBox.CheckedProperty, "Auscultation.Bronchial");

			var lblBronchiovesicular = new Label { Text="Bronchiovesicular", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var Bronchiovesicular = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			Bronchiovesicular.SetBinding (CheckBox.CheckedProperty, "Auscultation.Bronchiovesicular");

			var lblVesicular = new Label { Text="Vesicular", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var Vesicular = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			Vesicular.SetBinding (CheckBox.CheckedProperty, "Auscultation.Vesicular");

			var lblCrackles = new Label { Text="Crackles", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var Crackles = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			Crackles.SetBinding (CheckBox.CheckedProperty, "Auscultation.Crackles");

			var lblDiminishedBreathSounds = new Label { Text="Diminished Breath Sounds", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var DiminishedBreathSounds = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			DiminishedBreathSounds.SetBinding (CheckBox.CheckedProperty, "Auscultation.DiminishedBreathSounds");

			var lblHighPitchedBronchialBreathing = new Label { Text="High Pitched Bronchial Breathing", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var HighPitchedBronchialBreathing = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			HighPitchedBronchialBreathing.SetBinding (CheckBox.CheckedProperty, "Auscultation.HighPitchedBronchialBreathing");

			var lblLowPitchedBronchialBreathing = new Label { Text="Low Pitched Bronchial Breathing", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var LowPitchedBronchialBreathing = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			LowPitchedBronchialBreathing.SetBinding (CheckBox.CheckedProperty, "Auscultation.LowPitchedBronchialBreathing");

			var lblPleuralRub = new Label { Text="PleuralRub", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var PleuralRub = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			PleuralRub.SetBinding (CheckBox.CheckedProperty, "Auscultation.PleuralRub");

			var lblRhonchi = new Label { Text="Rhonchi", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var Rhonchi = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			Rhonchi.SetBinding (CheckBox.CheckedProperty, "Auscultation.Rhonchi");

			var lblStridor = new Label { Text="Stridor", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var Stridor = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			Stridor.SetBinding (CheckBox.CheckedProperty, "Auscultation.Stridor");

			var lblWheeze = new Label { Text="Wheeze", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var Wheeze = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			Wheeze.SetBinding (CheckBox.CheckedProperty, "Auscultation.Wheeze");

			var lblOthers = new Label { Text="Others", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var Others = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			Others.SetBinding (CheckBox.CheckedProperty, "Auscultation.Others");

			var OthersText = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Others" };
			OthersText.SetBinding (Entry.TextProperty, "Auscultation.OthersText");

			var lblSixMinWalk = new Label { Text="Six Minute Walk Test", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var SixMinWalk = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			SixMinWalk.SetBinding (CheckBox.CheckedProperty, "PulmonaryAssmt.SixMinWalk");

			var SixMinWalkFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Findings" };
			SixMinWalkFindings.SetBinding (Entry.TextProperty, "PulmonaryAssmt.SixMinWalkFindings");

			var lblStairClimbing = new Label { Text="Stair Climbing", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var StairClimbing = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			StairClimbing.SetBinding (CheckBox.CheckedProperty, "PulmonaryAssmt.StairClimbing");

			var StairClimbingFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Findings" };
			StairClimbingFindings.SetBinding (Entry.TextProperty, "PulmonaryAssmt.StairClimbingFindings");

			var lblShuttleTest = new Label { Text="Shuttle Test", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var ShuttleTest = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			ShuttleTest.SetBinding (CheckBox.CheckedProperty, "PulmonaryAssmt.ShuttleTest");

			var ShuttleTestFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Findings" };
			ShuttleTestFindings.SetBinding (Entry.TextProperty, "PulmonaryAssmt.ShuttleTestFindings");

			var lblOtherTest = new Label { Text="Other Test", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var OtherTest = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			OtherTest.SetBinding (CheckBox.CheckedProperty, "PulmonaryAssmt.OtherTest");

			var OtherTestFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Findings" };
			OtherTestFindings.SetBinding (Entry.TextProperty, "PulmonaryAssmt.OtherTestFindings");

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("Pulmonary Assessment - Part 5"){ 
						new ViewCell {
							View = new Label { Text = "PERCUSSION (Lung Density)", FontAttributes = FontAttributes.Bold, 
								HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }
						},
						new ViewCell{ View = Percussion },
						new ViewCell { View = PercussionOthers },
						new ViewCell {
							View = new Label { Text = "AUSCULTATION/BREATHING SOUND", FontAttributes = FontAttributes.Bold, 
								HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { Trachael, lblTrachael }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { Bronchial, lblBronchial }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { Bronchiovesicular, lblBronchiovesicular }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { Vesicular, lblVesicular }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { Crackles, lblCrackles }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { DiminishedBreathSounds, lblDiminishedBreathSounds }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { HighPitchedBronchialBreathing, lblHighPitchedBronchialBreathing }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { LowPitchedBronchialBreathing, lblLowPitchedBronchialBreathing }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { PleuralRub, lblPleuralRub }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { Rhonchi, lblRhonchi }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { Stridor, lblStridor }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { Wheeze, lblWheeze }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { Others, lblOthers }
							} 
						},
						new ViewCell { View = OthersText },
						new ViewCell {
							View = new Label { Text = "EXERCISE TESTING", FontAttributes = FontAttributes.Bold, 
								HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { SixMinWalk, lblSixMinWalk }
							} 
						},
						new ViewCell { View = SixMinWalkFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { StairClimbing, lblStairClimbing }
							} 
						},
						new ViewCell { View = StairClimbingFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { ShuttleTest, lblShuttleTest }
							} 
						},
						new ViewCell { View = ShuttleTestFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { OtherTest, lblOtherTest }
							} 
						},
						new ViewCell { View = OtherTestFindings }
					}
				}
			};
		}
	}
}


