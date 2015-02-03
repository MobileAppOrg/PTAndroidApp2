﻿
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
			CognitiveAssmt = new CognitiveAssmt ();
			BalanceTolerance = new BalanceTolerance ();
			DeepTendonReflex = new DeepTendonReflex ();
			HandGripStrength = new HandGripStrength ();
			VolumetricMeasurement = new VolumetricMeasurement ();
			AnteriorView = new AnteriorView ();
			PosteriorView = new PosteriorView ();
			LateralView = new LateralView ();
			GaitAssessment = new GaitAssessment ();
			FunctionalAnalysis = new FunctionalAnalysis ();
			Assessment = new Assessment ();
			Plan = new Plan ();
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

		public string RomFindings { get; set; }
		public string RomSignificance { get; set; }

		public string MmtFindings { get; set; }
		public string MmtSignificance { get; set; }

		public string SensoryFindings { get; set; }
		public string SensorySignificance { get; set; }

		public string CranialNerveAssmtFindings { get; set; }
		public string CranialNerveAssmtSignificance { get; set; }

		public string CoordinationAssmtFindings { get; set; }
		public string CoordinationAssmtSignificance { get; set; }

		public string MbmFindings { get; set; }
		public string MbmSignificance { get; set; }

		public string PosturalAssmtFindings { get; set; }
		public string PosturalAssmtSignificance { get; set; }

		public PMHx PMHx { get; set; }
		public FMHx FMHx { get; set; }
		public PSEHx PSEHx { get; set; }
		public SubjectiveObjective SubjectiveObjective { get; set; }
		public OcularInspection OcularInspection { get; set; }
		public Palpation Palpation { get; set; }
		public CognitiveAssmt CognitiveAssmt { get; set; }
		public BalanceTolerance BalanceTolerance { get; set; }
		public DeepTendonReflex DeepTendonReflex { get; set; }
		public HandGripStrength HandGripStrength { get; set; }
		public VolumetricMeasurement VolumetricMeasurement { get; set; }
		public AnteriorView AnteriorView { get; set; }
		public PosteriorView PosteriorView { get; set; }
		public LateralView LateralView { get; set; }
		public GaitAssessment GaitAssessment { get; set; }
		public FunctionalAnalysis FunctionalAnalysis { get; set; }
		public Assessment Assessment { get; set; }
		public Plan Plan { get; set; }

		// Navigation Properties and Foreign Keys
		//

		//[ForeignKey("Patient")]
		public int PatientId { get; set; }
		//public Patient Patient { get; set; }

		public List<AncillaryProcedure> AncillaryProcedures { get; set; }
		public List<DrugHistory> DrugHistory { get; set; }
		public List<ROM> ROMs { get; set; }
		public List<ROM2> ROM2s { get; set; }
		public List<MMT> MMTs { get; set; }
		public List<SensoryAx> SensoryAxs{ get; set; }
		public List<CranialNerveAssmt> CranialNerveAssmts{ get; set; }
		public List<CoordinationAssmt> CoordinationAssmts { get; set; }
		public List<MBM> MBMs { get; set; }
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

	public class ROM
	{
		public int RowId { get; set; }
		public string Motion { get; set; }
		public decimal Arom { get; set; }
		public decimal Prom { get; set; }
		public decimal NormalValue { get; set; }
		public decimal Difference { get; set;}
		public string EndFeel { get; set; }
		public int PatientVisitId { get; set; }
	}

	public class ROM2
	{
		public int RowId { get; set; }
		public string Motion { get; set; }
		public decimal AromR { get; set; }
		public decimal AromL { get; set; }
		public decimal PromR { get; set; }
		public decimal PromL { get; set; }
		public decimal NormalValue { get; set; }
		public decimal DifferenceR { get; set;}
		public decimal DifferenceL { get; set;}
		public string EndFeel { get; set; }
		public int PatientVisitId { get; set; }
	}

	public class MMT
	{
		public int RowId { get; set; }
		public string Motion { get; set; }
		//public decimal GradeR { get; set; }
		public string GradeR { get; set; }
		//public decimal GraderL { get; set; }
		public string GradeL { get; set; }
		public int PatientVisitId { get; set; }
	}

	public class SensoryAx
	{
		public int RowId { get; set; }
		//added
		public string Stimuli { get; set; }
		public string MaterialUsed { get; set; }
		public string Landmarks { get; set; }
		public string Result { get; set; }
		public int PatientVisitId { get; set; }
	}

	public class CranialNerveAssmt
	{
		public int RowId { get; set; }
		public string CranialNerve { get; set; }
		public string Right { get; set; }
		public string Left { get; set; }
		public string Result { get; set; }
		public int PatientVisitId { get; set; }
	}

	public class CognitiveAssmt
	{
		public string STQuestion { get; set; }
		public string STResponse { get; set; }
		public string LTQuestion { get; set; }
		public string LTResponse { get; set; }
		public string Findings { get; set; }
		public string Significance { get; set; }
	}

	public class CoordinationAssmt
	{
		public int RowId { get; set; }
		public string CoordinationTest { get; set; }
		public string Right { get; set; }
		public string Left { get; set; }
		public string Result { get; set; }
		public int PatientVisitId { get; set; }
	}

	public class BalanceTolerance
	{
		public string SittingBalance { get; set; }
		public string SittingTolerance { get; set; }
		public string StandingBalance { get; set; }
		public string StandingTolerance { get; set; }
		public string Findings { get; set; }
		public string Significance { get; set; }
	}

	public class DeepTendonReflex
	{
		public string LeftHand { get; set; }
		public string RightHand { get; set; }
		public string LeftElbow { get; set; }
		public string RightElbow { get; set; }
		public string LeftKnee { get; set; }
		public string RightKnee { get; set; }
		public string LeftFoot { get; set; }
		public string RightFoot { get; set; }
		public string Findings { get; set; }
		public string Significance { get; set; }
	}

	public class MBM
	{
		public int RowId { get; set; }
		public string Location { get; set; }
		public string Markings { get; set; }
		public decimal Right { get; set; }
		public decimal Left { get; set; }
		public decimal Difference { get; set; }
		public int PatientVisitId { get; set; }
	}

	public class HandGripStrength
	{
		public decimal T1RightHand { get; set; }
		public decimal T1LeftHand { get; set; }
		public decimal T2RightHand { get; set; }
		public decimal T2LeftHand { get; set; }
		public decimal T3RightHand { get; set; }
		public decimal T3LeftHand { get; set; }
		public decimal AveRightHand { get; set; }
		public decimal AveLeftHand { get; set; }
		public string Findings { get; set; }
		public string Significance { get; set; }
	}

	public class VolumetricMeasurement
	{
		public decimal Right { get; set; }
		public decimal Left { get; set; }
		public decimal Difference { get; set; }
		public string Findings { get; set; }
		public string Significance { get; set; }
	}

	public class AnteriorView
	{
		public bool HeadInMidline { get; set; }
		public string HeadInMidlineFindings { get; set; }
		public bool ShouldersInLevel { get; set; }
		public string ShouldersInLevelFindings { get; set; }
		public bool Protrusion { get; set; }
		public string ProtrusionFindings { get; set; }
		public bool Lateralization { get; set; }
		public string LateralizationFindings { get; set; }
		public bool Depression { get; set; }
		public string DepressionFindings { get; set; }
		public decimal WaistAngle { get; set; }
		public string ArmPosition { get; set; }
		public decimal CarryingAngle { get; set; }
		public string ASISLevel { get; set; }
		public string PatellaeAlignment { get; set; }
		public string KneeAlignment { get; set; }
		public string MalleoliLevel { get; set; }
		public string ArchesOfFeet  { get; set; }
		public bool FeetAngle { get; set; }
		public string FeetAngleFindings { get; set; }
	}

	public class PosteriorView
	{
		public bool HeadInMidline { get; set; }
		public string HeadInMidlineFindings { get; set; }
		public bool ShouldersInLevel { get; set; }
		public string ShouldersInLevelFindings { get; set; }
		public bool SpineScapularLevel { get; set; }
		public string SpineScapularLevelFindings { get; set; }
		public bool SpineInMidline { get; set; }
		public string SpineInMidlineFindings { get; set; }
		public decimal WaistLevelAngle { get; set;}
		public string ArmPosition { get; set; }
		public string IliacCrestlevel { get; set; }
		public string PSISLevel { get; set; }
		public string GlutealFoldsLevel { get; set; }
		public string PoplitealFoassalevel { get; set; }
		public string HeelsPosition { get; set; }
	}

	public class LateralView
	{
		public bool EarlobeShoulderAlignment { get; set; }
		public string EarlobeShoulderAlignmentFindings { get; set; }
		public bool AcromioIliacAlignment { get; set; }
		public string AcromioIliacAlignmentFindings { get; set; }
		public string SpinalSegments { get; set; }
		public string ShoulderAlignment { get; set; }
		public decimal PelvicAngle { get; set; }
		public string KneeAlignment { get; set; }
		public bool PlumblineAlignment { get; set; }
		public string PlumblineAlignmentFindings { get; set; }
		public string ArchesOfFeet { get; set; }
	}

	public class GaitAssessment
	{
		public string Asssessment { get; set; }
		public bool RInitialLoading { get; set; }
		public bool LInitialLoading { get; set; }
		public bool RLoadingResponse { get; set; }
		public bool LLoadingResponse { get; set; }
		public bool RMidStance { get; set; }
		public bool LMidStance { get; set; }
		public bool RTerminalStance { get; set; }
		public bool LTerminalStance { get; set; }
		public bool RPreSwing { get; set; }
		public bool LPreSwing { get; set; }
		public bool RInitialSwing { get; set; }
		public bool LInitialPreSwing { get; set; }
		public bool RMidSwing { get; set; }
		public bool LMidPreSwing { get; set; }
		public bool RTerminalSwing { get; set; }
		public bool LTerminalSwing { get; set; }
		public string Findings { get; set; }
		public string Significance { get; set; }
	}

	public class FunctionalAnalysis
	{
		public bool AdlsAxWriting { get; set; }
		public bool AdlsAxCleaningHouse { get; set; }
		public bool AdlsAxCooking { get; set; }
		public bool AdlsAxEating { get; set; }
		public bool AdlsAxTurningDoorKnob { get; set; }
		public bool AdlsAxUsingKeys { get; set; }
		public bool AdlsAxOpeningBottle { get; set; }
		public bool AdlsAxBrushingTeeth { get; set; }
		public bool AdlsAxTyingShoeLace { get; set; }
		public bool AdlsAxWashingDishes { get; set; }
		public bool AdlsAxSweepingFloor { get; set; }
		public bool AdlsAxOthers { get; set; }
		public string AdlsAxOthersText { get; set; }
	}

	public class Assessment {
		public string Diagnosis { get; set; }
		public string PTImpression { get; set; }
		public string ProblemList { get; set; }
		public string LongTermGoals { get; set; }
		public string ShortTermGoals { get; set; }
	}

	public class Plan {
		public string PTManagement { get; set; }
		public string HomeInstruction { get; set; }
	}
}

