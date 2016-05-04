using Feedback_2.TimeSeries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TopCountsGraph;
using Feedback_2.Gesture;
using System.IO;
//using SpeechStudio;

namespace Feedback_2
{
    public partial class main_feedback : Form
    {
        ReadData dataset = new ReadData();

        ReadABFiles readABFiles = null;
        ReadTimeSeries events = null;
        ReadG_event readgestures = null;

        StreamWriter notewriter = null;

        private string folder = null;
        private string datas = null;
        private string video = null;
        private string text1 = null;
        private string text2 = null;
        private string event1 = null;
        private string gesture1 = null;
        private string notes = null;

        private List<string> notelist = new List<string>();

        public main_feedback(string solution)
        {        
            folder = solution;
            readABFiles = new ReadABFiles(folder);
            text1 = readABFiles.SpeechText;
            text2 = readABFiles.VisualText;
            datas = folder + "\\slide.txt";
            event1 = folder + "\\time.txt";
            gesture1 = folder + "\\gesture.txt";
            video = folder + "\\video.mp4";
            notes = folder + "\\notes.txt";  
            readgestures = new ReadG_event(gesture1);
            InitializeComponent();
        }

       


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (notewriter != null) {
                notewriter.Close();
            }            
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }

        private void main_feedback_Load(object sender, EventArgs e)
        {
            dataset.read_data(datas);
            events = new ReadTimeSeries(event1);
            display_slides();
            for (int i = 0; i < Slide_CheckList.Items.Count; i++) {
                Slide_CheckList.SetItemCheckState(i, CheckState.Checked);                
            }
            display_TopCount();
            display_pie();
            display_Time();
            display_gesture();
            display_fillerWords();
            display_video();
        }

        private void display_video() {
            if (File.Exists(video) == false)
            {
                ADD_Button.Enabled = false;
            }
            else {
                pbvideo.URL = video;
                //pbvideo.Ctlcontrols.stop();
                if (File.Exists(notes) == true)
                {
                    StreamReader notefile = new StreamReader(notes);
                    string line = null;
                    while ((line = notefile.ReadLine()) != null)
                    {
                        notelist.Add(line);
                    }
                    if(notelist != null)
                    {
                        foreach(string item in notelist)
                        {
                            CommentList.Items.Add(item);
                        }                        
                    }
                    notefile.Close();

                    notewriter = new StreamWriter(notes);
                                       
                }
                else {
                    notewriter = new StreamWriter(notes);
                }
            }
        }




        private void display_gesture() {
            int value = 5;
            foreach (G_event item in readgestures.eventlist) {
                Time_chart.Series.Add(item.gesturename);
                Time_check.Items.Add(item.gesturename,true);
                foreach (int data in item.timeseries)
                {
                    Time_chart.Series[item.gesturename].Points.AddXY(data, value);
                }
                Time_chart.Series[item.gesturename].ChartType = SeriesChartType.Point;
            }
        }



        private void display_Time() {
            Time_chart.Series[0].Enabled = false;
            Time_chart.ChartAreas.ElementAt(0).AxisY.Interval = 1;
            if (events.Speak != null) {
                Time_chart.Series.Add("SPEAK");
                foreach (int item in events.Speak) {
                        Time_chart.Series["SPEAK"].Points.AddXY(item, 1);
                }            
                Time_chart.Series["SPEAK"].ChartType = SeriesChartType.Point;
            }

            if (events.Pause != null) {
                Time_chart.Series.Add("PAUSE");
                foreach (int item in events.Pause)
                {
                     Time_chart.Series["PAUSE"].Points.AddXY(item, 2);
                }
                Time_chart.Series["PAUSE"].ChartType = SeriesChartType.Point;
            }
            
            if (events.Smile != null) {
                Time_chart.Series.Add("SMILE");
                foreach (int item in events.Smile)
                {
                    Time_chart.Series["SMILE"].Points.AddXY(item, 3);
                }
                Time_chart.Series["SMILE"].ChartType = SeriesChartType.Point;
            }

            if (events.Lookaway != null)
            {
                Time_chart.Series.Add("Look Away");
                foreach (int item in events.Lookaway)
                {
                    Time_chart.Series["Look Away"].Points.AddXY(item, 4);
                }
                Time_chart.Series["Look Away"].ChartType = SeriesChartType.Point;
            }

        }



        private void display_TopCount()
        {
            GatherImportantWords gatherImportantWords = new GatherImportantWords(text1, text2);
            //gatherImportantWords.printImportantWords();
            List<string> top10Keys = gatherImportantWords.getTop10FromBothSources();
            List<string> top10visual = gatherImportantWords.Top10visualWords;
            List<string> top10speech = gatherImportantWords.Top10speechWords;

            List<Dictionary<string, int>> data = new List<Dictionary<string, int>>();
            data.Add(gatherImportantWords.CountedSpeechWords);
            data.Add(gatherImportantWords.CountedVisualWords);

            TopCount.Series[0].Name = "Speech";
            TopCount.Series["Speech"].ChartType = SeriesChartType.Column;
            TopCount.Series["Speech"].Color = Color.FromArgb(69, 115, 167);

            if (gatherImportantWords.CountedVisualWords.Count != 0)
            {
                TopCount.Series.Add("PowerPoint");
                TopCount.Series["PowerPoint"].ChartType = SeriesChartType.Column;
                TopCount.Series["PowerPoint"].Color = Color.FromArgb(169, 69, 67);
            }
            for (uint i = 0; i < top10Keys.Count; i++)
            {
                string key = top10Keys.ElementAt((int)i);
                if (top10speech.Contains(key) && top10visual.Contains(key))
                {
                    TopCount.Series["Speech"].Points.AddXY(key, data[0][key]);
                    TopCount.Series["PowerPoint"].Points.AddY(data[1][key]);
                }
                else if (top10speech.Contains(key) && !top10visual.Contains(key))
                {
                    TopCount.Series["Speech"].Points.AddXY(key, data[0][key]);
                    TopCount.Series["PowerPoint"].Points.AddY(0);
                }
                else if (!top10speech.Contains(key) && top10visual.Contains(key))
                {
                    TopCount.Series["Speech"].Points.AddXY(key, 0);
                    TopCount.Series["PowerPoint"].Points.AddY(data[1][key]);
                }
            }
            TopCount.ChartAreas.ElementAt(0).AxisX.Interval = 1;
            TopCount.ChartAreas.ElementAt(0).AxisY.Interval = 2;
        }


        private void display_pie() {
            if (dataset.SecPerSlide != null)
            {
                Pie_1.Series[0].ChartType = SeriesChartType.Pie;
                Pie_1.Series[0].Points.DataBindXY(dataset.slide_number, dataset.SecPerSlide);
                Pie_1.Series[0].IsVisibleInLegend = true;           
                Pie_1.Series[0].Label = "Slide #VALX (#PERCENT)";
            }
        }

//display slides
        private void display_slides() {
            int datanumber = 0;
            Slide_Chart.Series[0].Enabled = false;
            if (dataset.GesturePerSlide != null)
            {
                Slide_Chart.Series.Add("Gesture Per Slide");
                Slide_Chart.Series["Gesture Per Slide"].ChartType = SeriesChartType.Column;
                Slide_Chart.Series["Gesture Per Slide"].Points.DataBindXY(dataset.slide_number, dataset.GesturePerSlide);
                Slide_Chart.Series["Gesture Per Slide"].IsVisibleInLegend = true;                
                Slide_Chart.Series["Gesture Per Slide"].Color = Color.FromArgb(69, 115, 167);
                Slide_CheckList.Items.Add("Gesture Per Slide");                
                datanumber++;
            }
            if (dataset.WordPerSlide != null)
            {
                Slide_Chart.Series.Add("Word Per Slide");
                Slide_Chart.Series["Word Per Slide"].ChartType = SeriesChartType.Column;
                Slide_Chart.Series["Word Per Slide"].Points.DataBindXY(dataset.slide_number, dataset.WordPerSlide);
                Slide_Chart.Series["Word Per Slide"].IsVisibleInLegend = true;
                Slide_Chart.Series["Word Per Slide"].Color = Color.FromArgb(169, 69, 67);
                Slide_CheckList.Items.Add("Word Per Slide");
                datanumber++;
            }
            if (dataset.SmilePerSlide != null)
            {
                Slide_Chart.Series.Add("Smile Per Slide");
                Slide_Chart.Series["Smile Per Slide"].ChartType = SeriesChartType.Column;
                Slide_Chart.Series["Smile Per Slide"].Points.DataBindXY(dataset.slide_number, dataset.SmilePerSlide);
                Slide_Chart.Series["Smile Per Slide"].IsVisibleInLegend = true;
                Slide_Chart.Series["Smile Per Slide"].Color = Color.FromArgb(137, 165, 78);
                Slide_CheckList.Items.Add("Smile Per Slide");
                datanumber++;
            }
            if (dataset.LookAwayPerSlide != null)
            {
                Slide_Chart.Series.Add("LookAway Per Slide");
                Slide_Chart.Series["LookAway Per Slide"].ChartType = SeriesChartType.Column;
                Slide_Chart.Series["LookAway Per Slide"].Points.DataBindXY(dataset.slide_number, dataset.LookAwayPerSlide);
                Slide_Chart.Series["LookAway Per Slide"].IsVisibleInLegend = true;
                Slide_Chart.Series["LookAway Per Slide"].Color = Color.FromArgb(113, 88, 143);
                Slide_CheckList.Items.Add("LookAway Per Slide");
                datanumber++;
            }
            if (dataset.PausePerSlide != null)
            {
                Slide_Chart.Series.Add("Pause Per Slide");
                Slide_Chart.Series["Pause Per Slide"].ChartType = SeriesChartType.Column;
                Slide_Chart.Series["Pause Per Slide"].Points.DataBindXY(dataset.slide_number, dataset.PausePerSlide);
                Slide_Chart.Series["Pause Per Slide"].IsVisibleInLegend = true;
                Slide_Chart.Series["Pause Per Slide"].Color = Color.Red;
                Slide_CheckList.Items.Add("Pause Per Slide");
                datanumber++;
            }

        }

        private void display_fillerWords()
        {
            string[] deliminters = { ",", ".", "'", "\"", "?", ";", ":", "-", "\t", "\n", "\r", "[", "]", "(", ")", " " };
            int um_count = 0, uh_count = 0, erm_count = 0, huh_count = 0, hm_count = 0;
            if(text1 != null)
            {
                string[] filterWords = text1.Split(deliminters, StringSplitOptions.RemoveEmptyEntries);
                for(int i = 0; i < filterWords.Length; i++)
                {
                    switch(filterWords[i])
                    {
                        case "um":
                        case "Um":
                            um_count++;
                            break;
                        case "uh":
                        case "Uh":
                            uh_count++;
                            break;
                        case "erm":
                        case "Erm":
                            erm_count++;
                            break;
                        case "huh":
                        case "Huh":
                            huh_count++;
                            break;
                        case "hm":
                        case "Hm":
                            hm_count++;
                            break;
                    }
                }
                chart1.Series[0].Name = "Um's";
                chart1.Series.Add("Uh's");
                chart1.Series.Add("Erm's");
                chart1.Series.Add("Huh's");
                chart1.Series.Add("Hm's");

                chart1.Series[0].ChartType = SeriesChartType.Column;
                chart1.Series[0].Points.AddXY(1, um_count);
                chart1.Series[0].Points.AddXY(2, uh_count);
                chart1.Series[0].Points.AddXY(3, erm_count);
                chart1.Series[0].Points.AddXY(4, huh_count);
                chart1.Series[0].Points.AddXY(5, hm_count);

                chart1.Series[0].Points[0].Color = Color.FromArgb(69, 115, 167);
                chart1.Series[0].Points[1].Color = Color.FromArgb(169, 69, 67);
                chart1.Series[0].Points[2].Color = Color.FromArgb(137, 165, 78);
                chart1.Series[0].Points[3].Color = Color.FromArgb(113, 88, 143);
                chart1.Series[0].Points[4].Color = Color.FromArgb(66, 152, 175);

                chart1.Series[0].Points[0].AxisLabel = "Um";
                chart1.Series[0].Points[1].AxisLabel = "Uh";
                chart1.Series[0].Points[2].AxisLabel = "Erm";
                chart1.Series[0].Points[3].AxisLabel = "Huh";
                chart1.Series[0].Points[4].AxisLabel = "Hm";
            }
        }

        private void Slide_CheckList_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Slide_Chart.Series.Count; i++)
            {
                Slide_Chart.Series[i].Enabled = false;
            }
            foreach (string item in Slide_CheckList.CheckedItems)
            {
                Slide_Chart.Series[item].Enabled = true;
            }
        }

        private void Time_check_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (G_event item in readgestures.eventlist)
            {
                Time_chart.Series[item.gesturename].Enabled = false;
            }
            foreach (string item in Time_check.CheckedItems)
            {
                Time_chart.Series[item].Enabled = true;
            }
        }

        private void file_LoadProject_Click(object sender, EventArgs e)
        {
            if (open_loading.ShowDialog() == DialogResult.OK)
            {
                main_feedback a = new main_feedback(open_loading.SelectedPath);
                a.Show();
               // this.Hide();
            }
        }

        private void file_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Time_check_ItemCheck(object sender, ItemCheckEventArgs e)
        {
           
        }

        private void Slide_CheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void ADD_Button_Click(object sender, EventArgs e)
        {
            string input = comment_input.Text.ToString();
            string time = pbvideo.Ctlcontrols.currentPositionString;
            string result = time + " " + input;
            notelist.Add(result);
            CommentList.Items.Add(result);
            notewriter.WriteLine(result);
        }
    }
}
