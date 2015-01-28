using System;
using Xamarin.Forms;
using PTAndroidApp.ValueConverters;
using System.Collections.Generic;


namespace PTAndroidApp
{
	public class PMHxPage:ContentPage
	{

		public PMHxPage(){

			Title = "PMHx";
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

			var Trauma = new Label (){FontSize = 18, Text  = "   Trauma", VerticalOptions = LayoutOptions .EndAndExpand };
			var switchTrauma = new Switch {VerticalOptions = LayoutOptions .EndAndExpand,};
			var txttrauma = new EntryCell  {IsEnabled = false, Placeholder = "Trauma"};

			var lblArthritis = new Label {FontSize = 18,Text = "   Arthritis", VerticalOptions = LayoutOptions .EndAndExpand};
			var switchArthritis =
				new Switch {VerticalOptions = LayoutOptions .EndAndExpand};

			List<string> ArthritisType = new List<string> (){ "RA","OA" };
			var ArthritisTypepicker = new Picker (){ Items = { "RA","OA" }, 
				Title = "Arthritis Type", IsVisible = false, HorizontalOptions = LayoutOptions.FillAndExpand };

			List<string> DM = new List<string> (){ "IDDM","NIDDM" };
			var DMpicker = new Picker (){IsVisible =false , Items = { "IDDM","NIDDM" }, 
				Title = "Select DM", HorizontalOptions = LayoutOptions.FillAndExpand };

			var lblDM = new Label {FontSize = 18,Text = "   DM", VerticalOptions = LayoutOptions .EndAndExpand};
			var switchDM =new Switch {VerticalOptions = LayoutOptions .EndAndExpand};


			var lblallergies = new Label {FontSize = 18, Text = "   Allergies", VerticalOptions = LayoutOptions.End};
			var switchAllergies = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};

			var lblAsthma  = new Label { Text  = "   Asthma", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var switchAsthma = new Switch {VerticalOptions = LayoutOptions .EndAndExpand };
			var Asthma = new EntryCell  { IsEnabled = false ,Placeholder  = "Date Ashtma"};

			var lblHPN = new Label {FontSize = 18, Text = "   HPN", VerticalOptions = LayoutOptions .EndAndExpand};
			var switchHPN = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};

			var lblSurgery  = new Label { Text  = "   Surgery", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var switchSurgery = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtSurgery = new EntryCell  {IsEnabled = false, Placeholder = "Surgical Procedure"};
			var dtSurgery = new EntryCell  {IsEnabled = false, Placeholder = "Surgery Date"};

			var lblHospitalization  = new Label { Text  = "   Hopitalization", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var switchHospitalization = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtHospitalization = new EntryCell  {IsEnabled = false,Placeholder = "Specification of Disease"};
			var HospitalizationDate = new EntryCell  { IsEnabled = false, Placeholder = "Hospitalization Date" };

			var lblCardiovascularDisease  = new Label { Text  = "   Cardiovascular Disease", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var switchCardiovascularDisease = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtCardiovascularDisease = new EntryCell (){Height = 50,Placeholder  = "Cardiovascular Disease" };

			var lblPulmonaryCondition  = new Label { Text  = "   Pulmonary Condition", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var switchPulmonaryCondition = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtPulmonaryCondition = new EntryCell (){Height = 50, Placeholder = "Pulmonary Condition" };
		
			var lblNeurologyCondition  = new Label { Text  = "   Neurology Condition", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var switchNeurologyCondition = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtNeurologyCondition = new EntryCell (){ Height = 50,Placeholder = "Neurology Condition" };
			//var txtCancer = new EntryCell (){Height = 50, Placeholder = "Cancer" };

			var lblCancer = new Label {FontSize = 18, Text = "   Cancer", VerticalOptions = LayoutOptions .EndAndExpand};
			var switchCancer = new Switch {VerticalOptions = LayoutOptions .EndAndExpand};


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
					Children = {lblDM,switchDM,DMpicker},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell AllergiesCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblallergies,switchAllergies},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell AsthmaCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Orientation = StackOrientation.Horizontal ,
					Children = {lblAsthma,switchAsthma},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

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
					
			ViewCell HospitalizationCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblHospitalization,switchHospitalization},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell CardiovascularDiseaseCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblCardiovascularDisease,switchCardiovascularDisease},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell PulmonaryConditionCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblPulmonaryCondition,switchPulmonaryCondition},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell NeurologyConditionCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblNeurologyCondition,switchNeurologyCondition},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};
				
			ViewCell CancerCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblCancer,switchCancer},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			switchTrauma.Toggled += delegate 
			{	txttrauma .Text ="";
				if (switchTrauma.IsToggled)
				{txttrauma .IsEnabled = true;}
				else
				{txttrauma .IsEnabled = false ;}
			};

			switchArthritis.Toggled += delegate 
			{	
				ArthritisTypepicker.SelectedIndex = -1;
				if (switchArthritis.IsToggled)
				{ArthritisTypepicker.IsVisible  = true;}
				else 
				{ArthritisTypepicker.IsVisible  = false ;}
			};

			switchDM.Toggled += delegate 
			{	
				DMpicker.SelectedIndex = -1;
				if (switchDM.IsToggled)
				{DMpicker .IsVisible  = true;}
				else 
				{DMpicker.IsVisible  = false ;}
			};
				
			switchAsthma.Toggled += delegate 
			{
				Asthma.Text = "";
				if (switchAsthma.IsToggled)
				{Asthma.IsEnabled   = true;}
				else 
				{Asthma.IsEnabled  = false ;}
			};
				
			switchSurgery.Toggled += delegate 
			{	
				dtSurgery .Text = "";
				txtSurgery .Text = "";
				if (switchSurgery.IsToggled)
				{	dtSurgery.IsEnabled   = true;
					txtSurgery.IsEnabled = true;}
				else 
				{	dtSurgery.IsEnabled   = false ;
					txtSurgery.IsEnabled = false ;}
			};

			switchHospitalization.Toggled += delegate 
			{	
				txtHospitalization .Text = "";
				HospitalizationDate .Text = "";
				if (switchHospitalization.IsToggled)
				{	txtHospitalization.IsEnabled   = true;
					HospitalizationDate.IsEnabled = true;}
				else 
				{	txtHospitalization.IsEnabled   = false ;
					HospitalizationDate.IsEnabled = false ;}
			};

			switchCardiovascularDisease.Toggled += delegate 
			{	
				if (switchCardiovascularDisease.IsToggled)
				{	txtCardiovascularDisease.IsEnabled   = true;}
				else 
				{	txtCardiovascularDisease.IsEnabled   = false ;}
			};

			switchPulmonaryCondition.Toggled += delegate 
			{	
				txtPulmonaryCondition .Text = "";
				if (switchPulmonaryCondition.IsToggled)
				{	txtPulmonaryCondition.IsEnabled   = true;}
				else 
				{	txtPulmonaryCondition.IsEnabled   = false ;}
			};
			switchNeurologyCondition.Toggled += delegate 
			{	
				txtNeurologyCondition .Text = "";
				if (switchNeurologyCondition.IsToggled)
				{	txtNeurologyCondition.IsEnabled   = true;}
				else 
				{	txtNeurologyCondition.IsEnabled   = false; }
			};
			//bind 
			switchTrauma.SetBinding (Switch.IsToggledProperty, "PMHx.Trauma", BindingMode.TwoWay);
			txttrauma.SetBinding (EntryCell.TextProperty, "PMHx.TraumaText", BindingMode.TwoWay);
	
			ArthritisTypepicker.SetBinding (Picker.SelectedIndexProperty, "PMHx.ArthritisText", 
			 	BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = ArthritisType  });
			switchArthritis.SetBinding (Switch.IsToggledProperty, "PMHx.Arthritis", BindingMode.TwoWay);

			switchAsthma.SetBinding (Switch.IsToggledProperty, "PMHx.Asthma", BindingMode.TwoWay);
			Asthma.SetBinding (EntryCell.TextProperty , "PMHx.AsthmaDate",  BindingMode.TwoWay,new StringToNullDateTimeConverter());

			switchHPN.SetBinding (Switch.IsToggledProperty, "PMHx.HPN", BindingMode.TwoWay);

			DMpicker .SetBinding (Picker.SelectedIndexProperty, "PMHx.DMText", 
			BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = DM   });
			switchDM.SetBinding (Switch.IsToggledProperty, "PMHx.DM", BindingMode.TwoWay);

			switchAllergies.SetBinding (Switch.IsToggledProperty, "PMHx.Allergies", BindingMode.TwoWay);

			switchSurgery.SetBinding (Switch.IsToggledProperty, "PMHx.Surgery", BindingMode.TwoWay);
			txtSurgery.SetBinding (EntryCell.TextProperty, "PMHx.SurgeryText", BindingMode.TwoWay);
			dtSurgery .SetBinding (EntryCell.TextProperty, "PMHx.SurgeryDate",BindingMode.TwoWay,new StringToNullDateTimeConverter());

			switchHospitalization.SetBinding (Switch.IsToggledProperty, "PMHx.Hospitalization", BindingMode.TwoWay);
			txtHospitalization .SetBinding (EntryCell.TextProperty, "PMHx.HospitalizationText", BindingMode.TwoWay);
			HospitalizationDate.SetBinding (EntryCell.TextProperty, "PMHx.HospitalizationDate",BindingMode.TwoWay,new StringToNullDateTimeConverter());
		
			switchCardiovascularDisease.SetBinding (Switch.IsToggledProperty, "PMHx.CardiovascularDisease", BindingMode.TwoWay);
			txtCardiovascularDisease .SetBinding (EntryCell.TextProperty, "PMHx.CardiovascularDiseaseText", BindingMode.TwoWay);

			switchPulmonaryCondition.SetBinding (Switch.IsToggledProperty, "PMHx.PulmonaryCondition", BindingMode.TwoWay);
			txtPulmonaryCondition .SetBinding (EntryCell.TextProperty, "PMHx.PulmonaryConditionText", BindingMode.TwoWay);

			switchNeurologyCondition.SetBinding (Switch.IsToggledProperty, "PMHx.NeurologyCondition", BindingMode.TwoWay);
			txtNeurologyCondition .SetBinding (EntryCell.TextProperty, "PMHx.NeurologyConditionText", BindingMode.TwoWay);

			switchCancer.SetBinding (Switch.IsToggledProperty, "PMHx.Cancer", BindingMode.TwoWay);
			txtOthers  .SetBinding (EntryCell.TextProperty, "PMHx.Others", BindingMode.TwoWay);

			return new TableView () {
				//HasUnevenRows = true,
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("PMHx") {
						TraumaCell,txttrauma,
						ArthritisCell,
						AsthmaCell,Asthma,
						HPNCell,
						DMCell,
						AllergiesCell,
						SurgeryCell,txtSurgery,dtSurgery,
						HospitalizationCell,txtHospitalization,HospitalizationDate,
						CardiovascularDiseaseCell,txtCardiovascularDisease,
						PulmonaryConditionCell,txtPulmonaryCondition,
						NeurologyConditionCell,txtNeurologyCondition,
						CancerCell,
						txtOthers
					}
				}
			};

		}
	}
}

