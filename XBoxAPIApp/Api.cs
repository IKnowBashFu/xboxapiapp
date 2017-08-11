using RestSharp;
using Newtonsoft.Json;
using NLog;

namespace XBoxAPIApp
{
	class Api
	{
		private static RestClient client = new RestClient("https://xboxapi.com");
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public static string GetUserId(string gamertag, string apikey)
		{
			logger.Debug("GamerTag sent to Api.GetUserId() is: " + gamertag);
			RestRequest req = new RestRequest("/v2/xuid/" + gamertag);
			req.AddHeader("X-AUTH", apikey);

			IRestResponse res = client.Execute(req);
			string JsonRes = res.Content;

			Xuid x = JsonConvert.DeserializeObject<Xuid>(JsonRes);

			string xuid = x.xuid;

			return xuid;
		}

		public static bool GetGamerScore()
		{
			RestRequest req = new RestRequest("/v2/" + Config.Xuid + "/profile");
			req.AddHeader("X-AUTH", Config.ApiKey);

			IRestResponse res = client.Execute(req);
			string JsonRes = res.Content;

			try
			{
				Profile p = JsonConvert.DeserializeObject<Profile>(JsonRes);
				Global.GamerScore = p.gamerscore;
				logger.Info("Your gamerscore is " + Global.GamerScore);
				return true;
			}
			catch (JsonReaderException e)
			{
				logger.Error("There was an error reading the API response. Please send IKnowBashFu this error message | " + e.Message + " | " + res.ToString());
				return false;
			}
		}
	}

	class Xuid
	{
		public string xuid = "";
	}

	class Profile
	{
		public string gamerscore = "";
	}
}
