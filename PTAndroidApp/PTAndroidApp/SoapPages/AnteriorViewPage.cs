using System;

using Xamarin.Forms;
using PTAndroidApp.ValueConverters;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class AnteriorViewPage : ContentPage
	{
		public AnteriorViewPage ()
		{
			var tblLayout = CreateTable ();

			Content = tblLayout;
		}

		static TableView CreateTable(){
			var lblHeadInMidline = new Label { Text="Head in midline:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var HeadInMidline = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var HeadInMidlineFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			HeadInMidline.SetBinding (Picker.SelectedIndexProperty, "AnteriorView.HeadInMidline",BindingMode.TwoWay, new IndexToBoolConverter());
			HeadInMidlineFindings.SetBinding (Entry.TextProperty,"AnteriorView.HeadInMidlineFindings");

			var lblShouldersInLevel = new Label { Text="Shoulders in level:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var ShouldersInLevel = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var ShouldersInLevelFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			ShouldersInLevel.SetBinding (Picker.SelectedIndexProperty, "AnteriorView.ShouldersInLevel",BindingMode.TwoWay, new IndexToBoolConverter());
			ShouldersInLevelFindings.SetBinding (Entry.TextProperty,"AnteriorView.ShouldersInLevelFindings");

			var lblProtrusion = new Label { Text="Protrusion of the sternum, ribs and costocartilage:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var Protrusion = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var ProtrusionFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			Protrusion.SetBinding (Picker.SelectedIndexProperty, "AnteriorView.Protrusion",BindingMode.TwoWay, new IndexToBoolConverter());
			ProtrusionFindings.SetBinding (Entry.TextProperty,"AnteriorView.ProtrusionFindings");

			var lblLateralization = new Label { Text="Lateralization of the sternum, ribs and costocartilage:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var Lateralization = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var LateralizationFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			Lateralization.SetBinding (Picker.SelectedIndexProperty, "AnteriorView.Lateralization",BindingMode.TwoWay, new IndexToBoolConverter());
			LateralizationFindings.SetBinding (Entry.TextProperty,"AnteriorView.LateralizationFindings");

			var lblDepression = new Label { Text="Depression of the sternum, ribs and costocartilage:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var Depression = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var DepressionFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			Depression.SetBinding (Picker.SelectedIndexProperty, "AnteriorView.Depression",BindingMode.TwoWay, new IndexToBoolConverter());
			DepressionFindings.SetBinding (Entry.TextProperty,"AnteriorView.DepressionFindings");

			var lblWaistAngle= new Label { Text="Waist angle (°):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var WaistAngle = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			WaistAngle.SetBinding (Entry.TextProperty,"AnteriorView.WaistAngle", BindingMode.TwoWay, new StringToDecimal());

			var lblArmPosition = new Label { Text="Arm position (rotation):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var ArmPosition = new Picker { Items = { "Medially","Laterally","Neutral"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			ArmPosition.SetBinding (Picker.SelectedIndexProperty, "AnteriorView.ArmPosition",BindingMode.TwoWay, new IndexToGenericListConverter(){ItemList = new List<string>(){ "Medially","Laterally","Neutral"}});

			var lblCarryingAngle = new Label { Text="Carrying angle (°):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var CarryingAngle = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			CarryingAngle.SetBinding (Entry.TextProperty,"AnteriorView.CarryingAngle", BindingMode.TwoWay, new StringToDecimal());
			 
			var lblASISLevel = new Label { Text="ASIS Level:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var ASISLevel = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			ASISLevel.SetBinding (Entry.TextProperty,"AnteriorView.ASISLevel");

			var lblPatellaeAlignment = new Label { Text="Patellae Alignment:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var PatellaeAlignment = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			PatellaeAlignment.SetBinding (Entry.TextProperty,"AnteriorView.PatellaeAlignment");

			var lblKneeAlignment = new Label { Text="Knee Alignment:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var KneeAlignment = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			KneeAlignment.SetBinding (Entry.TextProperty,"AnteriorView.KneeAlignment");

			var lblMalleoliLevel = new Label { Text="Malleoli Level:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var MalleoliLevel = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			MalleoliLevel.SetBinding (Entry.TextProperty,"AnteriorView.MalleoliLevel");

			var lblArchesOfFeet = new Label { Text="Arches of the Feet:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var ArchesOfFeet = new Picker { Items = { "(+/-)  MEDIAL LONGITUDINAL ARCH", "(+/-) LATERAL LONGITUDINAL ARCH","NONE" }, HorizontalOptions = LayoutOptions.FillAndExpand };
			ArchesOfFeet.SetBinding (Picker.SelectedIndexProperty, "AnteriorView.ArchesOfFeet",BindingMode.TwoWay, new IndexToGenericListConverter(){ItemList = new List<string>(){ "(+/-)  MEDIAL LONGITUDINAL ARCH", "(+/-) LATERAL LONGITUDINAL ARCH","NONE" }});

			var lblFeetAngle = new Label { Text="Feet angle out equally:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var FeetAngle = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var FeetAngleFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			FeetAngle.SetBinding (Picker.SelectedIndexProperty, "AnteriorView.FeetAngle",BindingMode.TwoWay, new IndexToBoolConverter());
			FeetAngleFindings.SetBinding (Entry.TextProperty,"AnteriorView.FeetAngleFindings");

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection("Anterior View"){
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblHeadInMidline, HeadInMidline }
							} 
						},
						new ViewCell { View = HeadInMidlineFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblShouldersInLevel, ShouldersInLevel }
							} 
						},
						new ViewCell { View = ShouldersInLevelFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblProtrusion, Protrusion }
							} 
						},
						new ViewCell { View = ProtrusionFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblLateralization, Lateralization }
							} 
						},
						new ViewCell { View = LateralizationFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblDepression, Depression }
							} 
						},
						new ViewCell { View = DepressionFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblWaistAngle, WaistAngle }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblArmPosition, ArmPosition }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblCarryingAngle, CarryingAngle }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblASISLevel, ASISLevel }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblPatellaeAlignment, PatellaeAlignment }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblKneeAlignment, KneeAlignment }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblMalleoliLevel, MalleoliLevel }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblArchesOfFeet, ArchesOfFeet }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblFeetAngle, FeetAngle }
							} 
						},
						new ViewCell { View = FeetAngleFindings },
					}
				}
			};

		}
	}
}


