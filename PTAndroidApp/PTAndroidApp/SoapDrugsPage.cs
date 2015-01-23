using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class DrugHxPage : ContentPage
	{
		Grid gr = new Grid ();
		RowDefinition row = new RowDefinition(){ Height = GridLength.Auto };
		ColumnDefinition col = new ColumnDefinition(){Width = new GridLength(1, GridUnitType.Star)};
		ListView ls = new ListView (){RowHeight=60};
		//Label patientId = new Label();


		public DrugHxPage ()
		{
			Entry txtDrug = new Entry { Placeholder="Drug" };
			Entry txtDate = new Entry { Placeholder="Date" };
			Entry txtResult = new Entry { Placeholder="Result" };
			Button btnAdd = new Button () { Text = "Add" };
			//patientId.SetBinding (Label.TextProperty, "PatientId");

//			btnAdd.Clicked += delegate {
//				int i = gr.Children.Count;
//				gr.Children.Add(new Label { Text = txtDrug.Text },0,i);
//				gr.Children.Add(new Label { Text = txtDate.Text },1,i);
//				gr.Children.Add(new Label { Text = txtResult.Text },2,i);
//			};

			btnAdd.Clicked += delegate {
				List<DrugHistory> source;

				source = ((List<DrugHistory>)ls.ItemsSource==null?new List<DrugHistory>():(List<DrugHistory>)ls.ItemsSource);

				source.Add(new DrugHistory(){
					DrugName =txtDrug.Text,
					DrugDate = Convert.ToDateTime(txtDate.Text),
					Result = txtResult.Text,
					//PatientVisitId = patientId.Text
				});
				ls.ItemsSource = source;
			};

			StackLayout form = new StackLayout{
				Children = {
					txtDrug,
					txtDate,
					txtResult,
					btnAdd
				}
			};

			gr.RowDefinitions.Add (row);
			gr.ColumnDefinitions.Add (col);
			gr.Children.Add (new Label{Text="Drug"},0,0);
			gr.Children.Add (new Label{Text="Date"},1,0);
			gr.Children.Add (new Label{Text="Result"},2,0);

			ls.SetBinding (ListView.ItemsSourceProperty, "DrugHistory",BindingMode.TwoWay);
			ls.ItemTemplate = new DataTemplate(typeof(DrugCell));

			Content = new StackLayout { 
				Children = {
					form,
					ls
					//gr
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
			idLabel.SetBinding (Label.TextProperty, "RowId", BindingMode.TwoWay);

//			var patientIdLabel = new Label {
//				IsVisible = false //false
//			};
//			patientIdLabel.SetBinding (Label.TextProperty, "PatientId");

			var nameLabel = new Label
			{
				FontSize = 20,
				HorizontalOptions= LayoutOptions.FillAndExpand
			};
			nameLabel.SetBinding(Label.TextProperty, "DrugName", BindingMode.TwoWay);

			var nameLayout = CreateNameLayout();

			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children = { idLabel,nameLabel, nameLayout }
			};
			View = viewLayout;
		}

		static StackLayout CreateNameLayout()
		{

			var dateLabel = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			dateLabel.SetBinding(Label.TextProperty, "DrugDate", BindingMode.TwoWay);

			var resultLabel = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			resultLabel.SetBinding (Label.TextProperty, "Result", BindingMode.TwoWay);

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


