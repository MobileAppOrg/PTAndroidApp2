using System;

using Xamarin.Forms;

namespace PTAndroidApp
{
	public class ROMFindSignPage : ContentPage
	{
		public ROMFindSignPage ()
		{

			TableView form = CreateTable();
			Content = new StackLayout { 
				Children = {
					form
				}

			};
		}


		static TableView CreateTable()
		{

			var Findings = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };
			var Significance = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };


			var FindingsCell = new ViewCell {
				//Height = 200,
				View = new StackLayout () {
					Children = { Findings },
					Orientation = StackOrientation.Horizontal
				}
			};

			var SignificanceCell = new ViewCell {
				//Height = 200,
				View = new StackLayout () {
					Children = { Significance },
					Orientation = StackOrientation.Horizontal
				}
			};

			Findings.SetBinding (Editor.TextProperty, "RomFindings", BindingMode.TwoWay);
			Significance.SetBinding (Editor.TextProperty, "RomSignificance", BindingMode.TwoWay);

			return new TableView ()
			{	HasUnevenRows = true,
				Intent = TableIntent.Form,
				Root =  new TableRoot ()
				{
					new TableSection ("ROM Findings and Significance")
					{
						new ViewCell {View = new Label{ Text = "Findings", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						FindingsCell,
						new ViewCell {View = new Label{ Text = "Significance", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						SignificanceCell
					}
				}
			};
		}
	}
}


