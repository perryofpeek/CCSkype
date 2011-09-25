namespace CCSkype
{
    public class CcSkype
    {
        private readonly ICcTray _cctray;


        public CcSkype(ICcTray cctray)
        {
            _cctray = cctray;
        }

        public void Process()
        {
            _cctray.Load();
            var failures = _cctray.FailedPipelines;
            foreach (var project in failures)
            {
                

            }
        }
    }
}