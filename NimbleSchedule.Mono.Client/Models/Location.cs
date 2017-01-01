using Newtonsoft.Json;

namespace NimbleSchedule.Mono.Client
{
	[JsonObject]
	public class Location
	{
		public string Id { get; set; }
		public string Name { get; set; }
	}
}
