using System;
using Xamarin.Forms;
using System.Collections.Generic;
using PTAndroidApp.ValueConverters;

namespace PTAndroidApp
{
	public class FMHxPage: ContentPage
	{
		private static List<string> lstChoices = new List<string>(){"-","+"};

		static TableView CreateTable(){
			var HypertensionCell = new FMHxCell ();
			HypertensionCell.pickerF.SetBinding (Picker.SelectedIndexProperty, new Binding("FMHx.HypertensionF", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			HypertensionCell.pickerM.SetBinding (Picker.SelectedIndexProperty, "FMHx.HypertensionM", BindingMode.TwoWay, 
				new IndexToBoolConverter());

			var ArthritisCell = new FMHxCell ();
			ArthritisCell.pickerF.SetBinding (Picker.SelectedIndexProperty, new Binding("FMHx.ArthritisF", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			ArthritisCell.pickerM.SetBinding (Picker.SelectedIndexProperty, "FMHx.ArthritisM", BindingMode.TwoWay, 
				new IndexToBoolConverter());

			var DiabetesMellitusCell = new FMHxCell ();
			DiabetesMellitusCell.pickerF.SetBinding (Picker.SelectedIndexProperty, new Binding("FMHx.DiabetesMellitusF", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			DiabetesMellitusCell.pickerM.SetBinding (Picker.SelectedIndexProperty, "FMHx.DiabetesMellitusM", BindingMode.TwoWay, 
				new IndexToBoolConverter());

			var CancerCell = new FMHxCell ();
			CancerCell.pickerF.SetBinding (Picker.SelectedIndexProperty, new Binding("FMHx.CancerF", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			CancerCell.pickerM.SetBinding (Picker.SelectedIndexProperty, "FMHx.CancerM", BindingMode.TwoWay, 
				new IndexToBoolConverter());

			var AsthmaCell = new FMHxCell ();
			AsthmaCell.pickerF.SetBinding (Picker.SelectedIndexProperty, new Binding("FMHx.AsthmaF", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			AsthmaCell.pickerM.SetBinding (Picker.SelectedIndexProperty, "FMHx.AsthmaM", BindingMode.TwoWay, 
				new IndexToBoolConverter());

			var AllergiesCell = new FMHxCell ();
			AllergiesCell.pickerF.SetBinding (Picker.SelectedIndexProperty, new Binding("FMHx.AllergiesF", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			AllergiesCell.pickerM.SetBinding (Picker.SelectedIndexProperty, "FMHx.AllergiesM", BindingMode.TwoWay, 
				new IndexToBoolConverter());

			var NeurologicConditionCell = new FMHxCell ();
			NeurologicConditionCell.pickerF.SetBinding (Picker.SelectedIndexProperty, new Binding("FMHx.NeurologicConditionF", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			NeurologicConditionCell.pickerM.SetBinding (Picker.SelectedIndexProperty, "FMHx.NeurologicConditionM", BindingMode.TwoWay, 
				new IndexToBoolConverter());

			EntryCell othersText = new EntryCell{ Label = "Others: "};
			othersText.SetBinding (EntryCell.TextProperty, "FMHx.Others");

			var OthersCell = new FMHxCell ();
			OthersCell.pickerF.SetBinding (Picker.SelectedIndexProperty, new Binding("FMHx.OthersF", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			OthersCell.pickerM.SetBinding (Picker.SelectedIndexProperty, "FMHx.OthersM", BindingMode.TwoWay, 
				new IndexToBoolConverter());


			return new TableView () {
				Intent = TableIntent.Settings,
				Root = new TableRoot () {
					new TableSection ("FMHx") {
						new ViewCell {View = new Label{ Text = "Hypertentsion", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						HypertensionCell,
						new ViewCell {View = new Label{ Text = "Arthritis", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						ArthritisCell,
						new ViewCell {View = new Label{ Text = "Diabetes Mellitus", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						DiabetesMellitusCell,
						new ViewCell {View = new Label{ Text = "Cancer", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						CancerCell,
						new ViewCell {View = new Label{ Text = "Asthma", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						AsthmaCell,
						new ViewCell {View = new Label{ Text = "Allergies", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						AllergiesCell,
						new ViewCell {View = new Label{ Text = "Neurologic Condition", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						NeurologicConditionCell,
						othersText,
						OthersCell
					}
				}
			};
		}

		public FMHxPage ()
		{
			var tblView = CreateTable ();

			Content = new StackLayout{
				Children = { tblView }
			};
		}
	}

	public class FMHxCell : ViewCell
	{
		public Label lblFather = new Label(){Text = "Father: ", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center };
		public Picker pickerF = new Picker(){ Items = { "-", "+" },
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.FillAndExpand, WidthRequest = 40 };
		public Label  lblMother = new Label(){Text = "Mother: ", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.Center };
		public  Picker pickerM = new Picker(){ Items = { "-", "+" }, 
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.FillAndExpand, WidthRequest = 40  };

		public FMHxCell(){
			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = { lblFather, pickerF, lblMother,pickerM }
			};
		}
	}
}

