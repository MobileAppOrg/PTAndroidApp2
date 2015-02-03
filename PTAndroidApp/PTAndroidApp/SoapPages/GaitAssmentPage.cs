using System;
using Xamarin.Forms;
using System.Collections.Generic;
using PTAndroidApp.ValueConverters;

	namespace PTAndroidApp
	{

		public class GaitAssmentPage : ContentPage
		{

		private static List <string> lstChoices = new List<string>(){"-","+"};

			public GaitAssmentPage ()
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


			var IntialLoading = new	GSCell ();
			var LoadingResponse = new	GSCell ();
			var MidStance = new	GSCell ();
			var TerminalStance = new	GSCell ();
			var PreSwing = new	GSCell ();
			var InitialSwing = new	GSCell ();
			var MidSwing = new	GSCell ();
			var TerminalSwing = new	GSCell ();

			var txtAssment = new EntryCell {Placeholder = "Assessment", Keyboard = Keyboard.Numeric  };
			var Findings = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };
			var Significance = new Editor   {HorizontalOptions = LayoutOptions .FillAndExpand };

			txtAssment.SetBinding (Editor.TextProperty, "GaitAssessment.Asssessment", BindingMode.TwoWay);

			IntialLoading.pickerR.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.RInitialLoading", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			IntialLoading.pickerL.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.LInitialLoading", BindingMode.TwoWay, 
				new IndexToBoolConverter()));

			LoadingResponse.pickerR.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.RLoadingResponse", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			LoadingResponse.pickerL.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.LLoadingResponse", BindingMode.TwoWay, 
				new IndexToBoolConverter()));

			MidStance.pickerR.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.RMidStance", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			MidStance.pickerL.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.LMidStance", BindingMode.TwoWay, 
				new IndexToBoolConverter()));

			TerminalStance.pickerR.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.RTerminalStance", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			TerminalStance.pickerL.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.LTerminalStance", BindingMode.TwoWay, 
				new IndexToBoolConverter()));

			PreSwing.pickerR.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.RPreSwing", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			PreSwing.pickerL.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.LPreSwing", BindingMode.TwoWay, 
				new IndexToBoolConverter()));

			InitialSwing.pickerR.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.RInitialSwing", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			InitialSwing.pickerL.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.LInitialPreSwing", BindingMode.TwoWay, 
				new IndexToBoolConverter()));

			MidSwing.pickerR.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.RMidSwing", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			MidSwing.pickerL.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.LMidPreSwing", BindingMode.TwoWay, 
				new IndexToBoolConverter()));

			MidSwing.pickerR.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.RMidSwing", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			MidSwing.pickerL.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.LMidPreSwing", BindingMode.TwoWay, 
				new IndexToBoolConverter()));

			TerminalSwing.pickerR.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.RTerminalSwing", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			TerminalSwing.pickerL.SetBinding (Picker.SelectedIndexProperty, new Binding("GaitAssessment.LTerminalSwing", BindingMode.TwoWay, 
				new IndexToBoolConverter()));
			Findings.SetBinding (Editor.TextProperty, "GaitAssessment.Findings", BindingMode.TwoWay);
			Significance.SetBinding (Editor.TextProperty, "GaitAssessment.Significance", BindingMode.TwoWay);



		var FindingsCell = new ViewCell {
			View = new StackLayout () {
				Children = {
					new Label (){FontSize = 16,VerticalOptions = LayoutOptions .Start ,HorizontalOptions = LayoutOptions .Fill, Text = "Findings:"},

					Findings },
				Orientation = StackOrientation.Horizontal
			}
		};


		var SignificanceCell = new ViewCell {
			View = new StackLayout () {
				Children = {
					new Label (){FontSize = 16,VerticalOptions = LayoutOptions .Start ,HorizontalOptions = LayoutOptions .Fill, Text = "Significance:"},
					Significance },
				Orientation = StackOrientation.Horizontal
			}
		};
					
			Findings.SetBinding (Editor.TextProperty, "GaitAssessment.Findings", BindingMode.TwoWay);
			Significance.SetBinding (Editor.TextProperty, "GaitAssessment.Significance", BindingMode.TwoWay);


		return new TableView()
		{
			BackgroundColor = Color.Transparent ,
			HasUnevenRows = true,
			Intent = TableIntent.Form ,
			Root =  new TableRoot (){
				new TableSection ("Volumetric Measurement")
				{

					txtAssment,
					new ViewCell {Height = 40, View = new Label{ FontAttributes = FontAttributes.Bold , Text = "STANCE PHASE",  YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
					new ViewCell {Height = 20, View = new Label{ BackgroundColor =Color .Silver , Text = "Initial Loading",  YAlign = TextAlignment.Center, XAlign = TextAlignment.Start }},
					IntialLoading,
					new ViewCell {Height = 20, View = new Label{ BackgroundColor =Color .Silver , Text = "Loading Response",  YAlign = TextAlignment.Center, XAlign = TextAlignment.Start }},
					LoadingResponse,
					new ViewCell {Height = 20, View = new Label{ BackgroundColor =Color .Silver , Text = "Midstance",  YAlign = TextAlignment.Center, XAlign = TextAlignment.Start }},
					MidStance,
					new ViewCell {Height = 20, View = new Label{ BackgroundColor =Color .Silver , Text = "Terminal Stance",  YAlign = TextAlignment.Center, XAlign = TextAlignment.Start }},
					TerminalStance,
					new ViewCell {Height = 20, View = new Label{ BackgroundColor =Color .Silver , Text = "Preswing",  YAlign = TextAlignment.Center, XAlign = TextAlignment.Start }},
					PreSwing,
					new ViewCell {Height = 40, View = new Label{FontAttributes = FontAttributes.Bold ,  Text = "SWING PHASE",  YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
					new ViewCell {Height = 20, View = new Label{ BackgroundColor =Color .Silver , Text = "Initial Swing",  YAlign = TextAlignment.Center, XAlign = TextAlignment.Start }},
					InitialSwing,
					new ViewCell {Height = 20, View = new Label{ BackgroundColor =Color .Silver , Text = "Midswing",  YAlign = TextAlignment.Center, XAlign = TextAlignment.Start }},
					MidSwing,
					new ViewCell {Height = 20, View = new Label{ BackgroundColor =Color .Silver , Text = "Terminal Swing",  YAlign = TextAlignment.Center, XAlign = TextAlignment.Start }},

					TerminalSwing,

					FindingsCell,
					SignificanceCell

				}


			}
		};

	}



	public class GSCell : ViewCell
	{
		public Label lblRigth = new Label(){FontSize = 16, Text = "Right: ", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.End };
			public Label  lblLeft = new Label() {FontSize = 16,Text = "Left: ", HorizontalOptions = LayoutOptions.FillAndExpand, YAlign = TextAlignment.End };

			public Picker pickerR = new Picker(){ Title = "Select + -", Items = { "-", "+" },
		VerticalOptions = LayoutOptions.Start,
		HorizontalOptions = LayoutOptions.FillAndExpand};

			public  Picker pickerL = new Picker(){Title ="Select + -", Items = { "-", "+" }, 
		VerticalOptions = LayoutOptions.Start,
		HorizontalOptions = LayoutOptions.FillAndExpand};

			public GSCell(){

			View=	new StackLayout () {
				

				Orientation = StackOrientation.Vertical,
				HorizontalOptions= LayoutOptions .Fill ,
				Padding = new Thickness(0,0,0,0),
				Children = { 
					new StackLayout () {
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions= LayoutOptions .StartAndExpand ,
						Padding = new Thickness(0,0,0,0),
						Children = { 



								lblLeft, pickerL,lblRigth, pickerR
						}

					}
				}
			};


		}

	}






	}
}










