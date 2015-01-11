using System;
using RestSharp;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace PTAndroidApp
{
	public class Patient
	{
		// ADD Patient: Requires new Patient Model without Patient Id

		public bool Add(PatientModel Patient) {
			// Put code to communicate to web service here
			var client = new RestClient ("http://ptprojectapi.azurewebsites.net");
			// 
			var request = new RestRequest("api/Patients", Method.POST );

			// add parameters for all properties on an object
			request.AddObject(Patient);

			// send request
			client.ExecuteAsync (request, response => {
				// we need to handle errors here
				// if server encountered an error while adding patient record it will be indicated in the content
				// Notify user if error
				// Console.WriteLine (response.Content);
			});

			return true;
		}

		// EDIT Patient: Requires Updated Patient Model with Patient Id

		public bool Edit(PatientModel Patient){
			// Put code to communicate to web service here
			var client = new RestClient ("http://ptprojectapi.azurewebsites.net");
			// 
			var request = new RestRequest("api/Patients", Method.PUT );
			 
			// edit parameters for all properties on an object


			request.AddObject (Patient);
			client.ExecuteAsync (request, response => {
				// we need to handle errors here
				// if server encountered an error while adding patient record it will be indicated in the content
				// Notify user if error
				// Console.WriteLine (response.Content);
			}); 

			return true;
		}

		// DELETE Patient: Requires Patient Id

		public bool Delete(int PatientId){
			// Put code to communicate to web service here
			return true;
		}




		//Get patient
		public List<PatientModel> GetPatient()
		{
			// Put code to communicate to web service here
			var client = new RestClient ("http://ptprojectapi.azurewebsites.net");
			// 
			var request = new RestRequest("api/Patients", Method.GET );
			List<PatientModel> listPatients = new List<PatientModel> ();


			RestSharp.Deserializers.JsonDeserializer deserial= new JsonDeserializer();

			// send request
			listPatients = deserial.Deserialize<List<PatientModel>> (client.Execute (request));

			return listPatients;

		}


		public List<PatientModel> GetPatientbyID(int PatientId)
		{
			// Put code to communicate to web service here
			var client = new RestClient ("http://ptprojectapi.azurewebsites.net");
			// 
			var request = new RestRequest("api/Patients/5", Method.GET );
			List<PatientModel> listPatients = new List<PatientModel> ();


			RestSharp.Deserializers.JsonDeserializer deserial= new JsonDeserializer();

			// send request
			listPatients = deserial.Deserialize<List<PatientModel>> (client.Execute (request));

			return listPatients;

		}








		public List<PatientListItemModel> getPatientsList()
		{
			// Put code to communicate to web service here
			var client = new RestClient ("http://ptprojectapi.azurewebsites.net");
			// 
			var request = new RestRequest("api/PatientsList", Method.GET);
			List<PatientListItemModel> listPatients = new List<PatientListItemModel> ();


			RestSharp.Deserializers.JsonDeserializer deserial= new JsonDeserializer();

			// send request
			listPatients = deserial.Deserialize<List<PatientListItemModel>> (client.Execute (request));

			return listPatients;

		}

		//get patient
		public PatientModel GetPatient(int id)
		{
			// Put code to communicate to web service here
			var client = new RestClient ("http://ptprojectapi.azurewebsites.net");
			var request = new RestRequest("api/Patients/{id}", Method.GET);
			request.AddParameter("id",id);

			RestSharp.Deserializers.JsonDeserializer deserial= new JsonDeserializer();

			// send request
			var patient = deserial.Deserialize<PatientModel> (client.Execute (request));

			return patient;
		}
	}

	public class SoapManager {

		public List<SoapListItemModel> GetSoapList(int PatientId){
			// Put code to communicate to web service here
			var client = new RestClient ("http://ptprojectapi.azurewebsites.net");
			var request = new RestRequest("api/SoapList/{id}", Method.GET);
			request.AddParameter("id",PatientId);

			RestSharp.Deserializers.JsonDeserializer deserial= new JsonDeserializer();

			// send request
			var listSoap = deserial.Deserialize<List<SoapListItemModel>> (client.Execute (request));

			return listSoap;
		}

		public bool Add(SoapModel soap){
			// Put code to communicate to web service here
			var client = new RestClient ("http://ptprojectapi.azurewebsites.net");
			// 
			var request = new RestRequest("api/PatientVisits", Method.POST );

			// add parameters for all properties on an object
			request.AddObject(soap);

			// send request
			client.ExecuteAsync (request, response => {
				// we need to handle errors here
				// if server encountered an error while adding patient record it will be indicated in the content
				// Notify user if error
				 Console.WriteLine (response.Content);
			});

			return true;
		}
	}
}

