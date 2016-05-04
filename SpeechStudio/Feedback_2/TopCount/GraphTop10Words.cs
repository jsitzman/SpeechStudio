using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCountsGraph
{
    class GraphTop10Words
    {
        public static void graphTop10Words(System.Windows.Forms.DataVisualization.Charting.Chart chart, List<string> top10Keys,
            List<Dictionary<string, int>> data)
        {
            for (uint i = 0; i < top10Keys.Count; i++)
            {
                string key = top10Keys.ElementAt((int)i);
                chart.Series["Speech"].Points.AddXY(key, data[0][key]);
                chart.Series["PowerPoint"].Points.AddY(data[1][key]);
            }
            chart.ChartAreas.ElementAt(0).AxisX.Interval = 1;
            chart.ChartAreas.ElementAt(0).AxisY.Interval = 2;
        }
    }
}
