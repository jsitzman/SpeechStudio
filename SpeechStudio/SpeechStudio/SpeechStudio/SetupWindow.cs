using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeechStudio
{
    public partial class SetupWindow : Form
    {
        string initial_ppt = null;
        string initial_ol = null;
        MainWindow main;
        string output_video = null;

        public SetupWindow(MainWindow mainwindow)
        {
            main = mainwindow;
           
            InitializeComponent();
        }

        private void SetupWindow_Load(object sender, EventArgs e)
        {
             PPT_check.Checked = true;
             Ol_check.Checked = true;
             Ch_Kinect.Checked = true;
             Ch_Time.Checked = true;
            But_Comfire.Enabled = false;
        }



        private void But_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            main.Show();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (ppt_open.ShowDialog() == DialogResult.OK)
            {
                PPT_box.Text = ppt_open.FileName.ToString();
                initial_ppt = ppt_open.FileName.ToString();
            }
        }

        private void Browse2_Click(object sender, EventArgs e)
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
        }

        private void But_Comfire_Click(object sender, EventArgs e)
        {

            main.Enabled = true;
            if (PPT_check.Checked == true) {
                if (PPT_box.Text != null) {
                    main.display_ppt(PPT_box.Text);
                }
            }
            if (Ch_Time.Checked == true) {
                int time;
                bool isNumeric = int.TryParse(Time_box.Text.ToString(), out time);
                if (Time_box.Text.ToString() != null && isNumeric == true) {
                    main.S_Time(time);
                }
            }
            if (out_box.Text != null)
            {
                string directory = out_box.Text + "\\Output\\";                
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                output_video = directory + "output.mp4";
                main.set_vidoe_out(output_video);
            }
            this.Hide();
            main.open_preview();
            main.TopMost = true;
            

        }

        private void Ch_Kinect_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Ch_Time_CheckedChanged(object sender, EventArgs e)
        {
            if (Ch_Time.Checked == true)
            {
                Time_box.Enabled = true;                
            }
            else if (Ch_Time.Checked == false)
            {
                Time_box.Enabled = false;
            }
        }

        private void But_output_Click(object sender, EventArgs e)
        {
            if (Output_Open.ShowDialog() == DialogResult.OK)
            {
                
                But_Comfire.Enabled = true;
                string dir = Output_Open.SelectedPath.ToString();
                out_box.Text = dir;               
            }
        }
    }
}
