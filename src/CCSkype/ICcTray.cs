using System.Collections.Generic;

namespace CCSkype
{
    public interface ICcTray
    {
        List<Project> FailedPipelines { get; }
        void Load();
    }
}