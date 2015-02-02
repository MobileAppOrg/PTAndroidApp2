using System;

using Xamarin.Forms;
using System.Collections.Generic;
using PTAndroidApp.ValueConverters;
using XLabs.Forms.Controls;
namespace PTAndroidApp
{
	public class OcularInspectionPage : ContentPage
	{

		public OcularInspectionPage ()
		{
			TableView  table = CreateTable ();
			Content = new StackLayout { 
				Children = {
					table
				}
			};
		}


		static TableView CreateTable()
		{
			var CheckBoxAmbulation = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxWheelChair = new CheckBox {IsVisible  =false,VerticalOptions = LayoutOptions .EndAndExpand};
			//var CheckBoxCruches = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};

			List<string> TADCruches = new List<string> (){ "Axillary","Lofstrand", "Forearm" };

			var TADCruchesPicker = new Picker (){IsVisible =false, Items = { "Axillary","Lofstrand", "Forearm" }, 
				Title = "Crutches", HorizontalOptions = LayoutOptions.FillAndExpand  };
			//var txtOtherCrunches = new Entry{HorizontalOptions = LayoutOptions .FillAndExpand , IsEnabled = false, Placeholder = "Other Type" };


			List<string> TADCane = new List<string> (){ "Standard","Quad", "Crook" };
			var TADCanePicker = new Picker (){IsVisible =false, Items = { "Standard","Quad", "Crook" }, 
				Title = "Cane", HorizontalOptions = LayoutOptions.FillAndExpand  };
			//var txtothersCane = new Entry{HorizontalOptions = LayoutOptions .FillAndExpand ,IsEnabled = false, Placeholder = "Other Type" };

			List<string> TADWalker = new List<string> (){ "Standard","Rolling" };
			var TADWalkerPicker = new Picker (){IsVisible =false, Items = { "Standard","Rolling" }, 
				Title = "Walker", HorizontalOptions = LayoutOptions.FillAndExpand  };
			//var txtotherWalker = new Entry{HorizontalOptions = LayoutOptions .FillAndExpand ,IsEnabled = false, Placeholder = "Other Type" };

			var CheckBoxAlert = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxCoherent = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxCooperative = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};

			List<string> BodyType = new List<string> (){ "Endomorph","Mesomorph", "Ectomorph" };
			var BodyTypePicker = new Picker (){HorizontalOptions =LayoutOptions .FillAndExpand , Items = {  "Endomorph","Mesomorph", "Ectomorph" }, 
				Title = "Body Type" };

			var CheckBoxAtrophy = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtAthrophy = new Entry {IsVisible  = false, Placeholder = "Location" };

			var CheckBoxSwelling = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtSwelling = new Entry {IsVisible = false, Placeholder = "Swelling" };

			var CheckBoxRedness = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtRedness = new Entry {IsVisible = false, Placeholder = "Redness" };

			var CheckBoxEcchymosis = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtEcchymosis = new Entry {IsVisible = false, Placeholder = "Ecchymosis" };

			var CheckBoxDeformity = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtDeformity = new Entry {IsVisible = false, Placeholder = "Deformity" };

			var CheckBoxWounds = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtWounds = new Entry {IsVisible = false, Placeholder = "Wounds" };

			var CheckBoxScar = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtScar = new Entry {IsVisible = false, Placeholder = "Scar" };

			var CheckBoxPSore = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtPSore = new Entry {IsVisible = false, Placeholder = "Pressure Sore" };

			var CheckBoxGaitDev = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};

			var CheckBoxIncision = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtIncision = new Entry {IsVisible = false, Placeholder = "Incision" };
			var CheckBoxShortnessOfBreathing = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtOthers = new EntryCell { Placeholder = "Others" };

			ViewCell AmbulationCell = new ViewCell{
				Height = 40,
				View = new StackLayout(){
					Children = {
						CheckBoxAmbulation,new Label () {FontSize = 17, Text = "   Ambulation", VerticalOptions = LayoutOptions .End },
						},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};


			ViewCell WheelChairCell = new ViewCell{
				Height = 40,
				View = new StackLayout(){
					Children = {
						CheckBoxWheelChair,new Label () {FontSize = 17, Text = "   Wheel Chair:", VerticalOptions = LayoutOptions .End },
						},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell CruchesCell = new ViewCell{
				Height = 40,
				View = new StackLayout(){
					Children = {new Label () {FontSize = 17, Text = "   Crutches:", VerticalOptions = LayoutOptions .End },
						TADCruchesPicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};
		
			ViewCell CaneCell = new ViewCell{
				Height = 40,
				View = new StackLayout(){
					Children = {new Label () {FontSize = 17, Text = "   Cane:", VerticalOptions = LayoutOptions .End },
						TADCanePicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};


			ViewCell WalkerCell = new ViewCell{
				Height = 40,
				View = new StackLayout(){
					Children = {new Label () {FontSize = 17, Text = "   Walker:", VerticalOptions = LayoutOptions .End },
						TADWalkerPicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};


			ViewCell AlertCell = new ViewCell{
				Height = 40,
				View = new StackLayout(){
					Children = {
						CheckBoxAlert,new Label () {FontSize = 17, Text = "   Alert", VerticalOptions = LayoutOptions .End },
						},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell CoherentCell = new ViewCell{
				Height = 40,
				View = new StackLayout(){
					Children = {
						CheckBoxCoherent,new Label () {FontSize = 17, Text = "   Coherent", VerticalOptions = LayoutOptions .End },
						},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell CooperativeCell = new ViewCell{
				Height = 40,
				View = new StackLayout(){
					Children = {
						CheckBoxCooperative,new Label () {FontSize = 17, Text = "   Cooperative", VerticalOptions = LayoutOptions .End },
						},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell BodyTypeCell = new ViewCell{
				Height = 40,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Body Type", VerticalOptions = LayoutOptions .End },
						BodyTypePicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};


			ViewCell AtrophyCell = new ViewCell{
				Height = 80,
				View = new StackLayout(){
					Children = {

					
						new StackLayout(){
							Children = {
								CheckBoxAtrophy,new Label () {FontSize = 17, Text = "   Atrophy", VerticalOptions = LayoutOptions .End },
								},
							Orientation = StackOrientation.Horizontal  ,
							Padding = new Thickness(1,1,1,1),HorizontalOptions = LayoutOptions.Fill},
						txtAthrophy

					},
					Orientation = StackOrientation.Vertical  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};




			ViewCell SwellingCell = new ViewCell{
				Height = 80,
				View = new StackLayout(){

					Children = {
						new StackLayout(){
							Children = {
								CheckBoxSwelling,new Label () {FontSize = 17, Text = "   Swelling", VerticalOptions = LayoutOptions .End },
								},
							Orientation = StackOrientation.Horizontal  ,
							Padding = new Thickness(1,1,1,1),HorizontalOptions = LayoutOptions.Fill},
						txtSwelling},
					Orientation = StackOrientation.Vertical ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};




			ViewCell RednessCell = new ViewCell{
				Height = 80,
				View = new StackLayout(){
					Children = {


						new StackLayout(){
							Children = {
								CheckBoxRedness,new Label () {FontSize = 17, Text = "   Redness", VerticalOptions = LayoutOptions .End },
								},
							Orientation = StackOrientation.Horizontal  ,
							Padding = new Thickness(1,1,1,1),HorizontalOptions = LayoutOptions.Fill},
						txtRedness},

					Orientation = StackOrientation.Vertical  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};





			ViewCell EcchymosisCell = new ViewCell{
				Height = 80,
				View = new StackLayout(){
					Children = {

						new StackLayout(){
							Children = {
								CheckBoxEcchymosis,new Label () {FontSize = 17, Text = "   Ecchymosis", VerticalOptions = LayoutOptions .End },
								},
							Orientation = StackOrientation.Horizontal  ,
							Padding = new Thickness(1,1,1,1),HorizontalOptions = LayoutOptions.Fill},
						txtEcchymosis},
			
					Orientation = StackOrientation.Vertical  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};





			ViewCell DeformityCell = new ViewCell{
				Height = 80,
				View = new StackLayout(){
					Children = {


						new StackLayout(){
							Children = {
								CheckBoxDeformity, new Label () {FontSize = 17, Text = "   Deformity", VerticalOptions = LayoutOptions .End },
							},

							Orientation = StackOrientation.Horizontal  ,
							Padding = new Thickness(1,1,1,1),HorizontalOptions = LayoutOptions.Fill},
						txtDeformity
						},
					Orientation = StackOrientation.Vertical   ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell WoundsCell = new ViewCell{
				Height = 80,
				View = new StackLayout(){
					Children = {

						new StackLayout(){
							Children = {
								CheckBoxWounds,new Label () {FontSize = 17, Text = "   Wounds", VerticalOptions = LayoutOptions .End },
							},

							Orientation = StackOrientation.Horizontal  ,
							Padding = new Thickness(1,1,1,1),HorizontalOptions = LayoutOptions.Fill},

						txtWounds
						},
					Orientation = StackOrientation.Vertical   ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};




			ViewCell ScarCell = new ViewCell{
				Height = 80,
				View = new StackLayout(){
					Children = {

						new StackLayout(){
							Children = {
							CheckBoxScar,
							new Label () {FontSize = 17, Text = "   Scar", VerticalOptions = LayoutOptions .End },
							},

							Orientation = StackOrientation.Horizontal  ,
							Padding = new Thickness(1,1,1,1),HorizontalOptions = LayoutOptions.Fill},

						txtScar
						},
					Orientation = StackOrientation.Vertical  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};



			ViewCell PSoreCell = new ViewCell{
				Height = 80,
				View = new StackLayout(){
					Children = {


						new StackLayout(){
							Children = {
								CheckBoxPSore,
								new Label () {FontSize = 17, Text = "   Pressure Sore", VerticalOptions = LayoutOptions .End },
							},

							Orientation = StackOrientation.Horizontal  ,
							Padding = new Thickness(1,1,1,1),HorizontalOptions = LayoutOptions.Fill},

						txtPSore


						},
					Orientation = StackOrientation.Vertical   ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell GaitDevCell = new ViewCell{
				Height = 40,
				View = new StackLayout(){
					Children = {
						CheckBoxGaitDev,new Label () {FontSize = 17, Text = "   Gait Deviation", VerticalOptions = LayoutOptions .End },
						},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell IncisionCell = new ViewCell{
				Height = 80,
				View = new StackLayout(){
					Children = {

						new StackLayout(){
							Children = {
								CheckBoxIncision,new Label () {FontSize = 17, Text = "   Incision", VerticalOptions = LayoutOptions .End },
							},

							Orientation = StackOrientation.Horizontal  ,
							Padding = new Thickness(1,1,1,1),HorizontalOptions = LayoutOptions.Fill},
							txtIncision


								},
					Orientation = StackOrientation.Vertical   ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell ShortnessOfBreathingCell = new ViewCell{
				Height = 40,
				View = new StackLayout(){
					Children = {
						CheckBoxShortnessOfBreathing, new Label () {FontSize = 17, Text = "   Shortness Of Breathing", VerticalOptions = LayoutOptions .End },
						},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};
					

			CheckBoxAmbulation .CheckedChanged += delegate   {
					//txtOtherCrunches .Text = "";
					//txtothersCane  .Text = "";
					//txtotherWalker  .Text = "";

					if (CheckBoxAmbulation .Checked ){
					TADCruchesPicker .IsVisible = true;
					//txtOtherCrunches .IsEnabled = true;
					TADCanePicker  .IsVisible = true;
					//txtothersCane  .IsEnabled = true;
					TADWalkerPicker  .IsVisible = true;
					//txtotherWalker  .IsEnabled = true;
					CheckBoxWheelChair  .IsVisible = true;
					}
					else{
					TADCruchesPicker .IsVisible = false;
					//txtOtherCrunches .IsEnabled = false;
					TADCanePicker  .IsVisible = false;
					//txtothersCane  .IsEnabled = false;
					TADWalkerPicker  .IsVisible = false;
					//txtotherWalker  .IsEnabled = false;
					CheckBoxWheelChair  .IsVisible = false;
					}
				};

			CheckBoxAtrophy.CheckedChanged += delegate {
					txtAthrophy .Text = "";
					if (CheckBoxAtrophy.Checked ){
					txtAthrophy.IsVisible = true;
					}
					else{
					txtAthrophy.IsVisible = false ;
					}
				};

			CheckBoxSwelling .CheckedChanged += delegate {
					txtSwelling .Text = "";
				if (CheckBoxSwelling .Checked ){
					txtSwelling.IsVisible = true;
					}
					else{
					txtSwelling.IsVisible = false ;
					}
				};

			CheckBoxRedness  .CheckedChanged += delegate {
					txtRedness  .Text = "";
				if (CheckBoxRedness  .Checked ){
					txtRedness .IsVisible = true;
					}
					else{
					txtRedness .IsVisible = false ;
					}
				};

			CheckBoxEcchymosis   .CheckedChanged += delegate {
					txtEcchymosis   .Text = "";
				if (CheckBoxEcchymosis   .Checked ){
					txtEcchymosis  .IsVisible = true;
					}
					else{
					txtEcchymosis  .IsVisible = false ;
					}
				};

			CheckBoxDeformity    .CheckedChanged += delegate {
					txtDeformity   .Text = "";
				if (CheckBoxDeformity .Checked ){
					txtDeformity  .IsVisible = true;
					}
					else{
					txtDeformity  .IsVisible = false ;
					}
				};

			CheckBoxWounds.CheckedChanged += delegate {
					txtWounds .Text = "";
				if (CheckBoxWounds .Checked ){
					txtWounds   .IsVisible = true;
					}
					else{
					txtWounds   .IsVisible = false ;
					}

				};

			CheckBoxScar.CheckedChanged += delegate {
					txtScar     .Text = "";
				if (CheckBoxScar      .Checked ){
					txtScar    .IsVisible = true;
					}
					else{
					txtScar    .IsVisible = false ;
					}
				};

			CheckBoxPSore.CheckedChanged += delegate {
					txtPSore.Text = "";
				if (CheckBoxPSore .Checked ){
					txtPSore.IsVisible = true;
					}
					else{
					txtPSore.IsVisible = false ;
					}
				};

			CheckBoxIncision.CheckedChanged += delegate {
					txtIncision.Text = "";
				if (CheckBoxIncision.Checked ){
					txtIncision.IsVisible = true;
					}
					else{
					txtIncision.IsVisible = false ;
					}
				};
		

			CheckBoxAmbulation.SetBinding (CheckBox.CheckedProperty, "OcularInspection.Ambulation", BindingMode.TwoWay);
			CheckBoxWheelChair .SetBinding (CheckBox.CheckedProperty, "OcularInspection.TADWheelChair", BindingMode.TwoWay);
			//need to add other cruches on model?
//			TADCruchesPicker.SelectedIndexChanged += delegate {
//			if (TADCruchesPicker.SelectedIndex == 3) {
//				txtOtherCrunches.IsEnabled = true;
//				txtOtherCrunches.SetBinding (EntryCell.TextProperty, "OcularInspection.TADCruches", BindingMode.TwoWay);
//			}
//			else {
//						txtOtherCrunches.IsEnabled = false ;
//						TADCruchesPicker.SetBinding (Picker.SelectedIndexProperty, "OcularInspection.TADCruches", 
//						BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = TADCruches  });
//			}
//			};
//
//
//
//		}
//			TADCanePicker .SelectedIndexChanged += delegate {
//				if (TADCanePicker .SelectedIndex == 3) {
//					txtothersCane .IsEnabled = true;
//					txtothersCane.SetBinding (EntryCell.TextProperty, "OcularInspection.TADCane", BindingMode.TwoWay);
//				}
//				else {
//					txtothersCane .IsEnabled = false ;
//					TADCanePicker.SetBinding (Picker.SelectedIndexProperty, "OcularInspection.TADCane", 
//						BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = TADCane  });
//				}
//			};
//			TADWalkerPicker  .SelectedIndexChanged += delegate {
//				if (TADWalkerPicker  .SelectedIndex == 3) {
//					txtotherWalker  .IsEnabled = true;
//					txtotherWalker .SetBinding (EntryCell.TextProperty, "OcularInspection.TADWalker", BindingMode.TwoWay);
//				}
//				else {
//					txtotherWalker  .IsEnabled = false ;
//					TADWalkerPicker.SetBinding (Picker.SelectedIndexProperty, "OcularInspection.TADWalker", 
//						BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = TADWalker  });
//				}
//			};

			TADCruchesPicker.SetBinding (Picker.SelectedIndexProperty, "OcularInspection.TADCruches", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = TADCruches  });
			TADCanePicker.SetBinding (Picker.SelectedIndexProperty, "OcularInspection.TADCane", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = TADCane  });
			TADCanePicker.SetBinding (Picker.SelectedIndexProperty, "OcularInspection.TADCane", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = TADCane  });
			TADWalkerPicker.SetBinding (Picker.SelectedIndexProperty, "OcularInspection.TADWalker", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = TADWalker  });

			CheckBoxAlert  .SetBinding (CheckBox.CheckedProperty, "OcularInspection.Alert", BindingMode.TwoWay);
			CheckBoxCoherent   .SetBinding (CheckBox.CheckedProperty, "OcularInspection.Coherent", BindingMode.TwoWay);
			CheckBoxCooperative    .SetBinding (CheckBox.CheckedProperty, "OcularInspection.Cooperative", BindingMode.TwoWay);
			BodyTypePicker .SetBinding (Picker.SelectedIndexProperty, "OcularInspection.BodyType", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = BodyType  });
			txtAthrophy  .SetBinding (EntryCell.TextProperty, "OcularInspection.Atrophy", BindingMode.TwoWay);
			txtSwelling .SetBinding (EntryCell.TextProperty, "OcularInspection.Swelling", BindingMode.TwoWay);
			txtRedness .SetBinding (EntryCell.TextProperty, "OcularInspection.Redness", BindingMode.TwoWay);
			txtEcchymosis  .SetBinding (EntryCell.TextProperty, "OcularInspection.Ecchymosis", BindingMode.TwoWay);
			txtDeformity   .SetBinding (EntryCell.TextProperty, "OcularInspection.Deformity", BindingMode.TwoWay);
			txtWounds    .SetBinding (EntryCell.TextProperty, "OcularInspection.Wounds", BindingMode.TwoWay);
			txtScar     .SetBinding (EntryCell.TextProperty, "OcularInspection.Scar", BindingMode.TwoWay);
			txtPSore      .SetBinding (EntryCell.TextProperty, "OcularInspection.PressureSore", BindingMode.TwoWay);
			CheckBoxGaitDev.SetBinding (CheckBox.CheckedProperty, "OcularInspection.GaitDeviation", BindingMode.TwoWay);
			txtIncision .SetBinding (EntryCell.TextProperty, "OcularInspection.Incision", BindingMode.TwoWay);
			CheckBoxShortnessOfBreathing .SetBinding (CheckBox.CheckedProperty, "OcularInspection.ShortnessOfBreathing", BindingMode.TwoWay);
			txtOthers  .SetBinding (EntryCell.TextProperty, "OcularInspection.Others", BindingMode.TwoWay);


			return new TableView () {
			Intent = TableIntent.Form ,
				HasUnevenRows = true,
				Root = new TableRoot (){
					new TableSection ("Ocular Inspection"){
						AmbulationCell,
						WheelChairCell,
						CruchesCell,
						CaneCell,
						WalkerCell,
						AlertCell,
						CoherentCell,
						CooperativeCell,
						BodyTypeCell,
						AtrophyCell,
						SwellingCell, 
						RednessCell, 
						EcchymosisCell, 
						DeformityCell,
						WoundsCell,
						ScarCell, 
						PSoreCell, 
						GaitDevCell,
						IncisionCell, 
						ShortnessOfBreathingCell,txtOthers

					}
				
				}
			
			};
					
		}

	}

}


