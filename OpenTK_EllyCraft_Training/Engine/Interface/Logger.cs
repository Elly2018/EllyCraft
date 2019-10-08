namespace EllyCraft
{
    interface Logger
    {
        int GetLevel();
        void Log(object o);
        void LogError(object o);
        void LogWarning(object o);
    }
}
