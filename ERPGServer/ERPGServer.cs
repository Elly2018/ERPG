using System;
using System.IO;

namespace ERPGServer
{
    class ERPGServer
    {
        private const string InitializeTag = "Initialization";

        private bool exit = false;

        /// <summary>
        /// 
        /// </summary>
        public ERPGServer()
        {
            /*
             * Folder initialization
             * If excute the first time, create root structure
            */
            if (!Directory.Exists("mods")) Directory.CreateDirectory("mods");
            if (!Directory.Exists("config")) Directory.CreateDirectory("config");
            if (!Directory.Exists("data")) Directory.CreateDirectory("data");
            if (!Directory.Exists("language")) Directory.CreateDirectory("language");
            if (!Directory.Exists("log")) Directory.CreateDirectory("log");

            ServerLog.AddLogger(new ConsoleLog());
            ServerLog.AddLogger(new FileLog());

            ServerLog.Log(InitializeTag, "Core library version: " + ERPGCore.ERPGCore.Version);
            ServerLog.Log(InitializeTag, "Game version: " + ERPG.ERPG.Version);

            ServerLog.Log(InitializeTag, "Start initialize...");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            Initialize();
            PostInitialize();
            FinalInitialize();
            while (!exit)
            {
                Loop();
            }
        }

        /// <summary>
        /// Loading resource and mods
        /// </summary>
        private void Initialize()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void PostInitialize()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void FinalInitialize()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void Loop()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void Exit()
        {

        }

        static void Main(string[] args)
        {
            ERPGServer app = new ERPGServer();
            app.Run();
            Console.Write("press any key to continue...");
            Console.Read();
        }
    }
}
