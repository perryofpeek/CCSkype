namespace CCSkype
{
    public interface IUserGroups
    {
        bool IsMonitoring(string pipelineName);
        
        void Add(IUserGroup someGroup);

        void Alert(IProject project);
    }
}