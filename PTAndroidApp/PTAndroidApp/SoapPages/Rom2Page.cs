using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class Rom2Page : ContentPage
	{
		private static Entry txtPatientVisitId = new Entry (){ IsVisible = false };
		private static ListView ls = new ListView (){ RowHeight=80 };
		private static List<string> lstEndFeel = new List<string> (){ "Soft", "Hard", "Firm", "Empty", "Boggy" };
		private static List<string> lstMotions = new List<string>()
		{
			"Shoulder Flexion",
			"Shoulder Extension",
			"Shoulder Abduction",
			"Shoulder Medial Rotation",
			"Shoulder Lateral Rotation",
			"Elbow Flexion",
			"Elbow Extension",
			"Forearm Supination",
			"Forearm Pronation",
			"Wrist Flexion",
			"Wrist Extension",
			"Ulnar Deviation",
			"Radial Deviation",
			"Thumb MCP Flexion",
			"Thumb MCP Extension",
			"Thumb CMC Flexion",
			"Thumb CMC Extension",
			"2nd MCP Flexion",
			"3rd MCP Flexion",
			"4th MCP Flexion",
			"5th MCP Flexion",
			"Thumb IP Flexion",
			"2nd PIP Flexion",
			"3rd PIP Flexion",
			"4th PIP Flexion",
			"5th PIP Flexion",
			"2nd DIP Flexion",
			"3rd DIP Flexion",
			"4th DIP Flexion",
			"5th DIP Flexion",
			"2nd MCP Extension",
			"3rd MCP Extension",
			"4th MCP Extension",
			"5th MCP Extension",
			"2nd PIP Extension",
			"3rd PIP Extension",
			"4th PIP Extension",
			"5th PIP Extension",
			"2nd DIP Extension",
			"3rd DIP Extension",
			"4th DIP Extension",
			"5th DIP Extension",
			"HIP FLEXION",
			"HIP EXTENSION",
			"HIP ABDUCTION",
			"HIP ADDUCTION",
			"HIP MEDIAL ROTATION",
			"HIP LATERAL ROTATION",
			"KNEE FLEXION",
			"KNEE EXTENSION",
			"DORSIFLEXION",
			"PLANTARFLEXION",
			"INVERSION",
			"EVERSION",
			"MTP FLEXION",
			"MTP EXTENSION",
			"IP FLEXION (1st toe)",
			"PIP FLEXION (lateral four toes)",
			"IP EXTENSION (1st toe)",
			"PIP EXTENSION (lateral four toes)",
			"DIP FLEXION",
			"DIP EXTENSION"
		};

		static ContentView CreateFooter(){
			var btnDelete = new Button{ 
				Text = "Delete",
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand 
			};


			btnDelete.Clicked += delegate {
				ROM2 item;
				if(ls.SelectedItem==null)
					return;

				item = (ROM2)ls.SelectedItem;

				if(txtPatientVisitId.Text != "0") // delete in database if edit mode
					SoapManager.DeleteEntity<ROM2>(item.RowId,"api/ROM2/{id}");

				ls.SelectedItem = null;

				List<ROM2> source;
				source = ((List<ROM2>)ls.ItemsSource==null?new List<ROM2>():(List<ROM2>)ls.ItemsSource);
				source.Remove(item);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(ROM2Cell));
			};

			return new ContentView {

				VerticalOptions = LayoutOptions.End,
				Content = btnDelete

			};
		}

		static TableView CreateTable(){

			Entry txtPatientVisitId = new Entry (){ IsVisible = false };
			txtPatientVisitId.SetBinding (Entry.TextProperty,"PatientVisitId", BindingMode.TwoWay);

			var lblROM2 = new Label { Text="Motion: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var Motions = new Picker () { 
				Title = "Procedures",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Items = {
					"Shoulder Flexion",
					"Shoulder Extension",
					"Shoulder Abduction",
					"Shoulder Medial Rotation",
					"Shoulder Lateral Rotation",
					"Elbow Flexion",
					"Elbow Extension",
					"Forearm Supination",
					"Forearm Pronation",
					"Wrist Flexion",
					"Wrist Extension",
					"Ulnar Deviation",
					"Radial Deviation",
					"Thumb MCP Flexion",
					"Thumb MCP Extension",
					"Thumb CMC Flexion",
					"Thumb CMC Extension",
					"2nd MCP Flexion",
					"3rd MCP Flexion",
					"4th MCP Flexion",
					"5th MCP Flexion",
					"Thumb IP Flexion",
					"2nd PIP Flexion",
					"3rd PIP Flexion",
					"4th PIP Flexion",
					"5th PIP Flexion",
					"2nd DIP Flexion",
					"3rd DIP Flexion",
					"4th DIP Flexion",
					"5th DIP Flexion",
					"2nd MCP Extension",
					"3rd MCP Extension",
					"4th MCP Extension",
					"5th MCP Extension",
					"2nd PIP Extension",
					"3rd PIP Extension",
					"4th PIP Extension",
					"5th PIP Extension",
					"2nd DIP Extension",
					"3rd DIP Extension",
					"4th DIP Extension",
					"5th DIP Extension",
					"HIP FLEXION",
					"HIP EXTENSION",
					"HIP ABDUCTION",
					"HIP ADDUCTION",
					"HIP MEDIAL ROTATION",
					"HIP LATERAL ROTATION",
					"KNEE FLEXION",
					"KNEE EXTENSION",
					"DORSIFLEXION",
					"PLANTARFLEXION",
					"INVERSION",
					"EVERSION",
					"MTP FLEXION",
					"MTP EXTENSION",
					"IP FLEXION (1st toe)",
					"PIP FLEXION (lateral four toes)",
					"IP EXTENSION (1st toe)",
					"PIP EXTENSION (lateral four toes)",
					"DIP FLEXION",
					"DIP EXTENSION"
				}};

			var lblAromR = new Label { Text = "AromR(°): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var AromR = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric };
			var lblAromL = new Label { Text = "AromL(°): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var AromL = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric  };
			var lblPromR = new Label { Text = "PromR(°): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var PromR = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric  };
			var lblPromL = new Label { Text = "PromL(°): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var PromL = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric  };
			var lblNormalValue = new Label { Text = "NormalValue(°): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var NormalValue = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric  };
			var lblDifferenceR = new Label { Text = "DifferenceR(°): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var DifferenceR = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric  };
			var lblDifferenceL = new Label { Text = "DifferenceL(°): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var DifferenceL = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric  };
			var lblEndFeel = new Label { Text = "End Feel: ",HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var EndFeel = new Picker () { 
				Title = "End Feel",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Items = { "Soft", "Hard", "Firm", "Empty", "Boggy" }
			};

			var btnAdd = new Button { Text = "Add ROM", HorizontalOptions = LayoutOptions.FillAndExpand };

			var NameCell = new ViewCell {
				View = new StackLayout {
					Children = { lblROM2, Motions },
					Orientation = StackOrientation.Horizontal  
				}
			};

			var AromCell = new ViewCell {
				View = new StackLayout () {
					Children = { lblAromR, AromR, lblAromL, AromL },
					Orientation = StackOrientation.Horizontal
				}
			};

			var PromCell = new ViewCell {
				View = new StackLayout () {
					Children = { lblPromR, PromR, lblPromL, PromL },
					Orientation = StackOrientation.Horizontal
				}
			};

			var DifferenceCell = new ViewCell {
				View = new StackLayout () {
					Children = { lblDifferenceR, DifferenceR, lblDifferenceL, DifferenceL },
					Orientation = StackOrientation.Horizontal
				}
			};

			var EndFeelCell = new ViewCell {
				View = new StackLayout {
					Children = { lblNormalValue, NormalValue, lblEndFeel, EndFeel },
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

				ROM2 entity = new ROM2();

				entity.RowId = 0;
				entity.Motion = Motions.Items[Motions.SelectedIndex];
				entity.AromR = String.IsNullOrEmpty(AromR.Text) ? 0 : Convert.ToDecimal(AromR.Text);
				entity.AromL = String.IsNullOrEmpty(AromL.Text) ? 0 : Convert.ToDecimal(AromL.Text);
				entity.PromR = String.IsNullOrEmpty(PromR.Text) ? 0 : Convert.ToDecimal(PromR.Text);
				entity.PromL = String.IsNullOrEmpty(PromL.Text) ? 0 : Convert.ToDecimal(PromL.Text);
				entity.NormalValue = String.IsNullOrEmpty(NormalValue.Text) ? 0 : Convert.ToDecimal(NormalValue.Text);
				entity.DifferenceR = String.IsNullOrEmpty(DifferenceR.Text) ? 0 : Convert.ToDecimal(DifferenceR.Text);
				entity.DifferenceL = String.IsNullOrEmpty(DifferenceL.Text) ? 0 : Convert.ToDecimal(DifferenceL.Text);
				entity.EndFeel = EndFeel.Items[EndFeel.SelectedIndex];

				if(txtPatientVisitId.Text != "0") // add to db if edit mode
				{
					entity.PatientVisitId = Convert.ToInt32(txtPatientVisitId.Text);
					entity = SoapManager.AddEntity<ROM2>(entity,"api/ROM2");
				}


				List<ROM2> source;
				source = ((List<ROM2>)ls.ItemsSource==null?new List<ROM2>():(List<ROM2>)ls.ItemsSource);
				source.Add(entity);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(ROM2Cell));
			};

			TableSection ts = new TableSection ();
			return new TableView () {
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 300,
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("ROM (continued)") {
						NameCell,
						AromCell,
						PromCell,
						DifferenceCell,
						EndFeelCell,
						btnCell	
					}
				}
			};
		}

		public Rom2Page()
		{
			var form = CreateTable ();
			ls.ItemTemplate = new DataTemplate(typeof(ROM2Cell));
			ls.SetBinding (ListView.ItemsSourceProperty,"ROM2s",BindingMode.TwoWay);
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

	public class ROM2Cell : ViewCell
	{
		public ROM2Cell()
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

			var lblAromR = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			lblAromR.SetBinding(Label.TextProperty, new Binding(path: "AromR", stringFormat: "Arom(R): {0}°"));

			var lblAromL = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblAromL.SetBinding (Label.TextProperty, new Binding(path: "AromL",stringFormat: "Arom(L): {0}°"));

			var lblPromR = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			lblPromR.SetBinding(Label.TextProperty, new Binding(path: "PromR", stringFormat: "Prom(R): {0}°"));

			var lblPromL = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblPromL.SetBinding (Label.TextProperty, new Binding(path: "PromL",stringFormat: "Prom(L): {0}°"));

			var FirstLayout = new StackLayout (){ 
				Orientation = StackOrientation.Horizontal,
				Children = { lblAromR, lblAromL, lblPromR, lblPromL }
			};

			var lblDifferenceR = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			lblDifferenceR.SetBinding(Label.TextProperty, new Binding(path: "DifferenceR", stringFormat: "Difference(R): {0}°"));

			var lblDifferenceL = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblDifferenceL.SetBinding (Label.TextProperty, new Binding(path: "DifferenceL",stringFormat: "Difference(L): {0}°"));

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
				Children = { lblDifferenceR, lblDifferenceL, lblNormalValue, lblEndFeel }
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


