using System;

using Xamarin.Forms;
using System.Collections.Generic;
using PTAndroidApp.ValueConverters;

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
			var switchAmbulation = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var switchWheelChair = new Switch {IsEnabled =false,VerticalOptions = LayoutOptions .EndAndExpand};
			//var switchCruches = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};

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

			var switchAlert = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var switchCoherent = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var switchCooperative = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};

			List<string> BodyType = new List<string> (){ "Endomorph","Mesomorph", "Ectomorph" };
			var BodyTypePicker = new Picker (){HorizontalOptions =LayoutOptions .FillAndExpand , Items = {  "Endomorph","Mesomorph", "Ectomorph" }, 
				Title = "Body Type" };

			var switchAtrophy = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtAthrophy = new EntryCell {IsEnabled = false, Placeholder = "Location" };

			var switchSwelling = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtSwelling = new EntryCell {IsEnabled = false, Placeholder = "Swelling" };

			var switchRedness = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtRedness = new EntryCell {IsEnabled = false, Placeholder = "Redness" };

			var switchEcchymosis = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtEcchymosis = new EntryCell {IsEnabled = false, Placeholder = "Ecchymosis" };

			var switchDeformity = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtDeformity = new EntryCell {IsEnabled = false, Placeholder = "Deformity" };

			var switchWounds = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtWounds = new EntryCell {IsEnabled = false, Placeholder = "Wounds" };

			var switchScar = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtScar = new EntryCell {IsEnabled = false, Placeholder = "Scar" };

			var switchPSore = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtPSore = new EntryCell {IsEnabled = false, Placeholder = "Pressure Sore" };

			var switchGaitDev = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};

			var switchIncision = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtIncision = new EntryCell {IsEnabled = false, Placeholder = "Incision" };
			var switchShortnessOfBreathing = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtOthers = new EntryCell {IsEnabled = false, Placeholder = "Others" };

			ViewCell AmbulationCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Ambulation", VerticalOptions = LayoutOptions .End },
						switchAmbulation},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};


			ViewCell WheelChairCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Wheel Chair:", VerticalOptions = LayoutOptions .End },
						switchWheelChair},
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
						switchAlert},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell CoherentCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Coherent", VerticalOptions = LayoutOptions .End },
						switchCoherent},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell CooperativeCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Cooperative", VerticalOptions = LayoutOptions .End },
						switchCooperative},
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
						switchAtrophy},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell SwellingCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Swelling", VerticalOptions = LayoutOptions .End },
						switchSwelling},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell RednessCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Redness", VerticalOptions = LayoutOptions .End },
						switchRedness},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell EcchymosisCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Ecchymosis", VerticalOptions = LayoutOptions .End },
						switchEcchymosis},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell DeformityCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Deformity", VerticalOptions = LayoutOptions .End },
						switchDeformity},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell WoundsCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Wounds", VerticalOptions = LayoutOptions .End },
						switchDeformity},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell ScarCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Scar", VerticalOptions = LayoutOptions .End },
						switchScar},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell PSoreCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Pressure Sore", VerticalOptions = LayoutOptions .End },
						switchPSore},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell GaitDevCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Gait Deviation", VerticalOptions = LayoutOptions .End },
						switchGaitDev},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell IncisionCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Incision", VerticalOptions = LayoutOptions .End },
						switchIncision},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell ShortnessOfBreathingCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label () {FontSize = 17, Text = "   Shortness Of Breathing", VerticalOptions = LayoutOptions .End },
						switchShortnessOfBreathing},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};
					

			switchAmbulation .Toggled += delegate   {
					//txtOtherCrunches .Text = "";
					//txtothersCane  .Text = "";
					//txtotherWalker  .Text = "";

					if (switchAmbulation .IsToggled ){
					TADCruchesPicker .IsEnabled = true;
					//txtOtherCrunches .IsEnabled = true;
					TADCanePicker  .IsEnabled = true;
					//txtothersCane  .IsEnabled = true;
					TADWalkerPicker  .IsEnabled = true;
					//txtotherWalker  .IsEnabled = true;
					switchWheelChair  .IsEnabled = true;
					}
					else{
					TADCruchesPicker .IsEnabled = false;
					//txtOtherCrunches .IsEnabled = false;
					TADCanePicker  .IsEnabled = false;
					//txtothersCane  .IsEnabled = false;
					TADWalkerPicker  .IsEnabled = false;
					//txtotherWalker  .IsEnabled = false;
					switchWheelChair  .IsEnabled = false;
					}
				};

			switchAtrophy.Toggled += delegate {
					txtAthrophy .Text = "";
					if (switchAtrophy.IsToggled ){
						txtAthrophy.IsEnabled = true;
					}
					else{
						txtAthrophy.IsEnabled = false ;
					}
				};
				switchSwelling .Toggled += delegate {
					txtSwelling .Text = "";
					if (switchSwelling .IsToggled ){
						txtSwelling.IsEnabled = true;
					}
					else{
						txtSwelling.IsEnabled = false ;
					}
				};
				switchRedness  .Toggled += delegate {
					txtRedness  .Text = "";
					if (switchRedness  .IsToggled ){
						txtRedness .IsEnabled = true;
					}
					else{
						txtRedness .IsEnabled = false ;
					}
				};
				switchEcchymosis   .Toggled += delegate {
					txtEcchymosis   .Text = "";
					if (switchEcchymosis   .IsToggled ){
						txtEcchymosis  .IsEnabled = true;
					}
					else{
						txtEcchymosis  .IsEnabled = false ;
					}
				};
				switchDeformity    .Toggled += delegate {
					txtDeformity   .Text = "";
					if (switchDeformity    .IsToggled ){
						txtDeformity  .IsEnabled = true;
					}
					else{
						txtDeformity  .IsEnabled = false ;
					}
				};
				switchWounds     .Toggled += delegate {
					txtWounds    .Text = "";
					if (switchWounds     .IsToggled ){
						txtWounds   .IsEnabled = true;
					}
					else{
						txtWounds   .IsEnabled = false ;
					}
				};
				switchScar.Toggled += delegate {
					txtScar     .Text = "";
					if (switchScar      .IsToggled ){
						txtScar    .IsEnabled = true;
					}
					else{
						txtScar    .IsEnabled = false ;
					}
				};
				switchPSore .Toggled += delegate {
					txtPSore      .Text = "";
					if (switchPSore       .IsToggled ){
						txtPSore     .IsEnabled = true;
					}
					else{
						txtPSore     .IsEnabled = false ;
					}
				};
				switchIncision  .Toggled += delegate {
					txtIncision       .Text = "";
					if (switchIncision        .IsToggled ){
						txtIncision      .IsEnabled = true;
					}
					else{
						txtIncision      .IsEnabled = false ;
					}
				};
		

			switchAmbulation.SetBinding (Switch.IsToggledProperty, "OcularInspection.Ambulation", BindingMode.TwoWay);
			switchWheelChair .SetBinding (Switch.IsToggledProperty, "OcularInspection.TADWheelChair", BindingMode.TwoWay);
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

			switchAlert  .SetBinding (Switch.IsToggledProperty, "OcularInspection.Alert", BindingMode.TwoWay);
			switchCoherent   .SetBinding (Switch.IsToggledProperty, "OcularInspection.Coherent", BindingMode.TwoWay);
			switchCooperative    .SetBinding (Switch.IsToggledProperty, "OcularInspection.Cooperative", BindingMode.TwoWay);
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
			switchGaitDev.SetBinding (Switch.IsToggledProperty, "OcularInspection.GaitDeviation", BindingMode.TwoWay);
			txtIncision .SetBinding (EntryCell.TextProperty, "OcularInspection.Incision", BindingMode.TwoWay);
			switchShortnessOfBreathing .SetBinding (Switch.IsToggledProperty, "OcularInspection.ShortnessOfBreathing", BindingMode.TwoWay);
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


