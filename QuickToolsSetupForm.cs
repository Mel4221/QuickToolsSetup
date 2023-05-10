using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using QuickTools.QIO;
using QuickTools.QNet;
using QuickTools.QData;
using QuickTools.QCore;
using QuickTools.QColors;
using QuickTools.QConsole;
using QuickTools.QSecurity;
 
namespace QuickToolsSetup
{
    public partial class QuickToolsSetupForm : Form
    {
        public QuickToolsSetupForm()
        {
            InitializeComponent();
        }

        private void LinkToLicenceBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Thread(() => { Process.Start("https://github.com/Mel4221/QuickToolsScript/blob/main/LICENSE"); }).Start(); 
        }

        private void CloseInstallationBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InstallBtn_Click(object sender, EventArgs e)
        {
            if (this.CopyRightsAckBtn.Checked != true)
            {
                MessageBox.Show("Please Accept The Licence", "Info");
                return;
            }
            else
            {
                //hidding copyright 
                CopyRightsAckBtn.Visible = false;
                LinkToLicenceBtn.Visible = false; 
                //showing text status 
                this.InstalationTextStatus.Visible = true; 
                //showing the status var 
                this.InstallerProgressBar.Visible = true;
                this.InstallerProgressBar.Maximum = 100;
                this.InstallerProgressBar.Value = 0;
         
                InstalationWorker.RunWorkerAsync();
            }
        
        }


        public int Status;
        public string TextStatus; 
        private void InstalationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int current, goal;
            string text;

            goal = 100;
            for(current = 0; current < goal; current++)
            {
                this.Status = int.Parse(Get.StatusNumber(current, goal-1).ToString());
                this.TextStatus = $"{this.Status}%";
                Thread.Sleep(100);
                this.InstalationWorker.ReportProgress(0);
            }
        }

        private void InstalationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(this.InstallerProgressBar.Value != 100)
            {
                this.InstallerProgressBar.Value++;
                this.InstalationTextStatus.Text = $"Installing: {this.TextStatus}";
            }
        }

        private void InstalationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult result =   MessageBox.Show("Installation Completed Sucessfully","Info");
            if(result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        int settingsCount = 0; 
        private void QuickToolsPictures_Click(object sender, EventArgs e)
        {
            if(settingsCount < 2)
            {
                settingsCount++;
                return;
            }
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
            this.Hide();
        }
    }
}
