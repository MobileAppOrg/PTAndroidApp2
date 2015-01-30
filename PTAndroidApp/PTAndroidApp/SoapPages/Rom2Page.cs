using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class Rom2Page : ContentPage
	{
		private static Entry txtPatientVisitId = new Entry (){ IsVisible = false };
		private static ListView ls = new ListView (){ RowHeight=60 };
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

			var lblROM2 = new Label { Text="Motion: "};
			var Motions = new Picker () { 
				Title = "Procedures",
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

			var AromR = new EntryCell { Label = "AromR(°)" };
			var AromL = new EntryCell { Label = "AromL(°)" };
			var PromR = new EntryCell { Label = "PromR(°)" };
			var PromL = new EntryCell { Label = "PromL(°)" };
			var NormalValue = new EntryCell { Label = "NormalValue(°)" };
			var DifferenceR = new EntryCell { Label = "DifferenceR(°)" };
			var DifferenceL = new EntryCell { Label = "DifferenceL(°)" };
			var lblEndFeel = new Label { Text = "End Feel: " };
			var EndFeel = new Picker () { 
				Title = "End Feel",
				Items = { "Soft", "Hard", "Firm", "Empty", "Boggy" }
			};

			var btnAdd = new Button {
				Text = "Add ROM",
				HorizontalOptions = LayoutOptions.FillAndExpand};

			var NameLayout = new StackLayout {
				Children = { lblROM2, Motions },
				Orientation = StackOrientation.Horizontal  
			};

			var NameCell = new ViewCell {
				View = new StackLayout () {
					Children = { NameLayout },
					VerticalOptions = LayoutOptions .FillAndExpand 
				}
			};

			var EndFeelLayout = new StackLayout {
				Children = { lblEndFeel, EndFeel },
				Orientation = StackOrientation.Horizontal  
			};

			var EndFeelCell = new ViewCell {
				View = new StackLayout () {
					Children = { EndFeelLayout },
					VerticalOptions = LayoutOptions .FillAndExpand 
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
				HeightRequest = 260,
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("ROM (continued)") {
						NameCell,
						AromR,
						AromL,
						PromR,
						PromL,
						NormalValue,
						DifferenceR,
						DifferenceL,
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
			lblAromR.SetBinding(Label.TextProperty, new Binding(path: "AromR", stringFormat: "0 °"));

			var lblAromL = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblAromL.SetBinding (Label.TextProperty, new Binding(path: "AromL",stringFormat: "0 °"));

			var aromLayout = new StackLayout (){ 
				Orientation = StackOrientation.Horizontal,
				Children = { lblAromR, lblAromL }
			};

			var lblPromR = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			lblPromR.SetBinding(Label.TextProperty, new Binding(path: "PromR", stringFormat: "0 °"));

			var lblPromL = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblPromL.SetBinding (Label.TextProperty, new Binding(path: "PromL",stringFormat: "0 °"));

			var promLayout = new StackLayout (){ 
				Orientation = StackOrientation.Horizontal,
				Children = { lblPromR, lblPromL }
			};

			var lblDifferenceR = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			lblDifferenceR.SetBinding(Label.TextProperty, new Binding(path: "DifferenceR", stringFormat: "0 °"));

			var lblDifferenceL = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblDifferenceL.SetBinding (Label.TextProperty, new Binding(path: "DifferenceL",stringFormat: "0 °"));

			var differenceLLayout = new StackLayout (){ 
				Orientation = StackOrientation.Horizontal,
				Children = { lblDifferenceR, lblDifferenceL }
			};

			var lblNormalValue = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			lblNormalValue.SetBinding(Label.TextProperty, new Binding(path: "NormalValue", stringFormat: "0 °"));

			var lblEndFeel = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblEndFeel.SetBinding (Label.TextProperty, "EndFeel" );

			var endFeelLayout = new StackLayout (){ 
				Orientation = StackOrientation.Horizontal,
				Children = { lblNormalValue, lblEndFeel }
			};

			var detailLayout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { aromLayout, promLayout, differenceLLayout, endFeelLayout }
			};
			return detailLayout;
		}
	}
}


