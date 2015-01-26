using System;

using Xamarin.Forms;

namespace PTAndroidApp
{
		public class HPIpage : ContentPage
		{
			public HPIpage ()
			{

			TableView tblForm = CreateTable ();
				Content = new StackLayout{ 
					Children = { 
						tblForm
					}
				};
			}

		static TableView CreateTable(){

			var HPIentry = new Editor  { };
			var CellView = new ViewCell {
				View = new StackLayout {
						Children = { HPIentry }
					}
			};

			HPIentry.SetBinding (Editor.TextProperty, "HPI", BindingMode.TwoWay);
				return new TableView () {
				HasUnevenRows = true,
				Intent = TableIntent.Form , 
					Root = new TableRoot () {
					new TableSection ("HPI") {CellView}
				}
			};

		}

		
	}
}



	
	





