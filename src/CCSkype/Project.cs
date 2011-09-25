namespace CCSkype
{
    public class Project
    {
        public Project(string name, string activity, string lastBuildStatus, string lastBuildLabel, string lastBuildTime, string webUrl)
        {
            this.name = name;
            this.activity = activity;
            this.lastBuildStatus = lastBuildStatus;
            this.lastBuildLabel = lastBuildLabel;
            this.lastBuildTime = lastBuildTime;
            this.webUrl = webUrl;
            _pipelineName = name.Trim();
            if (name.IndexOf("::") > 0)
            {
                _pipelineName = name.Substring(0, name.IndexOf("::")).Trim();     
            }                       
        }

        public string name { get; private set; }

        public string activity { get; private set; }

        public string lastBuildStatus { get; private set; }

        public string lastBuildLabel { get; private set; }

        public string lastBuildTime { get; private set; }

        public string webUrl { get; private set; }

        public string PipelineName
        {
            get { return _pipelineName; }           
        }

        private string _pipelineName;
    }
}