namespace CCSkype.SkypeWrapper
{
    public class Chat : IChat
    {
        private readonly SKYPE4COMLib.Chat _chat;

        public Chat(SKYPE4COMLib.Chat chat, string name)
        {
            Name = name;
            _chat = chat;
        }

        public SKYPE4COMLib.Chat GetChat
        {
            get { return _chat; }
        }

        public string Name { get; private set; }

        public void OpenWindow()
        {          
            _chat.OpenWindow();
        }

        public void Leave()
        {
            _chat.Leave();            
        }

        public void SendMessage(string message)
        {
            _chat.SendMessage(message);
        }
    }
}