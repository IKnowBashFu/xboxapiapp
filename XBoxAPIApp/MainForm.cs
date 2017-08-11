using NLog;
using Squirrel;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XBoxAPIApp
{
	public partial class MainForm : Form
	{
		private NotifyIcon myNotifyIcon;
		private ContextMenu myContextMenu;
		private MenuItem exitMenuItem;
		private MenuItem showMenuItem;
		private MenuItem aboutMenuItem;
		private IContainer myComponents;
		private Timer scoreTimer;

		private static Logger logger = LogManager.GetCurrentClassLogger();


		public MainForm()
		{
			myComponents = new Container();
			myContextMenu = new ContextMenu();
			showMenuItem = new MenuItem();
			exitMenuItem = new MenuItem();
			aboutMenuItem = new MenuItem();

			myContextMenu.MenuItems.AddRange(new MenuItem[] { this.exitMenuItem, this.showMenuItem, this.aboutMenuItem });

			exitMenuItem.Index = 2;
			exitMenuItem.Text = "Exit";
			exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);

			showMenuItem.Index = 0;
			showMenuItem.Text = "Show Config";
			showMenuItem.Click += new System.EventHandler(this.showMenuItem_Click);

			aboutMenuItem.Index = 1;
			aboutMenuItem.Text = "About This Application";
			aboutMenuItem.Click += new System.EventHandler(this.showAboutMenuItem_Click);

			myNotifyIcon = new NotifyIcon(this.myComponents);
			myNotifyIcon.Icon = new Icon("appicon.ico");
			myNotifyIcon.ContextMenu = this.myContextMenu;

			myNotifyIcon.Text = "XBox API App";
			myNotifyIcon.Visible = true;

			myNotifyIcon.DoubleClick += new System.EventHandler(this.showMenuItem_Click);
			this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);

			InitializeComponent();
		}

		private void Form_Shown(object sender, EventArgs e)
		{
			CheckUpdate();

			if (File.Exists("config.ini"))
			{
				ConfigReport report = Config.ReadConfigFile();
				if (report.success)
				{
					gamertagBox.Text = Config.GamerTag;
					apikeyBox.Text = Config.ApiKey;
					pollrateBox.Value = Config.PollRate;
					this.Hide();
					WriteGamerScore();
					InitTimer();
					myNotifyIcon.BalloonTipTitle = "Configuration found.";
					myNotifyIcon.BalloonTipText = "Application is now running in your system tray.";
					myNotifyIcon.ShowBalloonTip(5000);
				}
				else
				{
					string fail = "There was an error reading your config file.";
					for (int i = 0; i < report.failures.Count; i++)
					{
						string failure = report.failures[i];
						if (failure == "file")
						{
							fail += " The file could not be parsed or found. Please fill out the form.";
							break;
						}


						if (i == 0)
							fail += " Some parts of your config could not be read: ";
						else
							fail += ", ";


						if (failure == "gamertag")
							fail += "gamertag";
						if (failure == "apikey")
							fail += "apikey";
						if (failure == "pollrate")
							fail += "pollrate";
					}
					this.gamertagBox.Text = Config.GamerTag;
					this.apikeyBox.Text = Config.ApiKey;
					this.pollrateBox.Value = Config.PollRate;
					MessageBox.Show(fail);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (gamertagBox.Text != "" || apikeyBox.Text == "" || pollrateBox.Value == 0 || Global.FilePath == "")
			{
				string xuid = Api.GetUserId(gamertagBox.Text, apikeyBox.Text);
				logger.Debug("After saving settings, Xuid is: " + xuid);
				Config.WriteConfigFile(gamertagBox.Text, apikeyBox.Text, (int)pollrateBox.Value, xuid, Global.FilePath);
				Config.ReadConfigFile();

				WriteGamerScore();

				InitTimer();

				this.Hide();
				myNotifyIcon.BalloonTipTitle = "Running in the background...";
				myNotifyIcon.BalloonTipText = "Right-click the XBox icon in your system tray to exit or show the configuration window.";
				myNotifyIcon.ShowBalloonTip(5000);
			}
			else
			{
				if (Global.FilePath == "")
					MessageBox.Show("Please select a folder to save your gamerscore file to.");
				else if (gamertagBox.Text != "" || apikeyBox.Text == "" || pollrateBox.Value == 0)
					MessageBox.Show("Please fill out the form fully.");
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				// Hide window.
				this.Hide();
				myNotifyIcon.BalloonTipTitle = "Running in the background...";
				myNotifyIcon.BalloonTipText = "Right-click the XBox icon in your system tray to exit or show the configuration window.";
				myNotifyIcon.ShowBalloonTip(5000);
			}
		}

		private void exitMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void showMenuItem_Click(object sender, EventArgs e)
		{
			this.Show();
		}

		private void showAboutMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm abt = new AboutForm();
			abt.Show();
		}

		private void InitTimer()
		{
			scoreTimer = new Timer();
			scoreTimer.Tick += new EventHandler(scoreTimer_Tick);
			scoreTimer.Interval = Config.PollRate * 1000;
			scoreTimer.Start();
		}

		private void WriteGamerScore()
		{
			if (Api.GetGamerScore())
			{
				StreamWriter writer = new StreamWriter(Config.FilePath + "\\gamerscore.txt");
				writer.Write(Global.GamerScore);
				writer.Close();
				writer.Dispose();
			}
		}

		private void scoreTimer_Tick(object sender, EventArgs e)
		{
			WriteGamerScore();
		}

		private void fileButton_Click(object sender, EventArgs e)
		{
			if (folderDialog.ShowDialog() == DialogResult.OK)
			{
				Global.FilePath = folderDialog.SelectedPath;
			}
		}

		async private void CheckUpdate()
		{
			using (UpdateManager mgr = new UpdateManager("http://www.iknowbashfu.com/downloads/xbox/"))
			{
				UpdateInfo upd = await mgr.CheckForUpdate();
				string version = upd.CurrentlyInstalledVersion.Version.ToString();
				string update = upd.FutureReleaseEntry.Version.ToString();

				logger.Debug("Current version: " + version + " | Latest version: " + update);

				if (version != update)
				{
					await mgr.UpdateApp();
					MessageBox.Show("An update has been downloaded. Please restart the application to use the updated version.");
				}
			}
		}
	}
}