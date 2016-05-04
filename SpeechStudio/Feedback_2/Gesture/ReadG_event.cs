using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback_2.Gesture
{
    class ReadG_event
    {
        public List<G_event> eventlist = null;
        System.IO.StreamReader gesturereader = null;
        List<string> input = new List<string>();

        public ReadG_event(string filename)
        {
            eventlist = new List<G_event>();
            gesturereader = new System.IO.StreamReader(filename);
            string line;
            while ((line = gesturereader.ReadLine()) != null)
            {
                if (line == "") {
                    continue;
                }
                input = line.Split(',').ToList();
                int m = Int32.Parse(input[0]);
                string n = input[1];
                if (eventlist == null)
                {
                    G_event newgesture = new G_event(n);
                    newgesture.add(m);
                    eventlist.Add(newgesture);
                }
                else
                {
                    bool exsit = false;
                    foreach (G_event item in eventlist)
                    {
                        if (item.gesturename == n)
                        {
                            item.add(m);
                            exsit = true;
                        }
                    }
                    if (exsit == false)
                    {
                        G_event newgesture = new G_event(n);
                        newgesture.add(m);
                        eventlist.Add(newgesture);
                    }
                }
            }
        }
    }
}
