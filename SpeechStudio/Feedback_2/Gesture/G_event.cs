using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback_2.Gesture
{
    class G_event
    {
        public string gesturename;
        public List<int> timeseries = null;

        public G_event(string a)
        {
            gesturename = a;
            timeseries = new List<int>();
        }

        public void add(int a)
        {
            timeseries.Add(a);
        }
    }
}
