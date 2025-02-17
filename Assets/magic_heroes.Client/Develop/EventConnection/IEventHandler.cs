namespace magic_heroes.Client.EventConnection
{
    public interface IEventHandler
    {
        public void HandleIncomingEvent(IncomingEvent incomingEvent);
    }
}