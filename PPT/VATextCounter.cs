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
    class VATextCounter
    {
        /* 
        The following functions gather all text on all slides including the Title text 
        */

        public static void GetSlideIdAndText(out string sldText, string docName, int index)
        {
            using (PresentationDocument ppt = PresentationDocument.Open(docName, false))
            {
                // Get the relationship ID of the first slide.
                PresentationPart part = ppt.PresentationPart;
                OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

                string relId = (slideIds[index] as SlideId).RelationshipId;

                // Get the slide part from the relationship ID.
                SlidePart slide = (SlidePart)part.GetPartById(relId);

                // Build a StringBuilder object.
                StringBuilder paragraphText = new StringBuilder();

                // Get the inner text of the slide:
                IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();
                foreach (A.Text text in texts)
                {
                    paragraphText.Append(text.Text + "\n");
                }
                sldText = paragraphText.ToString();
            }
        }

        /*
        The following functions then parse and count the number of words of the slides. 
        */
        public static int CountWordsPerSlide(string slideText)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n', '-' };
            int wordCount = slideText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            return wordCount;
        }

        public static string[] pushWordsToArray(string slideText)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n', '-' };
            return slideText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
