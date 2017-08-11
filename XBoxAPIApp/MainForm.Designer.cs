namespace XBoxAPIApp
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.gamertagBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.apikeyBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.pollrateBox = new System.Windows.Forms.NumericUpDown();
			this.fileButton = new System.Windows.Forms.Button();
			this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.pollrateBox)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "GamerTag:";
			// 
			// gamertagBox
			// 
			this.gamertagBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gamertagBox.Location = new System.Drawing.Point(12, 32);
			this.gamertagBox.Name = "gamertagBox";
			this.gamertagBox.Size = new System.Drawing.Size(260, 26);
			this.gamertagBox.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(197, 204);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Api Key:";
			// 
			// apikeyBox
			// 
			this.apikeyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.apikeyBox.Location = new System.Drawing.Point(13, 100);
			this.apikeyBox.Name = "apikeyBox";
			this.apikeyBox.Size = new System.Drawing.Size(259, 26);
			this.apikeyBox.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 146);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(172, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Poll Rate (In Seconds):";
			// 
			// pollrateBox
			// 
			this.pollrateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pollrateBox.Location = new System.Drawing.Point(12, 170);
			this.pollrateBox.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
			this.pollrateBox.Name = "pollrateBox";
			this.pollrateBox.Size = new System.Drawing.Size(172, 26);
			this.pollrateBox.TabIndex = 6;
			this.pollrateBox.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			// 
			// fileButton
			// 
			this.fileButton.Location = new System.Drawing.Point(13, 204);
			this.fileButton.Name = "fileButton";
			this.fileButton.Size = new System.Drawing.Size(88, 23);
			this.fileButton.TabIndex = 7;
			this.fileButton.Text = "Select Folder";
			this.fileButton.UseVisualStyleBackColor = true;
			this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 239);
			this.Controls.Add(this.fileButton);
			this.Controls.Add(this.pollrateBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.apikeyBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.gamertagBox);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "XBox API App";
			this.Shown += new System.EventHandler(this.Form_Shown);
			((System.ComponentModel.ISupportInitialize)(this.pollrateBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox gamertagBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox apikeyBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown pollrateBox;
		private System.Windows.Forms.Button fileButton;
		private System.Windows.Forms.FolderBrowserDialog folderDialog;
	}
}

