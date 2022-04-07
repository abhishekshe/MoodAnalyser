using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserClass
    {
        private string message;
        public MoodAnalyserClass(string message)
        {
            this.message = message;
        }
        public MoodAnalyserClass()
        {

        }
        public string AnalyseMood()
        {
            if (this.message.Contains("Sad") || this.message.Contains("sad"))
            {
                return "SAD";
            }
            else
            {
                return "HAPPY";
            }
        }
    }

}