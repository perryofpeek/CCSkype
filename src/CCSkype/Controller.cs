using System.Collections.Generic;
using CCSkype.Commands;
using CCSkype.Config;
using CCSkype.SkypeWrapper;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace CCSkype
{
    public class Controller
    {
        public string CcTrayUrl { get; set; }

        public int PollTime { get; set; }

        public string MessageTemplate { get; set; }
    
        public string CcTrayUsername { get; set; }

        public string CcTrayPassword { get; set; }

        public int HttpTimeout { get; set; }

        public string Configuration { get; set; }

        public Controller()
        {
            HttpTimeout = 10;
            MessageTemplate = "{0} Build has failed with id {1}";
            CcTrayPassword = "NotSet";
            CcTrayUsername = "NotSet";
            CcTrayUrl = "NotSet";
            PollTime = 20;
            Container = new WindsorContainer();
        }

        public WindsorContainer Container { get; set; }

        private WindsorContainer CreateContainer(string url, int pollTime, string messageTemplate,string username,string password,int httpTimeout,string configuration)
        {
            var parameters = new List<Parameter>
                                 {
                                     Parameter.ForKey("username").Eq(username),
                                     Parameter.ForKey("password").Eq(password),
                                     Parameter.ForKey("timeoutInSeconds").Eq(httpTimeout.ToString())
                                 };
                      
            Container.Register(Component.For<ITimer>().ImplementedBy(typeof(Timer)));
            Container.Register(Component.For<IStopper>().ImplementedBy(typeof(Stopper)));
            Container.Register(Component.For<IWantToBeRun>().ImplementedBy(typeof(SkypeMessenger)).Parameters(Parameter.ForKey("messageTemplate").Eq(messageTemplate)));
            Container.Register(Component.For<ISleeper>().ImplementedBy(typeof(Sleeper)).Parameters(Parameter.ForKey("timeInSeconds").Eq(pollTime.ToString())));
            Container.Register(Component.For<ICcTray>().ImplementedBy(typeof(CcTray)));            
            Container.Register(Component.For<IUserGroups>().ImplementedBy(typeof(UserGroups)));
            Container.Register(Component.For<IHttpGet>().ImplementedBy(typeof(HttpGet)).Parameters(parameters.ToArray()));
            Container.Register(Component.For<IEndPoint>().ImplementedBy(typeof(EndpointImpl)).Parameters(Parameter.ForKey("url").Eq(url)));
            Container.Register(Component.For<ISkype>().ImplementedBy(typeof(Skype)));
            Container.Register(Component.For<IConfigurationLoader>().ImplementedBy(typeof(ConfigurationLoader)));
            Container.Register(Component.For<ILoader>().ImplementedBy(typeof(Loader)));
            Container.Register(Component.For<IChats>().ImplementedBy(typeof(Chats)));
            Container.Register(Component.For<IBuildCollection>().ImplementedBy(typeof(BuildCollection)));
            Container.Register(Component.For<IMessengerClient>().ImplementedBy(typeof(MessengerClient)));
            Container.Register(Component.For<IMessageProcessor>().ImplementedBy(typeof(MessageProcessor)));
            Container.Register(Component.For<ICmdFactory>().ImplementedBy(typeof(CmdFactory)));
            Container.Register(Component.For<ICommandParser>().ImplementedBy(typeof(CommandParser)));

             
            if (!Container.Kernel.HasComponent("CCSkype.SkypeWrapper.IUserCollection"))
            {
                Container.Kernel.AddComponentInstance<IUserCollection>(new UserCollection(new SKYPE4COMLib.UserCollection()));                
            }
            
            var projectwatcher = new Projectwatcher(Container.Resolve<ILoader>().GetUserGroups(Container.Resolve<IConfigurationLoader>().Load(configuration)));
            Container.Kernel.AddComponentInstance<IProjectwatcher>(projectwatcher);                               
            return Container;
        }

        public void Start()
        {
            var container = CreateContainer(CcTrayUrl, PollTime, MessageTemplate, CcTrayUsername, CcTrayPassword, HttpTimeout, Configuration);
            var timer = container.Resolve<ITimer>();
            timer.Start();            
        }
    }
}