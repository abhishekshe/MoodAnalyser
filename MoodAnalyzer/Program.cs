using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               Console.WriteLine("Welcome to Mood Analyser Problem");

              
                MoodAnalyserClass moodAnalyserClass1 = (MoodAnalyserClass)MoodAnalyserFactory.GetFieldForMoodAnalysis("HAPPY", "message");
                string moodOutput1 = moodAnalyserClass1.AnalyseMood();
                Console.WriteLine(moodOutput1);
                //field from mood analyser factory is called and passed to parametrized object in mood analyser factory.
                object moodAnalyserClass2 = MoodAnalyserFactory.CreateMoodAnalyseObjectUsingParamaterizedConstructor("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass", "happy");
                // object is converted into instance of mood analyser class.
                MoodAnalyserClass mood = (MoodAnalyserClass)moodAnalyserClass2;
                //Analyse method method is called using class.
                string moodOutput = mood.AnalyseMood();
                Console.WriteLine(moodOutput);

                // creating a object with default constructor in mood analyser factory using reflection
                object moodAnalyserClass3 = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass");

                //Directly calling method class from Mood analyser factory using reflection.
                string moodOutput2 = MoodAnalyserFactory.InvokeAnalyserMethod("happy", "AnalyseMood");
                Console.WriteLine(moodOutput2);
            }
            catch (MoodAnalyserCustomException ex)
            {
                Console.WriteLine(ex.GetType().Name + ex.Message);
                //Console.WriteLine(ex);

            }

        }
    }
}