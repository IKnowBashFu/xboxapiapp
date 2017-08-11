using IniParser;
using IniParser.Model;
using NLog;
using System;
using System.Collections.Generic;

namespace XBoxAPIApp
{
	static class Config
	{
		private static string _gamertag = "";
		private static string _apikey = "";
		private static int _pollrate = 60;
		private static string _xuid = "";
		private static string _filepath = "";

		private static FileIniDataParser parser = new FileIniDataParser();

		private static Logger logger = LogManager.GetCurrentClassLogger();

		public static string GamerTag
		{
			get { return _gamertag; }
		}

		public static string ApiKey
		{
			get { return _apikey; }
		}

		public static int PollRate
		{
			get { return _pollrate; }
		}

		public static string Xuid
		{
			get { return _xuid; }
		}

		public static string FilePath
		{
			get { return _filepath; }
		}

		public static ConfigReport ReadConfigFile()
		{
			IniData data = null;
			List<string> failures = new List<string>();

			try
			{
				data = parser.ReadFile("config.ini");
			}
			catch (IniParser.Exceptions.ParsingException e)
			{
				logger.Error("Send IKnowBashFu this error message. | " + e.Message);
				failures.Add("file");
			}
			try
			{
				_gamertag = data["Global"]["GamerTag"].ToString();
			}
			catch (NullReferenceException e)
			{
				logger.Warn("GamerTag not found in Configuration file.");
				failures.Add("gamertag");
			}
			try
			{
				_apikey = data["Global"]["ApiKey"].ToString();
			}
			catch (NullReferenceException e)
			{
				logger.Warn("ApiKey not found in Configuration file.");
				failures.Add("apikey");
			}
			try
			{
				_pollrate = int.Parse(data["Global"]["PollRate"]);
			}
			catch (ArgumentNullException e)
			{
				logger.Warn("PollRate not found in Configuration file.");
				failures.Add("pollrate");
			}
			try
			{
				_filepath = data["Global"]["FilePath"].ToString();
			}
			catch (ArgumentNullException e)
			{
				logger.Warn("FilePath not found in Configuration file.");
				failures.Add("filepath");
			}
			try
			{
				_xuid = data["DoNotEdit"]["Xuid"].ToString();
			}
			catch (NullReferenceException e)
			{
				logger.Warn("Xuid not found in Configuration file.");
				failures.Add("xuid");
			}

			if (failures.Count > 0)
				return new ConfigReport(false, failures);
			else
				return new ConfigReport(true, failures);
		}

		public static void WriteConfigFile(string gtag, string apikey, int pollrate, string xuid, string filepath)
		{
			IniData data = new IniData();
			data["Global"]["GamerTag"] = gtag;
			data["Global"]["ApiKey"] = apikey;
			data["Global"]["PollRate"] = pollrate.ToString();
			data["Global"]["FilePath"] = filepath;
			data["DoNotEdit"]["Xuid"] = xuid;

			parser.WriteFile("config.ini", data);
		}
	}

	class ConfigReport
	{
		public Boolean success;
		public List<string> failures;

		public ConfigReport(Boolean success, List<string> failures)
		{
			this.success = success;
			this.failures = failures;
		}
	}
}
