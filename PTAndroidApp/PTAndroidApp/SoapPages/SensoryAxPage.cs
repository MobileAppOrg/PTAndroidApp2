using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class SensoryAxPage : ContentPage
	{
		private static Entry txtPatientVisitId = new Entry (){ IsVisible = false };
		private static ListView ls = new ListView (){ RowHeight=60 };
		private static List<string> lstStimuli = new List<string>()
		{
			"PAIN",
			"TEMPERATURE",
			"LIGHT TOUCH",
			"PRESSURE",
			"VIBRATION"
		};
			
		static ContentView CreateFooter(){
			var btnDelete = new Button{ 
				Text = "Delete",
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand 
			};


			btnDelete.Clicked += delegate {
				SensoryAx item;
				if(ls.SelectedItem==null)
					return;

				item = (SensoryAx)ls.SelectedItem;

				if(txtPatientVisitId.Text != "0") // delete in database if edit mode
					SoapManager.DeleteEntity<SensoryAx>(item.RowId,"api/SensoryAx/{id}");

				ls.SelectedItem = null;

				List<SensoryAx> source;
				source = ((List<SensoryAx>)ls.ItemsSource==null?new List<SensoryAx>():(List<SensoryAx>)ls.ItemsSource);
				source.Remove(item);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(SensoryAxCell));
			};

			return new ContentView {

				VerticalOptions = LayoutOptions.End,
				Content = btnDelete

			};
		}

		static TableView CreateTable(){

			Entry txtPatientVisitId = new Entry (){ IsVisible = false };
			txtPatientVisitId.SetBinding (Entry.TextProperty,"PatientVisitId", BindingMode.TwoWay);

			var lblStimuli = new Label { FontSize =17, Text="STIMULI: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var STIMULI = new Picker () { 
				Title = "STIMULI",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Items = {
					"PAIN",
					"TEMPERATURE",
					"LIGHT TOUCH",
					"PRESSURE",
					"VIBRATION"
				}};

			var txtMaterialUsed = new EntryCell { Placeholder = "Material Used" };
			var txtLandMarks = new EntryCell { Placeholder = "LandMarks" };
			var txtResult = new EntryCell { Placeholder = "Results" };



			var btnAdd = new Button { Text = "Add SensoryAx", HorizontalOptions = LayoutOptions.FillAndExpand };

			var NameCell = new ViewCell {
				View = new StackLayout {
					Children = { lblStimuli, STIMULI },
					Orientation = StackOrientation.Horizontal  
				}
			};


			ViewCell btnCell = new ViewCell {
				View = new StackLayout () {
					Children = { btnAdd, txtPatientVisitId }
				}
			};

			btnAdd.Clicked += delegate {
				if (STIMULI.SelectedIndex < 0) // no item selected in picker; exit event pre-maturely
					return;

				SensoryAx entity = new SensoryAx();

				entity.RowId = 0;
				entity.Stimuli = STIMULI.Items[STIMULI.SelectedIndex];
				entity.MaterialUsed = txtMaterialUsed.Text;
				entity.Landmarks =txtLandMarks.Text;
				entity.Result =txtResult.Text;


				if(txtPatientVisitId.Text != "0") // add to db if edit mode
				{
					entity.PatientVisitId = Convert.ToInt32(txtPatientVisitId.Text);
					entity = SoapManager.AddEntity<SensoryAx>(entity,"api/SensoryAx");
				}

				List<SensoryAx> source;
				source = ((List<SensoryAx>)ls.ItemsSource==null?new List<SensoryAx>():(List<SensoryAx>)ls.ItemsSource);
				source.Add(entity);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(SensoryAxCell));
			};

			TableSection ts = new TableSection ();
			return new TableView () {
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 300,
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("Sensory Ax") {
						NameCell,
						txtMaterialUsed,
						txtLandMarks,
						txtResult,
						btnCell	
					}
				}
			};
		}

		public SensoryAxPage()
		{
			var form = CreateTable ();
			ls.ItemTemplate = new DataTemplate(typeof(SensoryAxCell));
			ls.SetBinding (ListView.ItemsSourceProperty,"SensoryAx",BindingMode.TwoWay);
			var footerButtons = CreateFooter ();

			Content = new StackLayout {
				Spacing = 0,
				Padding = 0,
				Children = {
					form,
					ls,
					footerButtons
				}
			};
		}
	}

	public class SensoryAxCell : ViewCell
	{
		public SensoryAxCell()
		{
			var idLabel = new Label { IsVisible = false };
			idLabel.SetBinding (Label.TextProperty, "RowId");

			var patientVisitIdLabel = new Label { IsVisible = false };
			patientVisitIdLabel.SetBinding (Label.TextProperty, "PatientVisitId");

			var nameLabel = new Label
			{
				FontSize = 20,
				HorizontalOptions= LayoutOptions.FillAndExpand
			};
			nameLabel.SetBinding(Label.TextProperty, new Binding(path: "Stimuli", stringFormat: "Stimuli: {0}"));

			var detailsLayout = CreateDetailsLayout();

			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children = { idLabel, patientVisitIdLabel, nameLabel, detailsLayout }
			};
			View = viewLayout;
		}

		static StackLayout CreateDetailsLayout()
		{

			var lblMaterialUsed = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			lblMaterialUsed.SetBinding(Label.TextProperty, new Binding(path: "MaterialUsed", stringFormat: "Material Used: {0}"));

			var lblLandmarks = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblLandmarks.SetBinding (Label.TextProperty, new Binding(path: "Landmarks",stringFormat: "Landmarks: {0}"));

			var lblResult = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblResult.SetBinding (Label.TextProperty, new Binding(path: "Result",stringFormat: "Result: {0}"));

			var detailLayout = new StackLayout (){ 
				Orientation = StackOrientation.Horizontal,
				Children = { lblMaterialUsed, lblLandmarks,lblResult}
			};

			return detailLayout;
		}
	}
}


