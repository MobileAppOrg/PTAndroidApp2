using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class ROMPage : ContentPage
	{
		private static Entry txtPatientVisitId = new Entry (){ IsVisible = false };
		private static ListView ls = new ListView (){ RowHeight=80 };
		private static List<string> lstEndFeel = new List<string> (){ "Soft", "Hard", "Firm", "Empty", "Boggy" };
		private static List<string> lstMotions = new List<string>()
		{
			"Cervical Flexion",
			"Cervical  Extension",
			"Cervical  Rotation",
			"Cervical Lateral Flexion",
			"Thoracolumbar Flexion",
			"Thoracolumbar Extension",
			"Thoracolumbar Rotation",
			"Thoracolumbar Lateral Flexion"
		};

		static ContentView CreateFooter(){
			var btnDelete = new Button{ 
				Text = "Delete",
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand 
			};


			btnDelete.Clicked += delegate {
				ROM item;
				if(ls.SelectedItem==null)
					return;

				item = (ROM)ls.SelectedItem;

				if(txtPatientVisitId.Text != "0") // delete in database if edit mode
					SoapManager.DeleteEntity<ROM>(item.RowId,"api/ROM/{id}");

				ls.SelectedItem = null;

				List<ROM> source;
				source = ((List<ROM>)ls.ItemsSource==null?new List<ROM>():(List<ROM>)ls.ItemsSource);
				source.Remove(item);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(ROMCell));
			};

			return new ContentView {

				VerticalOptions = LayoutOptions.End,
				Content = btnDelete

			};
		}

		static TableView CreateTable(){

			Entry txtPatientVisitId = new Entry (){ IsVisible = false };
			txtPatientVisitId.SetBinding (Entry.TextProperty,"PatientVisitId", BindingMode.TwoWay);

			var lblROM = new Label { Text="Motion: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var Motions = new Picker () { 
				Title = "Motions",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Items = {
					"Cervical Flexion",
					"Cervical  Extension",
					"Cervical  Rotation",
					"Cervical Lateral Flexion",
					"Thoracolumbar Flexion",
					"Thoracolumbar Extension",
					"Thoracolumbar Rotation",
					"Thoracolumbar Lateral Flexion"
				}};

			var lblArom = new Label { Text = "AROM(°): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var Arom = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric };
			var lblProm = new Label { Text = "PROM(°): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var Prom = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric  };
			var lblNormalValue = new Label { Text = "NormalValue(°): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var NormalValue = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric  };
			var lblDifference = new Label { Text = "Difference(°): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var Difference = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric  };
			var lblEndFeel = new Label { Text = "End Feel: ",HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var EndFeel = new Picker () { 
				Title = "End Feel",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Items = { "Soft", "Hard", "Firm", "Empty", "Boggy" }
			};

			var btnAdd = new Button { Text = "Add ROM", HorizontalOptions = LayoutOptions.FillAndExpand };

			var NameCell = new ViewCell {
				View = new StackLayout {
					Children = { lblROM, Motions },
					Orientation = StackOrientation.Horizontal  
				}
			};

			var AromPromCell = new ViewCell {
				View = new StackLayout () {
					Children = { lblArom, Arom,lblProm, Prom},
					Orientation = StackOrientation.Horizontal
				}
			};
					
			var DifferenceCell = new ViewCell {
				View = new StackLayout () {
					Children = { lblDifference, Difference,lblNormalValue, NormalValue, },
					Orientation = StackOrientation.Horizontal
				}
			};

			var EndFeelCell = new ViewCell {
				View = new StackLayout {
					Children = { lblEndFeel, EndFeel },
					Orientation = StackOrientation.Horizontal  
				}
			};

			ViewCell btnCell = new ViewCell {
				View = new StackLayout () {
					Children = { btnAdd, txtPatientVisitId }
				}
			};

			btnAdd.Clicked += delegate {
				if (Motions.SelectedIndex < 0) // no item selected in picker; exit event pre-maturely
					return;

				ROM entity = new ROM();

				entity.RowId = 0;
				entity.Motion = Motions.Items[Motions.SelectedIndex];
				entity.Arom = String.IsNullOrEmpty(Arom.Text) ? 0 : Convert.ToDecimal(Arom.Text);
				entity.Prom = String.IsNullOrEmpty(Prom.Text) ? 0 : Convert.ToDecimal(Prom.Text);
				entity.NormalValue = String.IsNullOrEmpty(NormalValue.Text) ? 0 : Convert.ToDecimal(NormalValue.Text);
				entity.Difference = String.IsNullOrEmpty(Difference.Text) ? 0 : Convert.ToDecimal(Difference.Text);
				entity.EndFeel = EndFeel.Items[EndFeel.SelectedIndex];

				if(txtPatientVisitId.Text != "0") // add to db if edit mode
				{
					entity.PatientVisitId = Convert.ToInt32(txtPatientVisitId.Text);
					entity = SoapManager.AddEntity<ROM>(entity,"api/ROM");
				}

				List<ROM> source;
				source = ((List<ROM>)ls.ItemsSource==null?new List<ROM>():(List<ROM>)ls.ItemsSource);
				source.Add(entity);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(ROMCell));
			};

			TableSection ts = new TableSection ();
			return new TableView () {
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 300,
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("ROM") {
						NameCell,
						AromPromCell,
						DifferenceCell,
						EndFeelCell,
						btnCell	
					}
				}
			};
		}

		public ROMPage()
		{
			var form = CreateTable ();
			ls.ItemTemplate = new DataTemplate(typeof(ROMCell));
			ls.SetBinding (ListView.ItemsSourceProperty,"ROMs",BindingMode.TwoWay);
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

	public class ROMCell : ViewCell
	{
		public ROMCell()
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
			nameLabel.SetBinding(Label.TextProperty, new Binding(path: "Motion", stringFormat: "Motion: {0}"));

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

			var lblArom = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			lblArom.SetBinding(Label.TextProperty, new Binding(path: "Arom", stringFormat: "Arom: {0}°"));

			var lblProm = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblProm.SetBinding (Label.TextProperty, new Binding(path: "Prom",stringFormat: "Prom: {0}°"));

			var FirstLayout = new StackLayout (){ 
				Orientation = StackOrientation.Horizontal,
				Children = { lblArom, lblProm}
			};

			var lblDifference = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			lblDifference.SetBinding(Label.TextProperty, new Binding(path: "Difference", stringFormat: "Difference: {0}°"));

			var lblNormalValue = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			lblNormalValue.SetBinding(Label.TextProperty, new Binding(path: "NormalValue", stringFormat: "NormalValue: {0}°"));

			var lblEndFeel = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblEndFeel.SetBinding (Label.TextProperty, "EndFeel" );

			var SecondLayout = new StackLayout (){ 
				Orientation = StackOrientation.Horizontal,
				Children = { lblDifference,  lblNormalValue, lblEndFeel }
			};

			var detailLayout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { FirstLayout, SecondLayout }
			};
			return detailLayout;
		}
	}
}


