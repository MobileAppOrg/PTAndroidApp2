using System;
using Xamarin.Forms;
using PTAndroidApp.ValueConverters;
using System.Collections.Generic;

namespace PTAndroidApp
{
	public class AdmissiontInfoPage:ContentPage
	{
		public AdmissiontInfoPage(){
			TableView tblForm = CreateTable ();

			Content = new StackLayout{ 
				Children = { 
					tblForm
				}
			};
		}

		static TableView CreateTable(){
			List<string> listPatientType = new List<string> (){ "In-Patient","Out-Patient" };

			var PatientType = new Picker (){ Items = { "In-Patient","Out-Patient" }, 
				Title = "Patient Type", HorizontalOptions = LayoutOptions.FillAndExpand };
			var DateOfAdmission = new EntryCell (){ Label = "Admission Date: " };
			var DateOfConsultation = new EntryCell (){ Label = "Consultation Date: " };
			var Surgeon = new EntryCell (){ Label = "Surgeon: " };
			var DateOfSurgery = new EntryCell (){ Label = "Surgery Date: " };
			var GeneralPhysician = new EntryCell (){ Label = "General Physician: "};
			var Orthopedic = new EntryCell (){ Label = "Orthopedic: "};
			var Neurologist = new EntryCell (){ Label = "Neurologist: "};
			var Cardiologist = new EntryCell (){ Label = "Cardiologist: "};
			var Opthalmologoist = new EntryCell (){ Label = "Opthalmologoist: "};
			var Pulmonologist = new EntryCell (){ Label = "Pulmonologist: "};
			var OtherDoctor = new EntryCell (){ Label = "Other Doctor: "};
			var ReferringDoctor = new EntryCell (){ Label = "Referring Doctor: " };
			var DateOfReferral = new EntryCell () { Label = "Date Of Referral: " };
			var DateOfInitialEvaluation = new EntryCell (){ Label = "Date Of IE: " };
			var Diagnosis = new EntryCell (){ Label = "Diagnosis: "};

			ViewCell patienttypecell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Patient Type: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
						PatientType
					},
					Padding = new Thickness(5,1,1,1),
					HorizontalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Horizontal
				}
			};

			PatientType.SetBinding (Picker.SelectedIndexProperty, "PatientType", 
				BindingMode.TwoWay, new IndexToGenericListConverter(){ ItemList = listPatientType });
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
					new TableSection ("Admission Info") {
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

