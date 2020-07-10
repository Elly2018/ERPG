using System;
using System.IO;
using System.Net.Http.Headers;
using System.Text;

namespace ERPGServer
{
    public class FileLog : ILogger
    {
        private string filename;
        private string lastest;
        public FileLog()
        {
            filename = Path.Combine("log", $"{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.log");
            lastest = Path.Combine("log", "Latest.log");
            File.Delete(lastest);
        }

        public void Log(string tag, string message)
        {
            Outputmessage(tag, message);
        }

        public void LogError(string tag, string message)
        {
            Outputmessage(tag, message);
        }

        public void LogException(string tag, string message)
        {
            Outputmessage(tag, message);
        }

        public void LogWarning(string tag, string message)
        {
            Outputmessage(tag, message);
        }

        private void Outputmessage(string tag, string message)
        {
            string realmessage = $"[{tag}] " + message + "\n";
            byte[] bytes = Encoding.UTF8.GetBytes(realmessage);

            FileStream fs = File.OpenWrite(filename);
            fs.Seek(0, SeekOrigin.End);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            fs = File.OpenWrite(lastest);
            fs.Seek(0, SeekOrigin.End);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }
    }
}
