using magic_heroes.GlobalUtils.HttpApi;

namespace magic_heroes.Server.connection
{
    public interface IMessageHandler
    {
        public Response HandleMessage(Request request);
    }
}