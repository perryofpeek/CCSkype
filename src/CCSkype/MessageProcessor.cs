using CCSkype.Commands;

namespace CCSkype
{
    public class MessageProcessor : IMessageProcessor
    {        
        private readonly ICmdFactory _cmdFactory;

        public MessageProcessor(ICmdFactory cmdFactory)
        {            
            _cmdFactory = cmdFactory;
        }

        public IResponse Process(string message)
        {                                  
            var cmd = _cmdFactory.Create(message);
            var response = new Response(cmd.Execute(),true);            
            return response;
        }
    }
}