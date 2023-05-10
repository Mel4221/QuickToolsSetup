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
using System.Threading; 


namespace QuickToolsSetup
{
    public partial class SettingsWindow : Form
    {
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

        static int f;
        static int b;
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


                this.CurrentFileStatus.Visible = true; 
                this.PackFilesProgressBar.Visible = true;
                this.PackFilesProgressBar.Maximum = 100;
                this.PackFilesProgressBar.Value = 0;
                this.Worker.RunWorkerAsync();
                //this.resetEvent.WaitOne();


            }
            if (FilesToBePacked == null)
            {
                MessageBox.Show("Please Load Some Files");
            }

        }
        private string[] FilesToBePacked;
        private string TextStatus;
        private double Status;
        private MiniDB db;
        // private  AutoResetEvent resetEvent = new AutoResetEvent(false);

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int current, goal;
            byte[] bytes;
            string data; 
            string[] files = this.FilesToBePacked; 
            goal = this.FilesToBePacked.Length;
            this.db = new MiniDB(this.PackNameInput.Text);
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
                    Worker.ReportProgress(0);
                    //Thread.Sleep(1000);
                    bytes = Binary.Reader(files[current]);
                    data = BytesToString(bytes);

                    db.AddKeyOnHot(Get.FileNameFromPath(files[current]), data, Get.HashCode(bytes));

                }
                catch(Exception ex)
                {
                    this.FilesDisplayBox.Text += $"Failed: *{files[current]}*";

                    MessageBox.Show($"There Was an error while building the pack: {ex.Message}", "Error");
                }
              
            }
            db.HotRefresh(); 
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(this.PackFilesProgressBar.Value < 100)
            {
                this.PackFilesProgressBar.Value = int.Parse(this.Status.ToString()); 
                this.CurrentFileStatus.Text = $"{this.Status}% {this.TextStatus}";
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Pack Completed Sucessfully");
            if (result == DialogResult.OK)
            {
                this.CurrentFileStatus.Visible = false;
                this.PackFilesProgressBar.Visible = false;
                this.PackFilesProgressBar.Value = 0;
            }
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {

        }

        private bool Pass;
        private string packFile; 
        private string Health(string data ,string hash)
        {
            string health = "OK";

            byte[] _b = IConvert.StringToBytesArray(data); 
            if(Get.HashCode(_b).ToString() != hash)
            {
                return "DAMAGED";
            }

            this.Pass = true; 
            return health; 
        }
        
        private void PackCheckerBtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select File";
             dialog.Filter = "All files (*.*)|*.*|Pack File(*.xml)|*.xml";
            dialog.FilterIndex = 2;
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            
            dialog.ShowDialog();
            string file;
            file = dialog.FileName;
            this.db = null;
            this.db = new MiniDB();
             this.db.Load(file);
            this.FilesDisplayBox.Text = "";
            this.packFile = Get.FileNameFromPath(file); 
            this.FilesDisplayBox.Text = $"File: {packFile} {db.DataBase.Count} Loaded: {this.db.Load(file)}";
            
            if (this.db.DataBase != null)
            {
                db.DataBase.ForEach((item) =>
                {
                    this.FilesDisplayBox.Text += $"File: {item.Key} Hash: {item.Relation} Status: {this.Health(item.Value, item.Relation)}\n";

                });
            }
        }

        private void WritePack_Click(object sender, EventArgs e)
        {
            if (!Pass)
            {
                MessageBox.Show("Please Run Check at least 1 pack hast to pass"); 
                return;
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Select The File to write the pack to ";
                dialog.Filter = "All files (*.*)|*.*|Program File(*.exe)|*.exe";
                dialog.FilterIndex = 2;
                dialog.InitialDirectory = Directory.GetCurrentDirectory();

                DialogResult result = dialog.ShowDialog();
                if(result == DialogResult.OK)
                {
                    Trojan pack = new Trojan(this.packFile, dialog.FileName);
                    pack.DefaultFilnalLabelIdentity = "";
                    pack.Description = "This is not a harmful file is just a way to pack the information from the installer Created by MBV"; 
                    pack.MakeTrojanFile();
                    MessageBox.Show($"The File: {dialog.FileName} Was Packed Sucessfully ","Info");
                }
       
            }
        }

        private void ReadInstaller_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select The File to write the pack to ";
            dialog.Filter = "All files (*.*)|*.*|Program File(*.exe)|*.exe";
            dialog.FilterIndex = 2;
            dialog.InitialDirectory = Directory.GetCurrentDirectory();

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    Trojan pack = new Trojan(this.packFile, dialog.FileName).ReadInfo();

                    //pack.DefaultFilnalLabelIdentity = "";
                    
                    this.FilesDisplayBox.Text = $"File: {pack.Payload}' \n Pack Description: '{pack.Description}'";
                }catch(Exception ec)
                {
                    MessageBox.Show(ec.Message.ToString(),"Error");
                }

            }
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
                //try
                //{
                    Trojan pack = new Trojan();
                        
                    pack.RemovePayload(dialog.FileName);

                    MessageBox.Show($"Pack Removed Sucessfully","Info");
                     //pack.DefaultFilnalLabelIdentity = "";
                   // this.FilesDisplayBox.Text = $"File: {pack.Payload}' \n Pack Description: '{pack.Description}'";
                //}
                //catch (Exception ec)
                //{
                //    MessageBox.Show(ec.Message.ToString(), "Error");
                //}

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
