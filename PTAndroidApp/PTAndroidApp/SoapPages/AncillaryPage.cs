using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class  AncillaryPage:ContentPage 
	{
		Grid gr = new Grid ();
		RowDefinition row = new RowDefinition(){ Height = GridLength.Auto };
		ColumnDefinition col = new ColumnDefinition(){Width = new GridLength(1, GridUnitType.Star)};
		ListView ls = new ListView (){RowHeight=60};
		//Label patientId = new Label();


		public AncillaryPage ()
		{
			var pckAncillary = new Picker () { Items = { "XRAY", "MRI", "Blood Test","NCV","EMG","CT SCAN", "Others"}, 
				Title = "Procedures", 
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			var txtAncillary = new Entry {
				Placeholder = "Other Procedures",
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			var txtResult = new Entry {
				Placeholder = "Result",
				HorizontalOptions = LayoutOptions.FillAndExpand,

			};
			var dtAncillary = new DatePicker {
				Format = "D",
			};
			var btnAdd = new Button {
				Text = "Add Ancillary",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			var AncillaryProcedure = txtAncillary.Text ;


			txtAncillary.TextChanged += delegate {
				AncillaryProcedure = txtAncillary.Text;
			};

			pckAncillary.SelectedIndexChanged   += delegate  {

				if (pckAncillary .SelectedIndex  == -1 || pckAncillary.SelectedIndex   == 6 )
				{
					txtAncillary.IsVisible = true;
					AncillaryProcedure = txtAncillary.Text;
					txtAncillary.Focus ();
				}
				else 
				{
					AncillaryProcedure =  pckAncillary.Items [pckAncillary .SelectedIndex ];
					txtAncillary.IsVisible = false ;
				}

			};

			btnAdd.Clicked += delegate {
				List<AncillaryProcedure> source;

				source = ((List<AncillaryProcedure>)ls.ItemsSource==null?new List<AncillaryProcedure>():(List<AncillaryProcedure>)ls.ItemsSource);

				source.Add(new AncillaryProcedure(){
					ProcedureName = AncillaryProcedure,
					ProcedureDate = dtAncillary .Date ,
					Result = txtResult.Text,

				});
				ls.ItemsSource = source;
			};

			StackLayout form = new StackLayout{
				Children = {
					pckAncillary,
					txtAncillary,
					txtResult,
					dtAncillary,
					btnAdd
				}
			};

			gr.RowDefinitions.Add (row);
			gr.ColumnDefinitions.Add (col);
			gr.Children.Add (new Label{Text="Drug"},0,0);
			gr.Children.Add (new Label{Text="Date"},1,0);
			gr.Children.Add (new Label{Text="Result"},2,0);

			ls.SetBinding (ListView.ItemsSourceProperty, "AncillaryProcedure",BindingMode.TwoWay);
			ls.ItemTemplate = new DataTemplate(typeof(AncillaryPageCell));

			Content = new StackLayout { 
				Children = {
					form,
					ls
				}
			};
		}

	}

	public class AncillaryPageCell : ViewCell
	{
		public AncillaryPageCell()
		{
			var idLabel = new Label {
				IsVisible = false //false
			};

			idLabel.SetBinding (Label.TextProperty, "RowId", BindingMode.TwoWay);

			var nameLabel = new Label
			{
				FontSize = 20,
				HorizontalOptions= LayoutOptions.FillAndExpand
			};
			nameLabel.SetBinding(Label.TextProperty, "ProcedureName", BindingMode.TwoWay);

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
			dateLabel.SetBinding(Label.TextProperty, "ProcedureDate", BindingMode.TwoWay);

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


