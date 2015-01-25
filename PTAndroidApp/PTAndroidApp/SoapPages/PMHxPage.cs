using System;
using Xamarin.Forms;
using PTAndroidApp.ValueConverters;
using System.Collections.Generic;


namespace PTAndroidApp
{
	public class PMHxPage:ContentPage
	{
		public PMHxPage(){
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

			var Trauma = new Label (){FontSize = 18, Text  = "Trauma", VerticalOptions = LayoutOptions .EndAndExpand };
			var switchTrauma = new Switch {VerticalOptions = LayoutOptions .EndAndExpand,};
			var txttrauma = new EntryCell  {Placeholder = "Trauma", IsEnabled = false};

			var lblArthritis = new Label {FontSize = 18,Text = "Arthritis", VerticalOptions = LayoutOptions .EndAndExpand};
			var switchArthritis = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			List<string> ArthritisType = new List<string> (){ "RA","OA" };
			var ArthritisTypepicker = new Picker (){ Items = { "RA","OA" }, 
				Title = "Arthritis Type", IsVisible = false, HorizontalOptions = LayoutOptions.FillAndExpand };

			List<string> DM = new List<string> (){ "IDDM","NIDDM" };
			var DMpicker = new Picker (){ Items = { "IDDM","NIDDM" }, 
				Title = "Select DM", HorizontalOptions = LayoutOptions.FillAndExpand };

			var lblallergies = new Label {FontSize = 18, Text = "Allergies", VerticalOptions = LayoutOptions .EndAndExpand};
			var switchAllergies = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};

			var lblAsthma  = new Label { Text  = "Asthma", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var switchAsthma = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var dtAsthma = new DatePicker {IsEnabled = false, Format = "D", HorizontalOptions = LayoutOptions .FillAndExpand };

			var lblHPN = new Label {FontSize = 18, Text = "HPN", VerticalOptions = LayoutOptions .EndAndExpand};
			var switchHPN = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};

			var lblSurgery  = new Label { Text  = "Surgery", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var switchSurgery = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtSurgery = new EntryCell  {IsEnabled = false, Placeholder = "Surgical Procedure"};
			var dtSurgery = new DatePicker  {IsEnabled = false, Format = "D", HorizontalOptions = LayoutOptions .FillAndExpand };

			var lblHospitalization  = new Label { Text  = "Hopitalization", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var switchHospitalization = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtHospitalization = new EntryCell  {IsEnabled = false,Placeholder = "Specification of Disease"};
			var dtHospitalization = new DatePicker  {IsEnabled = false,Format = "D", HorizontalOptions = LayoutOptions .FillAndExpand };

			var txtCardiovascularDisease = new EntryCell (){Height = 50,Placeholder  = "Cardiovascular Disease" };
			var txtPulmonaryCondition = new EntryCell (){Height = 50, Placeholder = "Pulmonary Condition" };
			var txtNeurologyCondition = new EntryCell (){ Height = 50,Placeholder = "Neurology Condition" };
			var txtCancer = new EntryCell (){Height = 50, Placeholder = "Cancer" };
			var txtOthers = new EntryCell (){Height = 50, Placeholder = "Others" };

			ViewCell TraumaCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {Trauma, switchTrauma},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell ArthritisCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblArthritis,switchArthritis,ArthritisTypepicker},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};
					
			ViewCell DMCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {DMpicker},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell AllergiesCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblallergies,switchAllergies},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell AsthmaCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblAsthma,switchAsthma},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell AsthmaCell2 = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {//new Label (){Text  = "Date", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand},
						dtAsthma},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell HPNCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblHPN,switchHPN},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell SurgeryCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblSurgery,switchSurgery},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell SurgeryCell2 = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {dtSurgery},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell HospitalizationCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblHospitalization,switchHospitalization},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell HospitalizationCell2 = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {dtHospitalization},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};


			switchTrauma.Toggled += delegate 
			{	txttrauma .Text = "";
				if (switchTrauma.IsToggled)
				{txttrauma .IsEnabled = true;}
				else
				{txttrauma .IsEnabled = false ;}
			};


			switchArthritis.Toggled += delegate 
			{	txttrauma .Text = "";
				if (switchArthritis.IsToggled)
				{ArthritisTypepicker.IsVisible  = true;}
				else 
				{ArthritisTypepicker.IsVisible  = false ;}
			};

			bool Allergies = false;
			switchAllergies.Toggled += delegate 
			{	
				Allergies= true;
			};

			switchAsthma.Toggled += delegate 
			{
				if (switchAsthma.IsToggled)
				{dtAsthma.IsEnabled   = true;}
				else 
				{dtAsthma.IsEnabled  = false ;}
			};

			switchHPN.Toggled += delegate 
			{	
			};

			switchSurgery.Toggled += delegate 
			{	
				if (switchSurgery.IsToggled)
				{	dtSurgery.IsEnabled   = true;
					txtSurgery.IsEnabled = true;}
				else 
				{	dtSurgery.IsEnabled   = false ;
					txtSurgery.IsEnabled = false ;}
			};

			switchHospitalization.Toggled += delegate 
			{	
				if (switchHospitalization.IsToggled)
				{	txtHospitalization.IsEnabled   = true;
					dtHospitalization.IsEnabled = true;}
				else 
				{	txtHospitalization.IsEnabled   = false ;
					dtHospitalization.IsEnabled = false ;}
			};


			//bind
			txttrauma.SetBinding (EntryCell.TextProperty, "Trauma", BindingMode.TwoWay);
			ArthritisTypepicker.SetBinding (Picker.SelectedIndexProperty, "Arthritis", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = ArthritisType  });
			DMpicker .SetBinding (Picker.SelectedIndexProperty, "DM", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = DM   });



			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("PMHx") {
						TraumaCell,txttrauma,
						ArthritisCell,
						AsthmaCell,AsthmaCell2,
						HPNCell,
						DMCell,
						AllergiesCell,
						SurgeryCell,txtSurgery,SurgeryCell2,
						HospitalizationCell,txtHospitalization,HospitalizationCell2,
						txtCardiovascularDisease,
						txtPulmonaryCondition,
						txtNeurologyCondition,
						txtCancer,
						txtOthers
					}
				}
			};

		}
	}
}

