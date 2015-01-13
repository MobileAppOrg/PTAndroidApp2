﻿using System;
using RestSharp;
using System.Collections.Generic;
using RestSharp.Deserializers;
using PTAndroidApp.Models;

namespace PTAndroidApp
{
	public class PatientManager
	{
		// ADD Patient: Requires new Patient Model without Patient Id
		string clientUrl = "http://ptprojectapi.azurewebsites.net";
		//string clientUrl = "https://localhost:44301";
		//string clientUrl = "localhost:57131";

		public bool Add(Patient Patient) {
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);

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

		public bool Edit(int id,Patient patient){
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);

			// 
			var request = new RestRequest("api/Patients/Edit/{id}", Method.POST );
			request.RequestFormat = DataFormat.Json;

			RestSharp.Serializers.JsonSerializer serializer = new RestSharp.Serializers.JsonSerializer ();
			var _patient = serializer.Serialize (patient);
			// edit parameters for all properties on an object
			request.Parameters.Clear();
			//request.AddHeader("Accept", "application/json");
			//request.AddHeader ();
			request.AddUrlSegment ("id", id.ToString());
			request.AddBody (patient);
			//request.AddParameter ("patient", _patient, ParameterType.RequestBody);
			client.ExecuteAsync (request, response => {
				// we need to handle errors here
				// if server encountered an error while adding patient record it will be indicated in the content
				// Notify user if error
				Console.WriteLine (response.Content);
			}); 

			return true;
		}

		// DELETE Patient: Requires Patient Id

		public bool Delete(int PatientId){
			// Put code to communicate to web service here
			return true;
		}




		//Get patient
		public List<Patient> GetPatient()
		{
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);

			var request = new RestRequest("api/Patients", Method.GET );
			List<Patient> listPatients = new List<Patient> ();


			RestSharp.Deserializers.JsonDeserializer deserial= new JsonDeserializer();

			// send request
			listPatients = deserial.Deserialize<List<Patient>> (client.Execute (request));

			return listPatients;

		}

		//get patient
		public Patient GetPatient(int id)
		{
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);
			var request = new RestRequest("api/Patients/{id}", Method.GET);
			request.AddParameter("id",id);

			RestSharp.Deserializers.JsonDeserializer deserial= new JsonDeserializer();

			// send request
			var patient = deserial.Deserialize<Patient> (client.Execute (request));

			return patient;
		}

		public List<Patient> GetPatientbyID(int PatientId)
		{
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);
			// 
			var request = new RestRequest("api/Patients/5", Method.GET );
			List<Patient> listPatients = new List<Patient> ();


			RestSharp.Deserializers.JsonDeserializer deserial= new JsonDeserializer();

			// send request
			listPatients = deserial.Deserialize<List<Patient>> (client.Execute (request));

			return listPatients;

		}

		public List<PatientListItemModel> getPatientsList()
		{
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);

			var request = new RestRequest("api/PatientsList", Method.GET);



			List<PatientListItemModel> listPatients = new List<PatientListItemModel> ();


			RestSharp.Deserializers.JsonDeserializer deserial= new JsonDeserializer();

			// send request
			listPatients = deserial.Deserialize<List<PatientListItemModel>> (client.Execute (request));

//			client.ExecuteAsync (request, response => {
//				// we need to handle errors here
//				// if server encountered an error while adding patient record it will be indicated in the content
//				// Notify user if error
//				Console.WriteLine (response.Content);
//			}); 
//
			return listPatients;

		}
	}

	public class SoapManager {
		// ADD Patient: Requires new Patient Model without Patient Id
		string clientUrl = "http://ptprojectapi.azurewebsites.net";
		//string clientUrl = "https://localhost:44301";
		//string clientUrl = "localhost:57131";

		public List<SoapListItemModel> GetSoapList(int PatientId){
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);
			var request = new RestRequest("api/SoapList/{id}", Method.GET);
			request.AddParameter("id",PatientId);

			RestSharp.Deserializers.JsonDeserializer deserial= new JsonDeserializer();

			// send request
			var listSoap = deserial.Deserialize<List<SoapListItemModel>> (client.Execute (request));

			return listSoap;
		}

		public bool Add(PatientVisit soap){
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);
			// 
			var request = new RestRequest("api/PatientVisits", Method.POST );

			// add parameters for all properties on an object
			request.AddObject(soap);
			request.RequestFormat = DataFormat.Json;

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

