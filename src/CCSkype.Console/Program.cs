
namespace CCSkype.Console
{
    class Program
    {      
        static void Main(string[] args)
        {
            const string configName = "config.xml";
            Resources.UnPackAllResourcesToDisk();
            Resources.WriteDefaultConfig(configName);
            Resources.RegisterComDll("SKYPE4COMLib.dll");            
            EntryPoint.Start(configName);
        }
    }
}