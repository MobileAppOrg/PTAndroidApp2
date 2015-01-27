using System;

using Xamarin.Forms;

namespace PTAndroidApp
{
	public class SubjObjPage : ContentPage
	{

		static TableView CreateTable(){
			var ChiefComplaint = new EntryCell { Label = "Chief Complaint: "};
			ChiefComplaint.SetBinding (EntryCell.TextProperty, "SubjectiveObjective.ChiefComplaint");

			var PtTranslation = new EntryCell { Label = "PT Translation: "};
			PtTranslation.SetBinding (EntryCell.TextProperty, "SubjectiveObjective.PtTranslation");

			var BPCell = new SubjObjCell ();
			BPCell.entryBefore.SetBinding (Entry.TextProperty, "SubjectiveObjective.BPBefore");
			BPCell.entryAfter.SetBinding (Entry.TextProperty, "SubjectiveObjective.BPAfter");

			var RRCell = new SubjObjCell ();
			RRCell.entryBefore.SetBinding (Entry.TextProperty, "SubjectiveObjective.RRBefore");
			RRCell.entryAfter.SetBinding (Entry.TextProperty, "SubjectiveObjective.RRAfter");

			var PRCell = new SubjObjCell ();
			PRCell.entryBefore.SetBinding (Entry.TextProperty, "SubjectiveObjective.PRBefore");
			PRCell.entryAfter.SetBinding (Entry.TextProperty, "SubjectiveObjective.PRAfter");

			var TCell = new SubjObjCell ();
			TCell.entryBefore.SetBinding (Entry.TextProperty, "SubjectiveObjective.TBefore");
			TCell.entryAfter.SetBinding (Entry.TextProperty, "SubjectiveObjective.TAfter");

			var Findings = new EntryCell { Label = "Findings: "};
			Findings.SetBinding (EntryCell.TextProperty, "SubjectiveObjective.Findings");

			var Significance = new EntryCell { Label = "Significance: "};
			Significance.SetBinding (EntryCell.TextProperty, "SubjectiveObjective.Significance");

			return new TableView () {
				Intent = TableIntent.Settings,
				Root = new TableRoot () {
					new TableSection ("Subjective") {
						ChiefComplaint,
						PtTranslation
					},
					new TableSection ("Objective") {
						new ViewCell {View = new Label{ Text = "Vital Signs", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						new ViewCell {View = new Label{ Text = "BP", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						BPCell,
						new ViewCell {View = new Label{ Text = "RR", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						RRCell,
						new ViewCell {View = new Label{ Text = "PR", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						PRCell,
						new ViewCell {View = new Label{ Text = "T", FontAttributes = FontAttributes.Bold, YAlign = TextAlignment.Center, XAlign = TextAlignment.Center }},
						TCell,
						Findings,
						Significance
					}
				}
			};
		}

		public SubjObjPage ()
		{
			Content = new StackLayout { 
				Children = {
					CreateTable()
				}
			};
		}
	}

	public class SubjObjCell : ViewCell
	{
		public Label lblBefore = new Label(){Text = "Before: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
		public Entry entryBefore = new Entry(){ 
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.FillAndExpand, WidthRequest = 40 };
		public Label  lblAfter = new Label(){Text = "After: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center };
		public Entry entryAfter = new Entry(){ 
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.FillAndExpand, WidthRequest = 40  };

		public SubjObjCell(){
			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = { lblBefore, entryBefore, lblAfter, entryAfter }
			};
		}
	}
}


