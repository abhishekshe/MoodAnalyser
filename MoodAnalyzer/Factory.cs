using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Linq.Expressions;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            Type type = typeof(MoodAnalyserClass);
            if (type.FullName.Equals(className) || type.Name.Equals(className))
            {
                string pattern = @"." + constructorName + "$";
                Match result = Regex.Match(className, pattern);
                if (result.Success)
                {

                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "No constructor found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "No class found");
            }
        }
        public static object CreateMoodAnalyseObjectUsingParamaterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyserClass);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    /*ConstructorInfo construct = type.GetConstructor(new[] { typeof(string) });
                    object objects = construct.Invoke(new object[] { message });
                    return objects;*/
                    Assembly Executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = Executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType, message);
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
                }

            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "class not found");
            }
        }
        public static string InvokeAnalyserMethod(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyser.MoodAnalyserClass");
                MethodInfo methodInfo = type.GetMethod(methodName);
                object moodAnalyserObject = CreateMoodAnalyseObjectUsingParamaterizedConstructor("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass", message);
                object AnalyseMood = methodInfo.Invoke(moodAnalyserObject, null);
                return AnalyseMood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "method not found");
            }

        }
    }
}
