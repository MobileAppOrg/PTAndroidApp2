using System;

using Xamarin.Forms;
using System.Collections.Generic;
using PTAndroidApp.ValueConverters;
using XLabs.Forms.Controls;
namespace PTAndroidApp
{
	public class PalpationPage : ContentPage
	{
		public PalpationPage ()
		{
			TableView  table = CreateTable ();
			Content = new StackLayout { 
				Children = {
					table
				}
			};
		}




		static TableView CreateTable () {

			List<string> BodyTemperature = new List<string> (){ "Hypothermic","Normothermic","Hyperthermic" };
			var BodyTemperaturePicker = new Picker (){VerticalOptions = LayoutOptions .End, Items = { "Hypothermic","Normothermic","Hyperthermic" }, 
				Title = "Body Temperature",  HorizontalOptions = LayoutOptions.FillAndExpand  };
			var CheckBoxBodyTemperature =new Button  { Text = "Clear", VerticalOptions = LayoutOptions .End};

			List<string> MuscleTone = new List<string> (){ "Hypotonic","Normotonic","tHypertonic" };
			var MuscleTonePicker = new Picker (){ VerticalOptions = LayoutOptions .End,Items = { "Hypotonic","Normotonic","tHypertonic" }, 
				Title = "Muscle Tone" , HorizontalOptions = LayoutOptions.FillAndExpand  };
			var CheckBoxMuscleTone =new Button { Text = "Clear",VerticalOptions = LayoutOptions .End};

			List<string> Edema = new List<string> (){ "Non-pitting","Pitting"};
			var EdemaPicker = new Picker (){VerticalOptions = LayoutOptions .End, Items = { "Non-pitting","Pitting" }, 
				Title = "Edema", HorizontalOptions = LayoutOptions.FillAndExpand   };
			var CheckBoxEdema =new Button{Text = "Clear", VerticalOptions = LayoutOptions .End};

			List<string> Tenderness = new List<string> (){ "Grade 1","Grade 2","Grade 3","Grade 4","Grade 5"};
			var TendernessPicker = new Picker (){VerticalOptions = LayoutOptions .End, Items = { "Grade 1","Grade 2","Grade 3","Grade 4","Grade 5" }, 
				Title = "Tenderness",  HorizontalOptions = LayoutOptions.FillAndExpand   };
			var CheckBoxTenderness =new Button {Text = "Clear", VerticalOptions = LayoutOptions .End};

			var txtLocation = new EntryCell {  IsEnabled = true , Placeholder = "Location" };

			//var CheckBoxDeformity =new  Button{Text = "Clear", VerticalOptions = LayoutOptions .End};
			var txtDeformity = new EntryCell { Placeholder = "Deformity" };

			var CheckBoxMuscleGuarding =new CheckBox { VerticalOptions = LayoutOptions .End};
			var CheckBoxMuscleSpasm =new CheckBox { VerticalOptions = LayoutOptions .End};
			var CheckBoxSubluxation =new CheckBox { VerticalOptions = LayoutOptions .End};
			var CheckBoxDislocation =new CheckBox { VerticalOptions = LayoutOptions .End};

			ViewCell BodyTemperatureCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = { BodyTemperaturePicker,CheckBoxBodyTemperature},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};

			ViewCell MuscleToneCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = { MuscleTonePicker, CheckBoxMuscleTone},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};

			ViewCell EdemaCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = { EdemaPicker,CheckBoxEdema},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};

			ViewCell TendernessCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {TendernessPicker,CheckBoxTenderness},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};

//			ViewCell DeformityCell = new ViewCell{
//				Height = 100,
//				View = new StackLayout(){
//					Children = {new Label (){FontSize = 18, VerticalOptions = LayoutOptions .End , Text = "   Deformity              "},
//							//CheckBoxDeformity
//					},Orientation = StackOrientation.Horizontal  ,
//					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};
//		
			ViewCell MuscleGuardingCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {CheckBoxMuscleGuarding,new Label (){HorizontalOptions = LayoutOptions.Fill, FontSize = 18, VerticalOptions = LayoutOptions .End , Text = "   Muscle Guarding"},
						},Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};

			ViewCell MuscleSpasmCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {CheckBoxMuscleSpasm,new Label (){HorizontalOptions = LayoutOptions.Fill, FontSize = 18, VerticalOptions = LayoutOptions .End , Text = "   Muscle Spasm    "},
						},Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};
		
			ViewCell SubluxationCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {CheckBoxSubluxation,new Label (){HorizontalOptions = LayoutOptions.Fill, FontSize = 18, VerticalOptions = LayoutOptions .End , Text = "   Subluxation          "},
						},Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};

			ViewCell DislocationCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {CheckBoxDislocation,new Label (){HorizontalOptions = LayoutOptions.Fill, FontSize = 18, VerticalOptions = LayoutOptions .End , Text = "   Dislocation           "},
						},Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};



			CheckBoxBodyTemperature.Clicked +=  delegate
			{	
				BodyTemperaturePicker.SelectedIndex = -1;
//				if (CheckBoxBodyTemperature.Checked)
//				{BodyTemperaturePicker.IsEnabled   = true;}
//				else 
//				{BodyTemperaturePicker.IsEnabled  = false ;}
			};

			CheckBoxMuscleTone.Clicked  += delegate 
			{	
				MuscleTonePicker.SelectedIndex = -1;
//				if (CheckBoxMuscleTone.Checked)
//				{MuscleTonePicker.IsEnabled   = true;}
//				else 
//				{MuscleTonePicker.IsEnabled  = false ;}
			};

			CheckBoxEdema.Clicked += delegate 
			{	
				EdemaPicker.SelectedIndex = -1;
//				if (CheckBoxEdema.Checked)
//				{EdemaPicker.IsEnabled   = true;}
//				else 
//				{EdemaPicker.IsEnabled  = false ;}
			};

			CheckBoxTenderness.Clicked += delegate 
			{	
				TendernessPicker.SelectedIndex = -1;
//				if (CheckBoxTenderness.Checked)
//				{TendernessPicker.IsEnabled   = true;}
//				else 
//				{TendernessPicker.IsEnabled  = false ;}
			};

//			CheckBoxDeformity.Clicked += delegate 
//			{	
//				txtDeformity.Text ="";
////				if (CheckBoxDeformity.Checked)
////				{txtDeformity.IsEnabled   = true;}
////				else 
////				{txtDeformity.IsEnabled  = false ;}
//			};


			BodyTemperaturePicker .SetBinding (Picker.SelectedIndexProperty, "Palpation.BodyTemperature", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = BodyTemperature   });

			MuscleTonePicker .SetBinding (Picker.SelectedIndexProperty, "Palpation.MuscleTone", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = MuscleTone   });

			EdemaPicker .SetBinding (Picker.SelectedIndexProperty, "Palpation.Edema", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = Edema    });

			TendernessPicker .SetBinding (Picker.SelectedIndexProperty, "Palpation.Tenderness", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = Tenderness    });

			txtLocation.SetBinding (EntryCell.TextProperty, "Palpation.Location", BindingMode.TwoWay);
			txtDeformity.SetBinding (EntryCell.TextProperty, "Palpation.Deformity", BindingMode.TwoWay);
			CheckBoxMuscleGuarding.SetBinding (CheckBox.CheckedProperty, "Palpation.MuscleGuarding", BindingMode.TwoWay);
			CheckBoxMuscleSpasm.SetBinding (CheckBox.CheckedProperty, "Palpation.MuscleSpasm", BindingMode.TwoWay);
			CheckBoxSubluxation.SetBinding (CheckBox.CheckedProperty, "Palpation.Subluxation", BindingMode.TwoWay);
			CheckBoxDislocation.SetBinding (CheckBox.CheckedProperty, "Palpation.Dislocation", BindingMode.TwoWay);


			return new TableView () {
				Intent = TableIntent.Form ,
				//HasUnevenRows = true,
				Root = new TableRoot (){
					new TableSection ("Palpation Page"){
					
						BodyTemperatureCell,
						MuscleToneCell,
						EdemaCell,
						TendernessCell,txtLocation,
						//DeformityCell, 
						txtDeformity,
						MuscleGuardingCell,
						MuscleSpasmCell,
						SubluxationCell,
						DislocationCell

					}

				}

			};
		}


	}
}


