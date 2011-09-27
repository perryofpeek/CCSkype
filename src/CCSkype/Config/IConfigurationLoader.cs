namespace CCSkype.Config
{
    public interface IConfigurationLoader
    {
        Configuration Load(string path);
    }
}