using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NimbleSchedule.Mono.Models;

namespace NimbleSchedule.Interface
{
	public static class NimbleApiClient
	{
		public static async Task<List<Shift>> GetShifts(DateTime startDate, DateTime endDate, AuthInfo authInfo)
		{
			NimbleApiInterface apiInterface = new NimbleApiInterface(authInfo);
			return apiInterface.GetShiftsAsync(startDate, endDate).Result;
		}

		public static async Task<List<Employee>> GetEmployees(AuthInfo authInfo)
		{
			NimbleApiInterface apiInterface = new NimbleApiInterface(authInfo);
			return apiInterface.GetEmployeesAsync().Result;
		}

	}
}
