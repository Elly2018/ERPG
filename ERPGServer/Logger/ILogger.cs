using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPGServer
{
    public interface ILogger
    {
        void Log(string tag, string message);
        void LogWarning(string tag, string message);
        void LogError(string tag, string message);
        void LogException(string tag, string message);
    }
}
