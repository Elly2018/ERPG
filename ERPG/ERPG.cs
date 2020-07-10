using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPG
{
    /// <summary>
    /// API reference
    /// </summary>
    public class ERPG
    {
        public const int BuildVersion = 0;
        public const int BetaVersion = 0;
        public const int AlphaVersion = 1;
        public const string VersionInformation = "2020";
        public static string Version
        {
            get
            {
                return $"{BuildVersion}.{BetaVersion}.{AlphaVersion}_{VersionInformation}";
            }
        }
    }
}
