using System;

using Xamarin.Forms;

namespace PTAndroidApp
{
	public class PalpationPage : ContentPage
	{
		public PalpationPage ()
		{
			TableView  table = CreateTable ();
			Content = new StackLayout { 
				Children = {
					table
				}
			};
		}




		static TableView CreateTable () {




			return new TableView () {
				Intent = TableIntent.Form ,
				Root = new TableRoot (){
					new TableSection ("Ocular Inspection"){
					

					}

				}

			};
		}


	}
}


