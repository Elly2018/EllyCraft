namespace EllyCraft
{
    interface Logger
    {
        /// <summary>
        /// Return the level of this logger filter level
        /// </summary>
        /// <returns></returns>
        int GetLevel();
        /// <summary>
        /// Normal output
        /// Define how logger will react to the message
        /// </summary>
        /// <param name="o"></param>
        void Log(object o);
        /// <summary>
        /// Error output
        /// Define how logger will react to the message
        /// </summary>
        /// <param name="o"></param>
        void LogError(object o);
        /// <summary>
        /// Warning output
        /// Define how logger will react to the message
        /// </summary>
        /// <param name="o"></param>
        void LogWarning(object o);
    }
}
