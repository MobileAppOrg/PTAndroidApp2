using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class CoordinationAssmtPage : ContentPage
	{
		private static Entry txtPatientVisitId = new Entry (){ IsVisible = false };
		private static ListView ls = new ListView (){ RowHeight = 80, VerticalOptions = LayoutOptions.FillAndExpand };

		static ContentView CreateFooter(){
			//var btnEdit = new Button{ };
			var btnDelete = new Button{ 
				Text = "Delete",
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand 
			};


			btnDelete.Clicked += delegate {
				CoordinationAssmt item;
				if(ls.SelectedItem==null)
					return;

				item = (CoordinationAssmt)ls.SelectedItem;

				if(txtPatientVisitId.Text != "0") // delete in database if edit mode
					SoapManager.DeleteEntity<CoordinationAssmt>(item.RowId,"api/CoordinationAssmts/{id}");

				ls.SelectedItem = null;

				List<CoordinationAssmt> source;
				source = ((List<CoordinationAssmt>)ls.ItemsSource==null?new List<CoordinationAssmt>():(List<CoordinationAssmt>)ls.ItemsSource);
				source.Remove(item);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(CoordinationAssmtCell));
			};

			return new ContentView {

				VerticalOptions = LayoutOptions.End,
				Content = btnDelete

			};
		}

		static TableView CreateTable(){
			//Entry txtPatientVisitId = new Entry (){ IsVisible = false };
			txtPatientVisitId.SetBinding (Entry.TextProperty,"PatientVisitId", BindingMode.TwoWay);

			var lblCoordinationTest = new Label { Text="Coordination Test: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var pckCoordinationTest = new Picker () { 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Items = {
					"FINGER-TO-NOSE",
					"FINGER-TOTHERAPIST’S FINGER",
					"FINGER-TO-FINGER",
					"ALTERNATE-NOSE-TO-FINGER",
					"FINGER-OPPOSITION",
					"MASS-GRASP",
					"PRONATION-SUPANATION",
					"REBOUND-PHENOMENON",
					"TAPPING-HAND",
					"TAPPING-FOOT",
					"POINT-AND-PAST-POINTING",
					"ALTERNATE-HEEL-TO-KNEE",
					"HEEL-TO-TOE",
					"TOE-TO-EXAMINERS’S FINGER",
					"HEEL-ON-SHIN",
					"DRAWING-A-CIRCLE-USING-HAND",
					"DRAWING-A-CIRCLE-USING-FOOT",
					"FIXATION/POSITION HOLDING (UE)",
					"FIXATION/POSITION HOLDING (LE)"
				}
			};

			var lblRight = new Label { Text="Right:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
			var pckRight = new Picker { HorizontalOptions = LayoutOptions.FillAndExpand,
				Items = {
					"4 - Normal Performance",
					"3 - Minimal Impairment", 	// Able to accomplish activity; slightly less than normal control, speed, and steadiness
					"2 - Moderate Impairment", 	// Able to accomplish activity; movements are slow, awkward, and unsteady
					"1 -Severe Impairment",		// Able only to initiate activity without completion; movements are slow with significant unsteadiness, oscillations, and/or extraneous movements
					"0 - Activity Impossible"
				}
			};

			var lblLeft = new Label { Text="Left:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var pckLeft= new Picker () { HorizontalOptions = LayoutOptions.FillAndExpand,
				Items = {
					"4 - Normal Performance",
					"3 - Minimal Impairment", 	// Able to accomplish activity; slightly less than normal control, speed, and steadiness
					"2 - Moderate Impairment", 	// Able to accomplish activity; movements are slow, awkward, and unsteady
					"1 -Severe Impairment",		// Able only to initiate activity without completion; movements are slow with significant unsteadiness, oscillations, and/or extraneous movements
				}
			};

			var lblResult = new Label { Text="Result:", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center};
			var txtResult = new Entry () { HorizontalOptions = LayoutOptions.FillAndExpand };

			var btnAdd = new Button {
				Text = "Add Assessment",
				HorizontalOptions = LayoutOptions.FillAndExpand};

			btnAdd.Clicked += delegate {
				if (pckCoordinationTest.SelectedIndex < 0) // no item selected in picker; exit event pre-maturely
					return;

				CoordinationAssmt entity = new CoordinationAssmt();

				entity.RowId = 0;
				entity.CoordinationTest = pckCoordinationTest.Items[pckCoordinationTest.SelectedIndex];
				entity.Right = pckRight.Items[pckRight.SelectedIndex];
				entity.Left = pckLeft.Items[pckLeft.SelectedIndex];
				entity.Result = txtResult.Text;

				if(txtPatientVisitId.Text != "0") // add to db if edit mode
				{
					entity.PatientVisitId = Convert.ToInt32(txtPatientVisitId.Text);
					entity = SoapManager.AddEntity<CoordinationAssmt>(entity,"api/CoordinationAssmts");
				}


				List<CoordinationAssmt> source;
				source = ((List<CoordinationAssmt>)ls.ItemsSource==null?new List<CoordinationAssmt>():(List<CoordinationAssmt>)ls.ItemsSource);
				source.Add(entity);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(CoordinationAssmtCell));
			};

			return new TableView () {
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 320,
				RowHeight = 40,
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("Coordination Assessment") {
						new ViewCell {
							View = new StackLayout {
								Orientation = StackOrientation.Horizontal,
								Children = { lblCoordinationTest, pckCoordinationTest }
							}
						},
						new ViewCell {
							View = new StackLayout {
								Orientation = StackOrientation.Horizontal,
								Children = { lblRight, pckRight }
							}
						},
						new ViewCell {
							View = new StackLayout {
								Orientation = StackOrientation.Horizontal,
								Children = { lblLeft, pckLeft }
							}
						},
						new ViewCell {
							View = new StackLayout {
								Orientation = StackOrientation.Horizontal,
								Children = { lblResult, txtResult }
							}
						},
						new ViewCell {
							View = new StackLayout {
								Orientation = StackOrientation.Horizontal,
								Children = { btnAdd, txtPatientVisitId }
							}
						}
					}
				}
			};
		}

		public CoordinationAssmtPage ()
		{
			var form = CreateTable ();
			ls.ItemTemplate = new DataTemplate(typeof(CoordinationAssmtCell));
			ls.SetBinding (ListView.ItemsSourceProperty,"CoordinationAssmts",BindingMode.TwoWay);
			ContentView footerButtons = CreateFooter ();

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

	public class CoordinationAssmtCell : ViewCell
	{
		public CoordinationAssmtCell()
		{
			var idLabel = new Label {
				IsVisible = false //false
			};
			idLabel.SetBinding (Label.TextProperty, "RowId");

			var patientVisitIdLabel = new Label {
				IsVisible = false //false
			};
			patientVisitIdLabel.SetBinding (Label.TextProperty, "PatientVisitId");

			var nameLabel = new Label
			{
				FontSize = 20,
				HorizontalOptions= LayoutOptions.FillAndExpand
			};
			nameLabel.SetBinding(Label.TextProperty, new Binding(path: "CoordinationTest", stringFormat: "{0}"));

			var detailLayout = CreateDetailLayout();

			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children = { idLabel,patientVisitIdLabel, nameLabel, detailLayout }
			};
			View = viewLayout;
		}

		static StackLayout CreateDetailLayout()
		{
			var rightLabel = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			rightLabel.SetBinding(Label.TextProperty, new Binding(path: "Right", stringFormat: "Right: {0}"));

			var leftLabel = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			leftLabel.SetBinding(Label.TextProperty, new Binding(path: "Left", stringFormat: "Left: {0}"));

			var resultLabel = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			resultLabel.SetBinding (Label.TextProperty, new Binding(path: "Result",stringFormat: "Result: {0}"));

			var nameLayout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { 
					new StackLayout {
						Orientation = StackOrientation.Horizontal,
						Children = { rightLabel, leftLabel }
					},
					resultLabel 
				}
			};
			return nameLayout;
		}
	}
}


