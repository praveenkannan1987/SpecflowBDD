using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Utility
{
    public class AppConfig
    {
        public bool IsHeadless { get; set; }
        public bool ScreenShotEveryStep { get; set; }
        public string URL { get; set; }
        public string Database { get; set; }
        public string BrowserType { get; set; }
        public string RestURL { get; set; }
    }
}
