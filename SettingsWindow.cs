using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickTools.QIO;
using QuickTools.QSecurity.FalseIO; 
using QuickTools.QNet;
using QuickTools.QData;
using QuickTools.QCore;
using QuickTools.QColors;
using QuickTools.QConsole;
using QuickTools.QSecurity;
using System.Reflection;
using System.Threading; 


namespace QuickToolsSetup
{



    /// <summary>
    ///         internal variables are label a kindof depending on their use but there are exceptions such as 
    ///         when the variable belongs to the value of an external object from the form 
    ///         so if the object form  name is Input
    ///         the internal variable will be set to _InputText
    /// </summary>
    public partial class SettingsWindow : Form
    {
        static int f;
        static int b;
        private bool Pass;
        private double Status;
        private string TextStatus;
        private string _PackFileName;
        private string[] FilesToBePacked;
        private string DialogMessage;
        private string CurrentActionInfo;
        private bool _MessageBoxAllowed;
        private string _InstallerDescriptionText;
        private bool _FilesDisplayBoxAllow;
        private string _FilesDisplayBoxText;
        private bool _WaitForAckolegeMent;
        private bool _WritePackCompleted;
        public string PackInfo;
        public  double PullingStatus;
        public  string PullingTextStatus; 
       

        private MiniDB db;
        private Action<BackgroundWorker> CurrentAction;

        public SettingsWindow()
        {
            InitializeComponent();
            this.FilesPath.Text = Get.Path;
        
        }

        private void CloseSettingsWindow_Click(object sender, EventArgs e)
        {
            this.Close();
            new QuickToolsSetupForm().Show();
        }

        private void LoadFilesBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select Files";
            dialog.Multiselect = true;
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.FilesDisplayBox.Text = "";
                string[] files = dialog.FileNames;
                this.FilesPath.Text = files[0].ToString().Substring(0,files[0].LastIndexOf(Get.Slash()));
                foreach(string file in files)
                {
                    this.FilesDisplayBox.Text += $"{file}\n";
                }
                this.FilesToBePacked = files;


            }
            
             
        }
        
        public void PullPackOut(BackgroundWorker worker)
        {
            Trojan pack = new Trojan();
            string exe, ass, packInfo, file, path, data, str;
            int current, goal;
            byte[] bytes;
            bool packLoaded = false;
            packInfo = null;
            goal = 100;

            //Reading and looking for the pack file in the background
            new Thread(() =>
            {
                ass = @"..\Release\QuickToolsSetup.exe";// Assembly.GetExecutingAssembly().ToString();
                //exe = ass.Substring(0, ass.IndexOf(",")) + ".exe";
                //this.PullingTextStatus = $"Reading Packed File: {exe}";
                //worker.ReportProgress(0);
                //Thread.Sleep(3000);
                //pack.TrojanFile = ass;//as default should be exe
                pack.TrojanFile = ass;
                pack.PullPayloadFromTrojan();
                packInfo = pack.ReadInfo().Payload;
                Thread.Sleep(1000);                //Thread.Sleep(5000);
                packLoaded = true;
                GC.Collect();
            }).Start();

            //holding the thread until it gets the confirmation from the background Thread
            while (!packLoaded)
            {
                this.PullingTextStatus = "Searching Pack File Please Wait...";
                this.PullingStatus = QuickTools.QCore.IRandom.RandomInt(0, 100);
                worker.ReportProgress(0);
                Thread.Sleep(100);
            }
            //str = Get.FilterOnlyChars(packInfo);
            this.PullingTextStatus = $"Pack Fonded: {packInfo}";
            worker.ReportProgress(0);
            Thread.Sleep(1000);
            
            MiniDB db = new MiniDB(packInfo);
            this.PullingTextStatus = $"Pack Loaded: {File.Exists(packInfo)}";
            worker.ReportProgress(0);
            Thread.Sleep(1000);

            for (current = 0; current < goal; current++)
            {
                worker.ReportProgress(0);


                this.PullingStatus = Get.StatusNumber(current, goal - 1);
                Thread.Sleep(100);
      

            }
            //ass = @"C:\Users\William\Desktop\C#\QuickToolsSetup\bin\Release\..\QuickToolsSetup.exe";// Assembly.GetExecutingAssembly().ToString();
            //exe = ass.Substring(0, ass.IndexOf(",")) + ".exe";
            //this.PullingTextStatus = $"Reading Packed File: {exe}";
            //worker.ReportProgress(0);
            //Thread.Sleep(3000);
            //pack.TrojanFile = exe;
            //try
            //{
            //    packInfo = pack.ReadInfo().Payload;
            //    this.PackInfo = packInfo;
            //    if (packInfo != "")
            //    {
            //        pack.PullPayloadFromTrojan(exe);
            //        Make.Directory("temp");
            //        MiniDB db = new MiniDB(packInfo);
            //        // db.Drop(); 

            //        if (db.Load())
            //        {
            //            goal = db.DataBase.Count;
            //            for (current = 0; current < goal; current++)
            //            {

            //                //file = db.DataBase[current].Key;
            //                //data = db.DataBase[current].Value;
            //                //bytes = QuickToolsSetupForm.StringToBytesArray(data);
            //                //path = $"temp{Get.Slash()}{file}";
            //                //QuickToolsSetupForm.Writer(path, bytes);
            //                //this.PullingTextStatus = $"UnPacking {file}";
            //                this.PullingStatus = Get.StatusNumber(current, goal - 1);
            //                worker.ReportProgress(0);
            //                Thread.Sleep(100);
            //            }

            //            return;
            //        }
            //        else
            //        {
            //            throw new Exception("The Package File looks DAMAGED");
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.PackInfo = $"It Look that something did not go well while unpacking some files more info: \n {ex.Message}";
            //    return;
            //}





        }
    
        /// <summary>
        /// Converts the bytes given to a row string of bytes but is slow 
        /// </summary>
        /// <returns>The to string.</returns>
        /// <param name="array">Array.</param>
        public static string BytesToString(byte[] array)
        {
            try
            {

                Thread foward, back;
                StringBuilder str1, str2;
                int fw, bc, len, half;
                bool trigerA, trigerB;
                len = array.Length;
                half = len / 2;
                fw = 0;
                bc = 0;
                trigerA = false;
                trigerB = false;
                str1 = new StringBuilder();
                str2 = new StringBuilder();
                if (len != (half + half))
                {
                    // Get.Ok();
                    fw = half + 1;
                    bc = len;

                }
                if (len == (half + half))
                {
                    fw = half;
                    bc = len;
                }
                //Get.Wait();
                foward = new Thread(() =>
                {
                    for (int i = 0; i < fw; i++)
                    {
                        //  Get.Green(i);
                        f = i;
                        str1.Append(array[i] + ",");

                    }
                    trigerA = true;
                });

                back = new Thread(() =>
                {
                    for (int i = half; i < len; i++)
                    {
                        //  Get.Red(i);
                        b = i;
                        str2.Append(array[i] + ",");

                    }
                    trigerB = true;
                });

                foward.Start();
                back.Start();


                while (true)
                {

                    // Get.Green($"F: {f} B: {b} Size: {array.Length}  A:{Get.Status(f , b)} ");

                    if (trigerA == true && trigerB == true)
                    {
                        return str1.ToString() + str2.ToString();
                        //Writer.Write("test.txt" , str);
                    }
                    //Thread.Sleep(5000);

                }
            }
            catch (Exception ex)
            {
              //  Color.Yellow("It Looks like the array was empty and it can not be converted \n" + ex);
                return null;
            }


        }

        private void PackFilesBtn_Click(object sender, EventArgs e)
        {
            if (FilesToBePacked != null)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Select File";
                this.DialogMessage = "Select The Pack File";
                dialog.Filter = $"All files (*.*)|*.*|{this.DialogMessage}(*.xml)|*.xml";
                dialog.FilterIndex = 2;
                dialog.InitialDirectory = Directory.GetCurrentDirectory();

                this._WaitForAckolegeMent = true; 
                this.CurrentFileStatus.Visible = true; 
                this.PackFilesProgressBar.Visible = true;
                this.PackFilesProgressBar.Maximum = 100;
                this.PackFilesProgressBar.Value = 0;
                this._MessageBoxAllowed = false;
                if (this.PackFileNameInput.Text != "")
                {
                    this._PackFileName = this.PackFileNameInput.Text;
                }
                if (this.PackFileNameInput.Text == "")
                {
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        this.PackFileNameInput.Text = dialog.FileName; 
                        this._PackFileName = dialog.FileName;
                    }
                }
                if(this.PackFileNameInput.Text == "" || this._PackFileName == "")
                {
                    this.PackFileNameInput.Text = "Pack.xml";
                    this._PackFileName = "Pack.xml";
                }
                this.CurrentAction = PackFilesAction;
                if (!this.Worker.IsBusy)
                {
                    this.Worker.RunWorkerAsync();

                }
                //this.resetEvent.WaitOne();


            }
            if (FilesToBePacked == null)
            {
                MessageBox.Show("Please Load Some Files");
            }

        }
  
        private void PackFilesAction(BackgroundWorker worker)
        {
            int current, goal;
            byte[] bytes;
            string data;
            string[] files = this.FilesToBePacked;
            goal = this.FilesToBePacked.Length;
            this.db = new MiniDB(this._PackFileName);
            this.db.Drop();
            this.db.Create();
            //Print.List(files);
            for (int x = 0; x < goal; x++)
            {
                current = x;
                this.Status = Get.StatusNumber(current, goal - 1);
                this.TextStatus = files[current];
                try
                {
                    worker.ReportProgress(0);
                    //Thread.Sleep(1000);
                    bytes = Binary.Reader(files[current]);
                    data = BytesToString(bytes);

                    db.AddKeyOnHot(Get.FileNameFromPath(files[current]), data, Get.HashCode(bytes));

                }
                catch (Exception ex)
                {
                    this._FilesDisplayBoxAllow = true; 
                    this._FilesDisplayBoxText = $"Failed: *{files[current]}*";

                    this.DialogMessage = $"There Was an error while building the pack: {ex.Message}";
                }
                this.CurrentActionInfo = "Pack Completed Sucessfully"; 
            }
            db.HotRefresh();

        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.CurrentAction != null)
            {
                this.CurrentAction(this.Worker);
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(this.PackFilesProgressBar.Value < this.PackFilesProgressBar.Maximum)
            {
                this.PackFilesProgressBar.Value = int.Parse(this.Status.ToString()); 
                this.CurrentFileStatus.Text = $"{this.Status}% {this.TextStatus}";
                if (this._FilesDisplayBoxAllow)
                {
                    this.FilesDisplayBox.Text += this._FilesDisplayBoxText;
                }
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (!_WaitForAckolegeMent)
            {
                this.CurrentFileStatus.Visible = false;
                this.PackFilesProgressBar.Visible = false;
                this.PackFilesProgressBar.Value = 0;
                this.CurrentActionInfo = "";
                GC.Collect();// because it was holding the files even thought was not needed 
            }

            if (_MessageBoxAllowed || _WaitForAckolegeMent)
            {
                DialogResult result = MessageBox.Show(this.CurrentActionInfo, "Info");
                if (result == DialogResult.OK)
                {
                    this._WaitForAckolegeMent = false;
                    this._MessageBoxAllowed = false; 
                    this.CurrentFileStatus.Visible = false;
                    this.PackFilesProgressBar.Visible = false;
                    this.PackFilesProgressBar.Value = 0;
                    this.CurrentActionInfo = "";

                    //jthis.CurrentAction = null;
                }
            }
        
        }




        private string Health(string data ,string hash)
        {
            string health = "OK";

            byte[] _b = QuickToolsSetupForm.StringToBytesArray(data); 
            if(Get.HashCode(_b).ToString() != hash)
            {
                return "DAMAGED";
            }
            //worker.ReportProgress(0);
            this.Pass = true; 
            return health; 
        }
        private void  PackCheckAction(BackgroundWorker worker)
        {
          
            string packFile , file, hash, data, status; 
            int current, goal;
            packFile = this._PackFileName; 
            this.db = new MiniDB();
            this.db.Load(packFile);
            //this.FilesDisplayBox.Text = "";


            //this.packFile = Get.FileNameFromPath(file);
            //this.FilesDisplayBox.Text = $"File: {packFile} {db.DataBase.Count} Loaded: {this.db.Load(file)}";

            //if (this.db.DataBase != null)
            //{
            //    for (int current = 0; current < this.db.DataBase.Count; current++)
            //    {
            //        this.Status = Get.StatusNumber(current, this.db.DataBase.Count - 1);
            //        this.TextStatus = this.db.DataBase[current].Key;
            //        this.FilesDisplayBox.Text += $"File: {this.db.DataBase[current].Key} Hash: {this.db.DataBase[current].Relation} Status: {this.Health(this.db.DataBase[current].Value, this.db.DataBase[current].Relation)}\n";
            //        //this.FilesDisplayBox.Text += $"File: {item.Key} Hash: {item.Relation} Status: {this.Health(item.Value, item.Relation)}\n";
            goal = this.db.DataBase.Count;
            
            for(current = 0; current < goal; current++)
            {
                file = this.db.DataBase[current].Key;
                data = this.db.DataBase[current].Value;
                hash = this.db.DataBase[current].Relation;
                status = this.Health(this.db.DataBase[current].Value, this.db.DataBase[current].Relation);
                this._FilesDisplayBoxAllow = true;
                this._FilesDisplayBoxText = $"File: {file} Hash: {hash} Status: {status}\n";
                this.Status = Get.StatusNumber(current, goal-1);
                this.TextStatus = $"{file}";
                Thread.Sleep(100);
                worker.ReportProgress(0);
               
            }

            //    }
            //}
        }
        private void PackCheckerBtn_Click(object sender, EventArgs e)
        {
            if (!this.Worker.IsBusy)
            {
                this.FilesDisplayBox.Text = ""; 
                this.CurrentFileStatus.Visible = true;
                this.CurrentActionInfo = "Check Completed";
                this.PackFilesProgressBar.Visible = true;
                this.PackFilesProgressBar.Maximum = 100;
                this.PackFilesProgressBar.Value = 0;
                this._WaitForAckolegeMent = true; 
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Select File";
                this.DialogMessage = "Select The Pack File";
                dialog.Filter = $"All files (*.*)|*.*|{this.DialogMessage}(*.xml)|*.xml";
                dialog.FilterIndex = 2;
                dialog.InitialDirectory = Directory.GetCurrentDirectory();
                if (this.PackFileNameInput.Text != "")
                {
                    this._PackFileName = this.PackFileNameInput.Text; 
                }
                if (this.PackFileNameInput.Text == "")
                {
                    DialogResult result = dialog.ShowDialog();
                    if(result == DialogResult.OK)
                    {
                        this._PackFileName = dialog.FileName; 
                    }
                }
  
                this.CurrentAction = PackCheckAction;
                this.Worker.RunWorkerAsync();
            }
        }



        private void WritePackAction(BackgroundWorker worker)
        {
            //if (true)
            //{
                 string file;
            bool doneBackUp, writting;
            doneBackUp = false;
            writting = false; 
                file = this.TextStatus; 
               
                Trojan pack = new Trojan(this._PackFileName, file);
                pack.DefaultFilnalLabelIdentity = "";
                if(this._InstallerDescriptionText != "" && this._InstallerDescriptionText.Contains(":") != true)
            {
                pack.Description = this._InstallerDescriptionText;
            }
            if (this._InstallerDescriptionText == "")
            {
                pack.Description = "This is not a harmful file is just a way to pack the information from the installer Created by MBV";
            }
            new Thread(() => {
                //C:\Users\William\Desktop\C#\QuickToolsSetup\bin\Release\QuickToolsSetup.exe
                byte[] bytes = Binary.Reader(file);
                Binary.Writer($"{Get.FolderFromPath(file)}BackUp_{Get.FileNameFromPath(file)}", bytes);
                Thread.Sleep(5000);
                doneBackUp = true;
                GC.Collect();
            }).Start();

            while (!doneBackUp)
            {
                this.TextStatus = $"Creatting BackUp File: {file}";
                this.Status = 50;
                worker.ReportProgress(0);
                Thread.Sleep(100);
            }
            new Thread(() => {
                pack.MakeTrojanFile();
                Thread.Sleep(5000);
                writting = true;
                GC.Collect();
            }).Start();
            while (!writting)
            {
                worker.ReportProgress(0);
                this.TextStatus = $"Writting File: {file}";
                this.Status = 75; 
                Thread.Sleep(100);

            }
            this.Status = 100; 
            worker.ReportProgress(0);
            Thread.Sleep(1000);
            //this.Status = 100;
            // worker.ReportProgress(0);
            //MessageBox.Show($"The File: {file} Was Packed Sucessfully ", "Info");
            //}
        }
 
        private void WritePack_Click(object sender, EventArgs e)
        {
            if (!Pass)
            {
                MessageBox.Show("Please I Recommend Run The Check at least 1 pack should pass");
                this.Pass = true;
                return;
            }
            else
            {
                if (!this.Worker.IsBusy)
                {
                    //this.FilesDisplayBox.Text = "";
                    this.CurrentFileStatus.Visible = true;                    
                    this.PackFilesProgressBar.Visible = true;
                    this._WaitForAckolegeMent = true; 
                    this.PackFilesProgressBar.Maximum = 100;
                    this.PackFilesProgressBar.Value = 0;

                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Title = "Select The File to write the pack to ";
                    this.DialogMessage = "Select The Program That you Want to write the pack on ";
                    dialog.Filter = $"All files (*.*)|*.*|{this.DialogMessage}(*.exe)|*.exe";
                    dialog.FilterIndex = 2;
                    dialog.InitialDirectory = Directory.GetCurrentDirectory();
 
                    DialogResult result = dialog.ShowDialog();
                    if(result == DialogResult.OK)
                    {
                        //InstallerDescription
                        this.CurrentActionInfo = $"{Get.FileNameFromPath(dialog.FileName)} Was Written Sucessfully";
                        this.TextStatus = dialog.FileName;
                        this._PackFileName = this.PackFileNameInput.Text;
                        this._InstallerDescriptionText = this.InstallerDescription.Text; 
                        this.CurrentAction = this.WritePackAction;
                        this.FilesPath.Text = dialog.FileName;
                        this.Worker.RunWorkerAsync();
                        this._WritePackCompleted = true; 


                    }

                }

            }
        }
        

        private void ReadInstallerAction(BackgroundWorker worker)
        {
            //try
            //{
                Trojan pack = new Trojan();
                pack.TrojanFile = this.TextStatus;
            bool hasInfo = false; 
            new Thread(() => {
                    pack.ReadInfo();

                //pack.DefaultFilnalLabelIdentity = "";
                this._FilesDisplayBoxAllow = true;
           
                worker.ReportProgress(0); 
                this._FilesDisplayBoxText = $"File: {pack.Payload}' \n Pack Description: '{pack.Description}'";
                Thread.Sleep(5000);
                this.Status = 100;
                //this._WritePackCompleted = false;
            }).Start();

            while (!hasInfo)
            {
                this.TextStatus = $"Reading Installer {this.TextStatus}"; 
                worker.ReportProgress(0);
                this.Status = IRandom.RandomInt(0, 100);
                Thread.Sleep(100);
            }

            //}
            //catch (Exception ec)
            //{
            //MessageBox.Show(ec.Message.ToString(), "Error");
            //this._WritePackCompleted = false; 

            //}
        }

        private void ReadInstaller_Click(object sender, EventArgs e)
        {



            if (!this.Worker.IsBusy)
            {
                OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select The File to read ";
            dialog.Filter = "All files (*.*)|*.*|Program File(*.exe)|*.exe";
            dialog.FilterIndex = 2;
            dialog.InitialDirectory = Directory.GetCurrentDirectory();


            //DialogResult result = new DialogResult(); 
            //if (!this._WritePackCompleted)
            //{
               DialogResult result = dialog.ShowDialog();
            //}
            if (result == DialogResult.OK)
            {

                this.CurrentFileStatus.Visible = true;
                this.CurrentActionInfo = "The Program Was loaded Sucessfully";
                this.PackFilesProgressBar.Visible = true;
                this.PackFilesProgressBar.Maximum = 100;
                this.PackFilesProgressBar.Value = 0;
                    this._WaitForAckolegeMent = true; 

                    this.FilesDisplayBox.Text = "";
                    this._PackFileName = this.PackFileNameInput.Text;
                    this.TextStatus = dialog.FileName;
                    this.CurrentAction = this.ReadInstallerAction;
                    this.Worker.RunWorkerAsync();
                }
            }
            //this._WritePackCompleted = false; 
        }



        private void RemovePackAction(BackgroundWorker worker)
        {
            Trojan pack = new Trojan();
            this.Status = 50; 
            worker.ReportProgress(0);
            pack.RemovePayload(this.TextStatus);
            this.Status = 100;
            worker.ReportProgress(0);
            Thread.Sleep(100);
        }

        private void RemovePack_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select The File to write the pack to ";
            dialog.Filter = "All files (*.*)|*.*|Program File(*.exe)|*.exe";
            dialog.FilterIndex = 2;
            dialog.InitialDirectory = Directory.GetCurrentDirectory();

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!this.Worker.IsBusy)
                {
                    this.TextStatus = dialog.FileName;
                    this.CurrentAction = this.RemovePackAction;
                    this._MessageBoxAllowed = true;
                    this.DialogMessage = $"Done"; 
                    this.Worker.RunWorkerAsync();
                }
                //try
                //{
                 
                 //   MessageBox.Show($"Pack Removed Sucessfully","Info");
                     //pack.DefaultFilnalLabelIdentity = "";
                   // this.FilesDisplayBox.Text = $"File: {pack.Payload}' \n Pack Description: '{pack.Description}'";
                //}
                //catch (Exception ec)
                //{
                //    MessageBox.Show(ec.Message.ToString(), "Error");
                //}

            }
        }

        
        private void ClearLogsBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would You like to clear the logs ","Warning",MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    this.FilesToBePacked = null;
                    this.FilesDisplayBox.Text = "";
                    break;
                default:
                    break;
            }
        }
        private bool _InstallerDescriptionAlert; 
        private void InstallerDescription_TextChanged(object sender, EventArgs e)
        {
            if (!_InstallerDescriptionAlert)
            {
                MessageBox.Show(@"Do Not add  doble dots ':'", "Warning");
                _InstallerDescriptionAlert = true; 
            }
        }

        private void AddDescriptionBtn_Click(object sender, EventArgs e)
        {
            switch (this.InstallerDescription.Visible)
            {
                case true:
                    this.InstallerDescription.Visible = false;
                    this.AddDescriptionBtn.Text = "Add Description"; 
                    this.CheckInstaller.Visible = true;
                    this.SaveLogsBtn.Visible = true;
                    break;
                case false:
                    this.CheckInstaller.Visible = false;
                    this.SaveLogsBtn.Visible = false;
                    this.InstallerDescription.Visible = true;
                    this.AddDescriptionBtn.Text = "Hide Description";
                    break; 
            }
        }

        private void CheckInstaller_Click(object sender, EventArgs e)
        {

        }

        private void FilesDisplayBox_TextChanged(object sender, EventArgs e)
        {
            this.FilesDisplayBox.SelectionStart = this.FilesDisplayBox.Text.Length;
            // scroll it automatically
            this.FilesDisplayBox.ScrollToCaret();

        }

    private void SettingsWindow_Load(object sender, EventArgs e)
        {

        }

        private void SaveLogsBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Select The File location ";
            dialog.Filter = "All files (*.*)|*.*|Program File(*.txt)|*.txt";
            dialog.FilterIndex = 0;
            dialog.FileName = "logs.txt";
            if(this.FilesDisplayBox.Text == "")
            {
                return; 
            }
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                Writer.Write(dialog.FileName,this.FilesDisplayBox.Text);
            }
        }


        /*
        private void PackFilesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int current, goal;
            byte[] bytes;
            string data, file;
            string[] files = this.FilesToBePacked; 
            current = 0;
            goal = FilesToBePacked.Length; 
            for(current = 0; current < goal; current++)
            {
                Get.WaitTime(100);
                this.TextStatus = files[current]; 
                this.PackFilesWorker.ReportProgress(0); 
            }


        }

        private void PackFilesWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(PackFilesProgressBar.Value != 100)
            {
                this.PackFilesProgressBar.Value++;
                this.CurrentFileStatus.Text = $"{this.Status}% {this.TextStatus}"; 
            }
        }

        private void PackFilesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult  result = MessageBox.Show("Pack Completed Sucessfully");
            if (result == DialogResult.OK)
            {
                this.PackFilesProgressBar.Visible = false;
                this.PackFilesProgressBar.Value = 0;
            }
          
        }*/


    }
}
