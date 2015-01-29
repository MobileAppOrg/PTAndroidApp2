using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PTAndroidApp
{
	public class DrugHxPage : ContentPage
	{
		private static ListView ls = new ListView (){ RowHeight=60 };
		private static Entry txtPatientVisitId = new Entry (){ IsVisible = false };
		//private static SoapManager soapMgr = new SoapManager();

		static ContentView CreateFooter(){
			//var btnEdit = new Button{ };
			var btnDelete = new Button{ 
				Text = "Delete",
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand 
			};

			btnDelete.Clicked += delegate {
				DrugHistory item;
				if(ls.SelectedItem==null)
					return;

				item = (DrugHistory)ls.SelectedItem;

				if(txtPatientVisitId.Text != "0") // delete in database if edit mode
					SoapManager.DeleteEntity<DrugHistory>(item.RowId,"api/DrugHistories/{id}");

				ls.SelectedItem = null;

				List<DrugHistory> source;
				source = ((List<DrugHistory>)ls.ItemsSource==null?new List<DrugHistory>():(List<DrugHistory>)ls.ItemsSource);
				source.Remove(item);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(DrugCell));
			};

			return new ContentView {

				VerticalOptions = LayoutOptions.End,
				Content = btnDelete

			};
		}

		static TableView CreateTable(){
			txtPatientVisitId.SetBinding (Entry.TextProperty,"PatientVisitId", BindingMode.TwoWay);
			EntryCell txtDrug = new EntryCell { Label="Drug: " };
			//EntryCell txtDate = new EntryCell { Label="Date: " };
			EntryCell txtResult = new EntryCell { Label="Result: " };
			Button btnAdd = new Button () { Text = "Add" };
			var datePicker = new DatePicker (){ Date = DateTime.Now, Format = "D",HorizontalOptions = LayoutOptions.FillAndExpand };
			ViewCell btnCell = new ViewCell {
				View = new StackLayout () {
					Children = { btnAdd, txtPatientVisitId }
				}
			};
			ViewCell dateCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Date: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
						datePicker
					},
					Padding = new Thickness(5,1,1,1),
					HorizontalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Horizontal
				}
			};

			btnAdd.Clicked += delegate {
				if (string.IsNullOrEmpty(txtDrug.Text))
					return;

				DrugHistory d = new DrugHistory();

				d.RowId = 0;
				d.DrugName = txtDrug.Text;
				d.DrugDate = datePicker.Date;
				d.Result = txtResult.Text;

				if(txtPatientVisitId.Text != "0") // add to db if edit mode
				{
					d.PatientVisitId = Convert.ToInt32(txtPatientVisitId.Text);
					d = SoapManager.AddEntity<DrugHistory>(d,"api/DrugHistories");
				}

				List<DrugHistory> source;
				source = ((List<DrugHistory>)ls.ItemsSource==null?new List<DrugHistory>():(List<DrugHistory>)ls.ItemsSource);
				source.Add(d);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(DrugCell));
			};

			TableSection ts = new TableSection ();
			return new TableView () {
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 260,
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("DRUGHx") {
						txtDrug,
						dateCell,
						txtResult,
						btnCell,
					}
				}
			};
		}


		public DrugHxPage ()
		{
			var form = CreateTable ();
			//ls.ItemsSource = source;
			ls.ItemTemplate = new DataTemplate(typeof(DrugCell));
			ls.SetBinding (ListView.ItemsSourceProperty, "DrugHistory",BindingMode.TwoWay);

//			ls.ItemTapped += async (object sender, ItemTappedEventArgs e) => {
//				((ListView)sender).SelectedItem=null;
//				DrugHistory selItem = (DrugHistory)e.Item;
//				var action = await DisplayActionSheet ("Delete?", "Cancel", "Delete");
//				if (action=="Delete"){
//					List<DrugHistory> source;
//					source = ((List<DrugHistory>)ls.ItemsSource==null?new List<DrugHistory>():(List<DrugHistory>)ls.ItemsSource);
//					ls.ItemsSource = source;
//					ls.ItemTemplate = new DataTemplate(typeof(DrugCell));
//				}
//				//Debug.WriteLine("Action: " + action); // writes the selected button label to the console
//			};

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



	public class DrugCell : ViewCell
	{
		public DrugCell()
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
			nameLabel.SetBinding(Label.TextProperty, "DrugName");

			var nameLayout = CreateNameLayout();

			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children = { idLabel,patientVisitIdLabel,nameLabel, nameLayout }
			};
			View = viewLayout;
		}

		static StackLayout CreateNameLayout()
		{

			var dateLabel = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			dateLabel.SetBinding(Label.TextProperty, new Binding(path: "DrugDate", stringFormat: "Date: {0:D}"));

			var resultLabel = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			resultLabel.SetBinding (Label.TextProperty, new Binding(path: "Result",stringFormat: "Result: {0}"));

			var nameLayout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { dateLabel, resultLabel }
			};
			return nameLayout;
		}
	}
}


