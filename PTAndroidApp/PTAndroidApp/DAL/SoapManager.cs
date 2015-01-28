using System;
using RestSharp;
using System.Collections.Generic;
using RestSharp.Deserializers;
using Newtonsoft.Json;

namespace PTAndroidApp
{
	public class SoapManager {
		// ADD Patient: Requires new Patient Model without Patient Id
		private static string clientUrl = "http://ptprojectapi.azurewebsites.net";
		//string clientUrl = "https://localhost:44301";
		//string clientUrl = "localhost:57131";

		public PatientVisit GetSoap(int PatientVisitId){
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);
			var request = new RestRequest("api/PatientVisits/{id}", Method.GET);
			request.AddParameter("id",PatientVisitId);

			RestSharp.Deserializers.JsonDeserializer deserial= new JsonDeserializer();

			// send request
			var soap = deserial.Deserialize<PatientVisit> (client.Execute (request));

			return soap;
		}

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
			var request = new RestRequest("api/PatientVisits", Method.POST );

			// add parameters for all properties on an object
			string json = JsonConvert.SerializeObject (
				soap, 
				new JsonSerializerSettings (){ 
					DateFormatHandling = DateFormatHandling.IsoDateFormat,
					NullValueHandling = NullValueHandling.Include 
				});

			//request.AddObject(soap);
			request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
			request.RequestFormat = DataFormat.Json;

			// send request
			client.ExecuteAsync (request, response => {
				Console.WriteLine (response.Content);
			});

			return true;
		}

		public bool Edit(int id,PatientVisit soap){
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);
			var request = new RestRequest("api/PatientVisits/{id}", Method.PUT );

			request.RequestFormat = DataFormat.Json;

			// add parameters for all properties on an object
			string json = JsonConvert.SerializeObject (
				soap, 
				new JsonSerializerSettings (){ 
					DateFormatHandling = DateFormatHandling.IsoDateFormat,
					NullValueHandling = NullValueHandling.Include 
				});

			// edit parameters for all properties on an object
			request.Parameters.Clear();
			request.AddUrlSegment ("id", id.ToString());
			request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
			request.RequestFormat = DataFormat.Json;

			client.ExecuteAsync (request, response => {
				Console.WriteLine (response.Content);
			});

			return true;
		}

		public bool Delete(int PatientVisitId){
			// Put code to communicate to web service here
			var client = new RestClient ("http://ptprojectapi.azurewebsites.net");
			// 
			var request = new RestRequest("api/PatientVisits/{id}", Method.DELETE  );


			request.AddUrlSegment("id",PatientVisitId.ToString());
			RestSharp.Deserializers.JsonDeserializer deserial= new JsonDeserializer();

			// send request
			var soap = deserial.Deserialize<PatientVisit> (client.Execute (request));

			return true;
		}

		public bool AddDrugHx(DrugHistory DrugHx){
			var client = new RestClient (clientUrl);							// domain
			var request = new RestRequest("api/DrugHistories", Method.POST );	// request

			// serialize object to pass as parameter
			string json = JsonConvert.SerializeObject (							
				DrugHx, 
				new JsonSerializerSettings (){ 
					DateFormatHandling = DateFormatHandling.IsoDateFormat,
					NullValueHandling = NullValueHandling.Include 
				});

			// add parameters to request
			request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
			request.RequestFormat = DataFormat.Json;

			// send request
			client.ExecuteAsync (request, response => {
				//if ()
				Console.WriteLine (response.Content);
			});

			return true;
		}

		public DrugHistory AddDrugHistory(DrugHistory DrugHx){
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);
			var request = new RestRequest("api/DrugHistories", Method.POST );

			// serialize object to pass in request
			string json = JsonConvert.SerializeObject (
				DrugHx, 
				new JsonSerializerSettings (){ 
					DateFormatHandling = DateFormatHandling.IsoDateFormat,
					NullValueHandling = NullValueHandling.Include 
				});

			// add request parameters
			request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
			request.RequestFormat = DataFormat.Json;

			var response = Execute<DrugHistory> (request);

			return response;
		}

		public DrugHistory DeleteDrugHistory(int rowId){
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);
			var request = new RestRequest("api/DrugHistories/{id}", Method.DELETE );

			// add request parameters
			request.AddUrlSegment ("id", rowId.ToString ());

			var response =  Execute<DrugHistory> (request);

			return response;
		}

		public AncillaryProcedure AddAncillary(AncillaryProcedure AncillaryProc){
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);
			var request = new RestRequest("api/", Method.POST );

			// serialize object to pass in request
			string json = JsonConvert.SerializeObject (
				AncillaryProc, 
				new JsonSerializerSettings (){ 
					DateFormatHandling = DateFormatHandling.IsoDateFormat,
					NullValueHandling = NullValueHandling.Include 
				});

			// add request parameters
			request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
			request.RequestFormat = DataFormat.Json;

			var response = Execute<AncillaryProcedure> (request);

			return response;
		}



		public AncillaryProcedure DeleteAncillaryProcedurey(int rowId){
			// Put code to communicate to web service here
			var client = new RestClient (clientUrl);
			var request = new RestRequest("api/", Method.DELETE );

			// add request parameters
			request.AddUrlSegment ("id", rowId.ToString ());

			var response =  Execute<AncillaryProcedure> (request);

			return response;
		}









		static T Execute<T>(RestRequest request) where T: new()
		{
			var client = new RestClient(clientUrl);
			var response = client.Execute<T>(request);

			if (response.ErrorException != null)
			{
				const string message = "Error retrieving response.  Check inner details for more info.";
				var requestException = new ApplicationException(message, response.ErrorException);
				throw requestException;
			}

			return response.Data;
		}
	}
}

