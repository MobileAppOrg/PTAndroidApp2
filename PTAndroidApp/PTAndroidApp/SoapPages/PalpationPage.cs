using System;

using Xamarin.Forms;
using System.Collections.Generic;
using PTAndroidApp.ValueConverters;

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
				Title = "Body Temperature", IsEnabled = false  , HorizontalOptions = LayoutOptions.FillAndExpand  };
			var switchBodyTemperature =new Switch { VerticalOptions = LayoutOptions .End};

			List<string> MuscleTone = new List<string> (){ "Hypotonic","Normotonic","tHypertonic" };
			var MuscleTonePicker = new Picker (){ VerticalOptions = LayoutOptions .End,Items = { "Hypotonic","Normotonic","tHypertonic" }, 
				Title = "Muscle Tone", IsEnabled = false  , HorizontalOptions = LayoutOptions.FillAndExpand  };
			var switchMuscleTone =new Switch { VerticalOptions = LayoutOptions .End};

			List<string> Edema = new List<string> (){ "Non-pitting","Pitting"};
			var EdemaPicker = new Picker (){VerticalOptions = LayoutOptions .End, Items = { "Non-pitting","Pitting" }, 
				Title = "Edema", IsEnabled = false  , HorizontalOptions = LayoutOptions.FillAndExpand   };
			var switchEdema =new Switch{ VerticalOptions = LayoutOptions .End};

			List<string> Tenderness = new List<string> (){ "Grade 1","Grade 2","Grade 3","Grade 4","Grade 5"};
			var TendernessPicker = new Picker (){VerticalOptions = LayoutOptions .End, Items = { "Grade 1","Grade 2","Grade 3","Grade 4","Grade 5" }, 
				Title = "Tenderness", IsEnabled = false  , HorizontalOptions = LayoutOptions.FillAndExpand   };
			var switchTenderness =new Switch { VerticalOptions = LayoutOptions .End};

			var txtLocation = new EntryCell {  IsEnabled = true , Placeholder = "Location" };

			var switchDeformity =new  Switch{ VerticalOptions = LayoutOptions .End};
			var txtDeformity = new EntryCell {IsEnabled = false, Placeholder = "Deformity" };

			var switchMuscleGuarding =new Switch { VerticalOptions = LayoutOptions .End};
			var switchMuscleSpasm =new Switch { VerticalOptions = LayoutOptions .End};
			var switchSubluxation =new Switch { VerticalOptions = LayoutOptions .End};
			var switchDislocation =new Switch { VerticalOptions = LayoutOptions .End};

			ViewCell BodyTemperatureCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {switchBodyTemperature, BodyTemperaturePicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};

			ViewCell MuscleToneCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {switchMuscleTone, MuscleTonePicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};

			ViewCell EdemaCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {switchEdema, EdemaPicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};

			ViewCell TendernessCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {switchTenderness,TendernessPicker},
					Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};

			ViewCell DeformityCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {new Label (){FontSize = 18, VerticalOptions = LayoutOptions .End , Text = "   Deformity              "},
							switchDeformity},Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};
		
			ViewCell MuscleGuardingCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {new Label (){HorizontalOptions = LayoutOptions.Fill, FontSize = 18, VerticalOptions = LayoutOptions .End , Text = "   Muscle Guarding"},
						switchMuscleGuarding},Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};

			ViewCell MuscleSpasmCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {new Label (){HorizontalOptions = LayoutOptions.Fill, FontSize = 18, VerticalOptions = LayoutOptions .End , Text = "   Muscle Spasm    "},
						switchMuscleSpasm},Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};
		
			ViewCell SubluxationCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {new Label (){HorizontalOptions = LayoutOptions.Fill, FontSize = 18, VerticalOptions = LayoutOptions .End , Text = "   Subluxation          "},
						switchSubluxation},Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};

			ViewCell DislocationCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {new Label (){HorizontalOptions = LayoutOptions.Fill, FontSize = 18, VerticalOptions = LayoutOptions .End , Text = "   Dislocation           "},
						switchDislocation},Orientation = StackOrientation.Horizontal  ,
					Padding = new Thickness(5,1,1,1),HorizontalOptions = LayoutOptions.FillAndExpand }};



			switchBodyTemperature.Toggled += delegate 
			{	
				BodyTemperaturePicker.SelectedIndex = -1;
				if (switchBodyTemperature.IsToggled)
				{BodyTemperaturePicker.IsEnabled   = true;}
				else 
				{BodyTemperaturePicker.IsEnabled  = false ;}
			};

			switchMuscleTone.Toggled += delegate 
			{	
				MuscleTonePicker.SelectedIndex = -1;
				if (switchMuscleTone.IsToggled)
				{MuscleTonePicker.IsEnabled   = true;}
				else 
				{MuscleTonePicker.IsEnabled  = false ;}
			};

			switchEdema.Toggled += delegate 
			{	
				EdemaPicker.SelectedIndex = -1;
				if (switchEdema.IsToggled)
				{EdemaPicker.IsEnabled   = true;}
				else 
				{EdemaPicker.IsEnabled  = false ;}
			};

			switchTenderness.Toggled += delegate 
			{	
				TendernessPicker.SelectedIndex = -1;
				if (switchTenderness.IsToggled)
				{TendernessPicker.IsEnabled   = true;}
				else 
				{TendernessPicker.IsEnabled  = false ;}
			};

			switchDeformity.Toggled += delegate 
			{	
				txtDeformity.Text ="";
				if (switchDeformity.IsToggled)
				{txtDeformity.IsEnabled   = true;}
				else 
				{txtDeformity.IsEnabled  = false ;}
			};


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
			switchMuscleGuarding.SetBinding (Switch.IsToggledProperty, "Palpation.MuscleGuarding", BindingMode.TwoWay);
			switchMuscleSpasm.SetBinding (Switch.IsToggledProperty, "Palpation.MuscleSpasm", BindingMode.TwoWay);
			switchSubluxation.SetBinding (Switch.IsToggledProperty, "Palpation.Subluxation", BindingMode.TwoWay);
			switchDislocation.SetBinding (Switch.IsToggledProperty, "Palpation.Dislocation", BindingMode.TwoWay);


			return new TableView () {
				Intent = TableIntent.Form ,
				//HasUnevenRows = true,
				Root = new TableRoot (){
					new TableSection ("Palpation Page"){
					
						BodyTemperatureCell,
						MuscleToneCell,
						EdemaCell,
						TendernessCell,txtLocation,
						DeformityCell, txtDeformity,
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


