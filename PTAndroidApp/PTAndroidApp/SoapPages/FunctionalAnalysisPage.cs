using System;

using Xamarin.Forms;

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
			var AdlsAxWriting = new MyCheckBox{  };
			AdlsAxWriting.SetBinding (MyCheckBox.IsCheckedProperty, "FunctionalAnalysis.AdlsAxWriting", BindingMode.TwoWay);
			AdlsAxWriting.IsChecked = true;

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


