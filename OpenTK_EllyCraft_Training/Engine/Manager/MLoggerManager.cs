using System.Collections.Generic;

namespace EllyCraft
{
    /// <summary>
    /// The master logger, which will register at the begining of the program
    /// </summary>
    class SystemLogger : Logger
    {
        private int SystemLevel = 3;

        /// <summary>
        /// The level between 1 - 5, it will define the filter level of this logger
        /// </summary>
        /// <param name="level"></param>
        public SystemLogger(int level)
        {
            SystemLevel = level;
        }

        public int GetLevel()
        {
            return SystemLevel;
        }
        public void Log(object o)
        {
            System.Console.ForegroundColor = System.ConsoleColor.White;
            System.Console.WriteLine(o.ToString());
        }
        public void LogError(object o)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine(o.ToString());
        }
        public void LogWarning(object o)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine(o.ToString());
        }
    }

    /// <summary>
    /// When program active logger manager which program want to print something.
    /// It will loop all the logger register before, and trigger all interface.
    /// User can custom their own logger system.
    /// </summary>
    sealed class MLoggerManager
    {
        private static List<Logger> loggers = new List<Logger>();
        private static int level = 1;

        public static void AddLogger(Logger logger)
        {
            loggers.Add(logger);
        }
        public static void ClearLogger()
        {
            loggers.Clear();
        }
        public static void SetLevel(int _level)
        {
            if (_level > 5 || _level < 1)
            {
                LogWarning("Log level must be 1 - 5");
                return;
            }

            level = _level;
        }

        public static int GetLevel()
        {
            return level;
        }
        public static void Log(object o)
        {
            foreach (var i in loggers)
            {
                if(i.GetLevel() >= level)
                    i.Log(o.ToString());
            }
        }
        public static void LogError(object o)
        {
            foreach (var i in loggers)
            {
                if (i.GetLevel() >= level)
                    i.LogError(o.ToString());
            }
        }
        public static void LogWarning(object o)
        {
            foreach (var i in loggers)
            {
                if (i.GetLevel() >= level)
                    i.LogWarning(o.ToString());
            }
        }

        /// <summary>
        /// The pre-define message can be use
        /// Usually will return a string for logger to output
        /// </summary>
        public class LoggerMessage
        {
            public static string CannotGetResource(string resourceName, string path)
            {
                return "Cannot get resource " + resourceName + " from path " + path;
            }

            public static string OutOfRange(int index)
            {
                return "The index you select is out of range";
            }

            public static string ObjectDoesNotExist<T>()
            {
                return "The object does not exist " + typeof(T).Name;
            }

            public static string ObjectDoesNotExist<T>(string name)
            {
                return "The object does not exist " + typeof(T).Name + ", Object name " + name;
            }

            public static string LoadingFailed(string path)
            {
                return "File loading file " + path;
            }
        }
    }
}
