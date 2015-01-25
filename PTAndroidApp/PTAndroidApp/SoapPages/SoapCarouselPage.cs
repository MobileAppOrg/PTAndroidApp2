﻿using System;
using Xamarin.Forms;

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
			Children.Add (new DrugHxPage ());

			ToolbarItems.Add (new ToolbarItem(){
				Icon = "",
				Text = "Save",
				Command = new Command(()=> {
					if (mode!="Add")
						soapMgr.Edit(soap.PatientVisitId,soap);
					else
						soapMgr.Add(soap);
				})
			});

			if (mode != "Add") {
				ToolbarItems.Add (new ToolbarItem () {
					Icon="",
					Text="Delete",
					Order=ToolbarItemOrder.Secondary,
					Command = new Command(()=>new SoapManager().Delete(soap.PatientVisitId))
				});
			}
		}
	}
}
