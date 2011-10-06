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

            var controller = new Controller();
            controller.CcTrayUrl = "http://localhost/Cctray.xml";
            controller.CcTrayUsername = "username";
            controller.CcTrayPassword = "password";
            controller.HttpTimeout = 30;
            controller.Configuration = @"RealUsers.xml";
            controller.Start();
        }
    }
}
