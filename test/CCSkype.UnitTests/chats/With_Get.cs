using System;
using CCSkype.SkypeWrapper;
using NUnit.Framework;
using Rhino.Mocks;

namespace CCSkype.UnitTests.chats
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_Get
    {

        private ISkype skype;

        [SetUp]
        public void SetUp()
        {
            skype = MockRepository.GenerateMock<ISkype>();
        }

        [Test]
        public void Should_get_new_chat()
        {
            var name = Guid.NewGuid().ToString();
            var userCol = MockRepository.GenerateMock<IUserCollection>();
            var chatMock = MockRepository.GenerateMock<IChat>();
            skype.Expect(x => x.CreateChatMultiple(userCol, name)).Return(chatMock);
            var chats = new Chats(skype);
            var chat = chats.Get(name, userCol);
            Assert.That(chat, Is.Not.Null);           
            skype.VerifyAllExpectations();
        }

        [Test]
        public void Should_get_exsisting_chat()
        {
            var name = Guid.NewGuid().ToString();
            var userCol = MockRepository.GenerateMock<IUserCollection>();
            skype.Expect(x => x.CreateChatMultiple(userCol, name)).Repeat.Once();
            var chats = new Chats(skype);
            var chat = chats.Get(name, userCol);
            //Test
            var chat1 = chats.Get(name, userCol);
            //Assert
            Assert.That(chat1, Is.Not.Null);           
            skype.VerifyAllExpectations();
        }
    }
}