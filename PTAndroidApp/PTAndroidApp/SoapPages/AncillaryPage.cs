using System;

using Xamarin.Forms;

namespace PTAndroidApp
{
	public class AncillaryPage:ContentPage 
	{
		Grid gr = new Grid ();

		public AncillaryPage ()
		{


			var lblAncillaryProc = new Label {
				Text = "Ancillary Procedure", FontSize = 17,
				VerticalOptions = LayoutOptions .EndAndExpand,
				HorizontalOptions = LayoutOptions .Center };

			var pckAncillary = new Picker () { Items = { "XRAY", "MRI", "Blood Test","NCV","EMG","CT SCAN", "Others"}, 
				Title = "List of Procedure", 
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

			var AncillaryControls = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical ,
				Children = {  lblAncillaryProc, pckAncillary, txtAncillary,txtResult,
					dtAncillary,  btnAdd }
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
				}
				else 
				{
					AncillaryProcedure =  pckAncillary.Items [pckAncillary .SelectedIndex ];
					txtAncillary.IsVisible = false ;
				}

			};


			btnAdd.Clicked += delegate {
				int i = gr.Children.Count;
				gr.Children.Add(new Label{Text = AncillaryProcedure , FontSize= 15, VerticalOptions = LayoutOptions.Start , HorizontalOptions = LayoutOptions .CenterAndExpand },0,i);
				gr.Children.Add(new Label{Text = dtAncillary .Date .ToString (), FontSize = 15, VerticalOptions = LayoutOptions.Start , HorizontalOptions = LayoutOptions .CenterAndExpand },1,i);
				gr.Children.Add(new Label{Text = txtResult .Text,FontSize = 15, VerticalOptions = LayoutOptions.Start , HorizontalOptions = LayoutOptions.CenterAndExpand  },2,i);
			}; 



			var AncillaryList = new ScrollView {
				Content = new StackLayout {
					Children = {gr}
				}

			};

			Content = new StackLayout {
				Children = { AncillaryControls, AncillaryList }
			};



		}

	


	}
}


