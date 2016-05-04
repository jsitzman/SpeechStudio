using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using System.Configuration;
using Microsoft.Kinect;
using Microsoft.Kinect.Face;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using DirectX.Capture;
using System.Runtime.InteropServices;
using System.Threading;
using Feedback_2;

namespace SpeechStudio
{
    public partial class MainWindow : Form
    {
        SetupWindow change_Setup;

        int timelimit = 0;
        int timelimit_none = 0;
        //some enable elements
        private bool bool_start = false;
        public bool kinectfound = false;
        public bool kinectEnable = false;
        public bool pptdisplay = false;
        public bool is_time_limit_enabled = false; //added by Colt for Time_Count_D box enable disable
        //this is for output direction record
        private string rootfolder = null;
        private string projectfolder = null; //added by colt to be able to reach the project folder's output files. 
        private string output_text = null;
        private string output_report = null;
        private string output_video = null;
        
        
        //list elements for display
        List<string> PPTImageFileList = new List<string>();
        List<int> SecPerSlide = new List<int>();
        List<int> GesturePerSlide = new List<int>();
        List<int> SmilePerSlide = new List<int>();
        List<int> LookAwayPerSlide = new List<int>();


        List<int> GesturePerMins = new List<int>();
        List<int> SmilePerMins = new List<int>();
        List<int> LookAwayPerMins = new List<int>();
      //  List<FeedBack.Slidemovement> Slidemove = new List<FeedBack.Slidemovement>();


        //time element
        private System.Timers.Timer overall = new System.Timers.Timer();
        private System.Timers.Timer parts = new System.Timers.Timer();
        int sec = 0, sec2 = 0;
        int min = 0, min2 = 0;

        //slide element
        int slidenumber = 1;

        //kinect element
        private KinectSensor kinectSensor = null;
        private BodyFrameReader bodyFrameReader = null;
        private Body[] bodies = null;
        private List<GestureDetector> gestureDetectorList = null;
        private FaceFrameSource[] faceFrameSources;
        private FaceFrameReader[] faceFrameReaders;
        int maxBodies = 0;
        
        //video elements
        private Capture capture = null;
        private Filters filters = new Filters();
        
        //unknown elements
        public string status=null;


        //filewriter
        System.IO.StreamWriter commentwriter = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        //constructure, should only have initializecomponent in it.
        public void setSetupWindow(SetupWindow interact)
        {
            change_Setup = interact;
        }

        //THIS METHOD OVERRIDES NORMAL BEHAVIOR OF 'X' BUTTON ON WINDOW by adding Application.Exit() call to properly send shut off to camera as well.
        //Camera was previously preventing full shut off of application. (camera remained on after hitting 'X' button). 
        //Added by Colt Campbell
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        //the 2 lines below help enable pocketsphinx to run properly
        //[DllImport("user32.dll")]
        //static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);

        //what should do when loading the main window.
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //some function assignment and value assignment
            
            //slides setup
            Timer_Siles.Enabled = false;
            But_Next.Enabled = false;
            But_Previous.Enabled = false;
            //time setup, it is not accuracy but ok for now
            Time_Overall.Text = "0:00";
            overall.Elapsed += Each_Tick;
            overall.Interval = 1000;
            parts.Elapsed += Each_Tick2;
            parts.Interval = 1000;
            //kinect setup
            this.kinectSensor = KinectSensor.GetDefault();
            //video setup, issue1: video capture setup, add catch try if no camera was detected
            #if DEBUG
            capture = new Capture(filters.VideoInputDevices[0], filters.AudioInputDevices[0]);
            #endif
            capture.FrameSize = new System.Drawing.Size(640, 480);
           // capture.AudioSamplingRate = 44100;          // 44.1 kHz
           capture.AudioSampleSize = 16;               // 16-bit
          //  capture.AudioChannels = 1;
            capture.FrameRate = 15.997;
            pvideo.Size = new System.Drawing.Size(640, 480);
                        
            //issue2: the kinect will always be found
            if (this.kinectSensor.IsAvailable == true) //changed to checking if kinectSensor is available (when one's not really there, this returns false -- Colt
            {
               
                kinectfound = true;
                if (kinectEnable == false)
                {
                    disableKinect();
                }
                else
                {
                    enableKinect();
                }
            }
            Time_Count_D.Text = timelimit.ToString();
        }



        public void set_vidoe_out(string target) {
            capture.Filename = target;
            output_video = target;
        }
        public void set_report_out(string target) {
            output_report = target;
        }
        public void set_text_out(string target) {
            output_text = target;
        }
        public void set_root_out(string target) {
            rootfolder = target;
        }
        //added by colt to more easily access our target project folder for output handling.
        public void set_project_folder(string target) {
            projectfolder = target;
        }
        //Added to keep track of Time_Count_D usage and visibility from Setup window - Colt Campbell
        public void S_TimeLimitBox(bool is_enabled) {
            is_time_limit_enabled = is_enabled;
        }
        //checks time limit was placed in setup window and sets visibility - Colt Campbell
        public void S_TimeLimitBoxVisible()
        {
            if (is_time_limit_enabled)
            {
                Time_Count_D.Visible = true;
            }
            else
            {
                Time_Count_D.Visible = false;
            }
        }
        public void S_Time(int time){
            timelimit = time;
            timelimit_none = time;
            Time_Count_D.Text = time.ToString();
        }
        public void S_Kinect(bool enable){
            kinectEnable = enable;
        }

        private void enableKinect()
        {
            kinectEnable = true;
            kinectToggler.Image = global::SpeechStudio.Properties.Resources.kinect_icon_enabled;
            kinectToggler.ImageTransparentColor = System.Drawing.Color.Magenta;
            kinectToggler.ToolTipText = "Click to Disable Kinect";
        }

        public void disableKinect() {
            if (this.bodyFrameReader != null)
            {
                // BodyFrameReader is IDisposable
                this.bodyFrameReader.FrameArrived -= this.Reader_BodyFrameArrived;
                this.bodyFrameReader.Dispose();
                this.bodyFrameReader = null;
            }

            if (this.gestureDetectorList != null)
            {
                // The GestureDetector contains disposable members (VisualGestureBuilderFrameSource and VisualGestureBuilderFrameReader)
                foreach (GestureDetector detector in this.gestureDetectorList)
                {
                    detector.Dispose();
                }
                this.gestureDetectorList.Clear();
                this.gestureDetectorList = null;
            }
            if (this.kinectSensor != null)
            {
                this.kinectSensor.Close();
                this.kinectSensor = null;
            }
            kinectEnable = false;
            kinectToggler.Image = global::SpeechStudio.Properties.Resources.kinect_icon_disabled;
            kinectToggler.ImageTransparentColor = System.Drawing.Color.Magenta;
            kinectToggler.ToolTipText = "Click to Enable Kinect";
        }

        public void stop_displaying_ppt()
        {
            pictureBoxPowerPointPic.Image.Dispose();
        }


        public void display_ppt(string target) {
            pictureBoxPowerPointPic.Image = null;
            Microsoft.Office.Interop.PowerPoint.Application pptApplication = new Microsoft.Office.Interop.PowerPoint.Application();
            Presentation pptPresentation = pptApplication.Presentations.Open(target, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
            int size = pptPresentation.Slides.Count;
            string directory = Directory.GetCurrentDirectory() + "\\PowerPoint\\";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            if (pptdisplay == false) {
                foreach (FileInfo file in dirInfo.GetFiles())
                file.Delete();
            }           

            PPTImageFileList = new List<string>();
            for (int i = 1; i <= size; i++)
            {
                int size1 = target.Length;
                string filename = directory + target.Substring(target.Length-8,3)+ i.ToString() + ".png";
                pptPresentation.Slides[i].Export(filename, "png", 0, 0);
                PPTImageFileList.Add(filename);
                //listBoxMessage.Items.Add(string.Format("Adding file {0}", filename));
                //listBoxMessage.Items.Add(string.Format("dir: {0}, target: {1}", directory, target));
            }

            if (PPTImageFileList.Count > 0)
            {
                pptdisplay = true;
                pictureBoxPowerPointPic.Image = new Bitmap(PPTImageFileList[0]);
                But_Next.Enabled = true;
                Timer_Siles.Enabled = true;
                for (int i = 0; i < PPTImageFileList.Count; i++)
                {
                    SecPerSlide.Add(0);
                    GesturePerSlide.Add(0);
                    SmilePerSlide.Add(0);
                }
            }
        }

        private void pptStats_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = openFileDialog1.FileName;
                OutputDraft output = new OutputDraft(a, projectfolder);
                output.Show();
            }
        }


        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = openFileDialog1.FileName;
                //need a way to stop the powerpoint display before we try to display a new one. - Colt Campbell
                //set back to false for the brief moment we stop display for a new powerpoint to display
                stop_displaying_ppt();
                pptdisplay = false;
                display_ppt(a);
            }
        }

        
        private void But_Previous_Click(object sender, EventArgs e)
        {
            if (slidenumber != 1)
            {

                SecPerSlide[slidenumber - 1] = sec2 + min2 * 60;
                slidenumber--;
             //   FeedBack.Slidemovement item;
              //  item.slide_number = slidenumber;
             //   item.start_time = sec + min*60;
             //   Slidemove.Add(item);
                But_Previous.Enabled = true;

                sec2 = SecPerSlide[slidenumber - 1] % 60;
                min2 = (SecPerSlide[slidenumber - 1] - sec2) / 60;

                Timer_Siles.Text = min2.ToString() + ":" + sec2.ToString();

                But_Next.Enabled = true;
                if (slidenumber == 1)
                {
                    But_Previous.Enabled = false;
                }
                //releases resources of current slide image preparing for next slide to be displayed - Colt Campbell
                pictureBoxPowerPointPic.Image.Dispose();
                //displays previous slide
                pictureBoxPowerPointPic.Image = new Bitmap(PPTImageFileList[slidenumber-1]);
            }
            else {
                But_Previous.Enabled = false;
            }
        }


        private void But_Next_Click(object sender, EventArgs e)
        {
            if (slidenumber != PPTImageFileList.Count && PPTImageFileList.Count != 0)
            {
                SecPerSlide[slidenumber - 1] = sec2 + min2 * 60;

                slidenumber++;
              //  FeedBack.Slidemovement item;
             //   item.slide_number = slidenumber;
             //   item.start_time = sec + min * 60;
              //  Slidemove.Add(item);

                But_Previous.Enabled = true;

                sec2 = SecPerSlide[slidenumber - 1] % 60;
                min2 = (SecPerSlide[slidenumber - 1] - sec2) / 60;

                Timer_Siles.Text = min2.ToString() + ":" + sec2.ToString();

                if (slidenumber == PPTImageFileList.Count)
                {
                    But_Next.Enabled = false;
                }
                //releases resources of current slide image preparing for next slide to be displayed - Colt Campbell
                pictureBoxPowerPointPic.Image.Dispose();
                //displays next slide
                pictureBoxPowerPointPic.Image = new Bitmap(PPTImageFileList[slidenumber-1]);
            }
            else
            {
                But_Next.Enabled = false;
            }

        }

        //click start button
        private void But_Start_Record_Click(object sender, EventArgs e)
        {
            string t = DateTime.Now.ToString();
            if (bool_start == false)
            {
                /*
                ProcessStartInfo p = new ProcessStartInfo("pocketsphinx_continuous.exe");
                p.Arguments = "-inmic yes -adcdev sysdefault -hmm model/en-us/en-us -lm model/en-us/en-us.lm.dmp -dict model/en-us/cmudict-en-us.dict";
                Process.Start(p);
                */
                listBoxMessage.Items.Add(string.Format("[{0}]   start.......",t));
                But_Start_Record.Image = SpeechStudio.Properties.Resources.stop;
                bool_start = true;
                overall.Start();
                parts.Start();
                commentwriter = new System.IO.StreamWriter(output_text);
                SmilePerMins.Add(0);
                GesturePerMins.Add(0);
                SmilePerMins.Add(0);

                if (kinectEnable == true)
                {
                    this.kinectSensor.Open();
                    this.bodyFrameReader = this.kinectSensor.BodyFrameSource.OpenReader();
                    this.gestureDetectorList = new List<GestureDetector>();
                    this.bodyFrameReader.FrameArrived += this.Reader_BodyFrameArrived;

                    FaceFrameFeatures faceFrameFeatures = FaceFrameFeatures.FaceEngagement
                    | FaceFrameFeatures.Glasses
                    | FaceFrameFeatures.Happy
                    | FaceFrameFeatures.LeftEyeClosed
                    | FaceFrameFeatures.RightEyeClosed
                    | FaceFrameFeatures.LookingAway
                    | FaceFrameFeatures.MouthMoved
                    | FaceFrameFeatures.MouthOpen;

                    maxBodies = this.kinectSensor.BodyFrameSource.BodyCount;

                    this.faceFrameSources = new FaceFrameSource[maxBodies];
                    this.faceFrameReaders = new FaceFrameReader[maxBodies];


                    for (int i = 0; i < maxBodies; ++i)
                    {
                        GestureDetector detector = new GestureDetector(this.kinectSensor);
                        this.faceFrameSources[i] = new FaceFrameSource(this.kinectSensor, 0, faceFrameFeatures);
                        this.faceFrameSources[i] = new FaceFrameSource(this.kinectSensor, 0, faceFrameFeatures);
                        gestureDetectorList.Add(detector);
                        // open the corresponding reader
                        this.faceFrameReaders[i] = this.faceFrameSources[i].OpenReader();

                        // open the corresponding reader
                        this.faceFrameReaders[i] = this.faceFrameSources[i].OpenReader();
                        detector.mainhwd = this;

                    }

                    for (int i = 0; i < maxBodies; i++)
                    {
                        if (this.faceFrameReaders[i] != null)
                        {
                            // wire handler for face frame arrival
                            this.faceFrameReaders[i].FrameArrived += this.Reader_FaceFrameArrived;
                        }
                    }
                }
                capture.Start();
        }
            else {
                //WindowsMicrophoneMuteLibrary.WindowsMicMute micMute = new WindowsMicrophoneMuteLibrary.WindowsMicMute();
                //micMute.MuteMic();
                capture.Stop();
                int sum = 0;
                if (kinectEnable == true)
                {
                    for (int i = 0; i < GesturePerSlide.Count; i++)
                    {
                        string result = "Slide" + i + " spent " + SecPerSlide[i] + "sec" + ", " + GesturePerSlide[i] + " of gesture were detected.";
                        listBoxMessage.Items.Add(result);
                        sum += GesturePerSlide[i];
                    }
                    string a = "total " + sum.ToString() + " were detected.";
                    listBoxMessage.Items.Add(a);
                }
                                
                But_Start_Record.Image = SpeechStudio.Properties.Resources.Icons_Land_Play_Stop_Pause_Record_Pressed;
                bool_start = false;
                commentwriter.Close();
                output_result();
                overall.Stop();
                parts.Stop();
                disableKinect();
            }
        }

        //display message to output window
        private string last_message_g = " ";
        private string last_message_f = " ";
        public void displaymessage(string a, int model) {
            string message;
            if (model == 1)
            {
                message = min + ":" + sec + " Gesture Detected: " + a;
                
                if (a != last_message_g)
                {
                    if (a == "nothing")
                    {
                        last_message_g = "nothing";
                    }
                    else
                    {
                        commentwriter.WriteLine(message);
                        listBoxMessage.Items.Add(message);
                        last_message_g = a;
                        GesturePerSlide[slidenumber - 1]++;
                        GesturePerMins[min]++;
                    }
                }
                
            }
            else if (model == 2) {
                if (a != last_message_f)
                {
                    message = min + ":" + sec + " Face Motion: " + a;
                    listBoxMessage.Items.Add(message);
                    SmilePerMins[min]++;
                    SmilePerSlide[slidenumber - 1]++;
                }

            }
            listBoxMessage.ScrollAlwaysVisible = true;
            listBoxMessage.SelectedIndex = listBoxMessage.Items.Count - 1;

        }
        /*###############################################################################*/
        /*Time related part*/
        /*###############################################################################*/
        //this is overall timer

        

        private void Each_Tick(object sender, EventArgs e){          
            sec++;
            if (sec == 60) {
                sec = 0;
                min++;
                SmilePerMins.Add(0);
                GesturePerMins.Add(0);
                SmilePerMins.Add(0);
                if (timelimit != 0){
                    timelimit--;
                    Invoke((MethodInvoker)delegate
                    {
                        Time_Count_D.Text = timelimit.ToString();
                    });
                    if (timelimit == timelimit_none / 2) {
                        Time_Count_D.BackColor = Color.Yellow;
                    }
                    else if(timelimit == timelimit_none / 4) {
                        Time_Count_D.BackColor = Color.Red;
                    }
                }
            }
            Invoke((MethodInvoker)delegate
            {
                Time_Overall.Text = min.ToString() + ":" + sec.ToString();
            });
            }
        //Timer for each slide
        private void Each_Tick2(object sender, EventArgs e){
            if (pptdisplay == false)
            {
                sec2 = 0;
                min2 = 0;
            }
            else
            {
                sec2++;
                if (sec2 == 60)
                {
                    sec2 = 0;
                    min2++;
                }
                Timer_Siles.Text = min2.ToString() + ":" + sec2.ToString();
            }
        }
        /*###############################################################################*/
        /*Kinect face gesture part*/
        /*###############################################################################*/
        private void Reader_BodyFrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool dataReceived = false;

            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    if (this.bodies == null)
                    {
                        // creates an array of 6 bodies, which is the max number of bodies that Kinect can track simultaneously
                        this.bodies = new Body[bodyFrame.BodyCount];
                    }

                    // The first time GetAndRefreshBodyData is called, Kinect will allocate each Body in the array.
                    // As long as those body objects are not disposed and not set to null in the array,
                    // those body objects will be re-used.
                    bodyFrame.GetAndRefreshBodyData(this.bodies);
                    dataReceived = true;
                }
            }

            if (dataReceived)
            {
                // visualize the new body data
                // we may have lost/acquired bodies, so update the corresponding gesture detectors
                if (this.bodies != null)
                {
                    // loop through all bodies to see if any of the gesture detectors need to be updated

                    for (int i = 0; i < maxBodies; ++i)
                    {
                        Body body = this.bodies[i];
                        ulong trackingId = body.TrackingId;

                        // if the current body TrackingId changed, update the corresponding gesture detector with the new value
                        if (trackingId != this.gestureDetectorList[i].TrackingId)
                        {
                            this.gestureDetectorList[i].TrackingId = trackingId;
                            this.faceFrameSources[i].TrackingId = trackingId;

                            // if the current body is tracked, unpause its detector to get VisualGestureBuilderFrameArrived events
                            // if the current body is not tracked, pause its detector so we don't waste resources trying to get invalid gesture results
                            this.gestureDetectorList[i].IsPaused = trackingId == 0;
                        }
                    }
                }
            }
        }
        /*###############################################################################*/
        /*Kinect face recongnition part*/
        /*###############################################################################*/
        bool is_happy = false;
        bool is_engaged = false;
        bool is_both_eye_detect = false;
        bool is_talking = false;
        bool is_look_away = false;
        private int GetFaceSourceIndex(FaceFrameSource faceFrameSource)
        {
            int index = -1;

            for (int i = 0; i < maxBodies; i++)
            {
                if (this.faceFrameSources[i] == faceFrameSource)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private void Reader_FaceFrameArrived(object sender, FaceFrameArrivedEventArgs e)
        {
           using (FaceFrame faceFrame = e.FrameReference.AcquireFrame())
            {
                if (faceFrame != null)
                {
                    // get the index of the face source from the face source array
                    int index = this.GetFaceSourceIndex(faceFrame.FaceFrameSource);
                    if (faceFrame.FaceFrameResult != null)
                    {
                        Face_Result(faceFrame.FaceFrameResult);
                    }               
                }
            }
        }        

        private void Face_Result(FaceFrameResult result){
              foreach (var item in result.FaceProperties)
              {
                if (item.Key.ToString() == "Happy") {
                    if (item.Value == DetectionResult.Yes)
                    {
                        if (is_happy != true)
                        {
                            displaymessage("You're Smiling",2);
                            is_happy = true;
                        }
                    }
                    else {
                        is_happy = false;
                    }

                }
                if (item.Key.ToString() == "LookingAway")
                {
                    if (item.Value != DetectionResult.Yes)
                    {
                        if (is_look_away != false)
                        {
                            displaymessage("You are looking away from audience",2);
                            is_look_away = false;
                        }
                    }
                    else
                    {
                        is_look_away = true;
                    }
                }
            }
        }
        /*###############################################################################*/
        /*video capture part*/
        /*###############################################################################*/
        public void open_preview()
        {
            capture.PreviewWindow = pvideo;
        }

      
        private void S_But_Setting_Click(object sender, EventArgs e)
        {
            change_Setup.Show();
            change_Setup.setIsFirstOpen(false);
            this.Hide();
        }
        private void Playback_Click(object sender, EventArgs e)
        {
            main_feedback a = new main_feedback(rootfolder);
            a.Show();
            this.Hide();
        }

        private void But_Outline_Click(object sender, EventArgs e)
        {

        }

        private void pptSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = openFileDialog1.FileName;
                //need a way to stop the powerpoint display before we try to display a new one. - Colt Campbell
                //set back to false for the brief moment we stop display for a new powerpoint to display
                stop_displaying_ppt();
                pptdisplay = false;
                display_ppt(a);
            }
        }

        private void kinectToggler_Click(object sender, EventArgs e)
        {
            if (kinectEnable == false)
            {
                enableKinect();
            }
            else
            {
                disableKinect();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private string package(string name, List<int> set) {
            if (set != null)
            {
                foreach (int item in set)
                {
                    name += (item.ToString() + ", ");
                }
            }
            return name;
        }

        private void output_result() {
            System.IO.StreamWriter reportwriter = new System.IO.StreamWriter(output_report);
            string S_N = "S_N, ";//slide number
            if (PPTImageFileList != null) {
                for (int i = 1; i <= PPTImageFileList.Count; i++) {
                    S_N += (i.ToString() + ", ");
                }
            }
            string TPS = "TPS, ";//time per slide
            string GPS = "GPS, ";
            string SPS = "SPS, ";

            string T_T = "T_T, ";
            for (int i = 0; i <= min; i++) {
                T_T += (i.ToString() + ", ");
            }
            string GPM = "GPM,";
            string SPM = "SPM,";

            TPS = package(TPS, SecPerSlide);
            GPS = package(GPS, GesturePerSlide);
            SPS = package(SPS, SmilePerSlide);

            GPM = package(GPM, GesturePerMins);
            SPM = package(SPM, SmilePerMins);

            reportwriter.WriteLine(S_N);
            reportwriter.WriteLine(TPS);
            reportwriter.WriteLine(GPS);
            reportwriter.WriteLine(SPS);
            reportwriter.WriteLine(" ");
            reportwriter.WriteLine(T_T);
            reportwriter.WriteLine(GPM);
            reportwriter.WriteLine(SPM);

            reportwriter.Close();
        }
    }
}
