using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;
using A = DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;


namespace SpeechStudio
{
    class VACounterController
    {
        private PresentationDocument presentationDocument;
        private string presentationPath;
        private List<int> textCountList;
        private List<int> chartCountList;
        private List<int> imageCountList;
        private int numberOfSlides;

        public VACounterController()
        {
            this.presentationPath = "";
            this.numberOfSlides = 0;
            this.textCountList = new List<int>();
            this.chartCountList = new List<int>();
            this.imageCountList = new List<int>();
        }

        //helper function to open up the power point selected in OpenDialogue Form 
        public void openPresentationDocument(string path)
        {
            this.presentationPath = path;
            this.presentationDocument = PresentationDocument.Open(presentationPath, false);
        }
        //helper to close the power point
        public void closePresentationDocument()
        {
            this.presentationDocument.Close();
        }
        //helper to access the presentation outside of this class
        public PresentationDocument getPresentationDocument()
        {
            return this.presentationDocument;
        }
        public string getPresentationFileName()
        {
            return this.presentationPath;
        }

        public static int CountSlides(string presentationFile)
        {
            // Open the presentation as read-only.
            using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))
            {
                // Pass the presentation to the next CountSlides method
                // and return the slide count.
                return CountSlides(presentationDocument);
            }
        }

        // Count the slides in the presentation.
        public static int CountSlides(PresentationDocument presentationDocument)
        {
            // Check for a null document object.
            if (presentationDocument == null)
            {
                throw new ArgumentNullException("presentationDocument");
            }

            int slidesCount = 0;

            // Get the presentation part of document.
            PresentationPart presentationPart = presentationDocument.PresentationPart;
            // Get the slide count from the SlideParts.
            if (presentationPart != null)
            {
                slidesCount = presentationPart.SlideParts.Count();
            }
            // Return the slide count to the previous method.
            return slidesCount;
        }

        //helper to execute the counters

        //text counter
        public string runTextCounter()
        {
            string result = "";
            string file = this.presentationPath;
            this.numberOfSlides = CountSlides(file);
            result += String.Format("Number of slides = {0}", numberOfSlides);
            string slideText;
            int wordCount = 0;
            int totalWordCount = 0;
            for (int i = 0; i < this.numberOfSlides; i++)
            {
                VATextCounter.GetSlideIdAndText(out slideText, file, i);
                wordCount = VATextCounter.CountWordsPerSlide(slideText);
                totalWordCount += wordCount;
                result += String.Format("Slide {0}, {1}", i + 1, slideText);
                result += String.Format("Slide {0}, {1}", i + 1, wordCount);
                this.textCountList.Add(wordCount);
            }
            result += String.Format("Total word count across all slides: {0}\n", totalWordCount);
            this.textCountList.Add(totalWordCount);
            return result;
        }

        public string runChartCounter()
        {
            string result = "";
            string file = this.presentationPath;
            int chartCount = 0;
            int totalChartCount = 0;
            for (int i = 0; i < this.numberOfSlides; i++)
            {
                chartCount = VAChartCounter.CountChartsPerSlide(file, i);
                totalChartCount += chartCount;
                result += String.Format("Slide #{0} contains this many Charts: {1}\n", i + 1, chartCount);
                this.chartCountList.Add(chartCount);
            }
            result += String.Format("Total Chart count across all slides: {0}\n", totalChartCount);
            this.chartCountList.Add(totalChartCount);
            return result;
        }

        public string runImageCounter()
        {
            string result = "";
            string file = this.presentationPath;
            int imageCount = 0;
            int totalImageCount = 0;
            for (int i = 0; i < this.numberOfSlides; i++)
            {
                imageCount = VAImageCounter.CountImagesPerSlide(file, i);
                totalImageCount += imageCount;
                result += String.Format("Slide #{0} contains this many Images: {1}\n", i + 1, imageCount);
                this.imageCountList.Add(imageCount);
            }
            result += String.Format("Total Image count across all slides: {0}\n", totalImageCount);
            this.imageCountList.Add(totalImageCount);
            return result;
        }

        public void generateOutput(System.Windows.Forms.DataVisualization.Charting.Chart chart, string reportPath)
        {
            //create each of the dictionaries (which should all have the same length = to number of slides)
            Dictionary<string, int> textData = VAOutput.CreateCounterDictionary(this.numberOfSlides, this.textCountList);
            Dictionary<string, int> chartData = VAOutput.CreateCounterDictionary(this.numberOfSlides, this.chartCountList);
            Dictionary<string, int> imageData = VAOutput.CreateCounterDictionary(this.numberOfSlides, this.imageCountList);

            //create a list of those dictionaries to feed to the output class
            List<Dictionary<string, int>> data = new List<Dictionary<string, int>>();
            data.Add(textData);
            data.Add(chartData);
            data.Add(imageData);

            //output the data from the dictionaries to graphic form
            VAOutput.generateCsvOutput(reportPath, data);
            VAOutput.testGraphOutput(chart, data);
        }
    }
}
