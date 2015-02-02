using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class CranialNervePage : ContentPage
	{
		private static Entry txtPatientVisitId = new Entry (){ IsVisible = false };
		private static ListView ls = new ListView (){ RowHeight = 60 };

		static ContentView CreateFooter(){
			//var btnEdit = new Button{ };
			var btnDelete = new Button{ 
				Text = "Delete",
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand 
			};


			btnDelete.Clicked += delegate {
				CranialNerveAssmt item;
				if(ls.SelectedItem==null)
					return;

				item = (CranialNerveAssmt)ls.SelectedItem;

				if(txtPatientVisitId.Text != "0") // delete in database if edit mode
					SoapManager.DeleteEntity<CranialNerveAssmt>(item.RowId,"api/CranialNerveAssmts/{id}");

				ls.SelectedItem = null;

				List<CranialNerveAssmt> source;
				source = ((List<CranialNerveAssmt>)ls.ItemsSource==null?new List<CranialNerveAssmt>():(List<CranialNerveAssmt>)ls.ItemsSource);
				source.Remove(item);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(CranialNerveCell));
			};

			return new ContentView {

				VerticalOptions = LayoutOptions.End,
				Content = btnDelete

			};
		}

		static TableView CreateTable(){
			//Entry txtPatientVisitId = new Entry (){ IsVisible = false };
			txtPatientVisitId.SetBinding (Entry.TextProperty,"PatientVisitId", BindingMode.TwoWay);

			var lblCranialNerve = new Label { Text="Cranial Nerve: ", HorizontalOptions = LayoutOptions.Fill};
			var pckCranialNerve = new Picker () { 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Items = { "CN I", "CN II", "CN III", "CN IV", "CN V", "CN VI", "CN VII", "CN VIII", "CN IX", "CN X", "CN XI", "CN XII" } };

			var lblRight = new Label { Text="Right:", HorizontalOptions = LayoutOptions.Fill };
			var pckRight = new Picker () { Items = { "N", "AB" }, HorizontalOptions = LayoutOptions.FillAndExpand };

			var lblLeft = new Label { Text="Left:", HorizontalOptions = LayoutOptions.Fill};
			var pckLeft= new Picker () { Items = { "N", "AB" }, HorizontalOptions = LayoutOptions.FillAndExpand };

			var lblResult = new Label { Text="Result:", HorizontalOptions = LayoutOptions.Fill};
			var txtResult = new Entry () { HorizontalOptions = LayoutOptions.FillAndExpand };

			var btnAdd = new Button {
				Text = "Add Assessment",
				HorizontalOptions = LayoutOptions.FillAndExpand};

			btnAdd.Clicked += delegate {
				if (pckCranialNerve.SelectedIndex < 0) // no item selected in picker; exit event pre-maturely
					return;

				CranialNerveAssmt entity = new CranialNerveAssmt();

				entity.RowId = 0;
				entity.CranialNerve = pckCranialNerve.Items[pckCranialNerve.SelectedIndex];
				entity.Right = pckRight.Items[pckRight.SelectedIndex];
				entity.Left = pckLeft.Items[pckLeft.SelectedIndex];
				entity.Result = txtResult.Text;

				if(txtPatientVisitId.Text != "0") // add to db if edit mode
				{
					entity.PatientVisitId = Convert.ToInt32(txtPatientVisitId.Text);
					entity = SoapManager.AddEntity<CranialNerveAssmt>(entity,"api/CranialNerveAssmts");
				}


				List<CranialNerveAssmt> source;
				source = ((List<CranialNerveAssmt>)ls.ItemsSource==null?new List<CranialNerveAssmt>():(List<CranialNerveAssmt>)ls.ItemsSource);
				source.Add(entity);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(CranialNerveCell));
			};

			return new TableView () {
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 260,
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("Cranial Nerve Assessments") {
						new ViewCell {
							View = new StackLayout {
								Orientation = StackOrientation.Horizontal,
								Children = { lblCranialNerve, pckCranialNerve }
							}
						},
						new ViewCell {
							View = new StackLayout {
								Orientation = StackOrientation.Horizontal,
								Children = { lblRight, pckRight, lblLeft, pckLeft }
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

		public CranialNervePage ()
		{
			var form = CreateTable ();
			ls.ItemTemplate = new DataTemplate(typeof(CranialNerveCell));
			ls.SetBinding (ListView.ItemsSourceProperty,"CranialNerveAssmts",BindingMode.TwoWay);
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

	public class CranialNerveCell : ViewCell
	{
		public CranialNerveCell()
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
			nameLabel.SetBinding(Label.TextProperty, new Binding(path: "CranialNerve", stringFormat: "Cranial Nerve: {0}"));

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
				Orientation = StackOrientation.Horizontal,
				Children = { rightLabel, leftLabel, resultLabel }
			};
			return nameLayout;
		}
	}
}


