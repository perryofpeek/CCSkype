using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace CCSkype.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register(AllTypes.Of<ITimer>().FromAssembly(Assembly.GetExecutingAssembly()));
            var timer = container.Resolve<ITimer>();
            timer.Start();
        }
    }
}
