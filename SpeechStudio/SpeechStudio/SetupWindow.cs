using System;
/*using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;*/
using System.IO;
/*using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Windows.Forms;
using System.Configuration;
//using System.Speech.Recognition;

//This is the Setup Window
//From this window, the Main Window and the Welcome Window can be executed

namespace SpeechStudio
{
    public partial class SetupWindow : Form
    {
        string initial_ppt = null;
        string dir = null;
        string folder = null;
        bool kinectEnabled = false;
        bool timerEnabled = true;
        //string initial_ol = null;
        MainWindow main;
        //string output_video = null;
        //string output_text = null;
        //string output_report = null;
        bool isFirstOpen;

        //Constructor
        public SetupWindow(MainWindow mainwindow, bool notSet)
        {
            main = mainwindow;
            main.setSetupWindow(this);
            isFirstOpen = notSet;
            InitializeComponent();
        }

        //allows other windows to correctly determine where the Back button should link to
        public void setIsFirstOpen(bool change)
        {
            isFirstOpen = change;
        }

        //allows other windows to change the PowerPoint path
        public void set_initial_ppt(string path)
        {
            PPT_box.Text = path;
            initial_ppt = path;
        }

        //"X" button clicked (upper right, exit the application)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }

        //what should do when loading the setup window.
        private void SetupWindow_Load(object sender, EventArgs e)
        {

            //PPT_check.Checked = true;
            //Ol_check.Checked = true;
            Ch_Kinect.Checked = false;
            Ch_Time.Checked = true;
            But_Comfirm.Enabled = false;

            //PPT_box.Text = ConfigurationManager.AppSettings["PowerpointFileName"];
            //Ol_Box.Text = ConfigurationManager.AppSettings["OutlineFileName"];
        }

        //Back button pressed (return to previous screen)
        private void But_Back_Click(object sender, EventArgs e)
        {
            if (isFirstOpen)
            {
                WelcomeWindow welcome = new WelcomeWindow();
                this.Hide();
                initial_ppt = "";
                welcome.Show();
            }
            else
            {
                PPT_box.Text = initial_ppt;
                out_box.Text = dir;
                Proj_Name.Text = folder;
                Ch_Kinect.Checked = kinectEnabled;
                Ch_Time.Checked = timerEnabled;
                this.Hide();
                But_Comfirm_Click(sender, e); //pretend that the confirm button was clicked
            }
        }

        //PowerPoint File Browser button pressed
        private void PPT_Browse_Click(object sender, EventArgs e)
        {
            if (ppt_open.ShowDialog() == DialogResult.OK)
            {
                PPT_box.Text = ppt_open.FileName.ToString();
            }
        }

        /*private void Browse2_Click(object sender, EventArgs e)
        {
            if (Ol_Open.ShowDialog() == DialogResult.OK)
            {
                Ol_Box.Text = Ol_Open.FileName.ToString();
                initial_ol = Ol_Open.FileName.ToString();
            }
        }

        private void PPT_check_CheckedChanged(object sender, EventArgs e)
        {
            if (PPT_check.Checked == true)
            {
                buttonBrowse.Enabled = true;
                PPT_box.Enabled = true;
            }
            else if (PPT_check.Checked == false)
            {
                buttonBrowse.Enabled = false;
                PPT_box.Enabled = false;
            }
        }

        private void Ol_check_CheckedChanged(object sender, EventArgs e)
        {
            if (Ol_check.Checked == true)
            {
                Browse2.Enabled = true;
                Ol_Box.Enabled = true;
            }
            else if (Ol_check.Checked == false)
            {
                Browse2.Enabled = false;
                Ol_Box.Enabled = false;
            }
        }*/

        //Confirm button pressed (go to Main Window and set up initial variables)
        private void But_Comfirm_Click(object sender, EventArgs e)
        {
            main.Show();
            main.Enabled = true;
            initial_ppt = PPT_box.Text;
            dir = out_box.Text;
            folder = Proj_Name.Text;
            timerEnabled = Ch_Time.Checked;
            kinectEnabled = Ch_Kinect.Checked;
            if (dir.Length != 0)
            {
                string newfolder = null;
                if (folder.Length != 0)
                {
                    newfolder = "\\" + folder.ToString() + "\\";
                }
                else
                {
                    newfolder = "\\Output\\";
                }
                string directory = dir + newfolder;

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                main.set_root_out(directory.ToString());
            }
            if (initial_ppt.Length != 0)
            {
                main.display_ppt(PPT_box.Text);
            }
            if (timerEnabled)
            {
                int time = (int)Time_Value.Value;
                main.S_Time(time);
            }
            //main.S_Kinect(kinectEnabled);
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings["PowerpointFileName"] == null)
                    settings.Add("PowerpointFileName", PPT_box.Text);
                else
                    settings["PowerpointFileName"].Value = PPT_box.Text;

                /*if (settings["OutlineFileName"] == null)
                    settings.Add("OutlineFileName", Ol_Box.Text);
                else
                    settings["OutlineFileName"].Value = Ol_Box.Text;*/

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
            this.Hide();
            main.dos_and_donts_message();
            main.open_preview();
            main.TopMost = true;


        }

        //initially enables and disables the kinect
        private void Ch_Kinect_CheckedChanged(object sender, EventArgs e)
        {
            main.S_Kinect(Ch_Kinect.Checked);
        }

        //enables and disables the timer feature
        private void Ch_Time_CheckedChanged(object sender, EventArgs e)
        {
            if (Ch_Time.Checked == true)
            {
                Time_Value.Enabled = true;
                main.S_TimeLimitBox(true);
                main.S_TimeLimitBoxVisible();
            }
            else if (Ch_Time.Checked == false)
            {
                Time_Value.Enabled = false;
                main.S_TimeLimitBox(false);
                main.S_TimeLimitBoxVisible();
            }
        }

        //Output File Browser button pressed
        private void But_output_Click(object sender, EventArgs e)
        {
            if (Output_Open.ShowDialog() == DialogResult.OK)
            {
                But_Comfirm.Enabled = true;
                out_box.Text = Output_Open.SelectedPath.ToString(); ;
            }
        }
    }
}
