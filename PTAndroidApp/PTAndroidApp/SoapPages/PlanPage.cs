using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{


	public class PlanPage : ContentPage
	{


		public PlanPage ()
		{


			var form = CreateTable ();
			Content = new StackLayout { 
				Children = {
					form
				}
			};
		}



		public TableView CreateTable(){

			var patientVisitIdLabel = new Label { IsVisible = false };
			patientVisitIdLabel.SetBinding (Label.TextProperty, "PatientVisitId");



			var PTManagement = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };
			var HomeInstruction = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };


			PTManagement.SetBinding (Editor.TextProperty, "Plan.PTManagement", BindingMode.TwoWay);
			HomeInstruction.SetBinding (Editor.TextProperty, "Plan.HomeInstruction", BindingMode.TwoWay);




			var Cell = new ViewCell {
				View = new StackLayout () {
					Children = {
						new Label (){FontSize = 16,VerticalOptions = LayoutOptions .Start ,HorizontalOptions = LayoutOptions .Fill, Text = "PT Management:"},
						patientVisitIdLabel,	
						PTManagement,	
						new Label (){FontSize = 16,VerticalOptions = LayoutOptions .Start ,HorizontalOptions = LayoutOptions .Fill, Text = "Home Instruction:"},
						HomeInstruction,
					},
					Orientation = StackOrientation.Vertical
				}
			};



			return new TableView()
			{
				BackgroundColor = Color.Transparent ,
				HasUnevenRows = true,
				Intent = TableIntent.Form ,
				Root =  new TableRoot (){
					new TableSection ("Plan")
					{
						Cell
					}


				}
			};

		}

	}
}


