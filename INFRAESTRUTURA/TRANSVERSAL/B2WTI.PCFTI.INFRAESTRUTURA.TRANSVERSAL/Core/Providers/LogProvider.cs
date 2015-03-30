
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Core.Providers
{
    using log4net;
    using log4net.Config;
    using Schedules;
    using System;

    public enum LogLevelL4N
    {
        DEBUG = 1,
        ERROR,
        FATAL,
        INFO,
        WARN
    }

    public static class LogProvider
    {
        static LogProvider()
        {
            XmlConfigurator.Configure(); 
        }

        private static ILog logger;

        private static Scheduler scheduler = new Scheduler();
        private static string Message;
        private static LogLevelL4N logLevel;
        private static Exception exception;

        private const string CONST_STRINGDATEFORMAT = "yyyyMMddhhmmssfff";
        private const string CONST_STRINGLOGIDFORMAT = "LOG{0}";

        public static void Log(ILog ilog, LogLevelL4N level, string message)
        {
            try
            {
                logger = ilog;
                Message = message;
                logLevel = level;

                Job job = new Job(string.Format(CONST_STRINGLOGIDFORMAT, DateTime.Now.ToString(CONST_STRINGDATEFORMAT)));
                job.Run.Once();

                scheduler.SubmitJob(job, WriteLog);
            }
            catch
            {
            }
        }

        public static void Log(ILog ilog, LogLevelL4N level, Exception Ex)
        {
            try
            {
                logger = ilog;
                exception = Ex;
                logLevel = level;

                Job job = new Job(string.Format(CONST_STRINGLOGIDFORMAT, DateTime.Now.ToString(CONST_STRINGDATEFORMAT)));
                job.Run.Once();

                scheduler.SubmitJob(job, WriteLogFull);
            }
            catch
            {
            }
        }

        private static void WriteLog(Job job)
        {
            try
            {
                switch (logLevel)
                {
                    case LogLevelL4N.DEBUG:
                        logger.Debug(Message);
                        break;
                    case LogLevelL4N.ERROR:
                        logger.Error(Message);
                        break;
                    case LogLevelL4N.FATAL:
                        logger.Fatal(Message);
                        break;
                    case LogLevelL4N.INFO:
                        logger.Info(Message);
                        break;
                    case LogLevelL4N.WARN:
                        logger.Warn(Message);
                        break;
                }
            }
            catch
            {
            }
        }

        private static void WriteLogFull(Job job)
        {
            try
            {
                switch (logLevel)
                {
                    case LogLevelL4N.DEBUG:
                        logger.Debug(exception.Message, exception);
                        break;
                    case LogLevelL4N.ERROR:
                        logger.Error(exception.Message, exception);
                        MailProvider.EnviarErros(exception);
                        break;
                    case LogLevelL4N.FATAL:
                        logger.Fatal(exception.Message, exception);
                        break;
                    case LogLevelL4N.INFO:
                        logger.Info(exception.Message, exception);
                        break;
                    case LogLevelL4N.WARN:
                        logger.Warn(exception.Message, exception);
                        break;
                }
            }
            catch
            {
            }
        }
    }


}
