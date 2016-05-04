using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCountsGraph
{
    class GatherImportantWords
    {
        string[] nonImportantWords =
                {
                    ",", ".", "'", "\"", "?", ";", ":", "-", "\t", "\n", "\r", "[", "]", "(", ")",
                    "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " is ", " a ", " be ", " are ", " they ", " the ",
                    " this "," This "," That ", " that ", " with ", " then ", " thus ", " therefore ", " furthermore ", " additionally ",
                    " because ", " in ", " out ", " and ", " but ", " or ", " to ", " do ", " essentially ", " basically ",
                    " "," of "," these ", " those "," many ", " on ", " was ", " his "," her "," by "," become "," as ",
                };
        private string[] speechWords;
        private string[] visualWords;
        private string[] distinctVisualWords;
        private string[] distinctSpeechWords;
        private string[] intersectedWords;
        private List<string> top10speechWords;
        private List<string> top10visualWords;
        private Dictionary<string, int> countedSpeechWords;
        private Dictionary<string, int> countedVisualWords;

        public Dictionary<string, int> CountedSpeechWords
        {
            get { return countedSpeechWords; }
            set { }
        }
        public Dictionary<string, int> CountedVisualWords
        {
            get { return countedVisualWords; }
            set { }
        }

        public List<string> Top10speechWords
        {
            get { return top10speechWords; }
            set { }
        }

        public List<string> Top10visualWords
        {
            get { return top10visualWords; }
            set { }
        }

        public GatherImportantWords(string aText, string bText)
        {
            countedSpeechWords = new Dictionary<string, int>();
            countedVisualWords = new Dictionary<string, int>();
            top10speechWords = new List<string>();
            top10visualWords = new List<string>();
            speechWords = aText.Split(nonImportantWords, StringSplitOptions.RemoveEmptyEntries);
            visualWords = bText.Split(nonImportantWords, StringSplitOptions.RemoveEmptyEntries);
            distinctVisualWords = visualWords.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
            distinctSpeechWords = speechWords.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();

            //intersectedWords = distinctSpeechWords.Intersect(distinctVisualWords).ToArray();

            //foreach (string word in intersectedWords)
            //{
             // countedSpeechWords.Add(word, 0);
             // countedVisualWords.Add(word, 0);
            //}

            foreach (string word in distinctSpeechWords)
            {
                countedSpeechWords.Add(word, 0);
            }
            foreach (string word in distinctVisualWords)
            {
                countedVisualWords.Add(word, 0);
            }
        }

        //because getting top 10 from both sources, we could end up with 20 keys/values if all 10 top words are different between both sources
        public List<string> getTop10FromBothSources()
        {
            countSpeechWordsNonIntersected();
            countVisualWordsNonIntersected();

            IEnumerable<KeyValuePair<string, int>> orderedSpeechWords = orderTopSpeechWords();
            IEnumerable<KeyValuePair<string, int>> orderedVisualWords = orderTopVisualWords();

            top10speechWords = getTop10Keys(orderedSpeechWords);
            top10visualWords = getTop10Keys(orderedVisualWords);

            List<string> top10fromBoth = new List<string>();

            foreach (string key in top10speechWords)
            {
                top10fromBoth.Add(key);
            }
            foreach (string key in top10visualWords)
            {
                top10fromBoth.Add(key);
            }

            List<string> results = top10fromBoth.Distinct(StringComparer.OrdinalIgnoreCase).ToList();

            return results;
        }
        


        public List<string> listAndTakeTop10WordsFromBothSources()
        {
            countSpeechWords();
            countVisualWords();

            IEnumerable<KeyValuePair<string, int>> orderedSpeechWords = orderTopSpeechWords();
            IEnumerable<KeyValuePair<string, int>> orderedVisualWords = orderTopVisualWords();

            List<KeyValuePair<string, int>> disorderedCommonWords = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < intersectedWords.Length; i++)
            {
                int totalCount = orderedSpeechWords.ElementAt(i).Value + orderedVisualWords.ElementAt(i).Value;
                KeyValuePair<string, int> keyValuePair = new KeyValuePair<string, int>(orderedVisualWords.ElementAt(i).Key, totalCount);
                disorderedCommonWords.Add(keyValuePair);
            }

            IEnumerable<KeyValuePair<string, int>> orderedIntersectedWords = orderIntersectedWords(disorderedCommonWords);

            //now finally that we have a list of common words and their totals, take top 10 of them, and use for graphing
            List<string> top10Keys = getTop10Keys(orderedIntersectedWords);
            return top10Keys;
        }

        public List<string> getTop10Keys(IEnumerable<KeyValuePair<string, int>> orderedWords)
        {
            List<string> result = new List<string>();

            IEnumerable<KeyValuePair<string, int>> top10orderedWords = orderedWords.Reverse().Take(10);

            foreach (KeyValuePair<string, int> wordNcount in top10orderedWords)
            {
                result.Add(wordNcount.Key);
            }

            System.Console.WriteLine("\nTop 10 list of keys: ");
            foreach(string word in result)
            {
                System.Console.WriteLine(word);
            }

            return result;
        }

        public IEnumerable<KeyValuePair<string, int>> orderIntersectedWords(List<KeyValuePair<string, int>> disorderedWords)
        {
            IEnumerable<KeyValuePair<string, int>> orderedWords = disorderedWords.OrderBy(word => word.Value).ThenBy(word => word.Key);
            System.Console.WriteLine("\norder Intersected Words");
            foreach (KeyValuePair<string, int> wordNcount in orderedWords)
            {
                System.Console.WriteLine("Word: {0}, Count: {1}", wordNcount.Key, wordNcount.Value);
            }

            return orderedWords;
        }

        //The counting and ordering methods of the Speech words starts here
        public void countSpeechWords()
        {
            foreach (string word in intersectedWords)
            {
                foreach(string s in speechWords)
                {
                    if (word.Equals(s))
                    {
                        countedSpeechWords[word] += 1;
                    }
                }
            }
        }

        public void countSpeechWordsNonIntersected()
        {
            foreach (string word in distinctSpeechWords)
            {
                foreach (string s in speechWords)
                {
                    if (word.Equals(s))
                    {
                        countedSpeechWords[word] += 1;
                    }
                }
            }
        }

        public IEnumerable<KeyValuePair<string, int>> orderTopSpeechWords()
        {
            List<KeyValuePair<string, int>> listSpeechWords = countedSpeechWords.ToList();

            IEnumerable<KeyValuePair<string, int>> orderedSpeechWords = listSpeechWords.OrderBy(word => word.Value).ThenBy(word => word.Key);
            System.Console.WriteLine("\norder Speech Words");
            foreach (KeyValuePair<string, int> wordNcount in orderedSpeechWords)
            {
                System.Console.WriteLine("Word: {0}, Count: {1}", wordNcount.Key, wordNcount.Value);
            }

            return orderedSpeechWords;
        }
        //end speechWord counting

        //The counting and ordering methods of the Visual Aids words starts here
        public void countVisualWords()
        {
            foreach (string word in intersectedWords)
            {
                foreach(string v in visualWords)
                {
                    if (word.Equals(v))
                    {
                        countedVisualWords[word] += 1;
                    }
                }
            }
        }

        public void countVisualWordsNonIntersected()
        {
            foreach (string word in distinctVisualWords)
            {
                foreach (string v in visualWords)
                {
                    if (word.Equals(v))
                    {
                        countedVisualWords[word] += 1;
                    }
                }
            }
        }

        public IEnumerable<KeyValuePair<string, int>> orderTopVisualWords()
        {
            List<KeyValuePair<string, int>> listVisualWords = countedVisualWords.ToList();
            System.Console.WriteLine("\norder Visual Words");
            IEnumerable<KeyValuePair<string, int>> orderedVisualWords = listVisualWords.OrderBy(word => word.Value).ThenBy(word => word.Key);

            foreach (KeyValuePair<string, int> wordNcount in orderedVisualWords)
            {
                System.Console.WriteLine("Word: {0}, Count: {1}", wordNcount.Key, wordNcount.Value);
            }

            return orderedVisualWords;
        }
        //end visualWord counting

        //this is for testing purposes primarily :P 
        public void printImportantWords()
        {
            System.Console.WriteLine("Speech Important Words:");
            foreach (string word in speechWords)
            {
                System.Console.WriteLine(word);
            }
            System.Console.WriteLine();

            System.Console.WriteLine("Visual Important Words:");
            foreach (string word in visualWords)
            {
                System.Console.WriteLine(word);
            }
        }
    }
}
