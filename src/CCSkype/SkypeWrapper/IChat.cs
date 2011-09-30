namespace CCSkype.SkypeWrapper
{
    public interface IChat
    {
        SKYPE4COMLib.Chat GetChat { get; }
        
        string Name { get; }
        
        void OpenWindow();
        
        void Leave();
        
        void SendMessage(string message);
    }
}