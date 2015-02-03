using System;

using Xamarin.Forms;
using PTAndroidApp.ValueConverters;

namespace PTAndroidApp
{
	public class LateralViewPage : ContentPage
	{
		public LateralViewPage ()
		{
			var tblLayout = CreateTable ();

			Content = tblLayout;
		}

		static TableView CreateTable(){
			var lblEarlobeShoulderAlignment = new Label { Text="Earlobe and tip of shoulder alignment:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var EarlobeShoulderAlignment = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var EarlobeShoulderAlignmentFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			EarlobeShoulderAlignment.SetBinding (Picker.SelectedIndexProperty, "LateralView.EarlobeShoulderAlignment",BindingMode.TwoWay, new IndexToBoolConverter());
			EarlobeShoulderAlignmentFindings.SetBinding (Entry.TextProperty,"LateralView.EarlobeShoulderAlignmentFindings");

			var lblAcromioIliacAlignment = new Label { Text="Acromion process and high point of Iliac Crest alignment:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var AcromioIliacAlignment = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var AcromioIliacAlignmentFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			AcromioIliacAlignment.SetBinding (Picker.SelectedIndexProperty, "LateralView.AcromioIliacAlignment",BindingMode.TwoWay, new IndexToBoolConverter());
			AcromioIliacAlignmentFindings.SetBinding (Entry.TextProperty,"LateralView.AcromioIliacAlignmentFindings");

			var lblSpinalSegments = new Label { Text="Spinal segments:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var SpinalSegments = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			SpinalSegments.SetBinding (Entry.TextProperty,"LateralView.SpinalSegments");

			var lblShoulderAlignment = new Label { Text="Shoulder Alignment:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var ShoulderAlignment = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			ShoulderAlignment.SetBinding (Entry.TextProperty,"LateralView.ShoulderAlignment");

			var lblPelvicAngle = new Label { Text="Pelvic Angle (°):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var PelvicAngle = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			PelvicAngle.SetBinding (Entry.TextProperty,"LateralView.PelvicAngle", BindingMode.TwoWay, new StringToDecimal());

			var lblKneeAlignment = new Label { Text="Knee Alignment:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var KneeAlignment = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			KneeAlignment.SetBinding (Entry.TextProperty,"LateralView.KneeAlignment");

			var lblPlumblineAlignment = new Label { Text="Plumbline alignment to Lateral malleolus:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var PlumblineAlignment = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var PlumblineAlignmentFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			PlumblineAlignment.SetBinding (Picker.SelectedIndexProperty, "LateralView.PlumblineAlignment",BindingMode.TwoWay, new IndexToBoolConverter());
			PlumblineAlignmentFindings.SetBinding (Entry.TextProperty,"LateralView.PlumblineAlignmentFindings");

			var lblArchesOfFeet = new Label { Text="Arch of the foot:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var ArchesOfFeet = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			ArchesOfFeet.SetBinding (Entry.TextProperty,"LateralView.ArchesOfFeet");

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection("Lateral View"){
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblEarlobeShoulderAlignment, EarlobeShoulderAlignment }
							} 
						},
						new ViewCell { View = EarlobeShoulderAlignmentFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblAcromioIliacAlignment, AcromioIliacAlignment }
							} 
						},
						new ViewCell { View = AcromioIliacAlignmentFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblSpinalSegments, SpinalSegments }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblShoulderAlignment, ShoulderAlignment }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblPelvicAngle, PelvicAngle }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblKneeAlignment, KneeAlignment }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblPlumblineAlignment, PlumblineAlignment }
							} 
						},
						new ViewCell { View = PlumblineAlignmentFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblArchesOfFeet, ArchesOfFeet }
							} 
						}
					}
				}
			};
		}
	}
}


