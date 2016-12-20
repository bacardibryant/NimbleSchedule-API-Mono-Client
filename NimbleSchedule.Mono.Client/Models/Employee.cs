using Newtonsoft.Json;

namespace NimbleSchedule.Mono.Models
{
	[JsonObject]
	public class Employee
	{
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string UserId { get; set; }
		public string Role { get; set; }
		public string HireDate { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string ZipCode { get; set; }
		public string TimeZone { get; set; }
		public string FLEStandardTime { get; set; }
		public string CountryCodeForMobile { get; set; }
		public string CountryMobileCode { get; set; }
		public string Mobile { get; set; }
		public string Password { get; set; }
		public string MaximumHoursPerWeek { get; set; }
		public string MaximumHoursPerDay { get; set; }
		public string MaximumDaysPerWeek { get; set; }
		public string MaximumShiftsPerDay { get; set; }
		public string LocationName { get; set; }

	}
}
