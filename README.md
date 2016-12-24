# NimbleSchedule-API-Mono-Client
NimbleSchedule API Client written in C# (Mono) using Visual Studio for Mac.

This is a C# class library that when referenced in your projects, can be used to make asynchronous api calls to NimbleSchedule
and parse the results into .NET objects and collections for later use in your application.

###How is it written?
This project is written using Visual Studio for Mac. Because the .NET native and Mono implementations of C#
differ slightly, the code between this library and our
<a href="https://github.com/xnodeoncode/NimbleSchedule-API-Client" target="_blank">NimbleSchedule-API-Client</a>
(written using Visual Studio Preview for Mac)
is somewhat different.

###How to use it?
Simply reference the project or assembly in your project.
<pre><code>
using Newtonsoft.Json;
using NimbleSchedule.Client;
</code></pre>

Instantiate a authentication object with active credentials.
<pre><code>
// read authentication information from configuration file.
var authInfo = JsonConvert.DeserializeObject<AuthInfo>(File.ReadAllText("authConfig.json"));
</code></pre>

Call the appropriate static method on the client object.
<pre><code>
 // call static async method with authentication details object as parameter.
 var employees = await NimbleApiClient.GetEmployeesAsync(authInfo);
</code></pre>

###Asynchronous Throughout
The NimbleSchedule-API-Mono-Client attempts to use asynchronous code throughout, where there is support for it. Therefore
methods that contain client calls must implement the C# async/await pattern as illustrated in the ASP.NET MVC controller
call below.
<pre><code>
        public async Task&lt;ActionResult&gt; Employees()
        {
            var employees = new List<Employee>();
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

##NOTE: This project is not affiliated with the company Nimble nor its product located at http://www.nimbleschedule.com.

