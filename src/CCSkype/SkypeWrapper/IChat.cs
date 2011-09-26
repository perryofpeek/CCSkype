namespace CCSkype.SkypeWrapper
{
    public interface IChat
    {
        SKYPE4COMLib.Chat GetChat { get; }
        void OpenWindow();
        void Leave();
        void SendMessage(string message);
    }
}