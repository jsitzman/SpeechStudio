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
using System.Speech.Recognition;

namespace SpeechStudio
{
    public partial class MainWindow : Form
    {
        SetupWindow configure;

        int timelimit = 0;
        int timelimit_none = 0;
        //some enable elements
        private bool bool_start = false;
        public bool kinectEnable = false;
        public bool pptdisplay = false;
        public bool is_time_limit_enabled = false; //added by Colt for Time_Count_D box enable disable

        //this is for output direction record
        private string rootfolder = null;//root folder is project folder        
        private string output_Time = null;//time series record
        private string output_Gesture = null;//gesture record
        private string output_Slide = null;//slide series record
        private string output_video = null;//video name record
        private string output_VAword = null;//visual aids context
        private string output_SPword = null;//speech context
        
        
        //slide related list
        Presentation pptPresentation;
        Microsoft.Office.Interop.PowerPoint.Application pptApplication;
        int slidenumber = 1;
        List<string> PPTImageFileList = new List<string>();
        List<int> SecPerSlide = new List<int>();
        List<int> GesturePerSlide = new List<int>();
        List<int> SmilePerSlide = new List<int>();
        List<int> LookAwayPerSlide = new List<int>();
        List<int> WordPerSlide = new List<int>();
        List<int> PausePerSlide = new List<int>();
       
        //time element
        private System.Timers.Timer overall = new System.Timers.Timer();
        private System.Timers.Timer parts = new System.Timers.Timer();
        int sec = 0, sec2 = 0;//SEC 1 is overall timer, sec2 is slide timer
        int min = 0, min2 = 0;
        bool pause = true;
        List<int> pause_list = new List<int>();
        List<int> Speak_list = new List<int>();
        List<int> Lookaway_list = new List<int>();
        List<int> Smile_list = new List<int>();


        //kinect element
        private KinectSensor kinectSensor = null;
        private BodyFrameReader bodyFrameReader = null;
        private Body[] bodies = null;
        private List<GestureDetector> gestureDetectorList = null;
        private FaceFrameSource[] faceFrameSources;
        private FaceFrameReader[] faceFrameReaders;
        bool is_happy = false;
        bool is_both_eye_detect = false;
        bool is_look_away = false;
        string last_gesture = "nothing";
        int maxBodies = 0;
        
        //video elements
        private Capture capture = null;
        private Filters filters = new Filters();
        speechrecognition.speech speecher= null;

        //filewriter
        StreamWriter slidewriter = null;
        StreamWriter speechwriter = null;
        StreamWriter timewriter = null;
        StreamWriter gesturewriter = null;
        StreamWriter VAwriter = null;
        
        //Time Series 
        SpeechRecognitionEngine speechpartner = null;

        //Constructor
        public MainWindow()
        {
            InitializeComponent();
        }

        //save current setup configuration
        //allows the users to see what their previous configuration was if they wish to modify it later
        public void setSetupWindow(SetupWindow interact)
        {
            configure = interact;
        }

        //THIS METHOD OVERRIDES NORMAL BEHAVIOR OF 'X' BUTTON ON WINDOW by adding Application.Exit() call to properly send shut off to camera as well.
        //Camera was previously preventing full shut off of application. (camera remained on after hitting 'X' button). 
        //Added by Colt Campbell
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (bool_start)
            {
                But_Start_Record_Click(exitToolStripMenuItem, e);
            }
            System.Windows.Forms.Application.Exit();
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
            
            //capture.AudioSamplingRate = 44100;          // 44.1 kHz
            capture.AudioSampleSize = 16;               // 16-bit
            //capture.AudioChannels = 1;

            capture.FrameRate = 15.997;
            pvideo.Size = new System.Drawing.Size(640, 480);

            if (this.kinectSensor.IsAvailable == true) //changed to checking if kinectSensor is available (when one's not really there, this returns false -- Colt)
            {
                if (kinectEnable == false)
                {
                    disableKinect();
                }
                else
                {
                    enableKinect();
                }
            }
            if (kinectEnable == false)
            {
                kinectToggler.Image = global::SpeechStudio.Properties.Resources.kinect_icon_disabled;
                kinectToggler.ImageTransparentColor = System.Drawing.Color.Magenta;
                kinectToggler.ToolTipText = "Click to Enable Kinect";
            }
            else
            {
                kinectToggler.Image = global::SpeechStudio.Properties.Resources.kinect_icon_enabled;
                kinectToggler.ImageTransparentColor = System.Drawing.Color.Magenta;
                kinectToggler.ToolTipText = "Click to Disable Kinect";
            }
            Time_Count_D.Text = timelimit.ToString();

            speecher = new speechrecognition.speech(this);
        }

        //change the output file rooot folder, called by setupWindow
        public void set_root_out(string target) {
            rootfolder = target;
            output_Time = target + "\\time.txt";
            output_Gesture = target+ "\\gesture.txt";
            output_Slide = target + "\\slide.txt";
            output_video = target + "\\video.mp4";
            output_VAword = target + "\\VAword.txt";
            output_SPword = target + "\\SPword.txt";
        }

        public void writetospeech(string a) {
            speechwriter.Write(a);
            List<string> word = a.Split().ToList();
            if (pptdisplay == true)
                WordPerSlide[slidenumber-1] += word.Count();
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

        public void S_PptDisplay(bool displayed)
        {
            pptdisplay = displayed;
        }

        private void enableKinect()
        {
            kinectEnable = true;
            kinectToggler.Image = global::SpeechStudio.Properties.Resources.kinect_icon_enabled;
            kinectToggler.ImageTransparentColor = System.Drawing.Color.Magenta;
            kinectToggler.ToolTipText = "Click to Disable Kinect";
            this.kinectSensor = KinectSensor.GetDefault();
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

        public void dos_and_donts_message()
        {
            //dos and don'ts in listbox
            listBoxMessage.Items.Add("Recommended Things to Remember: ------------------------------------------------------------------------------------------------------------------------\n");
            listBoxMessage.Items.Add("DO: ---------------------------------------------------------\t| DONT: ---------------------------------------------------------------------------------------------\n");
            listBoxMessage.Items.Add("* Make purposeful movements.\t\t| * Make distracting gestures (crossing arms, hands in pockets, hands on head, etc) \n");
            listBoxMessage.Items.Add("* Speak clearly.            \t\t\t| * Yell or whisper\n");
            listBoxMessage.Items.Add("* Smile, be positive.       \t\t\t| * Be negative towards your audience \n");
            listBoxMessage.Items.Add("* Stay confident.           \t\t\t| * Use filler words like \"um, uh, erm, huh, hm, etc.\" \n");
            listBoxMessage.Items.Add("* Engage your audience. \t\t\t| * Turn away from the audience. \n");
            if (pptdisplay == true)
                listBoxMessage.Items.Add("* Suppliment speech with slides \t\t| * Read directly off the slides you have \n");
            listBoxMessage.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
        }

        //remove the powerpoint object from the main window
        public void stop_displaying_ppt()
        {
            if (pptdisplay == true)
            {
                pictureBoxPowerPointPic.Image = null;
                pptdisplay = false;
            }       
        }

        //add a powerpoint object to the main window
        public void display_ppt(string target) {

            VACounterController counterController = new VACounterController();
            counterController.get_text_of_ppt(target, output_VAword);

            try
            {
                pictureBoxPowerPointPic.Image = null;
                pptApplication = new Microsoft.Office.Interop.PowerPoint.Application();
                pptPresentation = pptApplication.Presentations.Open(target, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
            }
            catch
            {
                MessageBox.Show("PowerPoint File not found!\nPlease verify that the path is right, and a .ppt file was selected.");
                return;
            }
            int size = pptPresentation.Slides.Count;
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\PowerPoint\\";
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
                    LookAwayPerSlide.Add(0);
                    WordPerSlide.Add(0);
                    PausePerSlide.Add(0);
                }
            }
        }

        //allow the user to switch to the previous powerpoint slide
        private void But_Previous_Click(object sender, EventArgs e)
        {
           
            if (slidenumber != 1)
            {
                SecPerSlide[slidenumber - 1] = sec2 + min2 * 60;
                slidenumber--;
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

        //allow the user to switch to the next powerpoint slide
        private void But_Next_Click(object sender, EventArgs e)
        {
            if (slidenumber != PPTImageFileList.Count && PPTImageFileList.Count != 0)
            {
                SecPerSlide[slidenumber - 1] = sec2 + min2 * 60;

                slidenumber++;

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
                speecher.start();
                speechwriter = new StreamWriter(output_SPword);
                /*
                ProcessStartInfo p = new ProcessStartInfo("pocketsphinx_continuous.exe");
                p.Arguments = "-inmic yes -adcdev sysdefault -hmm model/en-us/en-us -lm model/en-us/en-us.lm.dmp -dict model/en-us/cmudict-en-us.dict";
                Process.Start(p);
                */
                listBoxMessage.Items.Add(string.Format("[{0}]   start.......",t));
                But_Start_Record.Image = SpeechStudio.Properties.Resources.stop;
                But_Start_Record.ToolTipText = "Stop Recording";
                bool_start = true;
                overall.Start();
                parts.Start();
                gesturewriter = new System.IO.StreamWriter(output_Gesture);
               

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

                capture.Filename = output_video;
                capture.Start();
                speechpartner = new SpeechRecognitionEngine();
                speechpartner.SetInputToDefaultAudioDevice(); // set the input of the speech recognizer to the default audio device
                speechpartner.LoadGrammar(new DictationGrammar());
                speechpartner.RecognizeAsync(RecognizeMode.Multiple); // recognize speech asynchronous
                speechpartner.SpeechRecognized += PauseStarted;
                speechpartner.SpeechDetected += PauseEnded;
                newToolStripMenuItem.Enabled = false;
                loadToolStripMenuItem1.Enabled = false;
                settingsToolStripMenuItem.Enabled = false;
                pptSelect.Enabled = false;
                kinectToggler.Enabled = false;
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
                listBoxMessage.Items.Add("Finish up speech recognition....");
                int count = 0;
                while (speecher.ends == false) {
                    Thread.Sleep(2000);
                    count++;
                    if (count == 5) {
                        break;
                    }
                }           
                   
                But_Start_Record.Image = SpeechStudio.Properties.Resources.Icons_Land_Play_Stop_Pause_Record_Pressed;
                But_Start_Record.ToolTipText = "Start Recording";
                bool_start = false;
                gesturewriter.Close();
                output_result();
                overall.Stop();
                parts.Stop();
                disableKinect();
                newToolStripMenuItem.Enabled = true;
                loadToolStripMenuItem1.Enabled = true;
                settingsToolStripMenuItem.Enabled = true;
                pptSelect.Enabled = true;
                kinectToggler.Enabled = true; 
                speecher.end();
                speechwriter.Close();
                if(sender == But_Start_Record)
                {
                    const string message = "Would you like to view results?\nYes: View results now.\nNo: Start a new project.";
                    string caption = "Proceed";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult dialog;

                    dialog = MessageBox.Show(message, caption, buttons);

                    if (dialog == DialogResult.Yes)
                    {
                        Playback_Click(sender, e);
                    }
                    else
                    {
                        S_But_Setting_Click(sender, e);
                    }
                }
            }
        }

        //checks to see if the user is still speaking
        private void PauseStarted(object sender, SpeechRecognizedEventArgs recognized)
        {
            if (pause != true && pptdisplay) {
                PausePerSlide[slidenumber-1]++;
            }
            pause = true;
        }

        //checks to see if the user is still silent
        private void PauseEnded(object sender, SpeechDetectedEventArgs detected)
        {
            pause = false;
        }

        //display message to output window
        public void displaymessage(string a) {
            int time = min * 60 + sec;
            string message = time.ToString() + ',' + a;
                     
            if (a != "nothing")
            {                   
                    if (pptdisplay && last_gesture != a)
                    {                        
                        GesturePerSlide[slidenumber - 1]++;
                    }               
            }
            last_gesture = a;      
            listBoxMessage.ScrollAlwaysVisible = true;
            listBoxMessage.SelectedIndex = listBoxMessage.Items.Count - 1;
        }

        /*###############################################################################*/
        /*Time related part*/
        /*###############################################################################*/
        //this is overall timer
        private void Each_Tick(object sender, EventArgs e)
        {
            int time = min * 60 + sec;
            if(last_gesture != "nothing"){
                    string message = time.ToString() + "," + last_gesture;
                    gesturewriter.WriteLine(message);
            }           
            sec++;
            if (pause == true)
            {
                pause_list.Add(sec + min * 60);
            }
            else if (pause == false)
            {
                Speak_list.Add(sec + min * 60);
            }

            if (is_happy == true)
            {
                Smile_list.Add(sec + min * 60);
            }
            if (is_look_away == true)
            {
                Lookaway_list.Add(sec + min * 60);
            }
            if (sec == 60)
            {
                sec = 0;
                min++;
                if (timelimit != 0)
                {
                    timelimit--;
                    Invoke((MethodInvoker)delegate
                    {
                        Time_Count_D.Text = timelimit.ToString();
                    });
                    if (timelimit == timelimit_none / 2)
                    {
                        Time_Count_D.BackColor = Color.Yellow;
                    }
                    else if (timelimit == timelimit_none / 4)
                    {
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
        /*Kinect gesture recognition part*/
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
                    if (item.Value == DetectionResult.Yes || item.Value == DetectionResult.Maybe)
                    {
                        if (is_happy != true && pptdisplay) {
                            SmilePerSlide[slidenumber - 1]++;
                        }
                        is_happy = true;
                        
                       
                    }
                    else if (item.Value == DetectionResult.No)
                    {
                        is_happy = false;
                    }
                }
                if (item.Key.ToString() == "LookingAway")
                {
                    if (item.Value == DetectionResult.Yes)
                    {
                        if (is_look_away != true && pptdisplay) {
                            LookAwayPerSlide[slidenumber - 1]++;
                        }
                        is_look_away = true;
                    }
                    else if(item.Value == DetectionResult.No)
                    {
                        is_look_away = false;
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
            if (kinectEnable == false)
            {
                kinectToggler.Image = global::SpeechStudio.Properties.Resources.kinect_icon_disabled;
                kinectToggler.ImageTransparentColor = System.Drawing.Color.Magenta;
                kinectToggler.ToolTipText = "Click to Enable Kinect";
            }
            else
            {
                kinectToggler.Image = global::SpeechStudio.Properties.Resources.kinect_icon_enabled;
                kinectToggler.ImageTransparentColor = System.Drawing.Color.Magenta;
                kinectToggler.ToolTipText = "Click to Disable Kinect";
            }
        }
      
        //called when File>settings is clicked
        //switch to the settings window
        private void S_But_Setting_Click(object sender, EventArgs e)
        {
            configure.Show();
            if(sender == But_Start_Record)
            {
                configure.setIsFirstOpen(true);
            }
            else
            {
                configure.setIsFirstOpen(false);
            }
            
            if(pptdisplay == true)
            {
                stop_displaying_ppt();
                pptPresentation.Close();
                pptApplication.Quit();
            }
            capture.Dispose();
            this.Hide();
        }

        //called when the recording button is pressed a second time
        //switch to the main_feedback window
        private void Playback_Click(object sender, EventArgs e)
        {
            main_feedback a = new main_feedback(rootfolder);
            a.Show();
            this.Hide();
        }

        //called when the ppt button is presseed
        //opens a new powerpoint file, removes the old powerpoint file
        private void pptSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                //need a way to stop the powerpoint display before we try to display a new one. - Colt Campbell
                //set back to false for the brief moment we stop display for a new powerpoint to display
                configure.set_initial_ppt(path);
                if(pictureBoxPowerPointPic.Image != null)
                {
                    pictureBoxPowerPointPic.Image.Dispose();
                    pptdisplay = false;
                }
                display_ppt(path);
            }
        }

        //called when the kinect icon is pressed
        //disables, and enables the kinect sensor
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

        //called when File>exit is clicked
        //exit the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (bool_start)
            {
                But_Start_Record_Click(sender, e);
            }
            System.Windows.Forms.Application.Exit();
        }

        //called when File>new project is clicked
        //creates a new project
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            S_But_Setting_Click(sender, e);
        }

        //called when File>load project is clicked
        //load the feedback for a completed project
        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (open_loading.ShowDialog() == DialogResult.OK)
            {
                main_feedback a = new main_feedback(open_loading.SelectedPath);
                a.Show();
                this.Hide();
            }
        }

        private void listBoxMessage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string package(string name, List<int> set) {
            if (set != null)
            {
                foreach (int item in set)
                {
                    name += (',' + item.ToString());
                }
            }
            else {
                name += ",0";
            }
            return name;
        }

        //sets up the output files so that the main feedback window can use the files
        private void output_result() {
            slidewriter = new StreamWriter(output_Slide);
            string S_N = "S_N";//slide number
            if (PPTImageFileList != null)
            {
                for (int i = 1; i <= PPTImageFileList.Count; i++)
                {
                    S_N += ("," + i.ToString());
                }
            }
            else {
                S_N += ",0";
            }
            string TPS = "TPS";//time per slide
            string GPS = "GPS";//gesture per slide
            string SPS = "SPS";//smiler per slide
            string LPS = "LPS";//lookawat per slide
            string WPS = "WPS";//words per slide
            string PPS = "PPS";//pause per slide
            TPS = package(TPS, SecPerSlide);
            GPS = package(GPS, GesturePerSlide);
            SPS = package(SPS, SmilePerSlide);
            LPS = package(LPS, LookAwayPerSlide);
            WPS = package(WPS, WordPerSlide);
            PPS = package(PPS, PausePerSlide);

            slidewriter.WriteLine(S_N);
            slidewriter.WriteLine(TPS);
            slidewriter.WriteLine(GPS);
            slidewriter.WriteLine(SPS);
            slidewriter.WriteLine(LPS);
            slidewriter.WriteLine(WPS);
            slidewriter.WriteLine(PPS);
            slidewriter.Close();

            timewriter = new StreamWriter(output_Time);
            string result = "speak,0";
            result = package(result, Speak_list);
            string result2 = ",pause,0";
            result2 = package(result2, pause_list);
            string result3 = ",lookaway,0";
            result3 = package(result3, Lookaway_list);
            string result4 = ",smile,0";
            result4 = package(result4, Smile_list);
            result = result+result2+result3+result4;
            timewriter.WriteLine(result);
            timewriter.Close();
        }
    }
}
