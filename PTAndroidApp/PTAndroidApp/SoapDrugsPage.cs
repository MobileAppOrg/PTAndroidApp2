using System;

using Xamarin.Forms;

namespace PTAndroidApp
{
	public class DrugHxPage : ContentPage
	{
		Grid gr = new Grid ();
		RowDefinition row = new RowDefinition(){ Height = GridLength.Auto };
		ColumnDefinition col = new ColumnDefinition(){Width = new GridLength(1, GridUnitType.Star)};


		public DrugHxPage ()
		{
			Entry txtDrug = new Entry {Placeholder="Drug" };
			Entry txtDate = new Entry {Placeholder="Date" };
			Entry txtResult = new Entry{Placeholder="Result" };
			Button btnAdd = new Button (){ Text = "Add"};

			btnAdd.Clicked += delegate {
				int i = gr.Children.Count;
				gr.Children.Add(new Label{Text = txtDrug.Text},0,i);
				gr.Children.Add(new Label{Text = txtDate.Text},1,i);
				gr.Children.Add(new Label{Text = txtResult.Text},2,i);
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
			//gr.ColumnDefinitions
			gr.Children.Add (new Label{Text="Drug"},0,0);
			gr.Children.Add (new Label{Text="Date"},1,0);
			gr.Children.Add (new Label{Text="Result"},2,0);

			Content = new StackLayout { 
				Children = {
					form,
					gr
				}
			};
		}
			
	}
}


