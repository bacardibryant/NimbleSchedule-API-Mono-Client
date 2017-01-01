using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NimbleSchedule.Mono.Models;

namespace NimbleSchedule.Mono.Client
{
	class NimbleApiInterface : IDisposable
	{
		HttpClient _client = new HttpClient();
		AuthInfo _authInfo = new AuthInfo();

		public NimbleApiInterface(AuthInfo authInfo)
		{
			_authInfo = authInfo;

			// set client parameters
			_client.BaseAddress = new Uri("https://app.nimbleschedule.com");
			_client.DefaultRequestHeaders.Accept.Clear();
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}


		/// <summary>
		/// This method is used to get list of countries. It doesn't require any additional parameters 
		/// </summary>
		/// <returns>.NET list collection of country objects</returns>
		public async Task<List<Country>> GetCountriesAsync()
		{
			var countries = new List<Country>();

			// call api async and wait for response.
			HttpResponseMessage response = await _client.GetAsync($"/api/countries/?CompanyId={_authInfo.CompanyId}&format=JSON&AuthToken={_authInfo.ApiKey}");

			// if an error code this will throw and exception.
			if (response.IsSuccessStatusCode)
			{
				// read json response
				string responseBody = await response.Content.ReadAsStringAsync();

				// parse json into list.
				countries = JsonConvert.DeserializeObject<List<Country>>(responseBody);
			}

			return countries;

		}

		/// <summary>
		/// This method is used to get all the departments in an organization. It doesn't require any additional parameters
		/// </summary>
		/// <returns>.NET list collection of department objects</returns>
		public async Task<List<Department>> GetDepartmentsAsync()
		{
			var departments = new List<Department>();

			// call api async and wait for response.
			HttpResponseMessage response = await _client.GetAsync($"/api/departments/?CompanyId={_authInfo.CompanyId}&format=JSON&AuthToken={_authInfo.ApiKey}");

			// if an error code this will throw and exception.
			if (response.IsSuccessStatusCode)
			{
				// read json response
				string responseBody = await response.Content.ReadAsStringAsync();

				// parse json into list.
				departments = JsonConvert.DeserializeObject<List<Department>>(responseBody);
			}

			return departments;

		}


		/// <summary>
		/// Gets the schedules from source.
		/// </summary>
		/// <returns>The schedules from source.</returns>
		public async Task<List<Shift>> GetShiftsAsync(DateTime startDate, DateTime endDate)
		{
			var shifts = new List<Shift>();

			// format the dates
			var shiftStart = startDate.ToString("yyyy-MM-ddTHH:mm");
			var shiftEnd = endDate.ToString("yyyy-MM-ddTHH:mm");


			// call api async and wait for response.
			HttpResponseMessage response = await _client.GetAsync($"/api/scheduledshifts/GetShifts?CompanyId={_authInfo.CompanyId}&format=JSON&AuthToken={_authInfo.ApiKey}&startAt={shiftStart}&endAt={shiftEnd}");

			// if an error code this will throw and exception.
			if (response.IsSuccessStatusCode)
			{
				// read json response
				string responseBody = await response.Content.ReadAsStringAsync();

				// parse json into list.
				shifts = JsonConvert.DeserializeObject<List<Shift>>(responseBody);
			}

			return shifts;
		}

		public async Task<List<Employee>> GetEmployeesAsync()
		{
			var employees = new List<Employee>();

			// clear pending http client requests
			_client.CancelPendingRequests();

			// call api async and wait for response.
				HttpResponseMessage response = await _client.GetAsync($"/api/employees?CompanyId={_authInfo.CompanyId}&format=JSON&AuthToken={_authInfo.ApiKey}");

			// if an error code this will throw and exception.
			if (response.IsSuccessStatusCode)
			{
				// read json response
				string responseBody = await response.Content.ReadAsStringAsync();

				// parse json into list.
				employees = JsonConvert.DeserializeObject<List<Employee>>(responseBody);
			}

			return employees;
		}

		/// <summary>
		/// This method is used to query all the locations. It doesn't require any additional parameters. 
		/// </summary>
		/// <returns>.NET list collection of locations</returns>
		public async Task<List<Location>> GetLocationsAsync()
		{
			var locations = new List<Location>();

			// call api async and wait for response.
			HttpResponseMessage response = await _client.GetAsync($"/api/locations?CompanyId={_authInfo.CompanyId}&format=JSON&AuthToken={_authInfo.ApiKey}");

			// if an error code this will throw and exception.
			if (response.IsSuccessStatusCode)
			{
				// read json response
				string responseBody = await response.Content.ReadAsStringAsync();

				// parse json into list.
				locations = JsonConvert.DeserializeObject<List<Location>>(responseBody);
			}

			return locations;

		}

		/// <summary>
		/// This method is used to query locations for which user has access to. It doesn't require any additional parameters.
		/// </summary>
		/// <returns>.NET List collection of locations.</returns>
		public async Task<List<Location>> GetAccessibleLocationsAsync()
		{
			var locations = new List<Location>();

			// call api async and wait for response
			HttpResponseMessage response = await _client.GetAsync($"/api/locations/GetAccessibleLocations?username={_authInfo.UserName}&password={_authInfo.Password}");

			// if an error code this will throw and exception.
			if (response.IsSuccessStatusCode)
			{
				// read json response
				string responseBody = await response.Content.ReadAsStringAsync();

				// parse json into list.
				locations = JsonConvert.DeserializeObject<List<Location>>(responseBody);
			}

			return locations;
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
					_client.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~NimbleApiInterface() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}
