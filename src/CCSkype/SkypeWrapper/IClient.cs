namespace CCSkype.SkypeWrapper
{
    public interface IClient
    {
        SKYPE4COMLib.Client GetClient();
        bool IsRunning();
        void Start(bool minimised,bool noSplash);
    }
}