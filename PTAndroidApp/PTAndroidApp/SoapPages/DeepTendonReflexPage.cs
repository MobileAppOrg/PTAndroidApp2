using System;
using XLabs.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Collections.Generic;
using PTAndroidApp.ValueConverters;

namespace PTAndroidApp
{
	public class DeepTendonReflexPage : ContentPage
	{
		private static CheckBox btnLegend = new CheckBox { HeightRequest = 10, WidthRequest = 47};
		private static List<string> lstGrades = new List <string>()
		{"0",
			"+",
			"++",
			"+++",
			"++++"};

		public DeepTendonReflexPage ()
		{
			var form = CreateTable ();

			var bodybackground = new Image (){ Source = "img2.jpg", Aspect = Aspect.AspectFit };

			var body = new RelativeLayout () {
				HeightRequest = 300,
				VerticalOptions = LayoutOptions.FillAndExpand
			};	

			var body2 = new StackLayout () { IsVisible = false,
				Children = { body }
			}; 
			body.Children.Add(bodybackground, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => { return parent.Width; }),
				Constraint.RelativeToParent ((parent) => { return parent.Height; })
			);

			var btn = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				Children = {
					new Label (){ FontSize = 15, Text = "Show Legend" },
					btnLegend
				}
			};

			btnLegend.CheckedChanged   += delegate {

				if (btnLegend.Checked )
				{
				body2.IsVisible = true;
				form.IsVisible = false;
				}
				else
				{
				body2.IsVisible = false;
				form.IsVisible = true;
				}
			};

			Content = new StackLayout { 
				Children = {
					form, btn,body2
				}
			};

		

		}


		public TableView CreateTable(){



			var Hand = new	BalTolCell ();
			var Elbow = new	BalTolCell ();
			var Knee = new	BalTolCell ();
			var Foot = new	BalTolCell ();
			var txtSignificance = new Editor { };
			var txtFindings = new Editor {};



			Hand.LEFT.SetBinding (Picker.SelectedIndexProperty, "DeepTendonReflex.LeftHand", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = lstGrades  });
			Hand.RIGHT.SetBinding (Picker.SelectedIndexProperty, "DeepTendonReflex.RightHand", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = lstGrades  });

			Elbow.LEFT.SetBinding (Picker.SelectedIndexProperty, "DeepTendonReflex.LeftElbow", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = lstGrades  });
			Elbow.RIGHT.SetBinding (Picker.SelectedIndexProperty, "DeepTendonReflex.RightElbow", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = lstGrades  });

			Knee.LEFT.SetBinding (Picker.SelectedIndexProperty, "DeepTendonReflex.LeftKnee", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = lstGrades  });
			Knee.RIGHT.SetBinding (Picker.SelectedIndexProperty, "DeepTendonReflex.RightKnee", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = lstGrades  });

			Foot.LEFT.SetBinding (Picker.SelectedIndexProperty, "DeepTendonReflex.LeftFoot", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = lstGrades  });
			Foot.RIGHT.SetBinding (Picker.SelectedIndexProperty, "DeepTendonReflex.RightFoot", 
				BindingMode.TwoWay, new IndexToGenericListConverter (){ ItemList = lstGrades  });

			txtSignificance  .SetBinding (Editor.TextProperty, "DeepTendonReflex.Significance", BindingMode.TwoWay);

			txtFindings  .SetBinding (Editor.TextProperty, "DeepTendonReflex.Findings", BindingMode.TwoWay);


			ViewCell HandLabel = new ViewCell {

				View = new StackLayout () {
					BackgroundColor = Color.Silver ,
					Orientation = StackOrientation.Horizontal ,
					Children = {
						new Label (){HorizontalOptions = LayoutOptions .StartAndExpand, Text = "  LEFT HAND"},
						new Label (){HorizontalOptions = LayoutOptions.EndAndExpand ,Text = "RIGHT HAND   "},
					}
				}
			};

			ViewCell ElbowLabel = new ViewCell {
				View = new StackLayout () {
					BackgroundColor = Color.Silver ,
					Orientation = StackOrientation.Horizontal ,
					Children = {
						new Label (){HorizontalOptions = LayoutOptions .StartAndExpand, Text = "  LEFT ELBOW"},
						new Label (){HorizontalOptions = LayoutOptions.EndAndExpand ,Text = "RIGHT ELBOW   "},
					}
				}
			};
			ViewCell KneeLabel = new ViewCell {
				View = new StackLayout () {
					BackgroundColor = Color.Silver ,
					Orientation = StackOrientation.Horizontal ,
					Children = {
						new Label (){HorizontalOptions = LayoutOptions .StartAndExpand, Text = "  LEFT KNEE"},
						new Label (){HorizontalOptions = LayoutOptions.EndAndExpand ,Text = "RIGHT KNEE   "},
					}
				}
			};

			ViewCell FootLabel = new ViewCell {
				View = new StackLayout () {
					BackgroundColor = Color.Silver ,
					Orientation = StackOrientation.Horizontal ,
					Children = {
						new Label (){HorizontalOptions = LayoutOptions .StartAndExpand, Text = "  LEFT FOOT"},
						new Label (){HorizontalOptions = LayoutOptions.EndAndExpand ,Text = "RIGHT FOOT   "},
					}
				}
			};

			var FindingsCell = new ViewCell {
				//Height = 200,
				View = new StackLayout () {
					Children = {
						new Label (){HorizontalOptions = LayoutOptions .Fill, Text = "Findings:"},

						txtFindings },
					Orientation = StackOrientation.Horizontal
				}
			};

			var SignificanceCell = new ViewCell {
				//Height = 200,
				View = new StackLayout () {
					Children = {
						new Label (){HorizontalOptions = LayoutOptions .Fill, Text = "Significance:"},
						txtSignificance },
					Orientation = StackOrientation.Horizontal
				}
			};


			return new TableView()
			{
				BackgroundColor = Color.Transparent ,
				HasUnevenRows = true,
				Intent = TableIntent.Form ,
				Root =  new TableRoot (){
					new TableSection ("Deep Tendon Reflex")
					{

						HandLabel,
						Hand,
						ElbowLabel,
						Elbow,
						KneeLabel,
						Knee,
						FootLabel,
						Foot,
						FindingsCell,
						SignificanceCell

					}


				}
			};

		}



		public class BalTolCell : ViewCell
		{
			public Picker LEFT  = new Picker () { 
				HorizontalOptions = LayoutOptions .StartAndExpand ,
				Title = "Select",
				Items = {
					"0",
					"+",
					"++",
					"+++",
					"++++",}};

			public Picker RIGHT  = new Picker () { 
				HorizontalOptions = LayoutOptions .EndAndExpand ,
				Title = "Select",
				Items = {
					"0",
					"+",
					"++",
					"+++",
					"++++",}};

			public BalTolCell(){

				View=	new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions= LayoutOptions .Fill ,
							Padding = new Thickness(0,0,0,0),
					Children = { LEFT ,RIGHT}
				
				
				};


			}
		}












	}
}


