using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback_2.TimeSeries
{
    class ReadTimeSeries
    {
        public List<int> Smile = new List<int>();
        public List<int> Speak = new List<int>();
        public List<int> Pause = new List<int>();
        public List<int> Lookaway = new List<int>();
        private bool smile = false;
        private bool speak = false;
        private bool pause = false;
        private bool lookaway = false;
        
        public ReadTimeSeries(string path) {
            String text = System.IO.File.ReadAllText(path);
            List<string> Series = text.Split(',').ToList();
            foreach (string item in Series) {
                if (item == "smile")
                {
                    smile = true;
                    speak = false;
                    pause = false;
                    lookaway = false;
                    continue;
                }
                else if (item == "speak")
                {
                    smile = false;
                    speak = true;
                    pause = false;
                    lookaway = false;
                    continue;
                }
                else if (item == "pause")
                {
                    smile = false;
                    speak = false;
                    pause = true;
                    lookaway = false;
                    continue;
                }
                else if (item == "lookaway")
                {
                    smile = false;
                    speak = false;
                    pause = false;
                    lookaway = true;
                    continue;
                }

                if (smile == true)
                {
                    int m = Int32.Parse(item);
                    if (m == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Smile.Add(m);
                    }
                }
                else if (speak == true) {
                    int m = Int32.Parse(item);
                    if (m == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Speak.Add(m);
                    }                    
                }
                else if (pause == true)
                {
                    
                    int m = Int32.Parse(item);
                    if (m == 0) {
                        continue;
                    }
                    else{
                        Pause.Add(m);
                    }                    
                }
                else if (lookaway == true)
                {
                    int m = Int32.Parse(item);
                    if (m == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Lookaway.Add(m);
                    }

                    
                }
            }            
        }
    }
}
