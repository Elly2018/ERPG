namespace ERPGCore
{
    /// <summary>
    /// Create your own logger type and register to <see cref="Logger"/>
    /// </summary>
    public abstract class LoggerBase : ILogger
    {
        public virtual void Log(string tag, string prefix, string message)
        {
            
        }

        public virtual void LogError(string tag, string prefix, string message)
        {
            
        }

        public virtual void LogException(string tag, string prefix, string message)
        {
            
        }

        public virtual void LogWarning(string tag, string prefix, string message)
        {
            
        }
    }
}
