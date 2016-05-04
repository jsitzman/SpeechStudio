using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeechStudio
{
    public partial class OutputDraft : Form
    {
        private VACounterController counterController;

        public OutputDraft(string pptPath, string rootTarget)
        {
            InitializeComponent();
            counterController = new VACounterController();

            // Assign the presentation in the Stream to the presentation used by all counter classes
            // from the CounterController class
            counterController.openPresentationDocument(pptPath);

            //send to excel and possibly produce a graph from the data and then open excel graph
            if (counterController.getPresentationDocument() != null)
            {
                //run the different types of counters
                string results = counterController.runTextCounter();
                results += counterController.runChartCounter();
                results += counterController.runImageCounter();

                //take information from counters and display in graph form
                counterController.generateOutput(this.chart1, rootTarget);
            }
            else
            {
                MessageBox.Show("Error 001: Please import a presentation or load previous results before we can help you display any analysis.", "Error");
            }
        }
    }
}
