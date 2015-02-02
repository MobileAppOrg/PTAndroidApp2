using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class MMTPage : ContentPage
	{
		private static Entry txtPatientVisitId = new Entry (){ IsVisible = false };
		private static ListView ls = new ListView (){ RowHeight=60 };
		private static List<string> lstMotions = new List<string>()
		{
			"Cervical Flexion",
			"Cervical Extension",
			"Cervical Rotation",
			"Cervical Side Flexion",
			"Thoracolumbar Flexion",
			"Thoracolumbar Extension",
			"Thoracolumbar Rotation",
			"Thoracolumbar Side Flexion",
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
			" Thumb IP Flexion",
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
			"IP LATERAL ROTATION",
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
		private static List<string> lstGrades = new List<string>()
		{"Grade 5","Grade 4","Grade 3","Grade 2+","Grade 2","Grade 2-","Grade 1"};
	

		static ContentView CreateFooter(){
			var btnDelete = new Button{ 
				Text = "Delete",
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand 
			};


			btnDelete.Clicked += delegate {
				MMT item;
				if(ls.SelectedItem==null)
					return;

				item = (MMT)ls.SelectedItem;

				if(txtPatientVisitId.Text != "0") // delete in database if edit mode
					SoapManager.DeleteEntity<MMT>(item.RowId,"api/MMT/{id}");

				ls.SelectedItem = null;

				List<MMT> source;
				source = ((List<MMT>)ls.ItemsSource==null?new List<MMT>():(List<MMT>)ls.ItemsSource);
				source.Remove(item);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(MMTCell));
			};

			return new ContentView {

				VerticalOptions = LayoutOptions.End,
				Content = btnDelete

			};
		}

		static TableView CreateTable(){

			Entry txtPatientVisitId = new Entry (){ IsVisible = false };
			txtPatientVisitId.SetBinding (Entry.TextProperty,"PatientVisitId", BindingMode.TwoWay);

			var lblMotions = new Label { Text="Motion: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var Motions = new Picker () { 
				Title = "Motions",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Items = {
					"Cervical Flexion",
					"Cervical Extension",
					"Cervical Rotation",
					"Cervical Side Flexion",
					"Thoracolumbar Flexion",
					"Thoracolumbar Extension",
					"Thoracolumbar Rotation",
					"Thoracolumbar Side Flexion",
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
					" Thumb IP Flexion",
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
					"IP LATERAL ROTATION",
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
			var GradesR = new Picker () { 
				Title = "Grades",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Items = {
					"Grade 5","Grade 4","Grade 3","Grade 2+","Grade 2","Grade 2-","Grade 1"
				}};
			var GradesL = new Picker () { 
				Title = "Grades",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Items = {
					"Grade 5","Grade 4","Grade 3","Grade 2+","Grade 2","Grade 2-","Grade 1"
				}};

			var lblGradesR = new Label { Text = "GRADE (R): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var lblGradesL = new Label { Text = "GRADE (L): ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };



			var btnAdd = new Button { Text = "Add MMT", HorizontalOptions = LayoutOptions.FillAndExpand };

			var NameCell = new ViewCell {
				View = new StackLayout {
					Children = { lblMotions, Motions },
					Orientation = StackOrientation.Horizontal  
				}
			};

			var GradesRCell = new ViewCell {
				View = new StackLayout () {
					Children = { lblGradesR, GradesR},
					Orientation = StackOrientation.Horizontal
				}
			};
			var GradesLCell = new ViewCell {
				View = new StackLayout () {
					Children = { lblGradesL, GradesL},
					Orientation = StackOrientation.Horizontal
				}
			};
				

			ViewCell btnCell = new ViewCell {
				View = new StackLayout () {
					Children = { btnAdd, txtPatientVisitId }
				}
			};

			btnAdd.Clicked += delegate {
				if (Motions.SelectedIndex < 0 && GradesR.SelectedIndex < 0 && GradesL.SelectedIndex < 0) // no item selected in picker; exit event pre-maturely
					return;

				MMT entity = new MMT();

				entity.RowId = 0;
				entity.Motion = Motions.Items[Motions.SelectedIndex];
				entity.GradeR = GradesR.Items[GradesR.SelectedIndex];
				entity.GradeL = GradesL.Items[GradesL.SelectedIndex];

				if(txtPatientVisitId.Text != "0") // add to db if edit mode
				{
					entity.PatientVisitId = Convert.ToInt32(txtPatientVisitId.Text);
					entity = SoapManager.AddEntity<MMT>(entity,"api/MMT");
				}

				List<MMT> source;
				source = ((List<MMT>)ls.ItemsSource==null?new List<MMT>():(List<MMT>)ls.ItemsSource);
				source.Add(entity);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(MMTCell));
			};

			TableSection ts = new TableSection ();
			return new TableView () {
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 300,
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("MMT") {
						NameCell,
						GradesRCell,
						GradesLCell,
						btnCell	
					}
				}
			};
		}

		public MMTPage()
		{
			var form = CreateTable ();
			ls.ItemTemplate = new DataTemplate(typeof(MMTCell));
			ls.SetBinding (ListView.ItemsSourceProperty,"MMT",BindingMode.TwoWay);
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

	public class MMTCell : ViewCell
	{
		public MMTCell()
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

			var lblGradeR = new Label
			{
				FontSize = 15,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			lblGradeR.SetBinding(Label.TextProperty, new Binding(path: "GradeR", stringFormat: "GRADE (R): {0}"));

			var lblGradeL = new Label {
				FontSize = 15,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblGradeL.SetBinding (Label.TextProperty, new Binding(path: "GradeL",stringFormat: "GRADE (L): {0}"));

			var detailLayout = new StackLayout (){ 
				Orientation = StackOrientation.Horizontal,
				Children = { lblGradeR, lblGradeL}
			};
			return detailLayout;
		}
	}
}


