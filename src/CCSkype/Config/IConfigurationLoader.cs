namespace CCSkype.Config
{
    public interface IConfigurationLoader
    {
        Configuration Load(string path);
        void Save(Configuration configuration, string path);
    }
}