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



namespace SpeechStudio
{
    public partial class MainWindow : Form
    {
        SetupWindow initial_Setup;
        int timelimit;
        bool kinectfound = false;
        bool kinectEnable = true;
        bool pptdisplay = false;


        List<string> PPTImageFileList = new List<string>();
        List<int> SecPerSlide = new List<int>();
        List<int> GesturePerSlide = new List<int>();
        int slidenumber = 1;

        string KinectDBName;
        int sec = 0, sec2 = 0;
        int min = 0, min2 = 0;

        private System.Timers.Timer overall = new System.Timers.Timer();
        private System.Timers.Timer parts = new System.Timers.Timer();



        private KinectSensor kinectSensor = null;
        
        private BodyFrameReader bodyFrameReader = null;
        private Body[] bodies = null;
        private List<GestureDetector> gestureDetectorList = null;

        public string status=null;


        private FaceFrameSource[] faceFrameSources;
        private FaceFrameReader[] faceFrameReaders;

        int maxBodies = 0;


        private Capture capture = null;
        private Filters filters = new Filters();



        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            string KinectDBName = ConfigurationManager.AppSettings["KinectDatabase"];
            Time_Overall.Text = "0:00";

            overall.Elapsed += Each_Tick;
            overall.Interval = 1000;
            parts.Elapsed += Each_Tick2;
            parts.Interval = 1000;
            Timer_Siles.Enabled = false;

            But_Next.Enabled = false;
            But_Previous.Enabled = false;
            

            this.kinectSensor = KinectSensor.GetDefault();
            if (this.kinectSensor != null) {
                kinectfound = true;
            }

            initial_Setup = new SetupWindow(this);
            initial_Setup.Show();
            initial_Setup.TopMost = true;
            this.Enabled = false;


            #if DEBUG
            capture = new Capture(filters.VideoInputDevices[0], filters.AudioInputDevices[0]);
#endif
            capture.FrameSize = new Size(640,480);
            pvideo.Size = new Size(640, 480);

            

        }



        public void set_vidoe_out(string target) {
            capture.Filename = target;
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
                listBoxMessage.Items.Add(string.Format("Adding file {0}", filename));
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
                }
            }


        }

        public void S_Time(int time) {
            timelimit = time;
        }

        public void S_Kinect(bool enable) {
            kinectEnable = enable;
        }



    private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = openFileDialog1.FileName;
                display_ppt(a);
            }
        }

        private bool bool_start = false;

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
                But_Previous.Enabled = true;

                sec2 = SecPerSlide[slidenumber - 1] % 60;
                min2 = (SecPerSlide[slidenumber - 1] - sec2) / 60;

                Timer_Siles.Text = min2.ToString() + ":" + sec2.ToString();

                if (slidenumber == PPTImageFileList.Count)
                {
                    But_Next.Enabled = false;
                }
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
                listBoxMessage.Items.Add(string.Format("[{0}]   start.......",t));
                But_Start_Record.Image = SpeechStudio.Properties.Resources.stop;
                bool_start = true;
                overall.Start();
                parts.Start();

                this.kinectSensor.Open();
                this.bodyFrameReader = this.kinectSensor.BodyFrameSource.OpenReader();
                this.gestureDetectorList = new List<GestureDetector>();
                this.bodyFrameReader.FrameArrived += this.Reader_BodyFrameArrived;

                FaceFrameFeatures faceFrameFeatures =  FaceFrameFeatures.FaceEngagement
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

                capture.Start();
    }
            else {
                capture.Stop();
                But_Start_Record.Image = SpeechStudio.Properties.Resources.Icons_Land_Play_Stop_Pause_Record_Pressed;
                bool_start = false;
                overall.Stop();
                parts.Stop();

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
            }
        }

        //display message to output window
        private string last_message = " ";
        public void displaymessage(string a, int model) {
            string message;
            if (model == 1)
            {
                message = min + ":" + sec + " Gesture Detected: " + a;
                if (a != last_message)
                {
                    if (a == "nothing")
                    {
                        last_message = "nothing";
                    }
                    else
                    {
                        listBoxMessage.Items.Add(message);
                        last_message = a;
                    }
                }
                
            }
            else if (model == 2) {
                if (a != last_message)
                {
                    message = min + ":" + sec + " Face Motion: " + a;
                    listBoxMessage.Items.Add(message);
                }

            }
            listBoxMessage.ScrollAlwaysVisible = true;
            listBoxMessage.SelectedIndex = listBoxMessage.Items.Count - 1;

        }
        

        //Timer for overall presentation
        private void Each_Tick(object sender, EventArgs e)
        {
            
           
            sec++;
            if (sec == 60) {
                sec = 0;
                min++;
            }
            Time_Overall.Text = min.ToString() + ":" + sec.ToString();
        }


        //Timer for each slide
        private void Each_Tick2(object sender, EventArgs e)
        {
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


        bool is_happy = false;
        bool is_engaged = false;
        bool is_both_eye_detect = false;
        bool is_talking = false;
        bool is_look_away = false;

        private void Face_Result(FaceFrameResult result) {

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

                if (item.Key.ToString() == "Engaged") {
                    if (item.Value != DetectionResult.Yes)
                    {
                        if (is_engaged != false)
                        {
                            displaymessage("You are not engaging your audience",2);
                            is_engaged = false;
                        }
                    }
                    else
                    {
                        is_engaged = true;
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
                        is_engaged = true;
                    }
                }



            }

        }

        public void open_preview()
        {
            capture.PreviewWindow = pvideo;
        }

        private void S_But_Setting_Click(object sender, EventArgs e)
        {
            initial_Setup.Show();
        }

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



    }
}
