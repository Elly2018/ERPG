namespace ERPG
{
    public interface ILogger
    {
        void Log(string tag, string prefix, string message);
        void LogWarning(string tag, string prefix, string message);
        void LogError(string tag, string prefix, string message);
        void LogException(string tag, string prefix, string message);
    }
}
