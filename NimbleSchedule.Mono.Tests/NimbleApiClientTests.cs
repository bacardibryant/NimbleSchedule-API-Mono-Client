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
		private const string configDataLocation = "App_Data/authConfig.json";
		private AuthInfo authInfo;

		/// <summary>
		/// Implemented test class constructor so that authInfo file i/o is only called once. Although in the case of test classes
		/// the constructor is called for each test method, so this would be the same as including the call in each method.
		/// However, try to stay consisted with good coding practices and keep things DRY yet with out abstracting away too much of the context
		/// so that you are still left with somewhat self-documenting code.
		/// </summary>

		public NimbleApiClientTests()
		{
			// read authentication information from configuration file.
			var fileContents = File.ReadAllText(configDataLocation);
			this.authInfo = JsonConvert.DeserializeObject<AuthInfo>(File.ReadAllText(configDataLocation));
		}

		[Test]
		public async Task Can_Get_Employees_Async()
		{
			// instantiate an authentication info object to hold api credentials.
			//var authInfo = new AuthInfo();

			// create the base file path to the projects folder.
			//var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Projects");

			// use system io to read the json file from the application path.
			// attempt to deserialize the json to an authinfo object.
			//using (StreamReader r = File.OpenText(filePath + "/NimbleSchedule-API-Mono-Client/NimbleSchedule.Mono.Tests/App_Data/AuthInfo.json"))
			//{
			//	string json = r.ReadToEnd();
			//	authInfo = JsonConvert.DeserializeObject<AuthInfo>(json);
			//}

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
