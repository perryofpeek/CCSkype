using System.Collections.Generic;
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
            PollTime = 10;
        }

        private WindsorContainer CreateContainer(string url, int pollTime, string messageTemplate,string username,string password,int httpTimeout,string configuration)
        {
            var parameters = new List<Parameter>
                                 {
                                     Parameter.ForKey("username").Eq(username),
                                     Parameter.ForKey("password").Eq(password),
                                     Parameter.ForKey("timeoutInSeconds").Eq(httpTimeout.ToString())
                                 };
            

            var container = new WindsorContainer();
            container.Register(Component.For<ITimer>().ImplementedBy(typeof(Timer)));
            container.Register(Component.For<IWantToBeRun>().ImplementedBy(typeof(SkypeMessenger)).Parameters(Parameter.ForKey("messageTemplate").Eq(messageTemplate)));
            container.Register(Component.For<ISleeper>().ImplementedBy(typeof(Sleeper)).Parameters(Parameter.ForKey("timeInSeconds").Eq(pollTime.ToString())));
            container.Register(Component.For<ICcTray>().ImplementedBy(typeof(CcTray)));
            //container.Register(Component.For<IProjectwatcher>().ImplementedBy(typeof(Projectwatcher)));
            container.Register(Component.For<IUserGroups>().ImplementedBy(typeof(UserGroups)));
            container.Register(Component.For<IHttpGet>().ImplementedBy(typeof(HttpGet)).Parameters(parameters.ToArray()));
            container.Register(Component.For<IEndPoint>().ImplementedBy(typeof(EndpointImpl)).Parameters(Parameter.ForKey("url").Eq(url)));
            container.Register(Component.For<ISkype>().ImplementedBy(typeof(Skype)));
            container.Register(Component.For<IConfigurationLoader>().ImplementedBy(typeof(ConfigurationLoader)));
            container.Register(Component.For<ILoader>().ImplementedBy(typeof(Loader)));
            container.Register(Component.For<IChats>().ImplementedBy(typeof(Chats)));
            container.Register(Component.For<IBuildCollection>().ImplementedBy(typeof(BuildCollection)));
            container.Register(Component.For<IMessengerClient>().ImplementedBy(typeof(MessengerClient)));                                    
            container.Kernel.AddComponentInstance<IUserCollection>(new UserCollection(new SKYPE4COMLib.UserCollection()));            
            var projectwatcher = new Projectwatcher(container.Resolve<ILoader>().GetUserGroups(container.Resolve<IConfigurationLoader>().Load(configuration)));
            container.Kernel.AddComponentInstance<IProjectwatcher>(projectwatcher);                                             
            return container;
        }

       
        public void Start()
        {
            var container = CreateContainer(CcTrayUrl, PollTime, MessageTemplate, CcTrayUsername, CcTrayPassword, HttpTimeout, Configuration);
            var timer = container.Resolve<ITimer>();
            timer.Start();            
        }
    }
}