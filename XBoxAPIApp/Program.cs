using System;
using System.Windows.Forms;
using Squirrel;
using System.Reflection;

namespace XBoxAPIApp
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			MainForm mainform = new MainForm();
			mainform.FormBorderStyle = FormBorderStyle.FixedSingle;
			mainform.MaximizeBox = false;

			Application.Run(mainform);
		}
	}
}
