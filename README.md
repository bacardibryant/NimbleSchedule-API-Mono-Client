# NimbleSchedule-API-Mono-Client
NimbleSchedule API Client written in C# (Mono) using Visual Studio for Mac.

This is a C# class library that when referenced in your projects, can be used to make asynchronous api calls to NimbleSchedule
and parse the results into .NET objects and collections for later use in your application.

### How is it written?
This project is written using Visual Studio for macOS. Because the .NET native and Mono implementations of C#
differ slightly, the code between this library and our
<a href="https://github.com/xnodeoncode/NimbleSchedule-API-Client" target="_blank">NimbleSchedule-API-Client</a>
is somewhat different.

### How to use it?
Simply reference the project or assembly in your project.
<pre><code>
using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NimbleSchedule.Mono.Client;
using NimbleSchedule.Mono.Models;
</code></pre>

Instantiate a authentication object with active credentials.
<pre><code>
private const string testProjectLocation = "path-to-project-folder";
private const string configDataLocation = "path-to-authConfig.json-in-project";
private const string projectFolderName = "name-of-projects-folder";

// build file path to config file.
var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), projectFolderName);

// read authentication information from configuration file.
authInfo = JsonConvert.DeserializeObject<AuthInfo>(File.ReadAllText($"{filePath}{testProjectLocation}{configDataLocation}");
</code></pre>

Call the appropriate static method on the client object.
<pre><code>
 // call static async method with authentication details object as parameter.
 var employees = await NimbleApiClient.GetEmployeesAsync(authInfo);
</code></pre>

### Asynchronous Throughout
The NimbleSchedule-API-Mono-Client attempts to use asynchronous code throughout, where there is support for it. Therefore
methods that contain client calls must implement the C# async/await pattern as illustrated in the ASP.NET MVC controller
call below.
<pre><code>
        public async Task&lt;ActionResult&gt; Employees()
        {
            var employees = new List<Employee>();
            
            // instantiate an authentication object with valid credentials.
            var authInfo = GetAuthInfo();

            // get employee data from api client.
            employees = await NimbleApiClient.GetEmployeesAsync(authInfo);

            var viewModel = new EmployeeViewModel
            {
                Employees = employees
            };

            return View(viewModel);
        }
</code></pre>

#### NOTE: This project is not affiliated with the company Nimble nor its product located at http://www.nimbleschedule.com.

