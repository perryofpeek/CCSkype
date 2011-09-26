using System;
using System.Collections.Generic;
using NUnit.Framework;
using SKYPE4COMLib;
using SkypeClient;
using User = SKYPE4COMLib.User;

namespace SkypeUnitTests
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_client
    {
        [Test]
        public void Should_send_message_to_group()
        {
            var oSkype = new Skype();
            if (oSkype.Client.IsRunning == false)
            {
                oSkype.Client.Start(false, true);
            }
            UserCollection users = oSkype.Friends;
            foreach (User f in users)
            {
                Console.WriteLine(f.DisplayName + "|" + f.FullName + "|" + f.Handle);
            }
            //var msg = oSkype.SendMessage("testgogroups", "some text...");
            var om = new UserCollection();
            om.Add(oSkype.get_User("testgogroups"));
            om.Add(oSkype.get_User("jonny.plankton"));
            var oc = oSkype.CreateChatMultiple(om);
            oc.OpenWindow();
            //oc.Topic = "Build is broken";
            oc.SendMessage("Build is broken");
            oc.Leave();
        }

        [Test]
        public void Should_send_message_to_group_impl()
        {
            var skypeClient = new Skype_Client(new Skype());
            var users = new List<SkypeClient.User>();
            users.Add(new SkypeClient.User("testgogroups"));
            users.Add(new SkypeClient.User("jonny.plankton"));
            var userGroup = new UserGroup(skypeClient, users, "Trumps_trunk");
            userGroup.Send(Guid.NewGuid().ToString());
        }



    }
}
