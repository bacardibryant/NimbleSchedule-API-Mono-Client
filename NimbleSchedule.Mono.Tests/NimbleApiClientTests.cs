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
	public class Test
	{
		[Test]
		public async Task Can_Get_Employees_Async()
		{
			// instantiate an authentication info object to hold api credentials.
			var authInfo = new AuthInfo();

			// create the base file path to the projects folder.
			var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Projects");

			// use system io to read the json file from the application path.
			// attempt to deserialize the json to an authinfo object.
			using (StreamReader r = File.OpenText(filePath + "/NimbleSchedule-API-Mono-Client/NimbleSchedule.Mono.Tests/App_Data/AuthInfo.json"))
			{
				string json = r.ReadToEnd();
				authInfo = JsonConvert.DeserializeObject<AuthInfo>(json);
			}

			// call the async method.
			var employees = await NimbleApiClient.GetEmployeesAsync(authInfo);

			// test that data is returned, meaning that the http client was able to authenticate and make the call.
			Assert.IsTrue(employees.Count > 0);
		}

		[Test]
		public async Task Can_Get_Shifts_Async()
		{
			// instantiate an authentication info object to hold api credentials.
			var authInfo = new AuthInfo();

			// create the base file path to the projects folder.
			var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Projects");

			// use system io to read the json file from the application path.
			// attempt to deserialize the json to an authinfo object.
			using (StreamReader r = File.OpenText(filePath + "/NimbleSchedule-API-Mono-Client/NimbleSchedule.Mono.Tests/App_Data/AuthInfo.json"))
			{
				string json = r.ReadToEnd();
				authInfo = JsonConvert.DeserializeObject<AuthInfo>(json);
			}

			// call the async method.
			var shifts = await NimbleApiClient.GetShiftsAsync(DateTime.Today.AddDays(-14), DateTime.Today, authInfo);

			// test that data is returned, meaning that the http client was able to authenticate and make the call.
			Assert.IsTrue(shifts.Count > 0);
		}
	}
}
