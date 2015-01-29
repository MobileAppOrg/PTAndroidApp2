using System;
using System.Collections.Generic;
using PTAndroidApp.Models;

namespace PTAndroidApp
{
	public class PatientVisit
	{
		public PatientVisit(){
			PMHx = new PMHx();
			FMHx = new FMHx();
			PSEHx = new PSEHx ();
			SubjectiveObjective = new SubjectiveObjective ();
			OcularInspection = new OcularInspection ();
			Palpation = new Palpation ();
		}

		//[Key]
		public int PatientVisitId { get; set; }

		//[Required]
		//[MaxLength(50)]
		public string FirstName { get; set; }
		//[Required]
		//[MaxLength(50)]
		public string LastName { get; set; }
		//[Required]
		public int Age { get; set; }
		//[MaxLength(1)]
		public string Sex { get; set; }                     // Sex = [M|F]
		//[MaxLength(150)]
		public string Address { get; set; }
		//[MaxLength(50)]
		public string CityTown { get; set; }
		//[MaxLength(50)]
		public string Province { get; set; }
		//[MaxLength(10)]
		public string CivilStatus { get; set; }
		//[MaxLength(5)]
		public string HandedNess { get; set; }
		//[MaxLength(50)]
		public string Occupation { get; set; }
		//[MaxLength(50)]
		public string Religion { get; set; }
		//public string Nationality { get; set; } //Not included in latest doc: 1/3/2015
		//[MaxLength(11)]
		public string PatientType { get; set; }

		public DateTime? DateOfAdmission { get; set; }
		public DateTime? DateOfConsultation { get; set; }
		//[MaxLength(50)]
		public string Surgeon { get; set; }
		public DateTime? DateOfSurgery { get; set; }

		//[MaxLength(50)]
		public string GeneralPhysician { get; set; }
		//[MaxLength(50)]
		public string Orthopedic { get; set; }
		//[MaxLength(50)]
		public string Neurologist { get; set; }
		//[MaxLength(50)]
		public string Cardiologist { get; set; }
		//[MaxLength(50)]
		public string Opthalmologoist { get; set; }
		//[MaxLength(50)]
		public string Pulmonologist { get; set; }
		//[MaxLength(50)]
		public string OtherDoctor { get; set; }

		//[MaxLength(50)]
		public string ReferringDoctor { get; set; }
		public DateTime? DateOfReferral { get; set; }
		public DateTime? DateOfInitialEvaluation { get; set; }

		public string Diagnosis { get; set; }

		public string HPI { get; set; }

		public PMHx PMHx { get; set; }
		public FMHx FMHx { get; set; }
		public PSEHx PSEHx { get; set; }
		public SubjectiveObjective SubjectiveObjective { get; set; }
		public OcularInspection OcularInspection { get; set; }
		public Palpation Palpation {get;set;}



		// Navigation Properties and Foreign Keys
		//

		//[ForeignKey("Patient")]
		public int PatientId { get; set; }
		//public Patient Patient { get; set; }

		public List<AncillaryProcedure> AncillaryProcedures { get; set; }
		public List<DrugHistory> DrugHistory { get; set; }

	}

	public class AncillaryProcedure
	{
		//[Key]
		public int RowId { get; set; }
		//[MaxLength(50)]
		public string ProcedureName { get; set; }
		public DateTime ProcedureDate { get; set; }
		//[MaxLength(50)]
		public string Result { get; set; }

		//[ForeignKey("PatientVisit")]
		public int PatientVisitId { get; set; }
		//public PatientVisit PatientVisit { get; set; }
	}

	public class AncillaryProcedureTypes
	{
		public int ProcedureId { get; set; }
		//[MaxLength(20)]
		public string ProcedureName { get; set; }
	}

	public class DrugHistory
	{
		//[Key]
		public int RowId { get; set; }
		//[MaxLength(50)]
		public string DrugName { get; set; }
		public DateTime DrugDate { get; set; }
		//[MaxLength(50)]
		public string Result { get; set; }

		//[ForeignKey("PatientVisit")]
		public int PatientVisitId { get; set; }
		//public PatientVisit PatientVisit { get; set; }
	}

	//[ComplexType]
	public class PMHx {
		//[MaxLength(50)]
		public bool Trauma { get; set; }
		public string TraumaText { get; set; }
		public bool Arthritis { get; set; }
		//additional
		public string ArthritisText { get; set; }
		public bool Asthma { get; set; }
		public DateTime? AsthmaDate { get; set; }
		public bool HPN { get; set; }
		//[MaxLength(50)]
		// DM bool?
		public bool DM { get; set; }
		//additional
		public string DMText { get; set; }

		public bool Allergies { get; set; }
		//[MaxLength(50)]
		public bool Surgery { get; set; }
		public string SurgeryText { get; set; }
		public DateTime? SurgeryDate { get; set; }
		//[MaxLength(50)]
		public bool Hospitalization { get; set; }
		public string HospitalizationText { get; set; }
		public DateTime? HospitalizationDate { get; set; }
		//[MaxLength(50)]
		public bool CardiovascularDisease { get; set; }
		public string CardiovascularDiseaseText { get; set; }
		//[MaxLength(50)]
		public bool PulmonaryCondition { get; set; }
		public string PulmonaryConditionText { get; set; }
		//[MaxLength(50)]
		public bool NeurologyCondition { get; set; }
		public string NeurologyConditionText { get; set; }
		public bool Cancer { get; set; }
		//[MaxLength(50)]
		public string Others { get; set; }
	}

	//[ComplexType]
	public class FMHx
	{
		public bool HypertensionF { get; set; }
		public bool HypertensionM { get; set; }
		public bool ArthritisF { get; set; }
		public bool ArthritisM { get; set; }
		public bool DiabetesMellitusF { get; set; }
		public bool DiabetesMellitusM { get; set; }
		public bool CancerF { get; set; }
		public bool CancerM { get; set; }
		public bool AsthmaF { get; set; }
		public bool AsthmaM { get; set; }
		public bool AllergiesF { get; set; }
		public bool AllergiesM { get; set; }
		public bool NeurologicConditionF { get; set; }
		public bool NeurologicConditionM { get; set; }
		public string Others { get; set; }
		public bool OthersF { get; set; }
		public bool OthersM { get; set; }
	}

	public class SoapListItemModel
	{
		public int PatientVisitId { get; set; }
		public DateTime Date { get; set; }
	}

	public class PSEHx
	{
		public string FinancialStatus { get; set; }
		public string PersonalityType { get; set; }
		public string LifeStyle { get; set; }
		public string EducationalAttainment { get; set; }
		public string LivesWith { get; set; }
		public int NumberOfOffspring { get; set; }
		public string Relatives {get;set;}
		public string OtherLivesWith { get; set; }
		public string Hobbies { get; set; }
		public string Sports { get; set; }
		public string OtherHobbies { get; set; }
		public bool CigaretteSmoker { get; set; }
		public bool AlcoholDrinker { get; set; }
		public string TypeOfHouse { get; set; }
		public string OtherTypeOfHouse { get; set; }
	}

	public class SubjectiveObjective
	{
		public string ChiefComplaint { get; set; }
		public string PtTranslation {get;set;}
		public string BPBefore { get; set; }
		public string BPAfter { get; set; }
		public string RRBefore { get; set; }
		public string RRAfter { get; set; }
		public string PRBefore { get; set; }
		public string PRAfter { get; set; }
		public string TBefore { get; set; }
		public string TAfter { get; set; }
		public string Findings {get;set;}
		public string Significance {get;set;}
	}

	public class OcularInspection
	{
		public bool Ambulation { get; set; }
		public bool TADWheelChair { get; set; }
		public string TADCruches {get;set;}
		public string TADCane {get;set;}
		public string TADWalker {get;set;}
		public bool Alert {get;set;}
		public bool Coherent {get;set;}
		public bool Cooperative { get; set; }
		public string BodyType { get; set; }
		public string Atrophy {get;set;}
		public string Swelling {get;set;}
		public string Redness {get;set;}
		public string Ecchymosis {get;set;}
		public string Deformity {get;set;}
		public string Wounds {get;set;}
		public string Scar { get; set; }
		public string PressureSore {get;set;}
		public bool GaitDeviation {get;set;}
		public string Incision {get;set;}
		public bool ShortnessOfBreathing {get;set;}
		public string Others {get;set;}
	}

	public class Palpation
	{
		public string BodyTemperature {get;set;}
		public string MuscleTone {get;set;}
		public string Edema {get;set;}
		public string Tenderness {get;set;}
		public string Location {get;set;}
		public string Deformity {get;set;}
		public bool MuscleGuarding {get;set;}
		public bool MuscleSpasm {get;set;}
		public bool Subluxation {get;set;}
		public bool Dislocation{ get; set; }
	}
}

