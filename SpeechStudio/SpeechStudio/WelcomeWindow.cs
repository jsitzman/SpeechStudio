using System;
/*using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Windows.Forms;
using Feedback_2;


//This is the first window displayed when the code is executed
//From this window, the SetupWindow and the main_feedback can be executed


namespace SpeechStudio
{
    public partial class WelcomeWindow : Form
    {
        //Constructor
        public WelcomeWindow()
        {
            InitializeComponent();
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

        //New Project button pressed (go to Setup Window)
        private void But_New_Click(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            SetupWindow setup = new SetupWindow(main, true);
            setup.Show();
            main.Hide();
            this.Hide();
        }

        //Load Project button pressed (go to main_feedback Window)
        private void But_Load_Click(object sender, EventArgs e)
        {
            if (open_loading.ShowDialog() == DialogResult.OK)
            {
                main_feedback a = new main_feedback(open_loading.SelectedPath);
                a.Show();
                this.Hide();
            }
        }

        //Exit button pressed (exit the application)
        private void But_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
