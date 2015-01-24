using System;

using Xamarin.Forms;

namespace PTAndroidApp
{
	public class PMHxPage : ContentPage
	{
		public PMHxPage ()
		{
			var trauma = traumas ();
			var athritis = Arthritis ();
			var dm = DM ();
			var allergies = Allergies ();
			var surgery = Surgery ();
			var surgery2 = Surgery2 ();
			var hospitalization = Hospitalization ();
			var hospitalization2 = Hospitalization2 ();
			var cardiovascularDisease = CardiovascularDisease ();
			var pulmonaryCondition = PulmonaryCondition ();
			var neurologyCondition = NeurologyCondition ();
			var cancer = Cancer ();
			var others = Others ();

			var pmhxcontrols = new ScrollView {
				Content = new StackLayout {
					Children = { trauma, athritis, dm, allergies, surgery, surgery2,
						hospitalization, hospitalization2, cardiovascularDisease,
						pulmonaryCondition, neurologyCondition, cancer, others}
				}
			};
			Content = new StackLayout {
				Children = { pmhxcontrols }
			};
		}

		static StackLayout traumas ()
		{
			var lbltrauma = new Label {
				Text = "Trauma", FontSize = 17,
				VerticalOptions = LayoutOptions .EndAndExpand };

			var switchTrauma = new Switch {
				VerticalOptions = LayoutOptions .EndAndExpand,
			};

			var txttrauma = new Entry {
				Placeholder = "Trauma",
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			var traumaRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = {  lbltrauma, switchTrauma, txttrauma }
			};
			return traumaRow;
		}


		static StackLayout Arthritis  ()
		{
			var lblAthritis = new Label {
				Text = "Arthritis"
			};
			var switchAthritis = new Switch {
			};

			var ArthritisRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal  ,
				Children = { lblAthritis, switchAthritis  }
			};

			return ArthritisRow;
		}

		static StackLayout DM()
		{
			var pckDM = new Picker () { Items = { "IDDM", "NIDDM", }, 
				Title = "Select DM", 
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			var DMrow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = {pckDM}
			};
			return DMrow;
		}

		static StackLayout Allergies ()
		{
			var lblallergies = new Label {
				Text = "Allergies"};
			var switchAllergies = new Switch {
			};
			var AllergiesRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { lblallergies, switchAllergies }
			};

			return AllergiesRow;
		}

		static StackLayout Surgery ()
		{
			var lblSurgery = new Label {
				Text = "Surgery"};

			var dtSurgery = new DatePicker {
				Format = "D",

			};
			var SurgerysRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { lblSurgery,dtSurgery,}
			};
			return SurgerysRow;
		}

		static StackLayout Surgery2 ()
		{
			var txtSurgery = new Entry {
				Placeholder = "Surgical Procedure",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			var SurgerysRow= new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = {txtSurgery}
			};
			return SurgerysRow;
		}

		static StackLayout Hospitalization ()
		{
			var lblHospitalization = new Label {
				Text = "Hospitalization"};

			var dtHospitalization = new DatePicker {
				Format = "D",
			};
			var HospitalizationRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { lblHospitalization,dtHospitalization,}
			};
			return HospitalizationRow;
		}

		static StackLayout Hospitalization2 ()
		{
			var txtHospitalization = new Entry {
				Placeholder = "Specification of disease",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			var Hospitalization2Row= new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { txtHospitalization}
			};
			return Hospitalization2Row;
		}

		static StackLayout CardiovascularDisease ()
		{
			var lblCardiovascularDisease = new Label {
				Text = "Cardiovascular Disease"};

			var txtCardiovascularDisease = new Entry  {
				Placeholder = "Cardiovascular Disease"
			};

			var CardiovascularDiseaseRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { lblCardiovascularDisease,txtCardiovascularDisease}
			};
			return CardiovascularDiseaseRow;
		}

		static StackLayout PulmonaryCondition ()
		{
			var lblPulmonaryCondition = new Label {
				Text = "Pulmonary Condition"};

			var txtPulmonaryCondition = new Entry  {
				Placeholder = "Pulmonary Condition"
			};

			var PulmonaryConditionRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { lblPulmonaryCondition,txtPulmonaryCondition}
			};
			return PulmonaryConditionRow;
		}

		static StackLayout NeurologyCondition ()
		{
			var lblNeurologyCondition = new Label {
				Text = "Neurology Condition"};

			var txtNeurologyCondition = new Entry  {
				Placeholder = "Neurology Condition"
			};

			var NeurologyConditionRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand ,
				Orientation = StackOrientation.Horizontal,
				Children = { lblNeurologyCondition,txtNeurologyCondition}
			};
			return NeurologyConditionRow;
		}

		static StackLayout Cancer  ()
		{
			var lblCancer = new Label {
				Text = "Cancer"
			};
			var switchCancer = new Switch {
			};

			var CancerRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal  ,
				Children = { lblCancer, switchCancer  }
			};
			return CancerRow;
		}

		static StackLayout Others  ()
		{
			var lblOthers = new Label {
				Text = "Others"
			};
			var txtOthers = new Entry  {
				Placeholder = "Specify others",
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			var OthersRow = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal  ,
				Children = { lblOthers, txtOthers  }
			};

			return OthersRow;
		
		}
	}
}


