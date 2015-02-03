using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{


	public class AssessmentPage : ContentPage
	{


		public AssessmentPage ()
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


				
			var Diagnosis = new EntryCell   {Placeholder = "Diagnosis"  };
			var PTImpression = new EntryCell   {Placeholder = "PT Impression" };

			var ProblemList = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };
			var LongTermGoals = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };
			var ShortTermGoals = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };


			Diagnosis.SetBinding (EntryCell.TextProperty, "Assessment.Diagnosis", BindingMode.TwoWay);
			PTImpression.SetBinding (EntryCell.TextProperty, "Assessment.PTImpression", BindingMode.TwoWay);

			ProblemList.SetBinding (Editor.TextProperty, "Assessment.ProblemList", BindingMode.TwoWay);
			LongTermGoals.SetBinding (Editor.TextProperty, "Assessment.LongTermGoals", BindingMode.TwoWay);
			ShortTermGoals.SetBinding (Editor.TextProperty, "Assessment.ShortTermGoals", BindingMode.TwoWay);




				var SCell = new ViewCell {
					View = new StackLayout () {
						Children = {
						new Label (){FontSize = 16,VerticalOptions = LayoutOptions .Start ,HorizontalOptions = LayoutOptions .Fill, Text = "\tProblem List:"},
						patientVisitIdLabel,	
						ProblemList,	
						new Label (){FontSize = 16,VerticalOptions = LayoutOptions .Start ,HorizontalOptions = LayoutOptions .Fill, Text = "\tLong Term Goals:"},
						LongTermGoals,
						new Label (){FontSize = 16,VerticalOptions = LayoutOptions .Start ,HorizontalOptions = LayoutOptions .Fill, Text = "\tShort Term Goals:"},
						ShortTermGoals },
						Orientation = StackOrientation.Vertical
					}
				};



				return new TableView()
				{
					BackgroundColor = Color.Transparent ,
					HasUnevenRows = true,
					Intent = TableIntent.Form ,
					Root =  new TableRoot (){
					new TableSection ("Assessment")
						{
						Diagnosis,
						PTImpression,
						SCell
						}


					}
				};

			}

	}
}


