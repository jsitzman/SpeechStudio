using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback_2
{
    class ReadData
    {
        public List<int> slide_number = new List<int>();
        public List<int> SecPerSlide = new List<int>();
        public List<int> GesturePerSlide = new List<int>();
        public List<int> SmilePerSlide = new List<int>();
        public List<int> LookAwayPerSlide = new List<int>();
        public List<int> WordPerSlide = new List<int>();
        public List<int> PausePerSlide = new List<int>();

        public int data_count_slide = 0;


       
        public ReadData()
        {
            
        }

        public void read_data(string path)
        {
            List<List<string>> overall = new List<List<string>>();
            StreamReader a = new StreamReader(path);
            String line;
            while ((line = a.ReadLine()) != null)
            {
                List<string> input_list = line.Split(',').ToList();
                overall.Add(input_list);
            }

            foreach (List<string> lists in overall)
            {
                if (lists[0] == "S_N")
                {
                    data_count_slide++;
                    for (int i = 1; i < lists.Count; i++)
                    {
                        int m = Int32.Parse(lists[i]);
                        this.slide_number.Add(m);
                    }
                }

                if (lists[0] == "TPS")
                {
                    data_count_slide++;
                    for (int i = 1; i < lists.Count; i++)
                    {
                        int m = Int32.Parse(lists[i]);
                        this.SecPerSlide.Add(m);
                    }
                }

                if (lists[0] == "GPS")
                {
                    data_count_slide++;
                    for (int i = 1; i < lists.Count; i++)
                    {
                        int m = Int32.Parse(lists[i]);
                        this.GesturePerSlide.Add(m);
                    }
                }

                if (lists[0] == "SPS")
                {
                    data_count_slide++;
                    for (int i = 1; i < lists.Count; i++)
                    {
                        int m = Int32.Parse(lists[i]);
                        this.SmilePerSlide.Add(m);
                    }
                }

                if (lists[0] == "LPS")
                {
                    data_count_slide++;
                    for (int i = 1; i < lists.Count; i++)
                    {
                        int m = Int32.Parse(lists[i]);
                        this.LookAwayPerSlide.Add(m);
                    }
                }

                if (lists[0] == "WPS")
                {
                    data_count_slide++;
                    for (int i = 1; i < lists.Count; i++)
                    {
                        int m = Int32.Parse(lists[i]);
                        this.WordPerSlide.Add(m);
                    }
                }

                if (lists[0] == "PPS")
                {
                    data_count_slide++;
                    for (int i = 1; i < lists.Count ; i++)
                    {
                        int m = Int32.Parse(lists[i]);
                        this.PausePerSlide.Add(m);
                    }
                }
            }
        }
    }
}
