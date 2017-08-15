using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XBoxAPIApp
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			InitializeComponent();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://mixer.com/iknowbashfu");
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.iknowbashfu.com/");
		}

		private void AboutForm_Load(object sender, EventArgs e)
		{
			versionLabel.Text = "Version " + ProductVersion.ToString();
		}
	}
}
