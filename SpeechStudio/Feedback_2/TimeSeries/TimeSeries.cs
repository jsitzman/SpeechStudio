using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback_2.TimeSeries
{
    class TimeSeries
    {
        public int time;
        public string events;
        public TimeSeries(int a, string b) {
            time = a;
            events = b;
        }
    }
}
