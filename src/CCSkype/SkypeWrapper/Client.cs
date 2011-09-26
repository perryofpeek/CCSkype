namespace CCSkype.SkypeWrapper
{
    public class Client : IClient
    {
        private readonly SKYPE4COMLib.Client _client;

        public Client(SKYPE4COMLib.Client client)
        {
            _client = client;
        }

        public SKYPE4COMLib.Client GetClient()
        {
            return _client;
        }

        public bool IsRunning()
        {
            return _client.IsRunning;
        }

        public void Start(bool minimised,bool noSplash)
        {
            _client.Start(minimised, noSplash);
        }
    }
}