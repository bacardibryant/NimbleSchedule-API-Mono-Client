namespace NimbleSchedule.Mono.Models
{
	/// <summary>
	/// NimbleSchedule API Authentication Information class used to provide authentication information to
	/// the client during api calls.
	/// 
	/// See the sample AuthInfo.json file included in with this library on how the json is structured, should you decide to use file storage
	/// for authentication parameters.
	/// 
	/// This public class should be instantiated and configured by the consuming assembly, this will allow for the NimbleApiClient
	/// will perform the work of this class.
	/// </summary>
	public class AuthInfo
	{
		public string CompanyId { get; set; }
		public string ApiKey { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
