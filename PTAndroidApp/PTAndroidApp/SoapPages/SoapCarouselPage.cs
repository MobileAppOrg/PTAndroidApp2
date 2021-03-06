﻿using System;
using Xamarin.Forms;
using PTAndroidApp.Models;

namespace PTAndroidApp
{
	public class SoapPage:CarouselPage
	{

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			//DisplayAlert ("Carousel Page Main", "OnAppearing", "OK");
		}

		public SoapPage(int id, string mode = "Add"){
			Title = "Add SOAP";
			//DisplayAlert ("Carousel Page Main", "Constructor", "OK");
			PatientManager patientMgr = new PatientManager ();
			SoapManager soapMgr = new SoapManager ();
			PatientVisit soap = new PatientVisit ();
			Patient patient = new Patient ();

			if (mode == "Add") {
				patient = patientMgr.GetPatient (id);
				soap.PatientId = patient.PatientId;
				soap.FirstName = patient.FirstName;
				soap.LastName = patient.LastName;
				soap.Age = DateTime.Now.Year - patient.DateOfBirth.Year;
				soap.Address = patient.Address;
				soap.CityTown = patient.CityTown;
				soap.Province = patient.Province;
				soap.CivilStatus = patient.CivilStatus;
				soap.HandedNess = patient.HandedNess;
				soap.Sex = patient.Gender;
				soap.Occupation = patient.Occupation;
				soap.Religion = patient.Religion;
			} else {
				soap = soapMgr.GetSoap (id);
			}

			BindingContext = soap;

			Children.Add (new PatientGeneralInfoPage ());
			Children.Add (new AdmissiontInfoPage ());
			Children.Add (new HPIpage ());
			Children.Add (new AncillaryPage ());
			Children.Add (new DrugHxPage ());
			Children.Add (new PMHxPage ());
			Children.Add (new FMHxPage ());
			Children.Add (new PSEHxPage ());
			Children.Add (new SubjObjPage ());
			Children.Add (new OcularInspectionPage  ());
			Children.Add (new PalpationPage  ());
			Children.Add (new ROMPage  ());
			Children.Add (new Rom2Page  ());
			Children.Add (new ROMFindSignPage ());
			Children.Add (new MMTPage  ());
			Children.Add (new MMTFindSigPage ());
			Children.Add (new SensoryAxPage  ());
			Children.Add (new SensorySigFindPage ());
			Children.Add (new CardioPulmonaryPage ());
			Children.Add (new PulmonaryAssmt1 ());
			Children.Add (new PulmonaryAssmt2 ());
			Children.Add (new PulmonaryAssmt3 ());
			Children.Add (new PulmonaryAssmt4 ());
			Children.Add (new PulmonaryAssmt5 ());
			Children.Add (new CranialNervePage ());
			Children.Add (new CrainialNerveAssmtFindSigPage ());
			Children.Add (new CognitiveAssmtPage  ());
			Children.Add (new CoordinationAssmtPage ());
			Children.Add (new CoordinationAssmtFinSigPage ());
			Children.Add (new BalanceAndTolerancePage ());
			Children.Add (new DeepTendonReflexPage ());
			Children.Add (new HandGripStrengthPage ());
			Children.Add (new VolMeasPage ());
			Children.Add (new LandmarksPage ());
			Children.Add (new MBMPage ());
			Children.Add (new MBMFinSigPage ());
			Children.Add (new AnteriorViewPage ());
			Children.Add (new PosteriorViewPage ());
			Children.Add (new LateralViewPage ());
			Children.Add (new GaitAssmentPage ());
			Children.Add (new FunctionalAnalysisPage ());
			Children.Add (new AssessmentPage ());
			Children.Add (new PlanPage ());

			ToolbarItems.Add (new ToolbarItem(){
				Icon = "",
				Text = "Save",
				Command = new Command(()=> {
					try {

						if (mode!="Add")
							soapMgr.Edit(soap.PatientVisitId,soap);
						else
							soapMgr.Add(soap);
						DisplayAlert("SOAP", "Saved", "OK");
						Navigation.PopAsync();
					}
					catch (Exception e)
					{
						DisplayAlert("Error", e.Message, "OK");
					}
				})
			});

			if (mode != "Add") {
				ToolbarItems.Add (new ToolbarItem () {
					Icon="",
					Text="Delete",
					Order=ToolbarItemOrder.Secondary,
					Command = new Command(()=> { 
						try {
							soapMgr.Delete(soap.PatientVisitId);
							DisplayAlert("SOAP", "Deleted", "OK");
							Navigation.PopAsync();
						}
						catch (Exception e){
							DisplayAlert("Error", e.Message, "OK");
						}
					})
				});
			}
		}
	}
}

