using System.Collections.Generic;

namespace EllyCraft
{
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
            System.Console.ForegroundColor = System.ConsoleColor.White;
            System.Console.WriteLine(o.ToString());

            foreach (var i in loggers)
            {
                if(i.GetLevel() <= level)
                    i.Log(o.ToString());
            }
        }
        public static void LogError(object o)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine(o.ToString());

            foreach (var i in loggers)
            {
                if (i.GetLevel() <= level)
                    i.LogError(o.ToString());
            }
        }
        public static void LogWarning(object o)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine(o.ToString());

            foreach (var i in loggers)
            {
                if (i.GetLevel() <= level)
                    i.LogWarning(o.ToString());
            }
        }

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
