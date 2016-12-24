using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NimbleSchedule.Mono.Models;

namespace NimbleSchedule.Mono.Client
{
	public static class NimbleApiClient
	{
		public static async Task<List<Shift>> GetShiftsAsync(DateTime startDate, DateTime endDate, AuthInfo authInfo)
		{
			using (NimbleApiInterface apiInterface = new NimbleApiInterface(authInfo))
			{
				return apiInterface.GetShiftsAsync(startDate, endDate).Result;
			}
		}

		public static async Task<List<Employee>> GetEmployeesAsync(AuthInfo authInfo)
		{
			using (NimbleApiInterface apiInterface = new NimbleApiInterface(authInfo))
			{
				return apiInterface.GetEmployeesAsync().Result;
			}
		}

	}
}
