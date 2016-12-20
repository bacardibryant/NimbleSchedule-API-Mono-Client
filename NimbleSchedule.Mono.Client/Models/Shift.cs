using Newtonsoft.Json;

namespace NimbleSchedule.Mono.Models
{
	[JsonObject]
	public class Shift
	{
		public string Id { get; set; }
		public string EmployeeId { get; set; }
		public string EmployeeName { get; set; }
		public string LocationName { get; set; }
		public string PositionName { get; set; }
		public string DepartmentName { get; set; }
		public string StartAt { get; set; }
		public string EndAt { get; set; }
		public string Color { get; set; }
		public string Title { get; set; }
		public string Notes { get; set; }
		public string IsPublished { get; set; }
	}
}