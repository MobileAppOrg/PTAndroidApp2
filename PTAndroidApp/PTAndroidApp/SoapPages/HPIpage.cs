using System;

using Xamarin.Forms;

namespace PTAndroidApp
{
	public class HPIpage : ContentPage
	{
		public HPIpage ()
		{

	

			var HPIviews = HPIview ();

			Content = new StackLayout{ 
				Children = { 
					HPIviews
				}
			};
		


		 
		}



		public ScrollView  HPIview () 
		{
			var header = new Label { FontSize = 25, Text = "HPI", HorizontalOptions = LayoutOptions.CenterAndExpand };
			var HPIentry = new Editor  {VerticalOptions = LayoutOptions .FillAndExpand, 
				HorizontalOptions = LayoutOptions .FillAndExpand, };
			var HPIviews = new ScrollView {
				VerticalOptions = LayoutOptions.FillAndExpand ,
				Content = new StackLayout {
					Children = {header,HPIentry}
				}
			};

			return HPIviews;
		}
	}





}


