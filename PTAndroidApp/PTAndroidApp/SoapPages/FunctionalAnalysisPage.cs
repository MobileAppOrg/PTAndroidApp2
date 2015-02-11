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
			var AdlsAxWriting = new CheckBox ();
			AdlsAxWriting.SetBinding (CheckBox.CheckedProperty, "FunctionalAnalysis.AdlsAxWriting");
			//AdlsAxWriting.IsChecked = true;

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("Lateral View"){
						new ViewCell { View = AdlsAxWriting }
					}
				}
			};
		}
	}
}


