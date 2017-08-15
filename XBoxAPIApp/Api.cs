using RestSharp;
using Newtonsoft.Json;
using NLog;
using System;

namespace XBoxAPIApp
{
	class Api
	{
		private static RestClient client = new RestClient("https://xboxapi.com");
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public static XuidInfo GetUserId(string gamertag, string apikey)
		{
			logger.Debug("GamerTag sent to Api.GetUserId() is: " + gamertag);
			RestRequest req = new RestRequest("/v2/xuid/" + gamertag);
			req.AddHeader("X-AUTH", apikey);

			IRestResponse res = client.Execute(req);
			string JsonRes = res.Content;

			logger.Debug("Received response from API for Xuid: " + res.Content.ToString());

			Xuid x = JsonConvert.DeserializeObject<Xuid>(JsonRes);

			XuidInfo xi = new XuidInfo();

			xi.xuid = x.xuid;
			string error = x.error_message;

			if (error != "")
			{
				xi.success = false;
				xi.error = error;
				return xi;
			}
			else
			{
				xi.success = true;
				return xi;
			}
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
				logger.Error("There was an error reading the API response. Please send IKnowBashFu this error message | " + e.Message + " | " + res.Content.ToString());
				return false;
			}
		}
	}

	class Xuid
	{
		public string xuid = "";
		public string error_message = "";
	}

	class XuidInfo
	{
		public Boolean success = false;
		public String xuid = "";
		public String error = "";
	}

	class Profile
	{
		public string gamerscore = "";
	}
}
