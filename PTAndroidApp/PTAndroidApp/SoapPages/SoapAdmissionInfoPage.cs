using System;
using Xamarin.Forms;
using PTAndroidApp.ValueConverters;

namespace PTAndroidApp
{
	public class AdmissiontInfoPage:ContentPage
	{
		public AdmissiontInfoPage(){
			Title = "Admission Info";
			TableView tblForm = CreateTable ();

			Content = new StackLayout{ 
				Children = { 
					tblForm
				}
			};
		}

		static TableView CreateTable(){
			var patientTypePicker = new Picker (){ Items = { "In-Patient","Out-Patient" }, Title = "Patient Type", HorizontalOptions = LayoutOptions.FillAndExpand };
			var PatientType = new Entry (){ IsVisible = false };
			//var DateOfAdmission = new  DatePickerButton(){ HorizontalOptions = LayoutOptions.FillAndExpand };
			var DateOfAdmission = new EntryCell (){ Label = "Admission Date: " };
			//var DateOfConsultation = new DatePickerButton (){ HorizontalOptions = LayoutOptions.FillAndExpand };
			var DateOfConsultation = new EntryCell (){ Label = "Consultation Date: " };
			var Surgeon = new EntryCell (){ Label = "Surgeon: " };
			//var DateOfSurgery = new DatePickerButton (){ HorizontalOptions = LayoutOptions.FillAndExpand };
			var DateOfSurgery = new EntryCell (){ Label = "Surgery Date: " };
			var GeneralPhysician = new EntryCell (){ Label = "General Physician: "};
			var Orthopedic = new EntryCell (){ Label = "Orthopedic: "};
			var Neurologist = new EntryCell (){ Label = "Neurologist: "};
			var Cardiologist = new EntryCell (){ Label = "Cardiologist: "};
			var Opthalmologoist = new EntryCell (){ Label = "Opthalmologoist: "};
			var Pulmonologist = new EntryCell (){ Label = "Pulmonologist: "};
			var OtherDoctor = new EntryCell (){ Label = "Other Doctor: "};
			var ReferringDoctor = new EntryCell (){ Label = "Referring Doctor: " };
			//var DateOfReferral = new DatePickerButton () { HorizontalOptions = LayoutOptions.FillAndExpand };
			var DateOfReferral = new EntryCell () { Label = "Date Of Referral: " };
			//var DateOfInitialEvaluation = new DatePickerButton (){ HorizontalOptions = LayoutOptions.FillAndExpand };
			var DateOfInitialEvaluation = new EntryCell (){ Label = "Date Of IE: " };
			var Diagnosis = new EntryCell (){ Label = "Diagnosis: "};

			ViewCell patienttypecell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Patient Type: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
						patientTypePicker,
						PatientType
					},
					Padding = new Thickness(5,1,1,1),
					HorizontalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Horizontal
				}
			};

			patientTypePicker.SelectedIndexChanged += delegate(object sender, EventArgs e) {
				if (patientTypePicker.SelectedIndex == -1)
					PatientType.Text = null;
				else
					PatientType.Text = patientTypePicker.Items[patientTypePicker.SelectedIndex];
			};

			#region Commented Date Cells
			//			ViewCell DateOfAdmissionCell = new ViewCell{
			//				Height = 100,
			//				View = new StackLayout(){
			//					Children = {
			//						new Label (){ FontSize = 20, Text = "Date Of Admission: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
			//						DateOfAdmission,
			//						//DateOfAdmissionPicker
			//					},
			//					Padding = new Thickness(5,1,1,1),
			//					HorizontalOptions = LayoutOptions.Fill,
			//					Orientation = StackOrientation.Horizontal
			//				}
			//			};

			//			ViewCell DateOfConsultationCell = new ViewCell{
			//				Height = 100,
			//				View = new StackLayout(){
			//					Children = {
			//						new Label (){ FontSize = 20, Text = "Date Of Consultation: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
			//						DateOfConsultation
			//					},
			//					Padding = new Thickness(5,1,1,1),
			//					HorizontalOptions = LayoutOptions.Fill,
			//					Orientation = StackOrientation.Horizontal
			//				}
			//			};

			//			ViewCell DateOfSurgeryCell = new ViewCell{
			//				Height = 100,
			//				View = new StackLayout(){
			//					Children = {
			//						new Label (){ FontSize = 20, Text = "Date Of Surgery: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
			//						DateOfSurgery
			//					},
			//					Padding = new Thickness(5,1,1,1),
			//					HorizontalOptions = LayoutOptions.Fill,
			//					Orientation = StackOrientation.Horizontal
			//				}
			//			};

			//			ViewCell DateOfReferralCell = new ViewCell{
			//				Height = 100,
			//				View = new StackLayout(){
			//					Children = {
			//						new Label (){ FontSize = 20, Text = "Date Of Referral: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
			//						DateOfReferral
			//					},
			//					Padding = new Thickness(5,1,1,1),
			//					HorizontalOptions = LayoutOptions.Fill,
			//					Orientation = StackOrientation.Horizontal
			//				}
			//			};

			//			ViewCell DateOfInitialEvaluationCell = new ViewCell{
			//				Height = 100,
			//				View = new StackLayout(){
			//					Children = {
			//						new Label (){ FontSize = 20, Text = "Date Of IE: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
			//						DateOfInitialEvaluation
			//					},
			//					Padding = new Thickness(5,1,1,1),
			//					HorizontalOptions = LayoutOptions.Fill,
			//					Orientation = StackOrientation.Horizontal
			//				}
			//			};

			//			DateOfAdmissionPicker.DateSelected += async (object sender, DateChangedEventArgs e) => {
			//				Console.WriteLine(sender);
			//				Console.WriteLine(e);
			//			};
			#endregion

			PatientType.SetBinding (Entry.TextProperty, "PatientType", BindingMode.TwoWay);
			DateOfAdmission.SetBinding (EntryCell.TextProperty, "DateOfAdmission", BindingMode.TwoWay,new StringToNullDateTimeConverter());
			DateOfConsultation.SetBinding (EntryCell.TextProperty, "DateOfConsultation", BindingMode.TwoWay,new StringToNullDateTimeConverter());
			Surgeon.SetBinding (EntryCell.TextProperty, "Surgeon", BindingMode.TwoWay);
			DateOfSurgery.SetBinding (EntryCell.TextProperty, "DateOfSurgery", BindingMode.TwoWay,new StringToNullDateTimeConverter());
			GeneralPhysician.SetBinding (EntryCell.TextProperty, "GeneralPhysician", BindingMode.TwoWay);
			Orthopedic.SetBinding (EntryCell.TextProperty, "Orthopedic", BindingMode.TwoWay);
			Neurologist.SetBinding (EntryCell.TextProperty, "Neurologist", BindingMode.TwoWay);
			Cardiologist.SetBinding (EntryCell.TextProperty, "Cardiologist", BindingMode.TwoWay);
			Opthalmologoist.SetBinding (EntryCell.TextProperty, "Opthalmologoist", BindingMode.TwoWay);
			Pulmonologist.SetBinding (EntryCell.TextProperty, "Pulmonologist", BindingMode.TwoWay);
			OtherDoctor.SetBinding (EntryCell.TextProperty, "OtherDoctor", BindingMode.TwoWay);
			ReferringDoctor.SetBinding (EntryCell.TextProperty, "ReferringDoctor", BindingMode.TwoWay);
			DateOfReferral.SetBinding (EntryCell.TextProperty, "DateOfReferral", BindingMode.TwoWay,new StringToNullDateTimeConverter());
			DateOfInitialEvaluation.SetBinding (EntryCell.TextProperty, "DateOfInitialEvaluation", BindingMode.TwoWay,new StringToNullDateTimeConverter());
			Diagnosis.SetBinding (EntryCell.TextProperty, "Diagnosis", BindingMode.TwoWay);

			return new TableView () {
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection () {
						patienttypecell,
						DateOfAdmission,
						DateOfConsultation,
						Surgeon,
						DateOfSurgery,
						GeneralPhysician,
						Orthopedic,
						Neurologist,
						Cardiologist,
						Opthalmologoist,
						Pulmonologist,
						OtherDoctor,
						ReferringDoctor,
						DateOfReferral,
						DateOfInitialEvaluation,
						Diagnosis
					}
				}
			};

		}
	}
}

