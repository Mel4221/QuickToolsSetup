﻿namespace QuickToolsSetup
{
    partial class QuickToolsSetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickToolsSetupForm));
            this.label1 = new System.Windows.Forms.Label();
            this.InstallerProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.CopyRightsAckBtn = new System.Windows.Forms.CheckBox();
            this.LinkToLicenceBtn = new System.Windows.Forms.LinkLabel();
            this.InstallBtn = new System.Windows.Forms.Button();
            this.QuickToolsPictures = new System.Windows.Forms.PictureBox();
            this.CloseInstallationBtn = new System.Windows.Forms.Button();
            this.InstalationWorker = new System.ComponentModel.BackgroundWorker();
            this.InstalationTextStatus = new System.Windows.Forms.Label();
            this.InstalationPath = new System.Windows.Forms.TextBox();
            this.InstallLocationOpen = new System.Windows.Forms.Button();
            this.Caller = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuickToolsPictures)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome To QuickTools Instaler";
            // 
            // InstallerProgressBar
            // 
            this.InstallerProgressBar.Location = new System.Drawing.Point(1, 244);
            this.InstallerProgressBar.Name = "InstallerProgressBar";
            this.InstallerProgressBar.Size = new System.Drawing.Size(553, 26);
            this.InstallerProgressBar.TabIndex = 1;
            this.InstallerProgressBar.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Created By MBV.";
            // 
            // CopyRightsAckBtn
            // 
            this.CopyRightsAckBtn.AutoSize = true;
            this.CopyRightsAckBtn.Location = new System.Drawing.Point(16, 248);
            this.CopyRightsAckBtn.Name = "CopyRightsAckBtn";
            this.CopyRightsAckBtn.Size = new System.Drawing.Size(137, 17);
            this.CopyRightsAckBtn.TabIndex = 3;
            this.CopyRightsAckBtn.Text = "Accept Copyrights MIT.";
            this.CopyRightsAckBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CopyRightsAckBtn.UseVisualStyleBackColor = true;
            // 
            // LinkToLicenceBtn
            // 
            this.LinkToLicenceBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LinkToLicenceBtn.AutoSize = true;
            this.LinkToLicenceBtn.LinkColor = System.Drawing.Color.Black;
            this.LinkToLicenceBtn.Location = new System.Drawing.Point(149, 249);
            this.LinkToLicenceBtn.Name = "LinkToLicenceBtn";
            this.LinkToLicenceBtn.Size = new System.Drawing.Size(50, 13);
            this.LinkToLicenceBtn.TabIndex = 4;
            this.LinkToLicenceBtn.TabStop = true;
            this.LinkToLicenceBtn.Text = "more info";
            this.LinkToLicenceBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkToLicenceBtn_LinkClicked);
            // 
            // InstallBtn
            // 
            this.InstallBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallBtn.ForeColor = System.Drawing.Color.Black;
            this.InstallBtn.Location = new System.Drawing.Point(480, 241);
            this.InstallBtn.Name = "InstallBtn";
            this.InstallBtn.Size = new System.Drawing.Size(70, 26);
            this.InstallBtn.TabIndex = 5;
            this.InstallBtn.Text = "Install";
            this.InstallBtn.UseVisualStyleBackColor = true;
            this.InstallBtn.Click += new System.EventHandler(this.InstallBtn_Click);
            // 
            // QuickToolsPictures
            // 
            this.QuickToolsPictures.Image = ((System.Drawing.Image)(resources.GetObject("QuickToolsPictures.Image")));
            this.QuickToolsPictures.InitialImage = ((System.Drawing.Image)(resources.GetObject("QuickToolsPictures.InitialImage")));
            this.QuickToolsPictures.Location = new System.Drawing.Point(336, 33);
            this.QuickToolsPictures.Name = "QuickToolsPictures";
            this.QuickToolsPictures.Size = new System.Drawing.Size(137, 140);
            this.QuickToolsPictures.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.QuickToolsPictures.TabIndex = 6;
            this.QuickToolsPictures.TabStop = false;
            this.QuickToolsPictures.Click += new System.EventHandler(this.QuickToolsPictures_Click);
            // 
            // CloseInstallationBtn
            // 
            this.CloseInstallationBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.CloseInstallationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseInstallationBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseInstallationBtn.ForeColor = System.Drawing.Color.White;
            this.CloseInstallationBtn.Location = new System.Drawing.Point(523, 1);
            this.CloseInstallationBtn.Name = "CloseInstallationBtn";
            this.CloseInstallationBtn.Size = new System.Drawing.Size(31, 23);
            this.CloseInstallationBtn.TabIndex = 7;
            this.CloseInstallationBtn.Text = "X";
            this.CloseInstallationBtn.UseVisualStyleBackColor = false;
            this.CloseInstallationBtn.Click += new System.EventHandler(this.CloseInstallationBtn_Click);
            // 
            // InstalationWorker
            // 
            this.InstalationWorker.WorkerReportsProgress = true;
            this.InstalationWorker.WorkerSupportsCancellation = true;
            this.InstalationWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InstalationWorker_DoWork);
            this.InstalationWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.InstalationWorker_ProgressChanged);
            this.InstalationWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.InstalationWorker_RunWorkerCompleted);
            // 
            // InstalationTextStatus
            // 
            this.InstalationTextStatus.AutoSize = true;
            this.InstalationTextStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.InstalationTextStatus.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.InstalationTextStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstalationTextStatus.ForeColor = System.Drawing.Color.White;
            this.InstalationTextStatus.Location = new System.Drawing.Point(2, 225);
            this.InstalationTextStatus.Name = "InstalationTextStatus";
            this.InstalationTextStatus.Size = new System.Drawing.Size(26, 16);
            this.InstalationTextStatus.TabIndex = 8;
            this.InstalationTextStatus.Text = "0%";
            this.InstalationTextStatus.Visible = false;
            // 
            // InstalationPath
            // 
            this.InstalationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstalationPath.Location = new System.Drawing.Point(1, 244);
            this.InstalationPath.Name = "InstalationPath";
            this.InstalationPath.Size = new System.Drawing.Size(386, 21);
            this.InstalationPath.TabIndex = 9;
            this.InstalationPath.Visible = false;
            // 
            // InstallLocationOpen
            // 
            this.InstallLocationOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallLocationOpen.ForeColor = System.Drawing.Color.Black;
            this.InstallLocationOpen.Location = new System.Drawing.Point(399, 241);
            this.InstallLocationOpen.Name = "InstallLocationOpen";
            this.InstallLocationOpen.Size = new System.Drawing.Size(70, 26);
            this.InstallLocationOpen.TabIndex = 10;
            this.InstallLocationOpen.Text = "Change";
            this.InstallLocationOpen.UseVisualStyleBackColor = true;
            this.InstallLocationOpen.Visible = false;
            this.InstallLocationOpen.Click += new System.EventHandler(this.InstallLocationOpen_Click);
            // 
            // Caller
            // 
            this.Caller.Location = new System.Drawing.Point(124, 108);
            this.Caller.Name = "Caller";
            this.Caller.Size = new System.Drawing.Size(75, 23);
            this.Caller.TabIndex = 11;
            this.Caller.Text = "button1";
            this.Caller.UseVisualStyleBackColor = true;
            this.Caller.Click += new System.EventHandler(this.Caller_Click);
            // 
            // QuickToolsSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(556, 270);
            this.Controls.Add(this.Caller);
            this.Controls.Add(this.InstallLocationOpen);
            this.Controls.Add(this.InstalationPath);
            this.Controls.Add(this.InstalationTextStatus);
            this.Controls.Add(this.CloseInstallationBtn);
            this.Controls.Add(this.QuickToolsPictures);
            this.Controls.Add(this.InstallBtn);
            this.Controls.Add(this.LinkToLicenceBtn);
            this.Controls.Add(this.CopyRightsAckBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InstallerProgressBar);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuickToolsSetupForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickToolsSetup";
            this.Load += new System.EventHandler(this.QuickToolsSetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuickToolsPictures)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar InstallerProgressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CopyRightsAckBtn;
        private System.Windows.Forms.LinkLabel LinkToLicenceBtn;
        private System.Windows.Forms.Button InstallBtn;
        private System.Windows.Forms.PictureBox QuickToolsPictures;
        private System.Windows.Forms.Button CloseInstallationBtn;
        private System.ComponentModel.BackgroundWorker InstalationWorker;
        private System.Windows.Forms.Label InstalationTextStatus;
        private System.Windows.Forms.TextBox InstalationPath;
        private System.Windows.Forms.Button InstallLocationOpen;
        private System.Windows.Forms.Button Caller;
    }
}

