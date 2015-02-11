using System;

using Xamarin.Forms;
using PTAndroidApp.ValueConverters;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class CardioPulmonaryPage : ContentPage
	{
		public CardioPulmonaryPage ()
		{
			var tblLayout = CreateTable ();

			Content = tblLayout;
		}

		static TableView CreateTable()
		{
			var lblBodyType = new Label { Text="Body Type:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var BodyType = new Picker { Items = { "Ectomorph","Mesomorph","Endomorph" }, HorizontalOptions = LayoutOptions.FillAndExpand };
			BodyType.SetBinding (Picker.SelectedIndexProperty, "CardioPulmonaryAssmt.BodyType",BindingMode.TwoWay, 
				new IndexToGenericListConverter { ItemList = new List<string>() { "Ectomorph","Mesomorph","Endomorph" }});

			var lblChestShape = new Label { Text="Chest Shape:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var ChestShape = new Picker { Items = {"Normal","Pectus carinatum","Pectus excavatum","Barrel chest","Others"}, 
				HorizontalOptions = LayoutOptions.FillAndExpand };
			var ChestShapeOthers = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Placeholder="Others" };
			ChestShape.SetBinding (Picker.SelectedIndexProperty, "CardioPulmonaryAssmt.ChestShape",BindingMode.TwoWay, 
				new IndexToGenericListConverter { ItemList = new List<string> {"Normal","Pectus carinatum","Pectus excavatum","Barrel chest","Others"}});
			ChestShapeOthers.SetBinding (Entry.TextProperty,"CardioPulmonaryAssmt.ChestShapeOthers");

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("Cardiopulmonary Assessment"){ 
						new ViewCell {
							View = new StackLayout {
								Orientation = StackOrientation.Horizontal,
								Children = { lblBodyType, BodyType }
							}
						},
						new ViewCell{
							View = new StackLayout {
								Orientation = StackOrientation.Horizontal,
								Children = { lblChestShape, ChestShape }
							}
						},
						new ViewCell { View = ChestShapeOthers }
					}
				}
			};
		}
	}
}


