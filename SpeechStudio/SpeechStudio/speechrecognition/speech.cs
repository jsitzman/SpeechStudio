using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using Microsoft.ProjectOxford.SpeechRecognition;
using System.IO.IsolatedStorage;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Threading;

namespace SpeechStudio.speechrecognition
{
    class speech
    {
        
        public bool ends= true;
        string _subscriptionKey;
        string _recoLanguage = "en-us";
        MainWindow mainwindow = null;
        private MicrophoneRecognitionClient _micClient;
        private AutoResetEvent _FinalResponseEvent;

        public string SubscriptionKey
        {
            get
            {
                return _subscriptionKey;
            }
            set
            {
                _subscriptionKey = value;
            }
        }

        public speech(MainWindow main)
        {
            mainwindow = main;
            Intialize();
            _FinalResponseEvent = new AutoResetEvent(false);
        }
        private void Intialize()
        {
            SubscriptionKey = "b6a9a94e80a24d00825926c4544de104";
        }

        public void start()
        {
            // commentwriter = new StreamWriter(filename);
            if (_micClient == null)
            {
                _micClient = CreateMicrophoneRecoClient(SpeechRecognitionMode.LongDictation, _recoLanguage, "b6a9a94e80a24d00825926c4544de104");
            }
            _micClient.StartMicAndRecognition();
        }

        MicrophoneRecognitionClient CreateMicrophoneRecoClient(SpeechRecognitionMode recoMode, string language, string subscriptionKey)
        {
            MicrophoneRecognitionClient micClient = SpeechRecognitionServiceFactory.CreateMicrophoneClient(
                    recoMode,
                    language,
                    subscriptionKey);
            // Event handlers for speech recognition results
            if (recoMode == SpeechRecognitionMode.LongDictation)
            {
                micClient.OnResponseReceived += OnMicDictationResponseReceivedHandler;               
            }
            return micClient;
        }



        void OnMicDictationResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            WriteResponseResult(e);
            if (e.PhraseResponse.RecognitionStatus == RecognitionStatus.EndOfDictation ||
                e.PhraseResponse.RecognitionStatus == RecognitionStatus.DictationEndSilenceTimeout)
            {
                ends = true;
            }
        }

        public void end()
        {
            _FinalResponseEvent.Set();
            _micClient.EndMicAndRecognition();
            _micClient.Dispose();
            _micClient = null;
       }

        private void WriteResponseResult(SpeechResponseEventArgs e)
        {
            if (e.PhraseResponse.Results.Length == 0)
            {
                
            }
            else
            {
                ends = false;
                string a = e.PhraseResponse.Results[0].DisplayText;
                mainwindow.writetospeech(a);
            }
        }
    }
}
