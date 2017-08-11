namespace XBoxAPIApp
{
	static class Global
	{
		private static string _xuid = "";
		private static string _gamerscore = "";
		private static string _filepath = "";

		public static string Xuid
		{
			get { return _xuid; }
			set { _xuid = value; }
		}

		public static string GamerScore
		{
			get { return _gamerscore; }
			set { _gamerscore = value; }
		}

		public static string FilePath
		{
			get { return _filepath; }
			set { _filepath = value; }
		}
	}
}
