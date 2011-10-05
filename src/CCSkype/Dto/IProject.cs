namespace CCSkype
{
    public interface IProject
    {
        string name { get; }
        
        string activity { get; }
        
        string lastBuildStatus { get; }
        
        string lastBuildLabel { get; }
        
        string lastBuildTime { get; }
        
        string webUrl { get; }
        
        string PipelineName { get; }
        
        string GetMessage();
        
        string GetUniqueKey();
    }
}