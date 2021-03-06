﻿using System;
using XLabs.Forms.Controls;
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
			var FinanciallStatsPicker = new Picker (){ Items = { "Stable","Unstable" }, 
				Title = "Financial Status", HorizontalOptions = LayoutOptions.FillAndExpand };

			List<string> Personalities = new List<string> (){ "A Personality","B Personalit" };
			var PersonalityPicker = new Picker (){ Items = { "A Personality","B Personality" }, 
				Title = "Personality", HorizontalOptions = LayoutOptions.FillAndExpand };
				
			List<string> LifeStyle = new List<string> (){ "Active","Sedentary" };
			var LifeStylePicker = new Picker (){ Items = { "Active","Sedentary" }, 
				Title = "LifeStyle", HorizontalOptions = LayoutOptions.FillAndExpand };

			List<string> EducationalAttainment  = new List<string> (){ "Elementary Graduate","Highschool Graduate", "College Graduate" };
			var EducationalAttainmentPicker = new Picker (){ Items = { "Elementary Graduate","Highschool Graduate", "College Graduate" }, 
				Title = "Educational Attainment", HorizontalOptions = LayoutOptions.FillAndExpand };

			List<string> LivesWith  = new List<string> (){ "Alone","Wife", "Husband", "Offspring", "Relatives", "Friends", "Others" };
			var LivesWithPicker = new Picker (){ Items = { "Alone","Wife", "Husband", "Offspring", "Relatives", "Friends", "Others" }, 
				Title = "LivesWith", HorizontalOptions = LayoutOptions.FillAndExpand };

			var LblOffspring = new Label  {IsVisible  = false, HorizontalOptions = LayoutOptions .Start, VerticalOptions = LayoutOptions.End,  FontSize = 17, Text  = "   Offspring:" };
			var NumberOfOffspring = new Stepper {IsVisible  = false, Minimum = 0,Maximum = 100,Increment = 1};
			var LblNumberOfOffspring = new Label  {IsVisible  = false,WidthRequest = 40, HorizontalOptions = LayoutOptions .CenterAndExpand  ,  VerticalOptions = LayoutOptions.End,  FontSize = 20, Text  = "" };

			List<string> Relatives  = new List<string> (){ "Grandparents", "Uncle", "Auntie", "Cousins" };
			var RelativesPicker = new Picker (){ IsVisible = false , Items = { "Grandparents", "Uncle", "Auntie", "Cousins" }, 
				Title = "Relatives", HorizontalOptions = LayoutOptions.FillAndExpand };




			var txtOthersLivesWith = new Entry  {HorizontalOptions = LayoutOptions .FillAndExpand , IsVisible  =false , Placeholder = "Others Lives With" };

			List<string> Hobbies  = new List<string> (){ "Singing","Dancing", "Reading", "Playing Sports", "Others"};
			var HobbiePicker = new Picker (){ Items = { "Singing","Dancing", "Reading", "Playing Sports", "Others"}, 
				Title = "Hobbies", HorizontalOptions = LayoutOptions.FillAndExpand };
			var txtSports = new Entry  {HorizontalOptions = LayoutOptions .FillAndExpand ,IsVisible = false, Placeholder = "Sports" };
			var txtOthersHobbies = new Entry  {HorizontalOptions = LayoutOptions .FillAndExpand ,IsVisible  =false, Placeholder = "Other Hobbies" };

			//List<string> CigaretteSmoker  = new List<string> (){ "+", "-"};
			//var CigaretteSmokerPicker = new Picker (){ Items = { "+","-"}, 
			//	Title = "Cigarette Smoker", HorizontalOptions = LayoutOptions.FillAndExpand };
			var lblCigaretteSmoker = new Label  { HorizontalOptions = LayoutOptions .StartAndExpand  ,  VerticalOptions = LayoutOptions.End,  FontSize = 18, Text  = "   Cigarette Smoker" };
			var CheckBoxCigaretteSmoker = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};

			var CheckBoxAlcoholDrinker = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var lblAlcoholDrinker = new Label  { HorizontalOptions = LayoutOptions .StartAndExpand  ,  VerticalOptions = LayoutOptions.End,  FontSize = 18, Text  = "   Alcohol Drinker" };

			//List <string> AlcoholDrinker  = new List<string> (){ "+", "-"};
			//var AlcoholDrinkerPicker = new Picker (){ Items = { "+","-"}, 
				//Title = "Alcohol Drinker", HorizontalOptions = LayoutOptions.FillAndExpand };

			List<string> TypeOfHouse  = new List<string> (){ "Nipa Hut","Dormitory", "Apartment", "Bungalow", "Condominium", "Mansion", "Two-Storey House", "Three Storey House", "Others"};
			var TypeOfHousesPicker = new Picker (){ Items = { "Nipa Hut","Dormitory", "Apartment", "Bungalow", "Condominium", "Mansion", "Two-Storey House", "Three Storey House", "Others"}, 
				Title = "Type Of Houses", HorizontalOptions = LayoutOptions.FillAndExpand };

			var txtOtherTypeOfHouse = new Entry  {HorizontalOptions = LayoutOptions .FillAndExpand ,IsVisible = false , Placeholder = "Other Type Of House" };


			NumberOfOffspring .ValueChanged += delegate (object sender, ValueChangedEventArgs e) {
				LblNumberOfOffspring.Text = String.Format("{0:####}", e.NewValue);
			};
				
		LivesWithPicker.SelectedIndexChanged   += delegate  {


				switch (LivesWithPicker.SelectedIndex)
			{
			case 3: //offspring
					NumberOfOffspring .IsVisible  = true;
					LblNumberOfOffspring.IsVisible  = true;
					LblOffspring.IsVisible  = true;
					RelativesPicker.IsVisible  = false;
					RelativesPicker.SelectedIndex = -1;
					txtOthersLivesWith.IsVisible = false ;
					txtOthersLivesWith.Text  = "";
				break;

			case 4: //relatives
					RelativesPicker.IsVisible  = true;
					LblNumberOfOffspring.Text  = "0";
					LblNumberOfOffspring.IsVisible  = false;
					LblOffspring.IsVisible  = false;
					NumberOfOffspring .IsVisible  = false ;
					txtOthersLivesWith.IsVisible = false ;
					txtOthersLivesWith.Text = "";
				break;

			case 6: //others
					LblNumberOfOffspring.Text  = "0";
					NumberOfOffspring .IsVisible  = false ;
					LblNumberOfOffspring.IsVisible  = false;
					LblOffspring.IsVisible  = false;
					txtOthersLivesWith.IsVisible = true;
					RelativesPicker.IsVisible  = false ;
					RelativesPicker.SelectedIndex = -1;
					break;
			default:
					NumberOfOffspring .IsVisible  = false ;
					LblNumberOfOffspring.IsVisible  = false;
					LblOffspring.IsVisible  = false;
					LblNumberOfOffspring.Text  = "0";
					RelativesPicker.IsVisible  = false ;
					RelativesPicker.SelectedIndex = -1;
					txtOthersLivesWith.IsVisible = false ;
					txtOthersLivesWith.Text  = "";

				break;
			}

		};

			HobbiePicker .SelectedIndexChanged   += delegate  {
			
				switch (HobbiePicker.SelectedIndex)
				{
				case 3: //sports
					txtSports .IsVisible = true;
					txtOthersHobbies .IsVisible = false;
					txtOthersHobbies .Text = "";
					txtSports .Text = "";
					break;
				case 4://others
					txtSports .IsVisible = false;
					txtSports .Text = "";
					txtOthersHobbies .IsVisible = true;
					txtOthersHobbies.Text = "";
					break;

					default:
					txtSports .IsVisible = false;
					txtSports .Text = "";
					txtOthersHobbies .IsVisible = false;
					txtOthersHobbies .Text = "";
					break;
				}
			};



			TypeOfHousesPicker  .SelectedIndexChanged   += delegate  {

				switch (TypeOfHousesPicker.SelectedIndex)
				{
				case 8: //sports
					txtOtherTypeOfHouse .IsVisible = true;
					txtOtherTypeOfHouse .Text = "";
					break;
				default:
					txtOtherTypeOfHouse .IsVisible = false ;
					break;
				}
			};



			ViewCell FinanciallStatsCell = new ViewCell{
				Height = 50,
				View = new StackLayout(){
					Children = {FinanciallStatsPicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell PersonalityCell = new ViewCell{
				Height = 50,
				View = new StackLayout(){
					Children = {PersonalityPicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell LifestyleCell = new ViewCell{
				Height = 50,
				View = new StackLayout(){
					Children = {LifeStylePicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell EducationalAttainmentCell = new ViewCell{
				Height = 50,
				View = new StackLayout(){
					Children = {EducationalAttainmentPicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell LivesWithCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {LivesWithPicker,
					
						new StackLayout(){
							Children = {LblOffspring,NumberOfOffspring, LblNumberOfOffspring},
							Orientation = StackOrientation.Horizontal  ,
							Padding = new Thickness(1,1,1,1),HorizontalOptions = LayoutOptions.Fill},
						RelativesPicker,txtOthersLivesWith
				
				},
					Orientation = StackOrientation.Vertical,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

//			ViewCell NumberOfOffspringCell = new ViewCell{
//				Height = 100,
//				View = new StackLayout(){
//					Children = {LblOffspring,NumberOfOffspring, LblNumberOfOffspring},
//					Orientation = StackOrientation.Horizontal  ,
//					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

//			ViewCell RelativesCell = new ViewCell{
//				Height = 100,
//				View = new StackLayout(){
//					Children = {RelativesPicker},
//					Orientation = StackOrientation.Horizontal  ,
//					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

//			ViewCell OthersLivesWithCell = new ViewCell{
//				Height = 100,
//				View = new StackLayout(){
//					Children = {txtOthersLivesWith },
//					Orientation = StackOrientation.Horizontal  ,
//					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell HobbiesCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {HobbiePicker,
						txtSports	,
						txtOthersHobbies,

					
					},
					Orientation = StackOrientation.Vertical   ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};


//			ViewCell SportsCell = new ViewCell{
//				Height = 50,
//				View = new StackLayout(){
//					Children = {txtSports  },
//					Orientation = StackOrientation.Horizontal  ,
//					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

//			ViewCell OthersHobbiesCell = new ViewCell{
//				Height = 40,
//				View = new StackLayout(){
//					Children = {txtOthersHobbies  },
//					Orientation = StackOrientation.Horizontal  ,
//					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};
//

			ViewCell CigaretteSmokerPickerCell = new ViewCell{
				Height = 50,
				View = new StackLayout(){
					Children = {CheckBoxCigaretteSmoker,lblCigaretteSmoker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell AlcoholDrinkerCell = new ViewCell{
				Height = 50,
				View = new StackLayout(){
					Children = {CheckBoxAlcoholDrinker,lblAlcoholDrinker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell TypeOfHouseCell = new ViewCell{
				Height = 50,
				View = new StackLayout(){
					Children = {TypeOfHousesPicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell OtherTypeOfHouseCell = new ViewCell{
				Height = 50,
				View = new StackLayout(){
					Children = {txtOtherTypeOfHouse  },
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};


			FinanciallStatsPicker.SetBinding (Picker.SelectedIndexProperty, "PSEHx.FinancialStatus", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = FinanciallStatus  });

			PersonalityPicker.SetBinding (Picker.SelectedIndexProperty, "PSEHx.PersonalityType", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = Personalities  });

			LifeStylePicker.SetBinding (Picker.SelectedIndexProperty, "PSEHx.LifeStyle", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = LifeStyle  });

			EducationalAttainmentPicker.SetBinding (Picker.SelectedIndexProperty, "PSEHx.EducationalAttainment", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = EducationalAttainment  });

			LivesWithPicker.SetBinding (Picker.SelectedIndexProperty, "PSEHx.LivesWith", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = LivesWith  });

			LblNumberOfOffspring.SetBinding ( Label.TextProperty , "PSEHx.NumberOfOffspring",  BindingMode.TwoWay);
			
			RelativesPicker.SetBinding (Picker.SelectedIndexProperty, "PSEHx.Relatives", 
					BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = Relatives  });

			txtOthersLivesWith.SetBinding ( EntryCell.TextProperty , "PSEHx.OtherLivesWith",  BindingMode.TwoWay);

			txtSports.SetBinding ( EntryCell.TextProperty , "PSEHx.Sports",  BindingMode.TwoWay);
			HobbiePicker.SetBinding (Picker.SelectedIndexProperty, "PSEHx.Hobbies", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = Hobbies  });

			txtOthersHobbies.SetBinding ( EntryCell.TextProperty , "PSEHx.OtherHobbies",  BindingMode.TwoWay);
			CheckBoxCigaretteSmoker.SetBinding (CheckBox.CheckedProperty, "PSEHx.CigaretteSmoker", BindingMode.TwoWay);
			CheckBoxAlcoholDrinker.SetBinding (CheckBox.CheckedProperty, "PSEHx.AlcoholDrinker", BindingMode.TwoWay);

			TypeOfHousesPicker.SetBinding (Picker.SelectedIndexProperty, "PSEHx.TypeOfHouse", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = TypeOfHouse  });

			txtOtherTypeOfHouse.SetBinding ( EntryCell.TextProperty , "PSEHx.OtherTypeOfHouse",  BindingMode.TwoWay);

//			CigaretteSmokerPicker.SetBinding (Picker.SelectedIndexProperty, "PSEHx.CigaretteSmoker", 
//				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = CigaretteSmoker  });
//
//			AlcoholDrinkerPicker.SetBinding (Picker.SelectedIndexProperty, "PSEHx.AlcoholDrinker", 
//				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = AlcoholDrinker  });

			return new TableView () {
				Intent = TableIntent.Form,
				HasUnevenRows = true,
				Root = new TableRoot () {
					new TableSection ("PSEHx") {
						FinanciallStatsCell,
						PersonalityCell,
						LifestyleCell,
						EducationalAttainmentCell,
						LivesWithCell,
						//NumberOfOffspringCell,
						//RelativesCell,
						//OthersLivesWithCell,
						HobbiesCell,
						//SportsCell,
						//OthersHobbiesCell,
						CigaretteSmokerPickerCell,
						AlcoholDrinkerCell,
						TypeOfHouseCell,
						OtherTypeOfHouseCell
					}
				}
			};

		}
	

	}
}


