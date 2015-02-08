﻿using System;

using Xamarin.Forms;

namespace PTAndroidApp
{
	public class CoordinationAssmtFinSigPage : ContentPage
	{
		public CoordinationAssmtFinSigPage ()
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

			Findings.SetBinding (Editor.TextProperty, "CoordinationAssmtFindings", BindingMode.TwoWay);
			Significance.SetBinding (Editor.TextProperty, "CoordinationAssmtSignificance", BindingMode.TwoWay);

			return new TableView ()
			{	HasUnevenRows = true,
				Intent = TableIntent.Form,
				Root =  new TableRoot ()
				{
					new TableSection ("Coordination Assessment Findings and Significance")
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

