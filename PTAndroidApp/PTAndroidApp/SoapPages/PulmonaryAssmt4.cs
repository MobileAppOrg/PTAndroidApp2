using System;

using Xamarin.Forms;

namespace PTAndroidApp
{
	public class PulmonaryAssmt4 : ContentPage
	{
		public PulmonaryAssmt4 ()
		{
			var tblLayout = CreateTable ();

			Content = tblLayout;
		}

		static TableView CreateTable()
		{
			var lblAxilla = new Label { Text="LANDMARK: LOWER COSTAL", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};

			var lblMaxInsT1 = new Label { Text="Trial1(cm):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var MaxInsT1 = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			MaxInsT1.SetBinding (Entry.TextProperty, "CMLowerCostal.MaxInsT1");

			var lblMaxInsT2 = new Label { Text="Trial2(cm):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var MaxInsT2 = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			MaxInsT2.SetBinding (Entry.TextProperty, "CMLowerCostal.MaxInsT2");

			var lblMaxInsT3 = new Label { Text="Trial3(cm):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var MaxInsT3 = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			MaxInsT3.SetBinding (Entry.TextProperty, "CMLowerCostal.MaxInsT3");

			var lblMaxInsAve = new Label { Text="Average (cm):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var MaxInsAve = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			MaxInsAve.SetBinding (Entry.TextProperty, "CMLowerCostal.MaxInsAve");

			var lblMaxExpT1 = new Label { Text="Trial1(cm):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var MaxExpT1 = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			MaxExpT1.SetBinding (Entry.TextProperty, "CMLowerCostal.MaxExpT1");

			var lblMaxExpT2 = new Label { Text="Trial2(cm):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var MaxExpT2 = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			MaxExpT2.SetBinding (Entry.TextProperty, "CMLowerCostal.MaxExpT2");

			var lblMaxExpT3 = new Label { Text="Trial3(cm):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var MaxExpT3 = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			MaxExpT3.SetBinding (Entry.TextProperty, "CMAxilla.MaxExpT3");

			var lblMaxExpAve = new Label { Text="Average (cm):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var MaxExpAve = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			MaxExpAve.SetBinding (Entry.TextProperty, "CMLowerCostal.MaxExpAve");

			var lblDiffT1 = new Label { Text="Trial1(cm):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var DiffT1 = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			DiffT1.SetBinding (Entry.TextProperty, "CMLowerCostal.DiffT1");

			var lblDiffT2 = new Label { Text="Trial2(cm):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var DiffT2 = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			DiffT2.SetBinding (Entry.TextProperty, "CMLowerCostal.DiffT2");

			var lblDiffT3 = new Label { Text="Trial3(cm):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var DiffT3 = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			DiffT3.SetBinding (Entry.TextProperty, "CMLowerCostal.DiffT3");

			var lblDiffAve = new Label { Text="Average (cm):", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var DiffAve = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
			DiffAve.SetBinding (Entry.TextProperty, "CMLowerCostal.DiffAve");

			var ChestMobilityFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Findings" };
			var ChestMobilitySignificance = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Significance" };
			ChestMobilityFindings.SetBinding (Entry.TextProperty, "ChestMobilityFindings");
			ChestMobilitySignificance.SetBinding (Entry.TextProperty, "ChestMobilitySignificance");

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("Pulmonary Assessment - Part 4") {
						new ViewCell {
							View = new Label { Text = "CHEST MOBILITY", FontAttributes = FontAttributes.Bold, 
								HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center
							}
						},
						new ViewCell { View = lblAxilla },
						new ViewCell { View = new Label { Text = "Maximum Inspiration", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center } },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblMaxInsT1, MaxInsT1, lblMaxInsT2, MaxInsT2, lblMaxInsT3, MaxInsT3 }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblMaxInsAve, MaxInsAve }
							} 
						},
						new ViewCell { View = new Label { Text = "Maximum Expiration", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center } },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblMaxExpT1, MaxExpT1, lblMaxExpT2, MaxExpT2, lblMaxExpT3, MaxExpT3 }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblMaxExpAve, MaxExpAve }
							} 
						},
						new ViewCell { View = new Label { Text = "Difference", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center } },
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblDiffT1, DiffT1, lblDiffT2, DiffT2, lblDiffT3, DiffT3 }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { lblDiffAve, DiffAve }
							} 
						},
						new ViewCell { View = new Label { Text = "Findings & Significance", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						new ViewCell { View = ChestMobilityFindings },
						new ViewCell { View = ChestMobilitySignificance }
					}
				}
			};
		}
	}
}


