using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopCountsGraph
{
    class ReadABFiles
    {
        //A.txt is representative of the text version of the speech
        //B.txt is representative of the text of the visual aid
        private string speechText;
        private string visualText;
        private string outputPath;

        public string SpeechText
        {
            get { return speechText; }
            set { speechText = value; }
        }

        public string VisualText
        {
            get { return visualText; }
            set { visualText = value; }
        }

        public string OutputPath
        {
            get { return outputPath; }
            set { outputPath = value; }
        }

        public ReadABFiles()
        {
            //static outputPath for testing purposes, will need to be changed when integrated to program so that we can take in 
            //the path to the output of the Program. 
            //outputPath = @"C:\Users\Colt\Desktop\482Testing\topGraphsTest\";
            speechText = readAFile();
            visualText = readBFile();
        }

        //constructor for when we need to be able to push in the project's output path to this part of the code 
        public ReadABFiles(string projectPath)
        {
            outputPath = projectPath;
            speechText = readAFile();
            visualText = readBFile();
            
        }

        public string readAFile()
        {
            string aFile = outputPath + "\\SPword.txt";
            string text = "";
            if (System.IO.File.Exists(aFile))
            {
                //read the entire file contents as a single string
                text = System.IO.File.ReadAllText(aFile);
            }
            else
            {
                MessageBox.Show("Error 003: either a.txt does not exist or the path is not correct.", "Error");
            }
            // Display the file contents to the console. Variable text is a string.
            System.Console.WriteLine("Contents of a.txt = {0}", text);

            return text;
        }

        public string readBFile()
        {
            string bFile = outputPath + "\\VAword.txt";
            string text = "";
            if (System.IO.File.Exists(bFile))
            {
                //read the entire file contents as a single string
                text = System.IO.File.ReadAllText(bFile);
            }
            else
            {
                MessageBox.Show("Error 004: either b.txt does not exist or the path is not correct.", "Error");
            }
            // Display the file contents to the console. Variable text is a string.
            System.Console.WriteLine("Contents of b.txt = {0}", text);

            return text;
        }
    }
}
