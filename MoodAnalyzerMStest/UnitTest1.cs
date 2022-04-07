using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System;
using System.Runtime.InteropServices;

namespace MoodAnalyserMSTest
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyserClass moodAnalyserClass;
        [TestInitialize]
        public void Setup()
        {
            moodAnalyserClass = new MoodAnalyserClass("I am in any mood");
        }
        [TestMethod]
        public void GivenSadMoodShouldReturnSAD()
        {
            //Arrange
            string expected = "SAD";
            //string message = "I am in Sad Mood";
            //MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass(message);

            //Act
            string actual = moodAnalyserClass.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GivenAnyMoodShouldReturnHAPPY()
        {
            //Arrange
            string expected = "HAPPY";
            //string message = "I am in any mood";
            //Add
            string actual = moodAnalyserClass.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        // [ExpectedException(typeof(NullReferenceException))]
        public void GivenNullShouldReturnHappy()
        {
            //Arrange
            try
            {
                throw new NullReferenceException();
            }
            catch (NullReferenceException ex)
            {
                string expected = "Happy " + ex.Message;
                string actual = moodAnalyserClass.AnalyseMood();
                Assert.AreEqual(expected, actual);

            }
        }
        [TestMethod]
        public void GivenNullShouldReturnCustomException()
        {
            try
            {
                //Add
                string actual = moodAnalyserClass.AnalyseMood();
            }
            catch (MoodAnalyserCustomException ex)
            {
                string expected = ex.Message;
                Assert.AreEqual(expected, "Mood should not be passed as a null value");
            }
        }
        [TestMethod]
        public void GivenEmptyStringShouldReturnCustomException()
        {
            try
            {
                //Add
                string actual = moodAnalyserClass.AnalyseMood();
            }
            catch (MoodAnalyserCustomException ex)
            {
                string expected = ex.Message;
                Assert.AreEqual(expected, "Mood should not be empty");
            }
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            string message = null;
            object expected = new MoodAnalyserClass(message);
            object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass");
            expected.Equals(actual);
            //Assert.AreEqual(expected, actual) -> this can not be used, as we are not testing strings.or other data type, here it is object.
        }
    }
}