using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NimbleSchedule.Mono.Models;

namespace NimbleSchedule.Interface
{
	class NimbleApiInterface
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
			HttpResponseMessage response = await _client.GetAsync("/api/scheduledshifts/GetShifts?CompanyId=" + _authInfo.CompanyId + "&format=JSON&AuthToken=" + _authInfo.ApiKey + "&startAt=" + shiftStart + "&endAt=" + shiftEnd);

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
			HttpResponseMessage response = await _client.GetAsync("/api/employees?CompanyId=" + _authInfo.CompanyId + "&format=JSON&AuthToken=" + _authInfo.ApiKey);

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

	}
}
