using Newtonsoft.Json;

namespace NimbleSchedule.Mono.Client
{
	[JsonObject]
	public class Country
	{
		public string Code { get; set; }
		public string Name { get; set; }
	}
}
