namespace QuickToolsSetup
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.CloseSettingsWindow = new System.Windows.Forms.Button();
            this.LoadFilesBtn = new System.Windows.Forms.Button();
            this.FilesPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FilesDisplayBox = new System.Windows.Forms.RichTextBox();
            this.Directorys = new System.DirectoryServices.DirectoryEntry();
            this.PackFilesBtn = new System.Windows.Forms.Button();
            this.PackFilesProgressBar = new System.Windows.Forms.ProgressBar();
            this.CurrentFileStatus = new System.Windows.Forms.Label();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.PackCheckerBtn = new System.Windows.Forms.Button();
            this.WritePack = new System.Windows.Forms.Button();
            this.ReadInstaller = new System.Windows.Forms.Button();
            this.RemovePack = new System.Windows.Forms.Button();
            this.PackFileNameInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ClearLogsBtn = new System.Windows.Forms.Button();
            this.InstallerDescription = new System.Windows.Forms.RichTextBox();
            this.AddDescriptionBtn = new System.Windows.Forms.Button();
            this.CheckInstaller = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CloseSettingsWindow
            // 
            this.CloseSettingsWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.CloseSettingsWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseSettingsWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseSettingsWindow.ForeColor = System.Drawing.Color.White;
            this.CloseSettingsWindow.Location = new System.Drawing.Point(768, 1);
            this.CloseSettingsWindow.Name = "CloseSettingsWindow";
            this.CloseSettingsWindow.Size = new System.Drawing.Size(31, 23);
            this.CloseSettingsWindow.TabIndex = 8;
            this.CloseSettingsWindow.Text = "X";
            this.CloseSettingsWindow.UseVisualStyleBackColor = false;
            this.CloseSettingsWindow.Click += new System.EventHandler(this.CloseSettingsWindow_Click);
            // 
            // LoadFilesBtn
            // 
            this.LoadFilesBtn.Location = new System.Drawing.Point(624, 99);
            this.LoadFilesBtn.Name = "LoadFilesBtn";
            this.LoadFilesBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadFilesBtn.TabIndex = 9;
            this.LoadFilesBtn.Text = "Load Files";
            this.LoadFilesBtn.UseVisualStyleBackColor = true;
            this.LoadFilesBtn.Click += new System.EventHandler(this.LoadFilesBtn_Click);
            // 
            // FilesPath
            // 
            this.FilesPath.Location = new System.Drawing.Point(12, 75);
            this.FilesPath.Name = "FilesPath";
            this.FilesPath.Size = new System.Drawing.Size(606, 20);
            this.FilesPath.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(251, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "QuickTools Installer Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Files Path";
            // 
            // FilesDisplayBox
            // 
            this.FilesDisplayBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.FilesDisplayBox.ForeColor = System.Drawing.Color.White;
            this.FilesDisplayBox.Location = new System.Drawing.Point(12, 101);
            this.FilesDisplayBox.Name = "FilesDisplayBox";
            this.FilesDisplayBox.Size = new System.Drawing.Size(606, 323);
            this.FilesDisplayBox.TabIndex = 13;
            this.FilesDisplayBox.Text = "";
            this.FilesDisplayBox.TextChanged += new System.EventHandler(this.FilesDisplayBox_TextChanged);
            // 
            // PackFilesBtn
            // 
            this.PackFilesBtn.Location = new System.Drawing.Point(713, 99);
            this.PackFilesBtn.Name = "PackFilesBtn";
            this.PackFilesBtn.Size = new System.Drawing.Size(75, 23);
            this.PackFilesBtn.TabIndex = 14;
            this.PackFilesBtn.Text = "Pack";
            this.PackFilesBtn.UseVisualStyleBackColor = true;
            this.PackFilesBtn.Click += new System.EventHandler(this.PackFilesBtn_Click);
            // 
            // PackFilesProgressBar
            // 
            this.PackFilesProgressBar.Location = new System.Drawing.Point(0, 451);
            this.PackFilesProgressBar.Name = "PackFilesProgressBar";
            this.PackFilesProgressBar.Size = new System.Drawing.Size(799, 23);
            this.PackFilesProgressBar.TabIndex = 15;
            this.PackFilesProgressBar.Visible = false;
            // 
            // CurrentFileStatus
            // 
            this.CurrentFileStatus.AutoSize = true;
            this.CurrentFileStatus.BackColor = System.Drawing.Color.White;
            this.CurrentFileStatus.Location = new System.Drawing.Point(9, 435);
            this.CurrentFileStatus.Name = "CurrentFileStatus";
            this.CurrentFileStatus.Size = new System.Drawing.Size(0, 13);
            this.CurrentFileStatus.TabIndex = 16;
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // PackCheckerBtn
            // 
            this.PackCheckerBtn.Location = new System.Drawing.Point(624, 128);
            this.PackCheckerBtn.Name = "PackCheckerBtn";
            this.PackCheckerBtn.Size = new System.Drawing.Size(75, 23);
            this.PackCheckerBtn.TabIndex = 17;
            this.PackCheckerBtn.Text = "CheckPack";
            this.PackCheckerBtn.UseVisualStyleBackColor = true;
            this.PackCheckerBtn.Click += new System.EventHandler(this.PackCheckerBtn_Click);
            // 
            // WritePack
            // 
            this.WritePack.Location = new System.Drawing.Point(624, 321);
            this.WritePack.Name = "WritePack";
            this.WritePack.Size = new System.Drawing.Size(164, 23);
            this.WritePack.TabIndex = 18;
            this.WritePack.Text = "Write To Installer";
            this.WritePack.UseVisualStyleBackColor = true;
            this.WritePack.Click += new System.EventHandler(this.WritePack_Click);
            // 
            // ReadInstaller
            // 
            this.ReadInstaller.Location = new System.Drawing.Point(624, 361);
            this.ReadInstaller.Name = "ReadInstaller";
            this.ReadInstaller.Size = new System.Drawing.Size(164, 23);
            this.ReadInstaller.TabIndex = 19;
            this.ReadInstaller.Text = "Read Installer";
            this.ReadInstaller.UseVisualStyleBackColor = true;
            this.ReadInstaller.Click += new System.EventHandler(this.ReadInstaller_Click);
            // 
            // RemovePack
            // 
            this.RemovePack.Location = new System.Drawing.Point(624, 401);
            this.RemovePack.Name = "RemovePack";
            this.RemovePack.Size = new System.Drawing.Size(164, 23);
            this.RemovePack.TabIndex = 20;
            this.RemovePack.Text = "Remove Pack";
            this.RemovePack.UseVisualStyleBackColor = true;
            this.RemovePack.Click += new System.EventHandler(this.RemovePack_Click);
            // 
            // PackFileNameInput
            // 
            this.PackFileNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PackFileNameInput.Location = new System.Drawing.Point(624, 75);
            this.PackFileNameInput.Name = "PackFileNameInput";
            this.PackFileNameInput.Size = new System.Drawing.Size(164, 21);
            this.PackFileNameInput.TabIndex = 21;
            this.PackFileNameInput.Text = "Pack.xml";
            this.PackFileNameInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(666, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Pack Name";
            // 
            // ClearLogsBtn
            // 
            this.ClearLogsBtn.Location = new System.Drawing.Point(713, 128);
            this.ClearLogsBtn.Name = "ClearLogsBtn";
            this.ClearLogsBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearLogsBtn.TabIndex = 23;
            this.ClearLogsBtn.Text = "Clear Logs";
            this.ClearLogsBtn.UseVisualStyleBackColor = true;
            this.ClearLogsBtn.Click += new System.EventHandler(this.ClearLogsBtn_Click);
            // 
            // InstallerDescription
            // 
            this.InstallerDescription.Location = new System.Drawing.Point(624, 186);
            this.InstallerDescription.Name = "InstallerDescription";
            this.InstallerDescription.Size = new System.Drawing.Size(164, 129);
            this.InstallerDescription.TabIndex = 24;
            this.InstallerDescription.Text = "";
            this.InstallerDescription.Visible = false;
            this.InstallerDescription.TextChanged += new System.EventHandler(this.InstallerDescription_TextChanged);
            // 
            // AddDescriptionBtn
            // 
            this.AddDescriptionBtn.Location = new System.Drawing.Point(624, 157);
            this.AddDescriptionBtn.Name = "AddDescriptionBtn";
            this.AddDescriptionBtn.Size = new System.Drawing.Size(164, 23);
            this.AddDescriptionBtn.TabIndex = 26;
            this.AddDescriptionBtn.Text = "Add Description";
            this.AddDescriptionBtn.UseVisualStyleBackColor = true;
            this.AddDescriptionBtn.Click += new System.EventHandler(this.AddDescriptionBtn_Click);
            // 
            // CheckInstaller
            // 
            this.CheckInstaller.Location = new System.Drawing.Point(624, 186);
            this.CheckInstaller.Name = "CheckInstaller";
            this.CheckInstaller.Size = new System.Drawing.Size(164, 23);
            this.CheckInstaller.TabIndex = 27;
            this.CheckInstaller.Text = "Check Installer";
            this.CheckInstaller.UseVisualStyleBackColor = true;
            this.CheckInstaller.Click += new System.EventHandler(this.CheckInstaller_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(800, 464);
            this.Controls.Add(this.CheckInstaller);
            this.Controls.Add(this.AddDescriptionBtn);
            this.Controls.Add(this.InstallerDescription);
            this.Controls.Add(this.ClearLogsBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PackFileNameInput);
            this.Controls.Add(this.RemovePack);
            this.Controls.Add(this.ReadInstaller);
            this.Controls.Add(this.WritePack);
            this.Controls.Add(this.PackCheckerBtn);
            this.Controls.Add(this.CurrentFileStatus);
            this.Controls.Add(this.PackFilesProgressBar);
            this.Controls.Add(this.PackFilesBtn);
            this.Controls.Add(this.FilesDisplayBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilesPath);
            this.Controls.Add(this.LoadFilesBtn);
            this.Controls.Add(this.CloseSettingsWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickToolsSetup Settings";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseSettingsWindow;
        private System.Windows.Forms.Button LoadFilesBtn;
        private System.Windows.Forms.TextBox FilesPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox FilesDisplayBox;
        private System.DirectoryServices.DirectoryEntry Directorys;
        private System.Windows.Forms.Button PackFilesBtn;
        private System.Windows.Forms.ProgressBar PackFilesProgressBar;
        private System.Windows.Forms.Label CurrentFileStatus;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.Button PackCheckerBtn;
        private System.Windows.Forms.Button WritePack;
        private System.Windows.Forms.Button ReadInstaller;
        private System.Windows.Forms.Button RemovePack;
        private System.Windows.Forms.TextBox PackFileNameInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ClearLogsBtn;
        private System.Windows.Forms.RichTextBox InstallerDescription;
        private System.Windows.Forms.Button AddDescriptionBtn;
        private System.Windows.Forms.Button CheckInstaller;
    }
}