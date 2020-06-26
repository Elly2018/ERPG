namespace ERPG
{
    public sealed class Logger
    {
        private delegate void LogHandle(string tag, string prefix, string message);
        private static LogHandle _Log;
        private static LogHandle _LogWarning;
        private static LogHandle _LogError;
        private static LogHandle _LogException;

        public static void RegisterLogger(LoggerBase target)
        {
            _Log += target.Log;
            _LogWarning += target.LogWarning;
            _LogError += target.LogError;
            _LogException += target.LogException;
        }

        public static void CleanLogger()
        {
            _Log = null;
            _LogWarning = null;
            _LogError = null;
            _LogException = null;
        }

        public static void Log(string tag, string prefix, string message)
        {
            if(_Log != null )
                _Log.Invoke(tag, prefix, message);
        }

        public static void LogWarning(string tag, string prefix, string message)
        {
            if (_LogWarning != null)
                _LogWarning.Invoke(tag, prefix, message);
        }

        public static void LogError(string tag, string prefix, string message)
        {
            if (_LogError != null)
                _LogError.Invoke(tag, prefix, message);
        }

        public static void LogException(string tag, string prefix, string message)
        {
            if (_LogException != null)
                _LogException.Invoke(tag, prefix, message);
        }
    }
}
