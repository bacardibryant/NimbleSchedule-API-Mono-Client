using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NimbleSchedule.Mono.Client;
using NimbleSchedule.Mono.Models;
using NUnit.Framework;

namespace NimbleSchedule.Mono.Tests
{
	[TestFixture]
	public class NimbleApiClientTests
	{
		private const string testProjectLocation = "/NimbleSchedule-API-Mono-Client/NimbleSchedule.Mono.Tests";
		private const string configDataLocation = "/App_Data/authConfig.json";
		private const string projectFolderName = "Projects";
		private AuthInfo authInfo;

		/// <summary>
		/// Implemented test class constructor so that authInfo file i/o is only called once. Although in the case of test classes
		/// the constructor is called for each test method, so this would be the same as including the call in each method.
		/// However, try to stay consisted with good coding practices and keep things DRY yet with out abstracting away too much of the context
		/// so that you are still left with somewhat self-documenting code.
		/// </summary>
		public NimbleApiClientTests()
		{
			// build file path to config file.
			var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), projectFolderName);

			// read authentication information from configuration file.
			authInfo = JsonConvert.DeserializeObject<AuthInfo>(File.ReadAllText($"{filePath}{testProjectLocation}{configDataLocation}"));
		}

		[Test]
		public async Task Client_Can_Get_Countries_Async()
		{
			// call static async method with parameter.
			var countries = await NimbleApiClient.GetCountriesAsync(authInfo);

			// assert that results were returned from the api.
			Assert.IsTrue(countries.Count > 0);
		}

		[Test]
		public async Task Client_Can_Get_Departments_Async()
		{
			// call static async method with parameter.
			var departments = await NimbleApiClient.GetDepartmentsAsync(authInfo);

			// assert that results were returned from the api.
			Assert.IsTrue(departments.Count > 0);
		}

		[Test]
		public async Task Can_Get_Employees_Async()
		{
			// call the async method.
			var employees = await NimbleApiClient.GetEmployeesAsync(authInfo);

			// test that data is returned, meaning that the http client was able to authenticate and make the call.
			Assert.IsTrue(employees.Count > 0);
		}

		[Test]
		public async Task Can_Get_Shifts_Async()
		{
			// call the async method.
			var shifts = await NimbleApiClient.GetShiftsAsync(DateTime.Today.AddDays(-14), DateTime.Today, authInfo);

			// test that data is returned, meaning that the http client was able to authenticate and make the call.
			Assert.IsTrue(shifts.Count > 0);
		}

		[Test]
		public async Task Client_Can_Get_Locations_Async()
		{
			// call static async method with parameter.
			var locations = await NimbleApiClient.GetLocationsAsync(authInfo);

			// assert that results were returned from the api.
			Assert.IsTrue(locations.Count > 0);
		}

		[Test]
		public async Task Client_Can_Get_Accessible_Locations_Async()
		{
			// call static async method with parameter.
			var locations = await NimbleApiClient.GetAccessibleLocationsAsync(authInfo);

			// assert that results were returned from the api.
			Assert.IsTrue(locations.Count > 0);
		}

	}
}
