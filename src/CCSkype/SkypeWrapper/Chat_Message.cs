namespace CCSkype.SkypeWrapper
{
// ReSharper disable InconsistentNaming
    public class Chat_Message : IChat_Message
    {
        private SKYPE4COMLib.ChatMessage _chatMessage;

        public Chat_Message(SKYPE4COMLib.ChatMessage chatMessage)
        {
            _chatMessage = chatMessage;            
        }
    }
}