using System;

namespace PTAndroidApp.Models
{
	public class Patient
	{
		public int PatientId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string CivilStatus { get; set; }
		public string HandedNess { get; set; }
		public string Gender { get; set; }
		public string Occupation { get; set; }
		public string Address { get; set; }
		public string Religion { get; set; }
		public string CityTown { get; set; }
		public string Province { get; set; }

	}

	public class PatientListItemModel
	{
		public int PatientId {get;set;}
		public string DisplayName {get;set;}
		public string Address { get; set;}
	}




}

