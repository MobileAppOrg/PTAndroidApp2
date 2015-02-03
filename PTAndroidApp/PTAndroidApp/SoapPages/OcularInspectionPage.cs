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
			var CheckBoxWheelChair = new CheckBox {IsEnabled =false,VerticalOptions = LayoutOptions .EndAndExpand};
			//var CheckBoxCruches = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};

			List<string> TADCruches = new List<string> (){ "Axillary","Lofstrand", "Forearm" };

			var TADCruchesPicker = new Picker (){IsEnabled =false, Items = { "Axillary","Lofstrand", "Forearm" }, 
				Title = "Crutches", HorizontalOptions = LayoutOptions.FillAndExpand  };
			//var txtOtherCrunches = new Entry{HorizontalOptions = LayoutOptions .FillAndExpand , IsEnabled = false, Placeholder = "Other Type" };


			List<string> TADCane = new List<string> (){ "Standard","Quad", "Crook" };
			var TADCanePicker = new Picker (){IsEnabled =false, Items = { "Standard","Quad", "Crook" }, 
				Title = "Cane", HorizontalOptions = LayoutOptions.FillAndExpand  };
			//var txtothersCane = new Entry{HorizontalOptions = LayoutOptions .FillAndExpand ,IsEnabled = false, Placeholder = "Other Type" };

			List<string> TADWalker = new List<string> (){ "Standard","Rolling" };
			var TADWalkerPicker = new Picker (){IsEnabled =false, Items = { "Standard","Rolling" }, 
				Title = "Walker", HorizontalOptions = LayoutOptions.FillAndExpand  };
			//var txtotherWalker = new Entry{HorizontalOptions = LayoutOptions .FillAndExpand ,IsEnabled = false, Placeholder = "Other Type" };

			var CheckBoxAlert = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxCoherent = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxCooperative = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};

			List<string> BodyType = new List<string> (){ "Endomorph","Mesomorph", "Ectomorph" };
			var BodyTypePicker = new Picker (){HorizontalOptions =LayoutOptions .FillAndExpand , Items = {  "Endomorph","Mesomorph", "Ectomorph" }, 
				Title = "Body Type" };

			var CheckBoxAtrophy = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtAthrophy = new EntryCell {IsEnabled = false, Placeholder = "Location" };

			var CheckBoxSwelling = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtSwelling = new EntryCell {IsEnabled = false, Placeholder = "Swelling" };

			var CheckBoxRedness = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtRedness = new EntryCell {IsEnabled = false, Placeholder = "Redness" };

			var CheckBoxEcchymosis = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtEcchymosis = new EntryCell {IsEnabled = false, Placeholder = "Ecchymosis" };

			var CheckBoxDeformity = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtDeformity = new EntryCell {IsEnabled = false, Placeholder = "Deformity" };

			var CheckBoxWounds = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtWounds = new EntryCell {IsEnabled = false, Placeholder = "Wounds" };

			var CheckBoxScar = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtScar = new EntryCell {IsEnabled = false, Placeholder = "Scar" };

			var CheckBoxPSore = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtPSore = new EntryCell {IsEnabled = false, Placeholder = "Pressure Sore" };

			var CheckBoxGaitDev = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};

			var CheckBoxIncision = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtIncision = new EntryCell {IsEnabled = false, Placeholder = "Incision" };
			var CheckBoxShortnessOfBreathing = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtOthers = new EntryCell { Placeholder = "Others" };

			ViewCell AmbulationCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Ambulation", VerticalOptions = LayoutOptions .End },
						CheckBoxAmbulation},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};


			ViewCell WheelChairCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Wheel Chair:", VerticalOptions = LayoutOptions .End },
						CheckBoxWheelChair},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell CruchesCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {new Label () {FontSize = 17, Text = "   Crutches:", VerticalOptions = LayoutOptions .End },
						TADCruchesPicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};
		
			ViewCell CaneCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {new Label () {FontSize = 17, Text = "   Cane:", VerticalOptions = LayoutOptions .End },
						TADCanePicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};


			ViewCell WalkerCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {new Label () {FontSize = 17, Text = "   Walker:", VerticalOptions = LayoutOptions .End },
						TADWalkerPicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};


			ViewCell AlertCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Alert", VerticalOptions = LayoutOptions .End },
						CheckBoxAlert},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell CoherentCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Coherent", VerticalOptions = LayoutOptions .End },
						CheckBoxCoherent},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell CooperativeCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Cooperative", VerticalOptions = LayoutOptions .End },
						CheckBoxCooperative},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell BodyTypeCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Body Type", VerticalOptions = LayoutOptions .End },
						BodyTypePicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell AtrophyCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Atrophy", VerticalOptions = LayoutOptions .End },
						CheckBoxAtrophy},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell SwellingCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Swelling", VerticalOptions = LayoutOptions .End },
						CheckBoxSwelling},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell RednessCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Redness", VerticalOptions = LayoutOptions .End },
						CheckBoxRedness},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell EcchymosisCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Ecchymosis", VerticalOptions = LayoutOptions .End },
						CheckBoxEcchymosis},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell DeformityCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Deformity", VerticalOptions = LayoutOptions .End },
						CheckBoxDeformity},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell WoundsCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Wounds", VerticalOptions = LayoutOptions .End },
						CheckBoxWounds},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell ScarCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Scar", VerticalOptions = LayoutOptions .End },
						CheckBoxScar},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell PSoreCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Pressure Sore", VerticalOptions = LayoutOptions .End },
						CheckBoxPSore},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell GaitDevCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Gait Deviation", VerticalOptions = LayoutOptions .End },
						CheckBoxGaitDev},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell IncisionCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Incision", VerticalOptions = LayoutOptions .End },
						CheckBoxIncision},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell ShortnessOfBreathingCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Shortness Of Breathing", VerticalOptions = LayoutOptions .End },
						CheckBoxShortnessOfBreathing},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};
					

			CheckBoxAmbulation .CheckedChanged += delegate   {
					//txtOtherCrunches .Text = "";
					//txtothersCane  .Text = "";
					//txtotherWalker  .Text = "";

					if (CheckBoxAmbulation .Checked ){
					TADCruchesPicker .IsEnabled = true;
					//txtOtherCrunches .IsEnabled = true;
					TADCanePicker  .IsEnabled = true;
					//txtothersCane  .IsEnabled = true;
					TADWalkerPicker  .IsEnabled = true;
					//txtotherWalker  .IsEnabled = true;
					CheckBoxWheelChair  .IsEnabled = true;
					}
					else{
					TADCruchesPicker .IsEnabled = false;
					//txtOtherCrunches .IsEnabled = false;
					TADCanePicker  .IsEnabled = false;
					//txtothersCane  .IsEnabled = false;
					TADWalkerPicker  .IsEnabled = false;
					//txtotherWalker  .IsEnabled = false;
					CheckBoxWheelChair  .IsEnabled = false;
					}
				};

			CheckBoxAtrophy.CheckedChanged += delegate {
					txtAthrophy .Text = "";
					if (CheckBoxAtrophy.Checked ){
						txtAthrophy.IsEnabled = true;
					}
					else{
						txtAthrophy.IsEnabled = false ;
					}
				};

			CheckBoxSwelling .CheckedChanged += delegate {
					txtSwelling .Text = "";
				if (CheckBoxSwelling .Checked ){
						txtSwelling.IsEnabled = true;
					}
					else{
						txtSwelling.IsEnabled = false ;
					}
				};

			CheckBoxRedness  .CheckedChanged += delegate {
					txtRedness  .Text = "";
				if (CheckBoxRedness  .Checked ){
						txtRedness .IsEnabled = true;
					}
					else{
						txtRedness .IsEnabled = false ;
					}
				};

			CheckBoxEcchymosis   .CheckedChanged += delegate {
					txtEcchymosis   .Text = "";
				if (CheckBoxEcchymosis   .Checked ){
						txtEcchymosis  .IsEnabled = true;
					}
					else{
						txtEcchymosis  .IsEnabled = false ;
					}
				};

			CheckBoxDeformity    .CheckedChanged += delegate {
					txtDeformity   .Text = "";
				if (CheckBoxDeformity .Checked ){
						txtDeformity  .IsEnabled = true;
					}
					else{
						txtDeformity  .IsEnabled = false ;
					}
				};

			CheckBoxWounds.CheckedChanged += delegate {
					txtWounds .Text = "";
				if (CheckBoxWounds .Checked ){
						txtWounds   .IsEnabled = true;
					}
					else{
						txtWounds   .IsEnabled = false ;
					}

				};

			CheckBoxScar.CheckedChanged += delegate {
					txtScar     .Text = "";
				if (CheckBoxScar      .Checked ){
						txtScar    .IsEnabled = true;
					}
					else{
						txtScar    .IsEnabled = false ;
					}
				};

			CheckBoxPSore.CheckedChanged += delegate {
					txtPSore.Text = "";
				if (CheckBoxPSore .Checked ){
						txtPSore.IsEnabled = true;
					}
					else{
						txtPSore.IsEnabled = false ;
					}
				};

			CheckBoxIncision.CheckedChanged += delegate {
					txtIncision.Text = "";
				if (CheckBoxIncision.Checked ){
						txtIncision.IsEnabled = true;
					}
					else{
						txtIncision.IsEnabled = false ;
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
						AtrophyCell,txtAthrophy,
						SwellingCell,  txtSwelling,
						RednessCell, txtRedness,
						EcchymosisCell, txtEcchymosis,
						DeformityCell, txtDeformity,
						WoundsCell, txtWounds,
						ScarCell, txtScar,
						PSoreCell, txtPSore,
						GaitDevCell,
						IncisionCell, txtIncision,
						ShortnessOfBreathingCell,txtOthers

					}
				
				}
			
			};
					
		}

	}

}


