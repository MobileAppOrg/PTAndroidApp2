using System;
using Xamarin.Forms;
using PTAndroidApp.ValueConverters;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class PatientGeneralInfoPage:ContentPage
	{
		public PatientGeneralInfoPage(){
			TableView tblForm = CreateTable ();

			Content = new StackLayout{ 
				Children = { 
					tblForm
				}
			};
		}

		static TableView CreateTable(){

			List<string> listCivilStatus = new List<string> (){ "Single", "Married", "Divorced", "Widowed" };
			List<string> listHandedness = new List<string> (){ "Right", "Left" };
			List<string> listGender = new List<string> (){ "M", "F" };

			var PatientVisitId = new EntryCell (){ Label = "Patient Visit Id: ", Keyboard = Keyboard.Numeric };
			var PatientId = new EntryCell (){ Label = "Patient Id: ", Keyboard= Keyboard.Numeric };
			var FirstName = new EntryCell (){ Label = "First Name: "};
			var LastName = new EntryCell (){ Label = "Last Name: "};
			var Age = new EntryCell (){ Label = "Age: ", Keyboard = Keyboard.Numeric };
			var GenderPicker = new Picker (){ Items = { "M", "F" }, Title = "Gender", HorizontalOptions = LayoutOptions.FillAndExpand };
			var Address = new EntryCell (){ Label = "Address: " };
			var CityTown = new EntryCell (){ Label = "City/Town: "};
			var Province = new EntryCell (){ Label = "Province: "};
			var CivilStatusPicker = new Picker (){ Items = { "Single", "Married", "Divorced", "Widowed" }, Title = "Civil Status", HorizontalOptions = LayoutOptions.FillAndExpand };
			var CivilStatus = new Entry (){ IsVisible = false };
			var HandedNess = new Picker (){ Items = { "Right","Left" }, Title = "Handedness", HorizontalOptions = LayoutOptions.FillAndExpand };
			var Occupation = new EntryCell (){ Label = "Occupation: "};
			var Religion = new EntryCell (){ Label = "Religion: "};

			ViewCell gendercell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 22, Text = "Gender: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
						GenderPicker
					},
					Padding = new Thickness(5,1,1,1),
					HorizontalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Horizontal
				}
			};

			ViewCell civilstatuscell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Civil Status: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
						CivilStatusPicker
					},
					Padding = new Thickness(5,1,1,1),
					HorizontalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Horizontal
				}
			};

			ViewCell handednesscell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Handedness: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
						HandedNess
					},
					Padding = new Thickness(5,1,1,1),
					HorizontalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Horizontal
				}
			};

			PatientVisitId.SetBinding(EntryCell.TextProperty,"PatientVisitId", BindingMode.TwoWay);
			PatientId.SetBinding(EntryCell.TextProperty,"PatientId", BindingMode.TwoWay);
			FirstName.SetBinding (EntryCell.TextProperty, "FirstName", BindingMode.TwoWay);
			LastName.SetBinding (EntryCell.TextProperty, "LastName", BindingMode.TwoWay);
			Age.SetBinding (EntryCell.TextProperty, "Age", BindingMode.TwoWay);
			GenderPicker.SetBinding (Picker.SelectedIndexProperty, "Sex", 
				BindingMode.TwoWay,new IndexToGenericListConverter(){ ItemList = listGender });
			Address.SetBinding (EntryCell.TextProperty, "Address", BindingMode.TwoWay);
			CityTown.SetBinding (EntryCell.TextProperty, "CityTown", BindingMode.TwoWay);
			Province.SetBinding (EntryCell.TextProperty, "Province", BindingMode.TwoWay);
			CivilStatusPicker.SetBinding(Picker.SelectedIndexProperty, "CivilStatus", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = listCivilStatus });
			HandedNess.SetBinding (Picker.SelectedIndexProperty, "HandedNess", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = listHandedness });
			Occupation.SetBinding (EntryCell.TextProperty, "Occupation", BindingMode.TwoWay);
			Religion.SetBinding (EntryCell.TextProperty, "Religion", BindingMode.TwoWay);

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("Personal Info") {
						PatientVisitId,
						PatientId,
						FirstName,
						LastName,
						Age,
						gendercell,
						Address,
						CityTown,
						Province,
						civilstatuscell,
						handednesscell,
						Occupation,
						Religion
					}
				}
			};
		}
	}
}

