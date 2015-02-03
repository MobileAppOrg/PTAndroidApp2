using System;

using Xamarin.Forms;
using PTAndroidApp.ValueConverters;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class PosteriorViewPage : ContentPage
	{
		public PosteriorViewPage ()
		{
			var tblLayout = CreateTable ();

			Content = tblLayout;
		}

		static TableView CreateTable(){
			var lblHeadInMidline = new Label { Text="Head in midline:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var HeadInMidline = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var HeadInMidlineFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			HeadInMidline.SetBinding (Picker.SelectedIndexProperty, "PosteriorView.HeadInMidline",BindingMode.TwoWay, new IndexToBoolConverter());
			HeadInMidlineFindings.SetBinding (Entry.TextProperty,"PosteriorView.HeadInMidlineFindings");

			var lblShouldersInLevel = new Label { Text="Shoulders are at the same level:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var ShouldersInLevel = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var ShouldersInLevelFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			ShouldersInLevel.SetBinding (Picker.SelectedIndexProperty, "PosteriorView.ShouldersInLevel",BindingMode.TwoWay, new IndexToBoolConverter());
			ShouldersInLevelFindings.SetBinding (Entry.TextProperty,"PosteriorView.ShouldersInLevelFindings");

			var lblSpineScapularLevel = new Label { Text="Spine and Scapular Level:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var SpineScapularLevel = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var SpineScapularLevelFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			SpineScapularLevel.SetBinding (Picker.SelectedIndexProperty, "PosteriorView.SpineScapularLevel",BindingMode.TwoWay, new IndexToBoolConverter());
			SpineScapularLevelFindings.SetBinding (Entry.TextProperty,"PosteriorView.SpineScapularLevelFindings");

			var lblSpineInMidline = new Label { Text="Spine in midline:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var SpineInMidline = new Picker { Items = {"-","+"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			var SpineInMidlineFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			SpineInMidline.SetBinding (Picker.SelectedIndexProperty, "PosteriorView.SpineInMidline",BindingMode.TwoWay, new IndexToBoolConverter());
			SpineInMidlineFindings.SetBinding (Entry.TextProperty,"PosteriorView.SpineInMidlineFindings");

			var lblWaistLevelAngle= new Label { Text="Waist level angle (°):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var WaistLevelAngle = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			WaistLevelAngle.SetBinding (Entry.TextProperty,"PosteriorView.WaistLevelAngle", BindingMode.TwoWay, new StringToDecimal());

			var lblArmPosition = new Label { Text="Arm position (rotation):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var ArmPosition = new Picker { Items = { "Medially","Laterally","Neutral"}, HorizontalOptions = LayoutOptions.FillAndExpand };
			ArmPosition.SetBinding (Picker.SelectedIndexProperty, "PosteriorView.ArmPosition",BindingMode.TwoWay, new IndexToGenericListConverter(){ItemList = new List<string>(){ "Medially","Laterally","Neutral"}});

			var lblIliacCrestlevel = new Label { Text="Iliac Crest level:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var IliacCrestlevel = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			IliacCrestlevel.SetBinding (Entry.TextProperty,"PosteriorView.IliacCrestlevel");

			var lblPSISLevel = new Label { Text="PSIS Level:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var PSISLevel = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			PSISLevel.SetBinding (Entry.TextProperty,"PosteriorView.PSISLevel");

			var lblGlutealFoldsLevel = new Label { Text="Gluteal Folds Level:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var GlutealFoldsLevel = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			GlutealFoldsLevel.SetBinding (Entry.TextProperty,"PosteriorView.GlutealFoldsLevel");

			var lblPoplitealFoassalevel = new Label { Text="Popliteal Foassa Level:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var PoplitealFoassalevel = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			PoplitealFoassalevel.SetBinding (Entry.TextProperty,"PosteriorView.PoplitealFoassalevel");

			var lblHeelsPosition = new Label { Text="Heels position:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var HeelsPosition = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			HeelsPosition.SetBinding (Entry.TextProperty,"PosteriorView.HeelsPosition");

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection("Posterior View"){
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
								Children = { lblSpineScapularLevel, SpineScapularLevel }
							} 
						},
						new ViewCell { View = SpineScapularLevelFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblSpineInMidline, SpineInMidline }
							} 
						},
						new ViewCell { View = SpineInMidlineFindings },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblWaistLevelAngle, WaistLevelAngle }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblArmPosition, ArmPosition }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblIliacCrestlevel, IliacCrestlevel }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblPSISLevel, PSISLevel }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblGlutealFoldsLevel, GlutealFoldsLevel }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblPoplitealFoassalevel, PoplitealFoassalevel }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblHeelsPosition, HeelsPosition }
							} 
						}
					}
				}
			};
		}
	}
}


