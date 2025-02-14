using magic_heroes.GlobalUtils.HttpApi;
using UnityEngine;

namespace magic_heroes.Server.connection.handlers
{
    public class ConnectionMessageHandler : IMessageHandler
    {
        public Response HandleMessage(Request request)
        {
            Debug.Log("SERVER_INFO : ConnectionMessageHandler::HandleMessage");
            return CachedResponses.StubResponse;
        }
    }
}