using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace CCSkype.Console
{
    public class Resources
    {
        private static void UnPackResourcesAndLoad()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                String resourceName = "CCSkype.Console." + new AssemblyName(args.Name).Name + ".dll";
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
        }

        public static void UnPackAllResourcesToDisk()
        {
            UnPackResourcesAndLoad();
            WriteResourceIfNotExsist("Castle.Core.dll", Resource.Castle_Core);
            WriteResourceIfNotExsist("Castle.Windsor.dll", Resource.Castle_Windsor);
            WriteResourceIfNotExsist("Skype4Com.dll", Resource.Skype4COM);
            WriteResourceIfNotExsist("Interop.Skype4COMLib.dll", Resource.Interop_SKYPE4COMLib);
        }

        private static void WriteResourceIfNotExsist(string path, byte[] data)
        {
            if (!File.Exists(path))
            {
                File.WriteAllBytes(path, data);
            }
        }

        public static void WriteDefaultConfig(string name)
        {
            if (!File.Exists(name))
            {
                var lines = new List<string>
                                {
                                    "<?xml version='1.0' encoding='utf-8' ?>",
                                    "<Configuration cctrayUri='' pollTime='10' CcTrayUsername='owainp' CcTrayPassword='**Fish22' HttpTimeout='30'>",
                                        "<Pipeline name='Git'>",
                                            "<users>",
                                                "<user skypeName='londongoserver' /> ",
                                            "</users>",
                                        "</Pipeline>",
                                    "</Configuration>"
                                };
                File.WriteAllLines(name, lines);
            }
        }         

        public static void RegisterComDll(string name)
        {
            var p = new Process
                        {
                            StartInfo = new ProcessStartInfo("regsvr32.exe")
                                            {
                                                CreateNoWindow = true, 
                                                Arguments = "/s " + name
                                            }
                        };             
            p.Start();
        }
    }
}