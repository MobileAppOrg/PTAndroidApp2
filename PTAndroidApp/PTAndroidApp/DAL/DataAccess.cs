using System;
using RestSharp;

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
			var request = new RestRequest("api/Patients", Method.GET );
			 
			// edit parameters for all properties on an object




			return true;
		}

		// DELETE Patient: Requires Patient Id

		public bool Delete(int PatientId){
			// Put code to communicate to web service here
			return true;
		}
	}
}

