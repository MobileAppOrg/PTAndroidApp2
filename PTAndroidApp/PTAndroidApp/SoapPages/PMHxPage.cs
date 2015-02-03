using System;
using Xamarin.Forms;
using PTAndroidApp.ValueConverters;
using System.Collections.Generic;
using XLabs.Forms.Controls;

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
			var CheckBoxTrauma = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand,};
			var txttrauma = new EntryCell  {IsEnabled = false, Placeholder = "Trauma"};

			var lblArthritis = new Label {FontSize = 18,Text = "   Arthritis", VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxArthritis =
				new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};

			List<string> ArthritisType = new List<string> (){ "RA","OA" };
			var ArthritisTypepicker = new Picker (){ Items = { "RA","OA" }, 
				Title = "Arthritis Type", IsVisible = false, HorizontalOptions = LayoutOptions.FillAndExpand };

			List<string> DM = new List<string> (){ "IDDM","NIDDM" };
			var DMpicker = new Picker (){IsVisible =false , Items = { "IDDM","NIDDM" }, 
				Title = "Select DM", HorizontalOptions = LayoutOptions.FillAndExpand };

			var lblDM = new Label {FontSize = 18,Text = "   DM", VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxDM =new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};


			var lblallergies = new Label {FontSize = 18, Text = "   Allergies", VerticalOptions = LayoutOptions.End};
			var CheckBoxAllergies = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};

			var lblAsthma  = new Label { Text  = "   Asthma", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxAsthma = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand };
			var Asthma = new EntryCell  { IsEnabled = false ,Placeholder  = "Date Ashtma"};

			var lblHPN = new Label {FontSize = 18, Text = "   HPN", VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxHPN = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};

			var lblSurgery  = new Label { Text  = "   Surgery", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxSurgery = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtSurgery = new EntryCell  {IsEnabled = false, Placeholder = "Surgical Procedure"};
			var dtSurgery = new EntryCell  {IsEnabled = false, Placeholder = "Surgery Date"};

			var lblHospitalization  = new Label { Text  = "   Hopitalization", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxHospitalization = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtHospitalization = new EntryCell  {IsEnabled = false,Placeholder = "Specification of Disease"};
			var HospitalizationDate = new EntryCell  { IsEnabled = false, Placeholder = "Hospitalization Date" };

			var lblCardiovascularDisease  = new Label { Text  = "   Cardiovascular Disease", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxCardiovascularDisease = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtCardiovascularDisease = new EntryCell (){Height = 50,Placeholder  = "Cardiovascular Disease" };

			var lblPulmonaryCondition  = new Label { Text  = "   Pulmonary Condition", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxPulmonaryCondition = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtPulmonaryCondition = new EntryCell (){Height = 50, Placeholder = "Pulmonary Condition" };

			var lblNeurologyCondition  = new Label { Text  = "   Neurology Condition", FontSize = 18, VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxNeurologyCondition = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};
			var txtNeurologyCondition = new EntryCell (){ Height = 50,Placeholder = "Neurology Condition" };
			//var txtCancer = new EntryCell (){Height = 50, Placeholder = "Cancer" };

			var lblCancer = new Label {FontSize = 18, Text = "   Cancer", VerticalOptions = LayoutOptions .EndAndExpand};
			var CheckBoxCancer = new CheckBox {VerticalOptions = LayoutOptions .EndAndExpand};


			var txtOthers = new EntryCell (){Height = 50, Placeholder = "Others" };

			ViewCell TraumaCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {Trauma, CheckBoxTrauma},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell ArthritisCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblArthritis,CheckBoxArthritis,ArthritisTypepicker},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};
					
			ViewCell DMCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblDM,CheckBoxDM,DMpicker},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell AllergiesCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblallergies,CheckBoxAllergies},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell AsthmaCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Orientation = StackOrientation.Horizontal ,
					Children = {lblAsthma,CheckBoxAsthma},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill}};

			ViewCell HPNCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblHPN,CheckBoxHPN},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell SurgeryCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblSurgery,CheckBoxSurgery},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};
					
			ViewCell HospitalizationCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblHospitalization,CheckBoxHospitalization},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell CardiovascularDiseaseCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblCardiovascularDisease,CheckBoxCardiovascularDisease},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell PulmonaryConditionCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblPulmonaryCondition,CheckBoxPulmonaryCondition},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			ViewCell NeurologyConditionCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblNeurologyCondition,CheckBoxNeurologyCondition},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};
				
			ViewCell CancerCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {lblCancer,CheckBoxCancer},
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.Fill,Orientation = StackOrientation.Horizontal}};

			CheckBoxTrauma.CheckedChanged += delegate 
			{	txttrauma .Text ="";
				if (CheckBoxTrauma.Checked)
				{txttrauma .IsEnabled = true;}
				else
				{txttrauma .IsEnabled = false ;}
			};

			CheckBoxArthritis.CheckedChanged += delegate 
			{	
				ArthritisTypepicker.SelectedIndex = -1;
				if (CheckBoxArthritis.Checked)
				{ArthritisTypepicker.IsVisible  = true;}
				else 
				{ArthritisTypepicker.IsVisible  = false ;}
			};

			CheckBoxDM.CheckedChanged += delegate 
			{	
				DMpicker.SelectedIndex = -1;
				if (CheckBoxDM.Checked)
				{DMpicker .IsVisible  = true;}
				else 
				{DMpicker.IsVisible  = false ;}
			};
				
			CheckBoxAsthma.CheckedChanged += delegate 
			{
				Asthma.Text = "";
				if (CheckBoxAsthma.Checked)
				{Asthma.IsEnabled   = true;}
				else 
				{Asthma.IsEnabled  = false ;}
			};
				
			CheckBoxSurgery.CheckedChanged += delegate 
			{	
				dtSurgery .Text = "";
				txtSurgery .Text = "";
				if (CheckBoxSurgery.Checked)
				{	dtSurgery.IsEnabled   = true;
					txtSurgery.IsEnabled = true;}
				else 
				{	dtSurgery.IsEnabled   = false ;
					txtSurgery.IsEnabled = false ;}
			};

			CheckBoxHospitalization.CheckedChanged += delegate 
			{	
				txtHospitalization .Text = "";
				HospitalizationDate .Text = "";
				if (CheckBoxHospitalization.Checked)
				{	txtHospitalization.IsEnabled   = true;
					HospitalizationDate.IsEnabled = true;}
				else 
				{	txtHospitalization.IsEnabled   = false ;
					HospitalizationDate.IsEnabled = false ;}
			};

			CheckBoxCardiovascularDisease.CheckedChanged += delegate 
			{	
				if (CheckBoxCardiovascularDisease.Checked)
				{	txtCardiovascularDisease.IsEnabled   = true;}
				else 
				{	txtCardiovascularDisease.IsEnabled   = false ;}
			};

			CheckBoxPulmonaryCondition.CheckedChanged += delegate 
			{	
				txtPulmonaryCondition .Text = "";
				if (CheckBoxPulmonaryCondition.Checked)
				{	txtPulmonaryCondition.IsEnabled   = true;}
				else 
				{	txtPulmonaryCondition.IsEnabled   = false ;}
			};
			CheckBoxNeurologyCondition.CheckedChanged += delegate 
			{	
				txtNeurologyCondition .Text = "";
				if (CheckBoxNeurologyCondition.Checked)
				{	txtNeurologyCondition.IsEnabled   = true;}
				else 
				{	txtNeurologyCondition.IsEnabled   = false; }
			};
			//bind 
			CheckBoxTrauma.SetBinding (CheckBox.CheckedProperty, "PMHx.Trauma", BindingMode.TwoWay);
			txttrauma.SetBinding (EntryCell.TextProperty, "PMHx.TraumaText", BindingMode.TwoWay);
	
			ArthritisTypepicker.SetBinding (Picker.SelectedIndexProperty, "PMHx.ArthritisText", 
			 	BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = ArthritisType  });
			CheckBoxArthritis.SetBinding (CheckBox.CheckedProperty, "PMHx.Arthritis", BindingMode.TwoWay);

			CheckBoxAsthma.SetBinding (CheckBox.CheckedProperty, "PMHx.Asthma", BindingMode.TwoWay);
			Asthma.SetBinding (EntryCell.TextProperty , "PMHx.AsthmaDate",  BindingMode.TwoWay,new StringToNullDateTimeConverter());

			CheckBoxHPN.SetBinding (CheckBox.CheckedProperty, "PMHx.HPN", BindingMode.TwoWay);

			DMpicker .SetBinding (Picker.SelectedIndexProperty, "PMHx.DMText", 
			BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = DM   });
			CheckBoxDM.SetBinding (CheckBox.CheckedProperty, "PMHx.DM", BindingMode.TwoWay);

			CheckBoxAllergies.SetBinding (CheckBox.CheckedProperty, "PMHx.Allergies", BindingMode.TwoWay);

			CheckBoxSurgery.SetBinding (CheckBox.CheckedProperty, "PMHx.Surgery", BindingMode.TwoWay);
			txtSurgery.SetBinding (EntryCell.TextProperty, "PMHx.SurgeryText", BindingMode.TwoWay);
			dtSurgery .SetBinding (EntryCell.TextProperty, "PMHx.SurgeryDate",BindingMode.TwoWay,new StringToNullDateTimeConverter());

			CheckBoxHospitalization.SetBinding (CheckBox.CheckedProperty, "PMHx.Hospitalization", BindingMode.TwoWay);
			txtHospitalization .SetBinding (EntryCell.TextProperty, "PMHx.HospitalizationText", BindingMode.TwoWay);
			HospitalizationDate.SetBinding (EntryCell.TextProperty, "PMHx.HospitalizationDate",BindingMode.TwoWay,new StringToNullDateTimeConverter());
		
			CheckBoxCardiovascularDisease.SetBinding (CheckBox.CheckedProperty, "PMHx.CardiovascularDisease", BindingMode.TwoWay);
			txtCardiovascularDisease .SetBinding (EntryCell.TextProperty, "PMHx.CardiovascularDiseaseText", BindingMode.TwoWay);

			CheckBoxPulmonaryCondition.SetBinding (CheckBox.CheckedProperty, "PMHx.PulmonaryCondition", BindingMode.TwoWay);
			txtPulmonaryCondition .SetBinding (EntryCell.TextProperty, "PMHx.PulmonaryConditionText", BindingMode.TwoWay);

			CheckBoxNeurologyCondition.SetBinding (CheckBox.CheckedProperty, "PMHx.NeurologyCondition", BindingMode.TwoWay);
			txtNeurologyCondition .SetBinding (EntryCell.TextProperty, "PMHx.NeurologyConditionText", BindingMode.TwoWay);

			CheckBoxCancer.SetBinding (CheckBox.CheckedProperty, "PMHx.Cancer", BindingMode.TwoWay);
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

