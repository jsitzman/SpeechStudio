using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.UI;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using System.Windows.Forms;

namespace SpeechStudio
{
    class VAOutput
    {
        public static Dictionary<string, int> CreateCounterDictionary(int numberOfSlides, List<int> counts)
        {
            Dictionary<string, int> counterDictionary = new Dictionary<string, int>();
            if (counts.Count - 1 == numberOfSlides)
            {
                string slideNumber = "";
                for (int i = 0; i < numberOfSlides; i++)
                {
                    slideNumber = String.Format("Slide {0}", i + 1);
                    counterDictionary.Add(slideNumber, counts[i]);
                }
            }
            //System.Console.WriteLine("dictionary size: {0}", counterDictionary.Count);
            return counterDictionary;
        }
        /* 
            BEGIN OUTPUT TO CSV FILE
        */

        public static string makeCsvFileName(string reportPath)
        {

            return reportPath + "VAreport.csv";
        }

        public static void createCsvFile(string filePath)
        {
            try
            {
                // Delete the file if it exists.
                if (File.Exists(filePath))
                {
                    // Note that no lock is put on the
                    // file and the possibility exists
                    // that another process could do
                    // something with it between
                    // the calls to Exists and Delete.
                    File.Delete(filePath);
                }

                using (System.IO.FileStream fs = System.IO.File.Create(filePath))
                {
                    //blank
                }

                // Open the stream and read it back.
                /*
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
                */

            }
            catch (Exception ex)
            {
                string error = "Error 002: " + ex.ToString();
                MessageBox.Show(error, "Error");
            }
        }

        public static void writeToCsvFile(string filePath, List<Dictionary<string, int>> data)
        {
            string results = "";
            for (uint i = 0; i < data.Count; i++)
            {
                results += "###\n";
                for (uint j = 0; j < data[0].Count; j++)
                {
                    results += data[(int)i].ElementAt((int)j).Key.ToString() + ",";
                    results += data[(int)i].ElementAt((int)j).Value.ToString() + "\n";
                }
            }
            File.WriteAllText(filePath, results);
        }

        public static void generateCsvOutput(string reportPath, List<Dictionary<string, int>> data)
        {
            string csvFilePath = makeCsvFileName(reportPath);
            createCsvFile(csvFilePath);
            writeToCsvFile(csvFilePath, data);
        }

        /* 
            END OUTPUT TO CSV FILE
        */
        // ------------------------------------------------------------------------------------------------------------
        /*
            BEGIN OUTPUT TO FEEDBACK PANEL 
        */

        //outputs number of words per slide in graph form
        public static void testGraphOutput(System.Windows.Forms.DataVisualization.Charting.Chart chart, List<Dictionary<string, int>> data)
        {
            for (uint i = 0; i < data[0].Count; i++)
            {
                chart.Series["Word Count"].Points.AddXY(data[0].ElementAt((int)i).Key.ToString(), data[0].ElementAt((int)i).Value);
            }
        }

        /*
            END OUTPUT TO FEEDBACK PANEL 
        */
    }
}
