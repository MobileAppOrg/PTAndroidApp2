using System;

using Xamarin.Forms;
using System.Collections.Generic;
using PTAndroidApp.ValueConverters;

namespace PTAndroidApp
{
	public class PSEHxPage : ContentPage
	{
		public PSEHxPage ()
		{
			TableView tblForm = CreateTable ();

			Content = new StackLayout{ 
				Children = { 
					tblForm
				}
			};
		
		}

		static TableView CreateTable(){

			Entry txtPatientVisitId = new Entry (){ IsVisible = false };
			txtPatientVisitId.SetBinding (Entry.TextProperty,"PatientVisitId", BindingMode.TwoWay);


			List<string> FinanciallStatus = new List<string> (){ "Stable","Unstable" };
			var FinanciallStats = new Picker (){ Items = { "Stable","Unstable" }, 
				Title = "Financiall Status", HorizontalOptions = LayoutOptions.FillAndExpand };

			List<string> Personalities = new List<string> (){ "A Personality","B Personalit" };
			var Personality = new Picker (){ Items = { "A Personality","B Personality" }, 
				Title = "Personality", HorizontalOptions = LayoutOptions.FillAndExpand };
				

			ViewCell FinanciallStatsCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {FinanciallStats},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell PersonalityCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {Personality},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};


			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("PSEHx") {
						FinanciallStatsCell,
						PersonalityCell
					}
				}
			};

		}
	

	}
}


