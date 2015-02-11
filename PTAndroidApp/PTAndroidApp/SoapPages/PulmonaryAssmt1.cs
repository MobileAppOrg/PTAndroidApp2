using System;

using Xamarin.Forms;
using PTAndroidApp.ValueConverters;
using System.Collections.Generic;
using XLabs.Forms.Controls;

namespace PTAndroidApp
{
	public class PulmonaryAssmt1 : ContentPage
	{
		public PulmonaryAssmt1 ()
		{
			var tblLayout = CreateTable ();

			Content = tblLayout;
		}

		static TableView CreateTable()
		{
			var lblSpmMucoid = new Label { Text="Mucoid", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var SpmMucoid = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			SpmMucoid.SetBinding (CheckBox.CheckedProperty, "PulmonaryAssmt.SpmMucoid");

			var lblSpmFrothy = new Label { Text="Frothy", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var SpmFrothy = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			SpmFrothy.SetBinding (CheckBox.CheckedProperty, "PulmonaryAssmt.SpmFrothy");

			var lblSpmMucopurulent = new Label { Text="Mucopurulent", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var SpmMucopurulent = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			SpmMucopurulent.SetBinding (CheckBox.CheckedProperty, "PulmonaryAssmt.SpmMucopurulent");

			var lblSpmHemoptysis = new Label { Text="Hemoptysis", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var SpmHemoptysis = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			SpmHemoptysis.SetBinding (CheckBox.CheckedProperty, "PulmonaryAssmt.SpmHemoptysis");

			var lblSpmPurulent = new Label { Text="Purulent", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var SpmPurulent = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			SpmPurulent.SetBinding (CheckBox.CheckedProperty, "PulmonaryAssmt.SpmPurulent");

			var lblSpmOthers = new Label { Text="Others", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var SpmOthers = new CheckBox { HorizontalOptions = LayoutOptions.Fill};
			SpmOthers.SetBinding (CheckBox.CheckedProperty, "PulmonaryAssmt.SpmOthers");

			var SpmOthersText = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Others" };

			//var lblMdShift = new Label { Text="MediastinalL Shift", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var MdShift = new Picker { Title = "Select...",
				Items = {"Normal","Abnormal"}, 
				HorizontalOptions = LayoutOptions.FillAndExpand };
			var MdShiftFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			var MdShiftSignificance = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Significance" };
			MdShift.SetBinding (Picker.SelectedIndexProperty, "PulmonaryAssmt.MdShift",BindingMode.TwoWay, 
				new IndexToGenericListConverter { ItemList = new List<string> {"Normal","Abnormal"}});
			MdShiftFindings.SetBinding (Entry.TextProperty,"PulmonaryAssmt.MdShiftFindings");
			MdShiftSignificance.SetBinding (Entry.TextProperty,"PulmonaryAssmt.MdShiftSignificance");

			var Fremitus = new Picker { Title = "Select...",
				Items = {"Normal","Increased","Decreased"}, 
				HorizontalOptions = LayoutOptions.FillAndExpand };
			var FremitusFindings = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Findings" };
			var FremitusSignificance = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Significance" };
			Fremitus.SetBinding (Picker.SelectedIndexProperty, "PulmonaryAssmt.Fremitus",BindingMode.TwoWay, 
				new IndexToGenericListConverter { ItemList = new List<string> {"Normal","Increased","Decreased"}});
			FremitusFindings.SetBinding (Entry.TextProperty,"PulmonaryAssmt.FremitusFindings");
			FremitusSignificance.SetBinding (Entry.TextProperty,"PulmonaryAssmt.FremitusSignificance");

			var lblChstExpULE = new Label { Text="Upper Lobe Expansion", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var ChstExpULE = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Findings"};
			ChstExpULE.SetBinding (Entry.TextProperty, "PulmonaryAssmt.ChstExpULE");

			var lblChstExpMLE = new Label { Text="Middle Lobe Expansion", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var ChstExpMLE = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Findings"};
			ChstExpMLE.SetBinding (Entry.TextProperty, "PulmonaryAssmt.ChstExpMLE");

			var lblChstExpLLE = new Label { Text="Lower Lobe Expansion", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center};
			var ChstExpLLE = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Findings"};
			ChstExpLLE.SetBinding (Entry.TextProperty, "PulmonaryAssmt.ChstExpLLE");

			var ChstExpSig = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder = "Significance"};
			ChstExpSig.SetBinding (Entry.TextProperty, "PulmonaryAssmt.ChstExpSig");

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("Pulmonary Assessment - Part 1") {
						new ViewCell {
							View = new Label { Text = "SPUTUM ANALYSIS", FontAttributes = FontAttributes.Bold, 
								HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { SpmMucoid, lblSpmMucoid }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { SpmFrothy, lblSpmFrothy }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { SpmMucopurulent, lblSpmMucopurulent }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { SpmHemoptysis, lblSpmHemoptysis }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { SpmPurulent, lblSpmPurulent }
							} 
						},
						new ViewCell { View = new StackLayout { 
								Orientation = StackOrientation.Horizontal,
								Children = { SpmOthers, lblSpmOthers }
							} 
						},
						new ViewCell { View = SpmOthersText },
						new ViewCell {
							View = new Label { Text = "MEDIASTINAL SHIFT", FontAttributes = FontAttributes.Bold, 
								HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }
						},
						new ViewCell { View = MdShift },
						new ViewCell { View = MdShiftFindings },
						new ViewCell { View = MdShiftSignificance },
						new ViewCell {
							View = new Label { Text = "FREMITUS", FontAttributes = FontAttributes.Bold, 
								HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }
						},
						new ViewCell { View = Fremitus },
						new ViewCell { View = FremitusFindings },
						new ViewCell { View = FremitusSignificance },
						new ViewCell {
							View = new Label { Text = "CHEST EXPANSION", FontAttributes = FontAttributes.Bold, 
								HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }
						},
						new ViewCell { View = lblChstExpULE },
						new ViewCell { View = ChstExpULE },
						new ViewCell { View = lblChstExpMLE },
						new ViewCell { View = ChstExpMLE },
						new ViewCell { View = lblChstExpLLE },
						new ViewCell { View = ChstExpLLE },
						new ViewCell { View = ChstExpSig }
					}
				}
			};
		}
	}
}


