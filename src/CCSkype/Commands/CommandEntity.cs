using System.Linq;

namespace CCSkype.Commands
{
    public class CommandEntity
    {
        public CommandEntity(string command, string parameter)
        {
            Command = command.Trim();
            SetDefaultParameter();
            ParseParametersIntoArray(parameter);
        }

        private void SetDefaultParameter()
        {
            Parameter = new string[1];
            Parameter[0] = string.Empty;
        }

        private void ParseParametersIntoArray(string parameter)
        {
            if (parameter == "") return;
            var items = parameter.Split(' ');
            Parameter = items.Select(t => t.Trim()).Where(p => p.Length != 0).ToArray();
        }

        public string Command { get; private set; }

        public string[] Parameter { get; private set; }
    }
}