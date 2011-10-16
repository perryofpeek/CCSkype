using System.Collections.Generic;

namespace CCSkype
{
    public interface ICcTray
    {
        List<Project> FailedPipelines();
        List<Project> AllPipelines();
        List<string> AllPipelineNames();
        void Load();
    }
}