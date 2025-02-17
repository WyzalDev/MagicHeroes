using magic_heroes.GlobalUtils.HttpApi;
using UnityEngine;

namespace magic_heroes.Server.connection.handlers
{
    public class ResetMessageHandler : IMessageHandler
    {
        public Response HandleMessage(Request request)
        {
            Debug.Log("SERVER_INFO : ResetMessageHandler::HandleMessage");
            return CachedResponses.StubResponse;
        }
    }
}