using System;
using System.Configuration;

namespace CCSkype.Console
{
    public class EntryPoint
    {
        public static void Start(string name)
        {
            var controller = new Controller
                                 {
                                     Configuration = @"config.xml",
                                     CcTrayPassword = GetKey("CcTrayPassword", "**Fish22"),
                                     CcTrayUsername = GetKey("CcTrayUsername", "owainp"),
                                     HttpTimeout = Convert.ToInt32(GetKey("HttpTimeout", "20")),
                                     PollTime = Convert.ToInt32(GetKey("PollTime", "10")),
                                     CcTrayUrl = GetKey("CcTrayUrl", "http://build.london.ttldev.local:8153/go/cctray.xml")
                                 };
            controller.Start();
        }

        private static string GetKey(string name, string defaultValue)
        {
            return ConfigurationManager.AppSettings[name] ?? defaultValue;
        }
    }
}