using Neoris.Ionleap.CrossCutting.Logging.Types;
using Neoris.Ionleap.CrossCutting.Utils.Date;
using Neoris.Ionleap.CrossCutting.Utils.IO;
using Neoris.Ionleap.CrossCutting.Utils.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Neoris.Ionleap.CrossCutting.Logging
{
    //FIXME: Make a better Logging class, Add ProjectName in logfile to identify layer name
    public class Logger
    {
        private static readonly DateTime CurrentDateTime;
        private static readonly string LogDirectory;
        private static string _module = "";

        public static string Filename => $"{Paths.CurrentDirectory + LogDirectory}/{_module}_{CurrentDateTime.ToString(Culture.FileDateFormat)}.json";

        static Logger()
        {
            CurrentDateTime = DateTimeManager.ApplicationServerDateTime;
            LogDirectory = ".logs/";
        }

        public static void Write(String message)
        {
            try
            {
                string objectSerialized = JsonSerializer<ExceptionLogging>.Serialize(new ExceptionLogging()
                {
                    Date = CurrentDateTime.ToString(Culture.UtcDateTimeFormat),
                    Message = message,
                });

                WriteLogFile(objectSerialized);
            }
            catch { }
        }

        public static void Write(Exception exception, string module)
        {
            try
            {
                _module = module;
                var currentStack = new System.Diagnostics.StackTrace(true).ToString();

                string exceptionData = ExceptionData(exception.Data);

                StackTraceLogging stackTraceLogging = new StackTraceLogging()
                {
                    Date = CurrentDateTime.ToString(Culture.UtcDateTimeFormat),
                    Exception = new ExceptionLog()
                    {
                        Source = exception.Source,
                        Message = exception.Message,
                        Stack = exception.StackTrace,
                        FullStack = currentStack,
                        Data = exceptionData,
                    }
                };

                List<InnerExceptionLog> innerExceptionLogs = new List<InnerExceptionLog>();

                if (exception.InnerException != null)
                {
                    string innerExceptionData = ExceptionData(exception.InnerException.Data);

                    InnerExceptionLog innerExceptionLog = new InnerExceptionLog()
                    {
                        Source = exception.InnerException.Source,
                        Message = exception.InnerException.Message,
                        Stack = exception.InnerException.StackTrace,
                        Data = innerExceptionData,
                        FullStack = currentStack,
                    };

                    innerExceptionLogs.Add(innerExceptionLog);
                }

                stackTraceLogging.InnerExceptions = innerExceptionLogs;

                string objectSerialized = JsonSerializer<StackTraceLogging>.Serialize(stackTraceLogging);

                WriteLogFile(objectSerialized);

            }
            catch (Exception e){ }
        }

        private static void WriteLogFile(string text)
        {
            //TODO: Fix before write
            //TODO: Verify if file exist
            //TODO: If exist? -> Un serialize file and add one more json line.
            StreamWriter streamWriter = new StreamWriter(Filename, true);
            streamWriter.WriteLine(text);
            streamWriter.Close();
        }

        private static string ExceptionData(IDictionary Data)
        {
            string exceptionData = "";
            if (Data.Count > 0)
            {
                foreach (var dictionaryException in Data)
                {
                    exceptionData += dictionaryException + "\r\n";
                }
            }

            return exceptionData;
        }

    }
}