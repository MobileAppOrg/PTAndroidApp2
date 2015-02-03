using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class MBMPage : ContentPage
	{
		private static Entry txtPatientVisitId = new Entry (){ IsVisible = false };
		private static ListView ls = new ListView (){ RowHeight=70 };

		static ContentView CreateFooter(){
			var btnDelete = new Button{ 
				Text = "Delete",
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand 
			};


			btnDelete.Clicked += delegate {
				MBM item;
				if(ls.SelectedItem==null)
					return;

				item = (MBM)ls.SelectedItem;

				if(txtPatientVisitId.Text != "0") // delete in database if edit mode
					SoapManager.DeleteEntity<MBM>(item.RowId,"api/MBM/{id}");

				ls.SelectedItem = null;

				List<MBM> source;
				source = ((List<MBM>)ls.ItemsSource==null?new List<MBM>():(List<MBM>)ls.ItemsSource);
				source.Remove(item);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(MBMCell));
			};

			return new ContentView {

				VerticalOptions = LayoutOptions.End,
				Content = btnDelete

			};
		}





		static TableView CreateTable(){

			Entry txtPatientVisitId = new Entry (){ IsVisible = false };
			txtPatientVisitId.SetBinding (Entry.TextProperty,"PatientVisitId", BindingMode.TwoWay);



			var txtLocation = new EntryCell { Placeholder = "Location" };
			var txtMarkings = new EntryCell { Placeholder = "Markings" };
			var txtRight = new Entry { HorizontalOptions = LayoutOptions .FillAndExpand, Placeholder = "Right", Keyboard = Keyboard.Numeric  };
			var txtLeft = new Entry { HorizontalOptions = LayoutOptions .FillAndExpand, Placeholder = "Left", Keyboard = Keyboard.Numeric  };
			var txtDifference = new Entry {HorizontalOptions = LayoutOptions .FillAndExpand,  Placeholder = "Difference", Keyboard = Keyboard.Numeric  };



			var btnAdd = new Button { Text = "Add MBM", HorizontalOptions = LayoutOptions.FillAndExpand };

			var NumberCell = new ViewCell {
				View = new StackLayout {
					Children = { txtRight, txtLeft, txtDifference },
					Orientation = StackOrientation.Horizontal  
				}
			};
//

			ViewCell btnCell = new ViewCell {
				View = new StackLayout () {
					Children = { btnAdd, txtPatientVisitId }
				}
			};

			btnAdd.Clicked += delegate {
					

				MBM entity = new MBM();

				entity.RowId = 0;

				entity.Location = txtLocation.Text;
				entity.Markings =txtMarkings.Text;
				entity.Right = String.IsNullOrEmpty(txtRight.Text) ? 0 : Convert.ToDecimal(txtRight.Text);
				entity.Left = String.IsNullOrEmpty(txtLeft.Text) ? 0 : Convert.ToDecimal(txtLeft.Text);
				entity.Difference = String.IsNullOrEmpty(txtDifference.Text) ? 0 : Convert.ToDecimal(txtDifference.Text);


				if(txtPatientVisitId.Text != "0") // add to db if edit mode
				{
					entity.PatientVisitId = Convert.ToInt32(txtPatientVisitId.Text);
					entity = SoapManager.AddEntity<MBM>(entity,"api/MBM");
				}

				List<MBM> source;
				source = ((List<MBM>)ls.ItemsSource==null?new List<MBM>():(List<MBM>)ls.ItemsSource);
				source.Add(entity);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(MBMCell));
			};

			TableSection ts = new TableSection ();
			return new TableView () {
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 350,
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("MBM") {
						txtLocation,
						txtMarkings,
						NumberCell,
						btnCell	
					}
				}
			};
		}

		public MBMPage()
		{
			var form = CreateTable ();
			ls.ItemTemplate = new DataTemplate(typeof(MBMCell));
			ls.SetBinding (ListView.ItemsSourceProperty,"MBM",BindingMode.TwoWay);
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

	public class MBMCell : ViewCell
	{
		public MBMCell()
		{
			var idLabel = new Label { IsVisible = false };
			idLabel.SetBinding (Label.TextProperty, "RowId");

			var patientVisitIdLabel = new Label { IsVisible = false };
			patientVisitIdLabel.SetBinding (Label.TextProperty, "PatientVisitId");
		
			var lblLocation = new Label
			{
				FontSize = 15,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			lblLocation.SetBinding(Label.TextProperty, new Binding(path: "Location", stringFormat: "Location: {0}"));

			var lblMarkings = new Label {
				FontSize = 15,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblMarkings.SetBinding (Label.TextProperty, new Binding(path: "Markings",stringFormat: "Markings: {0}"));

				
			var detailsLayout = CreateDetailsLayout();

			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children = { idLabel, patientVisitIdLabel,lblLocation,lblMarkings, detailsLayout }
			};
			View = viewLayout;
		}

		static StackLayout CreateDetailsLayout()
		{


			var lblRight = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand 
			};
			lblRight.SetBinding (Label.TextProperty, new Binding(path: "Right",stringFormat: "Right: {0} inch"));
		
			var lblLeft = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblLeft.SetBinding (Label.TextProperty, new Binding(path: "Left",stringFormat: "Left: {0} inch"));

			var lblDifference = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			lblDifference.SetBinding (Label.TextProperty, new Binding(path: "Difference",stringFormat: "Difference: {0} inch"));

			var detailLayout = new StackLayout (){ 
				Orientation = StackOrientation.Horizontal,
				Children = { lblRight,lblLeft,lblDifference}
			};

			return detailLayout;
		}
	}
}


