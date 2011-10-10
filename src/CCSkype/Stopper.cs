namespace CCSkype
{
    public class Stopper : IStopper
    {
        public Stopper()
        {
            Stop = false;
        }

        public bool Stop { get; set; }
    }
}